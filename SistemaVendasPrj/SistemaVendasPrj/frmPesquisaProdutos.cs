using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SqlStringConnections;

namespace SistemaVendasPrj
{
    public partial class frmPesquisaProdutos : Form
    {
        public frmPesquisaProdutos()
        {
            InitializeComponent();
        }

        public DataSet CarregarGrid(string tabela)
        {
            DataSet DS;
            string cmd = string.Format("SELECT ID_PRODUTO AS 'ID', NOME_PRODUTO AS 'PRODUTO', CUSTO_PRODUTO AS 'CUSTO R$ (UNIT)', PRECO_VENDA AS 'VENDA R$ (UNIT)' FROM ARTIGO " + tabela);
            DS = Utilidade.Executar(cmd);
            return DS;
        }

        private void frmPesquisaProdutos_Load(object sender, EventArgs e)
        {
            grdProduto.DataSource = CarregarGrid("ARTIGO").Tables[0];
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisa.Text.Trim() == "")
            {
                grdProduto.DataSource = CarregarGrid("ARTIGO").Tables[0];
            }
        }

        private void grdProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelecionarProduto.PerformClick();
            }
        }

        private void btnPesqusiarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                string cmd = "SELECT * FROM ARTIGO WHERE NOME_PRODUTO LIKE('%" + txtPesquisa.Text.Trim() + "%')";
                ds = Utilidade.Executar(cmd);
                grdProduto.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não possível realizar a sua pesquisa, por favor tente novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelecionarProduto_Click(object sender, EventArgs e)
        {
            if (grdProduto.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void grdProduto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionarProduto.PerformClick();
        }
    }
}

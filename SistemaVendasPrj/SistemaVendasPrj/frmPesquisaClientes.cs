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
    public partial class frmPesquisaClientes : Form
    {
        public frmPesquisaClientes()
        {
            InitializeComponent();
        }

        public DataSet CarregarGrid(string tabela)
        {
            DataSet DS;
            string cmd = string.Format("SELECT * FROM " + tabela);
            DS = Utilidade.Executar(cmd);
            return DS;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if(txtPesquisa.Text.Trim() == "")
            {
                grdCliente.DataSource = CarregarGrid("CLIENTE").Tables[0];
            }
        }

        private void frmPesquisaClientes_Load(object sender, EventArgs e)
        {
            grdCliente.DataSource = CarregarGrid("CLIENTE").Tables[0];
        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            
        }

        private void grdCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelecionar.PerformClick();
            }
        }

        private void btnPesqusiarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                string cmd = "SELECT * FROM CLIENTE WHERE NOME_CLIENTE LIKE('%" + txtPesquisa.Text.Trim() + "%')";
                ds = Utilidade.Executar(cmd);
                grdCliente.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não possível realizar a sua pesquisa, por favor tente novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (grdCliente.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void grdCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar.PerformClick();
        }
    }
}

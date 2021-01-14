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
    public partial class frmPesquisaRelatorios : Form
    {
        public frmPesquisaRelatorios()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=BDLOJA;Integrated Security=True");
        public static int cont_linha = 0;
        private void btnPesquisarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                string cmd = "SELECT PEDIDOS.ID_PEDIDO, PEDIDOS.DATA_PEDIDO, PEDIDOS.DATA_ENTREGA, " +
                    "PEDIDOS.ID_CLIENTE, CLIENTE.NOME_CLIENTE, CLIENTE.CPF, CLIENTE.RUA, CLIENTE.NUMERO, " +
                    "CLIENTE.BAIRRO, CLIENTE.CIDADE, PEDIDOS.TOTAL FROM CLIENTE INNER JOIN PEDIDOS ON " +
                    "CLIENTE.ID_CLIENTE = PEDIDOS.ID_CLIENTE WHERE CLIENTE.NOME_CLIENTE LIKE('%" + txtPesquisa.Text.Trim() + "%')";
                ds = Utilidade.Executar(cmd);
                grdPesquisaRelatorios.DataSource = ds.Tables[0];
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

        private void frmPesquisaRelatorios_Load(object sender, EventArgs e)
        {
            btnPesquisarRelatorio.PerformClick();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {

            if (txtIdPedido.Text == "")
            {
                MessageBox.Show("Não foi possível encontrar um pedido, por favor pesquisar o cliente e selecione o cliente na tabela!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmRelatorioDePesquisa relpornome = new frmRelatorioDePesquisa(txtIdPedido.Text);
                relpornome.Show();
            }            
        }

        private void grdPesquisaRelatorios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnGerarRelatorio.PerformClick();
        }

        private void grdPesquisaRelatorios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtIdPedido.Text = grdPesquisaRelatorios.CurrentRow.Cells[0].Value.ToString();
            txtDataPedido.Text = grdPesquisaRelatorios.CurrentRow.Cells[1].Value.ToString();
            txtDataEntrega.Text = grdPesquisaRelatorios.CurrentRow.Cells[2].Value.ToString();
            txtIdCliente.Text = grdPesquisaRelatorios.CurrentRow.Cells[3].Value.ToString();
            txtNomeCliente.Text = grdPesquisaRelatorios.CurrentRow.Cells[4].Value.ToString();
            txtCpf.Text = grdPesquisaRelatorios.CurrentRow.Cells[5].Value.ToString();
            txtRua.Text = grdPesquisaRelatorios.CurrentRow.Cells[6].Value.ToString();
            txtNumero.Text = grdPesquisaRelatorios.CurrentRow.Cells[7].Value.ToString();
            txtBairro.Text = grdPesquisaRelatorios.CurrentRow.Cells[8].Value.ToString();
            txtCidade.Text = grdPesquisaRelatorios.CurrentRow.Cells[9].Value.ToString();
            txtTotal.Text = grdPesquisaRelatorios.CurrentRow.Cells[10].Value.ToString();
        }
    }
}

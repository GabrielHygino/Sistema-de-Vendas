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
using System.Text.RegularExpressions;

namespace SistemaVendasPrj
{
    public partial class frmCadastroProdutos : Form
    {
        public frmCadastroProdutos()
        {
            InitializeComponent();
        }

        public DataSet CarregarGrid(string tabela)
        {
            DataSet DS;
            string cmd = string.Format("SELECT ID_PRODUTO AS 'ID', NOME_PRODUTO AS 'NOME', CUSTO_PRODUTO AS 'CUSTO R$ (UNIT)', PRECO_VENDA AS 'VENDA R$ (UNIT)' FROM " + tabela);
            DS = Utilidade.Executar(cmd);
            return DS;
            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeProduto.Text.Trim() == "" || txtCustoUnit.Text.Trim() == "" || txtVendaUnit.Text.Trim() == "")
                {
                    MessageBox.Show("Não foi possível realizar este cadastro, por favor preencha os campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdProduto.Clear();
                    txtNomeProduto.Clear();
                    txtCustoUnit.Clear();
                    txtVendaUnit.Clear();

                    txtNomeProduto.Focus();
                }
                else
                {
                    string pattern = ",";
                    string replacement = ".";

                    Regex regEx = new Regex(pattern);
                    string custo = regEx.Replace(txtCustoUnit.Text, replacement);
                    string venda = regEx.Replace(txtVendaUnit.Text, replacement);

                    string cmd = string.Format("EXEC ATUALIZARPRODUTOS '{0}', '{1}','{2}','{3}'", txtIdProduto.Text.Trim(), txtNomeProduto.Text.Trim(), custo, venda);
                    MessageBox.Show("Produto inserido com sucesso no sistema!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(cmd);
                    txtIdProduto.Clear();
                    txtNomeProduto.Clear();
                    txtCustoUnit.Clear();
                    txtVendaUnit.Clear();
                    
                    txtNomeProduto.Focus();

                    grdProduto.DataSource = CarregarGrid("ARTIGO").Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar este cadastro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            txtIdProduto.Clear();
            txtNomeProduto.Clear();
            txtCustoUnit.Clear();
            txtVendaUnit.Clear();
            txtPesquisa.Clear();

            grdProduto.Refresh();

            txtNomeProduto.Focus();
        }

        private void frmCadastroProdutos_Load(object sender, EventArgs e)
        {
            grdProduto.DataSource = CarregarGrid("ARTIGO").Tables[0];            
        }

        private void grdProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProduto.Text = grdProduto.CurrentRow.Cells[0].Value.ToString();
            txtNomeProduto.Text = grdProduto.CurrentRow.Cells[1].Value.ToString();
            //custounit = Double.Parse(grdProduto.CurrentRow.Cells[2].Value.ToString());
            //txtCustoUnit.Text = custounit.ToString();
            txtCustoUnit.Text = grdProduto.CurrentRow.Cells[2].Value.ToString();
            txtVendaUnit.Text = grdProduto.CurrentRow.Cells[3].Value.ToString();            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeProduto.Text.Trim() == "" || txtCustoUnit.Text.Trim() == "" || txtVendaUnit.Text.Trim() == "")
                {
                    MessageBox.Show("Não foi possível alterar o cadastro deste produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdProduto.Clear();
                    txtNomeProduto.Clear();
                    txtCustoUnit.Clear();
                    txtVendaUnit.Clear();

                    txtNomeProduto.Focus();
                }
                else
                {

                    //Para alterar os campos de valores foi necessário fazer um replacement com o regex, ele altera a string de inserção no banco de virgula para ponto

                    string pattern = ",";
                    string replacement = ".";

                    Regex regEx = new Regex(pattern);
                    string custo = regEx.Replace(txtCustoUnit.Text, replacement);
                    string venda = regEx.Replace(txtVendaUnit.Text, replacement);

                    string cmd = string.Format("EXEC ALTERARPRODUTOS '{0}', '{1}', '{2}', '{3}'", txtIdProduto.Text.Trim(), txtNomeProduto.Text.Trim(), custo, venda);
                    MessageBox.Show("Cadastro do produto alterado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(cmd);
                    txtIdProduto.Clear();
                    txtNomeProduto.Clear();
                    txtCustoUnit.Clear();
                    txtVendaUnit.Clear();

                    txtNomeProduto.Focus();

                    grdProduto.DataSource = CarregarGrid("ARTIGO").Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível alterar o cadastro deste produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void grdProduto_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtIdProduto.Text = grdProduto.CurrentRow.Cells[0].Value.ToString();
            txtNomeProduto.Text = grdProduto.CurrentRow.Cells[1].Value.ToString();
            txtCustoUnit.Text = grdProduto.CurrentRow.Cells[2].Value.ToString();
            txtVendaUnit.Text = grdProduto.CurrentRow.Cells[3].Value.ToString();
        }

        private void txtCustoUnit_TextChanged(object sender, EventArgs e)
        {
            if (txtCustoUnit.TextLength > 0)
            {
                double custo = 0;
                if (Double.TryParse(txtCustoUnit.Text, out custo))
                {

                }
                else
                {
                    MessageBox.Show("Por favor insira apenas números no campo Quantidade!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustoUnit.Clear();
                    txtCustoUnit.Focus();
                }
            }
        }

        private void txtVendaUnit_TextChanged(object sender, EventArgs e)
        {
            if (txtVendaUnit.TextLength > 0)
            {
                double venda = 0;
                if (Double.TryParse(txtVendaUnit.Text, out venda))
                {

                }
                else
                {
                    MessageBox.Show("Por favor insira apenas números no campo Quantidade!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVendaUnit.Clear();
                    txtVendaUnit.Focus();
                }
            }
        }

        private void txtVendaUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInserir.PerformClick();
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                string cmd = "SELECT * FROM ARTIGO WHERE NOME_PRODUTO LIKE ('%" + txtPesquisa.Text.Trim() + "%')";
                ds = Utilidade.Executar(cmd);
                grdProduto.DataSource = ds.Tables[0];
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não possível realizar a sua pesquisa, por favor tente novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (txtIdProduto.Text.Trim() == "")
            {
                MessageBox.Show("Não foi possível excluir o produto do sistema, para excluir um cadastro por favor, selecione-o na tabela abaixo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdProduto.Clear();
                txtNomeProduto.Clear();
                txtCustoUnit.Clear();
                txtVendaUnit.Clear();

                txtNomeProduto.Focus();
            }
            else
            {
                try
                {
                    string cmd = string.Format("EXEC DELETARPRODUTOS '{0}'", txtIdProduto.Text.Trim());
                    MessageBox.Show("Produto excluído com sucesso do sistema!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(cmd);
                    txtIdProduto.Clear();
                    txtNomeProduto.Clear();
                    txtCustoUnit.Clear();
                    txtVendaUnit.Clear();

                    txtNomeProduto.Focus();

                    grdProduto.DataSource = CarregarGrid("ARTIGO").Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível inserir o produto no sistema, para excluir um cadastro por favor, selecione-o na tabela abaixo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

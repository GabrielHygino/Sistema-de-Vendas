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
using System.Globalization;

namespace SistemaVendasPrj
{
    public partial class frmPedidoVenda : Form
    {
        public frmPedidoVenda()
        {
            InitializeComponent();
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {


        }

        private void btnPesqusiarCliente_Click(object sender, EventArgs e)
        {
            frmPesquisaClientes pesqcliente = new frmPesquisaClientes();
            pesqcliente.ShowDialog();

            if (pesqcliente.DialogResult == DialogResult.OK)
            {
                txtIdCliente.Text = pesqcliente.grdCliente.Rows[pesqcliente.grdCliente.CurrentRow.Index].Cells[0].Value.ToString();
                txtNomeCliente.Text = pesqcliente.grdCliente.Rows[pesqcliente.grdCliente.CurrentRow.Index].Cells[1].Value.ToString();
                txtCpf.Text = pesqcliente.grdCliente.Rows[pesqcliente.grdCliente.CurrentRow.Index].Cells[2].Value.ToString();
                mskCelular.Text = pesqcliente.grdCliente.Rows[pesqcliente.grdCliente.CurrentRow.Index].Cells[9].Value.ToString();

                txtAniversariante.Focus();
            }
        }

        private void frmPedidoVenda_Load(object sender, EventArgs e)
        {
            txtIdPedido.Text = "";
            txtIdCliente.Text = "";
            txtNomeCliente.Text = "";
            txtCpf.Text = "";
            mskCelular.Text = "";
            txtAniversariante.Text = "";
            mskDataNasc.Text = "";
            txtTema.Text = "";
            txtCorTema.Text = "";
            txtIdProduto.Text = "";
            txtNomeProduto.Text = "";
            txtValor.Text = "";
            txtQuantidade.Text = "";
            lblSubTotal.Text = "0";
            txtDesconto.Text = "";
            lblTotal.Text = "0";

            grdProdutoVenda.Rows.Clear();
            cont_linha = 0;
            total = 0;
            dtpDataPedido.Focus();
        }

        public static int cont_linha = 0;
        public static double total;

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExcluirPedido_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            txtIdPedido.Text = "";
            txtIdCliente.Text = "";
            txtNomeCliente.Text = "";
            txtCpf.Text = "";
            mskCelular.Text = "";
            txtAniversariante.Text = "";
            mskDataNasc.Text = "";
            txtTema.Text = "";
            txtCorTema.Text = "";
            txtIdProduto.Text = "";
            txtNomeProduto.Text = "";
            txtValor.Text = "";
            txtQuantidade.Text = "";
            lblSubTotal.Text = "";
            txtDesconto.Text = "";
            lblTotal.Text = "";

            grdProdutoVenda.Rows.Clear();
            cont_linha = 0;
            total = 0;
            dtpDataPedido.Focus();
        }


        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text == "" || txtCpf.Text == "" || mskCelular.Text == "")
            {
                MessageBox.Show("Não foi possível realizar este cadastro, por favor preencha os campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnPesqusiarCliente.Focus();
            }
            else
            {
                try
                {
                    string insert1 = "INSERT INTO PEDIDOS (DATA_PEDIDO, DATA_ENTREGA, ID_CLIENTE, ANIVERSARIANTE, DATA_NASC, TEMA, COR_TEMA)" +
                    "VALUES ('" + dtpDataPedido.Text + "', '" + dtpDataEntrega.Text + "', '" + txtIdCliente.Text +
                    "', '" + txtAniversariante.Text + "', '" + mskDataNasc.Text + "', '" + txtTema.Text + "', '" + txtCorTema.Text + "')";
                    MessageBox.Show("Pedido cadastrado com sucesso no sistema!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(insert1);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro no sistema, por favor consulte o suporte técnico!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string select = "";
                try
                {
                    string select1 = "SELECT ID_PEDIDO FROM PEDIDOS WHERE ID_PEDIDO = (SELECT MAX(ID_PEDIDO) FROM PEDIDOS)";
                    Utilidade.Executar(select1);
                    DataSet dataSelect = Utilidade.Executar(select1);
                    select = dataSelect.Tables[0].Rows[0][0].ToString();

                    for (int i = 0; i < grdProdutoVenda.Rows.Count; i++)
                    {
                        string pattern = ",";
                        string replacement = ".";

                        Regex regEx = new Regex(pattern);
                        string preco = regEx.Replace(grdProdutoVenda.Rows[i].Cells[2].Value.ToString(), replacement);

                        string insert2 = "INSERT INTO DETALHES (ID_PEDIDO, ID_PRODUTO, QUANTIDADE_VENDA)" +
                        "VALUES ('" + dataSelect.Tables[0].Rows[0][0].ToString() +
                        "', '" + grdProdutoVenda.Rows[i].Cells[0].Value.ToString() +
                        "', '" + grdProdutoVenda.Rows[i].Cells[3].Value.ToString() + "')";

                        Utilidade.Executar(insert2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro no sistema, por favor consulte o suporte técnico!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    string pattern1 = ",";
                    string replacement1 = ".";

                    Regex regEx1 = new Regex(pattern1);
                    string subtotal = regEx1.Replace(lblSubTotal.Text, replacement1);
                    string total = regEx1.Replace(lblTotal.Text, replacement1);


                    string update1 = "UPDATE PEDIDOS SET SUBTOTAL = '" + subtotal + "', DESCONTO = '" + txtDesconto.Text +
                        "', TOTAL = '" + total + "' WHERE ID_PEDIDO = " + select + "";
                    Utilidade.Executar(update1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível realizar este cadastro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            if (txtDesconto.TextLength > 0)
            {
                double desconto = 0;
                if (Double.TryParse(txtDesconto.Text, out desconto))
                {
                    desconto = Convert.ToDouble(lblSubTotal.Text) - ((Convert.ToDouble(lblSubTotal.Text) * Convert.ToDouble(txtDesconto.Text) / 100));
                    lblTotal.Text = desconto.ToString("F");
                }
                else
                {
                    MessageBox.Show("Por favor insira apenas números no campo desconto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesconto.Clear();
                    txtDesconto.Focus();
                }
            }
            else
            {
                lblTotal.Text = lblSubTotal.Text;
            }
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            if (e.KeyCode == Keys.Enter)
            {
                btnAdicionarProduto.PerformClick();
            }
        }

        private void mskDataNasc_Validating(object sender, CancelEventArgs e)
        {
            if (mskDataNasc.Text == "")
            {
                return;
            }

            if (!CommonFuncs.IsValidDate(sender))
            {
                e.Cancel = true;
            }
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFinalizarPedido.PerformClick();
            }
        }

        private void btnPesquisarProduto_Click_1(object sender, EventArgs e)
        {
            frmPesquisaProdutos pesqprodutos = new frmPesquisaProdutos();
            pesqprodutos.ShowDialog();

            if (pesqprodutos.DialogResult == DialogResult.OK)
            {
                txtIdProduto.Text = pesqprodutos.grdProduto.Rows[pesqprodutos.grdProduto.CurrentRow.Index].Cells[0].Value.ToString();
                txtNomeProduto.Text = pesqprodutos.grdProduto.Rows[pesqprodutos.grdProduto.CurrentRow.Index].Cells[1].Value.ToString();
                txtValor.Text = pesqprodutos.grdProduto.Rows[pesqprodutos.grdProduto.CurrentRow.Index].Cells[3].Value.ToString();

                txtQuantidade.Focus();

            }


        }

        private void btnAdicionarProduto_Click_1(object sender, EventArgs e)
        {
                            Boolean existe = false;
                int numero_linha = 0;

                if (cont_linha == 0)
                {
                    grdProdutoVenda.Rows.Add(txtIdProduto.Text, txtNomeProduto.Text, txtValor.Text, txtQuantidade.Text);
                    double valor = Double.Parse(grdProdutoVenda.Rows[cont_linha].Cells[2].Value.ToString()) * Double.Parse(grdProdutoVenda.Rows[cont_linha].Cells[3].Value.ToString());
                    grdProdutoVenda.Rows[cont_linha].Cells[4].Value = valor;
                    cont_linha++;
                    txtIdProduto.Clear();
                    txtNomeProduto.Clear();
                    txtValor.Clear();
                    txtQuantidade.Clear();
                }
                else
                {
                    foreach (DataGridViewRow linha in grdProdutoVenda.Rows)
                    {
                        if (linha.Cells[0].Value.ToString() == txtIdProduto.Text)
                        {
                            existe = true;
                            numero_linha = linha.Index;
                        }
                    }
                    if (existe == true)
                    {
                        grdProdutoVenda.Rows[numero_linha].Cells[3].Value = (Convert.ToDouble(txtQuantidade.Text) + Convert.ToDouble(grdProdutoVenda.Rows[numero_linha].Cells[3].Value.ToString()));
                        double valor = Convert.ToDouble(grdProdutoVenda.Rows[numero_linha].Cells[2].Value) * Convert.ToDouble(grdProdutoVenda.Rows[numero_linha].Cells[3].Value);
                        grdProdutoVenda.Rows[numero_linha].Cells[4].Value = valor;
                        txtIdProduto.Clear();
                        txtNomeProduto.Clear();
                        txtValor.Clear();
                        txtQuantidade.Clear();
                    }
                    else
                    {
                        grdProdutoVenda.Rows.Add(txtIdProduto.Text, txtNomeProduto.Text, txtValor.Text, txtQuantidade.Text);
                        double valor = Convert.ToDouble(grdProdutoVenda.Rows[cont_linha].Cells[2].Value) * Convert.ToDouble(grdProdutoVenda.Rows[cont_linha].Cells[3].Value);
                        grdProdutoVenda.Rows[cont_linha].Cells[4].Value = valor;
                        txtIdProduto.Clear();
                        txtNomeProduto.Clear();
                        txtValor.Clear();
                        txtQuantidade.Clear();

                        cont_linha++;
                    }
                }

                total = 0;
                foreach (DataGridViewRow linha in grdProdutoVenda.Rows)
                {
                    total += Convert.ToDouble(linha.Cells[4].Value);
                }
                lblSubTotal.Text = total.ToString("F");
            }

        private void btnExcluirPedido_Click_1(object sender, EventArgs e)
        {
            if (cont_linha > 0)
            {
                total = total - (Convert.ToDouble(grdProdutoVenda.Rows[grdProdutoVenda.CurrentRow.Index].Cells[4].Value));
                lblTotal.Text = total.ToString("F");
                lblSubTotal.Text = total.ToString("F");
                grdProdutoVenda.Rows.RemoveAt(grdProdutoVenda.CurrentRow.Index);
                cont_linha--;
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}



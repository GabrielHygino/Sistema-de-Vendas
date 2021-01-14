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
    public partial class frmCadastroClientes : Form
    {
        public frmCadastroClientes()
        {
            InitializeComponent();
        }

        public DataSet CarregarGrid(string tabela)
        {
            DataSet DS;
            string cmd = string.Format("SELECT ID_CLIENTE AS 'ID', NOME_CLIENTE AS 'NOME', CPF AS 'CPF', RUA AS 'RUA', NUMERO AS 'NUMERO', BAIRRO AS 'BAIRRO', CIDADE AS 'CIDADE', UF AS 'UF', CEP AS 'CEP', TELEFONE AS 'TELEFONE', CELULAR AS 'CELULAR', EMAIL AS 'E-MAIL', FACEBOOK AS 'FACEBOOK'    FROM " + tabela);
            DS = Utilidade.Executar(cmd);
            return DS;
        }

        private void btnInserirCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeCliente.Text.Trim() == "" || txtCpf.Text.Trim() == "" || txtRua.Text.Trim() == "" || txtNumero.Text.Trim() == "" || txtBairro.Text.Trim() == "" || 
                    txtCidade.Text.Trim() == "" || txtUf.Text.Trim() == "" || mskCep.Text.Trim() == "" || mskTelefone.Text.Trim() == "" || mskCelular.Text.Trim() == "")
                {
                    MessageBox.Show("Não foi possível realizar este cadastro, por favor preencha os campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    txtNomeCliente.Focus();
                }
                else
                {
                    string selectcpf = string.Format("SELECT CPF FROM CLIENTE WHERE CPF =" + txtCpf.Text);
                    DataSet ds = Utilidade.Executar(selectcpf);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("CPF já cadastrado, por favor verifique o CPF digitado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCpf.Focus();
                        txtCpf.Clear();
                    }
                    else
                    {
                        string cmd = string.Format("EXEC ATUALIZARCLIENTES '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}'",
                        txtIdCliente.Text.Trim(), txtNomeCliente.Text.Trim(), txtCpf.Text.Trim(), txtRua.Text.Trim(), txtNumero.Text.Trim(), txtBairro.Text.Trim(),
                        txtCidade.Text.Trim(), txtUf.Text.Trim(), mskCep.Text.Trim(), mskTelefone.Text.Trim(), mskCelular.Text.Trim(), txtEmail.Text.Trim(),
                        txtFacebook.Text.Trim());
                        MessageBox.Show("Cadastro inserido com sucesso no sistema!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Utilidade.Executar(cmd);
                        txtIdCliente.Clear();
                        txtNomeCliente.Clear();
                        txtCpf.Clear();
                        txtRua.Clear();
                        txtNumero.Clear();
                        txtBairro.Clear();
                        txtCidade.Clear();
                        txtUf.Clear();
                        mskCep.Clear();
                        mskTelefone.Clear();
                        mskCelular.Clear();
                        txtEmail.Clear();
                        txtFacebook.Clear();

                        txtNomeCliente.Focus();

                        grdCliente.DataSource = CarregarGrid("CLIENTE").Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar este cadastro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCadastroClientes_Load(object sender, EventArgs e)
        {
            grdCliente.DataSource = CarregarGrid("CLIENTE").Tables[0];
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            txtIdCliente.Clear();
            txtNomeCliente.Clear();
            txtCpf.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            mskCep.Clear();
            mskTelefone.Clear();
            mskCelular.Clear();
            txtEmail.Clear();
            txtFacebook.Clear();
            txtPesquisa.Clear();

            grdCliente.Refresh(); //testar

            txtNomeCliente.Focus();
        }

        private void grdCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCliente.Text = grdCliente.CurrentRow.Cells[0].Value.ToString();
            txtNomeCliente.Text = grdCliente.CurrentRow.Cells[1].Value.ToString();
            txtCpf.Text = grdCliente.CurrentRow.Cells[2].Value.ToString();
            txtRua.Text = grdCliente.CurrentRow.Cells[3].Value.ToString();
            txtNumero.Text = grdCliente.CurrentRow.Cells[4].Value.ToString();
            txtBairro.Text = grdCliente.CurrentRow.Cells[5].Value.ToString();
            txtCidade.Text = grdCliente.CurrentRow.Cells[6].Value.ToString();
            txtUf.Text = grdCliente.CurrentRow.Cells[7].Value.ToString();
            mskCep.Text = grdCliente.CurrentRow.Cells[8].Value.ToString();
            mskTelefone.Text = grdCliente.CurrentRow.Cells[9].Value.ToString();
            mskCelular.Text = grdCliente.CurrentRow.Cells[10].Value.ToString();
            txtEmail.Text = grdCliente.CurrentRow.Cells[11].Value.ToString();
            txtFacebook.Text = grdCliente.CurrentRow.Cells[12].Value.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeCliente.Text.Trim() == "" || txtCpf.Text.Trim() == "" || txtRua.Text.Trim() == "" || txtNumero.Text.Trim() == "" || txtBairro.Text.Trim() == "" ||
                    txtCidade.Text.Trim() == "" || txtUf.Text.Trim() == "" || mskCep.Text.Trim() == "" || mskTelefone.Text.Trim() == "" || mskCelular.Text.Trim() == "")
                {
                    MessageBox.Show("Não foi possível alterar este cadastro, por favor selecione um cadastro na tabela abaixo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtNomeCliente.Focus();
                }
                else
                {
                    string cmd = string.Format("EXEC ALTERARCLIENTES '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}'",
                    txtIdCliente.Text.Trim(), txtNomeCliente.Text.Trim(), txtCpf.Text.Trim(), txtRua.Text.Trim(), txtNumero.Text.Trim(), txtBairro.Text.Trim(),
                    txtCidade.Text.Trim(), txtUf.Text.Trim(), mskCep.Text.Trim(), mskTelefone.Text.Trim(), mskCelular.Text.Trim(), txtEmail.Text.Trim(),
                    txtFacebook.Text.Trim());
                    MessageBox.Show("Cadastro alterado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(cmd);
                    txtIdCliente.Clear();
                    txtNomeCliente.Clear();
                    txtCpf.Clear();
                    txtRua.Clear();
                    txtNumero.Clear();
                    txtBairro.Clear();
                    txtCidade.Clear();
                    txtUf.Clear();
                    mskCep.Clear();
                    mskTelefone.Clear();
                    mskCelular.Clear();
                    txtEmail.Clear();
                    txtFacebook.Clear();

                    txtNomeCliente.Focus();

                    grdCliente.DataSource = CarregarGrid("CLIENTE").Tables[0];
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível alterar este cadastro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCpf_Validating(object sender, CancelEventArgs e)
        {
            string NumeroCPF = txtCpf.Text;

            if (Validacao_cpf.verificar(NumeroCPF))
            {
                
            }
            else
            {
                MessageBox.Show("CPF inválido, por favor verifique o CPF digitado");
                txtCpf.Clear();
                txtCpf.Focus();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text.Trim() == "")
            {
                MessageBox.Show("Não foi possível excluir o cadastro do cliente, para excluir um cadastro por favor, selecione-o na tabela abaixo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdCliente.Clear();
                txtNomeCliente.Clear();
                txtCpf.Clear();
                txtRua.Clear();
                txtNumero.Clear();
                txtBairro.Clear();
                txtCidade.Clear();
                txtUf.Clear();
                mskCep.Clear();
                mskTelefone.Clear();
                mskCelular.Clear();
                txtEmail.Clear();
                txtFacebook.Clear();

                txtNomeCliente.Focus();
            }
            else
            {
                try
                {
                    //VERIFICAR ESTA STRING "EXEC DELETARCLIENTE, CONFIRMAR O NOME DO PROCEDIMENTO NO BANCO DE DADOS SE É DELETARCLIENTE OU DELETARCLIENTES
                    string cmd = string.Format("EXEC DELETARCLIENTE '{0}'", txtIdCliente.Text.Trim());
                    MessageBox.Show("Produto excluído com sucesso do sistema!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(cmd);
                    txtIdCliente.Clear();
                    txtNomeCliente.Clear();
                    txtCpf.Clear();
                    txtRua.Clear();
                    txtNumero.Clear();
                    txtBairro.Clear();
                    txtCidade.Clear();
                    txtUf.Clear();
                    mskCep.Clear();
                    mskTelefone.Clear();
                    mskCelular.Clear();
                    txtEmail.Clear();
                    txtFacebook.Clear();

                    txtNomeCliente.Focus();

                    grdCliente.DataSource = CarregarGrid("CLIENTE").Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível excluir o cadastro do cliente, para excluir um cadastro por favor, selecione-o na tabela abaixo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPesquisa_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                string cmd = "SELECT * FROM CLIENTE WHERE NOME_CLIENTE  LIKE('%" + txtPesquisa.Text.Trim() + "%')";
                ds = Utilidade.Executar(cmd);
                grdCliente.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não possível realizar a sua pesquisa, por favor tente novamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}

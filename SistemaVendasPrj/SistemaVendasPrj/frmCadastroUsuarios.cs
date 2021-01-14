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
    public partial class frmCadastroUsuarios : Form
    {
        public frmCadastroUsuarios()
        {
            InitializeComponent();
        }

        public DataSet CarregarGrid(string tabela)
        {
            DataSet DS;
            string cmd = string.Format("SELECT ID_USUARIO AS 'CÓDIGO', NOME_USUARIO AS 'NOME', USUARIO AS 'USUÁRIO' FROM USUARIO " + tabela);
            DS = Utilidade.Executar(cmd);
            return DS;
        }

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=BDLOJA;Integrated Security=True");
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (txtNomeUsuario.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || txtSenha.Text.Trim() == "")
                {
                    MessageBox.Show("Não foi possível realizar este cadastro, por favor preencha os campos em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string insert1 ="INSERT INTO USUARIO(ID_USUARIO, NOME_USUARIO, USUARIO, SENHA)" +
                        " VALUES ('" + txtIdUsuario.Text + "', '" + txtNomeUsuario.Text + "', '" + txtUsuario.Text + "', '" + txtSenha.Text + "')" +
                    
                    MessageBox.Show("Produto inserido com sucesso no sistema!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilidade.Executar(insert1);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error.Message);
            }*/

            try
            {
                string validarcampos;
                validarcampos = txtNomeUsuario.Text.Trim();
                if (validarcampos == "")
                {
                    MessageBox.Show("Por favor preencha os campos de Usuário e Senha!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNomeUsuario.Focus();
                }
                else
                {
                    SqlCommand cadastrousuario = new SqlCommand();
                    cadastrousuario.Connection = con;
                    cadastrousuario.CommandText = "INSERT INTO USUARIO(NOME_USUARIO, USUARIO, SENHA) VALUES(@NOME_USUARIO, @USUARIO, @SENHA)";
                    //cadastrousuario.Parameters.AddWithValue("@ID_USUARIO", txtIdUsuario.Text);
                    cadastrousuario.Parameters.AddWithValue("@NOME_USUARIO", txtNomeUsuario.Text);
                    cadastrousuario.Parameters.AddWithValue("@USUARIO", txtUsuario.Text);
                    cadastrousuario.Parameters.AddWithValue("@SENHA", txtSenha.Text);

                    con.Open();
                    cadastrousuario.ExecuteNonQuery();

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    con.Close();

                   
                    txtNomeUsuario.Clear();
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();

                    grdUsuarios.DataSource = CarregarGrid("USUARIO").Tables[0];
                }
            }
            catch(Exception error)
            {
                //MessageBox.Show("Não foi possível cadastrar este usuário, pode ser que este cadastro já exista!");
                MessageBox.Show("Error" + error.Message);
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void frmCadastroUsuarios_Load(object sender, EventArgs e)
        {
            grdUsuarios.DataSource = CarregarGrid("USUARIO").Tables[0];
        }

        private void grdUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdUsuario.Text = grdUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtNomeUsuario.Text = grdUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = grdUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtSenha.Text = "************";  
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                string validarcampos;
                validarcampos = txtNomeUsuario.Text.Trim();
                if (validarcampos == "")
                {
                    MessageBox.Show("Por favor preencha os campos de Usuário e Senha!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNomeUsuario.Focus();
                }
                else
                {
                    SqlCommand cadastrousuario = new SqlCommand();
                    cadastrousuario.Connection = con;
                    cadastrousuario.CommandText = "DELETE FROM USUARIO WHERE ID_USUARIO = @ID_USUARIO";
                    cadastrousuario.Parameters.AddWithValue("@ID_USUARIO", txtIdUsuario.Text);

                    con.Open();
                    cadastrousuario.ExecuteNonQuery();

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    con.Close();


                    txtNomeUsuario.Clear();
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();

                    grdUsuarios.DataSource = CarregarGrid("USUARIO").Tables[0];
                }
            }
            catch (Exception error)
            {
                //MessageBox.Show("Não foi possível cadastrar este usuário, pode ser que este cadastro já exista!");
                MessageBox.Show("Error" + error.Message);
            }
        }
    }
}

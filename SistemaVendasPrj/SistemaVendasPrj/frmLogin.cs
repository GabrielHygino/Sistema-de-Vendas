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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public static string Codigo = "";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("SELECT * FROM USUARIO WHERE USUARIO = '{0}' AND SENHA = '{1}'", txtUsuario.Text.Trim(), txtSenha.Text.Trim());
                DataSet ds = Utilidade.Executar(CMD);

                Codigo = ds.Tables[0].Rows[0]["ID_USUARIO"].ToString().Trim();

                string usuario = ds.Tables[0].Rows[0]["USUARIO"].ToString().Trim();
                string senha = ds.Tables[0].Rows[0]["SENHA"].ToString().Trim();

                if (usuario == txtUsuario.Text.Trim() && senha == txtSenha.Text.Trim())
                {
                    MessageBox.Show("Bem vindo(a) ao sistema de vendas Fadinha de Papel!", "Bem Vindo(a)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmMenuPrincipal principal = new frmMenuPrincipal();
                    principal.Show();
                    
                }
            }
            catch(Exception error)
            {
                
                MessageBox.Show("USUÁRIO e/ou SENHA inválidos, por favor tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o sistema?", "Saindo do Sistema!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}

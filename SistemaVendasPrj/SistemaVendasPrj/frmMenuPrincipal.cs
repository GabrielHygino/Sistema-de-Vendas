using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVendasPrj
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroUsuarios cadusuarios = new frmCadastroUsuarios();
            cadusuarios.MdiParent = this;
            cadusuarios.Show();
        }

        private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroClientes cadclientes = new frmCadastroClientes();
            cadclientes.MdiParent = this;
            cadclientes.Show();

        }

        private void cadastroDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProdutos cadprodutos = new frmCadastroProdutos();
            cadprodutos.MdiParent = this;
            cadprodutos.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidoVenda pedvenda = new frmPedidoVenda();
            pedvenda.MdiParent = this;
            pedvenda.Show();
        }

        private void últimaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioPedidoVenda relatorio = new frmRelatorioPedidoVenda();
            relatorio.MdiParent = this;
            relatorio.Show();
        }

        private void pesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPesquisaRelatorios pesqrel = new frmPesquisaRelatorios();
            pesqrel.MdiParent = this;
            pesqrel.Show();
        }

        private void informaçõesDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            sobre.MdiParent = this;
            sobre.Show();
        }
    }
}

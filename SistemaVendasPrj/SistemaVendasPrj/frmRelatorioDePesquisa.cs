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
    public partial class frmRelatorioDePesquisa : Form
    {
        public frmRelatorioDePesquisa()
        {
            InitializeComponent();
        }

        public frmRelatorioDePesquisa(string idpedido)
        {
            InitializeComponent();
            lblIdPedido.Text = idpedido;
        }

        private void frmRelatorioDePesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BDLOJADataSet1.DataTablePorNome' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'DataSetPorNome.DADOSVENDAS' table. You can move, or remove it, as needed.
            //this.DADOSVENDASTableAdapter.Fill(this.DataSetPorNome.DADOSVENDAS);
            this.DataTablePorNomeTableAdapter.Fill(this.BDLOJADataSet1.DataTablePorNome, ((int)(System.Convert.ChangeType(lblIdPedido.Text, typeof(int)))));
            
            this.reportViewer1.RefreshReport();
            
        }
    }
}

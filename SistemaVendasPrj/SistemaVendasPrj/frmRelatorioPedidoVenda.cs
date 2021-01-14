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
    public partial class frmRelatorioPedidoVenda : Form
    {
        public frmRelatorioPedidoVenda()
        {
            InitializeComponent();
        }

        private void frmRelatorioPedidoVenda_Load(object sender, EventArgs e)
        {
            string select1 = "SELECT MAX(ID_PEDIDO) FROM PEDIDOS";
            Utilidade.Executar(select1);
            string select = "";
            DataSet dataSelect = Utilidade.Executar(select1);
            select = dataSelect.Tables[0].Rows[0][0].ToString();
            this.DataTable1TableAdapter.FillBy1(this.BDLOJADataSet.DataTable1, ((int)(System.Convert.ChangeType(select, typeof(int)))));
            this.reportViewer1.RefreshReport();
        }
    }
}

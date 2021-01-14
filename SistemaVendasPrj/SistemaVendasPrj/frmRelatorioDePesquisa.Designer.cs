namespace SistemaVendasPrj
{
    partial class frmRelatorioDePesquisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioDePesquisa));
            this.DataTablePorNomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BDLOJADataSet1 = new SistemaVendasPrj.BDLOJADataSet1();
            this.lblIdPedido = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTablePorNomeTableAdapter = new SistemaVendasPrj.BDLOJADataSet1TableAdapters.DataTablePorNomeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTablePorNomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BDLOJADataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTablePorNomeBindingSource
            // 
            this.DataTablePorNomeBindingSource.DataMember = "DataTablePorNome";
            this.DataTablePorNomeBindingSource.DataSource = this.BDLOJADataSet1;
            // 
            // BDLOJADataSet1
            // 
            this.BDLOJADataSet1.DataSetName = "BDLOJADataSet1";
            this.BDLOJADataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblIdPedido
            // 
            this.lblIdPedido.AutoSize = true;
            this.lblIdPedido.Location = new System.Drawing.Point(634, 62);
            this.lblIdPedido.Name = "lblIdPedido";
            this.lblIdPedido.Size = new System.Drawing.Size(49, 13);
            this.lblIdPedido.TabIndex = 1;
            this.lblIdPedido.Text = "IdPedido";
            this.lblIdPedido.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTablePorNomeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaVendasPrj.ReportPorNome.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(850, 723);
            this.reportViewer1.TabIndex = 2;
            // 
            // DataTablePorNomeTableAdapter
            // 
            this.DataTablePorNomeTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioDePesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 723);
            this.Controls.Add(this.lblIdPedido);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelatorioDePesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Venda Por Pedido";
            this.Load += new System.EventHandler(this.frmRelatorioDePesquisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTablePorNomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BDLOJADataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdPedido;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTablePorNomeBindingSource;
        private BDLOJADataSet1 BDLOJADataSet1;
        private BDLOJADataSet1TableAdapters.DataTablePorNomeTableAdapter DataTablePorNomeTableAdapter;
    }
}
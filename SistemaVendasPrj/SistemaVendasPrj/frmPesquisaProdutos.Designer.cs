namespace SistemaVendasPrj
{
    partial class frmPesquisaProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaProdutos));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelecionarProduto = new System.Windows.Forms.Button();
            this.grdProduto = new System.Windows.Forms.DataGridView();
            this.btnPesqusiarProduto = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(610, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pesquisa de Produtos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Produto:";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(15, 68);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(607, 20);
            this.txtPesquisa.TabIndex = 5;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFechar.Location = new System.Drawing.Point(482, 94);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(140, 35);
            this.btnFechar.TabIndex = 37;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSelecionarProduto);
            this.panel2.Controls.Add(this.grdProduto);
            this.panel2.Location = new System.Drawing.Point(15, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 339);
            this.panel2.TabIndex = 38;
            // 
            // btnSelecionarProduto
            // 
            this.btnSelecionarProduto.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelecionarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarProduto.Image")));
            this.btnSelecionarProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionarProduto.Location = new System.Drawing.Point(450, 292);
            this.btnSelecionarProduto.Name = "btnSelecionarProduto";
            this.btnSelecionarProduto.Size = new System.Drawing.Size(140, 35);
            this.btnSelecionarProduto.TabIndex = 45;
            this.btnSelecionarProduto.Text = "Selecionar Produto";
            this.btnSelecionarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarProduto.UseVisualStyleBackColor = false;
            this.btnSelecionarProduto.Click += new System.EventHandler(this.btnSelecionarProduto_Click);
            // 
            // grdProduto
            // 
            this.grdProduto.AllowUserToAddRows = false;
            this.grdProduto.AllowUserToDeleteRows = false;
            this.grdProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdProduto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdProduto.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProduto.Location = new System.Drawing.Point(15, 15);
            this.grdProduto.Name = "grdProduto";
            this.grdProduto.ReadOnly = true;
            this.grdProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProduto.Size = new System.Drawing.Size(575, 271);
            this.grdProduto.TabIndex = 35;
            this.grdProduto.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProduto_CellContentDoubleClick);
            this.grdProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdProduto_KeyDown);
            // 
            // btnPesqusiarProduto
            // 
            this.btnPesqusiarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnPesqusiarProduto.Image")));
            this.btnPesqusiarProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesqusiarProduto.Location = new System.Drawing.Point(336, 94);
            this.btnPesqusiarProduto.Name = "btnPesqusiarProduto";
            this.btnPesqusiarProduto.Size = new System.Drawing.Size(140, 35);
            this.btnPesqusiarProduto.TabIndex = 39;
            this.btnPesqusiarProduto.Text = "Pesquisar Produto";
            this.btnPesqusiarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesqusiarProduto.UseVisualStyleBackColor = true;
            this.btnPesqusiarProduto.Click += new System.EventHandler(this.btnPesqusiarProduto_Click);
            // 
            // frmPesquisaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 487);
            this.Controls.Add(this.btnPesqusiarProduto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPesquisaProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Produtos";
            this.Load += new System.EventHandler(this.frmPesquisaProdutos_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView grdProduto;
        private System.Windows.Forms.Button btnPesqusiarProduto;
        private System.Windows.Forms.Button btnSelecionarProduto;
    }
}
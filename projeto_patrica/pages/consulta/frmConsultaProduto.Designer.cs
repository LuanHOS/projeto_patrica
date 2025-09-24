namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaProduto
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
            this.clmNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCodBarras = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMarca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEstoque = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNome,
            this.clmCodBarras,
            this.clmMarca,
            this.clmCategoria,
            this.clmValorVenda,
            this.clmEstoque,
            this.clmAtivo});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            this.listV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listV_MouseDoubleClick);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // clmNome
            // 
            this.clmNome.Text = "Produto";
            this.clmNome.Width = 250;
            // 
            // clmCodBarras
            // 
            this.clmCodBarras.Text = "Código de Barras";
            this.clmCodBarras.Width = 150;
            // 
            // clmMarca
            // 
            this.clmMarca.Text = "Marca";
            this.clmMarca.Width = 150;
            // 
            // clmCategoria
            // 
            this.clmCategoria.Text = "Categoria";
            this.clmCategoria.Width = 150;
            // 
            // clmValorVenda
            // 
            this.clmValorVenda.Text = "Valor de Venda";
            this.clmValorVenda.Width = 120;
            // 
            // clmEstoque
            // 
            this.clmEstoque.Text = "Estoque";
            this.clmEstoque.Width = 80;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Ativo";
            this.clmAtivo.Width = 100;
            // 
            // frmConsultaProduto
            // 
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultaProduto";
            this.Text = "Consulta de Produto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmNome;
        private System.Windows.Forms.ColumnHeader clmCodBarras;
        private System.Windows.Forms.ColumnHeader clmMarca;
        private System.Windows.Forms.ColumnHeader clmCategoria;
        private System.Windows.Forms.ColumnHeader clmValorVenda;
        private System.Windows.Forms.ColumnHeader clmEstoque;
        private System.Windows.Forms.ColumnHeader clmAtivo;
    }
}
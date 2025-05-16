namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaCondicaoPagamento
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
            this.clmDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmQtdParcelas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDescricao,
            this.clmQtdParcelas});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.ListV_SelectedIndexChanged);
            this.listV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmConsultaCondicaoPagamento_MouseDoubleClick);
            // 
            // clmCod
            // 
            this.clmCod.Width = 100;
            // 
            // clmDescricao
            // 
            this.clmDescricao.Text = "Descrição";
            this.clmDescricao.Width = 200;
            // 
            // clmQtdParcelas
            // 
            this.clmQtdParcelas.Text = "Qtd. de Parcelas";
            this.clmQtdParcelas.Width = 150;
            // 
            // frmConsultaCondicaoPagamento
            // 
            this.Name = "frmConsultaCondicaoPagamento";
            this.Text = "Consulta de Condição de Pagamento";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmConsultaCondicaoPagamento_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmDescricao;
        private System.Windows.Forms.ColumnHeader clmQtdParcelas;
    }
}

namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaFormaPagamento
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
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDescricao});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.ListV_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // clmDescricao
            // 
            this.clmDescricao.Text = "Descrição";
            this.clmDescricao.Width = 180;
            // 
            // frmConsultaFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(844, 476);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmConsultaFormaPagamento";
            this.Text = "Consulta Forma de Pagamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmDescricao;
    }
}

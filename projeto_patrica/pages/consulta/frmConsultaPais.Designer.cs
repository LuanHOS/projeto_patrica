namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaPais
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
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.TabIndex = 7;
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNome});
            this.listV.TabIndex = 4;
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmCod
            // 
            this.clmCod.Width = 103;
            // 
            // btnAlterar
            // 
            this.btnAlterar.TabIndex = 6;
            // 
            // btnIncluir
            // 
            this.btnIncluir.TabIndex = 5;
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 8;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // clmNome
            // 
            this.clmNome.Text = "País";
            this.clmNome.Width = 187;
            // 
            // frmConsultaPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultaPais";
            this.Text = "Consulta de País";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmNome;
    }
}

namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaCidade
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
            this.clmEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNome,
            this.clmEstado});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmCod
            // 
            this.clmCod.Width = 101;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // clmNome
            // 
            this.clmNome.Text = "Cidade";
            this.clmNome.Width = 195;
            // 
            // clmEstado
            // 
            this.clmEstado.Text = "Estado";
            this.clmEstado.Width = 190;
            // 
            // frmConsultaCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1789, 887);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmConsultaCidade";
            this.Text = "Consulta de Cidade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmNome;
        private System.Windows.Forms.ColumnHeader clmEstado;
    }
}

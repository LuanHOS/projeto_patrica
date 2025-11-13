namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaContasAReceber
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
            this.comboBoxFiltroStatus = new System.Windows.Forms.ComboBox();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(1125, 617);
            this.btnExcluir.Size = new System.Drawing.Size(99, 34);
            this.btnExcluir.Text = "Cancelar Conta";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(1039, 616);
            this.btnAlterar.Text = "Visualizar";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(952, 616);
            this.btnIncluir.Text = "Dar Baixa";
            // 
            // comboBoxFiltroStatus
            // 
            this.comboBoxFiltroStatus.FormattingEnabled = true;
            this.comboBoxFiltroStatus.Items.AddRange(new object[] {
            "Em Aberto",
            "Paga",
            "Vencida",
            "Cancelada",
            "Todas"});
            this.comboBoxFiltroStatus.Location = new System.Drawing.Point(1057, 46);
            this.comboBoxFiltroStatus.Name = "comboBoxFiltroStatus";
            this.comboBoxFiltroStatus.Size = new System.Drawing.Size(252, 24);
            this.comboBoxFiltroStatus.TabIndex = 13;
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(1054, 30);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(119, 16);
            this.lblFiltros.TabIndex = 12;
            this.lblFiltros.Text = "Filtros de Parcelas";
            // 
            // frmConsultaContasAReceber
            // 
            this.Controls.Add(this.comboBoxFiltroStatus);
            this.Controls.Add(this.lblFiltros);
            this.Name = "frmConsultaContasAReceber";
            this.Text = "Consulta de Contas a Receber";
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnIncluir, 0);
            this.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.Controls.SetChildIndex(this.bntLimparPesquisa, 0);
            this.Controls.SetChildIndex(this.listV, 0);
            this.Controls.SetChildIndex(this.lblFiltros, 0);
            this.Controls.SetChildIndex(this.comboBoxFiltroStatus, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFiltroStatus;
        private System.Windows.Forms.Label lblFiltros;
    }
}

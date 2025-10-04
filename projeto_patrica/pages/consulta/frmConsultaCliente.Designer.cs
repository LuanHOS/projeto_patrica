namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaCliente
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
            this.clmTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNomeRazaoSocial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCpfCnpj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmRgInscEstadual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTelefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGenero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCondicaoPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLimiteDeCredito = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNomeRazaoSocial,
            this.clmTipo,
            this.clmCondicaoPagamento,
            this.clmLimiteDeCredito,
            this.clmCpfCnpj,
            this.clmRgInscEstadual,
            this.clmGenero,
            this.clmCidade,
            this.clmEmail,
            this.clmTelefone,
            this.clmAtivo});
            this.listV.Location = new System.Drawing.Point(24, 86);
            this.listV.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            this.listV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listV_MouseDoubleClick);
            // 
            // clmCod
            // 
            this.clmCod.DisplayIndex = 0;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // clmTipo
            // 
            this.clmTipo.Text = "Tipo Pessoa";
            this.clmTipo.Width = 100;
            // 
            // clmNomeRazaoSocial
            // 
            this.clmNomeRazaoSocial.Text = "Nome/R. Social";
            this.clmNomeRazaoSocial.Width = 200;
            // 
            // clmCpfCnpj
            // 
            this.clmCpfCnpj.Text = "CPF/CNPJ";
            this.clmCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmCpfCnpj.Width = 100;
            // 
            // clmRgInscEstadual
            // 
            this.clmRgInscEstadual.Text = "RG/Insc. Est.";
            this.clmRgInscEstadual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmRgInscEstadual.Width = 100;
            // 
            // clmEmail
            // 
            this.clmEmail.Text = "E-mail";
            this.clmEmail.Width = 150;
            // 
            // clmTelefone
            // 
            this.clmTelefone.Text = "Telefone";
            this.clmTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmTelefone.Width = 100;
            // 
            // clmCidade
            // 
            this.clmCidade.Text = "Cidade";
            this.clmCidade.Width = 150;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Ativo";
            this.clmAtivo.Width = 100;
            // 
            // clmGenero
            // 
            this.clmGenero.Text = "Gênero";
            this.clmGenero.Width = 80;
            // 
            // clmCondicaoPagamento
            // 
            this.clmCondicaoPagamento.Text = "Condição de Pagamento";
            this.clmCondicaoPagamento.Width = 200;
            // 
            // clmLimiteDeCredito
            // 
            this.clmLimiteDeCredito.Text = "Limite de Crédito";
            this.clmLimiteDeCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmLimiteDeCredito.Width = 130;
            // 
            // frmConsultaCliente
            // 
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultaCliente";
            this.Text = "Consulta de Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmTipo;
        private System.Windows.Forms.ColumnHeader clmNomeRazaoSocial;
        private System.Windows.Forms.ColumnHeader clmCpfCnpj;
        private System.Windows.Forms.ColumnHeader clmRgInscEstadual;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.ColumnHeader clmTelefone;
        private System.Windows.Forms.ColumnHeader clmCidade;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.ColumnHeader clmGenero;
        private System.Windows.Forms.ColumnHeader clmCondicaoPagamento;
        private System.Windows.Forms.ColumnHeader clmLimiteDeCredito;
    }
}

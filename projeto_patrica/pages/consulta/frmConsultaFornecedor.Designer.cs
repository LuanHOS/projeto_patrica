namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaFornecedor
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
            this.clmGenero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCpfCnpj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmRgInscEstadual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTelefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmInscEstSubTrib = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCondicaoPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNomeRazaoSocial,
            this.clmTipo,
            this.clmCondicaoPagamento,
            this.clmCpfCnpj,
            this.clmRgInscEstadual,
            this.clmInscEstSubTrib,
            this.clmGenero,
            this.clmCidade,
            this.clmEmail,
            this.clmTelefone,
            this.clmAtivo});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmTipo
            // 
            this.clmTipo.DisplayIndex = 1;
            this.clmTipo.Text = "Tipo de Pessoa";
            // 
            // clmNomeRazaoSocial
            // 
            this.clmNomeRazaoSocial.DisplayIndex = 2;
            this.clmNomeRazaoSocial.Text = "Nome/Razão Social";
            this.clmNomeRazaoSocial.Width = 120;
            // 
            // clmGenero
            // 
            this.clmGenero.DisplayIndex = 3;
            this.clmGenero.Text = "Gênero";
            // 
            // clmCpfCnpj
            // 
            this.clmCpfCnpj.Text = "CPF/CNPJ";
            this.clmCpfCnpj.Width = 120;
            // 
            // clmRgInscEstadual
            // 
            this.clmRgInscEstadual.Text = "RG/Insc. Estadual";
            this.clmRgInscEstadual.Width = 120;
            // 
            // clmEmail
            // 
            this.clmEmail.DisplayIndex = 6;
            this.clmEmail.Text = "E-mail";
            this.clmEmail.Width = 120;
            // 
            // clmTelefone
            // 
            this.clmTelefone.DisplayIndex = 7;
            this.clmTelefone.Text = "Telefone";
            this.clmTelefone.Width = 120;
            // 
            // clmCidade
            // 
            this.clmCidade.Text = "Cidade";
            this.clmCidade.Width = 120;
            // 
            // clmAtivo
            // 
            this.clmAtivo.DisplayIndex = 9;
            this.clmAtivo.Text = "Ativo";
            // 
            // clmInscEstSubTrib
            // 
            this.clmInscEstSubTrib.DisplayIndex = 10;
            this.clmInscEstSubTrib.Text = "Insc. Est. Sub. Trib.";
            this.clmInscEstSubTrib.Width = 120;
            // 
            // clmCondicaoPagamento
            // 
            this.clmCondicaoPagamento.DisplayIndex = 11;
            this.clmCondicaoPagamento.Text = "Condição de Pagamento";
            this.clmCondicaoPagamento.Width = 120;
            // 
            // frmConsultaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 387);
            this.Name = "frmConsultaFornecedor";
            this.Text = "Consulta de Fornecedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmTipo;
        private System.Windows.Forms.ColumnHeader clmNomeRazaoSocial;
        private System.Windows.Forms.ColumnHeader clmGenero;
        private System.Windows.Forms.ColumnHeader clmCpfCnpj;
        private System.Windows.Forms.ColumnHeader clmRgInscEstadual;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.ColumnHeader clmTelefone;
        private System.Windows.Forms.ColumnHeader clmCidade;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.ColumnHeader clmInscEstSubTrib;
        private System.Windows.Forms.ColumnHeader clmCondicaoPagamento;
    }
}

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
            this.clmApelidoNomeFantasia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataNascimentoCriacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEndereco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBairo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGenero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTipo,
            this.clmNomeRazaoSocial,
            this.clmApelidoNomeFantasia,
            this.clmDataNascimentoCriacao,
            this.clmGenero,
            this.clmCpfCnpj,
            this.clmRgInscEstadual,
            this.clmEmail,
            this.clmTelefone,
            this.clmEndereco,
            this.clmBairo,
            this.clmCidade,
            this.clmCep,
            this.clmAtivo});
            this.listV.Location = new System.Drawing.Point(24, 86);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmCod
            // 
            this.clmCod.Width = 120;
            // 
            // clmTipo
            // 
            this.clmTipo.Text = "Tipo Pessoa";
            this.clmTipo.Width = 120;
            // 
            // clmNomeRazaoSocial
            // 
            this.clmNomeRazaoSocial.Text = "Nome/R. Social";
            this.clmNomeRazaoSocial.Width = 120;
            // 
            // clmCpfCnpj
            // 
            this.clmCpfCnpj.DisplayIndex = 5;
            this.clmCpfCnpj.Text = "CPF/CNPJ";
            this.clmCpfCnpj.Width = 120;
            // 
            // clmRgInscEstadual
            // 
            this.clmRgInscEstadual.DisplayIndex = 6;
            this.clmRgInscEstadual.Text = "RG/Insc. Estadual";
            this.clmRgInscEstadual.Width = 120;
            // 
            // clmEmail
            // 
            this.clmEmail.DisplayIndex = 7;
            this.clmEmail.Text = "E-mail";
            this.clmEmail.Width = 120;
            // 
            // clmTelefone
            // 
            this.clmTelefone.DisplayIndex = 8;
            this.clmTelefone.Text = "Telefone";
            this.clmTelefone.Width = 120;
            // 
            // clmCidade
            // 
            this.clmCidade.DisplayIndex = 11;
            this.clmCidade.Text = "Cidade";
            this.clmCidade.Width = 120;
            // 
            // clmApelidoNomeFantasia
            // 
            this.clmApelidoNomeFantasia.Text = "Apelido/Nome Fantasia";
            this.clmApelidoNomeFantasia.Width = 120;
            // 
            // clmDataNascimentoCriacao
            // 
            this.clmDataNascimentoCriacao.Text = "Data Nasc./Criação";
            this.clmDataNascimentoCriacao.Width = 120;
            // 
            // clmEndereco
            // 
            this.clmEndereco.DisplayIndex = 9;
            this.clmEndereco.Text = "Endereço";
            this.clmEndereco.Width = 120;
            // 
            // clmBairo
            // 
            this.clmBairo.DisplayIndex = 10;
            this.clmBairo.Text = "Bairro";
            this.clmBairo.Width = 120;
            // 
            // clmCep
            // 
            this.clmCep.DisplayIndex = 12;
            this.clmCep.Text = "CEP";
            this.clmCep.Width = 120;
            // 
            // clmAtivo
            // 
            this.clmAtivo.DisplayIndex = 13;
            this.clmAtivo.Text = "Ativo";
            // 
            // clmGenero
            // 
            this.clmGenero.DisplayIndex = 14;
            this.clmGenero.Text = "Gênero";
            // 
            // frmConsultaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(844, 476);
            this.Name = "frmConsultaCliente";
            this.Text = "Consulta de Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmTipo;
        private System.Windows.Forms.ColumnHeader clmNomeRazaoSocial;
        private System.Windows.Forms.ColumnHeader clmApelidoNomeFantasia;
        private System.Windows.Forms.ColumnHeader clmDataNascimentoCriacao;
        private System.Windows.Forms.ColumnHeader clmCpfCnpj;
        private System.Windows.Forms.ColumnHeader clmRgInscEstadual;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.ColumnHeader clmTelefone;
        private System.Windows.Forms.ColumnHeader clmEndereco;
        private System.Windows.Forms.ColumnHeader clmBairo;
        private System.Windows.Forms.ColumnHeader clmCidade;
        private System.Windows.Forms.ColumnHeader clmCep;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.ColumnHeader clmGenero;
    }
}

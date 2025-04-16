namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroCliente
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
            this.btnPesquisarCondicaoPagamento = new System.Windows.Forms.Button();
            this.txtCondicaoPagamento = new System.Windows.Forms.TextBox();
            this.lblCondicaoPagamento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRgInscEstadual
            // 
            this.txtRgInscEstadual.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtCidade
            // 
            this.txtCidade.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtBairro
            // 
            this.txtBairro.Margin = new System.Windows.Forms.Padding(4);
            // 
            // lblBairro
            // 
            this.lblBairro.Location = new System.Drawing.Point(23, 199);
            // 
            // txtEmail
            // 
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(27, 218);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4);
            this.txtCep.Size = new System.Drawing.Size(198, 22);
            // 
            // dtpDataNascimentoCriacao
            // 
            this.dtpDataNascimentoCriacao.Size = new System.Drawing.Size(135, 22);
            // 
            // txtApelidoNomeFantasia
            // 
            this.txtApelidoNomeFantasia.Margin = new System.Windows.Forms.Padding(4);
            // 
            // lblComplementoEndereco
            // 
            this.lblComplementoEndereco.Location = new System.Drawing.Point(459, 199);
            // 
            // txtComplementoEndereco
            // 
            this.txtComplementoEndereco.Location = new System.Drawing.Point(463, 218);
            this.txtComplementoEndereco.Size = new System.Drawing.Size(295, 22);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(627, 485);
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.Location = new System.Drawing.Point(21, 472);
            // 
            // lblDataUltimaEdicao
            // 
            this.lblDataUltimaEdicao.Location = new System.Drawing.Point(21, 488);
            // 
            // lblUltimoUsuarioQueEditou
            // 
            this.lblUltimoUsuarioQueEditou.Location = new System.Drawing.Point(21, 504);
            // 
            // lblDataCadastroData
            // 
            this.lblDataCadastroData.Location = new System.Drawing.Point(142, 472);
            // 
            // lblDataUltimaEdicaoData
            // 
            this.lblDataUltimaEdicaoData.Location = new System.Drawing.Point(171, 488);
            // 
            // lblUltimoUsuarioQueEditouNome
            // 
            this.lblUltimoUsuarioQueEditouNome.Location = new System.Drawing.Point(191, 504);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(720, 485);
            // 
            // btnPesquisarCondicaoPagamento
            // 
            this.btnPesquisarCondicaoPagamento.Location = new System.Drawing.Point(204, 395);
            this.btnPesquisarCondicaoPagamento.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarCondicaoPagamento.Name = "btnPesquisarCondicaoPagamento";
            this.btnPesquisarCondicaoPagamento.Size = new System.Drawing.Size(100, 25);
            this.btnPesquisarCondicaoPagamento.TabIndex = 38;
            this.btnPesquisarCondicaoPagamento.Text = "Pesquisar";
            this.btnPesquisarCondicaoPagamento.UseVisualStyleBackColor = true;
            this.btnPesquisarCondicaoPagamento.Click += new System.EventHandler(this.BtnPesquisarCondicaoPagamento_Click);
            // 
            // txtCondicaoPagamento
            // 
            this.txtCondicaoPagamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCondicaoPagamento.Location = new System.Drawing.Point(24, 396);
            this.txtCondicaoPagamento.Margin = new System.Windows.Forms.Padding(4);
            this.txtCondicaoPagamento.Name = "txtCondicaoPagamento";
            this.txtCondicaoPagamento.ReadOnly = true;
            this.txtCondicaoPagamento.Size = new System.Drawing.Size(171, 22);
            this.txtCondicaoPagamento.TabIndex = 37;
            // 
            // lblCondicaoPagamento
            // 
            this.lblCondicaoPagamento.AutoSize = true;
            this.lblCondicaoPagamento.Location = new System.Drawing.Point(24, 375);
            this.lblCondicaoPagamento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondicaoPagamento.Name = "lblCondicaoPagamento";
            this.lblCondicaoPagamento.Size = new System.Drawing.Size(165, 16);
            this.lblCondicaoPagamento.TabIndex = 36;
            this.lblCondicaoPagamento.Text = "Condição de Pagamento *";
            // 
            // frmCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(844, 557);
            this.Controls.Add(this.btnPesquisarCondicaoPagamento);
            this.Controls.Add(this.txtCondicaoPagamento);
            this.Controls.Add(this.lblCondicaoPagamento);
            this.Name = "frmCadastroCliente";
            this.Text = "Cadastro de Cliente";
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.lblDataCadastro, 0);
            this.Controls.SetChildIndex(this.lblDataCadastroData, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicao, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicaoData, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditou, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditouNome, 0);
            this.Controls.SetChildIndex(this.txtNumeroEndereco, 0);
            this.Controls.SetChildIndex(this.lblNumeroEndereco, 0);
            this.Controls.SetChildIndex(this.txtComplementoEndereco, 0);
            this.Controls.SetChildIndex(this.lblComplementoEndereco, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtApelidoNomeFantasia, 0);
            this.Controls.SetChildIndex(this.txtNomeRazaoSocial, 0);
            this.Controls.SetChildIndex(this.lblApelido, 0);
            this.Controls.SetChildIndex(this.lblGenero, 0);
            this.Controls.SetChildIndex(this.lblRg, 0);
            this.Controls.SetChildIndex(this.lblDataNascimento, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.lblTipo, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.lblBairro, 0);
            this.Controls.SetChildIndex(this.txtBairro, 0);
            this.Controls.SetChildIndex(this.lblCidade, 0);
            this.Controls.SetChildIndex(this.txtCidade, 0);
            this.Controls.SetChildIndex(this.lblCep, 0);
            this.Controls.SetChildIndex(this.txtCep, 0);
            this.Controls.SetChildIndex(this.lblCpf, 0);
            this.Controls.SetChildIndex(this.txtCpfCnpj, 0);
            this.Controls.SetChildIndex(this.txtRgInscEstadual, 0);
            this.Controls.SetChildIndex(this.lblTelefone, 0);
            this.Controls.SetChildIndex(this.txtTelefone, 0);
            this.Controls.SetChildIndex(this.lblEndereco, 0);
            this.Controls.SetChildIndex(this.txtEndereco, 0);
            this.Controls.SetChildIndex(this.checkBoxAtivo, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.dtpDataNascimentoCriacao, 0);
            this.Controls.SetChildIndex(this.comboBoxTipo, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCidade, 0);
            this.Controls.SetChildIndex(this.comboBoxGenero, 0);
            this.Controls.SetChildIndex(this.lblCondicaoPagamento, 0);
            this.Controls.SetChildIndex(this.txtCondicaoPagamento, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCondicaoPagamento, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisarCondicaoPagamento;
        private System.Windows.Forms.TextBox txtCondicaoPagamento;
        private System.Windows.Forms.Label lblCondicaoPagamento;
    }
}

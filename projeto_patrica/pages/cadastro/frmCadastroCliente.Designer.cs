﻿namespace projeto_patrica.pages.cadastro
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
            this.lblLimiteDeCredito = new System.Windows.Forms.Label();
            this.txtLimiteDeCredito = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtRgInscEstadual
            // 
            this.txtRgInscEstadual.MaxLength = 10;
            this.txtRgInscEstadual.ShortcutsEnabled = false;
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.MaxLength = 40;
            this.txtNomeRazaoSocial.ShortcutsEnabled = false;
            // 
            // txtCidade
            // 
            this.txtCidade.ShortcutsEnabled = false;
            // 
            // txtBairro
            // 
            this.txtBairro.MaxLength = 40;
            this.txtBairro.ShortcutsEnabled = false;
            // 
            // txtEmail
            // 
            this.txtEmail.MaxLength = 40;
            this.txtEmail.ShortcutsEnabled = false;
            // 
            // txtEndereco
            // 
            this.txtEndereco.MaxLength = 40;
            this.txtEndereco.ShortcutsEnabled = false;
            // 
            // txtTelefone
            // 
            this.txtTelefone.MaxLength = 20;
            this.txtTelefone.ShortcutsEnabled = false;
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.MaxLength = 14;
            this.txtCpfCnpj.ShortcutsEnabled = false;
            // 
            // txtCep
            // 
            this.txtCep.MaxLength = 8;
            this.txtCep.ShortcutsEnabled = false;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTipo_SelectedIndexChanged);
            // 
            // btnPesquisarCidade
            // 
            this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
            // 
            // txtApelidoNomeFantasia
            // 
            this.txtApelidoNomeFantasia.MaxLength = 40;
            this.txtApelidoNomeFantasia.ShortcutsEnabled = false;
            // 
            // lblNome
            // 
            this.lblNome.Size = new System.Drawing.Size(77, 13);
            this.lblNome.Text = "Cliente Nome *";
            // 
            // txtNumeroEndereco
            // 
            this.txtNumeroEndereco.MaxLength = 20;
            this.txtNumeroEndereco.ShortcutsEnabled = false;
            // 
            // txtComplementoEndereco
            // 
            this.txtComplementoEndereco.MaxLength = 40;
            this.txtComplementoEndereco.ShortcutsEnabled = false;
            // 
            // txtEstado
            // 
            this.txtEstado.ShortcutsEnabled = false;
            // 
            // txtPais
            // 
            this.txtPais.ShortcutsEnabled = false;
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 23;
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.TabIndex = 99;
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 24;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.ShortcutsEnabled = false;
            // 
            // btnPesquisarCondicaoPagamento
            // 
            this.btnPesquisarCondicaoPagamento.Location = new System.Drawing.Point(265, 390);
            this.btnPesquisarCondicaoPagamento.Name = "btnPesquisarCondicaoPagamento";
            this.btnPesquisarCondicaoPagamento.Size = new System.Drawing.Size(95, 26);
            this.btnPesquisarCondicaoPagamento.TabIndex = 21;
            this.btnPesquisarCondicaoPagamento.Text = "Pesquisar";
            this.btnPesquisarCondicaoPagamento.UseVisualStyleBackColor = true;
            this.btnPesquisarCondicaoPagamento.Click += new System.EventHandler(this.BtnPesquisarCondicaoPagamento_Click);
            // 
            // txtCondicaoPagamento
            // 
            this.txtCondicaoPagamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCondicaoPagamento.Location = new System.Drawing.Point(24, 393);
            this.txtCondicaoPagamento.Name = "txtCondicaoPagamento";
            this.txtCondicaoPagamento.ReadOnly = true;
            this.txtCondicaoPagamento.ShortcutsEnabled = false;
            this.txtCondicaoPagamento.Size = new System.Drawing.Size(235, 20);
            this.txtCondicaoPagamento.TabIndex = 20;
            // 
            // lblCondicaoPagamento
            // 
            this.lblCondicaoPagamento.AutoSize = true;
            this.lblCondicaoPagamento.Location = new System.Drawing.Point(21, 375);
            this.lblCondicaoPagamento.Name = "lblCondicaoPagamento";
            this.lblCondicaoPagamento.Size = new System.Drawing.Size(131, 13);
            this.lblCondicaoPagamento.TabIndex = 36;
            this.lblCondicaoPagamento.Text = "Condição de Pagamento *";
            // 
            // lblLimiteDeCredito
            // 
            this.lblLimiteDeCredito.AutoSize = true;
            this.lblLimiteDeCredito.Location = new System.Drawing.Point(380, 375);
            this.lblLimiteDeCredito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLimiteDeCredito.Name = "lblLimiteDeCredito";
            this.lblLimiteDeCredito.Size = new System.Drawing.Size(108, 13);
            this.lblLimiteDeCredito.TabIndex = 39;
            this.lblLimiteDeCredito.Text = "Limite de Crédito (R$)";
            // 
            // txtLimiteDeCredito
            // 
            this.txtLimiteDeCredito.Location = new System.Drawing.Point(383, 394);
            this.txtLimiteDeCredito.Margin = new System.Windows.Forms.Padding(2);
            this.txtLimiteDeCredito.Name = "txtLimiteDeCredito";
            this.txtLimiteDeCredito.ShortcutsEnabled = false;
            this.txtLimiteDeCredito.Size = new System.Drawing.Size(183, 20);
            this.txtLimiteDeCredito.TabIndex = 22;
            // 
            // frmCadastroCliente
            // 
            this.Controls.Add(this.txtLimiteDeCredito);
            this.Controls.Add(this.lblLimiteDeCredito);
            this.Controls.Add(this.btnPesquisarCondicaoPagamento);
            this.Controls.Add(this.txtCondicaoPagamento);
            this.Controls.Add(this.lblCondicaoPagamento);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCadastroCliente";
            this.Text = "Cadastro de Cliente";
            this.Controls.SetChildIndex(this.lblPais, 0);
            this.Controls.SetChildIndex(this.txtPais, 0);
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
            this.Controls.SetChildIndex(this.lblLimiteDeCredito, 0);
            this.Controls.SetChildIndex(this.txtLimiteDeCredito, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisarCondicaoPagamento;
        private System.Windows.Forms.TextBox txtCondicaoPagamento;
        private System.Windows.Forms.Label lblCondicaoPagamento;
        private System.Windows.Forms.Label lblLimiteDeCredito;
        private System.Windows.Forms.TextBox txtLimiteDeCredito;
    }
}

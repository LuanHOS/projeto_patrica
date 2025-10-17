namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroPessoa
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
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.lblRg = new System.Windows.Forms.Label();
            this.lblApelido = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtCpfCnpj = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblCep = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.dtpDataNascimentoCriacao = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.btnPesquisarCidade = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtApelidoNomeFantasia = new System.Windows.Forms.TextBox();
            this.txtRgInscEstadual = new System.Windows.Forms.TextBox();
            this.txtNomeRazaoSocial = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.comboBoxGenero = new System.Windows.Forms.ComboBox();
            this.lblNumeroEndereco = new System.Windows.Forms.Label();
            this.txtNumeroEndereco = new System.Windows.Forms.TextBox();
            this.lblComplementoEndereco = new System.Windows.Forms.Label();
            this.txtComplementoEndereco = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 20;
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(21, 78);
            this.lblCod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 21;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(24, 96);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.TabIndex = 2;
            // 
            // txtCidade
            // 
            this.txtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCidade.Location = new System.Drawing.Point(24, 161);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(235, 22);
            this.txtCidade.TabIndex = 6;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(21, 142);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(59, 16);
            this.lblCidade.TabIndex = 5;
            this.lblCidade.Text = "Cidade *";
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Location = new System.Drawing.Point(24, 218);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(336, 22);
            this.txtBairro.TabIndex = 12;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(21, 199);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(51, 16);
            this.lblBairro.TabIndex = 6;
            this.lblBairro.Text = "Bairro *";
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmail.Location = new System.Drawing.Point(383, 332);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(332, 22);
            this.txtEmail.TabIndex = 19;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(380, 313);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 16);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "E-mail *";
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Location = new System.Drawing.Point(734, 252);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(138, 16);
            this.lblDataNascimento.TabIndex = 8;
            this.lblDataNascimento.Text = "Data de Nascimento *";
            // 
            // lblRg
            // 
            this.lblRg.AutoSize = true;
            this.lblRg.Location = new System.Drawing.Point(380, 256);
            this.lblRg.Name = "lblRg";
            this.lblRg.Size = new System.Drawing.Size(35, 16);
            this.lblRg.TabIndex = 9;
            this.lblRg.Text = "RG *";
            // 
            // lblApelido
            // 
            this.lblApelido.AutoSize = true;
            this.lblApelido.Location = new System.Drawing.Point(512, 79);
            this.lblApelido.Name = "lblApelido";
            this.lblApelido.Size = new System.Drawing.Size(54, 16);
            this.lblApelido.TabIndex = 10;
            this.lblApelido.Text = "Apelido";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(161, 78);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(52, 16);
            this.lblNome.TabIndex = 11;
            this.lblNome.Text = "Nome *";
            // 
            // txtEndereco
            // 
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Location = new System.Drawing.Point(902, 161);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(292, 22);
            this.txtEndereco.TabIndex = 10;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(898, 142);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(74, 16);
            this.lblEndereco.TabIndex = 19;
            this.lblEndereco.Text = "Endereço *";
            // 
            // txtTelefone
            // 
            this.txtTelefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefone.Location = new System.Drawing.Point(24, 332);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(336, 22);
            this.txtTelefone.TabIndex = 18;
            this.txtTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(21, 313);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(69, 16);
            this.lblTelefone.TabIndex = 20;
            this.lblTelefone.Text = "Telefone *";
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCpfCnpj.Location = new System.Drawing.Point(24, 274);
            this.txtCpfCnpj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(336, 22);
            this.txtCpfCnpj.TabIndex = 15;
            this.txtCpfCnpj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(21, 256);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(41, 16);
            this.lblCpf.TabIndex = 21;
            this.lblCpf.Text = "CPF *";
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(386, 199);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(42, 16);
            this.lblCep.TabIndex = 5;
            this.lblCep.Text = "CEP *";
            // 
            // txtCep
            // 
            this.txtCep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCep.Location = new System.Drawing.Point(383, 218);
            this.txtCep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(332, 22);
            this.txtCep.TabIndex = 13;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpDataNascimentoCriacao
            // 
            this.dtpDataNascimentoCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimentoCriacao.Location = new System.Drawing.Point(737, 272);
            this.dtpDataNascimentoCriacao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDataNascimentoCriacao.Name = "dtpDataNascimentoCriacao";
            this.dtpDataNascimentoCriacao.Size = new System.Drawing.Size(135, 22);
            this.dtpDataNascimentoCriacao.TabIndex = 17;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "PESSOA FÍSICA",
            "PESSOA JURÍDICA"});
            this.comboBoxTipo.Location = new System.Drawing.Point(24, 36);
            this.comboBoxTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(185, 24);
            this.comboBoxTipo.TabIndex = 1;
            // 
            // btnPesquisarCidade
            // 
            this.btnPesquisarCidade.Location = new System.Drawing.Point(265, 158);
            this.btnPesquisarCidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarCidade.Name = "btnPesquisarCidade";
            this.btnPesquisarCidade.Size = new System.Drawing.Size(96, 28);
            this.btnPesquisarCidade.TabIndex = 7;
            this.btnPesquisarCidade.Text = "Pesquisar";
            this.btnPesquisarCidade.UseVisualStyleBackColor = true;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(21, 16);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(116, 16);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo de Registro *";
            // 
            // txtApelidoNomeFantasia
            // 
            this.txtApelidoNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApelidoNomeFantasia.Location = new System.Drawing.Point(516, 96);
            this.txtApelidoNomeFantasia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApelidoNomeFantasia.Name = "txtApelidoNomeFantasia";
            this.txtApelidoNomeFantasia.Size = new System.Drawing.Size(332, 22);
            this.txtApelidoNomeFantasia.TabIndex = 4;
            // 
            // txtRgInscEstadual
            // 
            this.txtRgInscEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRgInscEstadual.Location = new System.Drawing.Point(383, 274);
            this.txtRgInscEstadual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRgInscEstadual.Name = "txtRgInscEstadual";
            this.txtRgInscEstadual.Size = new System.Drawing.Size(332, 22);
            this.txtRgInscEstadual.TabIndex = 16;
            this.txtRgInscEstadual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNomeRazaoSocial
            // 
            this.txtNomeRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeRazaoSocial.Location = new System.Drawing.Point(165, 96);
            this.txtNomeRazaoSocial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeRazaoSocial.Name = "txtNomeRazaoSocial";
            this.txtNomeRazaoSocial.Size = new System.Drawing.Size(332, 22);
            this.txtNomeRazaoSocial.TabIndex = 3;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(867, 76);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(60, 16);
            this.lblGenero.TabIndex = 10;
            this.lblGenero.Text = "Gênero *";
            // 
            // comboBoxGenero
            // 
            this.comboBoxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGenero.FormattingEnabled = true;
            this.comboBoxGenero.Items.AddRange(new object[] {
            "MASCULINO",
            "FEMININO"});
            this.comboBoxGenero.Location = new System.Drawing.Point(869, 94);
            this.comboBoxGenero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGenero.Name = "comboBoxGenero";
            this.comboBoxGenero.Size = new System.Drawing.Size(161, 24);
            this.comboBoxGenero.TabIndex = 5;
            // 
            // lblNumeroEndereco
            // 
            this.lblNumeroEndereco.AutoSize = true;
            this.lblNumeroEndereco.Location = new System.Drawing.Point(1209, 142);
            this.lblNumeroEndereco.Name = "lblNumeroEndereco";
            this.lblNumeroEndereco.Size = new System.Drawing.Size(63, 16);
            this.lblNumeroEndereco.TabIndex = 31;
            this.lblNumeroEndereco.Text = "Número *";
            // 
            // txtNumeroEndereco
            // 
            this.txtNumeroEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroEndereco.Location = new System.Drawing.Point(1211, 161);
            this.txtNumeroEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumeroEndereco.Name = "txtNumeroEndereco";
            this.txtNumeroEndereco.Size = new System.Drawing.Size(82, 22);
            this.txtNumeroEndereco.TabIndex = 11;
            this.txtNumeroEndereco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblComplementoEndereco
            // 
            this.lblComplementoEndereco.AutoSize = true;
            this.lblComplementoEndereco.Location = new System.Drawing.Point(734, 198);
            this.lblComplementoEndereco.Name = "lblComplementoEndereco";
            this.lblComplementoEndereco.Size = new System.Drawing.Size(91, 16);
            this.lblComplementoEndereco.TabIndex = 33;
            this.lblComplementoEndereco.Text = "Complemento";
            // 
            // txtComplementoEndereco
            // 
            this.txtComplementoEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComplementoEndereco.Location = new System.Drawing.Point(738, 217);
            this.txtComplementoEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtComplementoEndereco.Name = "txtComplementoEndereco";
            this.txtComplementoEndereco.Size = new System.Drawing.Size(555, 22);
            this.txtComplementoEndereco.TabIndex = 14;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(380, 142);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(58, 16);
            this.lblEstado.TabIndex = 34;
            this.lblEstado.Text = "Estado *";
            // 
            // txtEstado
            // 
            this.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstado.Location = new System.Drawing.Point(383, 161);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(235, 22);
            this.txtEstado.TabIndex = 8;
            // 
            // txtPais
            // 
            this.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPais.Location = new System.Drawing.Point(637, 161);
            this.txtPais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPais.Name = "txtPais";
            this.txtPais.ReadOnly = true;
            this.txtPais.Size = new System.Drawing.Size(243, 22);
            this.txtPais.TabIndex = 9;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(634, 142);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(42, 16);
            this.lblPais.TabIndex = 102;
            this.lblPais.Text = "País *";
            // 
            // frmCadastroPessoa
            // 
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblComplementoEndereco);
            this.Controls.Add(this.txtComplementoEndereco);
            this.Controls.Add(this.lblNumeroEndereco);
            this.Controls.Add(this.txtNumeroEndereco);
            this.Controls.Add(this.comboBoxGenero);
            this.Controls.Add(this.btnPesquisarCidade);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.dtpDataNascimentoCriacao);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.txtRgInscEstadual);
            this.Controls.Add(this.txtCpfCnpj);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.lblCep);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDataNascimento);
            this.Controls.Add(this.lblRg);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblApelido);
            this.Controls.Add(this.txtNomeRazaoSocial);
            this.Controls.Add(this.txtApelidoNomeFantasia);
            this.Controls.Add(this.lblNome);
            this.Name = "frmCadastroPessoa";
            this.Text = "Cadastro de Pessoa";
            this.Controls.SetChildIndex(this.checkBoxAtivo, 0);
            this.Controls.SetChildIndex(this.lblDataCadastro, 0);
            this.Controls.SetChildIndex(this.lblDataCadastroData, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicao, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicaoData, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditou, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditouNome, 0);
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
            this.Controls.SetChildIndex(this.dtpDataNascimentoCriacao, 0);
            this.Controls.SetChildIndex(this.comboBoxTipo, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCidade, 0);
            this.Controls.SetChildIndex(this.comboBoxGenero, 0);
            this.Controls.SetChildIndex(this.txtNumeroEndereco, 0);
            this.Controls.SetChildIndex(this.lblNumeroEndereco, 0);
            this.Controls.SetChildIndex(this.txtComplementoEndereco, 0);
            this.Controls.SetChildIndex(this.lblComplementoEndereco, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.lblPais, 0);
            this.Controls.SetChildIndex(this.txtPais, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.TextBox txtRgInscEstadual;
        protected System.Windows.Forms.TextBox txtNomeRazaoSocial;
        protected System.Windows.Forms.TextBox txtCidade;
        protected System.Windows.Forms.Label lblCidade;
        protected System.Windows.Forms.TextBox txtBairro;
        protected System.Windows.Forms.Label lblBairro;
        protected System.Windows.Forms.TextBox txtEmail;
        protected System.Windows.Forms.Label lblEmail;
        protected System.Windows.Forms.Label lblDataNascimento;
        protected System.Windows.Forms.Label lblRg;
        protected System.Windows.Forms.Label lblApelido;
        protected System.Windows.Forms.TextBox txtEndereco;
        protected System.Windows.Forms.TextBox txtTelefone;
        protected System.Windows.Forms.TextBox txtCpfCnpj;
        protected System.Windows.Forms.Label lblCep;
        protected System.Windows.Forms.TextBox txtCep;
        protected System.Windows.Forms.DateTimePicker dtpDataNascimentoCriacao;
        protected System.Windows.Forms.ComboBox comboBoxTipo;
        protected System.Windows.Forms.Button btnPesquisarCidade;
        protected System.Windows.Forms.Label lblTipo;
        protected System.Windows.Forms.TextBox txtApelidoNomeFantasia;
        protected System.Windows.Forms.Label lblNome;
        protected System.Windows.Forms.Label lblEndereco;
        protected System.Windows.Forms.Label lblTelefone;
        protected System.Windows.Forms.Label lblCpf;
        protected System.Windows.Forms.Label lblGenero;
        protected System.Windows.Forms.ComboBox comboBoxGenero;
        protected System.Windows.Forms.Label lblNumeroEndereco;
        protected System.Windows.Forms.TextBox txtNumeroEndereco;
        protected System.Windows.Forms.Label lblComplementoEndereco;
        protected System.Windows.Forms.TextBox txtComplementoEndereco;
        protected System.Windows.Forms.Label lblEstado;
        protected System.Windows.Forms.TextBox txtEstado;
        protected System.Windows.Forms.TextBox txtPais;
        protected System.Windows.Forms.Label lblPais;
    }
}

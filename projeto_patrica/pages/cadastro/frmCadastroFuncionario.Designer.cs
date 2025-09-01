namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroFuncionario
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
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.lblCargaHoraria = new System.Windows.Forms.Label();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.lblDataAdmissao = new System.Windows.Forms.Label();
            this.dtpDataAdmissao = new System.Windows.Forms.DateTimePicker();
            this.dtpDataDemissao = new System.Windows.Forms.DateTimePicker();
            this.lblDataDemissao = new System.Windows.Forms.Label();
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
            this.lblNome.Size = new System.Drawing.Size(100, 13);
            this.lblNome.Text = "Funcionário Nome *";
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
            this.btnSave.TabIndex = 27;
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.TabIndex = 99;
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 28;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.ShortcutsEnabled = false;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(21, 373);
            this.lblMatricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(59, 13);
            this.lblMatricula.TabIndex = 30;
            this.lblMatricula.Text = "Matrícula *";
            // 
            // txtMatricula
            // 
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.Location = new System.Drawing.Point(24, 391);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.ShortcutsEnabled = false;
            this.txtMatricula.Size = new System.Drawing.Size(336, 20);
            this.txtMatricula.TabIndex = 20;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(380, 373);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(42, 13);
            this.lblCargo.TabIndex = 30;
            this.lblCargo.Text = "Cargo *";
            // 
            // txtCargo
            // 
            this.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargo.Location = new System.Drawing.Point(383, 391);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.ShortcutsEnabled = false;
            this.txtCargo.Size = new System.Drawing.Size(332, 20);
            this.txtCargo.TabIndex = 21;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(22, 431);
            this.lblTurno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(42, 13);
            this.lblTurno.TabIndex = 30;
            this.lblTurno.Text = "Turno *";
            // 
            // txtTurno
            // 
            this.txtTurno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTurno.Location = new System.Drawing.Point(24, 447);
            this.txtTurno.Margin = new System.Windows.Forms.Padding(2);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ShortcutsEnabled = false;
            this.txtTurno.Size = new System.Drawing.Size(336, 20);
            this.txtTurno.TabIndex = 23;
            // 
            // lblCargaHoraria
            // 
            this.lblCargaHoraria.AutoSize = true;
            this.lblCargaHoraria.Location = new System.Drawing.Point(380, 431);
            this.lblCargaHoraria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargaHoraria.Name = "lblCargaHoraria";
            this.lblCargaHoraria.Size = new System.Drawing.Size(79, 13);
            this.lblCargaHoraria.TabIndex = 30;
            this.lblCargaHoraria.Text = "Carga Horária *";
            // 
            // txtCargaHoraria
            // 
            this.txtCargaHoraria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCargaHoraria.Location = new System.Drawing.Point(383, 447);
            this.txtCargaHoraria.Margin = new System.Windows.Forms.Padding(2);
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.ShortcutsEnabled = false;
            this.txtCargaHoraria.Size = new System.Drawing.Size(332, 20);
            this.txtCargaHoraria.TabIndex = 24;
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.Location = new System.Drawing.Point(736, 375);
            this.lblSalario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(66, 13);
            this.lblSalario.TabIndex = 30;
            this.lblSalario.Text = "Salário (R$)*";
            // 
            // txtSalario
            // 
            this.txtSalario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSalario.Location = new System.Drawing.Point(738, 391);
            this.txtSalario.Margin = new System.Windows.Forms.Padding(2);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.ShortcutsEnabled = false;
            this.txtSalario.Size = new System.Drawing.Size(292, 20);
            this.txtSalario.TabIndex = 22;
            // 
            // lblDataAdmissao
            // 
            this.lblDataAdmissao.AutoSize = true;
            this.lblDataAdmissao.Location = new System.Drawing.Point(735, 431);
            this.lblDataAdmissao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataAdmissao.Name = "lblDataAdmissao";
            this.lblDataAdmissao.Size = new System.Drawing.Size(100, 13);
            this.lblDataAdmissao.TabIndex = 30;
            this.lblDataAdmissao.Text = "Data de Admissão *";
            // 
            // dtpDataAdmissao
            // 
            this.dtpDataAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAdmissao.Location = new System.Drawing.Point(738, 447);
            this.dtpDataAdmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataAdmissao.Name = "dtpDataAdmissao";
            this.dtpDataAdmissao.Size = new System.Drawing.Size(135, 20);
            this.dtpDataAdmissao.TabIndex = 25;
            // 
            // dtpDataDemissao
            // 
            this.dtpDataDemissao.Checked = false;
            this.dtpDataDemissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDemissao.Location = new System.Drawing.Point(895, 447);
            this.dtpDataDemissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataDemissao.Name = "dtpDataDemissao";
            this.dtpDataDemissao.ShowCheckBox = true;
            this.dtpDataDemissao.Size = new System.Drawing.Size(135, 20);
            this.dtpDataDemissao.TabIndex = 26;
            // 
            // lblDataDemissao
            // 
            this.lblDataDemissao.AutoSize = true;
            this.lblDataDemissao.Location = new System.Drawing.Point(893, 429);
            this.lblDataDemissao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataDemissao.Name = "lblDataDemissao";
            this.lblDataDemissao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDataDemissao.Size = new System.Drawing.Size(94, 13);
            this.lblDataDemissao.TabIndex = 34;
            this.lblDataDemissao.Text = "Data de Demissão";
            // 
            // frmCadastroFuncionario
            // 
            this.Controls.Add(this.dtpDataDemissao);
            this.Controls.Add(this.lblDataDemissao);
            this.Controls.Add(this.dtpDataAdmissao);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtCargaHoraria);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.lblCargaHoraria);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblDataAdmissao);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblMatricula);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCadastroFuncionario";
            this.Text = "Cadastro de Funcionário";
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
            this.Controls.SetChildIndex(this.lblGenero, 0);
            this.Controls.SetChildIndex(this.comboBoxGenero, 0);
            this.Controls.SetChildIndex(this.lblMatricula, 0);
            this.Controls.SetChildIndex(this.lblCargo, 0);
            this.Controls.SetChildIndex(this.lblDataAdmissao, 0);
            this.Controls.SetChildIndex(this.lblTurno, 0);
            this.Controls.SetChildIndex(this.lblCargaHoraria, 0);
            this.Controls.SetChildIndex(this.lblSalario, 0);
            this.Controls.SetChildIndex(this.txtMatricula, 0);
            this.Controls.SetChildIndex(this.txtCargo, 0);
            this.Controls.SetChildIndex(this.txtTurno, 0);
            this.Controls.SetChildIndex(this.txtCargaHoraria, 0);
            this.Controls.SetChildIndex(this.txtSalario, 0);
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtApelidoNomeFantasia, 0);
            this.Controls.SetChildIndex(this.txtNomeRazaoSocial, 0);
            this.Controls.SetChildIndex(this.lblApelido, 0);
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
            this.Controls.SetChildIndex(this.dtpDataAdmissao, 0);
            this.Controls.SetChildIndex(this.lblDataDemissao, 0);
            this.Controls.SetChildIndex(this.dtpDataDemissao, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.Label lblCargaHoraria;
        private System.Windows.Forms.TextBox txtCargaHoraria;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label lblDataAdmissao;
        private System.Windows.Forms.DateTimePicker dtpDataAdmissao;
        private System.Windows.Forms.DateTimePicker dtpDataDemissao;
        private System.Windows.Forms.Label lblDataDemissao;
    }
}

namespace projeto_patrica.pages.cadastro
{
	partial class frmCadastro
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCod = new System.Windows.Forms.Label();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.lblDataUltimaEdicao = new System.Windows.Forms.Label();
            this.lblUltimoUsuarioQueEditou = new System.Windows.Forms.Label();
            this.lblDataCadastroData = new System.Windows.Forms.Label();
            this.lblDataUltimaEdicaoData = new System.Windows.Forms.Label();
            this.lblUltimoUsuarioQueEditouNome = new System.Windows.Forms.Label();
            this.checkBoxAtivo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1213, 603);
            this.btnSair.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1120, 603);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(21, 27);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(51, 16);
            this.lblCod.TabIndex = 2;
            this.lblCod.Text = "Código";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Location = new System.Drawing.Point(21, 590);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(116, 16);
            this.lblDataCadastro.TabIndex = 3;
            this.lblDataCadastro.Text = "Data de Cadastro:";
            // 
            // lblDataUltimaEdicao
            // 
            this.lblDataUltimaEdicao.AutoSize = true;
            this.lblDataUltimaEdicao.Location = new System.Drawing.Point(21, 606);
            this.lblDataUltimaEdicao.Name = "lblDataUltimaEdicao";
            this.lblDataUltimaEdicao.Size = new System.Drawing.Size(145, 16);
            this.lblDataUltimaEdicao.TabIndex = 3;
            this.lblDataUltimaEdicao.Text = "Data da Última Edição:";
            // 
            // lblUltimoUsuarioQueEditou
            // 
            this.lblUltimoUsuarioQueEditou.AutoSize = true;
            this.lblUltimoUsuarioQueEditou.Location = new System.Drawing.Point(21, 622);
            this.lblUltimoUsuarioQueEditou.Name = "lblUltimoUsuarioQueEditou";
            this.lblUltimoUsuarioQueEditou.Size = new System.Drawing.Size(165, 16);
            this.lblUltimoUsuarioQueEditou.TabIndex = 3;
            this.lblUltimoUsuarioQueEditou.Text = "Último Usuário que Editou:";
            // 
            // lblDataCadastroData
            // 
            this.lblDataCadastroData.AutoSize = true;
            this.lblDataCadastroData.Location = new System.Drawing.Point(143, 590);
            this.lblDataCadastroData.Name = "lblDataCadastroData";
            this.lblDataCadastroData.Size = new System.Drawing.Size(0, 16);
            this.lblDataCadastroData.TabIndex = 3;
            // 
            // lblDataUltimaEdicaoData
            // 
            this.lblDataUltimaEdicaoData.AutoSize = true;
            this.lblDataUltimaEdicaoData.Location = new System.Drawing.Point(172, 606);
            this.lblDataUltimaEdicaoData.Name = "lblDataUltimaEdicaoData";
            this.lblDataUltimaEdicaoData.Size = new System.Drawing.Size(0, 16);
            this.lblDataUltimaEdicaoData.TabIndex = 3;
            // 
            // lblUltimoUsuarioQueEditouNome
            // 
            this.lblUltimoUsuarioQueEditouNome.AutoSize = true;
            this.lblUltimoUsuarioQueEditouNome.Location = new System.Drawing.Point(192, 622);
            this.lblUltimoUsuarioQueEditouNome.Name = "lblUltimoUsuarioQueEditouNome";
            this.lblUltimoUsuarioQueEditouNome.Size = new System.Drawing.Size(0, 16);
            this.lblUltimoUsuarioQueEditouNome.TabIndex = 3;
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.AutoSize = true;
            this.checkBoxAtivo.Checked = true;
            this.checkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAtivo.Location = new System.Drawing.Point(1234, 23);
            this.checkBoxAtivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAtivo.Name = "checkBoxAtivo";
            this.checkBoxAtivo.Size = new System.Drawing.Size(59, 20);
            this.checkBoxAtivo.TabIndex = 100;
            this.checkBoxAtivo.Text = "Ativo";
            this.checkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // frmCadastro
            // 
            this.Controls.Add(this.checkBoxAtivo);
            this.Controls.Add(this.lblUltimoUsuarioQueEditouNome);
            this.Controls.Add(this.lblUltimoUsuarioQueEditou);
            this.Controls.Add(this.lblDataUltimaEdicaoData);
            this.Controls.Add(this.lblDataUltimaEdicao);
            this.Controls.Add(this.lblDataCadastroData);
            this.Controls.Add(this.lblDataCadastro);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.btnSave);
            this.Name = "frmCadastro";
            this.Text = "Cadastro";
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.lblDataCadastro, 0);
            this.Controls.SetChildIndex(this.lblDataCadastroData, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicao, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicaoData, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditou, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditouNome, 0);
            this.Controls.SetChildIndex(this.checkBoxAtivo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        public System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Label lblCod;
        public System.Windows.Forms.Label lblDataCadastro;
        public System.Windows.Forms.Label lblDataUltimaEdicao;
        public System.Windows.Forms.Label lblUltimoUsuarioQueEditou;
        public System.Windows.Forms.Label lblDataCadastroData;
        public System.Windows.Forms.Label lblDataUltimaEdicaoData;
        public System.Windows.Forms.Label lblUltimoUsuarioQueEditouNome;
        protected System.Windows.Forms.CheckBox checkBoxAtivo;
    }
}

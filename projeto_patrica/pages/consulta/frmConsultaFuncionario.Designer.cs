namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaFuncionario
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
            this.clmCpf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmRg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTelefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMatricula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCargo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSalario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataAdmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTurno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCargaHoraria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGenero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMatricula,
            this.clmNome,
            this.clmCargo,
            this.clmSalario,
            this.clmTurno,
            this.clmCargaHoraria,
            this.clmCpf,
            this.clmRg,
            this.clmGenero,
            this.clmCidade,
            this.clmEmail,
            this.clmTelefone,
            this.clmDataAdmissao,
            this.clmAtivo});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmNome
            // 
            this.clmNome.DisplayIndex = 1;
            this.clmNome.Text = "Nome";
            this.clmNome.Width = 120;
            // 
            // clmCpf
            // 
            this.clmCpf.DisplayIndex = 2;
            this.clmCpf.Text = "CPF";
            this.clmCpf.Width = 120;
            // 
            // clmRg
            // 
            this.clmRg.DisplayIndex = 3;
            this.clmRg.Text = "RG";
            this.clmRg.Width = 120;
            // 
            // clmEmail
            // 
            this.clmEmail.DisplayIndex = 4;
            this.clmEmail.Text = "E-mail";
            this.clmEmail.Width = 120;
            // 
            // clmTelefone
            // 
            this.clmTelefone.DisplayIndex = 5;
            this.clmTelefone.Text = "Telefone";
            this.clmTelefone.Width = 120;
            // 
            // clmCidade
            // 
            this.clmCidade.DisplayIndex = 6;
            this.clmCidade.Text = "Cidade";
            this.clmCidade.Width = 120;
            // 
            // clmAtivo
            // 
            this.clmAtivo.DisplayIndex = 7;
            this.clmAtivo.Text = "Ativo";
            // 
            // clmMatricula
            // 
            this.clmMatricula.DisplayIndex = 8;
            this.clmMatricula.Text = "Matrícula";
            // 
            // clmCargo
            // 
            this.clmCargo.DisplayIndex = 9;
            this.clmCargo.Text = "Cargo";
            this.clmCargo.Width = 120;
            // 
            // clmSalario
            // 
            this.clmSalario.DisplayIndex = 10;
            this.clmSalario.Text = "Salário";
            // 
            // clmDataAdmissao
            // 
            this.clmDataAdmissao.DisplayIndex = 11;
            this.clmDataAdmissao.Text = "Data de Admissão";
            // 
            // clmTurno
            // 
            this.clmTurno.DisplayIndex = 12;
            this.clmTurno.Text = "Turno";
            // 
            // clmCargaHoraria
            // 
            this.clmCargaHoraria.DisplayIndex = 13;
            this.clmCargaHoraria.Text = "Carga Horária";
            // 
            // clmGenero
            // 
            this.clmGenero.DisplayIndex = 14;
            this.clmGenero.Text = "Gênero";
            // 
            // frmConsultaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 387);
            this.Name = "frmConsultaFuncionario";
            this.Text = "Consulta de Funcionário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader clmNome;
        private System.Windows.Forms.ColumnHeader clmCpf;
        private System.Windows.Forms.ColumnHeader clmRg;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.ColumnHeader clmTelefone;
        private System.Windows.Forms.ColumnHeader clmCidade;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.ColumnHeader clmMatricula;
        private System.Windows.Forms.ColumnHeader clmCargo;
        private System.Windows.Forms.ColumnHeader clmSalario;
        private System.Windows.Forms.ColumnHeader clmDataAdmissao;
        private System.Windows.Forms.ColumnHeader clmTurno;
        private System.Windows.Forms.ColumnHeader clmCargaHoraria;
        private System.Windows.Forms.ColumnHeader clmGenero;
    }
}

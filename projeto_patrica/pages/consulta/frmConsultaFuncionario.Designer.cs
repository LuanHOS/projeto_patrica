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
            this.clmMatricula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCargo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSalario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTurno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCargaHoraria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCpf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmRg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGenero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTelefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataAdmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.listV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmConsultaFuncionario_MouseDoubleClick);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // clmMatricula
            // 
            this.clmMatricula.Text = "Matrícula";
            this.clmMatricula.Width = 120;
            // 
            // clmNome
            // 
            this.clmNome.Text = "Nome";
            this.clmNome.Width = 120;
            // 
            // clmCargo
            // 
            this.clmCargo.Text = "Cargo";
            // 
            // clmSalario
            // 
            this.clmSalario.Text = "Salário";
            // 
            // clmTurno
            // 
            this.clmTurno.Text = "Turno";
            // 
            // clmCargaHoraria
            // 
            this.clmCargaHoraria.Text = "Carga Horária";
            // 
            // clmCpf
            // 
            this.clmCpf.Text = "CPF";
            this.clmCpf.Width = 120;
            // 
            // clmRg
            // 
            this.clmRg.Text = "RG";
            this.clmRg.Width = 120;
            // 
            // clmGenero
            // 
            this.clmGenero.Text = "Gênero";
            // 
            // clmCidade
            // 
            this.clmCidade.Text = "Cidade";
            this.clmCidade.Width = 120;
            // 
            // clmEmail
            // 
            this.clmEmail.Text = "E-mail";
            this.clmEmail.Width = 120;
            // 
            // clmTelefone
            // 
            this.clmTelefone.Text = "Telefone";
            this.clmTelefone.Width = 120;
            // 
            // clmDataAdmissao
            // 
            this.clmDataAdmissao.Text = "Data de Admissão";
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Ativo";
            // 
            // frmConsultaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1342, 681);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultaFuncionario";
            this.Text = "Consulta de Funcionário";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmConsultaFuncionario_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmMatricula;
        private System.Windows.Forms.ColumnHeader clmNome;
        private System.Windows.Forms.ColumnHeader clmCargo;
        private System.Windows.Forms.ColumnHeader clmSalario;
        private System.Windows.Forms.ColumnHeader clmTurno;
        private System.Windows.Forms.ColumnHeader clmCargaHoraria;
        private System.Windows.Forms.ColumnHeader clmCpf;
        private System.Windows.Forms.ColumnHeader clmRg;
        private System.Windows.Forms.ColumnHeader clmGenero;
        private System.Windows.Forms.ColumnHeader clmCidade;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.ColumnHeader clmTelefone;
        private System.Windows.Forms.ColumnHeader clmDataAdmissao;
        private System.Windows.Forms.ColumnHeader clmAtivo;
    }
}

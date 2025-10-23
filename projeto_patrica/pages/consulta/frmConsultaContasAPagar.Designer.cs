namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaContasAPagar
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
            this.clmModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSerie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNumNota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmIdFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataVencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFiltros = new System.Windows.Forms.Label();
            this.comboBoxFiltroStatus = new System.Windows.Forms.ComboBox();
            this.btnDarBaixa = new System.Windows.Forms.Button();
            this.clmFormaPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(1127, 617);
            this.btnExcluir.Size = new System.Drawing.Size(96, 34);
            this.btnExcluir.Text = "Cancelar Conta";
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmModelo,
            this.clmSerie,
            this.clmNumNota,
            this.clmIdFornecedor,
            this.clmFornecedor,
            this.clmValorParcela,
            this.clmFormaPagamento,
            this.clmDataEmissao,
            this.clmDataVencimento,
            this.clmAtivo});
            // 
            // clmCod
            // 
            this.clmCod.Text = "Num. Parcela";
            this.clmCod.Width = 120;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(1041, 617);
            this.btnAlterar.Text = "Visualizar";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(869, 617);
            // 
            // clmModelo
            // 
            this.clmModelo.Text = "Modelo";
            this.clmModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmModelo.Width = 80;
            // 
            // clmSerie
            // 
            this.clmSerie.Text = "Série";
            this.clmSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmSerie.Width = 80;
            // 
            // clmNumNota
            // 
            this.clmNumNota.Text = "Nº Nota";
            this.clmNumNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmNumNota.Width = 150;
            // 
            // clmIdFornecedor
            // 
            this.clmIdFornecedor.Text = "Cód. Fornecedor";
            this.clmIdFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmIdFornecedor.Width = 100;
            // 
            // clmFornecedor
            // 
            this.clmFornecedor.Text = "Fornecedor";
            this.clmFornecedor.Width = 250;
            // 
            // clmValorParcela
            // 
            this.clmValorParcela.Text = "Valor da Parcela";
            this.clmValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmValorParcela.Width = 100;
            // 
            // clmDataEmissao
            // 
            this.clmDataEmissao.Text = "Data Emissão";
            this.clmDataEmissao.Width = 120;
            // 
            // clmDataVencimento
            // 
            this.clmDataVencimento.Text = "Data Vencimento";
            this.clmDataVencimento.Width = 120;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Status";
            this.clmAtivo.Width = 80;
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(1054, 30);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(93, 13);
            this.lblFiltros.TabIndex = 10;
            this.lblFiltros.Text = "Filtros de Parcelas";
            // 
            // comboBoxFiltroStatus
            // 
            this.comboBoxFiltroStatus.FormattingEnabled = true;
            this.comboBoxFiltroStatus.Items.AddRange(new object[] {
            "Em Aberto",
            "Paga",
            "Vencida",
            "Cancelada",
            "Todas"});
            this.comboBoxFiltroStatus.Location = new System.Drawing.Point(1057, 46);
            this.comboBoxFiltroStatus.Name = "comboBoxFiltroStatus";
            this.comboBoxFiltroStatus.Size = new System.Drawing.Size(252, 21);
            this.comboBoxFiltroStatus.TabIndex = 11;
            this.comboBoxFiltroStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltroStatus_SelectedIndexChanged);
            // 
            // btnDarBaixa
            // 
            this.btnDarBaixa.Location = new System.Drawing.Point(955, 617);
            this.btnDarBaixa.Name = "btnDarBaixa";
            this.btnDarBaixa.Size = new System.Drawing.Size(80, 34);
            this.btnDarBaixa.TabIndex = 12;
            this.btnDarBaixa.Text = "Dar Baixa";
            this.btnDarBaixa.UseVisualStyleBackColor = true;
            this.btnDarBaixa.Click += new System.EventHandler(this.btnDarBaixa_Click);
            // 
            // clmFormaPagamento
            // 
            this.clmFormaPagamento.Text = "Forma de Pagamento";
            this.clmFormaPagamento.Width = 150;
            // 
            // frmConsultaContasAPagar
            // 
            this.Controls.Add(this.btnDarBaixa);
            this.Controls.Add(this.comboBoxFiltroStatus);
            this.Controls.Add(this.lblFiltros);
            this.Name = "frmConsultaContasAPagar";
            this.Text = "Consulta de Contas a Pagar";
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnIncluir, 0);
            this.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.Controls.SetChildIndex(this.bntLimparPesquisa, 0);
            this.Controls.SetChildIndex(this.listV, 0);
            this.Controls.SetChildIndex(this.lblFiltros, 0);
            this.Controls.SetChildIndex(this.comboBoxFiltroStatus, 0);
            this.Controls.SetChildIndex(this.btnDarBaixa, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmModelo;
        private System.Windows.Forms.ColumnHeader clmSerie;
        private System.Windows.Forms.ColumnHeader clmNumNota;
        private System.Windows.Forms.ColumnHeader clmIdFornecedor;
        private System.Windows.Forms.ColumnHeader clmFornecedor;
        private System.Windows.Forms.ColumnHeader clmValorParcela;
        private System.Windows.Forms.ColumnHeader clmDataEmissao;
        private System.Windows.Forms.ColumnHeader clmDataVencimento;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.ComboBox comboBoxFiltroStatus;
        private System.Windows.Forms.Button btnDarBaixa;
        private System.Windows.Forms.ColumnHeader clmFormaPagamento;
    }
}
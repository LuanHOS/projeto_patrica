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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.clmDataEmissao,
            this.clmDataVencimento,
            this.clmAtivo});
            // 
            // clmCod
            // 
            this.clmCod.Text = "Num. Parcela";
            this.clmCod.Width = 120;
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
            this.clmAtivo.Text = "Ativo";
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Em Aberto",
            "",
            "Paga",
            "",
            "Vencida",
            "",
            "Cancelada"});
            this.comboBox1.Location = new System.Drawing.Point(1057, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // frmConsultaContasAPagar
            // 
            this.Controls.Add(this.comboBox1);
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
            this.Controls.SetChildIndex(this.comboBox1, 0);
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
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

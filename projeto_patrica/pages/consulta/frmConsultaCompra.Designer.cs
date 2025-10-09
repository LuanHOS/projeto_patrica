namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaCompra
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
            this.clmSerie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNumNota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataEntrega = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmQtdProdutos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCondicaoPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(1130, 617);
            this.btnExcluir.Size = new System.Drawing.Size(94, 34);
            this.btnExcluir.Text = "Cancelar Nota";
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSerie,
            this.clmNumNota,
            this.clmFornecedor,
            this.clmDataEmissao,
            this.clmDataEntrega,
            this.clmQtdProdutos,
            this.clmValorTotal,
            this.clmCondicaoPagamento,
            this.clmAtivo});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmCod
            // 
            this.clmCod.Text = "Modelo";
            this.clmCod.Width = 80;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(1044, 617);
            this.btnAlterar.Text = "Vizualizar";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(957, 617);
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
            // clmFornecedor
            // 
            this.clmFornecedor.Text = "Fornecedor";
            this.clmFornecedor.Width = 250;
            // 
            // clmDataEmissao
            // 
            this.clmDataEmissao.Text = "Data Emissão";
            this.clmDataEmissao.Width = 120;
            // 
            // clmValorTotal
            // 
            this.clmValorTotal.Text = "Valor Total";
            this.clmValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmValorTotal.Width = 100;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Ativo";
            this.clmAtivo.Width = 80;
            // 
            // clmDataEntrega
            // 
            this.clmDataEntrega.Text = "Data Entrega";
            this.clmDataEntrega.Width = 120;
            // 
            // clmQtdProdutos
            // 
            this.clmQtdProdutos.Text = "Qtd. Produtos";
            this.clmQtdProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmQtdProdutos.Width = 80;
            // 
            // clmCondicaoPagamento
            // 
            this.clmCondicaoPagamento.Text = "Condição de Pagamento";
            this.clmCondicaoPagamento.Width = 150;
            // 
            // frmConsultaCompra
            // 
            this.Name = "frmConsultaCompra";
            this.Text = "Consulta de Compras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader clmSerie;
        private System.Windows.Forms.ColumnHeader clmNumNota;
        private System.Windows.Forms.ColumnHeader clmFornecedor;
        private System.Windows.Forms.ColumnHeader clmDataEmissao;
        private System.Windows.Forms.ColumnHeader clmValorTotal;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.ColumnHeader clmDataEntrega;
        private System.Windows.Forms.ColumnHeader clmQtdProdutos;
        private System.Windows.Forms.ColumnHeader clmCondicaoPagamento;
    }
}

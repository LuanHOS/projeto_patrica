namespace projeto_patrica.pages.consulta
{
    partial class frmConsultaVenda
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
            this.clmIdCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmIdFuncionario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFuncionario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCondicaoPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMotivoCancelamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataCancelamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIdCliente,
            this.clmCliente,
            this.clmIdFuncionario,
            this.clmFuncionario,
            this.clmSerie,
            this.clmNumNota,
            this.clmDataEmissao,
            this.clmValorTotal,
            this.clmCondicaoPagamento,
            this.clmAtivo,
            this.clmMotivoCancelamento,
            this.clmDataCancelamento});
            // 
            // clmCod
            // 
            this.clmCod.DisplayIndex = 4;
            this.clmCod.Text = "Modelo";
            this.clmCod.Width = 80;
            // 
            // clmSerie
            // 
            this.clmSerie.Text = "Série";
            this.clmSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmSerie.Width = 80;
            // 
            // clmNumNota
            // 
            this.clmNumNota.Text = "Nº  Nota";
            this.clmNumNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmNumNota.Width = 150;
            // 
            // clmIdCliente
            // 
            this.clmIdCliente.DisplayIndex = 0;
            this.clmIdCliente.Text = "Cód. Cliente";
            this.clmIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmIdCliente.Width = 100;
            // 
            // clmCliente
            // 
            this.clmCliente.DisplayIndex = 1;
            this.clmCliente.Text = "Cliente";
            this.clmCliente.Width = 250;
            // 
            // clmIdFuncionario
            // 
            this.clmIdFuncionario.DisplayIndex = 2;
            this.clmIdFuncionario.Text = "Cód. Funcionário";
            this.clmIdFuncionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmIdFuncionario.Width = 100;
            // 
            // clmFuncionario
            // 
            this.clmFuncionario.DisplayIndex = 3;
            this.clmFuncionario.Text = "Funcionário";
            this.clmFuncionario.Width = 250;
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
            // clmCondicaoPagamento
            // 
            this.clmCondicaoPagamento.Text = "Condição de Pagamento";
            this.clmCondicaoPagamento.Width = 150;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Status";
            this.clmAtivo.Width = 80;
            // 
            // clmMotivoCancelamento
            // 
            this.clmMotivoCancelamento.Text = "Motivo do Cancelamento";
            this.clmMotivoCancelamento.Width = 500;
            // 
            // clmDataCancelamento
            // 
            this.clmDataCancelamento.Text = "Data Cancelamento";
            this.clmDataCancelamento.Width = 150;
            // 
            // frmConsultaVenda
            // 
            this.Name = "frmConsultaVenda";
            this.Text = "Consulta de Vendas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmIdCliente;
        private System.Windows.Forms.ColumnHeader clmCliente;
        private System.Windows.Forms.ColumnHeader clmIdFuncionario;
        private System.Windows.Forms.ColumnHeader clmFuncionario;
        private System.Windows.Forms.ColumnHeader clmSerie;
        private System.Windows.Forms.ColumnHeader clmNumNota;
        private System.Windows.Forms.ColumnHeader clmDataEmissao;
        private System.Windows.Forms.ColumnHeader clmValorTotal;
        private System.Windows.Forms.ColumnHeader clmCondicaoPagamento;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.ColumnHeader clmMotivoCancelamento;
        private System.Windows.Forms.ColumnHeader clmDataCancelamento;
    }
}

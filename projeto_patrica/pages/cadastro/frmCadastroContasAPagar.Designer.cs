namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroContasAPagar
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
            this.txtNumDaNota = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblNumNota = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.dtpDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.txtCodFornecedor = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblNumParcela = new System.Windows.Forms.Label();
            this.txtNumParcela = new System.Windows.Forms.TextBox();
            this.btnPesquisarFornecedor = new System.Windows.Forms.Button();
            this.lblValorParcela = new System.Windows.Forms.Label();
            this.txtValorParcela = new System.Windows.Forms.TextBox();
            this.lblDataPagamento = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblMulta = new System.Windows.Forms.Label();
            this.lblJuros = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.txtJuros = new System.Windows.Forms.TextBox();
            this.lblValorFinal = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.btnPesquisarFormaPagamento = new System.Windows.Forms.Button();
            this.txtCodFormaPagamento = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.lblMotivCancelamentoExplicacao = new System.Windows.Forms.Label();
            this.lblMotivoCancelamentoTitulo = new System.Windows.Forms.Label();
            this.dtpDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.txtJurosReais = new System.Windows.Forms.TextBox();
            this.txtMultaReais = new System.Windows.Forms.TextBox();
            this.txtDescontoReais = new System.Windows.Forms.TextBox();
            this.lblJurosReais = new System.Windows.Forms.Label();
            this.lblMultaReais = new System.Windows.Forms.Label();
            this.lblDescontoReais = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 17;
            // 
            // lblCod
            // 
            this.lblCod.Size = new System.Drawing.Size(61, 16);
            this.lblCod.Text = "Modelo *";
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.Location = new System.Drawing.Point(1243, 22);
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 18;
            // 
            // txtCodigo
            // 
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.ShortcutsEnabled = false;
            this.txtCodigo.Size = new System.Drawing.Size(65, 22);
            this.txtCodigo.TextChanged += new System.EventHandler(this.CabecalhoConta_TextChanged);
            // 
            // txtNumDaNota
            // 
            this.txtNumDaNota.Location = new System.Drawing.Point(175, 46);
            this.txtNumDaNota.Name = "txtNumDaNota";
            this.txtNumDaNota.ShortcutsEnabled = false;
            this.txtNumDaNota.Size = new System.Drawing.Size(129, 22);
            this.txtNumDaNota.TabIndex = 3;
            this.txtNumDaNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumDaNota.TextChanged += new System.EventHandler(this.CabecalhoConta_TextChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(107, 46);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ShortcutsEnabled = false;
            this.txtSerie.Size = new System.Drawing.Size(46, 22);
            this.txtSerie.TabIndex = 2;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSerie.TextChanged += new System.EventHandler(this.CabecalhoConta_TextChanged);
            // 
            // lblNumNota
            // 
            this.lblNumNota.AutoSize = true;
            this.lblNumNota.Location = new System.Drawing.Point(172, 28);
            this.lblNumNota.Name = "lblNumNota";
            this.lblNumNota.Size = new System.Drawing.Size(97, 16);
            this.lblNumNota.TabIndex = 103;
            this.lblNumNota.Text = "Núm. da Nota *";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(104, 28);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(47, 16);
            this.lblSerie.TabIndex = 104;
            this.lblSerie.Text = "Série *";
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(671, 46);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(115, 22);
            this.dtpDataEmissao.TabIndex = 5;
            this.dtpDataEmissao.ValueChanged += new System.EventHandler(this.DtpDataEmissao_ValueChanged);
            // 
            // dtpDataVencimento
            // 
            this.dtpDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVencimento.Location = new System.Drawing.Point(804, 46);
            this.dtpDataVencimento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataVencimento.Name = "dtpDataVencimento";
            this.dtpDataVencimento.Size = new System.Drawing.Size(109, 22);
            this.dtpDataVencimento.TabIndex = 6;
            // 
            // txtCodFornecedor
            // 
            this.txtCodFornecedor.Location = new System.Drawing.Point(324, 47);
            this.txtCodFornecedor.Name = "txtCodFornecedor";
            this.txtCodFornecedor.ReadOnly = true;
            this.txtCodFornecedor.ShortcutsEnabled = false;
            this.txtCodFornecedor.Size = new System.Drawing.Size(60, 22);
            this.txtCodFornecedor.TabIndex = 110;
            this.txtCodFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(390, 46);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.ShortcutsEnabled = false;
            this.txtFornecedor.Size = new System.Drawing.Size(214, 22);
            this.txtFornecedor.TabIndex = 111;
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.AutoSize = true;
            this.lblDataVencimento.Location = new System.Drawing.Point(800, 28);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(137, 16);
            this.lblDataVencimento.TabIndex = 107;
            this.lblDataVencimento.Text = "Data de Vencimento *";
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.AutoSize = true;
            this.lblDataEmissao.Location = new System.Drawing.Point(667, 28);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(119, 16);
            this.lblDataEmissao.TabIndex = 108;
            this.lblDataEmissao.Text = "Data de Emissão *";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(321, 26);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(85, 16);
            this.lblFornecedor.TabIndex = 109;
            this.lblFornecedor.Text = "Fornecedor *";
            // 
            // lblNumParcela
            // 
            this.lblNumParcela.AutoSize = true;
            this.lblNumParcela.Location = new System.Drawing.Point(20, 112);
            this.lblNumParcela.Name = "lblNumParcela";
            this.lblNumParcela.Size = new System.Drawing.Size(115, 16);
            this.lblNumParcela.TabIndex = 103;
            this.lblNumParcela.Text = "Núm. da Parcela *";
            // 
            // txtNumParcela
            // 
            this.txtNumParcela.Location = new System.Drawing.Point(23, 130);
            this.txtNumParcela.Name = "txtNumParcela";
            this.txtNumParcela.ShortcutsEnabled = false;
            this.txtNumParcela.Size = new System.Drawing.Size(83, 22);
            this.txtNumParcela.TabIndex = 7;
            this.txtNumParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumParcela.TextChanged += new System.EventHandler(this.CabecalhoConta_TextChanged);
            // 
            // btnPesquisarFornecedor
            // 
            this.btnPesquisarFornecedor.Location = new System.Drawing.Point(610, 44);
            this.btnPesquisarFornecedor.Name = "btnPesquisarFornecedor";
            this.btnPesquisarFornecedor.Size = new System.Drawing.Size(39, 25);
            this.btnPesquisarFornecedor.TabIndex = 4;
            this.btnPesquisarFornecedor.Text = "🔎";
            this.btnPesquisarFornecedor.UseVisualStyleBackColor = true;
            this.btnPesquisarFornecedor.Click += new System.EventHandler(this.btnPesquisarFornecedor_Click);
            // 
            // lblValorParcela
            // 
            this.lblValorParcela.AutoSize = true;
            this.lblValorParcela.Location = new System.Drawing.Point(130, 112);
            this.lblValorParcela.Name = "lblValorParcela";
            this.lblValorParcela.Size = new System.Drawing.Size(144, 16);
            this.lblValorParcela.TabIndex = 103;
            this.lblValorParcela.Text = "Valor da Parcela (R$) *";
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(133, 130);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.ShortcutsEnabled = false;
            this.txtValorParcela.Size = new System.Drawing.Size(189, 22);
            this.txtValorParcela.TabIndex = 8;
            this.txtValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorParcela.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // lblDataPagamento
            // 
            this.lblDataPagamento.AutoSize = true;
            this.lblDataPagamento.Location = new System.Drawing.Point(369, 359);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(136, 16);
            this.lblDataPagamento.TabIndex = 108;
            this.lblDataPagamento.Text = "Data do Pagamento *";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(20, 359);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(146, 16);
            this.lblFormaPagamento.TabIndex = 151;
            this.lblFormaPagamento.Text = "Forma de Pagamento *";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(237, 199);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(88, 16);
            this.lblDesconto.TabIndex = 154;
            this.lblDesconto.Text = "Desconto (%)";
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Location = new System.Drawing.Point(20, 198);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(62, 16);
            this.lblMulta.TabIndex = 155;
            this.lblMulta.Text = "Multa (%)";
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Location = new System.Drawing.Point(130, 198);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(63, 16);
            this.lblJuros.TabIndex = 156;
            this.lblJuros.Text = "Juros (%)";
            // 
            // txtDesconto
            // 
            this.txtDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesconto.Location = new System.Drawing.Point(240, 217);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ShortcutsEnabled = false;
            this.txtDesconto.Size = new System.Drawing.Size(82, 22);
            this.txtDesconto.TabIndex = 11;
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // txtMulta
            // 
            this.txtMulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMulta.Location = new System.Drawing.Point(23, 217);
            this.txtMulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.ShortcutsEnabled = false;
            this.txtMulta.Size = new System.Drawing.Size(82, 22);
            this.txtMulta.TabIndex = 9;
            this.txtMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMulta.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // txtJuros
            // 
            this.txtJuros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJuros.Location = new System.Drawing.Point(133, 217);
            this.txtJuros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.ShortcutsEnabled = false;
            this.txtJuros.Size = new System.Drawing.Size(82, 22);
            this.txtJuros.TabIndex = 10;
            this.txtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJuros.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // lblValorFinal
            // 
            this.lblValorFinal.AutoSize = true;
            this.lblValorFinal.ForeColor = System.Drawing.Color.Red;
            this.lblValorFinal.Location = new System.Drawing.Point(20, 467);
            this.lblValorFinal.Name = "lblValorFinal";
            this.lblValorFinal.Size = new System.Drawing.Size(168, 16);
            this.lblValorFinal.TabIndex = 103;
            this.lblValorFinal.Text = "Valor Final da Parcela (R$)";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(23, 485);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.ReadOnly = true;
            this.txtValorPago.ShortcutsEnabled = false;
            this.txtValorPago.Size = new System.Drawing.Size(131, 22);
            this.txtValorPago.TabIndex = 105;
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPesquisarFormaPagamento
            // 
            this.btnPesquisarFormaPagamento.Location = new System.Drawing.Point(309, 375);
            this.btnPesquisarFormaPagamento.Name = "btnPesquisarFormaPagamento";
            this.btnPesquisarFormaPagamento.Size = new System.Drawing.Size(39, 25);
            this.btnPesquisarFormaPagamento.TabIndex = 15;
            this.btnPesquisarFormaPagamento.Text = "🔎";
            this.btnPesquisarFormaPagamento.UseVisualStyleBackColor = true;
            this.btnPesquisarFormaPagamento.Click += new System.EventHandler(this.btnPesquisarFormaPagamento_Click);
            // 
            // txtCodFormaPagamento
            // 
            this.txtCodFormaPagamento.Location = new System.Drawing.Point(23, 378);
            this.txtCodFormaPagamento.Name = "txtCodFormaPagamento";
            this.txtCodFormaPagamento.ReadOnly = true;
            this.txtCodFormaPagamento.ShortcutsEnabled = false;
            this.txtCodFormaPagamento.Size = new System.Drawing.Size(60, 22);
            this.txtCodFormaPagamento.TabIndex = 161;
            this.txtCodFormaPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Location = new System.Drawing.Point(89, 377);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.ReadOnly = true;
            this.txtFormaPagamento.ShortcutsEnabled = false;
            this.txtFormaPagamento.Size = new System.Drawing.Size(214, 22);
            this.txtFormaPagamento.TabIndex = 162;
            // 
            // lblMotivCancelamentoExplicacao
            // 
            this.lblMotivCancelamentoExplicacao.AutoSize = true;
            this.lblMotivCancelamentoExplicacao.Location = new System.Drawing.Point(388, 609);
            this.lblMotivCancelamentoExplicacao.Name = "lblMotivCancelamentoExplicacao";
            this.lblMotivCancelamentoExplicacao.Size = new System.Drawing.Size(136, 16);
            this.lblMotivCancelamentoExplicacao.TabIndex = 164;
            this.lblMotivCancelamentoExplicacao.Text = "Explicação do Motivo";
            this.lblMotivCancelamentoExplicacao.Visible = false;
            // 
            // lblMotivoCancelamentoTitulo
            // 
            this.lblMotivoCancelamentoTitulo.AutoSize = true;
            this.lblMotivoCancelamentoTitulo.Location = new System.Drawing.Point(387, 590);
            this.lblMotivoCancelamentoTitulo.Name = "lblMotivoCancelamentoTitulo";
            this.lblMotivoCancelamentoTitulo.Size = new System.Drawing.Size(156, 16);
            this.lblMotivoCancelamentoTitulo.TabIndex = 165;
            this.lblMotivoCancelamentoTitulo.Text = "Motivo de Cancelamento";
            this.lblMotivoCancelamentoTitulo.Visible = false;
            // 
            // dtpDataPagamento
            // 
            this.dtpDataPagamento.Checked = false;
            this.dtpDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPagamento.Location = new System.Drawing.Point(372, 377);
            this.dtpDataPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataPagamento.Name = "dtpDataPagamento";
            this.dtpDataPagamento.ShowCheckBox = true;
            this.dtpDataPagamento.Size = new System.Drawing.Size(135, 22);
            this.dtpDataPagamento.TabIndex = 16;
            this.dtpDataPagamento.ValueChanged += new System.EventHandler(this.RecalcularValorPago);
            // 
            // txtJurosReais
            // 
            this.txtJurosReais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJurosReais.Location = new System.Drawing.Point(133, 279);
            this.txtJurosReais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJurosReais.Name = "txtJurosReais";
            this.txtJurosReais.ShortcutsEnabled = false;
            this.txtJurosReais.Size = new System.Drawing.Size(82, 22);
            this.txtJurosReais.TabIndex = 13;
            this.txtJurosReais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJurosReais.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // txtMultaReais
            // 
            this.txtMultaReais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMultaReais.Location = new System.Drawing.Point(23, 279);
            this.txtMultaReais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMultaReais.Name = "txtMultaReais";
            this.txtMultaReais.ShortcutsEnabled = false;
            this.txtMultaReais.Size = new System.Drawing.Size(82, 22);
            this.txtMultaReais.TabIndex = 12;
            this.txtMultaReais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMultaReais.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // txtDescontoReais
            // 
            this.txtDescontoReais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescontoReais.Location = new System.Drawing.Point(240, 279);
            this.txtDescontoReais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescontoReais.Name = "txtDescontoReais";
            this.txtDescontoReais.ShortcutsEnabled = false;
            this.txtDescontoReais.Size = new System.Drawing.Size(82, 22);
            this.txtDescontoReais.TabIndex = 14;
            this.txtDescontoReais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoReais.Leave += new System.EventHandler(this.AtualizarValorPagoFinal_Handler);
            // 
            // lblJurosReais
            // 
            this.lblJurosReais.AutoSize = true;
            this.lblJurosReais.Location = new System.Drawing.Point(130, 260);
            this.lblJurosReais.Name = "lblJurosReais";
            this.lblJurosReais.Size = new System.Drawing.Size(68, 16);
            this.lblJurosReais.TabIndex = 156;
            this.lblJurosReais.Text = "Juros (R$)";
            // 
            // lblMultaReais
            // 
            this.lblMultaReais.AutoSize = true;
            this.lblMultaReais.Location = new System.Drawing.Point(20, 260);
            this.lblMultaReais.Name = "lblMultaReais";
            this.lblMultaReais.Size = new System.Drawing.Size(67, 16);
            this.lblMultaReais.TabIndex = 155;
            this.lblMultaReais.Text = "Multa (R$)";
            // 
            // lblDescontoReais
            // 
            this.lblDescontoReais.AutoSize = true;
            this.lblDescontoReais.Location = new System.Drawing.Point(237, 261);
            this.lblDescontoReais.Name = "lblDescontoReais";
            this.lblDescontoReais.Size = new System.Drawing.Size(93, 16);
            this.lblDescontoReais.TabIndex = 154;
            this.lblDescontoReais.Text = "Desconto (R$)";
            // 
            // frmCadastroContasAPagar
            // 
            this.Controls.Add(this.dtpDataPagamento);
            this.Controls.Add(this.lblMotivCancelamentoExplicacao);
            this.Controls.Add(this.lblMotivoCancelamentoTitulo);
            this.Controls.Add(this.btnPesquisarFormaPagamento);
            this.Controls.Add(this.txtCodFormaPagamento);
            this.Controls.Add(this.txtFormaPagamento);
            this.Controls.Add(this.lblDescontoReais);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.lblMultaReais);
            this.Controls.Add(this.lblMulta);
            this.Controls.Add(this.lblJurosReais);
            this.Controls.Add(this.lblJuros);
            this.Controls.Add(this.txtDescontoReais);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtMultaReais);
            this.Controls.Add(this.txtJurosReais);
            this.Controls.Add(this.txtMulta);
            this.Controls.Add(this.txtJuros);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.btnPesquisarFornecedor);
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.dtpDataVencimento);
            this.Controls.Add(this.txtCodFornecedor);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblDataPagamento);
            this.Controls.Add(this.lblDataVencimento);
            this.Controls.Add(this.lblDataEmissao);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.txtValorParcela);
            this.Controls.Add(this.lblValorFinal);
            this.Controls.Add(this.txtNumParcela);
            this.Controls.Add(this.lblValorParcela);
            this.Controls.Add(this.txtNumDaNota);
            this.Controls.Add(this.lblNumParcela);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblNumNota);
            this.Controls.Add(this.lblSerie);
            this.Name = "frmCadastroContasAPagar";
            this.Text = "Cadastro de Contas a Pagar";
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.lblNumNota, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblNumParcela, 0);
            this.Controls.SetChildIndex(this.txtNumDaNota, 0);
            this.Controls.SetChildIndex(this.lblValorParcela, 0);
            this.Controls.SetChildIndex(this.txtNumParcela, 0);
            this.Controls.SetChildIndex(this.lblValorFinal, 0);
            this.Controls.SetChildIndex(this.txtValorParcela, 0);
            this.Controls.SetChildIndex(this.txtValorPago, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.lblDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblDataVencimento, 0);
            this.Controls.SetChildIndex(this.lblDataPagamento, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.txtCodFornecedor, 0);
            this.Controls.SetChildIndex(this.dtpDataVencimento, 0);
            this.Controls.SetChildIndex(this.dtpDataEmissao, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFornecedor, 0);
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
            this.Controls.SetChildIndex(this.lblFormaPagamento, 0);
            this.Controls.SetChildIndex(this.txtJuros, 0);
            this.Controls.SetChildIndex(this.txtMulta, 0);
            this.Controls.SetChildIndex(this.txtJurosReais, 0);
            this.Controls.SetChildIndex(this.txtMultaReais, 0);
            this.Controls.SetChildIndex(this.txtDesconto, 0);
            this.Controls.SetChildIndex(this.txtDescontoReais, 0);
            this.Controls.SetChildIndex(this.lblJuros, 0);
            this.Controls.SetChildIndex(this.lblJurosReais, 0);
            this.Controls.SetChildIndex(this.lblMulta, 0);
            this.Controls.SetChildIndex(this.lblMultaReais, 0);
            this.Controls.SetChildIndex(this.lblDesconto, 0);
            this.Controls.SetChildIndex(this.lblDescontoReais, 0);
            this.Controls.SetChildIndex(this.txtFormaPagamento, 0);
            this.Controls.SetChildIndex(this.txtCodFormaPagamento, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFormaPagamento, 0);
            this.Controls.SetChildIndex(this.lblMotivoCancelamentoTitulo, 0);
            this.Controls.SetChildIndex(this.lblMotivCancelamentoExplicacao, 0);
            this.Controls.SetChildIndex(this.dtpDataPagamento, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumDaNota;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblNumNota;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.DateTimePicker dtpDataEmissao;
        private System.Windows.Forms.DateTimePicker dtpDataVencimento;
        private System.Windows.Forms.TextBox txtCodFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label lblNumParcela;
        private System.Windows.Forms.TextBox txtNumParcela;
        private System.Windows.Forms.Button btnPesquisarFornecedor;
        private System.Windows.Forms.Label lblValorParcela;
        private System.Windows.Forms.TextBox txtValorParcela;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.TextBox txtJuros;
        private System.Windows.Forms.Label lblValorFinal;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Button btnPesquisarFormaPagamento;
        private System.Windows.Forms.TextBox txtCodFormaPagamento;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.Label lblMotivCancelamentoExplicacao;
        private System.Windows.Forms.Label lblMotivoCancelamentoTitulo;
        private System.Windows.Forms.DateTimePicker dtpDataPagamento;
        private System.Windows.Forms.TextBox txtJurosReais;
        private System.Windows.Forms.TextBox txtMultaReais;
        private System.Windows.Forms.TextBox txtDescontoReais;
        private System.Windows.Forms.Label lblJurosReais;
        private System.Windows.Forms.Label lblMultaReais;
        private System.Windows.Forms.Label lblDescontoReais;
    }
}
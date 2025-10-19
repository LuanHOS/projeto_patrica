namespace projeto_patrica.pages.cadastro
{
	partial class frmCadastroVenda
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
			if(disposing && (components != null))
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
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.listVParcelas = new System.Windows.Forms.ListView();
            this.clmNumParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataVencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFormaPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listVProdutos = new System.Windows.Forms.ListView();
            this.clmCodProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUnMedida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmQtd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPesquisarCondicaoDePagamento = new System.Windows.Forms.Button();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.btnLimparListaProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnLimparParcelas = new System.Windows.Forms.Button();
            this.btnGerarParcelas = new System.Windows.Forms.Button();
            this.btnPesquisarFuncionario = new System.Windows.Forms.Button();
            this.txtCondicaoDePagamento = new System.Windows.Forms.TextBox();
            this.txtValorTotalValores = new System.Windows.Forms.TextBox();
            this.txtUnidadeDeMedida = new System.Windows.Forms.TextBox();
            this.txtTotalProduto = new System.Windows.Forms.TextBox();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblCondicaoDePagamento = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblValorTotalValores = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.txtCodCondicaoDePagamento = new System.Windows.Forms.TextBox();
            this.txtCodFuncionario = new System.Windows.Forms.TextBox();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.lblTotalProduto = new System.Windows.Forms.Label();
            this.txtNumDaNota = new System.Windows.Forms.TextBox();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.lblValorTotalParcelas = new System.Windows.Forms.Label();
            this.lblMotivCancelamentoExplicacao = new System.Windows.Forms.Label();
            this.lblValorQtdTotalProdutos = new System.Windows.Forms.Label();
            this.lblValorTotalGeralProdutos = new System.Windows.Forms.Label();
            this.lblTotalParcelas = new System.Windows.Forms.Label();
            this.lblMotivoCancelamentoTitulo = new System.Windows.Forms.Label();
            this.lblQtdTotalProdutos = new System.Windows.Forms.Label();
            this.lblTotalGeralProdutos = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblUnidadeDeMedida = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.lblNumNota = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1143, 632);
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(13, 16);
            this.lblCod.Size = new System.Drawing.Size(42, 13);
            this.lblCod.Text = "Modelo";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.Location = new System.Drawing.Point(13, 622);
            // 
            // lblDataUltimaEdicao
            // 
            this.lblDataUltimaEdicao.Location = new System.Drawing.Point(13, 638);
            // 
            // lblUltimoUsuarioQueEditou
            // 
            this.lblUltimoUsuarioQueEditou.Location = new System.Drawing.Point(13, 654);
            // 
            // lblDataCadastroData
            // 
            this.lblDataCadastroData.Location = new System.Drawing.Point(135, 622);
            // 
            // lblDataUltimaEdicaoData
            // 
            this.lblDataUltimaEdicaoData.Location = new System.Drawing.Point(164, 638);
            // 
            // lblUltimoUsuarioQueEditouNome
            // 
            this.lblUltimoUsuarioQueEditouNome.Location = new System.Drawing.Point(184, 654);
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.Location = new System.Drawing.Point(1266, 15);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1236, 632);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = true;
            this.txtCodigo.Location = new System.Drawing.Point(14, 32);
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.ShortcutsEnabled = false;
            this.txtCodigo.Size = new System.Drawing.Size(62, 20);
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(1022, 33);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(115, 20);
            this.dtpDataEmissao.TabIndex = 158;
            // 
            // listVParcelas
            // 
            this.listVParcelas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNumParcela,
            this.clmDataEmissao,
            this.clmDataVencimento,
            this.clmValorParcela,
            this.clmFormaPagamento});
            this.listVParcelas.FullRowSelect = true;
            this.listVParcelas.GridLines = true;
            this.listVParcelas.HideSelection = false;
            this.listVParcelas.Location = new System.Drawing.Point(12, 443);
            this.listVParcelas.Name = "listVParcelas";
            this.listVParcelas.Size = new System.Drawing.Size(1304, 168);
            this.listVParcelas.TabIndex = 156;
            this.listVParcelas.UseCompatibleStateImageBehavior = false;
            this.listVParcelas.View = System.Windows.Forms.View.Details;
            // 
            // clmNumParcela
            // 
            this.clmNumParcela.Text = "Num. Parcela";
            this.clmNumParcela.Width = 120;
            // 
            // clmDataEmissao
            // 
            this.clmDataEmissao.Text = "Data de Emissão";
            this.clmDataEmissao.Width = 120;
            // 
            // clmDataVencimento
            // 
            this.clmDataVencimento.Text = "Data de Vencimento";
            this.clmDataVencimento.Width = 120;
            // 
            // clmValorParcela
            // 
            this.clmValorParcela.Text = "Valor Parcela";
            this.clmValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmValorParcela.Width = 120;
            // 
            // clmFormaPagamento
            // 
            this.clmFormaPagamento.Text = "Forma de Pagamento";
            this.clmFormaPagamento.Width = 200;
            // 
            // listVProdutos
            // 
            this.listVProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCodProduto,
            this.clmProduto,
            this.clmUnMedida,
            this.clmQtd,
            this.clmValorUnitario,
            this.clmTotal});
            this.listVProdutos.FullRowSelect = true;
            this.listVProdutos.GridLines = true;
            this.listVProdutos.HideSelection = false;
            this.listVProdutos.Location = new System.Drawing.Point(16, 109);
            this.listVProdutos.Name = "listVProdutos";
            this.listVProdutos.Size = new System.Drawing.Size(1300, 227);
            this.listVProdutos.TabIndex = 155;
            this.listVProdutos.UseCompatibleStateImageBehavior = false;
            this.listVProdutos.View = System.Windows.Forms.View.Details;
            // 
            // clmCodProduto
            // 
            this.clmCodProduto.Text = "Cód. Produto";
            this.clmCodProduto.Width = 120;
            // 
            // clmProduto
            // 
            this.clmProduto.Text = "Produto";
            this.clmProduto.Width = 180;
            // 
            // clmUnMedida
            // 
            this.clmUnMedida.Text = "Un. de Medida";
            this.clmUnMedida.Width = 120;
            // 
            // clmQtd
            // 
            this.clmQtd.Text = "Quantidade";
            this.clmQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmQtd.Width = 120;
            // 
            // clmValorUnitario
            // 
            this.clmValorUnitario.Text = "Valor Unitário";
            this.clmValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmValorUnitario.Width = 120;
            // 
            // clmTotal
            // 
            this.clmTotal.Text = "Total";
            this.clmTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmTotal.Width = 120;
            // 
            // btnPesquisarCondicaoDePagamento
            // 
            this.btnPesquisarCondicaoDePagamento.Location = new System.Drawing.Point(318, 415);
            this.btnPesquisarCondicaoDePagamento.Name = "btnPesquisarCondicaoDePagamento";
            this.btnPesquisarCondicaoDePagamento.Size = new System.Drawing.Size(39, 23);
            this.btnPesquisarCondicaoDePagamento.TabIndex = 147;
            this.btnPesquisarCondicaoDePagamento.Text = "🔎";
            this.btnPesquisarCondicaoDePagamento.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Location = new System.Drawing.Point(295, 80);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(39, 23);
            this.btnPesquisarProduto.TabIndex = 148;
            this.btnPesquisarProduto.Text = "🔎";
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            // 
            // btnLimparListaProduto
            // 
            this.btnLimparListaProduto.Location = new System.Drawing.Point(1122, 78);
            this.btnLimparListaProduto.Name = "btnLimparListaProduto";
            this.btnLimparListaProduto.Size = new System.Drawing.Size(98, 23);
            this.btnLimparListaProduto.TabIndex = 146;
            this.btnLimparListaProduto.Text = "Limpar Lista";
            this.btnLimparListaProduto.UseVisualStyleBackColor = true;
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(1041, 78);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverProduto.TabIndex = 154;
            this.btnRemoverProduto.Text = "Remover";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.Location = new System.Drawing.Point(959, 78);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(76, 23);
            this.btnEditarProduto.TabIndex = 150;
            this.btnEditarProduto.Text = "Editar";
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(879, 78);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(74, 23);
            this.btnAdicionarProduto.TabIndex = 151;
            this.btnAdicionarProduto.Text = "Adicionar ";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            // 
            // btnLimparParcelas
            // 
            this.btnLimparParcelas.Location = new System.Drawing.Point(485, 414);
            this.btnLimparParcelas.Name = "btnLimparParcelas";
            this.btnLimparParcelas.Size = new System.Drawing.Size(122, 23);
            this.btnLimparParcelas.TabIndex = 152;
            this.btnLimparParcelas.Text = "Limpar Parcelas";
            this.btnLimparParcelas.UseVisualStyleBackColor = true;
            // 
            // btnGerarParcelas
            // 
            this.btnGerarParcelas.Location = new System.Drawing.Point(367, 414);
            this.btnGerarParcelas.Name = "btnGerarParcelas";
            this.btnGerarParcelas.Size = new System.Drawing.Size(112, 23);
            this.btnGerarParcelas.TabIndex = 153;
            this.btnGerarParcelas.Text = "Gerar Parcelas";
            this.btnGerarParcelas.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarFuncionario
            // 
            this.btnPesquisarFuncionario.Location = new System.Drawing.Point(613, 32);
            this.btnPesquisarFuncionario.Name = "btnPesquisarFuncionario";
            this.btnPesquisarFuncionario.Size = new System.Drawing.Size(39, 25);
            this.btnPesquisarFuncionario.TabIndex = 149;
            this.btnPesquisarFuncionario.Text = "🔎";
            this.btnPesquisarFuncionario.UseVisualStyleBackColor = true;
            // 
            // txtCondicaoDePagamento
            // 
            this.txtCondicaoDePagamento.Location = new System.Drawing.Point(78, 416);
            this.txtCondicaoDePagamento.Name = "txtCondicaoDePagamento";
            this.txtCondicaoDePagamento.ReadOnly = true;
            this.txtCondicaoDePagamento.ShortcutsEnabled = false;
            this.txtCondicaoDePagamento.Size = new System.Drawing.Size(234, 20);
            this.txtCondicaoDePagamento.TabIndex = 132;
            // 
            // txtValorTotalValores
            // 
            this.txtValorTotalValores.Location = new System.Drawing.Point(919, 418);
            this.txtValorTotalValores.Name = "txtValorTotalValores";
            this.txtValorTotalValores.ReadOnly = true;
            this.txtValorTotalValores.ShortcutsEnabled = false;
            this.txtValorTotalValores.Size = new System.Drawing.Size(172, 20);
            this.txtValorTotalValores.TabIndex = 133;
            this.txtValorTotalValores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUnidadeDeMedida
            // 
            this.txtUnidadeDeMedida.Location = new System.Drawing.Point(340, 80);
            this.txtUnidadeDeMedida.Name = "txtUnidadeDeMedida";
            this.txtUnidadeDeMedida.ReadOnly = true;
            this.txtUnidadeDeMedida.ShortcutsEnabled = false;
            this.txtUnidadeDeMedida.Size = new System.Drawing.Size(80, 20);
            this.txtUnidadeDeMedida.TabIndex = 135;
            // 
            // txtTotalProduto
            // 
            this.txtTotalProduto.Location = new System.Drawing.Point(750, 80);
            this.txtTotalProduto.Name = "txtTotalProduto";
            this.txtTotalProduto.ReadOnly = true;
            this.txtTotalProduto.ShortcutsEnabled = false;
            this.txtTotalProduto.Size = new System.Drawing.Size(100, 20);
            this.txtTotalProduto.TabIndex = 136;
            this.txtTotalProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(534, 81);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.ReadOnly = true;
            this.txtValorUnitario.ShortcutsEnabled = false;
            this.txtValorUnitario.Size = new System.Drawing.Size(88, 20);
            this.txtValorUnitario.TabIndex = 142;
            this.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(441, 81);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ShortcutsEnabled = false;
            this.txtQuantidade.Size = new System.Drawing.Size(74, 20);
            this.txtQuantidade.TabIndex = 131;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCondicaoDePagamento
            // 
            this.lblCondicaoDePagamento.AutoSize = true;
            this.lblCondicaoDePagamento.Location = new System.Drawing.Point(9, 398);
            this.lblCondicaoDePagamento.Name = "lblCondicaoDePagamento";
            this.lblCondicaoDePagamento.Size = new System.Drawing.Size(131, 13);
            this.lblCondicaoDePagamento.TabIndex = 128;
            this.lblCondicaoDePagamento.Text = "Condição de Pagamento *";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(82, 80);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.ShortcutsEnabled = false;
            this.txtProduto.Size = new System.Drawing.Size(207, 20);
            this.txtProduto.TabIndex = 130;
            // 
            // lblValorTotalValores
            // 
            this.lblValorTotalValores.AutoSize = true;
            this.lblValorTotalValores.ForeColor = System.Drawing.Color.Red;
            this.lblValorTotalValores.Location = new System.Drawing.Point(916, 400);
            this.lblValorTotalValores.Name = "lblValorTotalValores";
            this.lblValorTotalValores.Size = new System.Drawing.Size(107, 13);
            this.lblValorTotalValores.TabIndex = 127;
            this.lblValorTotalValores.Text = "Valor Total Nota (R$)";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(16, 80);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.ReadOnly = true;
            this.txtCodProduto.ShortcutsEnabled = false;
            this.txtCodProduto.Size = new System.Drawing.Size(60, 20);
            this.txtCodProduto.TabIndex = 141;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodCondicaoDePagamento
            // 
            this.txtCodCondicaoDePagamento.Location = new System.Drawing.Point(12, 415);
            this.txtCodCondicaoDePagamento.Name = "txtCodCondicaoDePagamento";
            this.txtCodCondicaoDePagamento.ReadOnly = true;
            this.txtCodCondicaoDePagamento.ShortcutsEnabled = false;
            this.txtCodCondicaoDePagamento.Size = new System.Drawing.Size(60, 20);
            this.txtCodCondicaoDePagamento.TabIndex = 140;
            this.txtCodCondicaoDePagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodFuncionario
            // 
            this.txtCodFuncionario.Location = new System.Drawing.Point(327, 33);
            this.txtCodFuncionario.Name = "txtCodFuncionario";
            this.txtCodFuncionario.ReadOnly = true;
            this.txtCodFuncionario.ShortcutsEnabled = false;
            this.txtCodFuncionario.Size = new System.Drawing.Size(60, 20);
            this.txtCodFuncionario.TabIndex = 139;
            this.txtCodFuncionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Location = new System.Drawing.Point(393, 32);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.ReadOnly = true;
            this.txtFuncionario.ShortcutsEnabled = false;
            this.txtFuncionario.Size = new System.Drawing.Size(214, 20);
            this.txtFuncionario.TabIndex = 138;
            // 
            // lblTotalProduto
            // 
            this.lblTotalProduto.AutoSize = true;
            this.lblTotalProduto.Location = new System.Drawing.Point(747, 62);
            this.lblTotalProduto.Name = "lblTotalProduto";
            this.lblTotalProduto.Size = new System.Drawing.Size(54, 13);
            this.lblTotalProduto.TabIndex = 109;
            this.lblTotalProduto.Text = "Total (R$)";
            // 
            // txtNumDaNota
            // 
            this.txtNumDaNota.Location = new System.Drawing.Point(172, 32);
            this.txtNumDaNota.Name = "txtNumDaNota";
            this.txtNumDaNota.ShortcutsEnabled = false;
            this.txtNumDaNota.Size = new System.Drawing.Size(129, 20);
            this.txtNumDaNota.TabIndex = 137;
            this.txtNumDaNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(531, 62);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(92, 13);
            this.lblPrecoVenda.TabIndex = 111;
            this.lblPrecoVenda.Text = "Preço Venda (R$)";
            // 
            // lblValorTotalParcelas
            // 
            this.lblValorTotalParcelas.AutoSize = true;
            this.lblValorTotalParcelas.Location = new System.Drawing.Point(1078, 615);
            this.lblValorTotalParcelas.Name = "lblValorTotalParcelas";
            this.lblValorTotalParcelas.Size = new System.Drawing.Size(13, 13);
            this.lblValorTotalParcelas.TabIndex = 112;
            this.lblValorTotalParcelas.Text = "0";
            // 
            // lblMotivCancelamentoExplicacao
            // 
            this.lblMotivCancelamentoExplicacao.AutoSize = true;
            this.lblMotivCancelamentoExplicacao.Location = new System.Drawing.Point(376, 643);
            this.lblMotivCancelamentoExplicacao.Name = "lblMotivCancelamentoExplicacao";
            this.lblMotivCancelamentoExplicacao.Size = new System.Drawing.Size(109, 13);
            this.lblMotivCancelamentoExplicacao.TabIndex = 113;
            this.lblMotivCancelamentoExplicacao.Text = "Explicação do Motivo";
            this.lblMotivCancelamentoExplicacao.Visible = false;
            // 
            // lblValorQtdTotalProdutos
            // 
            this.lblValorQtdTotalProdutos.AutoSize = true;
            this.lblValorQtdTotalProdutos.Location = new System.Drawing.Point(1078, 339);
            this.lblValorQtdTotalProdutos.Name = "lblValorQtdTotalProdutos";
            this.lblValorQtdTotalProdutos.Size = new System.Drawing.Size(13, 13);
            this.lblValorQtdTotalProdutos.TabIndex = 114;
            this.lblValorQtdTotalProdutos.Text = "0";
            // 
            // lblValorTotalGeralProdutos
            // 
            this.lblValorTotalGeralProdutos.AutoSize = true;
            this.lblValorTotalGeralProdutos.Location = new System.Drawing.Point(1078, 362);
            this.lblValorTotalGeralProdutos.Name = "lblValorTotalGeralProdutos";
            this.lblValorTotalGeralProdutos.Size = new System.Drawing.Size(13, 13);
            this.lblValorTotalGeralProdutos.TabIndex = 115;
            this.lblValorTotalGeralProdutos.Text = "0";
            // 
            // lblTotalParcelas
            // 
            this.lblTotalParcelas.AutoSize = true;
            this.lblTotalParcelas.Location = new System.Drawing.Point(916, 615);
            this.lblTotalParcelas.Name = "lblTotalParcelas";
            this.lblTotalParcelas.Size = new System.Drawing.Size(101, 13);
            this.lblTotalParcelas.TabIndex = 116;
            this.lblTotalParcelas.Text = "Total Parcelas (R$):";
            // 
            // lblMotivoCancelamentoTitulo
            // 
            this.lblMotivoCancelamentoTitulo.AutoSize = true;
            this.lblMotivoCancelamentoTitulo.Location = new System.Drawing.Point(375, 624);
            this.lblMotivoCancelamentoTitulo.Name = "lblMotivoCancelamentoTitulo";
            this.lblMotivoCancelamentoTitulo.Size = new System.Drawing.Size(125, 13);
            this.lblMotivoCancelamentoTitulo.TabIndex = 117;
            this.lblMotivoCancelamentoTitulo.Text = "Motivo de Cancelamento";
            this.lblMotivoCancelamentoTitulo.Visible = false;
            // 
            // lblQtdTotalProdutos
            // 
            this.lblQtdTotalProdutos.AutoSize = true;
            this.lblQtdTotalProdutos.Location = new System.Drawing.Point(916, 339);
            this.lblQtdTotalProdutos.Name = "lblQtdTotalProdutos";
            this.lblQtdTotalProdutos.Size = new System.Drawing.Size(117, 13);
            this.lblQtdTotalProdutos.TabIndex = 118;
            this.lblQtdTotalProdutos.Text = "Qtd. Total de Produtos:";
            // 
            // lblTotalGeralProdutos
            // 
            this.lblTotalGeralProdutos.AutoSize = true;
            this.lblTotalGeralProdutos.Location = new System.Drawing.Point(916, 362);
            this.lblTotalGeralProdutos.Name = "lblTotalGeralProdutos";
            this.lblTotalGeralProdutos.Size = new System.Drawing.Size(102, 13);
            this.lblTotalGeralProdutos.TabIndex = 119;
            this.lblTotalGeralProdutos.Text = "Valor Produtos (R$):";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(97, 33);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ShortcutsEnabled = false;
            this.txtSerie.Size = new System.Drawing.Size(46, 20);
            this.txtSerie.TabIndex = 145;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUnidadeDeMedida
            // 
            this.lblUnidadeDeMedida.AutoSize = true;
            this.lblUnidadeDeMedida.Location = new System.Drawing.Point(339, 62);
            this.lblUnidadeDeMedida.Name = "lblUnidadeDeMedida";
            this.lblUnidadeDeMedida.Size = new System.Drawing.Size(77, 13);
            this.lblUnidadeDeMedida.TabIndex = 121;
            this.lblUnidadeDeMedida.Text = "Un. de Medida";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(438, 63);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 122;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(13, 61);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(51, 13);
            this.lblProduto.TabIndex = 123;
            this.lblProduto.Text = "Produto *";
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.AutoSize = true;
            this.lblDataEmissao.Location = new System.Drawing.Point(1018, 15);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(94, 13);
            this.lblDataEmissao.TabIndex = 125;
            this.lblDataEmissao.Text = "Data de Emissão *";
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Location = new System.Drawing.Point(324, 13);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(69, 13);
            this.lblFuncionario.TabIndex = 126;
            this.lblFuncionario.Text = "Funcionário *";
            // 
            // lblNumNota
            // 
            this.lblNumNota.AutoSize = true;
            this.lblNumNota.Location = new System.Drawing.Point(169, 14);
            this.lblNumNota.Name = "lblNumNota";
            this.lblNumNota.Size = new System.Drawing.Size(80, 13);
            this.lblNumNota.TabIndex = 108;
            this.lblNumNota.Text = "Núm. da Nota *";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(94, 15);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(38, 13);
            this.lblSerie.TabIndex = 129;
            this.lblSerie.Text = "Série *";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(666, 13);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 13);
            this.lblCliente.TabIndex = 126;
            this.lblCliente.Text = "Cliente *";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(735, 32);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.ShortcutsEnabled = false;
            this.txtCliente.Size = new System.Drawing.Size(214, 20);
            this.txtCliente.TabIndex = 138;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(669, 33);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.ShortcutsEnabled = false;
            this.txtCodCliente.Size = new System.Drawing.Size(60, 20);
            this.txtCodCliente.TabIndex = 139;
            this.txtCodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.Location = new System.Drawing.Point(955, 32);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(39, 25);
            this.btnPesquisarCliente.TabIndex = 149;
            this.btnPesquisarCliente.Text = "🔎";
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(638, 62);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(76, 13);
            this.lblDesconto.TabIndex = 111;
            this.lblDesconto.Text = "Desconto (R$)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(641, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 142;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCadastroVenda
            // 
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.listVParcelas);
            this.Controls.Add(this.listVProdutos);
            this.Controls.Add(this.btnPesquisarCondicaoDePagamento);
            this.Controls.Add(this.btnPesquisarProduto);
            this.Controls.Add(this.btnLimparListaProduto);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.btnEditarProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.btnLimparParcelas);
            this.Controls.Add(this.btnGerarParcelas);
            this.Controls.Add(this.btnPesquisarCliente);
            this.Controls.Add(this.btnPesquisarFuncionario);
            this.Controls.Add(this.txtCondicaoDePagamento);
            this.Controls.Add(this.txtValorTotalValores);
            this.Controls.Add(this.txtUnidadeDeMedida);
            this.Controls.Add(this.txtTotalProduto);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtValorUnitario);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblCondicaoDePagamento);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.lblValorTotalValores);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.txtCodCondicaoDePagamento);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.txtCodFuncionario);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFuncionario);
            this.Controls.Add(this.lblTotalProduto);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.txtNumDaNota);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.lblValorTotalParcelas);
            this.Controls.Add(this.lblMotivCancelamentoExplicacao);
            this.Controls.Add(this.lblValorQtdTotalProdutos);
            this.Controls.Add(this.lblValorTotalGeralProdutos);
            this.Controls.Add(this.lblTotalParcelas);
            this.Controls.Add(this.lblMotivoCancelamentoTitulo);
            this.Controls.Add(this.lblQtdTotalProdutos);
            this.Controls.Add(this.lblTotalGeralProdutos);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblUnidadeDeMedida);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblDataEmissao);
            this.Controls.Add(this.lblFuncionario);
            this.Controls.Add(this.lblNumNota);
            this.Controls.Add(this.lblSerie);
            this.Name = "frmCadastroVenda";
            this.Text = "Cadastro de Venda";
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
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.lblNumNota, 0);
            this.Controls.SetChildIndex(this.lblFuncionario, 0);
            this.Controls.SetChildIndex(this.lblDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblCliente, 0);
            this.Controls.SetChildIndex(this.lblProduto, 0);
            this.Controls.SetChildIndex(this.lblQuantidade, 0);
            this.Controls.SetChildIndex(this.lblUnidadeDeMedida, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblTotalGeralProdutos, 0);
            this.Controls.SetChildIndex(this.lblQtdTotalProdutos, 0);
            this.Controls.SetChildIndex(this.lblMotivoCancelamentoTitulo, 0);
            this.Controls.SetChildIndex(this.lblTotalParcelas, 0);
            this.Controls.SetChildIndex(this.lblValorTotalGeralProdutos, 0);
            this.Controls.SetChildIndex(this.lblValorQtdTotalProdutos, 0);
            this.Controls.SetChildIndex(this.lblMotivCancelamentoExplicacao, 0);
            this.Controls.SetChildIndex(this.lblValorTotalParcelas, 0);
            this.Controls.SetChildIndex(this.lblPrecoVenda, 0);
            this.Controls.SetChildIndex(this.txtNumDaNota, 0);
            this.Controls.SetChildIndex(this.lblDesconto, 0);
            this.Controls.SetChildIndex(this.lblTotalProduto, 0);
            this.Controls.SetChildIndex(this.txtFuncionario, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.txtCodFuncionario, 0);
            this.Controls.SetChildIndex(this.txtCodCliente, 0);
            this.Controls.SetChildIndex(this.txtCodCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.txtCodProduto, 0);
            this.Controls.SetChildIndex(this.lblValorTotalValores, 0);
            this.Controls.SetChildIndex(this.txtProduto, 0);
            this.Controls.SetChildIndex(this.lblCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.txtQuantidade, 0);
            this.Controls.SetChildIndex(this.txtValorUnitario, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.txtTotalProduto, 0);
            this.Controls.SetChildIndex(this.txtUnidadeDeMedida, 0);
            this.Controls.SetChildIndex(this.txtValorTotalValores, 0);
            this.Controls.SetChildIndex(this.txtCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFuncionario, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCliente, 0);
            this.Controls.SetChildIndex(this.btnGerarParcelas, 0);
            this.Controls.SetChildIndex(this.btnLimparParcelas, 0);
            this.Controls.SetChildIndex(this.btnAdicionarProduto, 0);
            this.Controls.SetChildIndex(this.btnEditarProduto, 0);
            this.Controls.SetChildIndex(this.btnRemoverProduto, 0);
            this.Controls.SetChildIndex(this.btnLimparListaProduto, 0);
            this.Controls.SetChildIndex(this.btnPesquisarProduto, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.listVProdutos, 0);
            this.Controls.SetChildIndex(this.listVParcelas, 0);
            this.Controls.SetChildIndex(this.dtpDataEmissao, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDataEmissao;
        private System.Windows.Forms.ListView listVParcelas;
        private System.Windows.Forms.ColumnHeader clmNumParcela;
        private System.Windows.Forms.ColumnHeader clmDataEmissao;
        private System.Windows.Forms.ColumnHeader clmDataVencimento;
        private System.Windows.Forms.ColumnHeader clmValorParcela;
        private System.Windows.Forms.ColumnHeader clmFormaPagamento;
        private System.Windows.Forms.ListView listVProdutos;
        private System.Windows.Forms.ColumnHeader clmCodProduto;
        private System.Windows.Forms.ColumnHeader clmProduto;
        private System.Windows.Forms.ColumnHeader clmUnMedida;
        private System.Windows.Forms.ColumnHeader clmQtd;
        private System.Windows.Forms.ColumnHeader clmValorUnitario;
        private System.Windows.Forms.ColumnHeader clmTotal;
        private System.Windows.Forms.Button btnPesquisarCondicaoDePagamento;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.Button btnLimparListaProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Button btnLimparParcelas;
        private System.Windows.Forms.Button btnGerarParcelas;
        private System.Windows.Forms.Button btnPesquisarFuncionario;
        private System.Windows.Forms.TextBox txtCondicaoDePagamento;
        private System.Windows.Forms.TextBox txtValorTotalValores;
        private System.Windows.Forms.TextBox txtUnidadeDeMedida;
        private System.Windows.Forms.TextBox txtTotalProduto;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblCondicaoDePagamento;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label lblValorTotalValores;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.TextBox txtCodCondicaoDePagamento;
        private System.Windows.Forms.TextBox txtCodFuncionario;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.Label lblTotalProduto;
        private System.Windows.Forms.TextBox txtNumDaNota;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.Label lblValorTotalParcelas;
        private System.Windows.Forms.Label lblMotivCancelamentoExplicacao;
        private System.Windows.Forms.Label lblValorQtdTotalProdutos;
        private System.Windows.Forms.Label lblValorTotalGeralProdutos;
        private System.Windows.Forms.Label lblTotalParcelas;
        private System.Windows.Forms.Label lblMotivoCancelamentoTitulo;
        private System.Windows.Forms.Label lblQtdTotalProdutos;
        private System.Windows.Forms.Label lblTotalGeralProdutos;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblUnidadeDeMedida;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.Label lblNumNota;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Button btnPesquisarCliente;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.TextBox textBox1;
    }
}

namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroCompra
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
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblNumNota = new System.Windows.Forms.Label();
            this.txtNumDaNota = new System.Windows.Forms.TextBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.btnPesquisarFornecedor = new System.Windows.Forms.Button();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblDataEntrega = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.lblTotalProduto = new System.Windows.Forms.Label();
            this.txtTotalProduto = new System.Windows.Forms.TextBox();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.lblValorFrete = new System.Windows.Forms.Label();
            this.lblSeguro = new System.Windows.Forms.Label();
            this.lblDespesas = new System.Windows.Forms.Label();
            this.txtValorFrete = new System.Windows.Forms.TextBox();
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.txtDespesas = new System.Windows.Forms.TextBox();
            this.lblValorTotalValores = new System.Windows.Forms.Label();
            this.txtValorTotalValores = new System.Windows.Forms.TextBox();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.listVProdutos = new System.Windows.Forms.ListView();
            this.clmCodProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmQtd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCondicaoDePagamento = new System.Windows.Forms.Label();
            this.txtCondicaoDePagamento = new System.Windows.Forms.TextBox();
            this.btnGerarParcelas = new System.Windows.Forms.Button();
            this.btnLimparParcelas = new System.Windows.Forms.Button();
            this.btnLimparListaProduto = new System.Windows.Forms.Button();
            this.listVParcelas = new System.Windows.Forms.ListView();
            this.clmNumParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataVencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.lblTotalGeralProdutos = new System.Windows.Forms.Label();
            this.lblValorTotalGeralProdutos = new System.Windows.Forms.Label();
            this.btnPesquisarCondicaoDePagamento = new System.Windows.Forms.Button();
            this.txtCodFornecedor = new System.Windows.Forms.TextBox();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.txtCodCondicaoDePagamento = new System.Windows.Forms.TextBox();
            this.lblTotalParcelas = new System.Windows.Forms.Label();
            this.lblValorTotalParcelas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1143, 634);
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(13, 13);
            this.lblCod.Size = new System.Drawing.Size(49, 13);
            this.lblCod.Text = "Modelo *";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.Location = new System.Drawing.Point(13, 624);
            // 
            // lblDataUltimaEdicao
            // 
            this.lblDataUltimaEdicao.Location = new System.Drawing.Point(13, 640);
            // 
            // lblUltimoUsuarioQueEditou
            // 
            this.lblUltimoUsuarioQueEditou.Location = new System.Drawing.Point(13, 656);
            // 
            // lblDataCadastroData
            // 
            this.lblDataCadastroData.Location = new System.Drawing.Point(135, 624);
            // 
            // lblDataUltimaEdicaoData
            // 
            this.lblDataUltimaEdicaoData.Location = new System.Drawing.Point(164, 640);
            // 
            // lblUltimoUsuarioQueEditouNome
            // 
            this.lblUltimoUsuarioQueEditouNome.Location = new System.Drawing.Point(184, 656);
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.Location = new System.Drawing.Point(1266, 14);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1236, 634);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = true;
            this.txtCodigo.Location = new System.Drawing.Point(16, 32);
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.ShortcutsEnabled = false;
            this.txtCodigo.Size = new System.Drawing.Size(58, 20);
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(94, 15);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(38, 13);
            this.lblSerie.TabIndex = 101;
            this.lblSerie.Text = "Série *";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(97, 33);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ShortcutsEnabled = false;
            this.txtSerie.Size = new System.Drawing.Size(46, 20);
            this.txtSerie.TabIndex = 102;
            // 
            // lblNumNota
            // 
            this.lblNumNota.AutoSize = true;
            this.lblNumNota.Location = new System.Drawing.Point(169, 14);
            this.lblNumNota.Name = "lblNumNota";
            this.lblNumNota.Size = new System.Drawing.Size(80, 13);
            this.lblNumNota.TabIndex = 101;
            this.lblNumNota.Text = "Núm. da Nota *";
            // 
            // txtNumDaNota
            // 
            this.txtNumDaNota.Location = new System.Drawing.Point(172, 32);
            this.txtNumDaNota.Name = "txtNumDaNota";
            this.txtNumDaNota.ShortcutsEnabled = false;
            this.txtNumDaNota.Size = new System.Drawing.Size(129, 20);
            this.txtNumDaNota.TabIndex = 102;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(324, 13);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(68, 13);
            this.lblFornecedor.TabIndex = 101;
            this.lblFornecedor.Text = "Fornecedor *";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(393, 32);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.ShortcutsEnabled = false;
            this.txtFornecedor.Size = new System.Drawing.Size(214, 20);
            this.txtFornecedor.TabIndex = 102;
            // 
            // btnPesquisarFornecedor
            // 
            this.btnPesquisarFornecedor.Location = new System.Drawing.Point(613, 32);
            this.btnPesquisarFornecedor.Name = "btnPesquisarFornecedor";
            this.btnPesquisarFornecedor.Size = new System.Drawing.Size(39, 25);
            this.btnPesquisarFornecedor.TabIndex = 103;
            this.btnPesquisarFornecedor.Text = "🔎";
            this.btnPesquisarFornecedor.UseVisualStyleBackColor = true;
            this.btnPesquisarFornecedor.Click += new System.EventHandler(this.btnPesquisarFornecedor_Click);
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.AutoSize = true;
            this.lblDataEmissao.Location = new System.Drawing.Point(673, 15);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(94, 13);
            this.lblDataEmissao.TabIndex = 101;
            this.lblDataEmissao.Text = "Data de Emissão *";
            // 
            // lblDataEntrega
            // 
            this.lblDataEntrega.AutoSize = true;
            this.lblDataEntrega.Location = new System.Drawing.Point(806, 15);
            this.lblDataEntrega.Name = "lblDataEntrega";
            this.lblDataEntrega.Size = new System.Drawing.Size(92, 13);
            this.lblDataEntrega.TabIndex = 101;
            this.lblDataEntrega.Text = "Data de Entrega *";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(13, 61);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(51, 13);
            this.lblProduto.TabIndex = 101;
            this.lblProduto.Text = "Produto *";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(82, 80);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.ShortcutsEnabled = false;
            this.txtProduto.Size = new System.Drawing.Size(207, 20);
            this.txtProduto.TabIndex = 102;
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Location = new System.Drawing.Point(295, 80);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(39, 23);
            this.btnPesquisarProduto.TabIndex = 103;
            this.btnPesquisarProduto.Text = "🔎";
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisarProduto_Click);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(349, 62);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 101;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(352, 80);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ShortcutsEnabled = false;
            this.txtQuantidade.Size = new System.Drawing.Size(74, 20);
            this.txtQuantidade.TabIndex = 102;
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Location = new System.Drawing.Point(440, 61);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(93, 13);
            this.lblValorUnitario.TabIndex = 101;
            this.lblValorUnitario.Text = "Valor Unitário (R$)";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(443, 79);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.ShortcutsEnabled = false;
            this.txtValorUnitario.Size = new System.Drawing.Size(88, 20);
            this.txtValorUnitario.TabIndex = 102;
            this.txtValorUnitario.Leave += new System.EventHandler(this.txtValorUnitario_Leave);
            // 
            // lblTotalProduto
            // 
            this.lblTotalProduto.AutoSize = true;
            this.lblTotalProduto.Location = new System.Drawing.Point(549, 62);
            this.lblTotalProduto.Name = "lblTotalProduto";
            this.lblTotalProduto.Size = new System.Drawing.Size(54, 13);
            this.lblTotalProduto.TabIndex = 101;
            this.lblTotalProduto.Text = "Total (R$)";
            // 
            // txtTotalProduto
            // 
            this.txtTotalProduto.Location = new System.Drawing.Point(552, 80);
            this.txtTotalProduto.Name = "txtTotalProduto";
            this.txtTotalProduto.ReadOnly = true;
            this.txtTotalProduto.ShortcutsEnabled = false;
            this.txtTotalProduto.Size = new System.Drawing.Size(100, 20);
            this.txtTotalProduto.TabIndex = 102;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(676, 78);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(74, 23);
            this.btnAdicionarProduto.TabIndex = 103;
            this.btnAdicionarProduto.Text = "Adicionar ";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // lblValorFrete
            // 
            this.lblValorFrete.AutoSize = true;
            this.lblValorFrete.Location = new System.Drawing.Point(9, 348);
            this.lblValorFrete.Name = "lblValorFrete";
            this.lblValorFrete.Size = new System.Drawing.Size(81, 13);
            this.lblValorFrete.TabIndex = 101;
            this.lblValorFrete.Text = "Valor Frete (R$)";
            // 
            // lblSeguro
            // 
            this.lblSeguro.AutoSize = true;
            this.lblSeguro.Location = new System.Drawing.Point(141, 350);
            this.lblSeguro.Name = "lblSeguro";
            this.lblSeguro.Size = new System.Drawing.Size(64, 13);
            this.lblSeguro.TabIndex = 101;
            this.lblSeguro.Text = "Seguro (R$)";
            // 
            // lblDespesas
            // 
            this.lblDespesas.AutoSize = true;
            this.lblDespesas.Location = new System.Drawing.Point(278, 350);
            this.lblDespesas.Name = "lblDespesas";
            this.lblDespesas.Size = new System.Drawing.Size(77, 13);
            this.lblDespesas.TabIndex = 101;
            this.lblDespesas.Text = "Despesas (R$)";
            // 
            // txtValorFrete
            // 
            this.txtValorFrete.Location = new System.Drawing.Point(12, 368);
            this.txtValorFrete.Name = "txtValorFrete";
            this.txtValorFrete.ShortcutsEnabled = false;
            this.txtValorFrete.Size = new System.Drawing.Size(113, 20);
            this.txtValorFrete.TabIndex = 102;
            this.txtValorFrete.Leave += new System.EventHandler(this.txtValorFrete_Leave);
            // 
            // txtSeguro
            // 
            this.txtSeguro.Location = new System.Drawing.Point(144, 368);
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.ShortcutsEnabled = false;
            this.txtSeguro.Size = new System.Drawing.Size(113, 20);
            this.txtSeguro.TabIndex = 102;
            this.txtSeguro.Leave += new System.EventHandler(this.txtSeguro_Leave);
            // 
            // txtDespesas
            // 
            this.txtDespesas.Location = new System.Drawing.Point(281, 368);
            this.txtDespesas.Name = "txtDespesas";
            this.txtDespesas.ShortcutsEnabled = false;
            this.txtDespesas.Size = new System.Drawing.Size(120, 20);
            this.txtDespesas.TabIndex = 102;
            this.txtDespesas.Leave += new System.EventHandler(this.txtDespesas_Leave);
            // 
            // lblValorTotalValores
            // 
            this.lblValorTotalValores.AutoSize = true;
            this.lblValorTotalValores.Location = new System.Drawing.Point(422, 350);
            this.lblValorTotalValores.Name = "lblValorTotalValores";
            this.lblValorTotalValores.Size = new System.Drawing.Size(81, 13);
            this.lblValorTotalValores.TabIndex = 101;
            this.lblValorTotalValores.Text = "Valor Total (R$)";
            // 
            // txtValorTotalValores
            // 
            this.txtValorTotalValores.Location = new System.Drawing.Point(425, 368);
            this.txtValorTotalValores.Name = "txtValorTotalValores";
            this.txtValorTotalValores.ReadOnly = true;
            this.txtValorTotalValores.ShortcutsEnabled = false;
            this.txtValorTotalValores.Size = new System.Drawing.Size(138, 20);
            this.txtValorTotalValores.TabIndex = 102;
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.Location = new System.Drawing.Point(756, 78);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(76, 23);
            this.btnEditarProduto.TabIndex = 103;
            this.btnEditarProduto.Text = "Editar";
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(838, 78);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverProduto.TabIndex = 103;
            this.btnRemoverProduto.Text = "Remover";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // listVProdutos
            // 
            this.listVProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCodProduto,
            this.clmProduto,
            this.clmQtd,
            this.clmValorUnitario,
            this.clmTotal});
            this.listVProdutos.FullRowSelect = true;
            this.listVProdutos.GridLines = true;
            this.listVProdutos.HideSelection = false;
            this.listVProdutos.Location = new System.Drawing.Point(16, 109);
            this.listVProdutos.Name = "listVProdutos";
            this.listVProdutos.Size = new System.Drawing.Size(1300, 227);
            this.listVProdutos.TabIndex = 104;
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
            // clmQtd
            // 
            this.clmQtd.Text = "Quantidade";
            this.clmQtd.Width = 120;
            // 
            // clmValorUnitario
            // 
            this.clmValorUnitario.Text = "Valor Unitário";
            this.clmValorUnitario.Width = 120;
            // 
            // clmTotal
            // 
            this.clmTotal.Text = "Total";
            this.clmTotal.Width = 120;
            // 
            // lblCondicaoDePagamento
            // 
            this.lblCondicaoDePagamento.AutoSize = true;
            this.lblCondicaoDePagamento.Location = new System.Drawing.Point(9, 398);
            this.lblCondicaoDePagamento.Name = "lblCondicaoDePagamento";
            this.lblCondicaoDePagamento.Size = new System.Drawing.Size(131, 13);
            this.lblCondicaoDePagamento.TabIndex = 101;
            this.lblCondicaoDePagamento.Text = "Condição de Pagamento *";
            // 
            // txtCondicaoDePagamento
            // 
            this.txtCondicaoDePagamento.Location = new System.Drawing.Point(78, 416);
            this.txtCondicaoDePagamento.Name = "txtCondicaoDePagamento";
            this.txtCondicaoDePagamento.ReadOnly = true;
            this.txtCondicaoDePagamento.ShortcutsEnabled = false;
            this.txtCondicaoDePagamento.Size = new System.Drawing.Size(234, 20);
            this.txtCondicaoDePagamento.TabIndex = 102;
            // 
            // btnGerarParcelas
            // 
            this.btnGerarParcelas.Location = new System.Drawing.Point(367, 412);
            this.btnGerarParcelas.Name = "btnGerarParcelas";
            this.btnGerarParcelas.Size = new System.Drawing.Size(112, 23);
            this.btnGerarParcelas.TabIndex = 103;
            this.btnGerarParcelas.Text = "Gerar Parcelas";
            this.btnGerarParcelas.UseVisualStyleBackColor = true;
            this.btnGerarParcelas.Click += new System.EventHandler(this.btnGerarParcelas_Click);
            // 
            // btnLimparParcelas
            // 
            this.btnLimparParcelas.Location = new System.Drawing.Point(485, 412);
            this.btnLimparParcelas.Name = "btnLimparParcelas";
            this.btnLimparParcelas.Size = new System.Drawing.Size(122, 23);
            this.btnLimparParcelas.TabIndex = 103;
            this.btnLimparParcelas.Text = "Limpar Parcelas";
            this.btnLimparParcelas.UseVisualStyleBackColor = true;
            this.btnLimparParcelas.Click += new System.EventHandler(this.btnLimparParcelas_Click);
            // 
            // btnLimparListaProduto
            // 
            this.btnLimparListaProduto.Location = new System.Drawing.Point(919, 78);
            this.btnLimparListaProduto.Name = "btnLimparListaProduto";
            this.btnLimparListaProduto.Size = new System.Drawing.Size(98, 23);
            this.btnLimparListaProduto.TabIndex = 103;
            this.btnLimparListaProduto.Text = "Limpar Lista";
            this.btnLimparListaProduto.UseVisualStyleBackColor = true;
            this.btnLimparListaProduto.Click += new System.EventHandler(this.btnLimparListaProduto_Click);
            // 
            // listVParcelas
            // 
            this.listVParcelas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNumParcela,
            this.clmDataVencimento,
            this.clmValorParcela});
            this.listVParcelas.FullRowSelect = true;
            this.listVParcelas.GridLines = true;
            this.listVParcelas.HideSelection = false;
            this.listVParcelas.Location = new System.Drawing.Point(12, 444);
            this.listVParcelas.Name = "listVParcelas";
            this.listVParcelas.Size = new System.Drawing.Size(1304, 168);
            this.listVParcelas.TabIndex = 104;
            this.listVParcelas.UseCompatibleStateImageBehavior = false;
            this.listVParcelas.View = System.Windows.Forms.View.Details;
            // 
            // clmNumParcela
            // 
            this.clmNumParcela.Text = "Num. Parcela";
            this.clmNumParcela.Width = 120;
            // 
            // clmDataVencimento
            // 
            this.clmDataVencimento.Text = "Data de Vencimento";
            this.clmDataVencimento.Width = 120;
            // 
            // clmValorParcela
            // 
            this.clmValorParcela.Text = "Valor Parcela";
            this.clmValorParcela.Width = 120;
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.Location = new System.Drawing.Point(810, 33);
            this.dtpDataEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(109, 20);
            this.dtpDataEntrega.TabIndex = 105;
            this.dtpDataEntrega.ValueChanged += new System.EventHandler(this.dtpDataEmissao_ValueChanged);
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(677, 33);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(115, 20);
            this.dtpDataEmissao.TabIndex = 106;
            // 
            // lblTotalGeralProdutos
            // 
            this.lblTotalGeralProdutos.AutoSize = true;
            this.lblTotalGeralProdutos.Location = new System.Drawing.Point(916, 339);
            this.lblTotalGeralProdutos.Name = "lblTotalGeralProdutos";
            this.lblTotalGeralProdutos.Size = new System.Drawing.Size(130, 13);
            this.lblTotalGeralProdutos.TabIndex = 101;
            this.lblTotalGeralProdutos.Text = "Total Geral Produtos (R$):";
            // 
            // lblValorTotalGeralProdutos
            // 
            this.lblValorTotalGeralProdutos.AutoSize = true;
            this.lblValorTotalGeralProdutos.Location = new System.Drawing.Point(1078, 339);
            this.lblValorTotalGeralProdutos.Name = "lblValorTotalGeralProdutos";
            this.lblValorTotalGeralProdutos.Size = new System.Drawing.Size(13, 13);
            this.lblValorTotalGeralProdutos.TabIndex = 101;
            this.lblValorTotalGeralProdutos.Text = "0";
            // 
            // btnPesquisarCondicaoDePagamento
            // 
            this.btnPesquisarCondicaoDePagamento.Location = new System.Drawing.Point(318, 415);
            this.btnPesquisarCondicaoDePagamento.Name = "btnPesquisarCondicaoDePagamento";
            this.btnPesquisarCondicaoDePagamento.Size = new System.Drawing.Size(39, 23);
            this.btnPesquisarCondicaoDePagamento.TabIndex = 103;
            this.btnPesquisarCondicaoDePagamento.Text = "🔎";
            this.btnPesquisarCondicaoDePagamento.UseVisualStyleBackColor = true;
            this.btnPesquisarCondicaoDePagamento.Click += new System.EventHandler(this.btnPesquisarCondicaoDePagamento_Click);
            // 
            // txtCodFornecedor
            // 
            this.txtCodFornecedor.Location = new System.Drawing.Point(327, 33);
            this.txtCodFornecedor.Name = "txtCodFornecedor";
            this.txtCodFornecedor.ReadOnly = true;
            this.txtCodFornecedor.ShortcutsEnabled = false;
            this.txtCodFornecedor.Size = new System.Drawing.Size(60, 20);
            this.txtCodFornecedor.TabIndex = 102;
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(16, 80);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.ReadOnly = true;
            this.txtCodProduto.ShortcutsEnabled = false;
            this.txtCodProduto.Size = new System.Drawing.Size(60, 20);
            this.txtCodProduto.TabIndex = 102;
            // 
            // txtCodCondicaoDePagamento
            // 
            this.txtCodCondicaoDePagamento.Location = new System.Drawing.Point(12, 415);
            this.txtCodCondicaoDePagamento.Name = "txtCodCondicaoDePagamento";
            this.txtCodCondicaoDePagamento.ReadOnly = true;
            this.txtCodCondicaoDePagamento.ShortcutsEnabled = false;
            this.txtCodCondicaoDePagamento.Size = new System.Drawing.Size(60, 20);
            this.txtCodCondicaoDePagamento.TabIndex = 102;
            // 
            // lblTotalParcelas
            // 
            this.lblTotalParcelas.AutoSize = true;
            this.lblTotalParcelas.Location = new System.Drawing.Point(916, 615);
            this.lblTotalParcelas.Name = "lblTotalParcelas";
            this.lblTotalParcelas.Size = new System.Drawing.Size(101, 13);
            this.lblTotalParcelas.TabIndex = 101;
            this.lblTotalParcelas.Text = "Total Parcelas (R$):";
            // 
            // lblValorTotalParcelas
            // 
            this.lblValorTotalParcelas.AutoSize = true;
            this.lblValorTotalParcelas.Location = new System.Drawing.Point(1078, 615);
            this.lblValorTotalParcelas.Name = "lblValorTotalParcelas";
            this.lblValorTotalParcelas.Size = new System.Drawing.Size(13, 13);
            this.lblValorTotalParcelas.TabIndex = 101;
            this.lblValorTotalParcelas.Text = "0";
            // 
            // frmCadastroCompra
            // 
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.dtpDataEntrega);
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
            this.Controls.Add(this.btnPesquisarFornecedor);
            this.Controls.Add(this.txtCondicaoDePagamento);
            this.Controls.Add(this.txtValorTotalValores);
            this.Controls.Add(this.txtDespesas);
            this.Controls.Add(this.txtTotalProduto);
            this.Controls.Add(this.txtSeguro);
            this.Controls.Add(this.txtValorUnitario);
            this.Controls.Add(this.txtValorFrete);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblCondicaoDePagamento);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.lblValorTotalValores);
            this.Controls.Add(this.lblDespesas);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.txtCodCondicaoDePagamento);
            this.Controls.Add(this.txtCodFornecedor);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblTotalProduto);
            this.Controls.Add(this.lblSeguro);
            this.Controls.Add(this.txtNumDaNota);
            this.Controls.Add(this.lblValorUnitario);
            this.Controls.Add(this.lblValorTotalParcelas);
            this.Controls.Add(this.lblValorTotalGeralProdutos);
            this.Controls.Add(this.lblTotalParcelas);
            this.Controls.Add(this.lblTotalGeralProdutos);
            this.Controls.Add(this.lblValorFrete);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.lblDataEntrega);
            this.Controls.Add(this.lblDataEmissao);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.lblNumNota);
            this.Controls.Add(this.lblSerie);
            this.Name = "frmCadastroCompra";
            this.Text = "Cadastro de Compra";
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.lblNumNota, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.lblDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblDataEntrega, 0);
            this.Controls.SetChildIndex(this.lblProduto, 0);
            this.Controls.SetChildIndex(this.lblQuantidade, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblValorFrete, 0);
            this.Controls.SetChildIndex(this.lblTotalGeralProdutos, 0);
            this.Controls.SetChildIndex(this.lblTotalParcelas, 0);
            this.Controls.SetChildIndex(this.lblValorTotalGeralProdutos, 0);
            this.Controls.SetChildIndex(this.lblValorTotalParcelas, 0);
            this.Controls.SetChildIndex(this.lblValorUnitario, 0);
            this.Controls.SetChildIndex(this.txtNumDaNota, 0);
            this.Controls.SetChildIndex(this.lblSeguro, 0);
            this.Controls.SetChildIndex(this.lblTotalProduto, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.txtCodFornecedor, 0);
            this.Controls.SetChildIndex(this.txtCodCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.txtCodProduto, 0);
            this.Controls.SetChildIndex(this.lblDespesas, 0);
            this.Controls.SetChildIndex(this.lblValorTotalValores, 0);
            this.Controls.SetChildIndex(this.txtProduto, 0);
            this.Controls.SetChildIndex(this.lblCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.txtQuantidade, 0);
            this.Controls.SetChildIndex(this.txtValorFrete, 0);
            this.Controls.SetChildIndex(this.txtValorUnitario, 0);
            this.Controls.SetChildIndex(this.txtSeguro, 0);
            this.Controls.SetChildIndex(this.txtTotalProduto, 0);
            this.Controls.SetChildIndex(this.txtDespesas, 0);
            this.Controls.SetChildIndex(this.txtValorTotalValores, 0);
            this.Controls.SetChildIndex(this.txtCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFornecedor, 0);
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
            this.Controls.SetChildIndex(this.dtpDataEntrega, 0);
            this.Controls.SetChildIndex(this.dtpDataEmissao, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblNumNota;
        private System.Windows.Forms.TextBox txtNumDaNota;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnPesquisarFornecedor;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblDataEntrega;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label lblTotalProduto;
        private System.Windows.Forms.TextBox txtTotalProduto;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Label lblValorFrete;
        private System.Windows.Forms.Label lblSeguro;
        private System.Windows.Forms.Label lblDespesas;
        private System.Windows.Forms.TextBox txtValorFrete;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.TextBox txtDespesas;
        private System.Windows.Forms.Label lblValorTotalValores;
        private System.Windows.Forms.TextBox txtValorTotalValores;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.ListView listVProdutos;
        private System.Windows.Forms.Label lblCondicaoDePagamento;
        private System.Windows.Forms.TextBox txtCondicaoDePagamento;
        private System.Windows.Forms.Button btnGerarParcelas;
        private System.Windows.Forms.Button btnLimparParcelas;
        private System.Windows.Forms.Button btnLimparListaProduto;
        private System.Windows.Forms.ListView listVParcelas;
        private System.Windows.Forms.DateTimePicker dtpDataEntrega;
        private System.Windows.Forms.DateTimePicker dtpDataEmissao;
        private System.Windows.Forms.Label lblTotalGeralProdutos;
        private System.Windows.Forms.Label lblValorTotalGeralProdutos;
        private System.Windows.Forms.Button btnPesquisarCondicaoDePagamento;
        private System.Windows.Forms.TextBox txtCodFornecedor;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.TextBox txtCodCondicaoDePagamento;
        private System.Windows.Forms.ColumnHeader clmCodProduto;
        private System.Windows.Forms.ColumnHeader clmProduto;
        private System.Windows.Forms.ColumnHeader clmQtd;
        private System.Windows.Forms.ColumnHeader clmValorUnitario;
        private System.Windows.Forms.ColumnHeader clmTotal;
        private System.Windows.Forms.ColumnHeader clmNumParcela;
        private System.Windows.Forms.ColumnHeader clmDataVencimento;
        private System.Windows.Forms.ColumnHeader clmValorParcela;
        private System.Windows.Forms.Label lblTotalParcelas;
        private System.Windows.Forms.Label lblValorTotalParcelas;
    }
}

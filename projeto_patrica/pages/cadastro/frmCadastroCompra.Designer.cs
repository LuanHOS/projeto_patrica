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
            this.lblInformacoes = new System.Windows.Forms.Label();
            this.lblListaDeProdutos = new System.Windows.Forms.Label();
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
            this.lblCondicaoDePagamento = new System.Windows.Forms.Label();
            this.txtCondicaoDePagamento = new System.Windows.Forms.TextBox();
            this.btnGerarParcelas = new System.Windows.Forms.Button();
            this.btnLimparParcelas = new System.Windows.Forms.Button();
            this.btnLimparListaProduto = new System.Windows.Forms.Button();
            this.listVParcelas = new System.Windows.Forms.ListView();
            this.lblCondicaoDePagamentolbl = new System.Windows.Forms.Label();
            this.lblValores = new System.Windows.Forms.Label();
            this.dtpDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.lblTotalGeralProdutos = new System.Windows.Forms.Label();
            this.lblValorTotalGeralProdutos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1159, 634);
            // 
            // lblCod
            // 
            this.lblCod.Size = new System.Drawing.Size(61, 16);
            this.lblCod.Text = "Modelo *";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.Location = new System.Drawing.Point(21, 621);
            // 
            // lblDataUltimaEdicao
            // 
            this.lblDataUltimaEdicao.Location = new System.Drawing.Point(21, 637);
            // 
            // lblUltimoUsuarioQueEditou
            // 
            this.lblUltimoUsuarioQueEditou.Location = new System.Drawing.Point(21, 653);
            // 
            // lblDataCadastroData
            // 
            this.lblDataCadastroData.Location = new System.Drawing.Point(143, 621);
            // 
            // lblDataUltimaEdicaoData
            // 
            this.lblDataUltimaEdicaoData.Location = new System.Drawing.Point(172, 637);
            // 
            // lblUltimoUsuarioQueEditouNome
            // 
            this.lblUltimoUsuarioQueEditouNome.Location = new System.Drawing.Point(192, 653);
            // 
            // checkBoxAtivo
            // 
            this.checkBoxAtivo.Location = new System.Drawing.Point(1271, 9);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1252, 634);
            // 
            // txtCodigo
            // 
            this.txtCodigo.ShortcutsEnabled = false;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(172, 27);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(47, 16);
            this.lblSerie.TabIndex = 101;
            this.lblSerie.Text = "Série *";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(175, 45);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ShortcutsEnabled = false;
            this.txtSerie.Size = new System.Drawing.Size(100, 22);
            this.txtSerie.TabIndex = 102;
            // 
            // lblNumNota
            // 
            this.lblNumNota.AutoSize = true;
            this.lblNumNota.Location = new System.Drawing.Point(281, 27);
            this.lblNumNota.Name = "lblNumNota";
            this.lblNumNota.Size = new System.Drawing.Size(89, 16);
            this.lblNumNota.TabIndex = 101;
            this.lblNumNota.Text = "Núm. da Nota";
            // 
            // txtNumDaNota
            // 
            this.txtNumDaNota.Location = new System.Drawing.Point(284, 45);
            this.txtNumDaNota.Name = "txtNumDaNota";
            this.txtNumDaNota.ShortcutsEnabled = false;
            this.txtNumDaNota.Size = new System.Drawing.Size(100, 22);
            this.txtNumDaNota.TabIndex = 102;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(394, 27);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(85, 16);
            this.lblFornecedor.TabIndex = 101;
            this.lblFornecedor.Text = "Fornecedor *";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(397, 45);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ShortcutsEnabled = false;
            this.txtFornecedor.Size = new System.Drawing.Size(100, 22);
            this.txtFornecedor.TabIndex = 102;
            // 
            // btnPesquisarFornecedor
            // 
            this.btnPesquisarFornecedor.Location = new System.Drawing.Point(504, 46);
            this.btnPesquisarFornecedor.Name = "btnPesquisarFornecedor";
            this.btnPesquisarFornecedor.Size = new System.Drawing.Size(87, 23);
            this.btnPesquisarFornecedor.TabIndex = 103;
            this.btnPesquisarFornecedor.Text = "Pesquisar";
            this.btnPesquisarFornecedor.UseVisualStyleBackColor = true;
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.AutoSize = true;
            this.lblDataEmissao.Location = new System.Drawing.Point(21, 82);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(119, 16);
            this.lblDataEmissao.TabIndex = 101;
            this.lblDataEmissao.Text = "Data de Emissão *";
            // 
            // lblDataEntrega
            // 
            this.lblDataEntrega.AutoSize = true;
            this.lblDataEntrega.Location = new System.Drawing.Point(208, 82);
            this.lblDataEntrega.Name = "lblDataEntrega";
            this.lblDataEntrega.Size = new System.Drawing.Size(113, 16);
            this.lblDataEntrega.TabIndex = 101;
            this.lblDataEntrega.Text = "Data de Entrega *";
            // 
            // lblInformacoes
            // 
            this.lblInformacoes.AutoSize = true;
            this.lblInformacoes.Location = new System.Drawing.Point(21, 9);
            this.lblInformacoes.Name = "lblInformacoes";
            this.lblInformacoes.Size = new System.Drawing.Size(81, 16);
            this.lblInformacoes.TabIndex = 101;
            this.lblInformacoes.Text = "Informações";
            // 
            // lblListaDeProdutos
            // 
            this.lblListaDeProdutos.AutoSize = true;
            this.lblListaDeProdutos.Location = new System.Drawing.Point(21, 135);
            this.lblListaDeProdutos.Name = "lblListaDeProdutos";
            this.lblListaDeProdutos.Size = new System.Drawing.Size(111, 16);
            this.lblListaDeProdutos.TabIndex = 101;
            this.lblListaDeProdutos.Text = "Lista de Produtos";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(21, 158);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(62, 16);
            this.lblProduto.TabIndex = 101;
            this.lblProduto.Text = "Produto *";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(24, 176);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ShortcutsEnabled = false;
            this.txtProduto.Size = new System.Drawing.Size(100, 22);
            this.txtProduto.TabIndex = 102;
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Location = new System.Drawing.Point(130, 176);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(89, 23);
            this.btnPesquisarProduto.TabIndex = 103;
            this.btnPesquisarProduto.Text = "Pesquisar";
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(21, 212);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(77, 16);
            this.lblQuantidade.TabIndex = 101;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(24, 230);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ShortcutsEnabled = false;
            this.txtQuantidade.Size = new System.Drawing.Size(100, 22);
            this.txtQuantidade.TabIndex = 102;
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Location = new System.Drawing.Point(127, 212);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(88, 16);
            this.lblValorUnitario.TabIndex = 101;
            this.lblValorUnitario.Text = "Valor Unitário";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(130, 230);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.ShortcutsEnabled = false;
            this.txtValorUnitario.Size = new System.Drawing.Size(100, 22);
            this.txtValorUnitario.TabIndex = 102;
            // 
            // lblTotalProduto
            // 
            this.lblTotalProduto.AutoSize = true;
            this.lblTotalProduto.Location = new System.Drawing.Point(233, 212);
            this.lblTotalProduto.Name = "lblTotalProduto";
            this.lblTotalProduto.Size = new System.Drawing.Size(66, 16);
            this.lblTotalProduto.TabIndex = 101;
            this.lblTotalProduto.Text = "Total (R$)";
            // 
            // txtTotalProduto
            // 
            this.txtTotalProduto.Location = new System.Drawing.Point(236, 230);
            this.txtTotalProduto.Name = "txtTotalProduto";
            this.txtTotalProduto.ShortcutsEnabled = false;
            this.txtTotalProduto.Size = new System.Drawing.Size(100, 22);
            this.txtTotalProduto.TabIndex = 102;
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(342, 229);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(74, 23);
            this.btnAdicionarProduto.TabIndex = 103;
            this.btnAdicionarProduto.Text = "Adicionar ";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            // 
            // lblValorFrete
            // 
            this.lblValorFrete.AutoSize = true;
            this.lblValorFrete.Location = new System.Drawing.Point(21, 406);
            this.lblValorFrete.Name = "lblValorFrete";
            this.lblValorFrete.Size = new System.Drawing.Size(101, 16);
            this.lblValorFrete.TabIndex = 101;
            this.lblValorFrete.Text = "Valor Frete (R$)";
            // 
            // lblSeguro
            // 
            this.lblSeguro.AutoSize = true;
            this.lblSeguro.Location = new System.Drawing.Point(127, 406);
            this.lblSeguro.Name = "lblSeguro";
            this.lblSeguro.Size = new System.Drawing.Size(79, 16);
            this.lblSeguro.TabIndex = 101;
            this.lblSeguro.Text = "Seguro (R$)";
            // 
            // lblDespesas
            // 
            this.lblDespesas.AutoSize = true;
            this.lblDespesas.Location = new System.Drawing.Point(233, 406);
            this.lblDespesas.Name = "lblDespesas";
            this.lblDespesas.Size = new System.Drawing.Size(98, 16);
            this.lblDespesas.TabIndex = 101;
            this.lblDespesas.Text = "Despesas (R$)";
            // 
            // txtValorFrete
            // 
            this.txtValorFrete.Location = new System.Drawing.Point(24, 424);
            this.txtValorFrete.Name = "txtValorFrete";
            this.txtValorFrete.ShortcutsEnabled = false;
            this.txtValorFrete.Size = new System.Drawing.Size(100, 22);
            this.txtValorFrete.TabIndex = 102;
            // 
            // txtSeguro
            // 
            this.txtSeguro.Location = new System.Drawing.Point(130, 424);
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.ShortcutsEnabled = false;
            this.txtSeguro.Size = new System.Drawing.Size(100, 22);
            this.txtSeguro.TabIndex = 102;
            // 
            // txtDespesas
            // 
            this.txtDespesas.Location = new System.Drawing.Point(236, 424);
            this.txtDespesas.Name = "txtDespesas";
            this.txtDespesas.ShortcutsEnabled = false;
            this.txtDespesas.Size = new System.Drawing.Size(100, 22);
            this.txtDespesas.TabIndex = 102;
            // 
            // lblValorTotalValores
            // 
            this.lblValorTotalValores.AutoSize = true;
            this.lblValorTotalValores.Location = new System.Drawing.Point(339, 406);
            this.lblValorTotalValores.Name = "lblValorTotalValores";
            this.lblValorTotalValores.Size = new System.Drawing.Size(101, 16);
            this.lblValorTotalValores.TabIndex = 101;
            this.lblValorTotalValores.Text = "Valor Total (R$)";
            // 
            // txtValorTotalValores
            // 
            this.txtValorTotalValores.Location = new System.Drawing.Point(342, 424);
            this.txtValorTotalValores.Name = "txtValorTotalValores";
            this.txtValorTotalValores.ShortcutsEnabled = false;
            this.txtValorTotalValores.Size = new System.Drawing.Size(100, 22);
            this.txtValorTotalValores.TabIndex = 102;
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.Location = new System.Drawing.Point(422, 229);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(76, 23);
            this.btnEditarProduto.TabIndex = 103;
            this.btnEditarProduto.Text = "Editar";
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(504, 229);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverProduto.TabIndex = 103;
            this.btnRemoverProduto.Text = "Remover";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            // 
            // listVProdutos
            // 
            this.listVProdutos.HideSelection = false;
            this.listVProdutos.Location = new System.Drawing.Point(24, 268);
            this.listVProdutos.Name = "listVProdutos";
            this.listVProdutos.Size = new System.Drawing.Size(555, 97);
            this.listVProdutos.TabIndex = 104;
            this.listVProdutos.UseCompatibleStateImageBehavior = false;
            // 
            // lblCondicaoDePagamento
            // 
            this.lblCondicaoDePagamento.AutoSize = true;
            this.lblCondicaoDePagamento.Location = new System.Drawing.Point(21, 486);
            this.lblCondicaoDePagamento.Name = "lblCondicaoDePagamento";
            this.lblCondicaoDePagamento.Size = new System.Drawing.Size(165, 16);
            this.lblCondicaoDePagamento.TabIndex = 101;
            this.lblCondicaoDePagamento.Text = "Condição de Pagamento *";
            // 
            // txtCondicaoDePagamento
            // 
            this.txtCondicaoDePagamento.Location = new System.Drawing.Point(24, 504);
            this.txtCondicaoDePagamento.Name = "txtCondicaoDePagamento";
            this.txtCondicaoDePagamento.ShortcutsEnabled = false;
            this.txtCondicaoDePagamento.Size = new System.Drawing.Size(100, 22);
            this.txtCondicaoDePagamento.TabIndex = 102;
            // 
            // btnGerarParcelas
            // 
            this.btnGerarParcelas.Location = new System.Drawing.Point(130, 503);
            this.btnGerarParcelas.Name = "btnGerarParcelas";
            this.btnGerarParcelas.Size = new System.Drawing.Size(112, 23);
            this.btnGerarParcelas.TabIndex = 103;
            this.btnGerarParcelas.Text = "Gerar Parcelas";
            this.btnGerarParcelas.UseVisualStyleBackColor = true;
            // 
            // btnLimparParcelas
            // 
            this.btnLimparParcelas.Location = new System.Drawing.Point(248, 503);
            this.btnLimparParcelas.Name = "btnLimparParcelas";
            this.btnLimparParcelas.Size = new System.Drawing.Size(122, 23);
            this.btnLimparParcelas.TabIndex = 103;
            this.btnLimparParcelas.Text = "Limpar Parcelas";
            this.btnLimparParcelas.UseVisualStyleBackColor = true;
            // 
            // btnLimparListaProduto
            // 
            this.btnLimparListaProduto.Location = new System.Drawing.Point(585, 229);
            this.btnLimparListaProduto.Name = "btnLimparListaProduto";
            this.btnLimparListaProduto.Size = new System.Drawing.Size(98, 23);
            this.btnLimparListaProduto.TabIndex = 103;
            this.btnLimparListaProduto.Text = "Limpar Lista";
            this.btnLimparListaProduto.UseVisualStyleBackColor = true;
            // 
            // listVParcelas
            // 
            this.listVParcelas.HideSelection = false;
            this.listVParcelas.Location = new System.Drawing.Point(24, 532);
            this.listVParcelas.Name = "listVParcelas";
            this.listVParcelas.Size = new System.Drawing.Size(555, 80);
            this.listVParcelas.TabIndex = 104;
            this.listVParcelas.UseCompatibleStateImageBehavior = false;
            // 
            // lblCondicaoDePagamentolbl
            // 
            this.lblCondicaoDePagamentolbl.AutoSize = true;
            this.lblCondicaoDePagamentolbl.Location = new System.Drawing.Point(21, 461);
            this.lblCondicaoDePagamentolbl.Name = "lblCondicaoDePagamentolbl";
            this.lblCondicaoDePagamentolbl.Size = new System.Drawing.Size(157, 16);
            this.lblCondicaoDePagamentolbl.TabIndex = 101;
            this.lblCondicaoDePagamentolbl.Text = "Condição de Pagamento";
            // 
            // lblValores
            // 
            this.lblValores.AutoSize = true;
            this.lblValores.Location = new System.Drawing.Point(21, 381);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(54, 16);
            this.lblValores.TabIndex = 101;
            this.lblValores.Text = "Valores";
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.Location = new System.Drawing.Point(212, 100);
            this.dtpDataEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(135, 22);
            this.dtpDataEntrega.TabIndex = 105;
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(25, 100);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(135, 22);
            this.dtpDataEmissao.TabIndex = 106;
            // 
            // lblTotalGeralProdutos
            // 
            this.lblTotalGeralProdutos.AutoSize = true;
            this.lblTotalGeralProdutos.Location = new System.Drawing.Point(339, 368);
            this.lblTotalGeralProdutos.Name = "lblTotalGeralProdutos";
            this.lblTotalGeralProdutos.Size = new System.Drawing.Size(162, 16);
            this.lblTotalGeralProdutos.TabIndex = 101;
            this.lblTotalGeralProdutos.Text = "Total Geral Produtos (R$):";
            // 
            // lblValorTotalGeralProdutos
            // 
            this.lblValorTotalGeralProdutos.AutoSize = true;
            this.lblValorTotalGeralProdutos.Location = new System.Drawing.Point(501, 368);
            this.lblValorTotalGeralProdutos.Name = "lblValorTotalGeralProdutos";
            this.lblValorTotalGeralProdutos.Size = new System.Drawing.Size(14, 16);
            this.lblValorTotalGeralProdutos.TabIndex = 101;
            this.lblValorTotalGeralProdutos.Text = "0";
            // 
            // frmCadastroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1342, 681);
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.dtpDataEntrega);
            this.Controls.Add(this.listVParcelas);
            this.Controls.Add(this.listVProdutos);
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
            this.Controls.Add(this.lblCondicaoDePagamentolbl);
            this.Controls.Add(this.lblCondicaoDePagamento);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.lblValorTotalValores);
            this.Controls.Add(this.lblDespesas);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblTotalProduto);
            this.Controls.Add(this.lblSeguro);
            this.Controls.Add(this.txtNumDaNota);
            this.Controls.Add(this.lblValorUnitario);
            this.Controls.Add(this.lblValorTotalGeralProdutos);
            this.Controls.Add(this.lblTotalGeralProdutos);
            this.Controls.Add(this.lblValores);
            this.Controls.Add(this.lblValorFrete);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.lblDataEntrega);
            this.Controls.Add(this.lblDataEmissao);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.lblNumNota);
            this.Controls.Add(this.lblListaDeProdutos);
            this.Controls.Add(this.lblInformacoes);
            this.Controls.Add(this.lblSerie);
            this.Name = "frmCadastroCompra";
            this.Text = "Cadastro de Compra";
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.lblInformacoes, 0);
            this.Controls.SetChildIndex(this.lblListaDeProdutos, 0);
            this.Controls.SetChildIndex(this.lblNumNota, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.lblDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblDataEntrega, 0);
            this.Controls.SetChildIndex(this.lblProduto, 0);
            this.Controls.SetChildIndex(this.lblQuantidade, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblValorFrete, 0);
            this.Controls.SetChildIndex(this.lblValores, 0);
            this.Controls.SetChildIndex(this.lblTotalGeralProdutos, 0);
            this.Controls.SetChildIndex(this.lblValorTotalGeralProdutos, 0);
            this.Controls.SetChildIndex(this.lblValorUnitario, 0);
            this.Controls.SetChildIndex(this.txtNumDaNota, 0);
            this.Controls.SetChildIndex(this.lblSeguro, 0);
            this.Controls.SetChildIndex(this.lblTotalProduto, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.lblDespesas, 0);
            this.Controls.SetChildIndex(this.lblValorTotalValores, 0);
            this.Controls.SetChildIndex(this.txtProduto, 0);
            this.Controls.SetChildIndex(this.lblCondicaoDePagamento, 0);
            this.Controls.SetChildIndex(this.lblCondicaoDePagamentolbl, 0);
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
        private System.Windows.Forms.Label lblInformacoes;
        private System.Windows.Forms.Label lblListaDeProdutos;
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
        private System.Windows.Forms.Label lblCondicaoDePagamentolbl;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.DateTimePicker dtpDataEntrega;
        private System.Windows.Forms.DateTimePicker dtpDataEmissao;
        private System.Windows.Forms.Label lblTotalGeralProdutos;
        private System.Windows.Forms.Label lblValorTotalGeralProdutos;
    }
}

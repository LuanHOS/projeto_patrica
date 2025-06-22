namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroProduto
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
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.lblCodBarras = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnPesquisarFornecedor = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.btnPesquisarCategoria = new System.Windows.Forms.Button();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnPesquisarMarca = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnPesquisarUnidadeMedida = new System.Windows.Forms.Button();
            this.txtUnidadeMedida = new System.Windows.Forms.TextBox();
            this.lblUnidadeMedida = new System.Windows.Forms.Label();
            this.lblValorCompra = new System.Windows.Forms.Label();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.txtValorCompra = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.lblPorcentagemLucro = new System.Windows.Forms.Label();
            this.lblValorVenda = new System.Windows.Forms.Label();
            this.txtPorcentagemLucro = new System.Windows.Forms.TextBox();
            this.txtValorVenda = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 17;
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 18;
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodBarras.Location = new System.Drawing.Point(24, 98);
            this.txtCodBarras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodBarras.MaxLength = 40;
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(254, 20);
            this.txtCodBarras.TabIndex = 2;
            // 
            // lblCodBarras
            // 
            this.lblCodBarras.AutoSize = true;
            this.lblCodBarras.Location = new System.Drawing.Point(21, 79);
            this.lblCodBarras.Name = "lblCodBarras";
            this.lblCodBarras.Size = new System.Drawing.Size(95, 13);
            this.lblCodBarras.TabIndex = 102;
            this.lblCodBarras.Text = "Código de Barras *";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(24, 147);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.MaxLength = 40;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(647, 20);
            this.txtNome.TabIndex = 3;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(21, 128);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(51, 13);
            this.lblNome.TabIndex = 104;
            this.lblNome.Text = "Produto *";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(24, 198);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricao.MaxLength = 40;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(647, 35);
            this.txtDescricao.TabIndex = 4;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(21, 179);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 106;
            this.lblDescricao.Text = "Descrição";
            // 
            // btnPesquisarFornecedor
            // 
            this.btnPesquisarFornecedor.Location = new System.Drawing.Point(441, 314);
            this.btnPesquisarFornecedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarFornecedor.Name = "btnPesquisarFornecedor";
            this.btnPesquisarFornecedor.Size = new System.Drawing.Size(99, 28);
            this.btnPesquisarFornecedor.TabIndex = 8;
            this.btnPesquisarFornecedor.Text = "Pesquisar";
            this.btnPesquisarFornecedor.UseVisualStyleBackColor = true;
            this.btnPesquisarFornecedor.Click += new System.EventHandler(this.btnPesquisarFornecedor_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFornecedor.Location = new System.Drawing.Point(24, 319);
            this.txtFornecedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(411, 20);
            this.txtFornecedor.TabIndex = 7;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(21, 300);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(68, 13);
            this.lblFornecedor.TabIndex = 109;
            this.lblFornecedor.Text = "Fornecedor *";
            // 
            // btnPesquisarCategoria
            // 
            this.btnPesquisarCategoria.Location = new System.Drawing.Point(441, 365);
            this.btnPesquisarCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarCategoria.Name = "btnPesquisarCategoria";
            this.btnPesquisarCategoria.Size = new System.Drawing.Size(99, 28);
            this.btnPesquisarCategoria.TabIndex = 10;
            this.btnPesquisarCategoria.Text = "Pesquisar";
            this.btnPesquisarCategoria.UseVisualStyleBackColor = true;
            this.btnPesquisarCategoria.Click += new System.EventHandler(this.btnPesquisarCategoria_Click);
            // 
            // txtCategoria
            // 
            this.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCategoria.Location = new System.Drawing.Point(24, 370);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(411, 20);
            this.txtCategoria.TabIndex = 9;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(21, 351);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(59, 13);
            this.lblCategoria.TabIndex = 112;
            this.lblCategoria.Text = "Categoria *";
            // 
            // btnPesquisarMarca
            // 
            this.btnPesquisarMarca.Location = new System.Drawing.Point(441, 263);
            this.btnPesquisarMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarMarca.Name = "btnPesquisarMarca";
            this.btnPesquisarMarca.Size = new System.Drawing.Size(99, 28);
            this.btnPesquisarMarca.TabIndex = 6;
            this.btnPesquisarMarca.Text = "Pesquisar";
            this.btnPesquisarMarca.UseVisualStyleBackColor = true;
            this.btnPesquisarMarca.Click += new System.EventHandler(this.btnPesquisarMarca_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.Location = new System.Drawing.Point(24, 268);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(411, 20);
            this.txtMarca.TabIndex = 5;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(21, 249);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(44, 13);
            this.lblMarca.TabIndex = 115;
            this.lblMarca.Text = "Marca *";
            // 
            // btnPesquisarUnidadeMedida
            // 
            this.btnPesquisarUnidadeMedida.Location = new System.Drawing.Point(134, 416);
            this.btnPesquisarUnidadeMedida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarUnidadeMedida.Name = "btnPesquisarUnidadeMedida";
            this.btnPesquisarUnidadeMedida.Size = new System.Drawing.Size(99, 28);
            this.btnPesquisarUnidadeMedida.TabIndex = 12;
            this.btnPesquisarUnidadeMedida.Text = "Pesquisar";
            this.btnPesquisarUnidadeMedida.UseVisualStyleBackColor = true;
            this.btnPesquisarUnidadeMedida.Click += new System.EventHandler(this.btnPesquisarUnidadeMedida_Click);
            // 
            // txtUnidadeMedida
            // 
            this.txtUnidadeMedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidadeMedida.Location = new System.Drawing.Point(24, 421);
            this.txtUnidadeMedida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUnidadeMedida.Name = "txtUnidadeMedida";
            this.txtUnidadeMedida.ReadOnly = true;
            this.txtUnidadeMedida.Size = new System.Drawing.Size(104, 20);
            this.txtUnidadeMedida.TabIndex = 11;
            // 
            // lblUnidadeMedida
            // 
            this.lblUnidadeMedida.AutoSize = true;
            this.lblUnidadeMedida.Location = new System.Drawing.Point(21, 402);
            this.lblUnidadeMedida.Name = "lblUnidadeMedida";
            this.lblUnidadeMedida.Size = new System.Drawing.Size(107, 13);
            this.lblUnidadeMedida.TabIndex = 118;
            this.lblUnidadeMedida.Text = "Unidade de Medida *";
            // 
            // lblValorCompra
            // 
            this.lblValorCompra.AutoSize = true;
            this.lblValorCompra.Location = new System.Drawing.Point(21, 466);
            this.lblValorCompra.Name = "lblValorCompra";
            this.lblValorCompra.Size = new System.Drawing.Size(83, 13);
            this.lblValorCompra.TabIndex = 120;
            this.lblValorCompra.Text = "Valor de Custo *";
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Location = new System.Drawing.Point(21, 522);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(53, 13);
            this.lblEstoque.TabIndex = 121;
            this.lblEstoque.Text = "Estoque *";
            // 
            // txtValorCompra
            // 
            this.txtValorCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorCompra.Location = new System.Drawing.Point(24, 485);
            this.txtValorCompra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValorCompra.Name = "txtValorCompra";
            this.txtValorCompra.Size = new System.Drawing.Size(194, 20);
            this.txtValorCompra.TabIndex = 13;
            this.txtValorCompra.Leave += new System.EventHandler(this.txtValorCompra_Leave);
            // 
            // txtEstoque
            // 
            this.txtEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstoque.Location = new System.Drawing.Point(24, 541);
            this.txtEstoque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(194, 20);
            this.txtEstoque.TabIndex = 16;
            // 
            // lblPorcentagemLucro
            // 
            this.lblPorcentagemLucro.AutoSize = true;
            this.lblPorcentagemLucro.Location = new System.Drawing.Point(248, 466);
            this.lblPorcentagemLucro.Name = "lblPorcentagemLucro";
            this.lblPorcentagemLucro.Size = new System.Drawing.Size(67, 13);
            this.lblPorcentagemLucro.TabIndex = 124;
            this.lblPorcentagemLucro.Text = "% de Lucro *";
            // 
            // lblValorVenda
            // 
            this.lblValorVenda.AutoSize = true;
            this.lblValorVenda.Location = new System.Drawing.Point(474, 466);
            this.lblValorVenda.Name = "lblValorVenda";
            this.lblValorVenda.Size = new System.Drawing.Size(87, 13);
            this.lblValorVenda.TabIndex = 125;
            this.lblValorVenda.Text = "Valor de Venda *";
            // 
            // txtPorcentagemLucro
            // 
            this.txtPorcentagemLucro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPorcentagemLucro.Location = new System.Drawing.Point(251, 485);
            this.txtPorcentagemLucro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPorcentagemLucro.Name = "txtPorcentagemLucro";
            this.txtPorcentagemLucro.Size = new System.Drawing.Size(194, 20);
            this.txtPorcentagemLucro.TabIndex = 14;
            this.txtPorcentagemLucro.Leave += new System.EventHandler(this.txtPorcentagemLucro_Leave);
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorVenda.Location = new System.Drawing.Point(477, 485);
            this.txtValorVenda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(194, 20);
            this.txtValorVenda.TabIndex = 15;
            this.txtValorVenda.Leave += new System.EventHandler(this.txtValorVenda_Leave);
            // 
            // frmCadastroProduto
            // 
            this.Controls.Add(this.lblPorcentagemLucro);
            this.Controls.Add(this.lblValorVenda);
            this.Controls.Add(this.txtPorcentagemLucro);
            this.Controls.Add(this.txtValorVenda);
            this.Controls.Add(this.lblValorCompra);
            this.Controls.Add(this.lblEstoque);
            this.Controls.Add(this.txtValorCompra);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.btnPesquisarUnidadeMedida);
            this.Controls.Add(this.txtUnidadeMedida);
            this.Controls.Add(this.lblUnidadeMedida);
            this.Controls.Add(this.btnPesquisarMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.btnPesquisarCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.btnPesquisarFornecedor);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtCodBarras);
            this.Controls.Add(this.lblCodBarras);
            this.Name = "frmCadastroProduto";
            this.Text = "Cadastro de Produto";
            this.Controls.SetChildIndex(this.lblCodBarras, 0);
            this.Controls.SetChildIndex(this.txtCodBarras, 0);
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFornecedor, 0);
            this.Controls.SetChildIndex(this.lblCategoria, 0);
            this.Controls.SetChildIndex(this.txtCategoria, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCategoria, 0);
            this.Controls.SetChildIndex(this.lblMarca, 0);
            this.Controls.SetChildIndex(this.txtMarca, 0);
            this.Controls.SetChildIndex(this.btnPesquisarMarca, 0);
            this.Controls.SetChildIndex(this.lblUnidadeMedida, 0);
            this.Controls.SetChildIndex(this.txtUnidadeMedida, 0);
            this.Controls.SetChildIndex(this.btnPesquisarUnidadeMedida, 0);
            this.Controls.SetChildIndex(this.txtEstoque, 0);
            this.Controls.SetChildIndex(this.txtValorCompra, 0);
            this.Controls.SetChildIndex(this.lblEstoque, 0);
            this.Controls.SetChildIndex(this.lblValorCompra, 0);
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
            this.Controls.SetChildIndex(this.txtValorVenda, 0);
            this.Controls.SetChildIndex(this.txtPorcentagemLucro, 0);
            this.Controls.SetChildIndex(this.lblValorVenda, 0);
            this.Controls.SetChildIndex(this.lblPorcentagemLucro, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.Label lblCodBarras;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button btnPesquisarFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Button btnPesquisarCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnPesquisarMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnPesquisarUnidadeMedida;
        private System.Windows.Forms.TextBox txtUnidadeMedida;
        private System.Windows.Forms.Label lblUnidadeMedida;
        private System.Windows.Forms.Label lblValorCompra;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.TextBox txtValorCompra;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label lblPorcentagemLucro;
        private System.Windows.Forms.Label lblValorVenda;
        private System.Windows.Forms.TextBox txtPorcentagemLucro;
        private System.Windows.Forms.TextBox txtValorVenda;
    }
}

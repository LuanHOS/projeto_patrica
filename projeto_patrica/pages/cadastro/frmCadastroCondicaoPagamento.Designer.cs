namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroCondicaoPagamento
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
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtQtdParcelas = new System.Windows.Forms.TextBox();
            this.lvlQtdParcelas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.listVParcelas = new System.Windows.Forms.ListView();
            this.clmNumParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCodFormaPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPercentualParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDiasAposPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoverParcela = new System.Windows.Forms.Button();
            this.btnEditarParcela = new System.Windows.Forms.Button();
            this.btnAdicionarParcela = new System.Windows.Forms.Button();
            this.btnPesquisarFormaPagamento = new System.Windows.Forms.Button();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.txtPrazoDias = new System.Windows.Forms.TextBox();
            this.lblPrazoDias = new System.Windows.Forms.Label();
            this.txtPercentualParcela = new System.Windows.Forms.TextBox();
            this.lblPercentualParcela = new System.Windows.Forms.Label();
            this.txtNumParcela = new System.Windows.Forms.TextBox();
            this.lblNumParcela = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(651, 778);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(743, 778);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(24, 106);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(412, 22);
            this.txtDescricao.TabIndex = 3;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(21, 87);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(77, 16);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Descrição *";
            // 
            // txtQtdParcelas
            // 
            this.txtQtdParcelas.Location = new System.Drawing.Point(24, 164);
            this.txtQtdParcelas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQtdParcelas.Name = "txtQtdParcelas";
            this.txtQtdParcelas.Size = new System.Drawing.Size(119, 22);
            this.txtQtdParcelas.TabIndex = 3;
            // 
            // lvlQtdParcelas
            // 
            this.lvlQtdParcelas.AutoSize = true;
            this.lvlQtdParcelas.Location = new System.Drawing.Point(21, 145);
            this.lvlQtdParcelas.Name = "lvlQtdParcelas";
            this.lvlQtdParcelas.Size = new System.Drawing.Size(96, 16);
            this.lvlQtdParcelas.TabIndex = 4;
            this.lvlQtdParcelas.Text = "Qtd. Parcelas *";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxFormaPagamento);
            this.panel1.Controls.Add(this.listVParcelas);
            this.panel1.Controls.Add(this.btnRemoverParcela);
            this.panel1.Controls.Add(this.btnEditarParcela);
            this.panel1.Controls.Add(this.btnAdicionarParcela);
            this.panel1.Controls.Add(this.btnPesquisarFormaPagamento);
            this.panel1.Controls.Add(this.lblFormaPagamento);
            this.panel1.Controls.Add(this.txtPrazoDias);
            this.panel1.Controls.Add(this.lblPrazoDias);
            this.panel1.Controls.Add(this.txtPercentualParcela);
            this.panel1.Controls.Add(this.lblPercentualParcela);
            this.panel1.Controls.Add(this.txtNumParcela);
            this.panel1.Controls.Add(this.lblNumParcela);
            this.panel1.Controls.Add(this.lblParcelas);
            this.panel1.Location = new System.Drawing.Point(24, 207);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 564);
            this.panel1.TabIndex = 5;
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(491, 81);
            this.comboBoxFormaPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(183, 24);
            this.comboBoxFormaPagamento.TabIndex = 8;
            // 
            // listVParcelas
            // 
            this.listVParcelas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNumParcela,
            this.clmCodFormaPagamento,
            this.clmPercentualParcela,
            this.clmDiasAposPagamento});
            this.listVParcelas.FullRowSelect = true;
            this.listVParcelas.GridLines = true;
            this.listVParcelas.HideSelection = false;
            this.listVParcelas.Location = new System.Drawing.Point(24, 182);
            this.listVParcelas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listVParcelas.Name = "listVParcelas";
            this.listVParcelas.Size = new System.Drawing.Size(752, 363);
            this.listVParcelas.TabIndex = 7;
            this.listVParcelas.UseCompatibleStateImageBehavior = false;
            this.listVParcelas.View = System.Windows.Forms.View.Details;
            // 
            // clmNumParcela
            // 
            this.clmNumParcela.Text = "Num. Parcela";
            this.clmNumParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmNumParcela.Width = 103;
            // 
            // clmCodFormaPagamento
            // 
            this.clmCodFormaPagamento.Text = "Forma de Pagamento";
            this.clmCodFormaPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmCodFormaPagamento.Width = 163;
            // 
            // clmPercentualParcela
            // 
            this.clmPercentualParcela.Text = "Percentual";
            this.clmPercentualParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmPercentualParcela.Width = 116;
            // 
            // clmDiasAposPagamento
            // 
            this.clmDiasAposPagamento.Text = "Dias após Venda";
            this.clmDiasAposPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmDiasAposPagamento.Width = 145;
            // 
            // btnRemoverParcela
            // 
            this.btnRemoverParcela.Location = new System.Drawing.Point(632, 129);
            this.btnRemoverParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoverParcela.Name = "btnRemoverParcela";
            this.btnRemoverParcela.Size = new System.Drawing.Size(144, 34);
            this.btnRemoverParcela.TabIndex = 6;
            this.btnRemoverParcela.Text = "Remover Parcela";
            this.btnRemoverParcela.UseVisualStyleBackColor = true;
            this.btnRemoverParcela.Click += new System.EventHandler(this.btnRemoverParcela_Click);
            // 
            // btnEditarParcela
            // 
            this.btnEditarParcela.Location = new System.Drawing.Point(483, 129);
            this.btnEditarParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarParcela.Name = "btnEditarParcela";
            this.btnEditarParcela.Size = new System.Drawing.Size(144, 34);
            this.btnEditarParcela.TabIndex = 6;
            this.btnEditarParcela.Text = "Editar Parcela";
            this.btnEditarParcela.UseVisualStyleBackColor = true;
            this.btnEditarParcela.Click += new System.EventHandler(this.btnEditarParcela_Click);
            // 
            // btnAdicionarParcela
            // 
            this.btnAdicionarParcela.Location = new System.Drawing.Point(333, 129);
            this.btnAdicionarParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionarParcela.Name = "btnAdicionarParcela";
            this.btnAdicionarParcela.Size = new System.Drawing.Size(144, 34);
            this.btnAdicionarParcela.TabIndex = 6;
            this.btnAdicionarParcela.Text = "Adicionar Parcela";
            this.btnAdicionarParcela.UseVisualStyleBackColor = true;
            this.btnAdicionarParcela.Click += new System.EventHandler(this.btnAdicionarParcela_Click);
            // 
            // btnPesquisarFormaPagamento
            // 
            this.btnPesquisarFormaPagamento.Location = new System.Drawing.Point(680, 75);
            this.btnPesquisarFormaPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarFormaPagamento.Name = "btnPesquisarFormaPagamento";
            this.btnPesquisarFormaPagamento.Size = new System.Drawing.Size(96, 34);
            this.btnPesquisarFormaPagamento.TabIndex = 6;
            this.btnPesquisarFormaPagamento.Text = "Pesquisar";
            this.btnPesquisarFormaPagamento.UseVisualStyleBackColor = true;
            this.btnPesquisarFormaPagamento.Click += new System.EventHandler(this.btnPesquisarFormaPagamento_Click);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(488, 62);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(138, 16);
            this.lblFormaPagamento.TabIndex = 0;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // txtPrazoDias
            // 
            this.txtPrazoDias.Location = new System.Drawing.Point(339, 81);
            this.txtPrazoDias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrazoDias.Name = "txtPrazoDias";
            this.txtPrazoDias.Size = new System.Drawing.Size(135, 22);
            this.txtPrazoDias.TabIndex = 1;
            // 
            // lblPrazoDias
            // 
            this.lblPrazoDias.AutoSize = true;
            this.lblPrazoDias.Location = new System.Drawing.Point(336, 62);
            this.lblPrazoDias.Name = "lblPrazoDias";
            this.lblPrazoDias.Size = new System.Drawing.Size(95, 16);
            this.lblPrazoDias.TabIndex = 0;
            this.lblPrazoDias.Text = "Prazo em Dias";
            // 
            // txtPercentualParcela
            // 
            this.txtPercentualParcela.Location = new System.Drawing.Point(184, 81);
            this.txtPercentualParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPercentualParcela.Name = "txtPercentualParcela";
            this.txtPercentualParcela.Size = new System.Drawing.Size(135, 22);
            this.txtPercentualParcela.TabIndex = 1;
            // 
            // lblPercentualParcela
            // 
            this.lblPercentualParcela.AutoSize = true;
            this.lblPercentualParcela.Location = new System.Drawing.Point(181, 62);
            this.lblPercentualParcela.Name = "lblPercentualParcela";
            this.lblPercentualParcela.Size = new System.Drawing.Size(71, 16);
            this.lblPercentualParcela.TabIndex = 0;
            this.lblPercentualParcela.Text = "Percentual";
            // 
            // txtNumParcela
            // 
            this.txtNumParcela.Location = new System.Drawing.Point(24, 81);
            this.txtNumParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumParcela.Name = "txtNumParcela";
            this.txtNumParcela.Size = new System.Drawing.Size(135, 22);
            this.txtNumParcela.TabIndex = 1;
            // 
            // lblNumParcela
            // 
            this.lblNumParcela.AutoSize = true;
            this.lblNumParcela.Location = new System.Drawing.Point(21, 62);
            this.lblNumParcela.Name = "lblNumParcela";
            this.lblNumParcela.Size = new System.Drawing.Size(124, 16);
            this.lblNumParcela.TabIndex = 0;
            this.lblNumParcela.Text = "Número da Parcela";
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Location = new System.Drawing.Point(21, 18);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(61, 16);
            this.lblParcelas.TabIndex = 0;
            this.lblParcelas.Text = "Parcelas";
            // 
            // frmCadastroCondicaoPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(844, 825);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvlQtdParcelas);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtQtdParcelas);
            this.Controls.Add(this.txtDescricao);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCadastroCondicaoPagamento";
            this.Text = "Cadastro de Condição de Pagamento";
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.txtQtdParcelas, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.lvlQtdParcelas, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtQtdParcelas;
        private System.Windows.Forms.Label lvlQtdParcelas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listVParcelas;
        private System.Windows.Forms.Button btnRemoverParcela;
        private System.Windows.Forms.Button btnAdicionarParcela;
        private System.Windows.Forms.Button btnPesquisarFormaPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.TextBox txtPrazoDias;
        private System.Windows.Forms.Label lblPrazoDias;
        private System.Windows.Forms.TextBox txtPercentualParcela;
        private System.Windows.Forms.Label lblPercentualParcela;
        private System.Windows.Forms.TextBox txtNumParcela;
        private System.Windows.Forms.Label lblNumParcela;
        private System.Windows.Forms.Label lblParcelas;
        private System.Windows.Forms.ColumnHeader clmNumParcela;
        private System.Windows.Forms.ColumnHeader clmCodFormaPagamento;
        private System.Windows.Forms.ColumnHeader clmPercentualParcela;
        private System.Windows.Forms.ColumnHeader clmDiasAposPagamento;
        private System.Windows.Forms.ComboBox comboBoxFormaPagamento;
        private System.Windows.Forms.Button btnEditarParcela;
    }
}

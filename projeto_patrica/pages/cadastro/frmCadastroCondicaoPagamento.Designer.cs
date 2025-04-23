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
            this.lblPorcentagemTotalNum = new System.Windows.Forms.Label();
            this.lblPorcentagemTotal = new System.Windows.Forms.Label();
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
            this.txtJuros = new System.Windows.Forms.TextBox();
            this.lblJuros = new System.Windows.Forms.Label();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.lblMulta = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(651, 648);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.TabIndex = 15;
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.Location = new System.Drawing.Point(21, 635);
            // 
            // lblDataUltimaEdicao
            // 
            this.lblDataUltimaEdicao.Location = new System.Drawing.Point(21, 651);
            // 
            // lblUltimoUsuarioQueEditou
            // 
            this.lblUltimoUsuarioQueEditou.Location = new System.Drawing.Point(21, 667);
            // 
            // lblDataCadastroData
            // 
            this.lblDataCadastroData.Location = new System.Drawing.Point(143, 635);
            // 
            // lblDataUltimaEdicaoData
            // 
            this.lblDataUltimaEdicaoData.Location = new System.Drawing.Point(172, 651);
            // 
            // lblUltimoUsuarioQueEditouNome
            // 
            this.lblUltimoUsuarioQueEditouNome.Location = new System.Drawing.Point(192, 667);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(743, 648);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            this.btnSair.TabIndex = 16;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(24, 106);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(212, 22);
            this.txtDescricao.TabIndex = 2;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(21, 87);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(165, 16);
            this.lblDescricao.TabIndex = 4;
            this.lblDescricao.Text = "Condição de Pagamento *";
            // 
            // txtQtdParcelas
            // 
            this.txtQtdParcelas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdParcelas.Location = new System.Drawing.Point(254, 106);
            this.txtQtdParcelas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQtdParcelas.Name = "txtQtdParcelas";
            this.txtQtdParcelas.Size = new System.Drawing.Size(93, 22);
            this.txtQtdParcelas.TabIndex = 3;
            // 
            // lvlQtdParcelas
            // 
            this.lvlQtdParcelas.AutoSize = true;
            this.lvlQtdParcelas.Location = new System.Drawing.Point(251, 87);
            this.lvlQtdParcelas.Name = "lvlQtdParcelas";
            this.lvlQtdParcelas.Size = new System.Drawing.Size(96, 16);
            this.lvlQtdParcelas.TabIndex = 4;
            this.lvlQtdParcelas.Text = "Qtd. Parcelas *";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPorcentagemTotalNum);
            this.panel1.Controls.Add(this.lblPorcentagemTotal);
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
            this.panel1.Location = new System.Drawing.Point(24, 150);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 465);
            this.panel1.TabIndex = 5;
            // 
            // lblPorcentagemTotalNum
            // 
            this.lblPorcentagemTotalNum.AutoSize = true;
            this.lblPorcentagemTotalNum.Location = new System.Drawing.Point(246, 106);
            this.lblPorcentagemTotalNum.Name = "lblPorcentagemTotalNum";
            this.lblPorcentagemTotalNum.Size = new System.Drawing.Size(14, 16);
            this.lblPorcentagemTotalNum.TabIndex = 10;
            this.lblPorcentagemTotalNum.Text = "0";
            // 
            // lblPorcentagemTotal
            // 
            this.lblPorcentagemTotal.AutoSize = true;
            this.lblPorcentagemTotal.Location = new System.Drawing.Point(181, 106);
            this.lblPorcentagemTotal.Name = "lblPorcentagemTotal";
            this.lblPorcentagemTotal.Size = new System.Drawing.Size(59, 16);
            this.lblPorcentagemTotal.TabIndex = 9;
            this.lblPorcentagemTotal.Text = "% Total: ";
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(491, 73);
            this.comboBoxFormaPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(183, 24);
            this.comboBoxFormaPagamento.TabIndex = 10;
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
            this.listVParcelas.Location = new System.Drawing.Point(24, 174);
            this.listVParcelas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listVParcelas.Name = "listVParcelas";
            this.listVParcelas.Size = new System.Drawing.Size(752, 266);
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
            this.btnRemoverParcela.Location = new System.Drawing.Point(632, 121);
            this.btnRemoverParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoverParcela.Name = "btnRemoverParcela";
            this.btnRemoverParcela.Size = new System.Drawing.Size(144, 34);
            this.btnRemoverParcela.TabIndex = 14;
            this.btnRemoverParcela.Text = "Remover Parcela";
            this.btnRemoverParcela.UseVisualStyleBackColor = true;
            this.btnRemoverParcela.Click += new System.EventHandler(this.btnRemoverParcela_Click);
            // 
            // btnEditarParcela
            // 
            this.btnEditarParcela.Location = new System.Drawing.Point(483, 121);
            this.btnEditarParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarParcela.Name = "btnEditarParcela";
            this.btnEditarParcela.Size = new System.Drawing.Size(144, 34);
            this.btnEditarParcela.TabIndex = 13;
            this.btnEditarParcela.Text = "Editar Parcela";
            this.btnEditarParcela.UseVisualStyleBackColor = true;
            this.btnEditarParcela.Click += new System.EventHandler(this.btnEditarParcela_Click);
            // 
            // btnAdicionarParcela
            // 
            this.btnAdicionarParcela.Location = new System.Drawing.Point(333, 121);
            this.btnAdicionarParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionarParcela.Name = "btnAdicionarParcela";
            this.btnAdicionarParcela.Size = new System.Drawing.Size(144, 34);
            this.btnAdicionarParcela.TabIndex = 12;
            this.btnAdicionarParcela.Text = "Adicionar Parcela";
            this.btnAdicionarParcela.UseVisualStyleBackColor = true;
            this.btnAdicionarParcela.Click += new System.EventHandler(this.btnAdicionarParcela_Click);
            // 
            // btnPesquisarFormaPagamento
            // 
            this.btnPesquisarFormaPagamento.Location = new System.Drawing.Point(680, 67);
            this.btnPesquisarFormaPagamento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarFormaPagamento.Name = "btnPesquisarFormaPagamento";
            this.btnPesquisarFormaPagamento.Size = new System.Drawing.Size(96, 34);
            this.btnPesquisarFormaPagamento.TabIndex = 11;
            this.btnPesquisarFormaPagamento.Text = "Pesquisar";
            this.btnPesquisarFormaPagamento.UseVisualStyleBackColor = true;
            this.btnPesquisarFormaPagamento.Click += new System.EventHandler(this.btnPesquisarFormaPagamento_Click);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(488, 54);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(138, 16);
            this.lblFormaPagamento.TabIndex = 0;
            this.lblFormaPagamento.Text = "Forma de Pagamento";
            // 
            // txtPrazoDias
            // 
            this.txtPrazoDias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrazoDias.Location = new System.Drawing.Point(339, 73);
            this.txtPrazoDias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrazoDias.Name = "txtPrazoDias";
            this.txtPrazoDias.Size = new System.Drawing.Size(135, 22);
            this.txtPrazoDias.TabIndex = 9;
            // 
            // lblPrazoDias
            // 
            this.lblPrazoDias.AutoSize = true;
            this.lblPrazoDias.Location = new System.Drawing.Point(336, 54);
            this.lblPrazoDias.Name = "lblPrazoDias";
            this.lblPrazoDias.Size = new System.Drawing.Size(95, 16);
            this.lblPrazoDias.TabIndex = 0;
            this.lblPrazoDias.Text = "Prazo em Dias";
            // 
            // txtPercentualParcela
            // 
            this.txtPercentualParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPercentualParcela.Location = new System.Drawing.Point(184, 73);
            this.txtPercentualParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPercentualParcela.Name = "txtPercentualParcela";
            this.txtPercentualParcela.Size = new System.Drawing.Size(135, 22);
            this.txtPercentualParcela.TabIndex = 8;
            // 
            // lblPercentualParcela
            // 
            this.lblPercentualParcela.AutoSize = true;
            this.lblPercentualParcela.Location = new System.Drawing.Point(181, 54);
            this.lblPercentualParcela.Name = "lblPercentualParcela";
            this.lblPercentualParcela.Size = new System.Drawing.Size(71, 16);
            this.lblPercentualParcela.TabIndex = 0;
            this.lblPercentualParcela.Text = "Percentual";
            // 
            // txtNumParcela
            // 
            this.txtNumParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumParcela.Location = new System.Drawing.Point(24, 73);
            this.txtNumParcela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumParcela.Name = "txtNumParcela";
            this.txtNumParcela.Size = new System.Drawing.Size(135, 22);
            this.txtNumParcela.TabIndex = 7;
            // 
            // lblNumParcela
            // 
            this.lblNumParcela.AutoSize = true;
            this.lblNumParcela.Location = new System.Drawing.Point(21, 54);
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
            // txtJuros
            // 
            this.txtJuros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJuros.Location = new System.Drawing.Point(364, 106);
            this.txtJuros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.Size = new System.Drawing.Size(92, 22);
            this.txtJuros.TabIndex = 4;
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Location = new System.Drawing.Point(361, 87);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(63, 16);
            this.lblJuros.TabIndex = 4;
            this.lblJuros.Text = "Juros % *";
            // 
            // txtMulta
            // 
            this.txtMulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMulta.Location = new System.Drawing.Point(474, 106);
            this.txtMulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.Size = new System.Drawing.Size(92, 22);
            this.txtMulta.TabIndex = 5;
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Location = new System.Drawing.Point(471, 87);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(62, 16);
            this.lblMulta.TabIndex = 4;
            this.lblMulta.Text = "Multa % *";
            // 
            // txtDesconto
            // 
            this.txtDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesconto.Location = new System.Drawing.Point(580, 105);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(92, 22);
            this.txtDesconto.TabIndex = 6;
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(577, 87);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(88, 16);
            this.lblDesconto.TabIndex = 4;
            this.lblDesconto.Text = "Desconto % *";
            // 
            // frmCadastroCondicaoPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1342, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.lblMulta);
            this.Controls.Add(this.lblJuros);
            this.Controls.Add(this.lvlQtdParcelas);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtMulta);
            this.Controls.Add(this.txtJuros);
            this.Controls.Add(this.txtQtdParcelas);
            this.Controls.Add(this.txtDescricao);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCadastroCondicaoPagamento";
            this.Text = "Cadastro de Condição de Pagamento";
            this.Controls.SetChildIndex(this.checkBoxAtivo, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.lblDataCadastro, 0);
            this.Controls.SetChildIndex(this.lblDataCadastroData, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicao, 0);
            this.Controls.SetChildIndex(this.lblDataUltimaEdicaoData, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditou, 0);
            this.Controls.SetChildIndex(this.lblUltimoUsuarioQueEditouNome, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.txtQtdParcelas, 0);
            this.Controls.SetChildIndex(this.txtJuros, 0);
            this.Controls.SetChildIndex(this.txtMulta, 0);
            this.Controls.SetChildIndex(this.txtDesconto, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.lvlQtdParcelas, 0);
            this.Controls.SetChildIndex(this.lblJuros, 0);
            this.Controls.SetChildIndex(this.lblMulta, 0);
            this.Controls.SetChildIndex(this.lblDesconto, 0);
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
        private System.Windows.Forms.Label lblPorcentagemTotal;
        private System.Windows.Forms.Label lblPorcentagemTotalNum;
        private System.Windows.Forms.TextBox txtJuros;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label lblDesconto;
    }
}

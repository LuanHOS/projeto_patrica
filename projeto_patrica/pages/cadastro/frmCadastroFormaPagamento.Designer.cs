namespace projeto_patrica.pages.cadastro
{
    partial class frmCadastroFormaPagamento
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
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lvlQtdParcelas = new System.Windows.Forms.Label();
            this.txtQtdParcelas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(21, 116);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(69, 16);
            this.lblDescricao.TabIndex = 8;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(24, 135);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(412, 22);
            this.txtDescricao.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Dias após venda";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(603, 332);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(119, 22);
            this.textBox4.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Valor da Parcela (%)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(603, 272);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(119, 22);
            this.textBox3.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(600, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cod. Forma de Pagamento";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(603, 207);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 22);
            this.textBox2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Número da Parcela";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(603, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 22);
            this.textBox1.TabIndex = 17;
            // 
            // lvlQtdParcelas
            // 
            this.lvlQtdParcelas.AutoSize = true;
            this.lvlQtdParcelas.Location = new System.Drawing.Point(600, 70);
            this.lvlQtdParcelas.Name = "lvlQtdParcelas";
            this.lvlQtdParcelas.Size = new System.Drawing.Size(188, 16);
            this.lvlQtdParcelas.TabIndex = 16;
            this.lvlQtdParcelas.Text = "Cod. Condição de Pagamento";
            // 
            // txtQtdParcelas
            // 
            this.txtQtdParcelas.Location = new System.Drawing.Point(603, 89);
            this.txtQtdParcelas.Name = "txtQtdParcelas";
            this.txtQtdParcelas.Size = new System.Drawing.Size(119, 22);
            this.txtQtdParcelas.TabIndex = 15;
            // 
            // frmCadastroFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(844, 476);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lvlQtdParcelas);
            this.Controls.Add(this.txtQtdParcelas);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Name = "frmCadastroFormaPagamento";
            this.Text = "Cadastro de Forma de Pagamento";
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.txtQtdParcelas, 0);
            this.Controls.SetChildIndex(this.lvlQtdParcelas, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lvlQtdParcelas;
        private System.Windows.Forms.TextBox txtQtdParcelas;
    }
}

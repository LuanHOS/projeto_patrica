using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroFormaPagamento : projeto_patrica.pages.cadastro.frmCadastro
    {
        private formaPagamento aFormaPagamento;
        private Controller_formaPagamento aController_formaPagamento;


        /*
         * 
         */


        public frmCadastroFormaPagamento()
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString("0");
        }


        /*
         * 
         */


        public override void ConhecaObj(object obj, object ctrl)
        {
            aFormaPagamento = (formaPagamento)obj;
            aController_formaPagamento = (Controller_formaPagamento)ctrl;
        }


        /*
         * 
         */


        public override void Salvar()
        {
            base.Salvar();

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preencha os Campos Obrigatórios!");
                txtDescricao.Focus();
                return;
            }

            aFormaPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aFormaPagamento.Descricao = txtDescricao.Text;

            if (btnSave.Text == "Salvar")
            {
                this.txtCodigo.Text = aController_formaPagamento.Salvar(aFormaPagamento);
                MessageBox.Show($"A forma de pagamento \"{aFormaPagamento.Descricao}\" foi salva com o código {this.txtCodigo.Text}.");
            }
            else if (btnSave.Text == "Excluir")
            {
                var confirmResult = MessageBox.Show(
                    $"Tem certeza que deseja excluir a forma de pagamento \"{aFormaPagamento.Descricao}\"?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    aController_formaPagamento.Excluir(aFormaPagamento);
                    MessageBox.Show($"A forma de pagamento \"{aFormaPagamento.Descricao}\" foi excluída com sucesso.");
                    Sair();
                }
            }
        }


        /*
         * 
         */


        public override void Alterar()
        {
            base.Alterar();

            aFormaPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aFormaPagamento.Descricao = txtDescricao.Text;
            this.txtCodigo.Text = aController_formaPagamento.Salvar(aFormaPagamento);
            MessageBox.Show($"A forma de pagamento \"{aFormaPagamento.Descricao}\" foi alterada com sucesso.");
        }


        /*
         * 
         */


        public override void Limpartxt()
        {
            base.Limpartxt();

            this.txtDescricao.Clear();
        }


        /*
         * 
         */


        public override void Carregatxt()
        {
            base.Carregatxt();

            this.txtCodigo.Text = Convert.ToString(aFormaPagamento.Id);
            this.txtDescricao.Text = aFormaPagamento.Descricao;
        }


        /*
         * 
         */


        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            this.txtDescricao.Enabled = false;
        }


        /*
         * 
         */


        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            this.txtDescricao.Enabled = true;
        }
    }
}

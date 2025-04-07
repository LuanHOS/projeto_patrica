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

        public frmCadastroFormaPagamento()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aFormaPagamento = (formaPagamento)obj;
            aController_formaPagamento = (Controller_formaPagamento)ctrl;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                txtDescricao.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            aFormaPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aFormaPagamento.Descricao = txtDescricao.Text;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        txtCodigo.Text = aController_formaPagamento.Excluir(aFormaPagamento);
                        MessageBox.Show("A forma de pagamento \"" + aFormaPagamento.Descricao + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_formaPagamento.Salvar(aFormaPagamento);
                    MessageBox.Show("A forma de pagamento \"" + aFormaPagamento.Descricao + "\" foi alterada com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_formaPagamento.Salvar(aFormaPagamento);
                    MessageBox.Show("A forma de pagamento \"" + aFormaPagamento.Descricao + "\" foi salva com o código " + txtCodigo.Text + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível concluir a operação. Verifique os dados e tente novamente.\n\nDetalhes técnicos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            base.Salvar();
        }




        public override void Limpartxt()
        {
            txtCodigo.Text = "0";
            txtDescricao.Clear();
        }

        public override void Carregatxt()
        {
            txtCodigo.Text = Convert.ToString(aFormaPagamento.Id);
            txtDescricao.Text = aFormaPagamento.Descricao;
        }

        public override void Bloqueiatxt()
        {
            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            txtCodigo.Enabled = true;
            txtDescricao.Enabled = true;
        }
    }
}

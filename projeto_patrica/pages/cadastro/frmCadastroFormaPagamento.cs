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
            aFormaPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aFormaPagamento.Descricao = txtDescricao.Text;

            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha a descrição.");
                txtDescricao.Focus();
                return;
            }

            if (btnSave.Text == "Excluir")
            {
                txtCodigo.Text = aController_formaPagamento.Excluir(aFormaPagamento);
            }
            else
            {
                txtCodigo.Text = aController_formaPagamento.Salvar(aFormaPagamento);
                MessageBox.Show("Salvo com sucesso.");
            }
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

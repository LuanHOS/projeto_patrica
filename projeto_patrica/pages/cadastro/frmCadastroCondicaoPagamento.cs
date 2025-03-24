using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
	public partial class frmCadastroCondicaoPagamento : projeto_patrica.pages.cadastro.frmCadastro
	{

        private condicaoPagamento aCondicaoPagamento;
        private Controller_condicaoPagamento aController_condicaoPagamento;


        /*
         * 
         */


        public frmCadastroCondicaoPagamento()
        {
            InitializeComponent();
            txtCodigo.Text = Convert.ToString("0");
        }


        /*
         * 
         */


        public override void ConhecaObj(object obj, object ctrl)
        {
            aCondicaoPagamento = (condicaoPagamento)obj;
            aController_condicaoPagamento = (Controller_condicaoPagamento)ctrl;
        }


        /*
         * 
         */


        public override void Salvar()
        {
            base.Salvar();

            if ((string.IsNullOrWhiteSpace(txtDescricao.Text)) || (string.IsNullOrWhiteSpace(txtQtdParcelas.Text)))
            {
                MessageBox.Show("Preencha os Campos Obrigatórios!");
                txtDescricao.Focus();
                txtQtdParcelas.Focus();
                return;
            }


            aCondicaoPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aCondicaoPagamento.Descricao = txtDescricao.Text;
            aCondicaoPagamento.QuantidadeParcelas = Convert.ToInt32(txtQtdParcelas.Text);

            if (btnSave.Text == "Salvar")
            {
                this.txtCodigo.Text = aController_condicaoPagamento.Salvar(aCondicaoPagamento);
                MessageBox.Show($"A condição de pagamento \"{aCondicaoPagamento.Descricao}\" foi salva com o código {this.txtCodigo.Text}.");
            }
            else if (btnSave.Text == "Excluir")
            {
                var confirmResult = MessageBox.Show(
                    $"Tem certeza que deseja excluir a condição de pagamento \"{aCondicaoPagamento.Descricao}\"?",
                    "Confirmação de Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    aController_condicaoPagamento.Excluir(aCondicaoPagamento);
                    MessageBox.Show($"A condição de pagamento \"{aCondicaoPagamento.Descricao}\" foi excluída com sucesso.");
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

            aCondicaoPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aCondicaoPagamento.Descricao = txtDescricao.Text;
            aCondicaoPagamento.QuantidadeParcelas = Convert.ToInt32(txtQtdParcelas.Text);
            this.txtCodigo.Text = aController_condicaoPagamento.Salvar(aCondicaoPagamento);
            MessageBox.Show($"A condição de pagamento \"{aCondicaoPagamento.Descricao}\" foi alterada com sucesso.");
        }


        /*
         * 
         */


        public override void Limpartxt()
        {
            base.Limpartxt();

            this.txtDescricao.Clear();
            this.txtQtdParcelas.Clear();
        }


        /*
         * 
         */


        public override void Carregatxt()
        {
            base.Carregatxt();

            this.txtCodigo.Text = Convert.ToString(aCondicaoPagamento.Id);
            this.txtDescricao.Text = aCondicaoPagamento.Descricao;
            this.txtQtdParcelas.Text = Convert.ToString(aCondicaoPagamento.QuantidadeParcelas);
        }


        /*
         * 
         */


        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            this.txtDescricao.Enabled = false;
            this.txtQtdParcelas.Enabled = false;
        }


        /*
         * 
         */


        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            this.txtDescricao.Enabled = true;
            this.txtQtdParcelas.Enabled = true;
        }
    }










}

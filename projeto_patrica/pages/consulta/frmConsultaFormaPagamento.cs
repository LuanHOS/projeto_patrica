using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaFormaPagamento : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroFormaPagamento oFrmCadFormaPagamento;
        private formaPagamento aFormaPagamento;
        Controller_formaPagamento aController_formaPagamento;


        /*
         * 
         */

        public frmConsultaFormaPagamento()
        {
            InitializeComponent();
        }


        /*
         * 
         */


        public override void setFrmCadastro(object obj)
        {
            oFrmCadFormaPagamento = (frmCadastroFormaPagamento)obj;
        }


        /*
         * 
         */


        public override void ConhecaObj(object obj, object ctrl)
        {
            aFormaPagamento = (formaPagamento)obj;
            aController_formaPagamento = (Controller_formaPagamento)ctrl;
            this.CarregaLV();
        }


        /*
         * 
         */


        public override void Incluir()
        {
            base.Incluir();
            oFrmCadFormaPagamento.ConhecaObj(aFormaPagamento, aController_formaPagamento);
            oFrmCadFormaPagamento.Limpartxt();
            oFrmCadFormaPagamento.txtCodigo.Enabled = false;
            oFrmCadFormaPagamento.ShowDialog();
            this.CarregaLV();
        }


        /*
         * 
         */


        public override void Alterar()
        {
            base.Alterar();
            aController_formaPagamento.CarregaObj(aFormaPagamento);
            oFrmCadFormaPagamento.ConhecaObj(aFormaPagamento, aController_formaPagamento);
            oFrmCadFormaPagamento.Carregatxt();
            oFrmCadFormaPagamento.txtCodigo.Enabled = false;
            oFrmCadFormaPagamento.ShowDialog();
            this.CarregaLV();
        }


        /*
         * 
         */


        public override void Excluir()
        {
            string aux = oFrmCadFormaPagamento.btnSave.Text;
            oFrmCadFormaPagamento.btnSave.Text = "Excluir";
            base.Excluir();
            oFrmCadFormaPagamento.ConhecaObj(aFormaPagamento, aController_formaPagamento);
            oFrmCadFormaPagamento.Carregatxt();
            oFrmCadFormaPagamento.Bloqueiatxt();
            btnPesquisar.Enabled = false;
            oFrmCadFormaPagamento.ShowDialog(this);
            oFrmCadFormaPagamento.Desbloqueiatxt();
            btnPesquisar.Enabled = true;
            oFrmCadFormaPagamento.btnSave.Text = aux;
            this.CarregaLV();
        }


        /*
         * 
         */


        public override void CarregaLV()
        {
            base.CarregaLV();

            this.listV.Items.Clear();

            var lista = aController_formaPagamento.ListaFormaPagamento();
            foreach (var aFormaPagamento in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aFormaPagamento.Id));
                item.SubItems.Add(aFormaPagamento.Descricao);
                this.listV.Items.Add(item);
            }
        }


        /*
         * 
         */


        public override void Pesquisar()
        {
            this.listV.Items.Clear();

            string termoPesquisa = txtCodigo.Text.Trim().ToLower();

            var listaResultados = new List<formaPagamento>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var aFormaPagamento in aController_formaPagamento.ListaFormaPagamento())
                {
                    if (termoPesquisa == Convert.ToString(aFormaPagamento.Id))
                    {
                        listaResultados.Add(aFormaPagamento);
                    }
                    else if (aFormaPagamento.Descricao.ToLower().Contains(termoPesquisa.ToLower()))
                    {
                        listaResultados.Add(aFormaPagamento);
                    }
                }

            }

            foreach (var aFormaPagamento in listaResultados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aFormaPagamento.Id));
                item.SubItems.Add(aFormaPagamento.Descricao);
                this.listV.Items.Add(item);
            }
        }


        /*
         * 
         */


        public override void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                aFormaPagamento.Id = Convert.ToInt32(linha.SubItems[0].Text);
                aFormaPagamento.Descricao = linha.SubItems[1].Text;
            }
        }
    }
}
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
	public partial class frmConsultaCidade : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroCidade oFrmCadastroCidade;
        cidade aCidade;
        Controller_cidade aController_cidade;

        public frmConsultaCidade()
        {
			InitializeComponent();
		}

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCidade = (cidade)obj;
            aController_cidade = (Controller_cidade)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroCidade.ConhecaObj(aCidade, aController_cidade);
            oFrmCadastroCidade.Limpartxt();
            oFrmCadastroCidade.ShowDialog();
            this.CarregaLV();
        }


        public override void Alterar()
        {
            base.Alterar();
            aController_cidade.CarregaObj(aCidade);
            oFrmCadastroCidade.ConhecaObj(aCidade, aController_cidade);
            oFrmCadastroCidade.Carregatxt();
            oFrmCadastroCidade.ShowDialog();
            this.CarregaLV();
        }

        public override void Pesquisar()
        {
            this.listV.Items.Clear();

            string termoPesquisa = txtCodigo.Text.Trim().ToLower();

            var listaResultados = new List<cidade>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var aCidade in aController_cidade.ListaCidades())
                {
                    if (termoPesquisa == Convert.ToString(aCidade.Id))
                    {
                        listaResultados.Add(aCidade);
                    }
                    else if (aCidade.Nome.ToLower().Contains(termoPesquisa.ToLower()))
                    {
                        listaResultados.Add(aCidade);
                    }
                }

            }

            foreach (var aCidade in listaResultados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Id));
                item.SubItems.Add(aCidade.Nome);
                item.SubItems.Add(Convert.ToString(aCidade.OEstado.Id));
                this.listV.Items.Add(item);
            }
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroCidade.btnSave.Text;
            oFrmCadastroCidade.btnSave.Text = "Excluir";
            aController_cidade.CarregaObj(aCidade);
            oFrmCadastroCidade.ConhecaObj(aCidade, aController_cidade);
            oFrmCadastroCidade.Carregatxt();
            oFrmCadastroCidade.Bloqueiatxt();
            oFrmCadastroCidade.ShowDialog(this);
            oFrmCadastroCidade.Desbloqueiatxt();
            oFrmCadastroCidade.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            this.listV.Items.Clear();
            var lista = aController_cidade.ListaCidades();
            foreach (var aCidade in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Id));
                item.SubItems.Add(aCidade.Nome);
                //item.SubItems.Add(Convert.ToString(aCidade.OEstado.Id));
                item.SubItems.Add(aCidade.OEstado.Nome);
                listV.Items.Add(item);
            }
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroCidade = (frmCadastroCidade)obj;
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                aCidade.Id = Convert.ToInt16(linha.SubItems[0].Text);
                aCidade.Nome = linha.SubItems[1].Text;
                aCidade.OEstado.Id = Convert.ToInt16(linha.SubItems[2].Text);
            }
        }
    }
}

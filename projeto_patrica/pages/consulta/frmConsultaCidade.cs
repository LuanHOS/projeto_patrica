using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaCidade : projeto_patrica.pages.consulta.frmConsulta
    {
        private frmCadastroCidade oFrmCadastroCidade;
        private cidade aCidade;
        private Controller_cidade aController_cidade;

        public frmConsultaCidade() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroCidade = (frmCadastroCidade)obj;
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
            string aux = oFrmCadastroCidade.btnSave.Text;
            oFrmCadastroCidade.btnSave.Text = "Alterar";
            base.Alterar();
            aController_cidade.CarregaObj(aCidade);
            oFrmCadastroCidade.ConhecaObj(aCidade, aController_cidade);
            oFrmCadastroCidade.Carregatxt();
            oFrmCadastroCidade.ShowDialog();
            oFrmCadastroCidade.btnSave.Text = aux;
            this.CarregaLV();
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
            listV.Items.Clear();
            var lista = aController_cidade.ListaCidades();

            foreach (var cidade in lista)
            {
                ListViewItem item = new ListViewItem(cidade.Id.ToString());
                item.SubItems.Add(cidade.Nome);
                item.SubItems.Add(cidade.OEstado.Nome);
                item.Tag = cidade;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();

            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            var listaResultados = new List<cidade>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var cidade in aController_cidade.ListaCidades())
                {
                    if (termoPesquisa == cidade.Id.ToString() ||
                        cidade.Nome.ToUpper().Contains(termoPesquisa) ||
                        cidade.OEstado.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(cidade);
                    }
                }
            }

            foreach (var cidade in listaResultados)
            {
                ListViewItem item = new ListViewItem(cidade.Id.ToString());
                item.SubItems.Add(cidade.Nome);
                item.SubItems.Add(cidade.OEstado.Nome);
                item.Tag = cidade;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                cidade cidadeSelecionada = (cidade)linha.Tag;

                aCidade.Id = cidadeSelecionada.Id;
                aCidade.Nome = cidadeSelecionada.Nome;
                aCidade.OEstado.Id = cidadeSelecionada.OEstado.Id;
                aCidade.OEstado.Nome = cidadeSelecionada.OEstado.Nome;
            }
        }
    }
}

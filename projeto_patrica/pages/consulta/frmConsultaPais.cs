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
	public partial class frmConsultaPais : projeto_patrica.pages.consulta.frmConsulta
	{

        frmCadastroPais oFrmCadastroPais;
        private pais oPais;
        Controller_pais aController_pais;

        public frmConsultaPais() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroPais = (frmCadastroPais)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oPais = (pais)obj;
            aController_pais = (Controller_pais)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroPais.ConhecaObj(oPais, aController_pais);
            oFrmCadastroPais.Limpartxt();
            oFrmCadastroPais.ShowDialog();
            oFrmCadastroPais.Desbloqueiatxt();
            this.CarregaLV();
        }
        public override void Alterar()
        {
            string aux = oFrmCadastroPais.btnSave.Text;
            oFrmCadastroPais.btnSave.Text = "Alterar";
            base.Alterar();
            aController_pais.CarregaObj(oPais);
            oFrmCadastroPais.ConhecaObj(oPais, aController_pais);
            oFrmCadastroPais.Carregatxt();
            oFrmCadastroPais.ShowDialog();
            oFrmCadastroPais.btnSave.Text = aux;
            this.CarregaLV();
        }
        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            var listaResultados = new List<pais>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var oPais in aController_pais.ListaPaises())
                {
                    if (termoPesquisa == Convert.ToString(oPais.Id) ||
                        oPais.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(oPais);
                    }
                }

                foreach (var oPais in listaResultados)
                {
                    ListViewItem item = new ListViewItem(oPais.Id.ToString());
                    item.SubItems.Add(oPais.Nome);
                    item.Tag = oPais;
                    listV.Items.Add(item);
                }
            }
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroPais.btnSave.Text;
            oFrmCadastroPais.btnSave.Text = "Excluir";
            aController_pais.CarregaObj(oPais);
            oFrmCadastroPais.ConhecaObj(oPais, aController_pais);
            oFrmCadastroPais.Carregatxt();
            oFrmCadastroPais.Bloqueiatxt();
            oFrmCadastroPais.ShowDialog(this);
            oFrmCadastroPais.Desbloqueiatxt();
            oFrmCadastroPais.btnSave.Text = aux;
            this.CarregaLV();


        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            this.listV.Items.Clear();
            var lista = aController_pais.ListaPaises();
            foreach (var oPais in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oPais.Id));
                item.SubItems.Add(oPais.Nome);
                item.Tag = oPais;
                this.listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                pais paisSelecionado = (pais)linha.Tag;

                oPais.Id = paisSelecionado.Id;
                oPais.Nome = paisSelecionado.Nome;
            }
        }


        private void frmConsultaPais_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                pais paisSelecionado = (pais)linha.Tag;

                if (!paisSelecionado.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oPais.Id = paisSelecionado.Id;
                oPais.Nome = paisSelecionado.Nome;

                this.Close();
            }
        }

        public override void Sair()
        {
            oPais.Id = 0;
            base.Sair();
        }
    }
}

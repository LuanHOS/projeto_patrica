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
    public partial class frmConsultaEstado : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroEstado oFrmCadastroEstado;
        private estado oEstado;
        Controller_estado aController_estado;

        public frmConsultaEstado() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroEstado = (frmCadastroEstado)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oEstado = (estado)obj;
            aController_estado = (Controller_estado)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroEstado.ConhecaObj(oEstado, aController_estado);
            oFrmCadastroEstado.Limpartxt();
            oFrmCadastroEstado.ShowDialog();
            oFrmCadastroEstado.Desbloqueiatxt();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroEstado.btnSave.Text;
            oFrmCadastroEstado.btnSave.Text = "Alterar";
            base.Alterar();
            aController_estado.CarregaObj(oEstado);
            oFrmCadastroEstado.ConhecaObj(oEstado, aController_estado);
            oFrmCadastroEstado.Carregatxt();
            oFrmCadastroEstado.ShowDialog();
            oFrmCadastroEstado.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroEstado.btnSave.Text;
            oFrmCadastroEstado.btnSave.Text = "Excluir";
            aController_estado.CarregaObj(oEstado);
            oFrmCadastroEstado.ConhecaObj(oEstado, aController_estado);
            oFrmCadastroEstado.Carregatxt();
            oFrmCadastroEstado.Bloqueiatxt();
            oFrmCadastroEstado.ShowDialog(this);
            oFrmCadastroEstado.Desbloqueiatxt();
            oFrmCadastroEstado.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();
            var lista = aController_estado.ListaEstados();

            foreach (var oEstado in lista)
            {
                ListViewItem item = new ListViewItem(oEstado.Id.ToString());
                item.SubItems.Add(oEstado.Nome);
                item.SubItems.Add(oEstado.OPais.Nome);
                item.SubItems.Add(oEstado.Ativo ? "" : "Não");

                item.Tag = oEstado;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();

            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();

            var listaResultados = new List<estado>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var estado in aController_estado.ListaEstados())
                {
                    if (termoPesquisa == Convert.ToString(estado.Id) ||
                        estado.Nome.ToUpper().Contains(termoPesquisa) ||
                        estado.OPais.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(estado);
                    }
                }
            }

            foreach (var estado in listaResultados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(estado.Id));
                item.SubItems.Add(estado.Nome);
                item.SubItems.Add(estado.OPais.Nome);
                item.SubItems.Add(estado.Ativo ? "" : "Não");

                item.Tag = oEstado;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                estado estadoSelecionado = (estado)linha.Tag;

                oEstado.Id = estadoSelecionado.Id;
                oEstado.Nome = estadoSelecionado.Nome;
                oEstado.OPais.Id = estadoSelecionado.OPais.Id;
                oEstado.OPais.Nome = estadoSelecionado.OPais.Nome;
                oEstado.Ativo = estadoSelecionado.Ativo;
            }
        }

        private void frmConsultaEstado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                estado estadoSelecionado = (estado)linha.Tag;

                if (!estadoSelecionado.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oEstado.Id = estadoSelecionado.Id;
                oEstado.Nome = estadoSelecionado.Nome;
                oEstado.OPais.Id = estadoSelecionado.OPais.Id;
                oEstado.OPais.Nome = estadoSelecionado.OPais.Nome;
                oEstado.Ativo = estadoSelecionado.Ativo;

                this.Close();
            }
        }

        public override void Sair()
        {
            oEstado.Id = 0;
            base.Sair();
        }
    }
}

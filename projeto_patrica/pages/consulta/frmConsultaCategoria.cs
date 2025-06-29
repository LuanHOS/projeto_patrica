using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaCategoria : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroCategoria oFrmCadastroCategoria;
        private categoria oCategoria;
        Controller_categoria aController_categoria;

        public frmConsultaCategoria() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroCategoria = (frmCadastroCategoria)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCategoria = (categoria)obj;
            aController_categoria = (Controller_categoria)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroCategoria.ConhecaObj(oCategoria, aController_categoria);
            oFrmCadastroCategoria.Limpartxt();
            oFrmCadastroCategoria.ShowDialog();
            oFrmCadastroCategoria.Desbloqueiatxt();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroCategoria.btnSave.Text;
            oFrmCadastroCategoria.btnSave.Text = "Alterar";
            base.Alterar();
            aController_categoria.CarregaObj(oCategoria);
            oFrmCadastroCategoria.ConhecaObj(oCategoria, aController_categoria);
            oFrmCadastroCategoria.Carregatxt();
            oFrmCadastroCategoria.ShowDialog();
            oFrmCadastroCategoria.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            var listaResultados = new List<categoria>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var oCategoria in aController_categoria.ListaCategorias())
                {
                    if (termoPesquisa == Convert.ToString(oCategoria.Id) ||
                        oCategoria.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(oCategoria);
                    }
                }

                foreach (var oCategoria in listaResultados)
                {
                    ListViewItem item = new ListViewItem(oCategoria.Id.ToString());
                    item.SubItems.Add(oCategoria.Nome);
                    item.SubItems.Add(oCategoria.Descricao);
                    item.SubItems.Add(oCategoria.Ativo ? "Sim" : "Não");

                    item.Tag = oCategoria;
                    listV.Items.Add(item);
                }
            }
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroCategoria.btnSave.Text;
            oFrmCadastroCategoria.btnSave.Text = "Excluir";
            aController_categoria.CarregaObj(oCategoria);
            oFrmCadastroCategoria.ConhecaObj(oCategoria, aController_categoria);
            oFrmCadastroCategoria.Carregatxt();
            oFrmCadastroCategoria.Bloqueiatxt();
            oFrmCadastroCategoria.ShowDialog(this);
            oFrmCadastroCategoria.Desbloqueiatxt();
            oFrmCadastroCategoria.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            this.listV.Items.Clear();
            var lista = aController_categoria.ListaCategorias();
            foreach (var oCategoria in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oCategoria.Id));
                item.SubItems.Add(oCategoria.Nome);
                item.SubItems.Add(oCategoria.Descricao);
                item.SubItems.Add(oCategoria.Ativo ? "Sim" : "Não");

                item.Tag = oCategoria;
                this.listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                categoria categoriaSelecionada = (categoria)linha.Tag;

                oCategoria.Id = categoriaSelecionada.Id;
                oCategoria.Nome = categoriaSelecionada.Nome;
                oCategoria.Descricao = categoriaSelecionada.Descricao;
            }
        }

        private void frmConsultaCategoria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                categoria categoriaSelecionada = (categoria)linha.Tag;

                if (!categoriaSelecionada.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oCategoria.Id = categoriaSelecionada.Id;
                oCategoria.Nome = categoriaSelecionada.Nome;
                oCategoria.Descricao = categoriaSelecionada.Descricao;

                this.Close();
            }
        }

        public override void Sair()
        {
            oCategoria.Id = 0;
            base.Sair();
        }
    }
}
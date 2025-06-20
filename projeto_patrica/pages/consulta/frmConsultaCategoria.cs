using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaCategoria : frmConsulta
    {
        private frmCadastroCategoria oFrmCadastroCategoria;
        private categoria oCategoria;
        private Controller_categoria aController_categoria;

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
            oFrmCadastroCategoria.ConhecaObj(new categoria(), aController_categoria);
            oFrmCadastroCategoria.Desbloqueiatxt();
            oFrmCadastroCategoria.Limpartxt();
            oFrmCadastroCategoria.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            if (listV.SelectedItems.Count > 0)
            {
                string aux = oFrmCadastroCategoria.btnSave.Text;
                oFrmCadastroCategoria.btnSave.Text = "Alterar";
                base.Alterar();
                aController_categoria.CarregaObj(oCategoria);
                oFrmCadastroCategoria.ConhecaObj(oCategoria, aController_categoria);
                oFrmCadastroCategoria.Carregatxt();
                oFrmCadastroCategoria.Desbloqueiatxt();
                oFrmCadastroCategoria.ShowDialog();
                oFrmCadastroCategoria.btnSave.Text = aux;
                this.CarregaLV();
            }
            else
            {
                MessageBox.Show("Selecione um item para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (listV.SelectedItems.Count > 0)
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
            else
            {
                MessageBox.Show("Selecione um item para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();
            List<categoria> lista = aController_categoria.ListaCategorias();

            foreach (var cat in lista)
            {
                ListViewItem item = new ListViewItem(cat.Id.ToString());
                item.SubItems.Add(cat.Nome);
                item.SubItems.Add(cat.Descricao);
                item.Tag = cat;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();
            var resultados = new List<categoria>();
            var listaCompleta = aController_categoria.ListaCategorias();

            if (string.IsNullOrWhiteSpace(termo))
            {
                resultados = listaCompleta;
            }
            else
            {
                foreach (var cat in listaCompleta)
                {
                    if (cat.Id.ToString().Contains(termo) ||
                        cat.Nome.ToUpper().Contains(termo))
                    {
                        resultados.Add(cat);
                    }
                }
            }

            foreach (var cat in resultados)
            {
                ListViewItem item = new ListViewItem(cat.Id.ToString());
                item.SubItems.Add(cat.Nome);
                item.SubItems.Add(cat.Descricao);
                item.Tag = cat;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oCategoria = (categoria)linha.Tag;
            }
        }

        private void frmConsultaCategoria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oCategoria = (categoria)linha.Tag;

                if (!oCategoria.Ativo)
                {
                    MessageBox.Show("Esta categoria está inativa e não pode ser selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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

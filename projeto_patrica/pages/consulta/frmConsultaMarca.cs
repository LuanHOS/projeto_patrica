using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaMarca : projeto_patrica.pages.consulta.frmConsulta
    {

        frmCadastroMarca oFrmCadastroMarca;
        private marca oMarca;
        Controller_marca aController_marca;

        public frmConsultaMarca() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroMarca = (frmCadastroMarca)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oMarca = (marca)obj;
            aController_marca = (Controller_marca)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroMarca.ConhecaObj(oMarca, aController_marca);
            oFrmCadastroMarca.Limpartxt();
            oFrmCadastroMarca.ShowDialog();
            oFrmCadastroMarca.Desbloqueiatxt();
            this.CarregaLV();
        }
        public override void Alterar()
        {
            string aux = oFrmCadastroMarca.btnSave.Text;
            oFrmCadastroMarca.btnSave.Text = "Alterar";
            base.Alterar();
            aController_marca.CarregaObj(oMarca);
            oFrmCadastroMarca.ConhecaObj(oMarca, aController_marca);
            oFrmCadastroMarca.Carregatxt();
            oFrmCadastroMarca.ShowDialog();
            oFrmCadastroMarca.btnSave.Text = aux;
            this.CarregaLV();
        }
        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            var listaResultados = new List<marca>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var oMarca in aController_marca.ListaMarcas())
                {
                    if (termoPesquisa == Convert.ToString(oMarca.Id) ||
                        oMarca.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(oMarca);
                    }
                }

                foreach (var oMarca in listaResultados)
                {
                    ListViewItem item = new ListViewItem(oMarca.Id.ToString());
                    item.SubItems.Add(oMarca.Nome);
                    item.Tag = oMarca;
                    listV.Items.Add(item);
                }
            }
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroMarca.btnSave.Text;
            oFrmCadastroMarca.btnSave.Text = "Excluir";
            aController_marca.CarregaObj(oMarca);
            oFrmCadastroMarca.ConhecaObj(oMarca, aController_marca);
            oFrmCadastroMarca.Carregatxt();
            oFrmCadastroMarca.Bloqueiatxt();
            oFrmCadastroMarca.ShowDialog(this);
            oFrmCadastroMarca.Desbloqueiatxt();
            oFrmCadastroMarca.btnSave.Text = aux;
            this.CarregaLV();


        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            this.listV.Items.Clear();
            var lista = aController_marca.ListaMarcas();
            foreach (var oMarca in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oMarca.Id));
                item.SubItems.Add(oMarca.Nome);
                item.Tag = oMarca;
                this.listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                marca marcaSelecionada = (marca)linha.Tag;

                oMarca.Id = marcaSelecionada.Id;
                oMarca.Nome = marcaSelecionada.Nome;
            }
        }


        private void frmConsultaMarca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                marca marcaSelecionada = (marca)linha.Tag;

                if (!marcaSelecionada.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oMarca.Id = marcaSelecionada.Id;
                oMarca.Nome = marcaSelecionada.Nome;

                this.Close();
            }
        }

        public override void Sair()
        {
            oMarca.Id = 0;
            base.Sair();
        }
    }
}
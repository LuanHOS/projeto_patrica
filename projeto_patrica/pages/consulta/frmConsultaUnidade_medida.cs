using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaUnidade_medida : projeto_patrica.pages.consulta.frmConsulta
    {

        frmCadastroUnidade_medida oFrmCadastroUnidade_medida;
        private unidade_medida oUnidadeMedida;
        Controller_unidade_medida aController_unidade_medida;

        public frmConsultaUnidade_medida() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroUnidade_medida = (frmCadastroUnidade_medida)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oUnidadeMedida = (unidade_medida)obj;
            aController_unidade_medida = (Controller_unidade_medida)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroUnidade_medida.ConhecaObj(oUnidadeMedida, aController_unidade_medida);
            oFrmCadastroUnidade_medida.Limpartxt();
            oFrmCadastroUnidade_medida.ShowDialog();
            oFrmCadastroUnidade_medida.Desbloqueiatxt();
            this.CarregaLV();
        }
        public override void Alterar()
        {
            string aux = oFrmCadastroUnidade_medida.btnSave.Text;
            oFrmCadastroUnidade_medida.btnSave.Text = "Alterar";
            base.Alterar();
            aController_unidade_medida.CarregaObj(oUnidadeMedida);
            oFrmCadastroUnidade_medida.ConhecaObj(oUnidadeMedida, aController_unidade_medida);
            oFrmCadastroUnidade_medida.Carregatxt();
            oFrmCadastroUnidade_medida.ShowDialog();
            oFrmCadastroUnidade_medida.btnSave.Text = aux;
            this.CarregaLV();
        }
        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            var listaResultados = new List<unidade_medida>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var oUnidadeMedida in aController_unidade_medida.ListaUnidadeMedida())
                {
                    if (termoPesquisa == Convert.ToString(oUnidadeMedida.Id) ||
                        oUnidadeMedida.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(oUnidadeMedida);
                    }
                }

                foreach (var oUnidadeMedida in listaResultados)
                {
                    ListViewItem item = new ListViewItem(oUnidadeMedida.Id.ToString());
                    item.SubItems.Add(oUnidadeMedida.Nome);
                    item.SubItems.Add(oUnidadeMedida.Ativo ? "" : "Não");
                    item.SubItems.Add(oUnidadeMedida.Sigla);

                    item.Tag = oUnidadeMedida;
                    listV.Items.Add(item);
                }
            }
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroUnidade_medida.btnSave.Text;
            oFrmCadastroUnidade_medida.btnSave.Text = "Excluir";
            aController_unidade_medida.CarregaObj(oUnidadeMedida);
            oFrmCadastroUnidade_medida.ConhecaObj(oUnidadeMedida, aController_unidade_medida);
            oFrmCadastroUnidade_medida.Carregatxt();
            oFrmCadastroUnidade_medida.Bloqueiatxt();
            oFrmCadastroUnidade_medida.ShowDialog(this);
            oFrmCadastroUnidade_medida.Desbloqueiatxt();
            oFrmCadastroUnidade_medida.btnSave.Text = aux;
            this.CarregaLV();


        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            this.listV.Items.Clear();
            var lista = aController_unidade_medida.ListaUnidadeMedida();
            foreach (var oUnidadeMedida in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oUnidadeMedida.Id));
                item.SubItems.Add(oUnidadeMedida.Nome);
                item.SubItems.Add(oUnidadeMedida.Sigla);
                item.SubItems.Add(oUnidadeMedida.Ativo ? "" : "Não");

                item.Tag = oUnidadeMedida;
                this.listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                unidade_medida unidadeMedidaSelecionada = (unidade_medida)linha.Tag;

                oUnidadeMedida.Id = unidadeMedidaSelecionada.Id;
                oUnidadeMedida.Nome = unidadeMedidaSelecionada.Nome;
                oUnidadeMedida.Sigla = unidadeMedidaSelecionada.Sigla;
            }
        }


        private void frmConsultaUnidade_medida_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                unidade_medida unidadeMedidaSelecionada = (unidade_medida)linha.Tag;

                if (!unidadeMedidaSelecionada.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oUnidadeMedida.Id = unidadeMedidaSelecionada.Id;
                oUnidadeMedida.Nome = unidadeMedidaSelecionada.Nome;
                oUnidadeMedida.Sigla = unidadeMedidaSelecionada.Sigla;

                this.Close();
            }
        }

        public override void Sair()
        {
            oUnidadeMedida.Id = 0;
            base.Sair();
        }
    }
}
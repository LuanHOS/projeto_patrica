using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaProduto : projeto_patrica.pages.consulta.frmConsulta
    {
        private frmCadastroProduto oFrmCadastroProduto;
        private produto oProduto;
        private Controller_produto aController_produto;

        public frmConsultaProduto() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroProduto = (frmCadastroProduto)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oProduto = (produto)obj;
            aController_produto = (Controller_produto)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroProduto.ConhecaObj(oProduto, aController_produto);
            oFrmCadastroProduto.Limpartxt();
            oFrmCadastroProduto.ShowDialog();
            oFrmCadastroProduto.Desbloqueiatxt();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroProduto.btnSave.Text;
            oFrmCadastroProduto.btnSave.Text = "Alterar";
            base.Alterar();
            aController_produto.CarregaObj(oProduto);
            oFrmCadastroProduto.ConhecaObj(oProduto, aController_produto);
            oFrmCadastroProduto.Carregatxt();
            oFrmCadastroProduto.ShowDialog();
            oFrmCadastroProduto.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroProduto.btnSave.Text;
            oFrmCadastroProduto.btnSave.Text = "Excluir";
            aController_produto.CarregaObj(oProduto);
            oFrmCadastroProduto.ConhecaObj(oProduto, aController_produto);
            oFrmCadastroProduto.Carregatxt();
            oFrmCadastroProduto.Bloqueiatxt();
            oFrmCadastroProduto.ShowDialog(this);
            oFrmCadastroProduto.Desbloqueiatxt();
            oFrmCadastroProduto.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();
            var lista = aController_produto.ListaProdutos();

            foreach (var produto in lista)
            {
                ListViewItem item = new ListViewItem(produto.Id.ToString());
                item.SubItems.Add(produto.Nome);
                item.SubItems.Add(produto.CodigoBarras);
                item.SubItems.Add(produto.OMarca.Nome);
                item.SubItems.Add(produto.OCategoria.Nome);
                item.SubItems.Add(produto.ValorVenda.ToString());
                item.SubItems.Add(produto.Estoque.ToString());
                item.Tag = produto;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();

            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            var listaResultados = new List<produto>();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var produto in aController_produto.ListaProdutos())
                {
                    if (produto.Id.ToString() == termoPesquisa ||
                        produto.Nome.ToUpper().Contains(termoPesquisa) ||
                        produto.CodigoBarras.ToUpper().Contains(termoPesquisa) ||
                        produto.OMarca.Nome.ToUpper().Contains(termoPesquisa) ||
                        produto.OCategoria.Nome.ToUpper().Contains(termoPesquisa))
                    {
                        listaResultados.Add(produto);
                    }
                }
            }

            foreach (var produto in listaResultados)
            {
                ListViewItem item = new ListViewItem(produto.Id.ToString());
                item.SubItems.Add(produto.Nome);
                item.SubItems.Add(produto.CodigoBarras);
                item.SubItems.Add(produto.OMarca.Nome);
                item.SubItems.Add(produto.OCategoria.Nome);
                item.SubItems.Add(produto.ValorVenda.ToString("C"));
                item.SubItems.Add(produto.Estoque.ToString());
                item.Tag = produto;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                produto produtoSelecionado = (produto)linha.Tag;

                oProduto.Id = produtoSelecionado.Id;

                aController_produto.CarregaObj(oProduto);
            }
        }

        private void listV_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                produto produtoSelecionado = (produto)linha.Tag;

                if (!produtoSelecionado.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                aController_produto.CarregaObj(produtoSelecionado);
                oProduto = produtoSelecionado;

                this.Close();
            }
        }

        public override void Sair()
        {
            oProduto.Id = 0;
            base.Sair();
        }
    }
}

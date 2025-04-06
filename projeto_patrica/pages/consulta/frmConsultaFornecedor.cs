using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaFornecedor : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroFornecedor oFrmCadastroFornecedor;
        private fornecedor oFornecedor;
        Controller_fornecedor aController_fornecedor;

        public frmConsultaFornecedor()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroFornecedor = (frmCadastroFornecedor)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oFornecedor = (fornecedor)obj;
            aController_fornecedor = (Controller_fornecedor)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroFornecedor.ConhecaObj(oFornecedor, aController_fornecedor);
            oFrmCadastroFornecedor.Limpartxt();
            oFrmCadastroFornecedor.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroFornecedor.btnSave.Text;
            oFrmCadastroFornecedor.btnSave.Text = "Alterar";
            base.Alterar();
            aController_fornecedor.CarregaObj(oFornecedor);
            oFrmCadastroFornecedor.ConhecaObj(oFornecedor, aController_fornecedor);
            oFrmCadastroFornecedor.Carregatxt();
            oFrmCadastroFornecedor.ShowDialog();
            oFrmCadastroFornecedor.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroFornecedor.btnSave.Text;
            oFrmCadastroFornecedor.btnSave.Text = "Excluir";
            aController_fornecedor.CarregaObj(oFornecedor);
            oFrmCadastroFornecedor.ConhecaObj(oFornecedor, aController_fornecedor);
            oFrmCadastroFornecedor.Carregatxt();
            oFrmCadastroFornecedor.Bloqueiatxt();
            oFrmCadastroFornecedor.ShowDialog(this);
            oFrmCadastroFornecedor.Desbloqueiatxt();
            oFrmCadastroFornecedor.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();
            var lista = aController_fornecedor.ListaFornecedores();

            foreach (fornecedor forn in lista)
            {
                ListViewItem item = new ListViewItem(forn.Id.ToString());
                item.SubItems.Add(forn.TipoPessoa.ToString());
                item.SubItems.Add(forn.Nome_razaoSocial);
                item.SubItems.Add(forn.Apelido_nomeFantasia);
                item.SubItems.Add(forn.Genero.ToString());
                item.SubItems.Add(forn.DataNascimento_criacao.ToShortDateString());
                item.SubItems.Add(forn.Cpf_cnpj);
                item.SubItems.Add(forn.Rg_inscricaoEstadual);
                item.SubItems.Add(forn.Email);
                item.SubItems.Add(forn.Telefone);
                item.SubItems.Add(forn.Endereco);
                item.SubItems.Add(forn.Bairro);
                item.SubItems.Add(forn.ACidade.Nome);
                item.SubItems.Add(forn.Cep);
                item.SubItems.Add(forn.Ativo ? "Sim" : "Não");
                item.SubItems.Add(forn.InscricaoEstadualSubstitutoTributario);
                item.Tag = forn;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToLower();
            var resultados = new List<fornecedor>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (fornecedor forn in aController_fornecedor.ListaFornecedores())
            {
                if (forn.Id.ToString() == termo || forn.Nome_razaoSocial.ToLower().Contains(termo) || forn.Cpf_cnpj.ToLower().Contains(termo))
                {
                    resultados.Add(forn);
                }
            }

            foreach (fornecedor forn in resultados)
            {
                ListViewItem item = new ListViewItem(forn.Id.ToString());
                item.SubItems.Add(forn.TipoPessoa.ToString());
                item.SubItems.Add(forn.Nome_razaoSocial);
                item.SubItems.Add(forn.Apelido_nomeFantasia);
                item.SubItems.Add(forn.Genero.ToString());
                item.SubItems.Add(forn.DataNascimento_criacao.ToShortDateString());
                item.SubItems.Add(forn.Cpf_cnpj);
                item.SubItems.Add(forn.Rg_inscricaoEstadual);
                item.SubItems.Add(forn.Email);
                item.SubItems.Add(forn.Telefone);
                item.SubItems.Add(forn.Endereco);
                item.SubItems.Add(forn.Bairro);
                item.SubItems.Add(forn.ACidade.Nome);
                item.SubItems.Add(forn.Cep);
                item.SubItems.Add(forn.Ativo ? "Sim" : "Não");
                item.SubItems.Add(forn.InscricaoEstadualSubstitutoTributario);
                item.Tag = forn;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                fornecedor selecionado = (fornecedor)linha.Tag;

                oFornecedor.Id = selecionado.Id;
                oFornecedor.TipoPessoa = selecionado.TipoPessoa;
                oFornecedor.Nome_razaoSocial = selecionado.Nome_razaoSocial;
                oFornecedor.Apelido_nomeFantasia = selecionado.Apelido_nomeFantasia;
                oFornecedor.DataNascimento_criacao = selecionado.DataNascimento_criacao;
                oFornecedor.Cpf_cnpj = selecionado.Cpf_cnpj;
                oFornecedor.Rg_inscricaoEstadual = selecionado.Rg_inscricaoEstadual;
                oFornecedor.Email = selecionado.Email;
                oFornecedor.Telefone = selecionado.Telefone;
                oFornecedor.Endereco = selecionado.Endereco;
                oFornecedor.Bairro = selecionado.Bairro;
                oFornecedor.ACidade = selecionado.ACidade;
                oFornecedor.Cep = selecionado.Cep;
                oFornecedor.Ativo = selecionado.Ativo;
                oFornecedor.Genero = selecionado.Genero;
                oFornecedor.InscricaoEstadualSubstitutoTributario = selecionado.InscricaoEstadualSubstitutoTributario;
            }
        }
    }
}

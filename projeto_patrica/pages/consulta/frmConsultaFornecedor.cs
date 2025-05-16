using MySqlX.XDevAPI;
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

        public frmConsultaFornecedor() : base()
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
            oFrmCadastroFornecedor.Desbloqueiatxt();
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

            foreach (var oFornecedor in lista)
            {
                ListViewItem item = new ListViewItem(oFornecedor.Id.ToString());
                item.SubItems.Add(oFornecedor.Nome_razaoSocial);
                item.SubItems.Add(oFornecedor.TipoPessoa.ToString());
                item.SubItems.Add(oFornecedor.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oFornecedor.Cpf_cnpj);
                item.SubItems.Add(oFornecedor.Rg_inscricaoEstadual);
                item.SubItems.Add(oFornecedor.Genero == ' ' ? "" : oFornecedor.Genero.ToString());
                item.SubItems.Add(oFornecedor.ACidade.Nome);
                item.SubItems.Add(oFornecedor.Email);
                item.SubItems.Add(oFornecedor.Telefone);
                item.SubItems.Add(oFornecedor.Ativo ? "Sim" : "Não");

                item.Tag = oFornecedor;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();
            var resultados = new List<fornecedor>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (var oFornecedor in aController_fornecedor.ListaFornecedores())
            {
                if (oFornecedor.Id.ToString() == termo ||
                    oFornecedor.Nome_razaoSocial.ToUpper().Contains(termo) ||
                    (oFornecedor.Cpf_cnpj ?? "").ToUpper().Contains(termo) ||
                    oFornecedor.Rg_inscricaoEstadual.ToUpper().Contains(termo))
                {
                    resultados.Add(oFornecedor);
                }
            }

            foreach (var oFornecedor in resultados)
            {
                ListViewItem item = new ListViewItem(oFornecedor.Id.ToString());
                item.SubItems.Add(oFornecedor.Nome_razaoSocial);
                item.SubItems.Add(oFornecedor.TipoPessoa.ToString());
                item.SubItems.Add(oFornecedor.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oFornecedor.Cpf_cnpj);
                item.SubItems.Add(oFornecedor.Rg_inscricaoEstadual);
                item.SubItems.Add(oFornecedor.Genero == ' ' ? "" : oFornecedor.Genero.ToString());
                item.SubItems.Add(oFornecedor.ACidade.Nome);
                item.SubItems.Add(oFornecedor.Email);
                item.SubItems.Add(oFornecedor.Telefone);
                item.SubItems.Add(oFornecedor.Ativo ? "Sim" : "Não");

                item.Tag = oFornecedor;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

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
                oFornecedor.ACondicaoPagamento = selecionado.ACondicaoPagamento;
                oFornecedor.NumeroEndereco = selecionado.NumeroEndereco;
                oFornecedor.ComplementoEndereco = selecionado.ComplementoEndereco;
            }
        }

        private void frmConsultaFornecedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                fornecedor fornecedorSelecionado = (fornecedor)linha.Tag;

                if (!fornecedorSelecionado.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oFornecedor.Id = fornecedorSelecionado.Id;
                oFornecedor.TipoPessoa = fornecedorSelecionado.TipoPessoa;
                oFornecedor.Nome_razaoSocial = fornecedorSelecionado.Nome_razaoSocial;
                oFornecedor.Apelido_nomeFantasia = fornecedorSelecionado.Apelido_nomeFantasia;
                oFornecedor.DataNascimento_criacao = fornecedorSelecionado.DataNascimento_criacao;
                oFornecedor.Cpf_cnpj = fornecedorSelecionado.Cpf_cnpj;
                oFornecedor.Rg_inscricaoEstadual = fornecedorSelecionado.Rg_inscricaoEstadual;
                oFornecedor.Email = fornecedorSelecionado.Email;
                oFornecedor.Telefone = fornecedorSelecionado.Telefone;
                oFornecedor.Endereco = fornecedorSelecionado.Endereco;
                oFornecedor.Bairro = fornecedorSelecionado.Bairro;
                oFornecedor.ACidade = fornecedorSelecionado.ACidade;
                oFornecedor.Cep = fornecedorSelecionado.Cep;
                oFornecedor.Ativo = fornecedorSelecionado.Ativo;
                oFornecedor.Genero = fornecedorSelecionado.Genero;
                oFornecedor.ACondicaoPagamento = fornecedorSelecionado.ACondicaoPagamento;
                oFornecedor.NumeroEndereco = fornecedorSelecionado.NumeroEndereco;
                oFornecedor.ComplementoEndereco = fornecedorSelecionado.ComplementoEndereco;

                this.Close();
            }
        }

        public override void Sair()
        {
            oFornecedor.Id = 0;
            base.Sair();
        }
    }
}

using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaTransportadora : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroTransportadora oFrmCadastroTransportadora;
        private transportadora oTransportadora;
        Controller_transportadora aController_transportadora;

        public frmConsultaTransportadora() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroTransportadora = (frmCadastroTransportadora)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oTransportadora = (transportadora)obj;
            aController_transportadora = (Controller_transportadora)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroTransportadora.ConhecaObj(oTransportadora, aController_transportadora);
            oFrmCadastroTransportadora.Limpartxt();
            oFrmCadastroTransportadora.ShowDialog();
            oFrmCadastroTransportadora.Desbloqueiatxt();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroTransportadora.btnSave.Text;
            oFrmCadastroTransportadora.btnSave.Text = "Alterar";
            base.Alterar();
            aController_transportadora.CarregaObj(oTransportadora);
            oFrmCadastroTransportadora.ConhecaObj(oTransportadora, aController_transportadora);
            oFrmCadastroTransportadora.Carregatxt();
            oFrmCadastroTransportadora.ShowDialog();
            oFrmCadastroTransportadora.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroTransportadora.btnSave.Text;
            oFrmCadastroTransportadora.btnSave.Text = "Excluir";
            aController_transportadora.CarregaObj(oTransportadora);
            oFrmCadastroTransportadora.ConhecaObj(oTransportadora, aController_transportadora);
            oFrmCadastroTransportadora.Carregatxt();
            oFrmCadastroTransportadora.Bloqueiatxt();
            oFrmCadastroTransportadora.ShowDialog(this);
            oFrmCadastroTransportadora.Desbloqueiatxt();
            oFrmCadastroTransportadora.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();
            var lista = aController_transportadora.ListaTransportadoras();

            foreach (var oTransportadora in lista)
            {
                ListViewItem item = new ListViewItem(oTransportadora.Id.ToString());
                item.SubItems.Add(oTransportadora.Nome_razaoSocial);
                item.SubItems.Add(oTransportadora.TipoPessoa == 'F' ? "FÍSICA" : oTransportadora.TipoPessoa == 'J' ? "JURÍDICA" : "");
                item.SubItems.Add(oTransportadora.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oTransportadora.Cpf_cnpj);
                item.SubItems.Add(oTransportadora.Rg_inscricaoEstadual);
                item.SubItems.Add(oTransportadora.Genero == 'M' ? "MASCULINO" : oTransportadora.Genero == 'F' ? "FEMININO" : "");
                item.SubItems.Add(oTransportadora.ACidade.Nome);
                item.SubItems.Add(oTransportadora.Email);
                item.SubItems.Add(oTransportadora.Telefone);
                item.SubItems.Add(oTransportadora.Ativo ? "" : "Não");

                item.Tag = oTransportadora;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();
            var resultados = new List<transportadora>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (var oTransportadora in aController_transportadora.ListaTransportadoras())
            {
                if (oTransportadora.Id.ToString() == termo ||
                    oTransportadora.Nome_razaoSocial.ToUpper().Contains(termo) ||
                    (oTransportadora.Cpf_cnpj ?? "").ToUpper().Contains(termo) ||
                    oTransportadora.Rg_inscricaoEstadual.ToUpper().Contains(termo))
                {
                    resultados.Add(oTransportadora);
                }
            }

            foreach (var oTransportadora in resultados)
            {
                ListViewItem item = new ListViewItem(oTransportadora.Id.ToString());
                item.SubItems.Add(oTransportadora.Nome_razaoSocial);
                item.SubItems.Add(oTransportadora.TipoPessoa.ToString());
                item.SubItems.Add(oTransportadora.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oTransportadora.Cpf_cnpj);
                item.SubItems.Add(oTransportadora.Rg_inscricaoEstadual);
                item.SubItems.Add(oTransportadora.Genero == ' ' ? "" : oTransportadora.Genero.ToString());
                item.SubItems.Add(oTransportadora.ACidade.Nome);
                item.SubItems.Add(oTransportadora.Email);
                item.SubItems.Add(oTransportadora.Telefone);
                item.SubItems.Add(oTransportadora.Ativo ? "" : "Não");

                item.Tag = oTransportadora;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                transportadora selecionado = (transportadora)linha.Tag;

                oTransportadora.Id = selecionado.Id;
                oTransportadora.TipoPessoa = selecionado.TipoPessoa;
                oTransportadora.Nome_razaoSocial = selecionado.Nome_razaoSocial;
                oTransportadora.Apelido_nomeFantasia = selecionado.Apelido_nomeFantasia;
                oTransportadora.DataNascimento_criacao = selecionado.DataNascimento_criacao;
                oTransportadora.Cpf_cnpj = selecionado.Cpf_cnpj;
                oTransportadora.Rg_inscricaoEstadual = selecionado.Rg_inscricaoEstadual;
                oTransportadora.Email = selecionado.Email;
                oTransportadora.Telefone = selecionado.Telefone;
                oTransportadora.Endereco = selecionado.Endereco;
                oTransportadora.Bairro = selecionado.Bairro;
                oTransportadora.ACidade = selecionado.ACidade;
                oTransportadora.Cep = selecionado.Cep;
                oTransportadora.Ativo = selecionado.Ativo;
                oTransportadora.Genero = selecionado.Genero;
                oTransportadora.ACondicaoPagamento = selecionado.ACondicaoPagamento;
                oTransportadora.NumeroEndereco = selecionado.NumeroEndereco;
                oTransportadora.ComplementoEndereco = selecionado.ComplementoEndereco;
            }
        }

        private void frmConsultaTransportadora_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                transportadora transportadoraSelecionada = (transportadora)linha.Tag;

                if (!transportadoraSelecionada.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oTransportadora.Id = transportadoraSelecionada.Id;
                oTransportadora.TipoPessoa = transportadoraSelecionada.TipoPessoa;
                oTransportadora.Nome_razaoSocial = transportadoraSelecionada.Nome_razaoSocial;
                oTransportadora.Apelido_nomeFantasia = transportadoraSelecionada.Apelido_nomeFantasia;
                oTransportadora.DataNascimento_criacao = transportadoraSelecionada.DataNascimento_criacao;
                oTransportadora.Cpf_cnpj = transportadoraSelecionada.Cpf_cnpj;
                oTransportadora.Rg_inscricaoEstadual = transportadoraSelecionada.Rg_inscricaoEstadual;
                oTransportadora.Email = transportadoraSelecionada.Email;
                oTransportadora.Telefone = transportadoraSelecionada.Telefone;
                oTransportadora.Endereco = transportadoraSelecionada.Endereco;
                oTransportadora.Bairro = transportadoraSelecionada.Bairro;
                oTransportadora.ACidade = transportadoraSelecionada.ACidade;
                oTransportadora.Cep = transportadoraSelecionada.Cep;
                oTransportadora.Ativo = transportadoraSelecionada.Ativo;
                oTransportadora.Genero = transportadoraSelecionada.Genero;
                oTransportadora.ACondicaoPagamento = transportadoraSelecionada.ACondicaoPagamento;
                oTransportadora.NumeroEndereco = transportadoraSelecionada.NumeroEndereco;
                oTransportadora.ComplementoEndereco = transportadoraSelecionada.ComplementoEndereco;

                this.Close();
            }
        }

        public override void Sair()
        {
            oTransportadora.Id = 0;
            base.Sair();
        }
    }
}
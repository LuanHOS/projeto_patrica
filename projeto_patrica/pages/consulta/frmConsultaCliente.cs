using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaCliente : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroCliente oFrmCadastroCliente;
        private cliente oCliente;
        Controller_cliente aController_cliente;

        public frmConsultaCliente()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroCliente = (frmCadastroCliente)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCliente = (cliente)obj;
            aController_cliente = (Controller_cliente)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroCliente.ConhecaObj(oCliente, aController_cliente);
            oFrmCadastroCliente.Limpartxt();
            oFrmCadastroCliente.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroCliente.btnSave.Text;
            oFrmCadastroCliente.btnSave.Text = "Alterar";
            base.Alterar();
            aController_cliente.CarregaObj(oCliente);
            oFrmCadastroCliente.ConhecaObj(oCliente, aController_cliente);
            oFrmCadastroCliente.Carregatxt();
            oFrmCadastroCliente.ShowDialog();
            oFrmCadastroCliente.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroCliente.btnSave.Text;
            oFrmCadastroCliente.btnSave.Text = "Excluir";
            aController_cliente.CarregaObj(oCliente);
            oFrmCadastroCliente.ConhecaObj(oCliente, aController_cliente);
            oFrmCadastroCliente.Carregatxt();
            oFrmCadastroCliente.Bloqueiatxt();
            oFrmCadastroCliente.ShowDialog(this);
            oFrmCadastroCliente.Desbloqueiatxt();
            oFrmCadastroCliente.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();

            var lista = aController_cliente.ListaClientes();

            foreach (var oCliente in lista)
            {
                ListViewItem item = new ListViewItem(oCliente.Id.ToString());
                item.SubItems.Add(oCliente.Nome_razaoSocial);
                item.SubItems.Add(oCliente.TipoPessoa.ToString());
                item.SubItems.Add(oCliente.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oCliente.Cpf_cnpj);
                item.SubItems.Add(oCliente.Rg_inscricaoEstadual);
                item.SubItems.Add(oCliente.Genero == ' ' ? "" : oCliente.Genero.ToString());
                item.SubItems.Add(oCliente.ACidade.Nome);
                item.SubItems.Add(oCliente.Email);
                item.SubItems.Add(oCliente.Telefone);
                item.SubItems.Add(oCliente.Ativo ? "Sim" : "Não");

                item.Tag = oCliente;
                listV.Items.Add(item);
            }
        }


        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();
            var resultados = new List<cliente>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (var oCliente in aController_cliente.ListaClientes())
            {
                if (oCliente.Id.ToString() == termo ||
                    oCliente.Nome_razaoSocial.ToUpper().Contains(termo) ||
                    oCliente.Cpf_cnpj.ToUpper().Contains(termo) ||
                    oCliente.ACondicaoPagamento.Descricao.ToUpper().Contains(termo))
                {
                    resultados.Add(oCliente);
                }
            }

            foreach (var oCliente in resultados)
            {
                ListViewItem item = new ListViewItem(oCliente.Id.ToString());
                item.SubItems.Add(oCliente.Nome_razaoSocial);
                item.SubItems.Add(oCliente.TipoPessoa.ToString());
                item.SubItems.Add(oCliente.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oCliente.Cpf_cnpj);
                item.SubItems.Add(oCliente.Rg_inscricaoEstadual);
                item.SubItems.Add(oCliente.Genero == ' ' ? "" : oCliente.Genero.ToString());
                item.SubItems.Add(oCliente.ACidade.Nome);
                item.SubItems.Add(oCliente.Email);
                item.SubItems.Add(oCliente.Telefone);
                item.SubItems.Add(oCliente.Ativo ? "Sim" : "Não");

                item.Tag = oCliente;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                cliente selecionado = (cliente)linha.Tag;

                oCliente.Id = selecionado.Id;
                oCliente.TipoPessoa = selecionado.TipoPessoa;
                oCliente.Nome_razaoSocial = selecionado.Nome_razaoSocial;
                oCliente.Apelido_nomeFantasia = selecionado.Apelido_nomeFantasia;
                oCliente.DataNascimento_criacao = selecionado.DataNascimento_criacao;
                oCliente.Cpf_cnpj = selecionado.Cpf_cnpj;
                oCliente.Rg_inscricaoEstadual = selecionado.Rg_inscricaoEstadual;
                oCliente.Email = selecionado.Email;
                oCliente.Telefone = selecionado.Telefone;
                oCliente.Endereco = selecionado.Endereco;
                oCliente.Bairro = selecionado.Bairro;
                oCliente.ACidade = selecionado.ACidade;
                oCliente.Cep = selecionado.Cep;
                oCliente.Ativo = selecionado.Ativo;
                oCliente.Genero = selecionado.Genero;
                oCliente.ACondicaoPagamento = selecionado.ACondicaoPagamento;
            }
        }
    }
}

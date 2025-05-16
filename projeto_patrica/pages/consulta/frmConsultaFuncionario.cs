using MySqlX.XDevAPI;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaFuncionario : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroFuncionario oFrmCadastroFuncionario;
        private funcionario oFuncionario;
        private Controller_funcionario aController_funcionario;

        public frmConsultaFuncionario() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroFuncionario = (frmCadastroFuncionario)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oFuncionario = (funcionario)obj;
            aController_funcionario = (Controller_funcionario)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroFuncionario.ConhecaObj(oFuncionario, aController_funcionario);
            oFrmCadastroFuncionario.Limpartxt();
            oFrmCadastroFuncionario.ShowDialog();
            oFrmCadastroFuncionario.Desbloqueiatxt();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadastroFuncionario.btnSave.Text;
            oFrmCadastroFuncionario.btnSave.Text = "Alterar";
            base.Alterar();
            aController_funcionario.CarregaObj(oFuncionario);
            oFrmCadastroFuncionario.ConhecaObj(oFuncionario, aController_funcionario);
            oFrmCadastroFuncionario.Carregatxt();
            oFrmCadastroFuncionario.ShowDialog();
            oFrmCadastroFuncionario.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroFuncionario.btnSave.Text;
            oFrmCadastroFuncionario.btnSave.Text = "Excluir";
            aController_funcionario.CarregaObj(oFuncionario);
            oFrmCadastroFuncionario.ConhecaObj(oFuncionario, aController_funcionario);
            oFrmCadastroFuncionario.Carregatxt();
            oFrmCadastroFuncionario.Bloqueiatxt();
            oFrmCadastroFuncionario.ShowDialog();
            oFrmCadastroFuncionario.Desbloqueiatxt();
            oFrmCadastroFuncionario.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();

            var lista = aController_funcionario.ListaFuncionarios();
            foreach (var oFuncionario in lista)
            {
                ListViewItem item = new ListViewItem(oFuncionario.Id.ToString());
                item.SubItems.Add(oFuncionario.Matricula);
                item.SubItems.Add(oFuncionario.Nome_razaoSocial);
                item.SubItems.Add(oFuncionario.Cargo);
                item.SubItems.Add("R$ " + oFuncionario.Salario.ToString("F2"));
                item.SubItems.Add(oFuncionario.Turno);
                item.SubItems.Add(oFuncionario.CargaHoraria.ToString());
                item.SubItems.Add(oFuncionario.Cpf_cnpj);
                item.SubItems.Add(oFuncionario.Rg_inscricaoEstadual);
                item.SubItems.Add(oFuncionario.Genero == 'M' ? "MASCULINO" : oFuncionario.Genero == 'F' ? "FEMININO" : "");
                item.SubItems.Add(oFuncionario.ACidade.Nome);
                item.SubItems.Add(oFuncionario.Email);
                item.SubItems.Add(oFuncionario.Telefone);
                item.SubItems.Add(oFuncionario.DataAdmissao == DateTime.MinValue ? "" : oFuncionario.DataAdmissao.ToShortDateString());
                item.SubItems.Add(oFuncionario.DataDemissao.HasValue ? oFuncionario.DataDemissao.Value.ToShortDateString() : "");
                item.SubItems.Add(oFuncionario.Ativo ? "Sim" : "Não");

                item.Tag = oFuncionario;
                listV.Items.Add(item);
            }
        }


        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();

            var listaResultados = new List<funcionario>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (var oFuncionario in aController_funcionario.ListaFuncionarios())
            {
                if (oFuncionario.Id.ToString() == termo ||
                    oFuncionario.Nome_razaoSocial.ToUpper().Contains(termo) ||
                    (oFuncionario.Cpf_cnpj ?? "").ToUpper().Contains(termo) ||
                    oFuncionario.Rg_inscricaoEstadual.ToUpper().Contains(termo) ||
                    oFuncionario.Matricula.ToUpper().Contains(termo) ||
                    oFuncionario.Cargo.ToUpper().Contains(termo))
                {
                    listaResultados.Add(oFuncionario);
                }
            }

            foreach (var oFuncionario in listaResultados)
            {
                ListViewItem item = new ListViewItem(oFuncionario.Id.ToString());
                item.SubItems.Add(oFuncionario.Matricula);
                item.SubItems.Add(oFuncionario.Nome_razaoSocial);
                item.SubItems.Add(oFuncionario.Cargo);
                item.SubItems.Add(oFuncionario.Salario.ToString("F2"));
                item.SubItems.Add(oFuncionario.Turno);
                item.SubItems.Add(oFuncionario.CargaHoraria.ToString());
                item.SubItems.Add(oFuncionario.Cpf_cnpj);
                item.SubItems.Add(oFuncionario.Rg_inscricaoEstadual);
                item.SubItems.Add(oFuncionario.Genero == ' ' ? "" : oFuncionario.Genero.ToString());
                item.SubItems.Add(oFuncionario.ACidade.Nome);
                item.SubItems.Add(oFuncionario.Email);
                item.SubItems.Add(oFuncionario.Telefone);
                item.SubItems.Add(oFuncionario.DataAdmissao == DateTime.MinValue ? "" : oFuncionario.DataAdmissao.ToShortDateString());
                item.SubItems.Add(oFuncionario.Ativo ? "Sim" : "Não");

                item.Tag = oFuncionario;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                funcionario selecionado = (funcionario)linha.Tag;

                oFuncionario.Id = selecionado.Id;
                oFuncionario.TipoPessoa = selecionado.TipoPessoa;
                oFuncionario.Nome_razaoSocial = selecionado.Nome_razaoSocial;
                oFuncionario.Apelido_nomeFantasia = selecionado.Apelido_nomeFantasia;
                oFuncionario.DataNascimento_criacao = selecionado.DataNascimento_criacao;
                oFuncionario.Cpf_cnpj = selecionado.Cpf_cnpj;
                oFuncionario.Rg_inscricaoEstadual = selecionado.Rg_inscricaoEstadual;
                oFuncionario.Email = selecionado.Email;
                oFuncionario.Telefone = selecionado.Telefone;
                oFuncionario.Endereco = selecionado.Endereco;
                oFuncionario.Bairro = selecionado.Bairro;
                oFuncionario.ACidade = selecionado.ACidade;
                oFuncionario.Cep = selecionado.Cep;
                oFuncionario.Ativo = selecionado.Ativo;
                oFuncionario.Genero = selecionado.Genero;
                oFuncionario.Matricula = selecionado.Matricula;
                oFuncionario.Cargo = selecionado.Cargo;
                oFuncionario.Salario = selecionado.Salario;
                oFuncionario.DataAdmissao = selecionado.DataAdmissao;
                oFuncionario.Turno = selecionado.Turno;
                oFuncionario.CargaHoraria = selecionado.CargaHoraria;
            }
        }

        private void frmConsultaFuncionario_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                funcionario funcionarioSelecionado = (funcionario)linha.Tag;

                if (!funcionarioSelecionado.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                oFuncionario.Id = funcionarioSelecionado.Id;
                oFuncionario.TipoPessoa = funcionarioSelecionado.TipoPessoa;
                oFuncionario.Nome_razaoSocial = funcionarioSelecionado.Nome_razaoSocial;
                oFuncionario.Apelido_nomeFantasia = funcionarioSelecionado.Apelido_nomeFantasia;
                oFuncionario.DataNascimento_criacao = funcionarioSelecionado.DataNascimento_criacao;
                oFuncionario.Cpf_cnpj = funcionarioSelecionado.Cpf_cnpj;
                oFuncionario.Rg_inscricaoEstadual = funcionarioSelecionado.Rg_inscricaoEstadual;
                oFuncionario.Email = funcionarioSelecionado.Email;
                oFuncionario.Telefone = funcionarioSelecionado.Telefone;
                oFuncionario.Endereco = funcionarioSelecionado.Endereco;
                oFuncionario.Bairro = funcionarioSelecionado.Bairro;
                oFuncionario.ACidade = funcionarioSelecionado.ACidade;
                oFuncionario.Cep = funcionarioSelecionado.Cep;
                oFuncionario.Ativo = funcionarioSelecionado.Ativo;
                oFuncionario.Genero = funcionarioSelecionado.Genero;
                oFuncionario.Matricula = funcionarioSelecionado.Matricula;
                oFuncionario.Cargo = funcionarioSelecionado.Cargo;
                oFuncionario.Salario = funcionarioSelecionado.Salario;
                oFuncionario.DataAdmissao = funcionarioSelecionado.DataAdmissao;
                oFuncionario.Turno = funcionarioSelecionado.Turno;
                oFuncionario.CargaHoraria = funcionarioSelecionado.CargaHoraria;

                this.Close();
            }
        }

        public override void Sair()
        {
            oFuncionario.Id = 0;
            base.Sair();
        }
    }
}

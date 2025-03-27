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

        public frmConsultaFuncionario()
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
            oFrmCadastroFuncionario.ShowDialog(this);
            oFrmCadastroFuncionario.Desbloqueiatxt();
            oFrmCadastroFuncionario.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();

            List<funcionario> lista = aController_funcionario.ListaFuncionarios();
            foreach (funcionario f in lista)
            {
                ListViewItem item = new ListViewItem(f.Id.ToString());
                item.SubItems.Add(f.TipoPessoa.ToString());
                item.SubItems.Add(f.Nome_razaoSocial);
                item.SubItems.Add(f.Apelido_nomeFantasia);
                item.SubItems.Add(f.DataNascimento_criacao == DateTime.MinValue ? "" : f.DataNascimento_criacao.ToShortDateString());
                item.SubItems.Add(f.Cpf_cnpj);
                item.SubItems.Add(f.Rg_inscricaoEstadual);
                item.SubItems.Add(f.Email);
                item.SubItems.Add(f.Telefone);
                item.SubItems.Add(f.Endereco);
                item.SubItems.Add(f.Bairro);
                item.SubItems.Add(f.ACidade.Nome);
                item.SubItems.Add(f.Cep);
                item.SubItems.Add(f.Ativo ? "Sim" : "Não");
                item.SubItems.Add(f.Matricula.ToString());
                item.SubItems.Add(f.Cargo);
                item.SubItems.Add(f.Salario.ToString("F2"));
                item.SubItems.Add(f.DataAdmissao == DateTime.MinValue ? "" : f.DataAdmissao.ToShortDateString());
                item.SubItems.Add(f.Turno);
                item.SubItems.Add(f.CargaHoraria.ToString());
                item.SubItems.Add(string.IsNullOrWhiteSpace(f.Genero.ToString().Trim()) ? "" : f.Genero.ToString());

                item.Tag = f;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToLower();

            var listaResultados = new List<funcionario>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
            }
            else
            {
                foreach (var f in aController_funcionario.ListaFuncionarios())
                {
                    if (f.Id.ToString() == termo ||
                        f.Nome_razaoSocial.ToLower().Contains(termo) ||
                        f.Cargo.ToLower().Contains(termo))
                    {
                        listaResultados.Add(f);
                    }
                }
            }

            foreach (funcionario f in listaResultados)
            {
                ListViewItem item = new ListViewItem(f.Id.ToString());
                item.SubItems.Add(f.TipoPessoa.ToString());
                item.SubItems.Add(f.Nome_razaoSocial);
                item.SubItems.Add(f.Apelido_nomeFantasia);
                item.SubItems.Add(f.DataNascimento_criacao == DateTime.MinValue ? "" : f.DataNascimento_criacao.ToShortDateString());
                item.SubItems.Add(f.Cpf_cnpj);
                item.SubItems.Add(f.Rg_inscricaoEstadual);
                item.SubItems.Add(f.Email);
                item.SubItems.Add(f.Telefone);
                item.SubItems.Add(f.Endereco);
                item.SubItems.Add(f.Bairro);
                item.SubItems.Add(f.ACidade.Nome);
                item.SubItems.Add(f.Cep);
                item.SubItems.Add(f.Ativo ? "Sim" : "Não");
                item.SubItems.Add(f.Matricula.ToString());
                item.SubItems.Add(f.Cargo);
                item.SubItems.Add(f.Salario.ToString("F2"));
                item.SubItems.Add(f.DataAdmissao == DateTime.MinValue ? "" : f.DataAdmissao.ToShortDateString());
                item.SubItems.Add(f.Turno);
                item.SubItems.Add(f.CargaHoraria.ToString());
                item.SubItems.Add(string.IsNullOrWhiteSpace(f.Genero.ToString().Trim()) ? "" : f.Genero.ToString());

                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                funcionario selecionado = (funcionario)listV.SelectedItems[0].Tag;
                oFuncionario.Id = selecionado.Id;
                oFuncionario.Nome_razaoSocial = selecionado.Nome_razaoSocial;
                oFuncionario.ACidade.Id = selecionado.ACidade.Id;
                oFuncionario.ACidade.Nome = selecionado.ACidade.Nome;
            }
        }
    }
}

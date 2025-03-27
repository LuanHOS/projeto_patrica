using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroFuncionario : frmCadastroPessoa
    {
        private funcionario oFuncionario;
        private Controller_funcionario aController_funcionario;
        private frmConsultaCidade oFrmConsultaCidade;

        public frmCadastroFuncionario()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndex = 0; // Pessoa Física
            comboBoxTipo.Enabled = false;   // Tipo fixo 'F'
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oFuncionario = (funcionario)obj;
            aController_funcionario = (Controller_funcionario)ctrl;
        }

        public void setConsultaCidade(frmConsultaCidade consulta)
        {
            oFrmConsultaCidade = consulta;
        }

        public override void Salvar()
        {
            base.Salvar();

            if (txtNomeRazaoSocial.Text == "")
            {
                MessageBox.Show("Campo obrigatório: Nome");
                txtNomeRazaoSocial.Focus();
                return;
            }

            if (oFuncionario.ACidade == null || oFuncionario.ACidade.Id == 0)
            {
                MessageBox.Show("Selecione uma cidade.");
                return;
            }

            oFuncionario.Id = Convert.ToInt16(txtCodigo.Text);
            oFuncionario.TipoPessoa = 'F';
            oFuncionario.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oFuncionario.Apelido_nomeFantasia = txtApelidoNomeFantasia.Text;
            oFuncionario.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oFuncionario.Cpf_cnpj = txtCpfCnpj.Text;
            oFuncionario.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oFuncionario.Email = txtEmail.Text;
            oFuncionario.Telefone = txtTelefone.Text;
            oFuncionario.Endereco = txtEndereco.Text;
            oFuncionario.Bairro = txtBairro.Text;
            oFuncionario.Cep = txtCep.Text;
            oFuncionario.Ativo = checkBoxAtivo.Checked;
            oFuncionario.Genero = comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F';

            oFuncionario.Matricula = Convert.ToInt32(txtMatricula.Text);
            oFuncionario.Cargo = txtCargo.Text;
            oFuncionario.Salario = Convert.ToSingle(txtSalario.Text);
            oFuncionario.DataAdmissao = dtpDataAdmissao.Value;
            oFuncionario.Turno = txtTurno.Text;
            oFuncionario.CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);

            if (btnSave.Text == "Excluir")
            {
                DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    txtCodigo.Text = aController_funcionario.Excluir(oFuncionario);
                    MessageBox.Show("O funcionário foi excluído com sucesso.");
                    Sair();
                }
            }
            else if (btnSave.Text == "Alterar")
            {
                txtCodigo.Text = aController_funcionario.Salvar(oFuncionario);
                MessageBox.Show("Funcionário alterado com sucesso.");
            }
            else
            {
                txtCodigo.Text = aController_funcionario.Salvar(oFuncionario);
                MessageBox.Show("Funcionário salvo com o código " + txtCodigo.Text);
            }
        }

        public override void Limpartxt()
        {
            base.Limpartxt();

            txtCodigo.Text = "0";
            txtMatricula.Clear();
            txtCargo.Clear();
            txtSalario.Clear();
            dtpDataAdmissao.Value = DateTime.Today;
            txtTurno.Clear();
            txtCargaHoraria.Clear();

            txtCidade.Clear();
            oFuncionario.ACidade = new cidade();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oFuncionario.Id.ToString();
            txtNomeRazaoSocial.Text = oFuncionario.Nome_razaoSocial;
            txtApelidoNomeFantasia.Text = oFuncionario.Apelido_nomeFantasia;
            txtCpfCnpj.Text = oFuncionario.Cpf_cnpj;
            txtRgInscEstadual.Text = oFuncionario.Rg_inscricaoEstadual;
            txtEmail.Text = oFuncionario.Email;
            txtTelefone.Text = oFuncionario.Telefone;
            txtEndereco.Text = oFuncionario.Endereco;
            txtBairro.Text = oFuncionario.Bairro;
            txtCep.Text = oFuncionario.Cep;
            txtCidade.Text = oFuncionario.ACidade.Nome;

            dtpDataNascimentoCriacao.Value = (oFuncionario.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate) ? dtpDataNascimentoCriacao.MinDate : oFuncionario.DataNascimento_criacao;
            comboBoxGenero.SelectedIndex = oFuncionario.Genero == 'M' ? 0 : 1;
            checkBoxAtivo.Checked = oFuncionario.Ativo;

            txtMatricula.Text = oFuncionario.Matricula.ToString();
            txtCargo.Text = oFuncionario.Cargo;
            txtSalario.Text = oFuncionario.Salario.ToString("F2");
            dtpDataAdmissao.Value = (oFuncionario.DataAdmissao < dtpDataAdmissao.MinDate) ? dtpDataAdmissao.MinDate : oFuncionario.DataAdmissao;
            txtTurno.Text = oFuncionario.Turno;
            txtCargaHoraria.Text = oFuncionario.CargaHoraria.ToString();
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            txtMatricula.Enabled = false;
            txtCargo.Enabled = false;
            txtSalario.Enabled = false;
            dtpDataAdmissao.Enabled = false;
            txtTurno.Enabled = false;
            txtCargaHoraria.Enabled = false;
            btnPesquisarCidade.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            txtMatricula.Enabled = true;
            txtCargo.Enabled = true;
            txtSalario.Enabled = true;
            dtpDataAdmissao.Enabled = true;
            txtTurno.Enabled = true;
            txtCargaHoraria.Enabled = true;
            btnPesquisarCidade.Enabled = true;
        }

        private void btnPesquisarCidade_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCidade == null)
                oFrmConsultaCidade = new frmConsultaCidade();

            cidade cidade = new cidade();
            Controller_cidade controller = new Controller_cidade();
            oFrmConsultaCidade.ConhecaObj(cidade, controller);
            oFrmConsultaCidade.ShowDialog();

            if (cidade.Id != 0)
            {
                oFuncionario.ACidade = cidade;
                txtCidade.Text = cidade.Nome;
            }
        }
    }
}

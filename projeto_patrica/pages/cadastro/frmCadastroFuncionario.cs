using MySqlX.XDevAPI;
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
        private bool isEstrangeiro = false;

        public frmCadastroFuncionario() : base()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndex = 0;
            comboBoxTipo.Enabled = false;
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
            if (btnSave.Text == "Excluir")
            {
                DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    aController_funcionario.Excluir(oFuncionario);
                    MessageBox.Show("O funcionário foi excluído com sucesso.");
                    Sair();
                    return;
                }
            }

            if (!ValidacaoCampos())
                return;

            if (
                string.IsNullOrWhiteSpace(txtNomeRazaoSocial.Text) ||
                comboBoxGenero.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtCidade.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtBairro.Text) ||
                (!isEstrangeiro && string.IsNullOrWhiteSpace(txtCep.Text)) || // obrigatório só se for brasileiro
                (!isEstrangeiro && string.IsNullOrWhiteSpace(txtCpfCnpj.Text)) || // obrigatório só se for brasileiro
                string.IsNullOrWhiteSpace(txtRgInscEstadual.Text) ||
                dtpDataNascimentoCriacao.Value <= dtpDataNascimentoCriacao.MinDate ||
                string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                string.IsNullOrWhiteSpace(txtCargo.Text) ||
                string.IsNullOrWhiteSpace(txtSalario.Text) ||
                string.IsNullOrWhiteSpace(txtTurno.Text) ||
                string.IsNullOrWhiteSpace(txtCargaHoraria.Text) ||
                dtpDataAdmissao.Value <= dtpDataAdmissao.MinDate
            )
            {
                comboBoxTipo.Focus();
                txtNomeRazaoSocial.Focus();
                comboBoxGenero.Focus();
                txtCidade.Focus();
                txtEstado.Focus();
                txtEndereco.Focus();
                txtNumeroEndereco.Focus();
                txtBairro.Focus();
                if (!isEstrangeiro) txtCep.Focus();
                if (!isEstrangeiro) txtCpfCnpj.Focus();
                txtRgInscEstadual.Focus();
                dtpDataNascimentoCriacao.Focus();
                txtTelefone.Focus();
                txtEmail.Focus();
                txtMatricula.Focus();
                txtCargo.Focus();
                txtSalario.Focus();
                txtTurno.Focus();
                txtCargaHoraria.Focus();
                dtpDataAdmissao.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            if (dtpDataDemissao.Checked && dtpDataDemissao.Value < dtpDataAdmissao.Value)
            {
                MessageBox.Show("A data de demissão não pode ser anterior à data de admissão.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataDemissao.Focus();
                return;
            }

            oFuncionario.Id = Convert.ToInt32(txtCodigo.Text);
            oFuncionario.TipoPessoa = 'F';
            oFuncionario.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oFuncionario.Apelido_nomeFantasia = string.IsNullOrWhiteSpace(txtApelidoNomeFantasia.Text) ? null : txtApelidoNomeFantasia.Text;
            oFuncionario.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oFuncionario.Cpf_cnpj = string.IsNullOrWhiteSpace(txtCpfCnpj.Text) ? null : txtCpfCnpj.Text;
            oFuncionario.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oFuncionario.Email = txtEmail.Text;
            oFuncionario.Telefone = txtTelefone.Text;
            oFuncionario.Endereco = txtEndereco.Text;
            oFuncionario.Bairro = txtBairro.Text;
            oFuncionario.Cep = string.IsNullOrWhiteSpace(txtCep.Text) ? null : txtCep.Text;
            oFuncionario.Ativo = checkBoxAtivo.Checked;
            oFuncionario.Genero = comboBoxGenero.SelectedIndex == -1 ? ' ' : (comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F');
            oFuncionario.Matricula = txtMatricula.Text;
            oFuncionario.Cargo = txtCargo.Text;
            oFuncionario.Salario = Convert.ToDecimal(txtSalario.Text);
            oFuncionario.Turno = txtTurno.Text;
            oFuncionario.CargaHoraria = Convert.ToInt32(txtCargaHoraria.Text);
            oFuncionario.NumeroEndereco = txtNumeroEndereco.Text;
            oFuncionario.ComplementoEndereco = string.IsNullOrWhiteSpace(txtComplementoEndereco.Text) ? null : txtComplementoEndereco.Text;
            oFuncionario.DataAdmissao = dtpDataAdmissao.Value;
            oFuncionario.DataDemissao = dtpDataDemissao.Checked ? dtpDataDemissao.Value : (DateTime?)null;

            try
            {
                if (btnSave.Text == "Alterar")
                {
                    aController_funcionario.Salvar(oFuncionario);
                    MessageBox.Show("Funcionário alterado com sucesso.");
                }
                else
                {
                    aController_funcionario.Salvar(oFuncionario);
                    MessageBox.Show("Funcionário salvo com o código " + txtCodigo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível concluir a operação. Verifique os dados e tente novamente.\n\nDetalhes técnicos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            base.Salvar();
        }

        public override void Limpartxt()
        {
            base.Limpartxt();

            txtNomeRazaoSocial.Clear();
            txtApelidoNomeFantasia.Clear();
            txtCpfCnpj.Clear();
            txtRgInscEstadual.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            dtpDataNascimentoCriacao.Value = DateTime.Today;
            txtMatricula.Clear();
            txtCargo.Clear();
            txtSalario.Clear();
            dtpDataAdmissao.Value = DateTime.Today;
            txtTurno.Clear();
            txtCargaHoraria.Clear();
            oFuncionario.ACidade = new cidade();
            txtCidade.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtNumeroEndereco.Clear(); 
            txtComplementoEndereco.Clear(); 
            dtpDataDemissao.Value = DateTime.Today; 
            dtpDataDemissao.Checked = false;

            dtpDataDemissao.Enabled = false;
            lblDataDemissao.Enabled = false;
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
            txtEstado.Text = oFuncionario.ACidade.OEstado.Nome;
            txtPais.Text = oFuncionario.ACidade.OEstado.OPais.Nome;
            dtpDataNascimentoCriacao.Value = (oFuncionario.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate) ? dtpDataNascimentoCriacao.MinDate : oFuncionario.DataNascimento_criacao;
            comboBoxGenero.SelectedIndex = oFuncionario.Genero == 'M' ? 0 : 1;
            checkBoxAtivo.Checked = oFuncionario.Ativo;
            txtMatricula.Text = oFuncionario.Matricula;
            txtCargo.Text = oFuncionario.Cargo;
            txtSalario.Text = oFuncionario.Salario.ToString("F2");
            dtpDataAdmissao.Value = (oFuncionario.DataAdmissao < dtpDataAdmissao.MinDate) ? dtpDataAdmissao.MinDate : oFuncionario.DataAdmissao;
            txtTurno.Text = oFuncionario.Turno;
            txtCargaHoraria.Text = oFuncionario.CargaHoraria.ToString();
            txtNumeroEndereco.Text = oFuncionario.NumeroEndereco;
            txtComplementoEndereco.Text = oFuncionario.ComplementoEndereco;  
            dtpDataDemissao.Value = (oFuncionario.DataDemissao ?? DateTime.Today);
            dtpDataDemissao.Checked = oFuncionario.DataDemissao.HasValue;
            lblDataCadastroData.Text = oFuncionario.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oFuncionario.DataUltimaEdicao?.ToShortDateString() ?? " ";

            dtpDataDemissao.Enabled = true;
            lblDataDemissao.Enabled = true;
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtNomeRazaoSocial.Enabled = false;
            txtApelidoNomeFantasia.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtRgInscEstadual.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCep.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;
            txtPais.Enabled = false;
            comboBoxTipo.Enabled = false;
            comboBoxGenero.Enabled = false;
            dtpDataNascimentoCriacao.Enabled = false;
            btnPesquisarCidade.Enabled = false;
            txtMatricula.Enabled = false;
            txtCargo.Enabled = false;
            txtSalario.Enabled = false;
            dtpDataAdmissao.Enabled = false;
            txtTurno.Enabled = false;
            txtCargaHoraria.Enabled = false;
            txtNumeroEndereco.Enabled = false; 
            txtComplementoEndereco.Enabled = false; 
            dtpDataDemissao.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            txtNomeRazaoSocial.Enabled = true;
            txtApelidoNomeFantasia.Enabled = true;
            txtCpfCnpj.Enabled = true;
            txtRgInscEstadual.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefone.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtCep.Enabled = true;
            txtCidade.Enabled = true;
            txtEstado.Enabled = true;
            txtPais.Enabled = true;
            btnPesquisarCidade.Enabled = true;
            dtpDataNascimentoCriacao.Enabled = true;
            comboBoxGenero.Enabled = true;
            txtMatricula.Enabled = true;
            txtCargo.Enabled = true;
            txtSalario.Enabled = true;
            dtpDataAdmissao.Enabled = true;
            txtTurno.Enabled = true;
            txtCargaHoraria.Enabled = true;
            txtNumeroEndereco.Enabled = true; 
            txtComplementoEndereco.Enabled = true; 
            dtpDataDemissao.Enabled = true;
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
                controller.CarregaObj(cidade);

                oFuncionario.ACidade = cidade;
                txtCidade.Text = cidade.Nome;
                txtEstado.Text = cidade.OEstado.Nome;
                txtPais.Text = cidade.OEstado.OPais.Nome;

                isEstrangeiro = cidade.OEstado.OPais.Nome.Trim().ToUpper() != "BRASIL";

                lblCep.Text = isEstrangeiro ? "CEP" : "CEP *";
                lblCpf.Text = isEstrangeiro ? "CPF" : "CPF *";
            }
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtCpfCnpj.MaxLength = 11;
            txtMatricula.MaxLength = 20;
            txtCargo.MaxLength = 40;
            txtSalario.MaxLength = 11;
            txtTurno.MaxLength = 40;
            txtCargaHoraria.MaxLength = 3;

            txtSalario.KeyPress -= ApenasNumerosDecimal;
            txtSalario.KeyPress += ApenasNumerosDecimal;

            txtCargaHoraria.KeyPress -= ApenasNumeros;
            txtCargaHoraria.KeyPress += ApenasNumeros;
        }
    }
}

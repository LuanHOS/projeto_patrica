using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroCliente : projeto_patrica.pages.cadastro.frmCadastroPessoa
    {
        private cliente oCliente;
        private Controller_cliente aController_cliente;
        private frmConsultaCidade oFrmConsultaCidade;
        private frmConsultaCondicaoPagamento oFrmConsultaCondicaoPagamento;

        public frmCadastroCliente() : base()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndex = -1;
            HabilitarCampos(false);
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCliente = (cliente)obj;
            aController_cliente = (Controller_cliente)ctrl;
        }

        public void setConsultaCidade(frmConsultaCidade consulta)
        {
            oFrmConsultaCidade = consulta;
        }

        public void setConsultaCondicaoPagamento(frmConsultaCondicaoPagamento consulta)
        {
            oFrmConsultaCondicaoPagamento = consulta;
        }

        public override void Salvar()
        {
            if (
                comboBoxTipo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNomeRazaoSocial.Text) ||
                string.IsNullOrWhiteSpace(txtCpfCnpj.Text) ||
                string.IsNullOrWhiteSpace(txtRgInscEstadual.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtBairro.Text) ||
                string.IsNullOrWhiteSpace(txtCep.Text) ||
                comboBoxGenero.SelectedIndex == -1 ||
                dtpDataNascimentoCriacao.Value <= dtpDataNascimentoCriacao.MinDate ||
                oCliente.ACidade == null || oCliente.ACidade.Id == 0 ||
                oCliente.ACondicaoPagamento == null || oCliente.ACondicaoPagamento.Id == 0
            )
            {
                comboBoxTipo.Focus();
                txtNomeRazaoSocial.Focus();
                txtCpfCnpj.Focus();
                txtRgInscEstadual.Focus();
                txtEmail.Focus();
                txtTelefone.Focus();
                txtEndereco.Focus();
                txtBairro.Focus();
                txtCep.Focus();
                comboBoxGenero.Focus();
                dtpDataNascimentoCriacao.Focus();
                txtCidade.Focus();
                txtCondicaoPagamento.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oCliente.Id = Convert.ToInt32(txtCodigo.Text);
            oCliente.TipoPessoa = comboBoxTipo.SelectedIndex == 0 ? 'F' : 'J';
            oCliente.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oCliente.Apelido_nomeFantasia = txtApelidoNomeFantasia.Text;
            oCliente.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oCliente.Cpf_cnpj = txtCpfCnpj.Text;
            oCliente.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oCliente.Email = txtEmail.Text;
            oCliente.Telefone = txtTelefone.Text;
            oCliente.Endereco = txtEndereco.Text;
            oCliente.Bairro = txtBairro.Text;
            oCliente.Cep = txtCep.Text;
            oCliente.Ativo = checkBoxAtivo.Checked;
            oCliente.Genero = comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F';
            oCliente.NumeroEndereco = txtNumeroEndereco.Text;
            oCliente.ComplementoEndereco = txtComplementoEndereco.Text;
            oCliente.LimiteDeCredito = string.IsNullOrWhiteSpace(txtLimiteDeCredito.Text) ? 0 : Convert.ToDecimal(txtLimiteDeCredito.Text.Replace(".", ","));


            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        txtCodigo.Text = aController_cliente.Excluir(oCliente);
                        MessageBox.Show("Cliente excluído com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_cliente.Salvar(oCliente);
                    MessageBox.Show("Cliente alterado com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_cliente.Salvar(oCliente);
                    MessageBox.Show("Cliente salvo com o código " + txtCodigo.Text + ".");
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
            txtCidade.Clear();
            txtEstado.Clear();
            txtNumeroEndereco.Clear();
            txtComplementoEndereco.Clear();
            txtLimiteDeCredito.Clear();
            txtCondicaoPagamento.Clear();
            comboBoxTipo.SelectedIndex = -1;
            comboBoxGenero.SelectedIndex = -1;
            dtpDataNascimentoCriacao.Value = DateTime.Today;
            oCliente.ACidade = new cidade();
            oCliente.ACondicaoPagamento = new condicaoPagamento();
            HabilitarCampos(false);
            comboBoxTipo.Enabled = true;
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oCliente.Id.ToString();
            txtNomeRazaoSocial.Text = oCliente.Nome_razaoSocial;
            txtApelidoNomeFantasia.Text = oCliente.Apelido_nomeFantasia;
            txtCpfCnpj.Text = oCliente.Cpf_cnpj;
            txtRgInscEstadual.Text = oCliente.Rg_inscricaoEstadual;
            txtEmail.Text = oCliente.Email;
            txtTelefone.Text = oCliente.Telefone;
            txtEndereco.Text = oCliente.Endereco;
            txtBairro.Text = oCliente.Bairro;
            txtCep.Text = oCliente.Cep;
            txtCidade.Text = oCliente.ACidade.Nome;
            txtEstado.Text = oCliente.ACidade.OEstado.Nome;
            txtCondicaoPagamento.Text = oCliente.ACondicaoPagamento.Descricao;
            dtpDataNascimentoCriacao.Value = (oCliente.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate) ? dtpDataNascimentoCriacao.MinDate : oCliente.DataNascimento_criacao;
            txtNumeroEndereco.Text = oCliente.NumeroEndereco;
            txtComplementoEndereco.Text = oCliente.ComplementoEndereco;
            txtLimiteDeCredito.Text = oCliente.LimiteDeCredito.ToString("F2");
            lblDataCadastroData.Text = oCliente.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oCliente.DataUltimaEdicao?.ToShortDateString() ?? " ";
            comboBoxTipo.SelectedIndex = oCliente.TipoPessoa == 'F' ? 0 : 1;
            comboBoxTipo.Enabled = false;
            comboBoxGenero.SelectedIndex = oCliente.Genero == 'M' ? 0 : 1;
            checkBoxAtivo.Checked = oCliente.Ativo;
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            HabilitarCampos(false);
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            if (comboBoxTipo.SelectedIndex != -1) HabilitarCampos(true);
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isFisica = comboBoxTipo.SelectedIndex == 0;

            HabilitarCampos(true);
            comboBoxGenero.Enabled = isFisica;

            lblNome.Text = isFisica ? "Nome *" : "Razão Social *";
            lblApelido.Text = isFisica ? "Apelido" : "Nome Fantasia";
            lblCpf.Text = isFisica ? "CPF *" : "CNPJ *";
            lblRg.Text = isFisica ? "RG *" : "Inscrição Estadual *";
            lblDataNascimento.Text = isFisica ? "Data de Nascimento *" : "Data de Criação *";
        }

        private void BtnPesquisarCidade_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCidade == null)
                oFrmConsultaCidade = new frmConsultaCidade();

            cidade aCidade = new cidade();
            Controller_cidade controller = new Controller_cidade();
            oFrmConsultaCidade.ConhecaObj(aCidade, controller);
            oFrmConsultaCidade.ShowDialog();

            if (aCidade.Id != 0)
            {
                oCliente.ACidade = aCidade;
                txtCidade.Text = aCidade.Nome;
                txtEstado.Text = aCidade.OEstado.Nome;
            }
        }

        private void BtnPesquisarCondicaoPagamento_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCondicaoPagamento == null)
                oFrmConsultaCondicaoPagamento = new frmConsultaCondicaoPagamento();

            condicaoPagamento oCondicaoPagamento = new condicaoPagamento();
            Controller_condicaoPagamento controller = new Controller_condicaoPagamento();
            oFrmConsultaCondicaoPagamento.ConhecaObj(oCondicaoPagamento, controller);
            oFrmConsultaCondicaoPagamento.ShowDialog();

            if (oCondicaoPagamento.Id != 0)
            {
                oCliente.ACondicaoPagamento = oCondicaoPagamento;
                txtCondicaoPagamento.Text = oCondicaoPagamento.Descricao;
            }
        }

        private void HabilitarCampos(bool habilita)
        {
            txtNomeRazaoSocial.Enabled = habilita;
            txtApelidoNomeFantasia.Enabled = habilita;
            txtCpfCnpj.Enabled = habilita;
            txtRgInscEstadual.Enabled = habilita;
            txtEmail.Enabled = habilita;
            txtTelefone.Enabled = habilita;
            txtEndereco.Enabled = habilita;
            txtBairro.Enabled = habilita;
            txtCep.Enabled = habilita;
            txtCidade.Enabled = habilita;
            txtEstado.Enabled = habilita;
            txtCondicaoPagamento.Enabled = habilita;
            dtpDataNascimentoCriacao.Enabled = habilita;
            comboBoxGenero.Enabled = habilita;
            btnPesquisarCidade.Enabled = habilita;
            btnPesquisarCondicaoPagamento.Enabled = habilita;
            txtNumeroEndereco.Enabled = habilita;
            txtComplementoEndereco.Enabled = habilita;
            txtLimiteDeCredito.Enabled = habilita;
        }
    }
}

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
        private bool isFisica = true;
        private bool isEstrangeiro = false;

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
            if (!ValidacaoCampos())
                return;

            if (
                string.IsNullOrWhiteSpace(txtNomeRazaoSocial.Text) ||
                (isFisica && comboBoxGenero.SelectedIndex == -1) || // obrigatório só se for física
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
                string.IsNullOrWhiteSpace(txtCondicaoPagamento.Text)
            )
            {
                comboBoxTipo.Focus();
                txtNomeRazaoSocial.Focus();
                if (isFisica) comboBoxGenero.Focus();
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
                txtCondicaoPagamento.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oCliente.Id = Convert.ToInt32(txtCodigo.Text);
            oCliente.TipoPessoa = comboBoxTipo.SelectedIndex == 0 ? 'F' : 'J';
            oCliente.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oCliente.Apelido_nomeFantasia = string.IsNullOrWhiteSpace(txtApelidoNomeFantasia.Text) ? null : txtApelidoNomeFantasia.Text;
            oCliente.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oCliente.Cpf_cnpj = string.IsNullOrWhiteSpace(txtCpfCnpj.Text) ? null : txtCpfCnpj.Text;
            oCliente.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oCliente.Email = txtEmail.Text;
            oCliente.Telefone = txtTelefone.Text;
            oCliente.Endereco = txtEndereco.Text;
            oCliente.Bairro = txtBairro.Text;
            oCliente.Cep = string.IsNullOrWhiteSpace(txtCep.Text) ? null : txtCep.Text;
            oCliente.Ativo = checkBoxAtivo.Checked;
            oCliente.Genero = comboBoxGenero.SelectedIndex == -1 ? ' ' : (comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F');
            oCliente.NumeroEndereco = txtNumeroEndereco.Text;
            oCliente.ComplementoEndereco = string.IsNullOrWhiteSpace(txtComplementoEndereco.Text) ? null : txtComplementoEndereco.Text;
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
            txtPais.Clear();
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
            txtPais.Text = oCliente.ACidade.OEstado.OPais.Nome;
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

            if (isFisica)
                txtCpfCnpj.MaxLength = 11;
            else
                txtCpfCnpj.MaxLength = 14;
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
            comboBoxGenero.SelectedIndex = -1;

            isFisica = comboBoxTipo.SelectedIndex == 0; // 0 = Pessoa Física, 1 = Pessoa Jurídica

            HabilitarCampos(true);
            comboBoxGenero.Enabled = isFisica;
            lblGenero.Enabled = isFisica;

            lblNome.Text = isFisica ? "Cliente Nome *" : "Cliente Razão Social *";
            lblApelido.Text = isFisica ? "Apelido" : "Nome Fantasia";

            if (isFisica)
            {
                lblCpf.Text = isEstrangeiro ? "CPF" : "CPF *";
                txtCpfCnpj.MaxLength = 11;
            }
            else
            {
                lblCpf.Text = isEstrangeiro ? "CNPJ" : "CNPJ *";
                txtCpfCnpj.MaxLength = 14;
            }

            lblRg.Text = isFisica ? "RG *" : "Inscrição Estadual *";
            lblDataNascimento.Text = isFisica ? "Data de Nascimento *" : "Data de Criação *";
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

                oCliente.ACidade = cidade;
                txtCidade.Text = cidade.Nome;
                txtEstado.Text = cidade.OEstado.Nome;
                txtPais.Text = cidade.OEstado.OPais.Nome;

                isEstrangeiro = cidade.OEstado.OPais.Nome.Trim().ToUpper() != "BRASIL";

                lblCep.Text = isEstrangeiro ? "CEP" : "CEP *";

                if (isFisica)
                {
                    lblCpf.Text = isEstrangeiro ? "CPF" : "CPF *";
                    txtCpfCnpj.MaxLength = 11;
                }
                else
                {
                    lblCpf.Text = isEstrangeiro ? "CNPJ" : "CNPJ *";
                    txtCpfCnpj.MaxLength = 14;
                }
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
            txtPais.Enabled = habilita;
            txtCondicaoPagamento.Enabled = habilita;
            dtpDataNascimentoCriacao.Enabled = habilita;
            comboBoxGenero.Enabled = habilita;
            btnPesquisarCidade.Enabled = habilita;
            btnPesquisarCondicaoPagamento.Enabled = habilita;
            txtNumeroEndereco.Enabled = habilita;
            txtComplementoEndereco.Enabled = habilita;
            txtLimiteDeCredito.Enabled = habilita;
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtLimiteDeCredito.MaxLength = 40;

            txtLimiteDeCredito.KeyPress -= ApenasNumeros;
            txtLimiteDeCredito.KeyPress += ApenasNumeros;
        }
    }
}

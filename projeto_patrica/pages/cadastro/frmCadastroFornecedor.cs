using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroFornecedor : projeto_patrica.pages.cadastro.frmCadastroPessoa
    {
        private fornecedor oFornecedor;
        private Controller_fornecedor aController_fornecedor;
        private frmConsultaCidade oFrmConsultaCidade;
        private frmConsultaCondicaoPagamento oFrmConsultaCondicaoPagamento;
        private bool isEstrangeiro = false;

        public frmCadastroFornecedor() : base()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndex = -1;
            HabilitarCampos(false);
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oFornecedor = (fornecedor)obj;
            aController_fornecedor = (Controller_fornecedor)ctrl;
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
            if (btnSave.Text == "Excluir")
            {
                DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    aController_fornecedor.Excluir(oFornecedor);
                    MessageBox.Show("Fornecedor excluído com sucesso.");
                    Sair();
                    return;
                }
            }

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

            oFornecedor.Id = Convert.ToInt32(txtCodigo.Text);
            oFornecedor.TipoPessoa = comboBoxTipo.SelectedIndex == 0 ? 'F' : 'J';
            oFornecedor.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oFornecedor.Apelido_nomeFantasia = string.IsNullOrWhiteSpace(txtApelidoNomeFantasia.Text) ? null : txtApelidoNomeFantasia.Text;
            oFornecedor.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oFornecedor.Cpf_cnpj = string.IsNullOrWhiteSpace(txtCpfCnpj.Text) ? null : txtCpfCnpj.Text;
            oFornecedor.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oFornecedor.Email = txtEmail.Text;
            oFornecedor.Telefone = txtTelefone.Text;
            oFornecedor.Endereco = txtEndereco.Text;
            oFornecedor.Bairro = txtBairro.Text;
            oFornecedor.Cep = string.IsNullOrWhiteSpace(txtCep.Text) ? null : txtCep.Text;
            oFornecedor.Ativo = checkBoxAtivo.Checked;
            oFornecedor.Genero = comboBoxGenero.SelectedIndex == -1 ? ' ' : (comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F');
            oFornecedor.NumeroEndereco = txtNumeroEndereco.Text;
            oFornecedor.ComplementoEndereco = string.IsNullOrWhiteSpace(txtComplementoEndereco.Text) ? null : txtComplementoEndereco.Text;

            try
            {
                if (btnSave.Text == "Alterar")
                {
                    aController_fornecedor.Salvar(oFornecedor);
                    MessageBox.Show("Fornecedor alterado com sucesso.");
                }
                else
                {
                    aController_fornecedor.Salvar(oFornecedor);
                    MessageBox.Show("Fornecedor salvo com o código " + oFornecedor.Id + ".");
                }

                base.Salvar();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1062: // Entrada duplicada
                        MessageBox.Show(
                            "Não foi possível salvar o item.\n\nJá existe um item salvo com estes dados.",
                            "Erro: Item duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;

                    case 1451: //  Entrada interligada
                        MessageBox.Show(
                            "Não foi possível excluir o item.\n\nEle está interligado a outro item existente.",
                            "Erro: Item em uso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;

                    default: // Outros erros de banco de dados
                        MessageBox.Show(
                            "Não foi possível concluir a operação. Verifique os dados e tente novamente.\n\nDetalhes técnicos: " + ex.Message,
                            "Erro no Banco de Dados",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            txtCodCidade.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtNumeroEndereco.Clear();
            txtComplementoEndereco.Clear();
            txtCodCondicaoPagamento.Clear();
            txtCondicaoPagamento.Clear();
            comboBoxTipo.SelectedIndex = -1;
            comboBoxGenero.SelectedIndex = -1;
            dtpDataNascimentoCriacao.Value = DateTime.Today;
            oFornecedor.ACidade = new cidade();
            oFornecedor.ACondicaoPagamento = new condicaoPagamento();
            HabilitarCampos(false);
            comboBoxTipo.Enabled = true;
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oFornecedor.Id.ToString();
            txtNomeRazaoSocial.Text = oFornecedor.Nome_razaoSocial;
            txtApelidoNomeFantasia.Text = oFornecedor.Apelido_nomeFantasia;
            txtCpfCnpj.Text = oFornecedor.Cpf_cnpj;
            txtRgInscEstadual.Text = oFornecedor.Rg_inscricaoEstadual;
            txtEmail.Text = oFornecedor.Email;
            txtTelefone.Text = oFornecedor.Telefone;
            txtEndereco.Text = oFornecedor.Endereco;
            txtBairro.Text = oFornecedor.Bairro;
            txtCep.Text = oFornecedor.Cep;
            txtCodCidade.Text = oFornecedor.ACidade.Id.ToString();
            txtCidade.Text = oFornecedor.ACidade.Nome;
            txtEstado.Text = oFornecedor.ACidade.OEstado.Nome;
            txtPais.Text = oFornecedor.ACidade.OEstado.OPais.Nome;
            txtNumeroEndereco.Text = oFornecedor.NumeroEndereco;
            txtComplementoEndereco.Text = oFornecedor.ComplementoEndereco;
            txtCodCondicaoPagamento.Text = oFornecedor.ACondicaoPagamento.Id.ToString();
            txtCondicaoPagamento.Text = oFornecedor.ACondicaoPagamento.Descricao;
            dtpDataNascimentoCriacao.Value = (oFornecedor.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate) ? dtpDataNascimentoCriacao.MinDate : oFornecedor.DataNascimento_criacao;
            comboBoxTipo.SelectedIndex = oFornecedor.TipoPessoa == 'F' ? 0 : 1;
            comboBoxTipo.Enabled = false;
            comboBoxGenero.SelectedIndex = oFornecedor.Genero == 'M' ? 0 : (oFornecedor.Genero == 'F' ? 1 : -1);
            checkBoxAtivo.Checked = oFornecedor.Ativo;
            lblDataCadastroData.Text = oFornecedor.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oFornecedor.DataUltimaEdicao?.ToShortDateString() ?? " ";

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

            lblNome.Text = isFisica ? "Fornecedor Nome *" : "Fornecedor Razão Social *";
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

                oFornecedor.ACidade = cidade;
                txtCodCidade.Text = cidade.Id.ToString();
                txtCidade.Text = cidade.Nome;
                txtEstado.Text = cidade.OEstado.Nome;
                txtPais.Text = cidade.OEstado.OPais.Nome;

                isEstrangeiro = cidade.OEstado.OPais.Nome.Trim().ToUpper() != "BRASIL";

                lblCep.Text = isEstrangeiro ? "CEP" : "CEP *";

                if (isFisica)
                    lblCpf.Text = isEstrangeiro ? "CPF" : "CPF *";
                else
                    lblCpf.Text = isEstrangeiro ? "CNPJ" : "CNPJ *";
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
                oFornecedor.ACondicaoPagamento = oCondicaoPagamento;
                txtCodCondicaoPagamento.Text = oCondicaoPagamento.Id.ToString();
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
            txtCodCidade.Enabled = habilita;
            txtCidade.Enabled = habilita;
            txtEstado.Enabled = habilita;
            txtPais.Enabled = habilita;
            txtNumeroEndereco.Enabled = habilita;
            txtComplementoEndereco.Enabled = habilita;
            dtpDataNascimentoCriacao.Enabled = habilita;
            comboBoxGenero.Enabled = habilita;
            btnPesquisarCidade.Enabled = habilita;
            btnPesquisarCondicaoPagamento.Enabled = habilita;
            txtCodCondicaoPagamento.Enabled = habilita;
            txtCondicaoPagamento.Enabled = habilita;
        }
    }
}
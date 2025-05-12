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
                oFornecedor.ACidade == null || oFornecedor.ACidade.Id == 0 ||
                oFornecedor.ACondicaoPagamento == null || oFornecedor.ACondicaoPagamento.Id == 0 ||
                dtpDataNascimentoCriacao.Value <= dtpDataNascimentoCriacao.MinDate
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
                txtCidade.Focus();
                txtCondicaoPagamento.Focus();
                dtpDataNascimentoCriacao.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oFornecedor.Id = Convert.ToInt32(txtCodigo.Text);
            oFornecedor.TipoPessoa = comboBoxTipo.SelectedIndex == 0 ? 'F' : 'J';
            oFornecedor.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oFornecedor.Apelido_nomeFantasia = txtApelidoNomeFantasia.Text;
            oFornecedor.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oFornecedor.Cpf_cnpj = txtCpfCnpj.Text;
            oFornecedor.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oFornecedor.Email = txtEmail.Text;
            oFornecedor.Telefone = txtTelefone.Text;
            oFornecedor.Endereco = txtEndereco.Text;
            oFornecedor.Bairro = txtBairro.Text;
            oFornecedor.Cep = txtCep.Text;
            oFornecedor.Ativo = checkBoxAtivo.Checked;
            oFornecedor.Genero = comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F';
            oFornecedor.NumeroEndereco = txtNumeroEndereco.Text;
            oFornecedor.ComplementoEndereco = txtComplementoEndereco.Text;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        txtCodigo.Text = aController_fornecedor.Excluir(oFornecedor);
                        MessageBox.Show("Fornecedor excluído com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_fornecedor.Salvar(oFornecedor);
                    MessageBox.Show("Fornecedor alterado com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_fornecedor.Salvar(oFornecedor);
                    MessageBox.Show("Fornecedor salvo com o código " + txtCodigo.Text + ".");
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
            txtCondicaoPagamento.Clear();
            comboBoxTipo.SelectedIndex = -1;
            comboBoxGenero.SelectedIndex = -1;
            dtpDataNascimentoCriacao.Value = DateTime.Today;
            oFornecedor.ACidade = new cidade();
            oFornecedor.ACondicaoPagamento = new condicaoPagamento();

            HabilitarCampos(false);
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
            txtCidade.Text = oFornecedor.ACidade.Nome;
            txtEstado.Text = oFornecedor.ACidade.OEstado.Nome;
            txtNumeroEndereco.Text = oFornecedor.NumeroEndereco;
            txtComplementoEndereco.Text = oFornecedor.ComplementoEndereco;
            txtCondicaoPagamento.Text = oFornecedor.ACondicaoPagamento.Descricao;
            dtpDataNascimentoCriacao.Value = (oFornecedor.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate) ? dtpDataNascimentoCriacao.MinDate : oFornecedor.DataNascimento_criacao;
            comboBoxTipo.SelectedIndex = oFornecedor.TipoPessoa == 'F' ? 0 : 1;
            comboBoxGenero.SelectedIndex = oFornecedor.Genero == 'M' ? 0 : 1;
            checkBoxAtivo.Checked = oFornecedor.Ativo;
            lblDataCadastroData.Text = oFornecedor.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oFornecedor.DataUltimaEdicao?.ToShortDateString() ?? " ";
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
                oFornecedor.ACidade = aCidade;
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
                oFornecedor.ACondicaoPagamento = oCondicaoPagamento;
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
            txtNumeroEndereco.Enabled = habilita;
            txtComplementoEndereco.Enabled = habilita;
            dtpDataNascimentoCriacao.Enabled = habilita;
            comboBoxGenero.Enabled = habilita;
            btnPesquisarCidade.Enabled = habilita;
            btnPesquisarCondicaoPagamento.Enabled = habilita;
            txtCondicaoPagamento.Enabled = habilita;

            if (btnSave.Text == "Excluir")
            {
                comboBoxTipo.Enabled = false;
            }
            else
            {
                comboBoxTipo.Enabled = true;
            }
        }
    }
}

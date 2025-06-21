using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroTransportadora : frmCadastroPessoa
    {
        private transportadora oTransportadora;
        private Controller_transportadora aController_transportadora;
        private frmConsultaCidade oFrmConsultaCidade;
        private frmConsultaCondicaoPagamento oFrmConsultaCondicaoPagamento;
        private bool isFisica = true;
        private bool isEstrangeiro = false;

        public frmCadastroTransportadora() : base()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndex = -1;
            HabilitarCampos(false);
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oTransportadora = (transportadora)obj;
            aController_transportadora = (Controller_transportadora)ctrl;
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
                (isFisica && comboBoxGenero.SelectedIndex == -1) ||
                string.IsNullOrWhiteSpace(txtCidade.Text) ||
                string.IsNullOrWhiteSpace(txtEstado.Text) ||
                string.IsNullOrWhiteSpace(txtEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroEndereco.Text) ||
                string.IsNullOrWhiteSpace(txtBairro.Text) ||
                (!isEstrangeiro && string.IsNullOrWhiteSpace(txtCep.Text)) ||
                (!isEstrangeiro && string.IsNullOrWhiteSpace(txtCpfCnpj.Text)) ||
                string.IsNullOrWhiteSpace(txtRgInscEstadual.Text) ||
                dtpDataNascimentoCriacao.Value <= dtpDataNascimentoCriacao.MinDate ||
                string.IsNullOrWhiteSpace(txtTelefone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCondicaoPagamento.Text)
            )
            {
                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oTransportadora.Id = Convert.ToInt32(txtCodigo.Text);
            oTransportadora.TipoPessoa = comboBoxTipo.SelectedIndex == 0 ? 'F' : 'J';
            oTransportadora.Nome_razaoSocial = txtNomeRazaoSocial.Text;
            oTransportadora.Apelido_nomeFantasia = string.IsNullOrWhiteSpace(txtApelidoNomeFantasia.Text) ? null : txtApelidoNomeFantasia.Text;
            oTransportadora.DataNascimento_criacao = dtpDataNascimentoCriacao.Value;
            oTransportadora.Cpf_cnpj = string.IsNullOrWhiteSpace(txtCpfCnpj.Text) ? null : txtCpfCnpj.Text;
            oTransportadora.Rg_inscricaoEstadual = txtRgInscEstadual.Text;
            oTransportadora.Email = txtEmail.Text;
            oTransportadora.Telefone = txtTelefone.Text;
            oTransportadora.Endereco = txtEndereco.Text;
            oTransportadora.Bairro = txtBairro.Text;
            oTransportadora.Cep = string.IsNullOrWhiteSpace(txtCep.Text) ? null : txtCep.Text;
            oTransportadora.Ativo = checkBoxAtivo.Checked;
            oTransportadora.Genero = comboBoxGenero.SelectedIndex == -1 ? ' ' : (comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F');
            oTransportadora.NumeroEndereco = txtNumeroEndereco.Text;
            oTransportadora.ComplementoEndereco = string.IsNullOrWhiteSpace(txtComplementoEndereco.Text) ? null : txtComplementoEndereco.Text;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.Yes)
                    {
                        aController_transportadora.Excluir(oTransportadora);
                        MessageBox.Show("Transportadora excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    oTransportadora.DataUltimaEdicao = DateTime.Now;
                    txtCodigo.Text = aController_transportadora.Salvar(oTransportadora);
                    MessageBox.Show("Transportadora alterada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oTransportadora.DataCadastro = DateTime.Now;
                    txtCodigo.Text = aController_transportadora.Salvar(oTransportadora);
                    MessageBox.Show("Transportadora salva com o código " + txtCodigo.Text + ".", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCondicaoPagamento.Clear();
            comboBoxTipo.SelectedIndex = -1;
            comboBoxGenero.SelectedIndex = -1;
            dtpDataNascimentoCriacao.Value = DateTime.Today;
            oTransportadora.ACidade = new cidade();
            oTransportadora.ACondicaoPagamento = new condicaoPagamento();
            HabilitarCampos(false);
            comboBoxTipo.Enabled = true;
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oTransportadora.Id.ToString();
            txtNomeRazaoSocial.Text = oTransportadora.Nome_razaoSocial;
            txtApelidoNomeFantasia.Text = oTransportadora.Apelido_nomeFantasia;
            txtCpfCnpj.Text = oTransportadora.Cpf_cnpj;
            txtRgInscEstadual.Text = oTransportadora.Rg_inscricaoEstadual;
            txtEmail.Text = oTransportadora.Email;
            txtTelefone.Text = oTransportadora.Telefone;
            txtEndereco.Text = oTransportadora.Endereco;
            txtBairro.Text = oTransportadora.Bairro;
            txtCep.Text = oTransportadora.Cep;
            txtCidade.Text = oTransportadora.ACidade.Nome;
            txtEstado.Text = oTransportadora.ACidade.OEstado.Nome;
            txtPais.Text = oTransportadora.ACidade.OEstado.OPais.Nome;
            txtNumeroEndereco.Text = oTransportadora.NumeroEndereco;
            txtComplementoEndereco.Text = oTransportadora.ComplementoEndereco;
            txtCondicaoPagamento.Text = oTransportadora.ACondicaoPagamento.Descricao;
            dtpDataNascimentoCriacao.Value = (oTransportadora.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate) ? dtpDataNascimentoCriacao.MinDate : oTransportadora.DataNascimento_criacao;
            comboBoxTipo.SelectedIndex = oTransportadora.TipoPessoa == 'F' ? 0 : 1;
            comboBoxTipo.Enabled = false;
            comboBoxGenero.SelectedIndex = oTransportadora.Genero == 'M' ? 0 : 1;
            checkBoxAtivo.Checked = oTransportadora.Ativo;
            lblDataCadastroData.Text = oTransportadora.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oTransportadora.DataUltimaEdicao?.ToShortDateString() ?? " ";

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
            txtNumeroEndereco.Enabled = habilita;
            txtComplementoEndereco.Enabled = habilita;
            dtpDataNascimentoCriacao.Enabled = habilita;
            comboBoxGenero.Enabled = habilita;
            btnPesquisarCidade.Enabled = habilita;
            btnPesquisarCondicaoPagamento.Enabled = habilita;
            txtCondicaoPagamento.Enabled = habilita;
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGenero.SelectedIndex = -1;
            isFisica = comboBoxTipo.SelectedIndex == 0;
            HabilitarCampos(true);
            comboBoxGenero.Enabled = isFisica;
            lblGenero.Enabled = isFisica;
            lblNome.Text = isFisica ? "Transportadora Nome *" : "Transportadora Razão Social *";
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
                oTransportadora.ACidade = cidade;
                txtCidade.Text = cidade.Nome;
                txtEstado.Text = cidade.OEstado.Nome;
                txtPais.Text = cidade.OEstado.OPais.Nome;

                isEstrangeiro = cidade.OEstado.OPais.Nome.Trim().ToUpper() != "BRASIL";
                lblCep.Text = isEstrangeiro ? "CEP" : "CEP *";
                lblCpf.Text = isFisica ? (isEstrangeiro ? "CPF" : "CPF *") : (isEstrangeiro ? "CNPJ" : "CNPJ *");
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
                oTransportadora.ACondicaoPagamento = oCondicaoPagamento;
                txtCondicaoPagamento.Text = oCondicaoPagamento.Descricao;
            }
        }
    }
}

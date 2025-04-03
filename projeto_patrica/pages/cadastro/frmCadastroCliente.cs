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

        public frmCadastroCliente()
        {
            InitializeComponent();
            comboBoxTipo.SelectedIndexChanged += ComboBoxTipo_SelectedIndexChanged;
            btnPesquisarCidade.Click += BtnPesquisarCidade_Click;
            comboBoxTipo.SelectedIndex = -1;
            HabilitarCampos(false);
            checkBoxAtivo.Enabled = true;
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
            base.Salvar();

            if (comboBoxTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo de registro.");
                return;
            }

            if (txtNomeRazaoSocial.Text == "")
            {
                MessageBox.Show("Preencha o nome ou razão social.");
                txtNomeRazaoSocial.Focus();
                return;
            }

            if (oCliente.ACidade == null || oCliente.ACidade.Id == 0)
            {
                MessageBox.Show("Selecione uma cidade.");
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
            oCliente.Genero = comboBoxGenero.Enabled ? (comboBoxGenero.SelectedIndex == 0 ? 'M' : 'F') : ' ';

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

        public override void Limpartxt()
        {
            base.Limpartxt();
            txtCodigo.Text = "0";
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
            comboBoxTipo.SelectedIndex = -1;
            comboBoxGenero.SelectedIndex = -1;
            checkBoxAtivo.Checked = true;
            oCliente.ACidade = new cidade();
            oCliente.ACondicaoPagamento = new condicaoPagamento();
            HabilitarCampos(false);
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
            txtCondicaoPagamento.Text = oCliente.ACondicaoPagamento.Descricao;

            if (oCliente.DataNascimento_criacao < dtpDataNascimentoCriacao.MinDate)
                dtpDataNascimentoCriacao.Value = dtpDataNascimentoCriacao.MinDate;
            else
                dtpDataNascimentoCriacao.Value = oCliente.DataNascimento_criacao;

            comboBoxTipo.SelectedIndex = oCliente.TipoPessoa == 'F' ? 0 : 1;
            comboBoxGenero.SelectedIndex = oCliente.Genero == 'M' ? 0 : (oCliente.Genero == 'F' ? 1 : -1);
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

            cidade oCidade = new cidade();
            Controller_cidade controller = new Controller_cidade();
            oFrmConsultaCidade.ConhecaObj(oCidade, controller);
            oFrmConsultaCidade.ShowDialog();

            if (oCidade.Id != 0)
            {
                oCliente.ACidade = oCidade;
                txtCidade.Text = oCidade.Nome;
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
            txtCondicaoPagamento.Enabled = habilita;
            dtpDataNascimentoCriacao.Enabled = habilita;
            comboBoxGenero.Enabled = habilita;
            btnPesquisarCidade.Enabled = habilita;
            btnPesquisarCondicaoPagamento.Enabled = habilita;

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

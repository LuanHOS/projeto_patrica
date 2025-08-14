using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroFormaPagamento : projeto_patrica.pages.cadastro.frmCadastro
    {
        private formaPagamento aFormaPagamento;
        private Controller_formaPagamento aController_formaPagamento;

        public frmCadastroFormaPagamento() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aFormaPagamento = (formaPagamento)obj;
            aController_formaPagamento = (Controller_formaPagamento)ctrl;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                txtDescricao.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            aFormaPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aFormaPagamento.Descricao = txtDescricao.Text;
            aFormaPagamento.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_formaPagamento.Excluir(aFormaPagamento);
                        MessageBox.Show("A forma de pagamento \"" + aFormaPagamento.Descricao + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    aController_formaPagamento.Salvar(aFormaPagamento);
                    MessageBox.Show("A forma de pagamento \"" + aFormaPagamento.Descricao + "\" foi alterada com sucesso.");
                }
                else
                {
                    aController_formaPagamento.Salvar(aFormaPagamento);
                    MessageBox.Show("A forma de pagamento \"" + aFormaPagamento.Descricao + "\" foi salva com o código " + aFormaPagamento.Id + ".");
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

            txtDescricao.Clear();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = Convert.ToString(aFormaPagamento.Id);
            txtDescricao.Text = aFormaPagamento.Descricao;
            checkBoxAtivo.Checked = aFormaPagamento.Ativo;
            lblDataCadastroData.Text = aFormaPagamento.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = aFormaPagamento.DataUltimaEdicao?.ToShortDateString() ?? " ";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtDescricao.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            txtDescricao.Enabled = true;
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtDescricao.MaxLength = 40;
        }
    }
}

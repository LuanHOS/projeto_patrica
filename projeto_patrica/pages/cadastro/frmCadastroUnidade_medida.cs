using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroUnidade_medida : projeto_patrica.pages.cadastro.frmCadastro
    {
        private unidade_medida oUnidadeMedida;
        private Controller_unidade_medida aController_unidade_medida;

        public frmCadastroUnidade_medida() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oUnidadeMedida = (unidade_medida)obj;
            aController_unidade_medida = (Controller_unidade_medida)ctrl;
        }
        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oUnidadeMedida.Id = Convert.ToInt32(txtCodigo.Text);
            oUnidadeMedida.Nome = txtNome.Text;
            oUnidadeMedida.Sigla = txtSigla.Text;
            oUnidadeMedida.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_unidade_medida.Excluir(oUnidadeMedida);
                        MessageBox.Show("A unidade de medida \"" + oUnidadeMedida.Nome + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    aController_unidade_medida.Salvar(oUnidadeMedida);
                    MessageBox.Show("A unidade de medida \"" + oUnidadeMedida.Nome + "\" foi alterada com sucesso.");
                }
                else
                {
                    aController_unidade_medida.Salvar(oUnidadeMedida);
                    MessageBox.Show("A unidade de medida \"" + oUnidadeMedida.Nome + "\" foi salva com o código " + oUnidadeMedida.Id + ".");
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
            txtNome.Clear();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();
            txtCodigo.Text = Convert.ToString(oUnidadeMedida.Id);
            txtNome.Text = oUnidadeMedida.Nome;
            txtSigla.Text = oUnidadeMedida.Sigla;
            lblDataCadastroData.Text = oUnidadeMedida.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oUnidadeMedida.DataUltimaEdicao?.ToShortDateString() ?? " ";
            checkBoxAtivo.Checked = oUnidadeMedida.Ativo;
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            txtNome.Enabled = false;
            txtSigla.Enabled = false;
        }
        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            txtNome.Enabled = true;
            txtSigla.Enabled = true;
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();
            txtNome.MaxLength = 40;
            txtSigla.MaxLength = 3;
        }
    }
}
using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroEstado : projeto_patrica.pages.cadastro.frmCadastro
    {
        private estado oEstado;
        private Controller_estado aController_estado;
        private frmConsultaPais oFrmConsultaPais;

        public frmCadastroEstado() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oEstado = (estado)obj;
            aController_estado = (Controller_estado)ctrl;
        }

        public void setConsultaPais(frmConsultaPais consulta)
        {
            oFrmConsultaPais = consulta;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                oEstado.OPais == null
                )
            {
                txtNome.Focus();
                txtPais.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oEstado.Id = Convert.ToInt32(txtCodigo.Text);
            oEstado.Nome = txtNome.Text;
            oEstado.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_estado.Excluir(oEstado);
                        MessageBox.Show("O estado \"" + oEstado.Nome + "\" foi excluído com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    aController_estado.Salvar(oEstado);
                    MessageBox.Show("O estado \"" + oEstado.Nome + "\" foi alterado com sucesso.");
                }
                else
                {
                    aController_estado.Salvar(oEstado);
                    MessageBox.Show("O estado \"" + oEstado.Nome + "\" foi salvo com o código " + oEstado.Id + ".");
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
            txtPais.Clear();
            oEstado.OPais = new pais();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oEstado.Id.ToString();
            txtNome.Text = oEstado.Nome;
            txtPais.Text = oEstado.OPais.Nome;
            checkBoxAtivo.Checked = oEstado.Ativo;
            lblDataCadastroData.Text = oEstado.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oEstado.DataUltimaEdicao?.ToShortDateString() ?? " ";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtNome.Enabled = false;
            txtPais.Enabled = false;
            btnPesquisarPais.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            txtNome.Enabled = true;
            txtPais.Enabled = true;
            btnPesquisarPais.Enabled = true;
        }

        private void btnPesquisarPais_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaPais == null)
                oFrmConsultaPais = new frmConsultaPais();

            pais oPais = new pais();
            Controller_pais controller = new Controller_pais();
            oFrmConsultaPais.ConhecaObj(oPais, controller);
            oFrmConsultaPais.ShowDialog();

            if (oPais.Id != 0)
            {
                oEstado.OPais = oPais;
                txtPais.Text = oPais.Nome;
            }
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtNome.MaxLength = 58;
        }
    }
}

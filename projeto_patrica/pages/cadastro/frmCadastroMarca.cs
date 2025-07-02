using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroMarca : projeto_patrica.pages.cadastro.frmCadastro
    {
        private marca oMarca;
        private Controller_marca aController_marca;

        public frmCadastroMarca() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oMarca = (marca)obj;
            aController_marca = (Controller_marca)ctrl;
        }
        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oMarca.Id = Convert.ToInt32(txtCodigo.Text);
            oMarca.Nome = txtNome.Text;
            oMarca.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        txtCodigo.Text = aController_marca.Excluir(oMarca);
                        MessageBox.Show("A marca \"" + oMarca.Nome + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_marca.Salvar(oMarca);
                    MessageBox.Show("A marca \"" + oMarca.Nome + "\" foi alterada com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_marca.Salvar(oMarca);
                    MessageBox.Show("A marca \"" + oMarca.Nome + "\" foi salva com o código " + txtCodigo.Text + ".");
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
            txtNome.Clear();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();
            txtCodigo.Text = Convert.ToString(oMarca.Id);
            txtNome.Text = oMarca.Nome;
            lblDataCadastroData.Text = oMarca.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oMarca.DataUltimaEdicao?.ToShortDateString() ?? " ";
            checkBoxAtivo.Checked = oMarca.Ativo;
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            txtNome.Enabled = false;
        }
        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            txtNome.Enabled = true;
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtNome.MaxLength = 40;
        }
    }
}
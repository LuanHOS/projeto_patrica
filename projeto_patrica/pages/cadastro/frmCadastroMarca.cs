using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroMarca : frmCadastro
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
                MessageBox.Show("Preencha o nome da marca para salvar.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oMarca.Id = Convert.ToInt32(txtCodigo.Text);
            oMarca.Nome = txtNome.Text;
            oMarca.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.Yes)
                    {
                        aController_marca.Excluir(oMarca);
                        MessageBox.Show("A marca \"" + oMarca.Nome + "\" foi excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    oMarca.DataUltimaEdicao = DateTime.Now;
                    txtCodigo.Text = aController_marca.Salvar(oMarca);
                    MessageBox.Show("A marca \"" + oMarca.Nome + "\" foi alterada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oMarca.DataCadastro = DateTime.Now;
                    txtCodigo.Text = aController_marca.Salvar(oMarca);
                    MessageBox.Show("A marca \"" + oMarca.Nome + "\" foi salva com o código " + txtCodigo.Text + ".", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCodigo.Text = oMarca.Id.ToString();
            txtNome.Text = oMarca.Nome;
            checkBoxAtivo.Checked = oMarca.Ativo;
            lblDataCadastroData.Text = oMarca.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oMarca.DataUltimaEdicao?.ToShortDateString() ?? " ";
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
    }
}

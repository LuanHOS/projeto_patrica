using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroCidade : projeto_patrica.pages.cadastro.frmCadastro
    {
        private cidade aCidade;
        private Controller_cidade aController_cidade;
        private frmConsultaEstado oFrmConsultaEstado;

        public frmCadastroCidade() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCidade = (cidade)obj;
            aController_cidade = (Controller_cidade)ctrl;
        }

        public void setConsultaEstado(frmConsultaEstado consulta)
        {
            oFrmConsultaEstado = consulta;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || 
                aCidade.OEstado == null
                )
            {
                txtNome.Focus();
                txtEstado.Focus();

                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            aCidade.Id = Convert.ToInt32(txtCodigo.Text);
            aCidade.Nome = txtNome.Text;
            aCidade.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        txtCodigo.Text = aController_cidade.Excluir(aCidade);
                        MessageBox.Show("A cidade \"" + aCidade.Nome + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_cidade.Salvar(aCidade);
                    MessageBox.Show("A cidade \"" + aCidade.Nome + "\" foi alterada com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_cidade.Salvar(aCidade);
                    MessageBox.Show("A cidade \"" + aCidade.Nome + "\" foi salva com o código " + txtCodigo.Text + ".");
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
            txtEstado.Clear();
            aCidade.OEstado = new estado();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = aCidade.Id.ToString();
            txtNome.Text = aCidade.Nome;
            txtEstado.Text = aCidade.OEstado.Nome;
            checkBoxAtivo.Checked = aCidade.Ativo;
            lblDataCadastroData.Text = aCidade.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = aCidade.DataUltimaEdicao?.ToShortDateString() ?? " ";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtNome.Enabled = false;
            txtEstado.Enabled = false;
            btnPesquisarEstado.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            txtNome.Enabled = true;
            txtEstado.Enabled = true;
            btnPesquisarEstado.Enabled = true;
        }

        private void btnPesquisarEstado_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaEstado == null)
                oFrmConsultaEstado = new frmConsultaEstado();

            estado oEstado = new estado();
            Controller_estado controller = new Controller_estado();
            oFrmConsultaEstado.ConhecaObj(oEstado, controller);
            oFrmConsultaEstado.ShowDialog();

            if (oEstado.Id != 0)
            {
                aCidade.OEstado = oEstado;
                txtEstado.Text = oEstado.Nome;
            }
        }
        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtNome.MaxLength = 58;
        }
    }
}

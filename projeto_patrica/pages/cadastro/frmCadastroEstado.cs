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
                        txtCodigo.Text = aController_estado.Excluir(oEstado);
                        MessageBox.Show("O estado \"" + oEstado.Nome + "\" foi excluído com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_estado.Salvar(oEstado);
                    MessageBox.Show("O estado \"" + oEstado.Nome + "\" foi alterado com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_estado.Salvar(oEstado);
                    MessageBox.Show("O estado \"" + oEstado.Nome + "\" foi salvo com o código " + txtCodigo.Text + ".");
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
    }
}

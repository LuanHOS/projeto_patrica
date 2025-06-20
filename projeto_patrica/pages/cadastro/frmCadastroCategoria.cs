using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroCategoria : frmCadastro
    {
        private categoria oCategoria;
        private Controller_categoria aController_categoria;

        public frmCadastroCategoria() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCategoria = (categoria)obj;
            aController_categoria = (Controller_categoria)ctrl;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("Preencha o nome da categoria para salvar.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oCategoria.Id = Convert.ToInt32(txtCodigo.Text);
            oCategoria.Nome = txtNome.Text;
            oCategoria.Descricao = txtDescricao.Text;
            oCategoria.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.Yes)
                    {
                        aController_categoria.Excluir(oCategoria);
                        MessageBox.Show("A categoria \"" + oCategoria.Nome + "\" foi excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    oCategoria.DataUltimaEdicao = DateTime.Now;
                    txtCodigo.Text = aController_categoria.Salvar(oCategoria);
                    MessageBox.Show("A categoria \"" + oCategoria.Nome + "\" foi alterada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oCategoria.DataCadastro = DateTime.Now;
                    txtCodigo.Text = aController_categoria.Salvar(oCategoria);
                    MessageBox.Show("A categoria \"" + oCategoria.Nome + "\" foi salva com o código " + txtCodigo.Text + ".", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtDescricao.Clear();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();
            txtCodigo.Text = oCategoria.Id.ToString();
            txtNome.Text = oCategoria.Nome;
            txtDescricao.Text = oCategoria.Descricao;
            checkBoxAtivo.Checked = oCategoria.Ativo;
            lblDataCadastroData.Text = oCategoria.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oCategoria.DataUltimaEdicao?.ToShortDateString() ?? " ";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
        }
    }
}

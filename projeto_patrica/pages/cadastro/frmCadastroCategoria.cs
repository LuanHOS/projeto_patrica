using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroCategoria : projeto_patrica.pages.cadastro.frmCadastro
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
                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
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
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_categoria.Excluir(oCategoria);
                        MessageBox.Show("A categoria \"" + oCategoria.Nome + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    aController_categoria.Salvar(oCategoria);
                    MessageBox.Show("A categoria \"" + oCategoria.Nome + "\" foi alterada com sucesso.");
                }
                else
                {
                    aController_categoria.Salvar(oCategoria);
                    MessageBox.Show("A categoria \"" + oCategoria.Nome + "\" foi salva com o código " + txtCodigo.Text + ".");
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

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtNome.MaxLength = 40;
            txtDescricao.MaxLength = 80;
        }
    }
}
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
	public partial class frmCadastroPais : projeto_patrica.pages.cadastro.frmCadastro
	{
        private pais oPais;
        private Controller_pais aController_pais;

        public frmCadastroPais() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oPais = (pais)obj;
            aController_pais = (Controller_pais)ctrl;
        }
        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                txtNome.Focus();
                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oPais.Id = Convert.ToInt32(txtCodigo.Text);
            oPais.Nome = txtNome.Text;
            oPais.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_pais.Excluir(oPais);
                        MessageBox.Show("O país \"" + oPais.Nome + "\" foi excluído com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    aController_pais.Salvar(oPais);
                    MessageBox.Show("O país \"" + oPais.Nome + "\" foi alterado com sucesso.");
                }
                else
                {
                    aController_pais.Salvar(oPais);
                    MessageBox.Show("O país \"" + oPais.Nome + "\" foi salvo com o código " + txtCodigo.Text + ".");
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
            txtCodigo.Text = Convert.ToString(oPais.Id);
            txtNome.Text = oPais.Nome;
            lblDataCadastroData.Text = oPais.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oPais.DataUltimaEdicao?.ToShortDateString() ?? " ";
            checkBoxAtivo.Checked = oPais.Ativo;
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

            txtNome.MaxLength = 85;
        }
    }
}

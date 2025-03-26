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
        public frmCadastroPais()
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
            base.Salvar();

            if (txtNome.Text == "")
            {
                MessageBox.Show("Campo Obrigatório: Nome do país");
                txtNome.Focus();
                return;
            }

            oPais.Id = Convert.ToInt16(txtCodigo.Text);
            oPais.Nome = txtNome.Text;

            if (btnSave.Text == "Excluir")
            {
                DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    this.txtCodigo.Text = aController_pais.Excluir(oPais);
                    MessageBox.Show("O país \"" + oPais.Nome + "\" foi excluído com sucesso.");
                    Sair();
                }
            }
            else if (btnSave.Text == "Alterar")
            {
                this.txtCodigo.Text = aController_pais.Salvar(oPais);
                MessageBox.Show("O país \"" + oPais.Nome + "\" foi alterado com sucesso.");
            }
            else
            {
                this.txtCodigo.Text = aController_pais.Salvar(oPais);
                MessageBox.Show("O país \"" + oPais.Nome + "\" foi salvo com o código " + this.txtCodigo.Text + ".");
            }
        }



        public override void Limpartxt()
        {
            base.Limpartxt();
            this.txtCodigo.Text = "0";
            this.txtNome.Clear();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();
            this.txtCodigo.Text = Convert.ToString(oPais.Id);
            this.txtNome.Text = oPais.Nome;
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            this.txtNome.Enabled = false;
        }
        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            this.txtNome.Enabled = true;
        }
    }
}

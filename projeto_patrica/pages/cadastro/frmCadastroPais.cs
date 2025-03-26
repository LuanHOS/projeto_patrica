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
            if (txtNome.Text == "")
            {
                MessageBox.Show("Campo Obrigatorio: Nome do país");
                txtNome.Focus();
            }
            else
            {
                oPais.Id = Convert.ToInt16(txtCodigo.Text);
                oPais.Nome = txtNome.Text;
                
                if (btnSave.Text == "Excluir")
                    this.txtCodigo.Text = aController_pais.Excluir(oPais);
                else
                {
                    this.txtCodigo.Text = aController_pais.Salvar(oPais);
                    MessageBox.Show("o" + oPais.Nome + "foi salvo com o codigo " + this.txtCodigo.Text);
                }
            }
        }


        public override void Alterar()
        {

            oPais.Id = Convert.ToInt16(txtCodigo.Text);
            oPais.Nome = txtNome.Text;
            this.txtCodigo.Text = aController_pais.Salvar(oPais);
            MessageBox.Show("o" + oPais.Nome + "foi alterado.");


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

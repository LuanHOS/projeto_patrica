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
    public partial class frmCadastro : projeto_patrica.frmBase
    {
        public frmCadastro() : base()
        {
            InitializeComponent();
            //ConfigurarFormularioBase();
            this.txtCodigo.Enabled = false;

        }


        /*
         * 
         */


        public virtual void Salvar()
        {
            Sair();
        }


        /*
         * 
         */


        public virtual void Alterar()
        {
            Sair();
        }


        /*
         * 
         */


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }


        /*
         * 
         */


        public virtual void Limpartxt()
        {
            this.txtCodigo.Text = "0";
        }


        /*
         * 
         */


        public virtual void Carregatxt()
        {
        }


        /*
         * 
         */


        public virtual void Bloqueiatxt()
        {
            this.txtCodigo.Enabled = false;
        }


        /*
         * 
         */


        public virtual void Desbloqueiatxt()
        {
            //this.txtCodigo.Enabled = true;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {

        }
    }
}

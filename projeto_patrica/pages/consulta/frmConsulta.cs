using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
	public partial class frmConsulta : projeto_patrica.frmBase
	{
		public frmConsulta()
		{
			InitializeComponent();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        public virtual void Incluir()
        {

        }

        public virtual void Excluir()
        {

        }

        public virtual void Alterar()
        {

        }

        public virtual void Pesquisar()
        {

        }

        public virtual void LimparPesquisa()
        {
            txtCodigo.Text = " ";
            CarregaLV();
        }


        public virtual void setFrmCadastro(object obj)
        {

        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Incluir();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Alterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnLimparPesquisa_Click(object sender, EventArgs e)
        {
            LimparPesquisa();
        }

        public virtual void CarregaLV()
        {

        }

        public virtual void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

    }
}

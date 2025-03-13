using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_patrica
{
	public partial class frmPrincipal : Form
	{
        private formaPagamento aFormaPagamento;
        private condicaoPagamento aCondicaoPagamento;
        private Interfaces aInter;
        private Controller_formaPagamento oController_formaPagamento;
        private Controller_condicaoPagamento oController_condicaoPagamento;

        public frmPrincipal()
		{
            InitializeComponent();
            aFormaPagamento = new formaPagamento();
            aInter = new Interfaces();
            oController_formaPagamento = new Controller_formaPagamento();

            aCondicaoPagamento = new condicaoPagamento();
            oController_condicaoPagamento = new Controller_condicaoPagamento();
        }

        private void formaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFormaPagamento(aFormaPagamento, oController_formaPagamento);

        }

        private void condiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaCondicaoPagamento(aCondicaoPagamento, oController_condicaoPagamento);
        }
    }
}

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
        //Interface
        private Interfaces aInter;

        //Classes
        private formaPagamento aFormaPagamento;
        private condicaoPagamento aCondicaoPagamento;
        private pais oPais;
        private estado oEstado;
        private cidade aCidade;

        //Controllers
        private Controller_formaPagamento oController_formaPagamento;
        private Controller_condicaoPagamento oController_condicaoPagamento;
        private Controller_pais oController_pais;
        private Controller_estado oController_estado;
        private Controller_cidade oController_cidade;


        /*
         * 
         */


        public frmPrincipal()
        {
            InitializeComponent();

            // Instanciando Interface
            aInter = new Interfaces();

            // Instanciando Classes
            aFormaPagamento = new formaPagamento();
            aCondicaoPagamento = new condicaoPagamento();
            oPais = new pais();
            oEstado = new estado();
            aCidade = new cidade();

            // Instanciando Controllers
            oController_formaPagamento = new Controller_formaPagamento();
            oController_condicaoPagamento = new Controller_condicaoPagamento();
            oController_pais = new Controller_pais();
            oController_estado = new Controller_estado();
            oController_cidade = new Controller_cidade();

            // Passando dependências de controllers
            oController_condicaoPagamento.AController_formaPagamento = oController_formaPagamento;
            oController_cidade.AController_estado = oController_estado;
        }


        /*
         * 
         */


        private void formaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFormaPagamento(aFormaPagamento, oController_formaPagamento);
        }


        /*
         * 
         */


        private void condiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCondicaoPagamento(aCondicaoPagamento, oController_condicaoPagamento);
        }


        /*
         * 
         */


        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaPais(oPais, oController_pais);
        }


        /*
         * 
         */


        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaEstado(oEstado, oController_estado);
        }


        /*
         * 
         */


        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCidade(aCidade, oController_cidade);
        }


        /*
         * 
         */


        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /*
         * 
         */


        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /*
         * 
         */


        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

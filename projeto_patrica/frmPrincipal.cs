﻿using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
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
        private cliente oCliente;
        private funcionario oFuncionario;
        private fornecedor oFornecedor;

        //Controllers
        private Controller_formaPagamento oController_formaPagamento;
        private Controller_condicaoPagamento oController_condicaoPagamento;
        private Controller_pais oController_pais;
        private Controller_estado oController_estado;
        private Controller_cidade oController_cidade;
        private Controller_cliente oController_cliente;
        private Controller_funcionario oController_funcionario;
        private Controller_fornecedor oController_fornecedor;

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
            oCliente = new cliente();
            oFuncionario = new funcionario();
            oFornecedor = new fornecedor();

            // Instanciando Controllers
            oController_formaPagamento = new Controller_formaPagamento();
            oController_condicaoPagamento = new Controller_condicaoPagamento();
            oController_pais = new Controller_pais();
            oController_estado = new Controller_estado();
            oController_cidade = new Controller_cidade();
            oController_cliente = new Controller_cliente();
            oController_funcionario = new Controller_funcionario();
            oController_fornecedor = new Controller_fornecedor();

            // Passando dependências de controllers
            oController_condicaoPagamento.AController_formaPagamento = oController_formaPagamento;
            oController_cidade.AController_estado = oController_estado;
            oController_cliente.AController_cidade = oController_cidade;
            oController_funcionario.AController_cidade = oController_cidade;
            oController_fornecedor.AController_cidade = oController_cidade;
            oController_cliente.AController_condicaoPagamento = oController_condicaoPagamento;
            oController_fornecedor.AController_condicaoPagamento = oController_condicaoPagamento;
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
            aInter.pecaConsultaCliente(oCliente, oController_cliente);
        }

        /*
         * 
         */

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFuncionario(oFuncionario, oController_funcionario);
        }

        /*
         * 
         */

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFornecedor(oFornecedor, oController_fornecedor);
        }
    }
}

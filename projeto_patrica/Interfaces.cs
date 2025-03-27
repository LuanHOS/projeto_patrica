using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using projeto_patrica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica
{
    internal class Interfaces
    {
        // Formulários de Cadastro
        frmCadastroCondicaoPagamento oFrmCadCondPag;
        frmCadastroFormaPagamento oFrmCadFormPag;
        frmCadastroPais oFrmCadPais;
        frmCadastroEstado oFrmCadEstado;
        frmCadastroCidade oFrmCadCidade;
        frmCadastroCliente oFrmCadCliente;


        // Formulários de Consulta
        frmConsultaCondicaoPagamento oFrmConCondPag;
        frmConsultaFormaPagamento oFrmConFormPag;
        frmConsultaPais oFrmConPais;
        frmConsultaEstado oFrmConEstado;
        frmConsultaCidade oFrmConCidade;
        frmConsultaCliente oFrmConCliente;


        /*
         * 
         */


        public Interfaces()
        {
            oFrmConCondPag = new frmConsultaCondicaoPagamento();
            oFrmConFormPag = new frmConsultaFormaPagamento();
            oFrmConPais = new frmConsultaPais();
            oFrmConEstado = new frmConsultaEstado();
            oFrmConCidade = new frmConsultaCidade();
            oFrmConCliente = new frmConsultaCliente();


            oFrmCadCondPag = new frmCadastroCondicaoPagamento();
            oFrmCadFormPag = new frmCadastroFormaPagamento();
            oFrmCadPais = new frmCadastroPais();
            oFrmCadEstado = new frmCadastroEstado();
            oFrmCadCidade = new frmCadastroCidade();
            oFrmCadCliente = new frmCadastroCliente();


            oFrmConCondPag.setFrmCadastro(oFrmCadCondPag);
            oFrmConFormPag.setFrmCadastro(oFrmCadFormPag);
            oFrmConPais.setFrmCadastro(oFrmCadPais);
            oFrmConEstado.setFrmCadastro(oFrmCadEstado);
            oFrmConCidade.setFrmCadastro(oFrmCadCidade);
            oFrmConCliente.setFrmCadastro(oFrmCadCliente);


            oFrmCadCondPag.setConsultaFormaPagamento(oFrmConFormPag);
            oFrmCadEstado.setConsultaPais(oFrmConPais);
            oFrmCadCidade.setConsultaEstado(oFrmConEstado);
            oFrmCadCliente.setConsultaCidade(oFrmConCidade);
        }


        /*
         * 
         */


        public void pecaConsultaCondicaoPagamento(condicaoPagamento oCondicaoPagamento, Controller_condicaoPagamento oController_condicaoPagamento)
        {
            oFrmConCondPag.ConhecaObj(oCondicaoPagamento, oController_condicaoPagamento);
            oFrmConCondPag.ShowDialog();
        }


        /*
         * 
         */


        public void pecaConsultaFormaPagamento(formaPagamento aFormaPagamento, Controller_formaPagamento oController_formaPagamento)
        {
            oFrmConFormPag.ConhecaObj(aFormaPagamento, oController_formaPagamento);
            oFrmConFormPag.ShowDialog();
        }


        /*
         * 
         */


        public void pecaConsultaPais(pais oPais, Controller_pais oController_pais)
        {
            oFrmConPais.ConhecaObj(oPais, oController_pais);
            oFrmConPais.ShowDialog();
        }


        /*
         * 
         */


        public void pecaConsultaEstado(estado oEstado, Controller_estado oController_estado)
        {
            oFrmConEstado.ConhecaObj(oEstado, oController_estado);
            oFrmConEstado.ShowDialog();
        }


        /*
         * 
         */


        public void pecaConsultaCidade(cidade aCidade, Controller_cidade oController_cidade)
        {
            oFrmConCidade.ConhecaObj(aCidade, oController_cidade);
            oFrmConCidade.ShowDialog();
        }


        /*
         * 
         */


        public void pecaConsultaFuncionario(cidade aCidade, Controller_cidade oController_cidade)
        {

        }


        /*
         * 
         */


        public void pecaConsultaCliente(cliente oCliente, Controller_cliente oController_cliente)
        {
            oFrmConCliente.ConhecaObj(oCliente, oController_cliente);
            oFrmConCliente.ShowDialog();
        }


        /*
         * 
         */


        public void pecaConsultaFornecedor(cidade aCidade, Controller_cidade oController_cidade)
        {

        }
    }
}

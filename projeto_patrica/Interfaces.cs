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
        frmCadastroCondicaoPagamento oFrmCadCondPag;
        frmCadastroFormaPagamento oFrmCadFormPag;
        frmCadastroParcelaCondicaoPagamento oFrmCadParcCondPag;

        //frmConsultaCondicaoPagamento oFrmConCondPag;
        frmConsultaFormaPagamento oFrmConFormPag;
        //frmConsultaParcelaCondicaoPagamento oFrmConParcCondPag;

        public Interfaces()
        {
            //oFrmConCondPag = new frmConsultaCondicaoPagamento();
            oFrmConFormPag = new frmConsultaFormaPagamento();
            //oFrmConParcCondPag = new frmConsultaParcelaCondicaoPagamento();


            oFrmCadCondPag = new frmCadastroCondicaoPagamento();
            oFrmCadFormPag = new frmCadastroFormaPagamento();
            oFrmCadParcCondPag = new frmCadastroParcelaCondicaoPagamento();


            //oFrmConNotebooks.setFrmCadastro(oFrmCadNotebooks);

            //oFrmCadNotebooks.setConsultaPlacas_de_video(oFrmConPlacas_de_video);

            oFrmConFormPag.setFrmCadastro(oFrmCadFormPag);
        }
        /*public void pecaCondicaoPagamento(condicaoPagamento oCondicaoPagamento, Controller_condicaoPagamento oController_condicaoPagamento)
        {
            oFrmConCondPag.ConhecaObj(oCondicaoPagamento, oController_condicaoPagamento);
            oFrmConCondPag.ShowDialog();
        }*/
        public void pecaConsultaFormaPagamento(formaPagamento aFormaPagamento, Controller_formaPagamento oController_formaPagamento)
        {
            oFrmConFormPag.ConhecaObj(aFormaPagamento, oController_formaPagamento);
            oFrmConFormPag.ShowDialog();
        }
    }
}

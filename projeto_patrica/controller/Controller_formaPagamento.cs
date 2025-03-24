using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    internal class Controller_formaPagamento : Controller
    {
        private Dao_formaPagamento aDao_formaPagamento;


        /*
         * 
         */


        public Controller_formaPagamento()
        {
            aDao_formaPagamento = new Dao_formaPagamento();
        }


        /*
         * 
         */


        public override string Salvar(object obj)
        {
            return aDao_formaPagamento.Salvar(obj);
        }


        /*
         * 
         */


        public override string CarregaObj(object obj)
        {
            return aDao_formaPagamento.CarregaObj(obj);
        }


        /*
         * 
         */


        public override string Excluir(object obj)
        {
            return aDao_formaPagamento.Excluir(obj);
        }


        /*
         * 
         */


        public List<formaPagamento> ListaFormaPagamento()
        {
            return aDao_formaPagamento.ListarFormaPagamento();
        }
    }
}

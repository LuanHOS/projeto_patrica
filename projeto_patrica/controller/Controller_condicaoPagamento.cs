using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    internal class Controller_condicaoPagamento : Controller
    {
        private Dao_condicaoPagamento aDao_condicaoPagamento;

        public Controller_condicaoPagamento()
        {
            aDao_condicaoPagamento = new Dao_condicaoPagamento();
        }

        public override string Salvar(object obj)
        {
            return aDao_condicaoPagamento.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_condicaoPagamento.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_condicaoPagamento.Excluir(obj);
        }

        public List<condicaoPagamento> ListaCondicaoPagamento()
        {
            return aDao_condicaoPagamento.ListarCondicaoPagamento();
        }

        public List<parcelaCondicaoPagamento> ListaParcelas(int idCondicaoPagamento)
        {
            return aDao_condicaoPagamento.ListarParcelas(idCondicaoPagamento);
        }

        public string SalvarParcela(parcelaCondicaoPagamento parcela)
        {
            return aDao_condicaoPagamento.SalvarParcela(parcela);
        }

        public string ExcluirParcela(parcelaCondicaoPagamento parcela)
        {
            return aDao_condicaoPagamento.ExcluirParcela(parcela);
        }
    }
}

using projeto_patrica.classes;
using projeto_patrica.dao;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    internal class Controller_condicaoPagamento : Controller
    {
        private Dao_condicaoPagamento aDao_condicaoPagamento;
        private Controller_formaPagamento aController_formaPagamento;

        public Controller_condicaoPagamento()
        {
            aDao_condicaoPagamento = new Dao_condicaoPagamento();
            aController_formaPagamento = new Controller_formaPagamento();
        }

        public override string Salvar(object obj)
        {
            return aDao_condicaoPagamento.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_condicaoPagamento.Excluir(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_condicaoPagamento.CarregaObj(obj);
        }

        public List<condicaoPagamento> ListaCondicaoPagamento()
        {
            return aDao_condicaoPagamento.ListarCondicaoPagamento();
        }

        public List<parcelaCondicaoPagamento> ListaParcelas(int idCondicaoPagamento)
        {
            return aDao_condicaoPagamento.ListarParcelas(idCondicaoPagamento);
        }

        public string SalvarParcela(parcelaCondicaoPagamento parcela, MySqlConnection conn)
        {
            return aDao_condicaoPagamento.SalvarParcela(parcela, conn);
        }

        public string ExcluirParcela(parcelaCondicaoPagamento parcela)
        {
            return aDao_condicaoPagamento.ExcluirParcela(parcela);
        }

        public List<parcelaCondicaoPagamento> ObterParcelasPorCondicaoPagamentoId(int condicaoPagamentoId)
        {
            return aDao_condicaoPagamento.ListarParcelas(condicaoPagamentoId);
        }

        public Controller_formaPagamento AController_formaPagamento
        {
            get => aController_formaPagamento;
            set => aController_formaPagamento = value;
        }
    }
}

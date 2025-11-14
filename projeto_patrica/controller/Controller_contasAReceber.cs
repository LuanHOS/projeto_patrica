using projeto_patrica.classes;
using projeto_patrica.dao;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    class Controller_contasAReceber : Controller
    {
        private Dao_contasAReceber aDao_contasAReceber;
        private Controller_cliente aController_cliente;
        private Controller_formaPagamento aController_formaPagamento;

        public Controller_contasAReceber()
        {
            aDao_contasAReceber = new Dao_contasAReceber();
        }

        public Controller_cliente AController_cliente
        {
            get => aController_cliente;
            set => aController_cliente = value;
        }

        public Controller_formaPagamento AController_formaPagamento
        {
            get => aController_formaPagamento;
            set => aController_formaPagamento = value;
        }

        public override string Salvar(object obj)
        {
            return aDao_contasAReceber.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            contasAReceber oContaAReceber = (contasAReceber)obj;
            string retorno = aDao_contasAReceber.CarregaObj(oContaAReceber);

            if (retorno == "" && oContaAReceber.OCliente.Id > 0 && oContaAReceber.AFormaPagamento.Id > 0)
            {
                if (aController_cliente != null)
                {
                    aController_cliente.CarregaObj(oContaAReceber.OCliente);
                }

                if (aController_formaPagamento != null)
                {
                    aController_formaPagamento.CarregaObj(oContaAReceber.AFormaPagamento);
                }
            }
            return retorno;
        }

        public override string Excluir(object obj)
        {
            return aDao_contasAReceber.Excluir(obj);
        }

        public List<contasAReceber> ListaContasAReceber()
        {
            List<contasAReceber> lista = aDao_contasAReceber.ListarContasAReceber();

            foreach (contasAReceber conta in lista)
            {
                if (conta.OCliente.Id > 0 && aController_cliente != null)
                {
                    aController_cliente.CarregaObj(conta.OCliente);
                }
                if (conta.AFormaPagamento.Id > 0 && aController_formaPagamento != null)
                {
                    aController_formaPagamento.CarregaObj(conta.AFormaPagamento);
                }
            }
            return lista;
        }
    }
}
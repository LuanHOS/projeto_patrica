using projeto_patrica.classes;
using projeto_patrica.dao;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    class Controller_contasAPagar : Controller
    {
        private Dao_contasAPagar aDao_contasAPagar;
        private Controller_fornecedor aController_fornecedor;
        private Controller_formaPagamento aController_formaPagamento;

        public Controller_contasAPagar()
        {
            aDao_contasAPagar = new Dao_contasAPagar();
        }

        public Controller_fornecedor AController_fornecedor
        {
            get => aController_fornecedor;
            set => aController_fornecedor = value;
        }

        public Controller_formaPagamento AController_formaPagamento
        {
            get => aController_formaPagamento;
            set => aController_formaPagamento = value;
        }

        public override string Salvar(object obj)
        {
            return aDao_contasAPagar.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            contasAPagar oContaAPagar = (contasAPagar)obj;
            string retorno = aDao_contasAPagar.CarregaObj(oContaAPagar);

            if (retorno == "" && oContaAPagar.OFornecedor.Id > 0 && oContaAPagar.AFormaPagamento.Id > 0)
            {
                if (aController_fornecedor != null)
                {
                    aController_fornecedor.CarregaObj(oContaAPagar.OFornecedor);
                }

                if (aController_formaPagamento != null)
                {
                    aController_formaPagamento.CarregaObj(oContaAPagar.AFormaPagamento);
                }
            }
            return retorno;
        }

        public override string Excluir(object obj)
        {
            return aDao_contasAPagar.Excluir(obj);
        }

        public List<contasAPagar> ListaContasAPagar()
        {
            List<contasAPagar> lista = aDao_contasAPagar.ListarContasAPagar();

            foreach (contasAPagar conta in lista)
            {
                if (conta.OFornecedor.Id > 0 && aController_fornecedor != null)
                {
                    aController_fornecedor.CarregaObj(conta.OFornecedor);
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
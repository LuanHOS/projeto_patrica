using projeto_patrica.classes;
using projeto_patrica.dao;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    class Controller_compra : Controller
    {
        private Dao_compra aDao_compra;
        private Controller_fornecedor aController_fornecedor;
        private Controller_condicaoPagamento aController_condicaoPagamento;
        private Controller_produto aController_produto;

        public Controller_compra()
        {
            aDao_compra = new Dao_compra();
            aController_fornecedor = new Controller_fornecedor();
            aController_condicaoPagamento = new Controller_condicaoPagamento();
            aController_produto = new Controller_produto();
        }

        public override string Salvar(object obj)
        {
            return aDao_compra.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_compra.Excluir(obj);
        }

        public override string CarregaObj(object obj)
        {
            compra aCompra = (compra)obj;
            string retorno = aDao_compra.CarregaObj(aCompra);

            if (retorno == "")
            {
                // Carrega os dados completos do fornecedor e da condição de pagamento
                aController_fornecedor.CarregaObj(aCompra.OFornecedor);
                aController_condicaoPagamento.CarregaObj(aCompra.ACondicaoPagamento);

                // Carrega os dados completos de cada produto nos itens da compra
                foreach (itemCompra item in aCompra.Itens)
                {
                    aController_produto.CarregaObj(item.OProduto);
                }
            }

            return retorno;
        }

        public List<compra> ListaCompras()
        {
            List<compra> lista = aDao_compra.ListarCompras();

            // Para cada compra na lista, carrega os dados completos do fornecedor
            foreach (compra aCompra in lista)
            {
                aController_fornecedor.CarregaObj(aCompra.OFornecedor);
            }

            return lista;
        }

        public Controller_fornecedor AController_fornecedor
        {
            get => aController_fornecedor;
            set => aController_fornecedor = value;
        }

        public Controller_condicaoPagamento AController_condicaoPagamento
        {
            get => aController_condicaoPagamento;
            set => aController_condicaoPagamento = value;
        }

        public Controller_produto AController_produto
        {
            get => aController_produto;
            set => aController_produto = value;
        }
    }
}

using projeto_patrica.classes;
using projeto_patrica.dao;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    class Controller_venda : Controller
    {
        private Dao_venda aDao_venda;
        private Controller_cliente aController_cliente;
        private Controller_funcionario aController_funcionario;
        private Controller_condicaoPagamento aController_condicaoPagamento;
        private Controller_produto aController_produto;
        private Controller_contasAReceber aController_contasAReceber;

        public Controller_venda()
        {
            aDao_venda = new Dao_venda();
            aController_cliente = new Controller_cliente();
            aController_funcionario = new Controller_funcionario();
            aController_condicaoPagamento = new Controller_condicaoPagamento();
            aController_produto = new Controller_produto();
        }

        public override string Salvar(object obj)
        {
            return aDao_venda.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_venda.Excluir(obj);
        }

        public override string CarregaObj(object obj)
        {
            venda aVenda = (venda)obj;
            string retorno = aDao_venda.CarregaObj(aVenda);

            if (retorno == "")
            {
                aController_cliente.CarregaObj(aVenda.OCliente);
                aController_funcionario.CarregaObj(aVenda.OFuncionario);
                aController_condicaoPagamento.CarregaObj(aVenda.ACondicaoPagamento);

                foreach (itemVenda item in aVenda.Itens)
                {
                    aController_produto.CarregaObj(item.OProduto);
                }
            }

            return retorno;
        }

        public List<venda> ListaVendas()
        {
            List<venda> lista = aDao_venda.ListarVendas();

            foreach (venda aVenda in lista)
            {
                aController_cliente.CarregaObj(aVenda.OCliente);
                aController_funcionario.CarregaObj(aVenda.OFuncionario);
                aController_condicaoPagamento.CarregaObj(aVenda.ACondicaoPagamento);
            }

            return lista;
        }

        public Controller_cliente AController_cliente
        {
            get => aController_cliente;
            set => aController_cliente = value;
        }

        public Controller_funcionario AController_funcionario
        {
            get => aController_funcionario;
            set => aController_funcionario = value;
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
        public Controller_contasAReceber AController_contasAReceber
        {
            get => aController_contasAReceber;
            set => aController_contasAReceber = value;
        }
    }
}
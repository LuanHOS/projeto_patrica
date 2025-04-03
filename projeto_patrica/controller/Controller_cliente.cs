using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_cliente : Controller
    {
        Dao_cliente aDao_cliente;
        Controller_cidade aController_cidade;
        Controller_condicaoPagamento aController_condicaoPagamento;

        public Controller_cliente()
        {
            aDao_cliente = new Dao_cliente();
            aController_cidade = new Controller_cidade();
        }

        public override string Salvar(object obj)
        {
            return aDao_cliente.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_cliente.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_cliente.Excluir(obj);
        }

        public List<cliente> ListaClientes()
        {
            List<cliente> lista = aDao_cliente.ListarClientes();

            foreach (cliente oCliente in lista)
            {
                aController_cidade.CarregaObj(oCliente.ACidade);
            }

            return lista;
        }

        public Controller_cidade AController_cidade
        {
            get => aController_cidade;
            set => aController_cidade = value;
        }

        public Controller_condicaoPagamento AController_condicaoPagamento
        {
            get => aController_condicaoPagamento;
            set => aController_condicaoPagamento = value;
        }
    }
}

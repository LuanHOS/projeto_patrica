using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_transportadora : Controller
    {
        Dao_transportadora aDao_transportadora;
        Controller_cidade aController_cidade;
        Controller_condicaoPagamento aController_condicaoPagamento;

        public Controller_transportadora()
        {
            aDao_transportadora = new Dao_transportadora();
            aController_cidade = new Controller_cidade();
            aController_condicaoPagamento = new Controller_condicaoPagamento();
        }

        public override string Salvar(object obj)
        {
            return aDao_transportadora.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_transportadora.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_transportadora.Excluir(obj);
        }

        public List<transportadora> ListaTransportadoras()
        {
            List<transportadora> lista = aDao_transportadora.ListarTransportadoras();

            foreach (transportadora oTransportadora in lista)
            {
                aController_cidade.CarregaObj(oTransportadora.ACidade);
                aController_condicaoPagamento.CarregaObj(oTransportadora.ACondicaoPagamento);
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

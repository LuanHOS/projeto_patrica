﻿using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_fornecedor : Controller
    {
        Dao_fornecedor aDao_fornecedor;
        Controller_cidade aController_cidade;
        Controller_condicaoPagamento aController_condicaoPagamento;

        public Controller_fornecedor()
        {
            aDao_fornecedor = new Dao_fornecedor();
            aController_cidade = new Controller_cidade();
            aController_condicaoPagamento = new Controller_condicaoPagamento();
        }

        public override string Salvar(object obj)
        {
            return aDao_fornecedor.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_fornecedor.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_fornecedor.Excluir(obj);
        }

        public List<fornecedor> ListaFornecedores()
        {
            List<fornecedor> lista = aDao_fornecedor.ListarFornecedores();

            foreach (fornecedor oFornecedor in lista)
            {
                aController_cidade.CarregaObj(oFornecedor.ACidade);
                aController_condicaoPagamento.CarregaObj(oFornecedor.ACondicaoPagamento);
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

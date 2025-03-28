﻿using projeto_patrica.classes;
using projeto_patrica.dao;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    class Controller_cidade : Controller
    {
        Dao_cidade aDao_cidade;
        Controller_estado aController_estado;

        public Controller_cidade()
        {
            aDao_cidade = new Dao_cidade();
            aController_estado = new Controller_estado();
        }

        public override string Salvar(object obj)
        {
            return aDao_cidade.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_cidade.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_cidade.Excluir(obj);
        }

        public List<cidade> ListaCidades()
        {
            List<cidade> lista = aDao_cidade.ListarCidades();

            foreach (cidade aCidade in lista)
            {
                aController_estado.CarregaObj(aCidade.OEstado);
            }

            return lista;
        }

        public Controller_estado AController_estado
        {
            get => aController_estado;
            set => aController_estado = value;
        }
    }
}


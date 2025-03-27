using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_estado : Controller
    {
        Dao_estado aDao_estado;
        Controller_pais aController_pais;

        public Controller_estado()
        {
            aDao_estado = new Dao_estado();
            aController_pais = new Controller_pais();
        }

        public override string Salvar(object obj)
        {
            return aDao_estado.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_estado.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_estado.Excluir(obj);
        }

        public List<estado> ListaEstados()
        {
            List<estado> lista = aDao_estado.ListarEstados();

            foreach (estado oEstado in lista)
            {
                aController_pais.CarregaObj(oEstado.OPais);
            }

            return lista;
        }

        public Controller_pais AController_pais
        {
            get => aController_pais;
            set => aController_pais = value;
        }
    }
}

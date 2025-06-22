using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_unidade_medida : Controller
    {
        Dao_unidade_medida aDao_unidade_medida;
        public Controller_unidade_medida()
        {
            aDao_unidade_medida = new Dao_unidade_medida();
        }
        public override string Salvar(object obj)
        {
            return aDao_unidade_medida.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_unidade_medida.CarregaObj(obj);
        }
        public override string Excluir(object obj)
        {
            return aDao_unidade_medida.Excluir(obj);
        }

        public List<unidade_medida> ListaUnidadeMedida()
        {
            return aDao_unidade_medida.ListarUnidadeMedida();
        }
    }
}
using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_marca : Controller
    {
        Dao_marca aDao_marca;

        public Controller_marca()
        {
            aDao_marca = new Dao_marca();
        }

        public override string Salvar(object obj)
        {
            return aDao_marca.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_marca.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_marca.Excluir(obj);
        }

        public List<marca> ListaMarcas()
        {
            return aDao_marca.ListarMarcas();
        }
    }
}

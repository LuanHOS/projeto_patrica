using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_pais : Controller
    {
        Dao_pais aDao_pais;
        public Controller_pais()
        {
            aDao_pais = new Dao_pais();
        }
        public override string Salvar(object obj)
        {
            return aDao_pais.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_pais.CarregaObj(obj);
        }
        public override string Excluir(object obj)
        {
            return aDao_pais.Excluir(obj);
        }

        public List<pais> ListaPaises()
        {
            return aDao_pais.ListarPaises();
        }
    }
}

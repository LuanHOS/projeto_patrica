using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_categoria : Controller
    {
        Dao_categoria aDao_categoria;

        public Controller_categoria()
        {
            aDao_categoria = new Dao_categoria();
        }

        public override string Salvar(object obj)
        {
            return aDao_categoria.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_categoria.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_categoria.Excluir(obj);
        }

        public List<categoria> ListaCategorias()
        {
            return aDao_categoria.ListarCategorias();
        }
    }
}

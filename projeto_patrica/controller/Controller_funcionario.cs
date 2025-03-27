using projeto_patrica.classes;
using projeto_patrica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.controller
{
    class Controller_funcionario : Controller
    {
        Dao_funcionario aDao_funcionario;
        Controller_cidade aController_cidade;

        public Controller_funcionario()
        {
            aDao_funcionario = new Dao_funcionario();
            aController_cidade = new Controller_cidade();
        }

        public override string Salvar(object obj)
        {
            return aDao_funcionario.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_funcionario.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_funcionario.Excluir(obj);
        }

        public List<funcionario> ListaFuncionarios()
        {
            List<funcionario> lista = aDao_funcionario.ListarFuncionarios();

            foreach (funcionario oFuncionario in lista)
            {
                aController_cidade.CarregaObj(oFuncionario.ACidade);
            }

            return lista;
        }

        public Controller_cidade AController_cidade
        {
            get => aController_cidade;
            set => aController_cidade = value;
        }
    }
}

using projeto_patrica.classes;
using projeto_patrica.dao;
using System.Collections.Generic;

namespace projeto_patrica.controller
{
    class Controller_produto : Controller
    {
        private Dao_produto aDao_produto;
        private Controller_marca aController_marca;
        private Controller_categoria aController_categoria;
        private Controller_unidade_medida aController_unidade_medida;

        public Controller_produto()
        {
            aDao_produto = new Dao_produto();
            aController_marca = new Controller_marca();
            aController_categoria = new Controller_categoria();
            aController_unidade_medida = new Controller_unidade_medida();
        }

        public override string Salvar(object obj)
        {
            return aDao_produto.Salvar(obj);
        }

        public override string CarregaObj(object obj)
        {
            return aDao_produto.CarregaObj(obj);
        }

        public override string Excluir(object obj)
        {
            return aDao_produto.Excluir(obj);
        }

        public List<produto> ListaProdutos()
        {
            List<produto> lista = aDao_produto.ListarProdutos();

            foreach (produto oProduto in lista)
            {
                aController_marca.CarregaObj(oProduto.OMarca);
                aController_categoria.CarregaObj(oProduto.OCategoria);
                aController_unidade_medida.CarregaObj(oProduto.OUnidadeMedida);
            }

            return lista;
        }

        public Controller_marca AController_marca
        {
            get => aController_marca;
            set => aController_marca = value;
        }

        public Controller_categoria AController_categoria
        {
            get => aController_categoria;
            set => aController_categoria = value;
        }

        public Controller_unidade_medida AController_unidade_medida
        {
            get => aController_unidade_medida;
            set => aController_unidade_medida = value;
        }
    }
}
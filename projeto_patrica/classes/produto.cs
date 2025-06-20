using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class produto : pai
    {
        protected string nome;
        protected string descricao;
        protected string codigoBarras;
        protected marca oMarca;
        protected categoria oCategoria;
        protected unidade_medida oUnidadeMedida;
        protected fornecedor oFornecedor;
        protected decimal valorCompra;
        protected decimal valorVenda;
        protected decimal percentualLucro;
        protected int estoque;

        public produto()
        {
            id = 0;
            nome = " ";
            descricao = " ";
            codigoBarras = " ";
            oMarca = new marca();
            oCategoria = new categoria();
            oUnidadeMedida = new unidade_medida();
            oFornecedor = new fornecedor();
            valorCompra = 0;
            valorVenda = 0;
            percentualLucro = 0;
            estoque = 0;
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
        }

        public produto(int id, string nome, string descricao, string codigoBarras, marca oMarca, categoria oCategoria,
                       unidade_medida oUnidadeMedida, fornecedor oFornecedor, decimal valorCompra, decimal valorVenda,
                       decimal percentualLucro, int estoque, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao)
            : base(id, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.codigoBarras = codigoBarras;
            this.oMarca = oMarca;
            this.oCategoria = oCategoria;
            this.oUnidadeMedida = oUnidadeMedida;
            this.oFornecedor = oFornecedor;
            this.valorCompra = valorCompra;
            this.valorVenda = valorVenda;
            this.percentualLucro = percentualLucro;
            this.estoque = estoque;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public string CodigoBarras
        {
            get => codigoBarras;
            set => codigoBarras = value;
        }

        public marca OMarca
        {
            get => oMarca;
            set => oMarca = value;
        }

        public categoria OCategoria
        {
            get => oCategoria;
            set => oCategoria = value;
        }

        public unidade_medida OUnidadeMedida
        {
            get => oUnidadeMedida;
            set => oUnidadeMedida = value;
        }

        public fornecedor OFornecedor
        {
            get => oFornecedor;
            set => oFornecedor = value;
        }

        public decimal ValorCompra
        {
            get => valorCompra;
            set => valorCompra = value;
        }

        public decimal ValorVenda
        {
            get => valorVenda;
            set => valorVenda = value;
        }

        public decimal PercentualLucro
        {
            get => percentualLucro;
            set => percentualLucro = value;
        }

        public int Estoque
        {
            get => estoque;
            set => estoque = value;
        }
    }
}
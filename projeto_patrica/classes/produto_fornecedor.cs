using System;

namespace projeto_patrica.classes
{
    class produto_fornecedor
    {
        protected int idProduto;
        protected int idFornecedor;
        protected decimal valorUltimaCompra;
        protected DateTime dataUltimaCompra;
        protected decimal valorAtualCompra;

        public produto_fornecedor()
        {
            idProduto = 0;
            idFornecedor = 0;
            valorUltimaCompra = 0;
            dataUltimaCompra = DateTime.MinValue;
            valorAtualCompra = 0;
        }

        public produto_fornecedor(int idProduto, int idFornecedor, decimal valorUltimaCompra, DateTime dataUltimaCompra, decimal valorAtualCompra)
        {
            this.idProduto = idProduto;
            this.idFornecedor = idFornecedor;
            this.valorUltimaCompra = valorUltimaCompra;
            this.dataUltimaCompra = dataUltimaCompra;
            this.valorAtualCompra = valorAtualCompra;
        }

        public int IdProduto
        {
            get => idProduto;
            set => idProduto = value;
        }

        public int IdFornecedor
        {
            get => idFornecedor;
            set => idFornecedor = value;
        }

        public decimal ValorUltimaCompra
        {
            get => valorUltimaCompra;
            set => valorUltimaCompra = value;
        }

        public DateTime DataUltimaCompra
        {
            get => dataUltimaCompra;
            set => dataUltimaCompra = value;
        }

        public decimal ValorAtualCompra
        {
            get => valorAtualCompra;
            set => valorAtualCompra = value;
        }
    }
}
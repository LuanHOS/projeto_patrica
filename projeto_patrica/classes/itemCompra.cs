namespace projeto_patrica.classes
{
    class itemCompra
    {
        protected int modeloCompra;
        protected string serieCompra;
        protected string numeroNotaCompra;
        protected int idFornecedor;
        protected produto oProduto;
        protected int quantidade;
        protected decimal valorUnitario;

        public itemCompra()
        {
            modeloCompra = 0;
            serieCompra = " ";
            numeroNotaCompra = " ";
            idFornecedor = 0;
            oProduto = new produto();
            quantidade = 0;
            valorUnitario = 0;
        }

        public itemCompra(int modeloCompra, string serieCompra, string numeroNotaCompra, int idFornecedor, produto oProduto, int quantidade, decimal valorUnitario)
        {
            this.modeloCompra = modeloCompra;
            this.serieCompra = serieCompra;
            this.numeroNotaCompra = numeroNotaCompra;
            this.idFornecedor = idFornecedor;
            this.oProduto = oProduto;
            this.quantidade = quantidade;
            this.valorUnitario = valorUnitario;
        }

        public int ModeloCompra
        {
            get => modeloCompra;
            set => modeloCompra = value;
        }

        public string SerieCompra
        {
            get => serieCompra;
            set => serieCompra = value;
        }

        public string NumeroNotaCompra
        {
            get => numeroNotaCompra;
            set => numeroNotaCompra = value;
        }

        public int IdFornecedor
        {
            get => idFornecedor;
            set => idFornecedor = value;
        }

        public produto OProduto
        {
            get => oProduto;
            set => oProduto = value;
        }

        public int Quantidade
        {
            get => quantidade;
            set => quantidade = value;
        }

        public decimal ValorUnitario
        {
            get => valorUnitario;
            set => valorUnitario = value;
        }

        public decimal ValorTotal
        {
            get => quantidade * valorUnitario;
        }
    }
}
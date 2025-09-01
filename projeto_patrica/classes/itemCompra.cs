namespace projeto_patrica.classes
{
    class itemCompra
    {
        protected int modeloCompra;
        protected string serieCompra;
        protected string numeroNotaCompra;
        protected produto oProduto;
        protected int quantidade;
        protected decimal valorUnitario;

        public itemCompra()
        {
            modeloCompra = 0;
            serieCompra = " ";
            numeroNotaCompra = " ";
            oProduto = new produto();
            quantidade = 0;
            valorUnitario = 0;
        }

        public itemCompra(int modeloCompra, string serieCompra, string numeroNotaCompra, produto oProduto, int quantidade, decimal valorUnitario)
        {
            this.modeloCompra = modeloCompra;
            this.serieCompra = serieCompra;
            this.numeroNotaCompra = numeroNotaCompra;
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
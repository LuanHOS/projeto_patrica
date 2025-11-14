namespace projeto_patrica.classes
{
    class itemVenda
    {
        protected int modeloVenda;
        protected string serieVenda;
        protected int numeroNotaVenda;
        protected int idCliente;
        protected produto oProduto;
        protected int quantidade;
        protected decimal valorUnitario;

        public itemVenda()
        {
            modeloVenda = 0;
            serieVenda = " ";
            numeroNotaVenda = 0;
            idCliente = 0;
            oProduto = new produto();
            quantidade = 0;
            valorUnitario = 0;
        }

        public itemVenda(int modeloVenda, string serieVenda, int numeroNotaVenda, int idCliente, produto oProduto, int quantidade, decimal valorUnitario)
        {
            this.modeloVenda = modeloVenda;
            this.serieVenda = serieVenda;
            this.numeroNotaVenda = numeroNotaVenda;
            this.idCliente = idCliente;
            this.oProduto = oProduto;
            this.quantidade = quantidade;
            this.valorUnitario = valorUnitario;
        }

        public int ModeloVenda
        {
            get => modeloVenda;
            set => modeloVenda = value;
        }

        public string SerieVenda
        {
            get => serieVenda;
            set => serieVenda = value;
        }

        public int NumeroNotaVenda
        {
            get => numeroNotaVenda;
            set => numeroNotaVenda = value;
        }

        public int IdCliente
        {
            get => idCliente;
            set => idCliente = value;
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
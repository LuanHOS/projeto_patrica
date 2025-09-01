using System;

namespace projeto_patrica.classes
{
    class parcelaCompra
    {
        protected int modeloCompra;
        protected string serieCompra;
        protected string numeroNotaCompra;
        protected int numeroParcela;
        protected DateTime dataVencimento;
        protected decimal valorParcela;

        public parcelaCompra()
        {
            modeloCompra = 0;
            serieCompra = " ";
            numeroNotaCompra = " ";
            numeroParcela = 0;
            dataVencimento = DateTime.MinValue;
            valorParcela = 0;
        }

        public parcelaCompra(int modeloCompra, string serieCompra, string numeroNotaCompra, int numeroParcela, DateTime dataVencimento, decimal valorParcela)
        {
            this.modeloCompra = modeloCompra;
            this.serieCompra = serieCompra;
            this.numeroNotaCompra = numeroNotaCompra;
            this.numeroParcela = numeroParcela;
            this.dataVencimento = dataVencimento;
            this.valorParcela = valorParcela;
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

        public int NumeroParcela
        {
            get => numeroParcela;
            set => numeroParcela = value;
        }

        public DateTime DataVencimento
        {
            get => dataVencimento;
            set => dataVencimento = value;
        }

        public decimal ValorParcela
        {
            get => valorParcela;
            set => valorParcela = value;
        }
    }
}
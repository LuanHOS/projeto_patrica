using System;

namespace projeto_patrica.classes
{
    class contasAPagar
    {
        protected int modeloCompra;
        protected string serieCompra;
        protected string numeroNotaCompra;
        protected int idFornecedor;
        protected int numeroParcela;
        protected DateTime dataEmissao;
        protected DateTime dataVencimento;
        protected decimal valorParcela;
        protected formaPagamento aFormaPagamento;
        protected bool ativo;

        public contasAPagar()
        {
            modeloCompra = 0;
            serieCompra = " ";
            numeroNotaCompra = " ";
            idFornecedor = 0;
            numeroParcela = 0;
            dataEmissao = DateTime.MinValue;
            dataVencimento = DateTime.MinValue;
            valorParcela = 0;
            aFormaPagamento = new formaPagamento();
            ativo = true;
        }

        public contasAPagar(int modeloCompra, string serieCompra, string numeroNotaCompra, int idFornecedor, int numeroParcela, DateTime dataEmissao, DateTime dataVencimento, decimal valorParcela, formaPagamento aFormaPagamento, bool ativo)
        {
            this.modeloCompra = modeloCompra;
            this.serieCompra = serieCompra;
            this.numeroNotaCompra = numeroNotaCompra;
            this.idFornecedor = idFornecedor;
            this.numeroParcela = numeroParcela;
            this.dataEmissao = dataEmissao;
            this.dataVencimento = dataVencimento;
            this.valorParcela = valorParcela;
            this.aFormaPagamento = aFormaPagamento;
            this.ativo = ativo;
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

        public int NumeroParcela
        {
            get => numeroParcela;
            set => numeroParcela = value;
        }

        public DateTime DataEmissao
        {
            get => dataEmissao;
            set => dataEmissao = value;
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

        public formaPagamento AFormaPagamento
        {
            get => aFormaPagamento;
            set => aFormaPagamento = value;
        }
        public bool Ativo
        {
            get => ativo;
            set => ativo = value;
        }
    }
}
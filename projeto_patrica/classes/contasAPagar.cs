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
        protected int situacao; // 0 - Em aberto, 1 - Pago
        protected decimal juros;
        protected decimal multa;
        protected decimal desconto;
        protected decimal? valorPago;
        protected DateTime? dataPagamento;


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
            situacao = 0; // Default: Em aberto
            juros = 0;
            multa = 0;
            desconto = 0;
            valorPago = null;
            dataPagamento = null;
        }

        public contasAPagar(int modeloCompra, string serieCompra, string numeroNotaCompra, int idFornecedor, int numeroParcela,
                            DateTime dataEmissao, DateTime dataVencimento, decimal valorParcela, formaPagamento aFormaPagamento, bool ativo,
                            int situacao, decimal juros, decimal multa, decimal desconto, decimal? valorPago, DateTime? dataPagamento)
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
            this.situacao = situacao;
            this.juros = juros;
            this.multa = multa;
            this.desconto = desconto;
            this.valorPago = valorPago;
            this.dataPagamento = dataPagamento;
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
        public int Situacao
        {
            get => situacao;
            set => situacao = value;
        }
        public decimal Juros
        {
            get => juros;
            set => juros = value;
        }
        public decimal Multa
        {
            get => multa;
            set => multa = value;
        }
        public decimal Desconto
        {
            get => desconto;
            set => desconto = value;
        }
        public decimal? ValorPago
        {
            get => valorPago;
            set => valorPago = value;
        }
        public DateTime? DataPagamento
        {
            get => dataPagamento;
            set => dataPagamento = value;
        }
    }
}
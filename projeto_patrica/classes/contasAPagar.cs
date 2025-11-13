using System;

namespace projeto_patrica.classes
{
    class contasAPagar : pai
    {
        protected int modeloCompra;
        protected string serieCompra;
        protected string numeroNotaCompra;
        protected fornecedor oFornecedor;
        protected int numeroParcela;
        protected DateTime dataEmissao;
        protected DateTime dataVencimento;
        protected decimal valorParcela;
        protected formaPagamento aFormaPagamento;
        protected int situacao; // 0 - Em aberto, 1 - Pago
        protected decimal juros;
        protected decimal multa;
        protected decimal desconto;
        protected decimal? valorPago;
        protected decimal? multaValor;
        protected decimal? jurosValor;
        protected decimal? descontoValor;
        protected DateTime? dataPagamento;
        protected string motivoCancelamento;

        public contasAPagar() : base()
        {
            modeloCompra = 0;
            serieCompra = " ";
            numeroNotaCompra = " ";
            oFornecedor = new fornecedor();
            numeroParcela = 0;
            dataEmissao = DateTime.MinValue;
            dataVencimento = DateTime.MinValue;
            valorParcela = 0;
            aFormaPagamento = new formaPagamento();
            situacao = 0;
            juros = 0;
            multa = 0;
            desconto = 0;
            valorPago = null;
            multaValor = null;
            jurosValor = null;
            descontoValor = null;
            dataPagamento = null;
            motivoCancelamento = null;
        }

        public contasAPagar(
            int modeloCompra, string serieCompra, string numeroNotaCompra, fornecedor oFornecedor, int numeroParcela,
            DateTime dataEmissao, DateTime dataVencimento, decimal valorParcela, formaPagamento aFormaPagamento, bool ativo,
            int situacao, decimal juros, decimal multa, decimal desconto, decimal? valorPago, DateTime? dataPagamento,
            DateTime dataCadastro, DateTime? dataUltimaEdicao, string motivoCancelamento, decimal? multaValor, decimal? jurosValor, decimal? descontoValor
        ) : base(0, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.modeloCompra = modeloCompra;
            this.serieCompra = serieCompra;
            this.numeroNotaCompra = numeroNotaCompra;
            this.oFornecedor = oFornecedor;
            this.numeroParcela = numeroParcela;
            this.dataEmissao = dataEmissao;
            this.dataVencimento = dataVencimento;
            this.valorParcela = valorParcela;
            this.aFormaPagamento = aFormaPagamento;
            this.situacao = situacao;
            this.juros = juros;
            this.multa = multa;
            this.desconto = desconto;
            this.valorPago = valorPago;
            this.multaValor = multaValor;
            this.jurosValor = jurosValor;
            this.descontoValor = descontoValor;
            this.dataPagamento = dataPagamento;
            this.motivoCancelamento = motivoCancelamento;
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

        public fornecedor OFornecedor
        {
            get => oFornecedor;
            set => oFornecedor = value;
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
        public decimal? MultaValor
        {
            get => multaValor;
            set => multaValor = value;
        }
        public decimal? JurosValor
        {
            get => jurosValor;
            set => jurosValor = value;
        }
        public decimal? DescontoValor
        {
            get => descontoValor;
            set => descontoValor = value;
        }
        public DateTime? DataPagamento
        {
            get => dataPagamento;
            set => dataPagamento = value;
        }
        public string MotivoCancelamento
        {
            get => motivoCancelamento;
            set => motivoCancelamento = value;
        }
    }
}
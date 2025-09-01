using System;
using System.Collections.Generic;

namespace projeto_patrica.classes
{
    class compra : pai
    {
        protected int modelo;
        protected string serie;
        protected string numeroNota;
        protected fornecedor oFornecedor;
        protected DateTime dataEmissao;
        protected DateTime dataEntrega;
        protected List<itemCompra> itens;
        protected decimal valorFrete;
        protected decimal seguro;
        protected decimal despesas;
        protected condicaoPagamento aCondicaoPagamento;
        protected List<parcelaCompra> parcelas;
        protected string motivoCancelamento;

        public compra()
        {
            modelo = 0;
            serie = " ";
            numeroNota = " ";
            oFornecedor = new fornecedor();
            dataEmissao = DateTime.MinValue;
            dataEntrega = DateTime.MinValue;
            itens = new List<itemCompra>();
            valorFrete = 0;
            seguro = 0;
            despesas = 0;
            aCondicaoPagamento = new condicaoPagamento();
            parcelas = new List<parcelaCompra>();
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
            motivoCancelamento = null;
        }

        public compra(int modelo, string serie, string numeroNota, fornecedor oFornecedor, DateTime dataEmissao,
                      DateTime dataEntrega, List<itemCompra> itens, decimal valorFrete, decimal seguro,
                      decimal despesas, condicaoPagamento aCondicaoPagamento, List<parcelaCompra> parcelas,
                      bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao, string motivoCancelamento)
            : base(0, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.modelo = modelo;
            this.serie = serie;
            this.numeroNota = numeroNota;
            this.oFornecedor = oFornecedor;
            this.dataEmissao = dataEmissao;
            this.dataEntrega = dataEntrega;
            this.itens = itens;
            this.valorFrete = valorFrete;
            this.seguro = seguro;
            this.despesas = despesas;
            this.aCondicaoPagamento = aCondicaoPagamento;
            this.parcelas = parcelas;
            this.motivoCancelamento = motivoCancelamento;
        }

        public int Modelo
        {
            get => modelo;
            set => modelo = value;
        }

        public string Serie
        {
            get => serie;
            set => serie = value;
        }

        public string NumeroNota
        {
            get => numeroNota;
            set => numeroNota = value;
        }

        public fornecedor OFornecedor
        {
            get => oFornecedor;
            set => oFornecedor = value;
        }

        public DateTime DataEmissao
        {
            get => dataEmissao;
            set => dataEmissao = value;
        }

        public DateTime DataEntrega
        {
            get => dataEntrega;
            set => dataEntrega = value;
        }

        public List<itemCompra> Itens
        {
            get => itens;
            set => itens = value;
        }

        public decimal ValorFrete
        {
            get => valorFrete;
            set => valorFrete = value;
        }

        public decimal Seguro
        {
            get => seguro;
            set => seguro = value;
        }

        public decimal Despesas
        {
            get => despesas;
            set => despesas = value;
        }

        public condicaoPagamento ACondicaoPagamento
        {
            get => aCondicaoPagamento;
            set => aCondicaoPagamento = value;
        }

        public List<parcelaCompra> Parcelas
        {
            get => parcelas;
            set => parcelas = value;
        }
        public string MotivoCancelamento
        {
            get => motivoCancelamento;
            set => motivoCancelamento = value;
        }
    }
}
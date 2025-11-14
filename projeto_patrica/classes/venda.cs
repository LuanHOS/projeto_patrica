using System;
using System.Collections.Generic;

namespace projeto_patrica.classes
{
    class venda : pai
    {
        protected int modelo;
        protected string serie;
        protected string numeroNota;
        protected cliente oCliente;
        protected funcionario oFuncionario;
        protected DateTime dataEmissao;
        protected List<itemVenda> itens;
        protected condicaoPagamento aCondicaoPagamento;
        protected List<contasAReceber> parcelas;
        protected string motivoCancelamento;

        public venda()
        {
            modelo = 0;
            serie = " ";
            numeroNota = " ";
            oCliente = new cliente();
            oFuncionario = new funcionario();
            dataEmissao = DateTime.MinValue;
            itens = new List<itemVenda>();
            aCondicaoPagamento = new condicaoPagamento();
            parcelas = new List<contasAReceber>();
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
            motivoCancelamento = null;
        }

        public venda(int modelo, string serie, string numeroNota, cliente oCliente, funcionario oFuncionario, DateTime dataEmissao,
                     List<itemVenda> itens, condicaoPagamento aCondicaoPagamento, List<contasAReceber> parcelas,
                     bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao, string motivoCancelamento)
            : base(0, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.modelo = modelo;
            this.serie = serie;
            this.numeroNota = numeroNota;
            this.oCliente = oCliente;
            this.oFuncionario = oFuncionario;
            this.dataEmissao = dataEmissao;
            this.itens = itens;
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

        public cliente OCliente
        {
            get => oCliente;
            set => oCliente = value;
        }

        public funcionario OFuncionario
        {
            get => oFuncionario;
            set => oFuncionario = value;
        }

        public DateTime DataEmissao
        {
            get => dataEmissao;
            set => dataEmissao = value;
        }

        public List<itemVenda> Itens
        {
            get => itens;
            set => itens = value;
        }

        public condicaoPagamento ACondicaoPagamento
        {
            get => aCondicaoPagamento;
            set => aCondicaoPagamento = value;
        }

        public List<contasAReceber> Parcelas
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
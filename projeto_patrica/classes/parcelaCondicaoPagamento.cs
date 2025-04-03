using projeto_patrica.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    internal class parcelaCondicaoPagamento
    {
        protected int codCondPgto; 
        protected int numeroParcela; 
        protected formaPagamento aFormaPagamento; 
        protected decimal valorPercentual;
        protected int diasAposVenda;
        public parcelaCondicaoPagamento()
        {
            codCondPgto = 0;
            numeroParcela = 0;
            aFormaPagamento = new formaPagamento();
            valorPercentual = 0;
            diasAposVenda = 0;
        }

        public parcelaCondicaoPagamento(int codCondPagto, int numeroParcela, formaPagamento aFormaPagamento, decimal valorPercentual, int diasAposVenda)
        {
            this.codCondPgto = codCondPagto;
            this.numeroParcela = numeroParcela;
            this.aFormaPagamento = aFormaPagamento;
            this.valorPercentual = valorPercentual;
            this.diasAposVenda = diasAposVenda;

        }

        public int CodCondPagto
        {
            get => codCondPgto;
            set => codCondPgto = value;
        }
        public int NumeroParcela
        {
            get => numeroParcela;
            set => numeroParcela = value;
        }
        public formaPagamento AFormaPagamento
        {
            get => aFormaPagamento;
            set => aFormaPagamento = value;
        }
        public decimal ValorPercentual
        {
            get => valorPercentual;
            set => valorPercentual = value;
        }
        public int DiasAposVenda
        {
            get => diasAposVenda;
            set => diasAposVenda = value;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    internal class parcelaCondicaoPagamento
    {
        protected int codCondPgto; //PK
        protected int numeroParcela; //PK
        protected int codFormaPgto; //FK
        protected decimal valorPercentual;
        protected int diasAposVenda;

        public parcelaCondicaoPagamento()
        {
            codCondPgto = 0;
            numeroParcela = 0;
            codFormaPgto = 0;
            valorPercentual = 0;
            diasAposVenda = 0;
        }

        public parcelaCondicaoPagamento(int codCondPagto, int numeroParcela, int codFormaPagto, decimal valorPercentual, int diasAposVenda)
        {
            this.codCondPgto = codCondPagto;
            this.numeroParcela = numeroParcela;
            this.codFormaPgto = codFormaPagto;
            this.valorPercentual = valorPercentual;
            this.diasAposVenda = diasAposVenda;

        }

        public int CodCondPagto { get; set; }
        public int NumeroParcela { get; set; }
        public int CodFormaPagto { get; set; }
        public decimal ValorPercentual { get; set; }
        public int DiasAposVenda { get; set; }
    }
}

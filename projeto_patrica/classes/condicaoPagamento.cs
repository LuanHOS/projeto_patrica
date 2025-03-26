using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    internal class condicaoPagamento : pai
    {
        // id representa o codCondicaoPagamento
        protected string descricao;
        protected int quantidadeParcelas;
        protected List<parcelaCondicaoPagamento> parcelas;

        public condicaoPagamento()
        {
            id = 0;
            descricao = " ";
            quantidadeParcelas = 0;
            parcelas = new List<parcelaCondicaoPagamento>();
        }

        public condicaoPagamento(int id, string descricao, int quantidadeParcelas, List<parcelaCondicaoPagamento> parcelas) : base(id)
        {
            this.id = id;
            this.descricao = descricao;
            this.quantidadeParcelas = quantidadeParcelas;
            this.parcelas = parcelas;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }
        public int QuantidadeParcelas
        {
            get => quantidadeParcelas;
            set => quantidadeParcelas = value;
        }
        public List<parcelaCondicaoPagamento> Parcelas
        {
            get => parcelas;
            set => parcelas = value;
        }
    }
}

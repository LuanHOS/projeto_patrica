using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    internal class condicaoPagamento : pai
    {
        protected string descricao;
        protected int quantidadeParcelas;
        protected List<parcelaCondicaoPagamento> parcelas;
        protected decimal juros;
        protected decimal multa;
        protected decimal desconto;

        public condicaoPagamento()
        {
            id = 0;
            descricao = " ";
            quantidadeParcelas = 0;
            parcelas = new List<parcelaCondicaoPagamento>();
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
            juros = 0;
            multa = 0;
            desconto = 0;
        }

        public condicaoPagamento(int id, string descricao, int quantidadeParcelas, List<parcelaCondicaoPagamento> parcelas, decimal juros, decimal multa, decimal desconto, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao)
            : base(id, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.id = id;
            this.descricao = descricao;
            this.quantidadeParcelas = quantidadeParcelas;
            this.parcelas = parcelas;
            this.juros = juros;
            this.multa = multa;
            this.desconto = desconto;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
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
    }
}

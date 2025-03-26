using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    internal class formaPagamento : pai
    {
        // id representa o codFormaPagamento
        protected string descricao;

        public formaPagamento()
        {
            id = 0;
            descricao = " ";
        }

        public formaPagamento(int id, string descricao) : base(id)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }
    }
}

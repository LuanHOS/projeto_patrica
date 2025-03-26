using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class pais : pai
    {
        protected string nome;

        public pais()
        {
            id = 0;
            nome = " ";
        }

        public pais(int id, string nome) : base(id)
        {
            this.id = id;
            this.nome = nome;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }
    }
}

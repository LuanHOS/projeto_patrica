using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class estado : pai
    {
        protected string nome;
        protected pais oPais;

        public estado()
        {
            id = 0;
            nome = " ";
            oPais = new pais();

        }

        public estado(int id, string nome, pais oPais) : base(id)
        {
            this.id = id;
            this.nome = nome;
            this.oPais = oPais;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }
        public pais OPais
        {
            get => oPais;
            set => oPais = value;
        }
    }
}

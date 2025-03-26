using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class cidade : pai
    {
        protected string nome;
        protected estado oEstado;

        public cidade()
        {
            id = 0;
            nome = " ";
            oEstado = new estado();

        }

        public cidade(int id, string nome, estado oEstado) : base(id)
        {
            this.id = id;
            this.nome = nome;
            this.oEstado = oEstado;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }
        public estado OEstado
        {
            get => oEstado;
            set => oEstado = value;
        }
    }
}

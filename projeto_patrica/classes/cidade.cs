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
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
        }

        public cidade(int id, string nome, estado oEstado, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao)
            : base(id, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.id = id;
            this.nome = nome;
            this.oEstado = oEstado;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
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

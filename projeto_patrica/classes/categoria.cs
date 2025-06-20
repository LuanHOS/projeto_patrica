using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class categoria : pai
    {
        protected string nome;
        protected string descricao;

        public categoria()
        {
            id = 0;
            nome = " ";
            descricao = " ";
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
        }

        public categoria(int id, string nome, string descricao, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao)
            : base(id, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }
    }
}

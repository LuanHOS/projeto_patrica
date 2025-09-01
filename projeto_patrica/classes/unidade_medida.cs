using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class unidade_medida : pai
    {
        protected string nome;
        protected string sigla;

        public unidade_medida()
        {
            id = 0;
            nome = " ";
            sigla = " ";
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
        }

        public unidade_medida(int id, string nome, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao, string sigla) : base(id, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.id = id;
            this.nome = nome;
            this.sigla = sigla;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }
        public string Sigla
        {
            get => sigla;
            set => sigla = value;
        }
    }
}

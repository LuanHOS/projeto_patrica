using System;

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
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
        }

        public estado(int id, string nome, pais oPais, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao)
            : base(id, ativo, dataCadastro, dataUltimaEdicao)
        {
            this.id = id;
            this.nome = nome;
            this.oPais = oPais;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    internal class pai
    {
        protected int id;
        protected bool ativo;
        protected DateTime dataCadastro;
        protected DateTime? dataUltimaEdicao;

        public pai()
        {
            id = 0;
            ativo = true;
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
        }

        public pai(int id, bool ativo, DateTime dataCadastro, DateTime? dataUltimaEdicao)
        {
            this.id = id;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public bool Ativo
        {
            get => ativo;
            set => ativo = value;
        }

        public DateTime DataCadastro
        {
            get => dataCadastro;
            internal protected set => dataCadastro = value;
        }
        public DateTime? DataUltimaEdicao
        {
            get => dataUltimaEdicao;
            set => dataUltimaEdicao = value;
        }
    }
}

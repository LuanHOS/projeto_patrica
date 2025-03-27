using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class pessoa : pai
    {
        protected char tipoPessoa;
        protected string nome_razaoSocial;
        protected string apelido_nomeFantasia;
        protected DateTime dataNascimento_criacao;
        protected string cpf_cnpj;
        protected string rg_inscricaoEstadual;
        protected string email;
        protected string telefone;
        protected string endereco;
        protected string bairro;
        protected cidade aCidade;
        protected string cep;
        protected bool ativo;
        protected char genero;

        public pessoa()
        {
            id = 0;
            tipoPessoa = ' ';
            nome_razaoSocial = " ";
            Apelido_nomeFantasia = " ";
            dataNascimento_criacao = DateTime.MinValue;
            cpf_cnpj = " ";
            rg_inscricaoEstadual = " ";
            email = " ";
            telefone = " ";
            endereco = " ";
            bairro = " ";
            cidade aCidade = new cidade();
            cep = " ";
            ativo = true;
            genero = ' ';

        }
        public pessoa(int id, char tipoPessoa, string nome_razaoSocial, string apelido_nomeFantasia, DateTime dataNascimento_criacao, string cpf_cnpj, 
            string rg_inscricaoEstadual, string email, string telefone, string endereco, string bairro, cidade aCidade, string cep, bool ativo, char genero) : base(id)
        {
            this.id = id;
            this.tipoPessoa = tipoPessoa;
            this.nome_razaoSocial = nome_razaoSocial;
            this.apelido_nomeFantasia = apelido_nomeFantasia;
            this.dataNascimento_criacao = dataNascimento_criacao;
            this.cpf_cnpj = cpf_cnpj;
            this.rg_inscricaoEstadual = rg_inscricaoEstadual;
            this.email = email;
            this.telefone = telefone;
            this.endereco = endereco;
            this.bairro = bairro;
            this.aCidade = aCidade;
            this.cep = cep;
            this.ativo = ativo;
            this.genero = genero;
        }

        public char TipoPessoa
        {
            get => tipoPessoa;
            set => tipoPessoa = value;
        }
        public string Nome_razaoSocial
        {
            get => nome_razaoSocial;
            set => nome_razaoSocial = value;
        }
        public string Apelido_nomeFantasia
        {
            get => apelido_nomeFantasia;
            set => apelido_nomeFantasia = value;
        }
        public DateTime DataNascimento_criacao
        {
            get => dataNascimento_criacao;
            set => dataNascimento_criacao = value;
        }
        public string Cpf_cnpj
        {
            get => cpf_cnpj;
            set => cpf_cnpj = value;
        }
        public string Rg_inscricaoEstadual
        {
            get => rg_inscricaoEstadual;
            set => rg_inscricaoEstadual = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public string Telefone
        {
            get => telefone;
            set => telefone = value;
        }
        public string Endereco
        {
            get => endereco;
            set => endereco = value;
        }
        public string Bairro
        {
            get => bairro;
            set => bairro = value;
        }
        public cidade ACidade
        {
            get => ACidade;
            set => ACidade = value;
        }
        public string Cep
        {
            get => cep;
            set => cep = value;
        }
        public bool Ativo
        {
            get => ativo;
            set => ativo = value;
        }
        public char Genero
        {
            get => genero;
            set => genero = value;
        }
    }
}

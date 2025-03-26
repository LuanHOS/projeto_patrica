using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class funcionario : pessoa
    {
        protected int matricula;
        protected string cargo;
        protected float salario;
        protected DateTime dataAdmissao;
        protected string turno;
        protected int cargaHoraria;
        protected char genero;

        public funcionario()
        {
            id = 0;
            tipoPessoa = ' ';
            nome_razaoSocial = " ";
            apelido_nomeFantasia = " ";
            dataNascimento_criacao = DateTime.MinValue;
            cpf_cnpj = " ";
            rg_inscricaoEstadual = " ";
            email = " ";
            telefone = " ";
            endereco = " ";
            bairro = " ";
            aCidade = new cidade();
            cep = " ";
            ativo = true;
            matricula = 0;
            cargo = " ";
            salario = 0;
            dataAdmissao = DateTime.MinValue;
            turno = " ";
            cargaHoraria = 0;
            genero = ' ';
        }

        public funcionario(
            int id, char tipoPessoa, string nome_razaoSocial, string apelido_nomeFantasia, DateTime dataNascimento_criacao, string cpf_cnpj, 
            string rg_inscricaoEstadual, string email, string telefone, string endereco, string bairro, cidade aCidade, string cep, bool ativo, int matricula, 
            string cargo, float salario, DateTime dataAdmissao, string turno, int cargaHoraria, char genero)
            : base(id, tipoPessoa, nome_razaoSocial, apelido_nomeFantasia, dataNascimento_criacao, cpf_cnpj, rg_inscricaoEstadual, 
                  email, telefone, endereco, bairro, aCidade, cep, ativo)
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
            this.matricula = matricula;
            this.cargo = cargo;
            this.salario = salario;
            this.dataAdmissao = dataAdmissao;
            this.turno = turno;
            this.cargaHoraria = cargaHoraria;
            this.genero = genero;
        }

        public int Matricula
        {
            get => matricula;
            set => matricula = value;
        }
        public string Cargo
        {
            get => cargo;
            set => cargo = value;
        }
        public float Salario
        {
            get => salario;
            set => salario = value;
        }
        public DateTime DataAdmissao
        {
            get => dataAdmissao;
            set => dataAdmissao = value;
        }
        public string Turno
        {
            get => turno;
            set => turno = value;
        }
        public int CargaHoraria
        {
            get => cargaHoraria;
            set => cargaHoraria = value;
        }
        public char Genero
        {
            get => genero;
            set => genero = value;
        }
    }
}

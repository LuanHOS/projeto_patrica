using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class funcionario : pessoa
    {
        protected string matricula;
        protected string cargo;
        protected decimal salario;
        protected DateTime dataAdmissao;
        protected DateTime? dataDemissao;
        protected string turno;
        protected int cargaHoraria;

        public funcionario()
        {
            id = 0;
            tipoPessoa = 'F';  // Todo funcionário é obrigatoriamente uma pessoa física
            nome_razaoSocial = " ";
            apelido_nomeFantasia = " ";
            dataNascimento_criacao = DateTime.MinValue;
            cpf_cnpj = " ";
            rg_inscricaoEstadual = " ";
            email = " ";
            telefone = " ";
            endereco = " ";
            numeroEndereco = " ";
            complementoEndereco = " ";
            bairro = " ";
            aCidade = new cidade();
            cep = " ";
            ativo = true;
            genero = ' ';
            dataCadastro = DateTime.MinValue;
            dataUltimaEdicao = null;
            matricula = " ";
            cargo = " ";
            salario = 0;
            dataAdmissao = DateTime.MinValue;
            dataDemissao = null;
            turno = " ";
            cargaHoraria = 0;
        }

        public funcionario(
            int id, char tipoPessoa, string nome_razaoSocial, string apelido_nomeFantasia, DateTime dataNascimento_criacao,
            string cpf_cnpj, string rg_inscricaoEstadual, string email, string telefone, string endereco, string numeroEndereco,
            string complementoEndereco, string bairro, cidade aCidade, string cep, bool ativo, DateTime dataCadastro,
            DateTime? dataUltimaEdicao, char genero, string matricula, string cargo, decimal salario,
            DateTime dataAdmissao, DateTime? dataDemissao, string turno, int cargaHoraria
        ) : base(id, tipoPessoa, nome_razaoSocial, apelido_nomeFantasia, dataNascimento_criacao,
                 cpf_cnpj, rg_inscricaoEstadual, email, telefone, endereco, numeroEndereco,
                 complementoEndereco, bairro, aCidade, cep, ativo, genero, dataCadastro, dataUltimaEdicao)
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
            this.numeroEndereco = numeroEndereco;
            this.complementoEndereco = complementoEndereco;
            this.bairro = bairro;
            this.aCidade = aCidade;
            this.cep = cep;
            this.ativo = ativo;
            this.dataCadastro = dataCadastro;
            this.dataUltimaEdicao = dataUltimaEdicao;
            this.genero = genero;
            this.matricula = matricula;
            this.cargo = cargo;
            this.salario = salario;
            this.dataAdmissao = dataAdmissao;
            this.dataDemissao = dataDemissao;
            this.turno = turno;
            this.cargaHoraria = cargaHoraria;
        }

        public string Matricula
        {
            get => matricula;
            set => matricula = value;
        }
        public string Cargo
        {
            get => cargo;
            set => cargo = value;
        }
        public decimal Salario
        {
            get => salario;
            set => salario = value;
        }
        public DateTime DataAdmissao
        {
            get => dataAdmissao;
            set => dataAdmissao = value;
        }
        public DateTime? DataDemissao
        {
            get => dataDemissao;
            set => dataDemissao = value;
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
    }
}

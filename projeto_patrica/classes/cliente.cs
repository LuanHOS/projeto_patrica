using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.classes
{
    class cliente : pessoa
    {
        //protected condicaoPagamento aCondicaoPagamento;

        public cliente()
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
            genero = ' ';
            //aCondicaoPagamento = new condicaoPagamento();
        }

        public cliente(int id, char tipoPessoa, string nome_razaoSocial, string apelido_nomeFantasia, DateTime dataNascimento_criacao, string cpf_cnpj,
            string rg_inscricaoEstadual, string email, string telefone, string endereco, string bairro, cidade aCidade, string cep, bool ativo, char genero/*, condicaoPagamento aCondicaoPagamento*/)
            : base(id, tipoPessoa, nome_razaoSocial, apelido_nomeFantasia, dataNascimento_criacao, cpf_cnpj,
                   rg_inscricaoEstadual, email, telefone, endereco, bairro, aCidade, cep, ativo, genero)
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
            //this.aCondicaoPagamento = aCondicaoPagamento;
        }

        //public condicaoPagamento ACondicaoPagamento { get; set; }
    }
}

using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_funcionario : Dao
    {
        public Dao_funcionario()
        {
        }

        public override string Salvar(object obj)
        {
            funcionario oFuncionario = (funcionario)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO funcionario (" +
                  "TIPO_PESSOA, NOME_RAZAO_SOCIAL, APELIDO_NOME_FANTASIA, DATA_NASCIMENTO_CRIACAO, CPF_CNPJ, " +
                  "RG_INSCRICAO_ESTADUAL, EMAIL, TELEFONE, ENDERECO, BAIRRO, ID_CIDADE, CEP, ATIVO, MATRICULA, CARGO, SALARIO, " +
                  "DATA_ADMISSAO, TURNO, CARGA_HORARIA, GENERO, NUMERO_ENDERECO, COMPLEMENTO_ENDERECO, DATA_DEMISSAO) VALUES (" +
                  "'" + oFuncionario.TipoPessoa + "', " +
                  "'" + oFuncionario.Nome_razaoSocial + "', " +
                  (string.IsNullOrWhiteSpace(oFuncionario.Apelido_nomeFantasia) ? "NULL" : "'" + oFuncionario.Apelido_nomeFantasia + "'") + ", " +
                  "'" + oFuncionario.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', " +
                  (string.IsNullOrWhiteSpace(oFuncionario.Cpf_cnpj) ? "NULL" : "'" + oFuncionario.Cpf_cnpj + "'") + ", " +
                  "'" + oFuncionario.Rg_inscricaoEstadual + "', " +
                  "'" + oFuncionario.Email + "', " +
                  "'" + oFuncionario.Telefone + "', " +
                  "'" + oFuncionario.Endereco + "', " +
                  "'" + oFuncionario.Bairro + "', " +
                  "'" + oFuncionario.ACidade.Id + "', " +
                  (string.IsNullOrWhiteSpace(oFuncionario.Cep) ? "NULL" : "'" + oFuncionario.Cep + "'") + ", " +
                  "'" + (oFuncionario.Ativo ? 1 : 0) + "', " +
                  "'" + oFuncionario.Matricula + "', " +
                  "'" + oFuncionario.Cargo + "', " +
                  "'" + oFuncionario.Salario.ToString().Replace(",", ".") + "', " +
                  "'" + oFuncionario.DataAdmissao.ToString("yyyy-MM-dd") + "', " +
                  "'" + oFuncionario.Turno + "', " +
                  "'" + oFuncionario.CargaHoraria + "', " +
                  (oFuncionario.Genero == ' ' ? "NULL" : "'" + oFuncionario.Genero + "'") + ", " +
                  "'" + oFuncionario.NumeroEndereco + "', " +
                  (string.IsNullOrWhiteSpace(oFuncionario.ComplementoEndereco) ? "NULL" : "'" + oFuncionario.ComplementoEndereco + "'") + ", " +
                  (oFuncionario.DataDemissao.HasValue ? "'" + oFuncionario.DataDemissao.Value.ToString("yyyy-MM-dd") + "'" : "NULL") +
                  ")";



            if (oFuncionario.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE funcionario SET " +
                      "TIPO_PESSOA = '" + oFuncionario.TipoPessoa + "', " +
                      "NOME_RAZAO_SOCIAL = '" + oFuncionario.Nome_razaoSocial + "', " +
                      "APELIDO_NOME_FANTASIA = " + (string.IsNullOrWhiteSpace(oFuncionario.Apelido_nomeFantasia) ? "NULL" : "'" + oFuncionario.Apelido_nomeFantasia + "'") + ", " +
                      "DATA_NASCIMENTO_CRIACAO = '" + oFuncionario.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', " +
                      "CPF_CNPJ = " + (string.IsNullOrWhiteSpace(oFuncionario.Cpf_cnpj) ? "NULL" : "'" + oFuncionario.Cpf_cnpj + "'") + ", " +
                      "RG_INSCRICAO_ESTADUAL = '" + oFuncionario.Rg_inscricaoEstadual + "', " +
                      "EMAIL = '" + oFuncionario.Email + "', " +
                      "TELEFONE = '" + oFuncionario.Telefone + "', " +
                      "ENDERECO = '" + oFuncionario.Endereco + "', " +
                      "BAIRRO = '" + oFuncionario.Bairro + "', " +
                      "ID_CIDADE = '" + oFuncionario.ACidade.Id + "', " +
                      "CEP = " + (string.IsNullOrWhiteSpace(oFuncionario.Cep) ? "NULL" : "'" + oFuncionario.Cep + "'") + ", " +
                      "ATIVO = '" + (oFuncionario.Ativo ? 1 : 0) + "', " +
                      "MATRICULA = '" + oFuncionario.Matricula + "', " +
                      "CARGO = '" + oFuncionario.Cargo + "', " +
                      "SALARIO = '" + oFuncionario.Salario.ToString().Replace(",", ".") + "', " +
                      "DATA_ADMISSAO = '" + oFuncionario.DataAdmissao.ToString("yyyy-MM-dd") + "', " +
                      "TURNO = '" + oFuncionario.Turno + "', " +
                      "CARGA_HORARIA = '" + oFuncionario.CargaHoraria + "', " +
                      "GENERO = " + (oFuncionario.Genero == ' ' ? "NULL" : "'" + oFuncionario.Genero + "'") + ", " +
                      "NUMERO_ENDERECO = '" + oFuncionario.NumeroEndereco + "', " +
                      "COMPLEMENTO_ENDERECO = " + (string.IsNullOrWhiteSpace(oFuncionario.ComplementoEndereco) ? "NULL" : "'" + oFuncionario.ComplementoEndereco + "'") + ", " +
                      "DATA_DEMISSAO = " + (oFuncionario.DataDemissao.HasValue ? "'" + oFuncionario.DataDemissao.Value.ToString("yyyy-MM-dd") + "'" : "NULL") + ", " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_FUNCIONARIO = '" + oFuncionario.Id + "'";

            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oFuncionario.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oFuncionario.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            funcionario oFuncionario = (funcionario)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM funcionario WHERE ID_FUNCIONARIO = '" + oFuncionario.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oFuncionario.Id = Convert.ToInt32(dr["ID_FUNCIONARIO"]);
                    oFuncionario.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                    oFuncionario.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                    oFuncionario.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? null : dr["APELIDO_NOME_FANTASIA"].ToString();
                    oFuncionario.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                    oFuncionario.Cpf_cnpj = dr["CPF_CNPJ"] == DBNull.Value ? null : dr["CPF_CNPJ"].ToString();
                    oFuncionario.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                    oFuncionario.Email = dr["EMAIL"].ToString();
                    oFuncionario.Telefone = dr["TELEFONE"].ToString();
                    oFuncionario.Endereco = dr["ENDERECO"].ToString();
                    oFuncionario.Bairro = dr["BAIRRO"].ToString();
                    oFuncionario.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                    oFuncionario.Cep = dr["CEP"] == DBNull.Value ? null : dr["CEP"].ToString();
                    oFuncionario.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oFuncionario.Matricula = dr["MATRICULA"].ToString();
                    oFuncionario.Cargo = dr["CARGO"].ToString();
                    oFuncionario.Salario = Convert.ToDecimal(dr["SALARIO"]);
                    oFuncionario.DataAdmissao = Convert.ToDateTime(dr["DATA_ADMISSAO"]);
                    oFuncionario.Turno = dr["TURNO"].ToString();
                    oFuncionario.CargaHoraria = Convert.ToInt32(dr["CARGA_HORARIA"]);
                    oFuncionario.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                    oFuncionario.NumeroEndereco = dr["NUMERO_ENDERECO"].ToString();
                    oFuncionario.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? null : dr["COMPLEMENTO_ENDERECO"].ToString();
                    oFuncionario.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oFuncionario.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                    oFuncionario.DataDemissao = dr.IsDBNull(dr.GetOrdinal("DATA_DEMISSAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_DEMISSAO"]);

                }

                conn.Connection.Close();

                Controller_cidade controller = new Controller_cidade();
                controller.CarregaObj(oFuncionario.ACidade);
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            funcionario oFuncionario = (funcionario)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM funcionario WHERE ID_FUNCIONARIO = '" + oFuncionario.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
                conn.Connection.Close();

                ok = "Excluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public List<funcionario> ListarFuncionarios()
        {
            List<funcionario> lista = new List<funcionario>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = "SELECT * FROM funcionario";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                funcionario oFuncionario = new funcionario();
                oFuncionario.Id = Convert.ToInt32(dr["ID_FUNCIONARIO"]);
                oFuncionario.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                oFuncionario.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                oFuncionario.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? null : dr["APELIDO_NOME_FANTASIA"].ToString();
                oFuncionario.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                oFuncionario.Cpf_cnpj = dr["CPF_CNPJ"] == DBNull.Value ? null : dr["CPF_CNPJ"].ToString();
                oFuncionario.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                oFuncionario.Email = dr["EMAIL"].ToString();
                oFuncionario.Telefone = dr["TELEFONE"].ToString();
                oFuncionario.Endereco = dr["ENDERECO"].ToString();
                oFuncionario.Bairro = dr["BAIRRO"].ToString();
                oFuncionario.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                oFuncionario.Cep = dr["CEP"] == DBNull.Value ? null : dr["CEP"].ToString();
                oFuncionario.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oFuncionario.Matricula = dr["MATRICULA"].ToString();
                oFuncionario.Cargo = dr["CARGO"].ToString();
                oFuncionario.Salario = Convert.ToDecimal(dr["SALARIO"]);
                oFuncionario.DataAdmissao = Convert.ToDateTime(dr["DATA_ADMISSAO"]);
                oFuncionario.Turno = dr["TURNO"].ToString();
                oFuncionario.CargaHoraria = Convert.ToInt32(dr["CARGA_HORARIA"]);
                oFuncionario.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                oFuncionario.NumeroEndereco = dr["NUMERO_ENDERECO"].ToString();
                oFuncionario.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? null : dr["COMPLEMENTO_ENDERECO"].ToString();
                oFuncionario.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oFuncionario.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                oFuncionario.DataDemissao = dr.IsDBNull(dr.GetOrdinal("DATA_DEMISSAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_DEMISSAO"]);


                lista.Add(oFuncionario);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

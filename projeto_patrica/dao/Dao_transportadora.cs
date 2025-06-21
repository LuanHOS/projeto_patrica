using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_transportadora : Dao
    {
        public Dao_transportadora()
        {
        }

        public override string Salvar(object obj)
        {
            transportadora oTransportadora = (transportadora)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO TRANSPORTADORA (" +
                  "TIPO_PESSOA, NOME_RAZAO_SOCIAL, APELIDO_NOME_FANTASIA, DATA_NASCIMENTO_CRIACAO, CPF_CNPJ, " +
                  "RG_INSCRICAO_ESTADUAL, EMAIL, TELEFONE, ENDERECO, BAIRRO, ID_CIDADE, CEP, ATIVO, " +
                  "GENERO, ID_CONDICAO_PAGAMENTO, NUMERO_ENDERECO, COMPLEMENTO_ENDERECO" +
                  ") VALUES (" +
                  "'" + oTransportadora.TipoPessoa + "', " +
                  "'" + oTransportadora.Nome_razaoSocial + "', " +
                  (string.IsNullOrWhiteSpace(oTransportadora.Apelido_nomeFantasia) ? "NULL" : "'" + oTransportadora.Apelido_nomeFantasia + "'") + ", " +
                  "'" + oTransportadora.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', " +
                  (string.IsNullOrWhiteSpace(oTransportadora.Cpf_cnpj) ? "NULL" : "'" + oTransportadora.Cpf_cnpj + "'") + ", " +
                  "'" + oTransportadora.Rg_inscricaoEstadual + "', " +
                  "'" + oTransportadora.Email + "', " +
                  "'" + oTransportadora.Telefone + "', " +
                  "'" + oTransportadora.Endereco + "', " +
                  "'" + oTransportadora.Bairro + "', " +
                  "'" + oTransportadora.ACidade.Id + "', " +
                  (string.IsNullOrWhiteSpace(oTransportadora.Cep) ? "NULL" : "'" + oTransportadora.Cep + "'") + ", " +
                  (oTransportadora.Ativo ? "1" : "0") + ", " +
                  (oTransportadora.Genero == ' ' ? "NULL" : "'" + oTransportadora.Genero + "'") + ", " +
                  "'" + oTransportadora.ACondicaoPagamento.Id + "', " +
                  "'" + oTransportadora.NumeroEndereco + "', " +
                  (string.IsNullOrWhiteSpace(oTransportadora.ComplementoEndereco) ? "NULL" : "'" + oTransportadora.ComplementoEndereco + "'") + ")";

            if (oTransportadora.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE TRANSPORTADORA SET " +
                     "TIPO_PESSOA = '" + oTransportadora.TipoPessoa + "', " +
                     "NOME_RAZAO_SOCIAL = '" + oTransportadora.Nome_razaoSocial + "', " +
                     "APELIDO_NOME_FANTASIA = " + (string.IsNullOrWhiteSpace(oTransportadora.Apelido_nomeFantasia) ? "NULL" : "'" + oTransportadora.Apelido_nomeFantasia + "'") + ", " +
                     "DATA_NASCIMENTO_CRIACAO = '" + oTransportadora.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', " +
                     "CPF_CNPJ = " + (string.IsNullOrWhiteSpace(oTransportadora.Cpf_cnpj) ? "NULL" : "'" + oTransportadora.Cpf_cnpj + "'") + ", " +
                     "RG_INSCRICAO_ESTADUAL = '" + oTransportadora.Rg_inscricaoEstadual + "', " +
                     "EMAIL = '" + oTransportadora.Email + "', " +
                     "TELEFONE = '" + oTransportadora.Telefone + "', " +
                     "ENDERECO = '" + oTransportadora.Endereco + "', " +
                     "BAIRRO = '" + oTransportadora.Bairro + "', " +
                     "ID_CIDADE = '" + oTransportadora.ACidade.Id + "', " +
                     "CEP = " + (string.IsNullOrWhiteSpace(oTransportadora.Cep) ? "NULL" : "'" + oTransportadora.Cep + "'") + ", " +
                     "ATIVO = '" + (oTransportadora.Ativo ? 1 : 0) + "', " +
                     "GENERO = " + (oTransportadora.Genero == ' ' ? "NULL" : "'" + oTransportadora.Genero + "'") + ", " +
                     "ID_CONDICAO_PAGAMENTO = '" + oTransportadora.ACondicaoPagamento.Id + "', " +
                     "NUMERO_ENDERECO = '" + oTransportadora.NumeroEndereco + "', " +
                     "COMPLEMENTO_ENDERECO = " + (string.IsNullOrWhiteSpace(oTransportadora.ComplementoEndereco) ? "NULL" : "'" + oTransportadora.ComplementoEndereco + "'") + ", " +
                     "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                     "WHERE ID_TRANSPORTADORA = '" + oTransportadora.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oTransportadora.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oTransportadora.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            transportadora oTransportadora = (transportadora)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM TRANSPORTADORA WHERE ID_TRANSPORTADORA = '" + oTransportadora.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oTransportadora.Id = Convert.ToInt32(dr["ID_TRANSPORTADORA"]);
                    oTransportadora.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                    oTransportadora.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                    oTransportadora.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? null : dr["APELIDO_NOME_FANTASIA"].ToString();
                    oTransportadora.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                    oTransportadora.Cpf_cnpj = dr["CPF_CNPJ"] == DBNull.Value ? null : dr["CPF_CNPJ"].ToString();
                    oTransportadora.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                    oTransportadora.Email = dr["EMAIL"].ToString();
                    oTransportadora.Telefone = dr["TELEFONE"].ToString();
                    oTransportadora.Endereco = dr["ENDERECO"].ToString();
                    oTransportadora.Bairro = dr["BAIRRO"].ToString();
                    oTransportadora.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                    oTransportadora.Cep = dr["CEP"] == DBNull.Value ? null : dr["CEP"].ToString();
                    oTransportadora.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oTransportadora.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                    oTransportadora.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                    oTransportadora.NumeroEndereco = dr["NUMERO_ENDERECO"].ToString();
                    oTransportadora.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? null : dr["COMPLEMENTO_ENDERECO"].ToString();
                    oTransportadora.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oTransportadora.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                }

                conn.Connection.Close();

                Controller_cidade controller = new Controller_cidade();
                controller.CarregaObj(oTransportadora.ACidade);
                Controller_condicaoPagamento controller2 = new Controller_condicaoPagamento();
                controller2.CarregaObj(oTransportadora.ACondicaoPagamento);
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            transportadora oTransportadora = (transportadora)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM TRANSPORTADORA WHERE ID_TRANSPORTADORA = '" + oTransportadora.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
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

        public List<transportadora> ListarTransportadoras()
        {
            List<transportadora> lista = new List<transportadora>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM TRANSPORTADORA";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                transportadora oTransportadora = new transportadora();
                oTransportadora.Id = Convert.ToInt32(dr["ID_TRANSPORTADORA"]);
                oTransportadora.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                oTransportadora.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                oTransportadora.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? null : dr["APELIDO_NOME_FANTASIA"].ToString();
                oTransportadora.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                oTransportadora.Cpf_cnpj = dr["CPF_CNPJ"] == DBNull.Value ? null : dr["CPF_CNPJ"].ToString();
                oTransportadora.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                oTransportadora.Email = dr["EMAIL"].ToString();
                oTransportadora.Telefone = dr["TELEFONE"].ToString();
                oTransportadora.Endereco = dr["ENDERECO"].ToString();
                oTransportadora.Bairro = dr["BAIRRO"].ToString();
                oTransportadora.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                oTransportadora.Cep = dr["CEP"] == DBNull.Value ? null : dr["CEP"].ToString();
                oTransportadora.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oTransportadora.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                oTransportadora.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                oTransportadora.NumeroEndereco = dr["NUMERO_ENDERECO"].ToString();
                oTransportadora.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? null : dr["COMPLEMENTO_ENDERECO"].ToString();
                oTransportadora.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oTransportadora.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                lista.Add(oTransportadora);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_fornecedor : Dao
    {
        public Dao_fornecedor()
        {
        }

        public override string Salvar(object obj)
        {
            fornecedor oFornecedor = (fornecedor)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO fornecedor (" +
                "TIPO_PESSOA, NOME_RAZAO_SOCIAL, APELIDO_NOME_FANTASIA, DATA_NASCIMENTO_CRIACAO, CPF_CNPJ, " +
                "RG_INSCRICAO_ESTADUAL, EMAIL, TELEFONE, ENDERECO, BAIRRO, ID_CIDADE, CEP, ATIVO, " +
                "GENERO, ID_CONDICAO_PAGAMENTO, NUMERO_ENDERECO, COMPLEMENTO_ENDERECO" +
                ") VALUES (" +
                "'" + oFornecedor.TipoPessoa + "', '" + oFornecedor.Nome_razaoSocial + "', '" + oFornecedor.Apelido_nomeFantasia + "', '" + oFornecedor.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', '" + oFornecedor.Cpf_cnpj + "', " +
                "'" + oFornecedor.Rg_inscricaoEstadual + "', '" + oFornecedor.Email + "', '" + oFornecedor.Telefone + "', '" + oFornecedor.Endereco + "', '" + oFornecedor.Bairro + "', " +
                "'" + oFornecedor.ACidade.Id + "', '" + oFornecedor.Cep + "', '" + (oFornecedor.Ativo ? 1 : 0) + "', " +
                "'" + oFornecedor.Genero + "', '" + oFornecedor.ACondicaoPagamento.Id + "', '" + oFornecedor.NumeroEndereco + "', '" + oFornecedor.ComplementoEndereco + "')";

            if (oFornecedor.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE fornecedor SET " +
                    "TIPO_PESSOA = '" + oFornecedor.TipoPessoa + "', " +
                    "NOME_RAZAO_SOCIAL = '" + oFornecedor.Nome_razaoSocial + "', " +
                    "APELIDO_NOME_FANTASIA = '" + oFornecedor.Apelido_nomeFantasia + "', " +
                    "DATA_NASCIMENTO_CRIACAO = '" + oFornecedor.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', " +
                    "CPF_CNPJ = '" + oFornecedor.Cpf_cnpj + "', " +
                    "RG_INSCRICAO_ESTADUAL = '" + oFornecedor.Rg_inscricaoEstadual + "', " +
                    "EMAIL = '" + oFornecedor.Email + "', " +
                    "TELEFONE = '" + oFornecedor.Telefone + "', " +
                    "ENDERECO = '" + oFornecedor.Endereco + "', " +
                    "BAIRRO = '" + oFornecedor.Bairro + "', " +
                    "ID_CIDADE = '" + oFornecedor.ACidade.Id + "', " +
                    "CEP = '" + oFornecedor.Cep + "', " +
                    "ATIVO = '" + (oFornecedor.Ativo ? 1 : 0) + "', " +
                    "ID_CONDICAO_PAGAMENTO = '" + oFornecedor.ACondicaoPagamento.Id + "', " +
                    "GENERO = '" + oFornecedor.Genero + "', " +
                    "NUMERO_ENDERECO = '" + oFornecedor.NumeroEndereco + "', " +
                    "COMPLEMENTO_ENDERECO = '" + oFornecedor.ComplementoEndereco + "', " +
                    "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                    "WHERE ID_FORNECEDOR = '" + oFornecedor.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oFornecedor.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oFornecedor.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            fornecedor oFornecedor = (fornecedor)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM fornecedor WHERE ID_FORNECEDOR = '" + oFornecedor.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oFornecedor.Id = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                    oFornecedor.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                    oFornecedor.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                    oFornecedor.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? "" : dr["APELIDO_NOME_FANTASIA"].ToString();
                    oFornecedor.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                    oFornecedor.Cpf_cnpj = dr["CPF_CNPJ"].ToString();
                    oFornecedor.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                    oFornecedor.Email = dr["EMAIL"].ToString();
                    oFornecedor.Telefone = dr["TELEFONE"].ToString();
                    oFornecedor.Endereco = dr["ENDERECO"].ToString();
                    oFornecedor.Bairro = dr["BAIRRO"].ToString();
                    oFornecedor.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                    oFornecedor.Cep = dr["CEP"].ToString();
                    oFornecedor.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oFornecedor.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                    oFornecedor.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                    oFornecedor.NumeroEndereco = dr["NUMERO_ENDERECO"] == DBNull.Value ? "" : dr["NUMERO_ENDERECO"].ToString();
                    oFornecedor.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? "" : dr["COMPLEMENTO_ENDERECO"].ToString();
                    oFornecedor.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oFornecedor.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                }

                conn.Connection.Close();

                Controller_cidade controller = new Controller_cidade();
                controller.CarregaObj(oFornecedor.ACidade);
                Controller_condicaoPagamento controller2 = new Controller_condicaoPagamento();
                controller2.CarregaObj(oFornecedor.ACondicaoPagamento);
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            fornecedor oFornecedor = (fornecedor)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM fornecedor WHERE ID_FORNECEDOR = '" + oFornecedor.Id + "'";
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

        public List<fornecedor> ListarFornecedores()
        {
            List<fornecedor> lista = new List<fornecedor>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM fornecedor";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                fornecedor oFornecedor = new fornecedor();
                oFornecedor.Id = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                oFornecedor.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                oFornecedor.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                oFornecedor.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? "" : dr["APELIDO_NOME_FANTASIA"].ToString();
                oFornecedor.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                oFornecedor.Cpf_cnpj = dr["CPF_CNPJ"].ToString();
                oFornecedor.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                oFornecedor.Email = dr["EMAIL"].ToString();
                oFornecedor.Telefone = dr["TELEFONE"].ToString();
                oFornecedor.Endereco = dr["ENDERECO"].ToString();
                oFornecedor.Bairro = dr["BAIRRO"].ToString();
                oFornecedor.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                oFornecedor.Cep = dr["CEP"].ToString();
                oFornecedor.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oFornecedor.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                oFornecedor.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                oFornecedor.NumeroEndereco = dr["NUMERO_ENDERECO"] == DBNull.Value ? "" : dr["NUMERO_ENDERECO"].ToString();
                oFornecedor.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? "" : dr["COMPLEMENTO_ENDERECO"].ToString();
                oFornecedor.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oFornecedor.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                lista.Add(oFornecedor);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

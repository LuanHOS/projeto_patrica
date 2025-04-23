using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_cliente : Dao
    {
        public Dao_cliente()
        {
        }

        public override string Salvar(object obj)
        {
            cliente oCliente = (cliente)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO cliente (" +
                "TIPO_PESSOA, NOME_RAZAO_SOCIAL, APELIDO_NOME_FANTASIA, DATA_NASCIMENTO_CRIACAO, CPF_CNPJ, " +
                "RG_INSCRICAO_ESTADUAL, EMAIL, TELEFONE, ENDERECO, BAIRRO, ID_CIDADE, CEP, ATIVO, GENERO, " +
                "ID_CONDICAO_PAGAMENTO, NUMERO_ENDERECO, COMPLEMENTO_ENDERECO, LIMITE_CREDITO" +
                ") VALUES (" +
                "'" + oCliente.TipoPessoa + "', '" + oCliente.Nome_razaoSocial + "', '" + oCliente.Apelido_nomeFantasia + "', '" + oCliente.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', '" + oCliente.Cpf_cnpj + "', '" +
                oCliente.Rg_inscricaoEstadual + "', '" + oCliente.Email + "', '" + oCliente.Telefone + "', '" + oCliente.Endereco + "', '" + oCliente.Bairro + "', '" +
                oCliente.ACidade.Id + "', '" + oCliente.Cep + "', '" + (oCliente.Ativo ? 1 : 0) + "', '" + oCliente.Genero + "', '" +
                oCliente.ACondicaoPagamento.Id + "', '" + oCliente.NumeroEndereco + "', '" + oCliente.ComplementoEndereco + "', '" + oCliente.LimiteDeCredito.ToString().Replace(",", ".") + "'" +
                ")";

            if (oCliente.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE cliente SET " +
                    "TIPO_PESSOA = '" + oCliente.TipoPessoa + "', " +
                    "NOME_RAZAO_SOCIAL = '" + oCliente.Nome_razaoSocial + "', " +
                    "APELIDO_NOME_FANTASIA = '" + oCliente.Apelido_nomeFantasia + "', " +
                    "DATA_NASCIMENTO_CRIACAO = '" + oCliente.DataNascimento_criacao.ToString("yyyy-MM-dd") + "', " +
                    "CPF_CNPJ = '" + oCliente.Cpf_cnpj + "', " +
                    "RG_INSCRICAO_ESTADUAL = '" + oCliente.Rg_inscricaoEstadual + "', " +
                    "EMAIL = '" + oCliente.Email + "', " +
                    "TELEFONE = '" + oCliente.Telefone + "', " +
                    "ENDERECO = '" + oCliente.Endereco + "', " +
                    "BAIRRO = '" + oCliente.Bairro + "', " +
                    "ID_CIDADE = '" + oCliente.ACidade.Id + "', " +
                    "CEP = '" + oCliente.Cep + "', " +
                    "ATIVO = '" + (oCliente.Ativo ? 1 : 0) + "', " +
                    "GENERO = '" + oCliente.Genero + "', " +
                    "ID_CONDICAO_PAGAMENTO = '" + oCliente.ACondicaoPagamento.Id + "', " +
                    "NUMERO_ENDERECO = '" + oCliente.NumeroEndereco + "', " +
                    "COMPLEMENTO_ENDERECO = '" + oCliente.ComplementoEndereco + "', " +
                    "LIMITE_CREDITO = '" + oCliente.LimiteDeCredito.ToString().Replace(",", ".") + "', " +
                    "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                    "WHERE ID_CLIENTE = '" + oCliente.Id + "'";

            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oCliente.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oCliente.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            cliente oCliente = (cliente)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM cliente WHERE ID_CLIENTE = '" + oCliente.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
                    oCliente.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                    oCliente.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                    oCliente.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? "" : dr["APELIDO_NOME_FANTASIA"].ToString();
                    oCliente.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                    oCliente.Cpf_cnpj = dr["CPF_CNPJ"].ToString();
                    oCliente.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                    oCliente.Email = dr["EMAIL"].ToString();
                    oCliente.Telefone = dr["TELEFONE"].ToString();
                    oCliente.Endereco = dr["ENDERECO"].ToString();
                    oCliente.Bairro = dr["BAIRRO"].ToString();
                    oCliente.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                    oCliente.Cep = dr["CEP"].ToString();
                    oCliente.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oCliente.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                    oCliente.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                    oCliente.NumeroEndereco = dr["NUMERO_ENDERECO"] == DBNull.Value ? "" : dr["NUMERO_ENDERECO"].ToString();
                    oCliente.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? "" : dr["COMPLEMENTO_ENDERECO"].ToString();
                    oCliente.LimiteDeCredito = dr["LIMITE_CREDITO"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["LIMITE_CREDITO"]);
                    oCliente.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oCliente.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                }

                conn.Connection.Close();

                Controller_cidade controller = new Controller_cidade();
                controller.CarregaObj(oCliente.ACidade);
                Controller_condicaoPagamento controller2 = new Controller_condicaoPagamento();
                controller2.CarregaObj(oCliente.ACondicaoPagamento);
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            cliente oCliente = (cliente)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM cliente WHERE ID_CLIENTE = '" + oCliente.Id + "'";
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

        public List<cliente> ListarClientes()
        {
            List<cliente> lista = new List<cliente>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM cliente";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                cliente oCliente = new cliente();
                oCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
                oCliente.TipoPessoa = Convert.ToChar(dr["TIPO_PESSOA"]);
                oCliente.Nome_razaoSocial = dr["NOME_RAZAO_SOCIAL"].ToString();
                oCliente.Apelido_nomeFantasia = dr["APELIDO_NOME_FANTASIA"] == DBNull.Value ? "" : dr["APELIDO_NOME_FANTASIA"].ToString();
                oCliente.DataNascimento_criacao = Convert.ToDateTime(dr["DATA_NASCIMENTO_CRIACAO"]);
                oCliente.Cpf_cnpj = dr["CPF_CNPJ"].ToString();
                oCliente.Rg_inscricaoEstadual = dr["RG_INSCRICAO_ESTADUAL"].ToString();
                oCliente.Email = dr["EMAIL"].ToString();
                oCliente.Telefone = dr["TELEFONE"].ToString();
                oCliente.Endereco = dr["ENDERECO"].ToString();
                oCliente.Bairro = dr["BAIRRO"].ToString();
                oCliente.ACidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                oCliente.Cep = dr["CEP"].ToString();
                oCliente.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oCliente.Genero = dr["GENERO"] == DBNull.Value || string.IsNullOrWhiteSpace(dr["GENERO"].ToString()) ? ' ' : Convert.ToChar(dr["GENERO"]);
                oCliente.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                oCliente.NumeroEndereco = dr["NUMERO_ENDERECO"] == DBNull.Value ? "" : dr["NUMERO_ENDERECO"].ToString();
                oCliente.ComplementoEndereco = dr["COMPLEMENTO_ENDERECO"] == DBNull.Value ? "" : dr["COMPLEMENTO_ENDERECO"].ToString();
                oCliente.LimiteDeCredito = dr["LIMITE_CREDITO"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["LIMITE_CREDITO"]);
                oCliente.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oCliente.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);


                lista.Add(oCliente);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

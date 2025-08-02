using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_formaPagamento : Dao
    {
        public Dao_formaPagamento()
        {

        }

        public override string Salvar(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            if (aFormaPagamento.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE FORMA_PAGAMENTO SET " +
                      "DESCRICAO = '" + aFormaPagamento.Descricao + "', " +
                      "ATIVO = '" + (aFormaPagamento.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_FORMA_PAGAMENTO = '" + aFormaPagamento.Id + "'";
            }
            else
            {
                sql = "INSERT INTO FORMA_PAGAMENTO (DESCRICAO, ATIVO) " +
                      "VALUES ('" + aFormaPagamento.Descricao + "', '" + (aFormaPagamento.Ativo ? 1 : 0) + "')";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@identity";
                ok = conn.ExecuteScalar().ToString();
                aFormaPagamento.Id = Convert.ToInt32(ok);
            }

            conn.Connection.Close();
            return ok;
        }

        public override string Excluir(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;

            string sql = "DELETE FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = '" + aFormaPagamento.Id + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;
            conn.CommandText = sql;
            conn.ExecuteNonQuery();
            conn.Connection.Close();

            return "Excluído com sucesso!";
        }
    

        public override string CarregaObj(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = '" + aFormaPagamento.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    aFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                    aFormaPagamento.Descricao = dr["DESCRICAO"].ToString();
                    aFormaPagamento.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    aFormaPagamento.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    aFormaPagamento.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                }

                conn.Connection.Close();
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao carregar: " + ex.Message;
            }

            return ok;
        }

        public List<formaPagamento> ListarFormaPagamento()
        {
            formaPagamento aFormaPagamento;
            List<formaPagamento> lista = new List<formaPagamento>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;
            conn.CommandText = "SELECT * FROM FORMA_PAGAMENTO";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                aFormaPagamento = new formaPagamento();
                aFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                aFormaPagamento.Descricao = dr["DESCRICAO"].ToString();
                aFormaPagamento.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                aFormaPagamento.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                aFormaPagamento.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                lista.Add(aFormaPagamento);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

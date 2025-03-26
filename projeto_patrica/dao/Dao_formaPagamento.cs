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
            string sql = "";

            if (aFormaPagamento.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE FORMA_PAGAMENTO SET DESCRICAO = '" + aFormaPagamento.Descricao + "' " +
                      "WHERE ID_FORMA_PAGAMENTO = '" + aFormaPagamento.Id + "'";
            }
            else
            {
                sql = "INSERT INTO FORMA_PAGAMENTO (DESCRICAO) VALUES ('" + aFormaPagamento.Descricao + "')";
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
            string ok = "";

            try
            {
                string sql = "DELETE FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = '" + aFormaPagamento.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
                conn.Connection.Close();
                ok = "Excluído!";
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao excluir: " + ex.Message;
            }

            return ok;
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
                    aFormaPagamento.Id = Convert.ToInt32(dr.GetValue(0));
                    aFormaPagamento.Descricao = dr.GetString(1);
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
                aFormaPagamento.Id = Convert.ToInt32(dr.GetValue(0));
                aFormaPagamento.Descricao = dr.GetString(1);
                lista.Add(aFormaPagamento);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

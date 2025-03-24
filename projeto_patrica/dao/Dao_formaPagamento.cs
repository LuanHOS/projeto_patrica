using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using projeto_patrica.classes;

namespace projeto_patrica.dao
{
    internal class Dao_formaPagamento : Dao
    {
        public override string Salvar(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";
            char operacao = 'I';
            string sql;


            /*
             * 
             */


            using (MySqlConnection conn = Banco.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (aFormaPagamento.Id == 0)
                {
                    sql = "INSERT INTO FORMA_PAGAMENTO (DESCRICAO) VALUES (@descricao);";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@descricao", aFormaPagamento.Descricao);
                }
                else
                {
                    operacao = 'U';
                    sql = "UPDATE FORMA_PAGAMENTO SET DESCRICAO = @descricao WHERE ID_FORMA_PAGAMENTO = @id;";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@descricao", aFormaPagamento.Descricao);
                    cmd.Parameters.AddWithValue("@id", aFormaPagamento.Id);
                }

                cmd.ExecuteNonQuery();

                if (operacao == 'I')
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    ok = cmd.ExecuteScalar().ToString();
                    aFormaPagamento.Id = Convert.ToInt32(ok);
                }

                conn.Close();
            }

            return ok;
        }


        /*
         * 
         */


        public List<formaPagamento> ListarFormaPagamento()
        {
            List<formaPagamento> lista = new List<formaPagamento>();

            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "SELECT ID_FORMA_PAGAMENTO, DESCRICAO FROM FORMA_PAGAMENTO;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new formaPagamento
                    {
                        Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]),
                        Descricao = dr["DESCRICAO"].ToString()
                    });
                }

                conn.Close();
            }

            return lista;
        }


        /*
         * 
         */


        public override string CarregaObj(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = " ";

            try
            {
                using (MySqlConnection conn = Banco.Abrir())
                {
                    string sql = "SELECT * FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = @id;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", aFormaPagamento.Id);
                    var dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        aFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                        aFormaPagamento.Descricao = dr["DESCRICAO"].ToString();
                        ok = "Encontrado";
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ok = "Erro: " + ex.Message;
            }

            return ok;
        }


        /*
         * 
         */


        public override string Excluir(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";

            try
            {
                using (MySqlConnection conn = Banco.Abrir())
                {
                    string sql = "DELETE FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = @id;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", aFormaPagamento.Id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    ok = "Excluído com sucesso!";
                }
            }
            catch (Exception ex)
            {
                ok = "Erro ao excluir: " + ex.Message;
            }

            return ok;
        }
    }
}

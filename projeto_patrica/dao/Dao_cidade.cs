using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_cidade : Dao
    {
        public Dao_cidade()
        {
        }

        public override string Salvar(object obj)
        {
            cidade aCidade = (cidade)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO cidade (NOME, ID_ESTADO) VALUES('" + aCidade.Nome + "', '" + aCidade.OEstado.Id + "')";

            if (aCidade.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE cidade SET NOME = '" + aCidade.Nome + "', ID_ESTADO = '" + aCidade.OEstado.Id + "' WHERE ID_CIDADE = '" + aCidade.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                aCidade.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = aCidade.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            cidade aCidade = (cidade)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM cidade WHERE ID_CIDADE = '" + aCidade.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;

                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    aCidade.Id = Convert.ToInt32(dr.GetValue(0));
                    aCidade.Nome = dr.GetString(1);
                    aCidade.OEstado.Id = Convert.ToInt32(dr.GetValue(2));
                }

                conn.Connection.Close();
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            cidade aCidade = (cidade)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM cidade WHERE ID_CIDADE = '" + aCidade.Id + "'";
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

        public List<cidade> ListarCidades()
        {
            cidade aCidade;
            List<cidade> lista = new List<cidade>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM cidade";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                aCidade = new cidade();
                aCidade.Id = Convert.ToInt32(dr.GetValue(0));
                aCidade.Nome = dr.GetString(1);
                aCidade.OEstado.Id = Convert.ToInt32(dr.GetValue(2));
                lista.Add(aCidade);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}


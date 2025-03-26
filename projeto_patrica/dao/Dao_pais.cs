using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_pais : Dao
    {
        public Dao_pais()
        {
        }

        public override string Salvar(object obj)
        {
            pais oPais = (pais)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            // Correção: nome das colunas especificado no INSERT
            sql = "INSERT INTO pais (NOME) VALUES('" + oPais.Nome + "')";

            if (oPais.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE pais SET NOME = '" + oPais.Nome + "' WHERE ID_PAIS = '" + oPais.Id + "'"; // Correção: Nome da coluna uniformizado
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY"; // Corrigido para garantir compatibilidade com MySQL
                ok = conn.ExecuteScalar().ToString();
                oPais.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oPais.Id.ToString(); // Correção: garante que "ok" também seja retornado em UPDATE
            }

            conn.Connection.Close();
            return ok;
        }

        public List<pais> ListarPaises()
        {
            List<pais> lista = new List<pais>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM PAIS";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new pais(
                    Convert.ToInt32(dr.GetValue(0)),
                    dr.GetString(1)
                ));
            }

            conn.Connection.Close(); // Correção: fechamento da conexão após leitura
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            pais oPais = (pais)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM pais WHERE ID_PAIS = '" + oPais.Id + "'"; // Correção: removido ToString redundante
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;

                // Correção: REMOVIDO ExecuteNonQuery desnecessário em SELECT
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oPais.Id = Convert.ToInt32(dr.GetValue(0));
                    oPais.Nome = dr.GetString(1);
                }

                conn.Connection.Close();
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message; // Correção ortográfica
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            pais oPais = (pais)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM pais WHERE ID_PAIS = '" + oPais.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
                conn.Connection.Close();

                ok = "Excluído com sucesso!"; // Correção de formatação
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message; // Correção ortográfica
            }

            return ok;
        }
    }
}

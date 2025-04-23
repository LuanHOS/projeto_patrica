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

            sql = "INSERT INTO pais (NOME, ATIVO) VALUES('" + oPais.Nome + "', '" + (oPais.Ativo ? 1 : 0) + "')";

            if (oPais.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE pais SET " +
                      "NOME = '" + oPais.Nome + "', " +
                      "ATIVO = '" + (oPais.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_PAIS = '" + oPais.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oPais.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oPais.Id.ToString();
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
                    Convert.ToInt32(dr["ID_PAIS"]),
                    dr["NOME"].ToString(),
                    Convert.ToBoolean(dr["ATIVO"]),
                    Convert.ToDateTime(dr["DATA_CADASTRO"]),
                    dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"])
                ));
            }

            conn.Connection.Close();
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            pais oPais = (pais)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM pais WHERE ID_PAIS = '" + oPais.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;

                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oPais.Id = Convert.ToInt32(dr["ID_PAIS"]);
                    oPais.Nome = dr["NOME"].ToString();
                    oPais.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oPais.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oPais.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
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

                ok = "Excluído com sucesso!";
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }
    }
}

using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_marca : Dao
    {
        public Dao_marca()
        {
        }

        public override string Salvar(object obj)
        {
            marca oMarca = (marca)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO MARCA (NOME, ATIVO) VALUES('"
                  + oMarca.Nome + "', '"
                  + (oMarca.Ativo ? 1 : 0) + "')";

            if (oMarca.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE MARCA SET " +
                      "NOME = '" + oMarca.Nome + "', " +
                      "ATIVO = '" + (oMarca.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_MARCA = '" + oMarca.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oMarca.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oMarca.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            marca oMarca = (marca)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM MARCA WHERE ID_MARCA = '" + oMarca.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;

                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oMarca.Id = Convert.ToInt32(dr["ID_MARCA"]);
                    oMarca.Nome = dr["NOME"].ToString();
                    oMarca.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oMarca.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oMarca.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
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
            marca oMarca = (marca)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM MARCA WHERE ID_MARCA = '" + oMarca.Id + "'";
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

        public List<marca> ListarMarcas()
        {
            List<marca> lista = new List<marca>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;
            conn.CommandText = "SELECT * FROM MARCA";

            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                marca oMarca = new marca();
                oMarca.Id = Convert.ToInt32(dr["ID_MARCA"]);
                oMarca.Nome = dr["NOME"].ToString();
                oMarca.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oMarca.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oMarca.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                lista.Add(oMarca);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

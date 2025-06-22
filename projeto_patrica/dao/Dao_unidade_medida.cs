using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_unidade_medida : Dao
    {
        public Dao_unidade_medida()
        {
        }

        public override string Salvar(object obj)
        {
            unidade_medida oUnidadeMedida = (unidade_medida)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO UNIDADE_MEDIDA (NOME, ATIVO) VALUES('" + oUnidadeMedida.Nome + "', '" + (oUnidadeMedida.Ativo ? 1 : 0) + "')";

            if (oUnidadeMedida.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE UNIDADE_MEDIDA SET " +
                      "NOME = '" + oUnidadeMedida.Nome + "', " +
                      "ATIVO = '" + (oUnidadeMedida.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_UNIDADE_MEDIDA = '" + oUnidadeMedida.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oUnidadeMedida.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oUnidadeMedida.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public List<unidade_medida> ListarUnidadeMedida()
        {
            List<unidade_medida> lista = new List<unidade_medida>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;
            conn.CommandText = "SELECT * FROM UNIDADE_MEDIDA";

            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new unidade_medida(
                    Convert.ToInt32(dr["ID_UNIDADE_MEDIDA"]),
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
            unidade_medida oUnidadeMedida = (unidade_medida)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM UNIDADE_MEDIDA WHERE ID_UNIDADE_MEDIDA = '" + oUnidadeMedida.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;

                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oUnidadeMedida.Id = Convert.ToInt32(dr["ID_UNIDADE_MEDIDA"]);
                    oUnidadeMedida.Nome = dr["NOME"].ToString();
                    oUnidadeMedida.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oUnidadeMedida.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oUnidadeMedida.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
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
            unidade_medida oUnidadeMedida = (unidade_medida)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM UNIDADE_MEDIDA WHERE ID_UNIDADE_MEDIDA = '" + oUnidadeMedida.Id + "'";
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
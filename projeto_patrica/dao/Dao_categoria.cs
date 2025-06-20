using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_categoria : Dao
    {
        public Dao_categoria()
        {
        }

        public override string Salvar(object obj)
        {
            categoria oCategoria = (categoria)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO CATEGORIA (NOME, DESCRICAO, ATIVO) VALUES('"
                  + oCategoria.Nome + "', '"
                  + oCategoria.Descricao + "', '"
                  + (oCategoria.Ativo ? 1 : 0) + "')";

            if (oCategoria.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE CATEGORIA SET " +
                      "NOME = '" + oCategoria.Nome + "', " +
                      "DESCRICAO = '" + oCategoria.Descricao + "', " +
                      "ATIVO = '" + (oCategoria.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_CATEGORIA = '" + oCategoria.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oCategoria.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oCategoria.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            categoria oCategoria = (categoria)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM CATEGORIA WHERE ID_CATEGORIA = '" + oCategoria.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;

                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oCategoria.Id = Convert.ToInt32(dr["ID_CATEGORIA"]);
                    oCategoria.Nome = dr["NOME"].ToString();
                    oCategoria.Descricao = dr["DESCRICAO"].ToString();
                    oCategoria.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oCategoria.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oCategoria.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
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
            categoria oCategoria = (categoria)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM CATEGORIA WHERE ID_CATEGORIA = '" + oCategoria.Id + "'";
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

        public List<categoria> ListarCategorias()
        {
            List<categoria> lista = new List<categoria>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;
            conn.CommandText = "SELECT * FROM CATEGORIA";

            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                categoria oCategoria = new categoria();
                oCategoria.Id = Convert.ToInt32(dr["ID_CATEGORIA"]);
                oCategoria.Nome = dr["NOME"].ToString();
                oCategoria.Descricao = dr["DESCRICAO"].ToString();
                oCategoria.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oCategoria.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oCategoria.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                lista.Add(oCategoria);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

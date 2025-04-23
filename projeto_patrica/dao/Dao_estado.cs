using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_estado : Dao
    {
        public Dao_estado()
        {
        }

        public override string Salvar(object obj)
        {
            estado oEstado = (estado)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO estado (NOME, ID_PAIS, ATIVO) " +
                  "VALUES('" + oEstado.Nome + "', '" + oEstado.OPais.Id + "', '" + (oEstado.Ativo ? 1 : 0) + "')";

            if (oEstado.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE estado SET " +
                      "NOME = '" + oEstado.Nome + "', " +
                      "ID_PAIS = '" + oEstado.OPais.Id + "', " +
                      "ATIVO = '" + (oEstado.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_ESTADO = '" + oEstado.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oEstado.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oEstado.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public List<estado> ListarEstados()
        {
            estado oEstado;
            List<estado> lista = new List<estado>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM estado";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                oEstado = new estado();
                oEstado.Id = Convert.ToInt32(dr["ID_ESTADO"]);
                oEstado.Nome = dr["NOME"].ToString();
                oEstado.OPais.Id = Convert.ToInt32(dr["ID_PAIS"]);
                oEstado.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oEstado.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oEstado.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                Controller_pais controller = new Controller_pais();
                controller.CarregaObj(oEstado.OPais);

                lista.Add(oEstado);
            }

            conn.Connection.Close();
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            estado oEstado = (estado)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM estado WHERE ID_ESTADO = '" + oEstado.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oEstado.Id = Convert.ToInt32(dr["ID_ESTADO"]);
                    oEstado.Nome = dr["NOME"].ToString();
                    oEstado.OPais.Id = Convert.ToInt32(dr["ID_PAIS"]);
                    oEstado.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oEstado.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oEstado.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                }

                conn.Connection.Close();

                Controller_pais controller = new Controller_pais();
                controller.CarregaObj(oEstado.OPais);
            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            estado oEstado = (estado)obj;
            string ok = "";

            try
            {
                string sql = "DELETE FROM estado WHERE ID_ESTADO = '" + oEstado.Id + "'";
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

﻿using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
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

            sql = "INSERT INTO cidade (NOME, ID_ESTADO, ATIVO) " +
                  "VALUES('" + aCidade.Nome + "', '" + aCidade.OEstado.Id + "', '" + (aCidade.Ativo ? 1 : 0) + "')";

            if (aCidade.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE cidade SET " +
                      "NOME = '" + aCidade.Nome + "', " +
                      "ID_ESTADO = '" + aCidade.OEstado.Id + "', " +
                      "ATIVO = '" + (aCidade.Ativo ? 1 : 0) + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_CIDADE = '" + aCidade.Id + "'";
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
                    aCidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                    aCidade.Nome = dr["NOME"].ToString();
                    aCidade.OEstado.Id = Convert.ToInt32(dr["ID_ESTADO"]);
                    aCidade.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    aCidade.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    aCidade.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                }

                conn.Connection.Close();

                Controller_estado controller = new Controller_estado();
                controller.CarregaObj(aCidade.OEstado);
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
                aCidade.Id = Convert.ToInt32(dr["ID_CIDADE"]);
                aCidade.Nome = dr["NOME"].ToString();
                aCidade.OEstado.Id = Convert.ToInt32(dr["ID_ESTADO"]);
                aCidade.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                aCidade.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                aCidade.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                lista.Add(aCidade);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}

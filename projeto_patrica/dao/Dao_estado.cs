/*using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.dao
{
    class Dao_estado : Dao
    {
        public Dao_estado()
        {

        }
        public override string Salvar(Object obj)
        {
            estado oEstado = (estado)obj;
            string ok = "";
            char operacao = 'I';
            string sql;
            sql = "insert estado values('" + oEstado.Nome + "','" + oEstado.OPais.Id + "')";

            if (oEstado.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE estado SET nome = '" + oEstado.Nome + "',id_pais='" + oEstado.OPais.Id + "' WHERE ID_ESTADO = '" + oEstado.Id + "'"; ;

            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();


            if (operacao == 'I')
            {
                conn.CommandText = "select @@identity";
                ok = conn.ExecuteScalar().ToString();
                oEstado.Id = Convert.ToInt32(ok);
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

            conn.CommandText = "select * from estado";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                oEstado = new estado();
                oEstado.Id = Convert.ToInt32(dr.GetValue(0));
                oEstado.Nome = dr.GetString(1);
                oEstado.OPais.Id = Convert.ToInt32(dr.GetValue(2));
                lista.Add(oEstado);
            }
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            estado oEstado = (estado)obj;
            string ok = "";

            try
            {
                string sql = "select * from estado where ID_ESTADO = '" + Convert.ToString(oEstado.Id) + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oEstado.Id = Convert.ToInt32(dr.GetValue(0));
                    oEstado.Nome = dr.GetString(1);
                    oEstado.OPais.Id = Convert.ToInt16(dr.GetValue(2));

                }
                conn.Connection.Close();
            }
            catch (MySqlException ex)
            {
                ok = "Error de banco de dados" + ex.Message;
            }
            return ok;
        }
        public override string Excluir(object obj)
        {
            estado oEstado = (estado)obj;
            string ok = "";

            try
            {
                string sql = "delete from estado where ID_ESTADO = '" + Convert.ToString(oEstado.Id) + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
                conn.Connection.Close();
                ok = "Excluido !";
            }
            catch (MySqlException ex)
            {
                ok = "Error de banco de dados" + ex.Message;
            }
            return ok;
        }
    }
}*/






using MySql.Data.MySqlClient;
using projeto_patrica.classes;
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

            sql = "INSERT INTO estado (NOME, ID_PAIS) VALUES('" + oEstado.Nome + "', '" + oEstado.OPais.Id + "')";

            if (oEstado.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE estado SET NOME = '" + oEstado.Nome + "', ID_PAIS = '" + oEstado.OPais.Id + "' WHERE ID_ESTADO = '" + oEstado.Id + "'";
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
                oEstado.Id = Convert.ToInt32(dr.GetValue(0));
                oEstado.Nome = dr.GetString(1);
                oEstado.OPais.Id = Convert.ToInt32(dr.GetValue(2));
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
                    oEstado.Id = Convert.ToInt32(dr.GetValue(0));
                    oEstado.Nome = dr.GetString(1);
                    oEstado.OPais.Id = Convert.ToInt16(dr.GetValue(2));
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

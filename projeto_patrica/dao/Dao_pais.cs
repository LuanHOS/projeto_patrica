using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            sql = "insert pais values('" + oPais.Nome + "')";

            if (oPais.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE pais SET Nome = '" + oPais.Nome + "' WHERE ID_PAIS = '" + oPais.Id + "'"; ;

            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();


            if (operacao == 'I')
            {
                conn.CommandText = "select @@identity";
                ok = conn.ExecuteScalar().ToString();
                oPais.Id = Convert.ToInt32(ok);
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

            conn.CommandText = "select * from PAIS";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new pais(Convert.ToInt32(dr.GetValue(0)),
                    dr.GetString(1)
                    ));
            }
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            pais oPais = (pais)obj;
            string ok = "";

            try
            {
                string sql = "select * from pais where ID_PAIS = '" + Convert.ToString(oPais.Id) + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
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
                ok = "Error de banco de dados" + ex.Message;
            }
            return ok;
        }
        public override string Excluir(object obj)
        {
            pais oPais = (pais)obj;
            string ok = "";

            try
            {
                string sql = "delete from pais where ID_PAIS = '" + Convert.ToString(oPais.Id) + "'";
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
}

using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            sql = "INSERT CIDADE VALUES('" + aCidade.Nome + "','" + aCidade.OEstado.Id + "')";

            if (aCidade.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE CIDADE SET NOME = '" + aCidade.Nome + "',ID_ESTADO = '" + aCidade.OEstado.Id + "' WHERE ID_CIDADE = '" + aCidade.Id + "'"; ;

            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();


            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@identity";
                ok = conn.ExecuteScalar().ToString();
                aCidade.Id = Convert.ToInt32(ok);
            }


            conn.Connection.Close();
            return ok;
        }

        public override string Excluir(object obj)
        {
            cidade aCidade = (cidade)obj;
            string ok = "";

            try
            {
                string sql = "DELETE from CIDADE where ID_CIDADE = '" + Convert.ToString(aCidade.Id) + "'";
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

        public List<cidade> ListarCidades()
        {
            cidade aCidade;
            List<cidade> lista = new List<cidade>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "select * from CIDADE";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                aCidade = new cidade();
                aCidade.Id = Convert.ToInt32(dr.GetValue(0));
                aCidade.Nome = dr.GetString(1);
                aCidade.OEstado.Id = Convert.ToInt32(dr.GetValue(2));
                lista.Add(aCidade);
            }
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            cidade aCidade = (cidade)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * from CIDADE where ID_CIDADE = '" + Convert.ToString(aCidade.Id) + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                conn.ExecuteNonQuery();
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    aCidade.Id = Convert.ToInt32(dr.GetValue(0));
                    aCidade.Nome = dr.GetString(1);
                    aCidade.OEstado.Id = Convert.ToInt16(dr.GetValue(2));

                }
                conn.Connection.Close();
            }
            catch (MySqlException ex)
            {
                ok = "Error de banco de dados" + ex.Message;
            }
            return ok;
        }
    }
}

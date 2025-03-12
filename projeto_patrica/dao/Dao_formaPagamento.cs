/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_patrica.dao
{
    internal class Dao_formaPagamento : Dao
    {
        public override string Salvar(object obj)
        {
            Placas_de_Video aPlaca_de_video = (Placas_de_Video)obj;
            string ok = "";
            char operacao = 'I';
            string sql;
            sql = "insert PLACA_DE_VIDEO values('" + aPlaca_de_video.Modelo + "','" + aPlaca_de_video.Marca + "','" + aPlaca_de_video.Nucleos + "')";

            if (aPlaca_de_video.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE PLACA_DE_VIDEO SET MODELO = '" + aPlaca_de_video.Modelo + "', MARCA = '" + aPlaca_de_video.Marca + "', NUCLEOS = '" + aPlaca_de_video.Nucleos + "' WHERE ID_PLACA_DE_VIDEO = '" + aPlaca_de_video.Id + "'";
            }

            SqlCommand cnn = new SqlCommand();
            cnn.Connection = Banco.abrir();
            cnn.CommandText = sql;
            cnn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                cnn.CommandText = "select @@identity";
                ok = cnn.ExecuteScalar().ToString();
                aPlaca_de_video.Id = Convert.ToInt32(ok);
            }

            cnn.Connection.Close();
            return ok;
        }

        public List<Placas_de_Video> ListarPlacas_de_video()
        {
            List<Placas_de_Video> lista = new List<Placas_de_Video>();
            SqlCommand cnn = new SqlCommand();
            cnn.Connection = Banco.abrir();
            cnn.CommandType = System.Data.CommandType.Text;

            cnn.CommandText = "select * from PLACA_DE_VIDEO";
            var dr = cnn.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Placas_de_Video(Convert.ToInt32(dr.GetValue(0)),
                    dr.GetString(1),
                    dr.GetString(2),
                    Convert.ToInt32(dr.GetValue(3))
                    ));

            }
            return lista;
        }

        public override string CarregaObj(object obj)
        {
            Placas_de_Video aPlaca_de_video = (Placas_de_Video)obj;
            string ok = "";

            try
            {
                string sql = "select * from PLACA_DE_VIDEO where ID_PLACA_DE_VIDEO = '" + Convert.ToString(aPlaca_de_video.Id) + "'";
                SqlCommand cnn = new SqlCommand();
                cnn.Connection = Banco.abrir();
                cnn.CommandType = System.Data.CommandType.Text;
                cnn.CommandText = sql;
                cnn.ExecuteNonQuery();
                var dr = cnn.ExecuteReader();

                while (dr.Read())
                {
                    aPlaca_de_video.Id = Convert.ToInt32(dr.GetValue(0));
                    aPlaca_de_video.Modelo = dr.GetString(1);
                    aPlaca_de_video.Marca = dr.GetString(2);
                    aPlaca_de_video.Nucleos = Convert.ToInt32(dr.GetString(3));
                }
                cnn.Connection.Close();
            }
            catch (Exception ex)
            {

            }
            return ok;
        }
        public override string Excluir(object obj)
        {
            Placas_de_Video aPlaca_de_video = (Placas_de_Video)obj;
            string ok = "";

            try
            {
                string sql = "delete from PLACA_DE_VIDEO where ID_PLACA_DE_VIDEO = '" + Convert.ToString(aPlaca_de_video.Id) + "'";
                SqlCommand cnn = new SqlCommand();
                cnn.Connection = Banco.abrir();
                cnn.CommandType = System.Data.CommandType.Text;
                cnn.CommandText = sql;
                cnn.ExecuteNonQuery();

                cnn.Connection.Close();
                ok = "Excluido!";
            }
            catch (Exception ex)
            {

            }
            return ok;
        }
    }
}
*/


using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using projeto_patrica.classes;

namespace projeto_patrica.dao
{
    internal class Dao_formaPagamento : Dao
    {
        public override string Salvar(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            using (MySqlConnection conn = Banco.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (aFormaPagamento.Id == 0)
                {
                    sql = "INSERT INTO FORMA_PAGAMENTO (DESCRICAO) VALUES (@descricao);";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@descricao", aFormaPagamento.Descricao);
                }
                else
                {
                    operacao = 'U';
                    sql = "UPDATE FORMA_PAGAMENTO SET DESCRICAO = @descricao WHERE ID_FORMA_PAGAMENTO = @id;";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@descricao", aFormaPagamento.Descricao);
                    cmd.Parameters.AddWithValue("@id", aFormaPagamento.Id);
                }

                cmd.ExecuteNonQuery();

                if (operacao == 'I')
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    ok = cmd.ExecuteScalar().ToString();
                    aFormaPagamento.Id = Convert.ToInt32(ok);
                }

                conn.Close();
            }

            return ok;
        }

        public List<formaPagamento> ListarFormaPagamento()
        {
            List<formaPagamento> lista = new List<formaPagamento>();

            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "SELECT ID_FORMA_PAGAMENTO, DESCRICAO FROM FORMA_PAGAMENTO;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new formaPagamento
                    {
                        Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]),
                        Descricao = dr["DESCRICAO"].ToString()
                    });
                }

                conn.Close();
            }

            return lista;
        }

        public override string CarregaObj(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";

            try
            {
                using (MySqlConnection conn = Banco.Abrir())
                {
                    string sql = "SELECT * FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = @id;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", aFormaPagamento.Id);
                    var dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        aFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                        aFormaPagamento.Descricao = dr["DESCRICAO"].ToString();
                        ok = "Encontrado";
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ok = "Erro: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            formaPagamento aFormaPagamento = (formaPagamento)obj;
            string ok = "";

            try
            {
                using (MySqlConnection conn = Banco.Abrir())
                {
                    string sql = "DELETE FROM FORMA_PAGAMENTO WHERE ID_FORMA_PAGAMENTO = @id;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", aFormaPagamento.Id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    ok = "Excluído com sucesso!";
                }
            }
            catch (Exception ex)
            {
                ok = "Erro ao excluir: " + ex.Message;
            }

            return ok;
        }
    }
}


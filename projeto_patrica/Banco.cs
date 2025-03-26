using MySql.Data.MySqlClient;
using System;

namespace projeto_patrica
{
    internal class Banco
    {
        public static MySqlConnection Abrir()
        {
            string strCnn = "Server=localhost;Database=projeto_patrica;User ID=root;Password=Luan!123;";

            MySqlConnection conn = new MySqlConnection(strCnn);
            conn.Open();
            return conn;
        }
    }
}

using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_produto_fornecedor : Dao
    {
        public Dao_produto_fornecedor()
        {
        }

        public override string Salvar(object obj)
        {
            produto_fornecedor oProdForn = (produto_fornecedor)obj;
            string ok = "";
            string sql;

            // Verifica se o relacionamento já existe
            sql = "SELECT COUNT(*) FROM PRODUTO_FORNECEDOR WHERE ID_PRODUTO = '" + oProdForn.IdProduto + "' AND ID_FORNECEDOR = '" + oProdForn.IdFornecedor + "'";

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            int count = Convert.ToInt32(conn.ExecuteScalar());

            if (count > 0)
            {
                // UPDATE
                sql = "UPDATE PRODUTO_FORNECEDOR SET " +
                      "VALOR_ULTIMA_COMPRA = '" + oProdForn.ValorUltimaCompra.ToString().Replace(",", ".") + "', " +
                      "DATA_ULTIMA_COMPRA = '" + oProdForn.DataUltimaCompra.ToString("yyyy-MM-dd") + "', " +
                      "VALOR_ATUAL_COMPRA = '" + oProdForn.ValorAtualCompra.ToString().Replace(",", ".") + "' " +
                      "WHERE ID_PRODUTO = '" + oProdForn.IdProduto + "' AND ID_FORNECEDOR = '" + oProdForn.IdFornecedor + "'";
            }
            else
            {
                // INSERT
                sql = "INSERT INTO PRODUTO_FORNECEDOR (ID_PRODUTO, ID_FORNECEDOR, VALOR_ULTIMA_COMPRA, DATA_ULTIMA_COMPRA, VALOR_ATUAL_COMPRA) VALUES (" +
                      "'" + oProdForn.IdProduto + "', " +
                      "'" + oProdForn.IdFornecedor + "', " +
                      "'" + oProdForn.ValorUltimaCompra.ToString().Replace(",", ".") + "', " +
                      "'" + oProdForn.DataUltimaCompra.ToString("yyyy-MM-dd") + "', " +
                      "'" + oProdForn.ValorAtualCompra.ToString().Replace(",", ".") + "')";
            }

            conn.CommandText = sql;
            conn.ExecuteNonQuery();
            conn.Connection.Close();
            ok = "Salvo com sucesso!";
            return ok;
        }

        public override string Excluir(object obj)
        {
            produto_fornecedor oProdForn = (produto_fornecedor)obj;

            string sql = "DELETE FROM PRODUTO_FORNECEDOR WHERE ID_PRODUTO = '" + oProdForn.IdProduto + "' AND ID_FORNECEDOR = '" + oProdForn.IdFornecedor + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();
            conn.Connection.Close();

            return "Excluído com sucesso!";
        }

        public List<produto_fornecedor> ListarPorProduto(int idProduto)
        {
            List<produto_fornecedor> lista = new List<produto_fornecedor>();
            string sql = "SELECT * FROM PRODUTO_FORNECEDOR WHERE ID_PRODUTO = '" + idProduto + "'";

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                produto_fornecedor oProdForn = new produto_fornecedor();
                oProdForn.IdProduto = Convert.ToInt32(dr["ID_PRODUTO"]);
                oProdForn.IdFornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                oProdForn.ValorUltimaCompra = Convert.ToDecimal(dr["VALOR_ULTIMA_COMPRA"]);
                oProdForn.DataUltimaCompra = Convert.ToDateTime(dr["DATA_ULTIMA_COMPRA"]);
                oProdForn.ValorAtualCompra = Convert.ToDecimal(dr["VALOR_ATUAL_COMPRA"]);
                lista.Add(oProdForn);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}
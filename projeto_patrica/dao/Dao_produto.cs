using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;

namespace projeto_patrica.dao
{
    class Dao_produto : Dao
    {
        public Dao_produto()
        {
        }

        public override string Salvar(object obj)
        {
            produto oProduto = (produto)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO PRODUTO (NOME, DESCRICAO, CODIGO_BARRAS, ID_MARCA, ID_CATEGORIA, ID_UNIDADE_MEDIDA, VALOR_COMPRA, VALOR_VENDA, VALOR_COMPRAANTERIOR, PERCENTUAL_LUCRO, ESTOQUE, ATIVO) VALUES (" +
                  "'" + oProduto.Nome + "', " +
                  (string.IsNullOrWhiteSpace(oProduto.Descricao) ? "NULL" : "'" + oProduto.Descricao + "'") + ", " +
                  "'" + oProduto.CodigoBarras + "', " +
                  "'" + oProduto.OMarca.Id + "', " +
                  "'" + oProduto.OCategoria.Id + "', " +
                  "'" + oProduto.OUnidadeMedida.Id + "', " +
                  "'" + oProduto.ValorCompra.ToString().Replace(",", ".") + "', " +
                  "'" + oProduto.ValorVenda.ToString().Replace(",", ".") + "', " +
                  "'" + oProduto.ValorCompraAnterior.ToString().Replace(",", ".") + "', " +
                  "'" + oProduto.PercentualLucro.ToString().Replace(",", ".") + "', " +
                  "'" + oProduto.Estoque + "', " +
                  (oProduto.Ativo ? "1" : "0") + ")";

            if (oProduto.Id != 0)
            {
                operacao = 'U';
                sql = "UPDATE PRODUTO SET " +
                      "NOME = '" + oProduto.Nome + "', " +
                      "DESCRICAO = " + (string.IsNullOrWhiteSpace(oProduto.Descricao) ? "NULL" : "'" + oProduto.Descricao + "'") + ", " +
                      "CODIGO_BARRAS = '" + oProduto.CodigoBarras + "', " +
                      "ID_MARCA = '" + oProduto.OMarca.Id + "', " +
                      "ID_CATEGORIA = '" + oProduto.OCategoria.Id + "', " +
                      "ID_UNIDADE_MEDIDA = '" + oProduto.OUnidadeMedida.Id + "', " +
                      "VALOR_COMPRA = '" + oProduto.ValorCompra.ToString().Replace(",", ".") + "', " +
                      "VALOR_VENDA = '" + oProduto.ValorVenda.ToString().Replace(",", ".") + "', " +
                      "VALOR_COMPRAANTERIOR = '" + oProduto.ValorCompraAnterior.ToString().Replace(",", ".") + "', " +
                      "PERCENTUAL_LUCRO = '" + oProduto.PercentualLucro.ToString().Replace(",", ".") + "', " +
                      "ESTOQUE = '" + oProduto.Estoque + "', " +
                      "ATIVO = " + (oProduto.Ativo ? "1" : "0") + ", " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_PRODUTO = '" + oProduto.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                oProduto.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = oProduto.Id.ToString();
            }

            conn.Connection.Close();
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            produto oProduto = (produto)obj;
            string ok = "";

            try
            {
                string sql = "SELECT * FROM PRODUTO WHERE ID_PRODUTO = '" + oProduto.Id + "'";
                MySqlCommand conn = new MySqlCommand();
                conn.Connection = Banco.Abrir();
                conn.CommandType = System.Data.CommandType.Text;
                conn.CommandText = sql;
                var dr = conn.ExecuteReader();

                while (dr.Read())
                {
                    oProduto.Id = Convert.ToInt32(dr["ID_PRODUTO"]);
                    oProduto.Nome = dr["NOME"].ToString();
                    oProduto.Descricao = dr["DESCRICAO"] == DBNull.Value ? null : dr["DESCRICAO"].ToString();
                    oProduto.CodigoBarras = dr["CODIGO_BARRAS"].ToString();
                    oProduto.OMarca.Id = Convert.ToInt32(dr["ID_MARCA"]);
                    oProduto.OCategoria.Id = Convert.ToInt32(dr["ID_CATEGORIA"]);
                    oProduto.OUnidadeMedida.Id = Convert.ToInt32(dr["ID_UNIDADE_MEDIDA"]);
                    oProduto.ValorCompra = Convert.ToDecimal(dr["VALOR_COMPRA"]);
                    oProduto.ValorVenda = Convert.ToDecimal(dr["VALOR_VENDA"]);
                    oProduto.ValorCompraAnterior = Convert.ToDecimal(dr["VALOR_COMPRAANTERIOR"]);
                    oProduto.PercentualLucro = Convert.ToDecimal(dr["PERCENTUAL_LUCRO"]);
                    oProduto.Estoque = Convert.ToInt32(dr["ESTOQUE"]);
                    oProduto.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    oProduto.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    oProduto.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                }

                conn.Connection.Close();

                Controller_marca controllerMarca = new Controller_marca();
                controllerMarca.CarregaObj(oProduto.OMarca);

                Controller_categoria controllerCategoria = new Controller_categoria();
                controllerCategoria.CarregaObj(oProduto.OCategoria);

                Controller_unidade_medida controllerUnidadeMedida = new Controller_unidade_medida();
                controllerUnidadeMedida.CarregaObj(oProduto.OUnidadeMedida);

            }
            catch (MySqlException ex)
            {
                ok = "Erro de banco de dados: " + ex.Message;
            }

            return ok;
        }

        public override string Excluir(object obj)
        {
            produto oProduto = (produto)obj;

            string sql = "DELETE FROM PRODUTO WHERE ID_PRODUTO = '" + oProduto.Id + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;
            conn.CommandText = sql;
            conn.ExecuteNonQuery();
            conn.Connection.Close();

            return "Excluído com sucesso!";
        }

        public List<produto> ListarProdutos()
        {
            List<produto> lista = new List<produto>();
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandType = System.Data.CommandType.Text;

            conn.CommandText = "SELECT * FROM PRODUTO";
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                produto oProduto = new produto();
                oProduto.Id = Convert.ToInt32(dr["ID_PRODUTO"]);
                oProduto.Nome = dr["NOME"].ToString();
                oProduto.Descricao = dr["DESCRICAO"] == DBNull.Value ? null : dr["DESCRICAO"].ToString();
                oProduto.CodigoBarras = dr["CODIGO_BARRAS"].ToString();
                oProduto.OMarca.Id = Convert.ToInt32(dr["ID_MARCA"]);
                oProduto.OCategoria.Id = Convert.ToInt32(dr["ID_CATEGORIA"]);
                oProduto.OUnidadeMedida.Id = Convert.ToInt32(dr["ID_UNIDADE_MEDIDA"]);
                oProduto.ValorCompra = Convert.ToDecimal(dr["VALOR_COMPRA"]);
                oProduto.ValorVenda = Convert.ToDecimal(dr["VALOR_VENDA"]);
                oProduto.ValorCompraAnterior = Convert.ToDecimal(dr["VALOR_COMPRAANTERIOR"]);
                oProduto.PercentualLucro = Convert.ToDecimal(dr["PERCENTUAL_LUCRO"]);
                oProduto.Estoque = Convert.ToInt32(dr["ESTOQUE"]);
                oProduto.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                oProduto.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                oProduto.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                lista.Add(oProduto);
            }

            conn.Connection.Close();
            return lista;
        }
    }
}
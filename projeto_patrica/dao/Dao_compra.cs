using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace projeto_patrica.dao
{
    class Dao_compra : Dao
    {
        public Dao_compra()
        {
        }

        public override string Salvar(object obj)
        {
            compra aCompra = (compra)obj;
            string ok = "";
            MySqlConnection conn = null;
            MySqlTransaction trans = null;

            try
            {
                conn = Banco.Abrir();
                trans = conn.BeginTransaction();

                // Verifica se a compra já existe para decidir entre INSERT e UPDATE
                string sqlCheck = "SELECT COUNT(*) FROM COMPRA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota";
                MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn, trans);
                cmdCheck.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                cmdCheck.Parameters.AddWithValue("@Serie", aCompra.Serie);
                cmdCheck.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                bool existe = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;

                string sql;
                if (!existe) // Se não existe, é um INSERT
                {
                    sql = "INSERT INTO COMPRA (MODELO, SERIE, NUMERO_NOTA, ID_FORNECEDOR, DATA_EMISSAO, DATA_ENTREGA, VALOR_FRETE, SEGURO, DESPESAS, ID_CONDICAO_PAGAMENTO, MOTIVO_CANCELAMENTO, ATIVO) " +
                          "VALUES (@Modelo, @Serie, @NumeroNota, @IdFornecedor, @DataEmissao, @DataEntrega, @ValorFrete, @Seguro, @Despesas, @IdCondicaoPagamento, @MotivoCancelamento, @Ativo)";
                }
                else // Se existe, é um UPDATE
                {
                    sql = "UPDATE COMPRA SET " +
                          "ID_FORNECEDOR = @IdFornecedor, " +
                          "DATA_EMISSAO = @DataEmissao, " +
                          "DATA_ENTREGA = @DataEntrega, " +
                          "VALOR_FRETE = @ValorFrete, " +
                          "SEGURO = @Seguro, " +
                          "DESPESAS = @Despesas, " +
                          "ID_CONDICAO_PAGAMENTO = @IdCondicaoPagamento, " +
                          "MOTIVO_CANCELAMENTO = @MotivoCancelamento, " +
                          "ATIVO = @Ativo, " +
                          "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                          "WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
                cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                cmd.Parameters.AddWithValue("@IdFornecedor", aCompra.OFornecedor.Id);
                cmd.Parameters.AddWithValue("@DataEmissao", aCompra.DataEmissao);
                cmd.Parameters.AddWithValue("@DataEntrega", aCompra.DataEntrega);
                cmd.Parameters.AddWithValue("@ValorFrete", aCompra.ValorFrete);
                cmd.Parameters.AddWithValue("@Seguro", aCompra.Seguro);
                cmd.Parameters.AddWithValue("@Despesas", aCompra.Despesas);
                cmd.Parameters.AddWithValue("@IdCondicaoPagamento", aCompra.ACondicaoPagamento.Id);
                cmd.Parameters.AddWithValue("@MotivoCancelamento", aCompra.MotivoCancelamento);
                cmd.Parameters.AddWithValue("@Ativo", aCompra.Ativo);
                cmd.ExecuteNonQuery();

                // Para UPDATE, primeiro excluímos itens e parcelas existentes para reinseri-los
                if (existe)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM ITEM_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
                    cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
                    cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM PARCELA_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
                    cmd.ExecuteNonQuery();
                }

                // Salvar Itens e Parcelas
                foreach (itemCompra item in aCompra.Itens)
                {
                    SalvarItem(item, conn, trans);
                }

                foreach (parcelaCompra parcela in aCompra.Parcelas)
                {
                    SalvarParcela(parcela, conn, trans);
                }

                trans.Commit();
                ok = "Compra salva com sucesso!";
            }
            catch (Exception ex)
            {
                trans?.Rollback();
                ok = "Erro ao salvar compra: " + ex.Message;
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public override string Excluir(object obj)
        {
            compra aCompra = (compra)obj;
            string ok = "";
            MySqlConnection conn = null;
            try
            {
                conn = Banco.Abrir();
                string sql = "DELETE FROM COMPRA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
                cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                cmd.ExecuteNonQuery();
                ok = "Compra excluída com sucesso!";
            }
            catch (Exception ex)
            {
                ok = "Erro ao excluir compra: " + ex.Message;
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            compra aCompra = (compra)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM COMPRA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
                cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    aCompra.Modelo = Convert.ToInt32(dr["MODELO"]);
                    aCompra.Serie = dr["SERIE"].ToString();
                    aCompra.NumeroNota = dr["NUMERO_NOTA"].ToString();
                    aCompra.OFornecedor.Id = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                    aCompra.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                    aCompra.DataEntrega = dr.IsDBNull(dr.GetOrdinal("DATA_ENTREGA")) ? DateTime.MinValue : Convert.ToDateTime(dr["DATA_ENTREGA"]);
                    aCompra.ValorFrete = Convert.ToDecimal(dr["VALOR_FRETE"]);
                    aCompra.Seguro = Convert.ToDecimal(dr["SEGURO"]);
                    aCompra.Despesas = Convert.ToDecimal(dr["DESPESAS"]);
                    aCompra.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                    aCompra.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();
                    aCompra.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    aCompra.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    aCompra.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                }
                dr.Close();

                // Carrega objetos relacionados
                Controller_fornecedor cf = new Controller_fornecedor();
                cf.CarregaObj(aCompra.OFornecedor);

                Controller_condicaoPagamento ccp = new Controller_condicaoPagamento();
                ccp.CarregaObj(aCompra.ACondicaoPagamento);

                // Carrega listas filhas
                aCompra.Itens = ListarItensDaCompra(aCompra, conn);
                aCompra.Parcelas = ListarParcelasDaCompra(aCompra, conn);
            }
            catch (Exception ex)
            {
                ok = "Erro ao carregar compra: " + ex.Message;
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public List<compra> ListarCompras()
        {
            List<compra> lista = new List<compra>();
            MySqlConnection conn = null;
            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM COMPRA";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    compra aCompra = new compra();
                    aCompra.Modelo = Convert.ToInt32(dr["MODELO"]);
                    aCompra.Serie = dr["SERIE"].ToString();
                    aCompra.NumeroNota = dr["NUMERO_NOTA"].ToString();
                    aCompra.OFornecedor.Id = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                    aCompra.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                    aCompra.Ativo = Convert.ToBoolean(dr["ATIVO"]);

                    lista.Add(aCompra);
                }
                dr.Close();

                // Carrega os fornecedores para a lista
                Controller_fornecedor cf = new Controller_fornecedor();
                foreach (var compra in lista)
                {
                    cf.CarregaObj(compra.OFornecedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar compras: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return lista;
        }

        // --- Métodos Auxiliares ---
        private void SalvarItem(itemCompra item, MySqlConnection conn, MySqlTransaction trans)
        {
            string sql = "INSERT INTO ITEM_COMPRA (MODELO_COMPRA, SERIE_COMPRA, NUMERO_NOTA_COMPRA, ID_PRODUTO, QUANTIDADE, VALOR_UNITARIO) VALUES " +
                         "(@ModeloCompra, @SerieCompra, @NumeroNotaCompra, @IdProduto, @Quantidade, @ValorUnitario)";
            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@ModeloCompra", item.ModeloCompra);
            cmd.Parameters.AddWithValue("@SerieCompra", item.SerieCompra);
            cmd.Parameters.AddWithValue("@NumeroNotaCompra", item.NumeroNotaCompra);
            cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
            cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
            cmd.ExecuteNonQuery();
        }

        private void SalvarParcela(parcelaCompra parcela, MySqlConnection conn, MySqlTransaction trans)
        {
            string sql = "INSERT INTO PARCELA_COMPRA (MODELO_COMPRA, SERIE_COMPRA, NUMERO_NOTA_COMPRA, NUMERO_PARCELA, DATA_VENCIMENTO, VALOR_PARCELA) VALUES " +
                         "(@ModeloCompra, @SerieCompra, @NumeroNotaCompra, @NumeroParcela, @DataVencimento, @ValorParcela)";
            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@ModeloCompra", parcela.ModeloCompra);
            cmd.Parameters.AddWithValue("@SerieCompra", parcela.SerieCompra);
            cmd.Parameters.AddWithValue("@NumeroNotaCompra", parcela.NumeroNotaCompra);
            cmd.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
            cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
            cmd.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
            cmd.ExecuteNonQuery();
        }

        private List<itemCompra> ListarItensDaCompra(compra aCompra, MySqlConnection conn)
        {
            List<itemCompra> itens = new List<itemCompra>();
            string sql = "SELECT * FROM ITEM_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
            cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
            cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                itemCompra item = new itemCompra();
                item.OProduto.Id = Convert.ToInt32(dr["ID_PRODUTO"]);
                item.Quantidade = Convert.ToInt32(dr["QUANTIDADE"]);
                item.ValorUnitario = Convert.ToDecimal(dr["VALOR_UNITARIO"]);
                itens.Add(item);
            }
            dr.Close();

            Controller_produto cp = new Controller_produto();
            foreach (var item in itens)
            {
                cp.CarregaObj(item.OProduto);
            }
            return itens;
        }

        private List<parcelaCompra> ListarParcelasDaCompra(compra aCompra, MySqlConnection conn)
        {
            List<parcelaCompra> parcelas = new List<parcelaCompra>();
            string sql = "SELECT * FROM PARCELA_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
            cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
            cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                parcelaCompra parcela = new parcelaCompra();
                parcela.NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]);
                parcela.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                parcela.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                parcelas.Add(parcela);
            }
            dr.Close();
            return parcelas;
        }
    }
}


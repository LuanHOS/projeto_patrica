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

                string sqlCheck = "SELECT COUNT(*) FROM COMPRA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota";
                MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn, trans);
                cmdCheck.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                cmdCheck.Parameters.AddWithValue("@Serie", aCompra.Serie);
                cmdCheck.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                bool existe = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;

                string sql;
                if (!existe)
                {
                    sql = "INSERT INTO COMPRA (MODELO, SERIE, NUMERO_NOTA, ID_FORNECEDOR, DATA_EMISSAO, DATA_ENTREGA, VALOR_FRETE, SEGURO, DESPESAS, ID_CONDICAO_PAGAMENTO, MOTIVO_CANCELAMENTO, ATIVO) " +
                          "VALUES (@Modelo, @Serie, @NumeroNota, @IdFornecedor, @DataEmissao, @DataEntrega, @ValorFrete, @Seguro, @Despesas, @IdCondicaoPagamento, @MotivoCancelamento, @Ativo)";
                }
                else
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
                cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)aCompra.MotivoCancelamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ativo", aCompra.Ativo);
                cmd.ExecuteNonQuery();

                if (existe)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM ITEM_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
                    cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
                    cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM CONTAS_A_PAGAR WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
                    cmd.ExecuteNonQuery();
                }

                foreach (itemCompra item in aCompra.Itens)
                {
                    SalvarItem(item, conn, trans);
                }

                foreach (contasAPagar conta in aCompra.Parcelas)
                {
                    SalvarContaAPagar(conta, conn, trans);
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

                    if (dr.IsDBNull(dr.GetOrdinal("DATA_ENTREGA")) || Convert.ToDateTime(dr["DATA_ENTREGA"]) < new DateTime(1753, 1, 1))
                    {
                        aCompra.DataEntrega = aCompra.DataEmissao;
                    }
                    else
                    {
                        aCompra.DataEntrega = Convert.ToDateTime(dr["DATA_ENTREGA"]);
                    }

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

                Controller_fornecedor cf = new Controller_fornecedor();
                cf.CarregaObj(aCompra.OFornecedor);

                Controller_condicaoPagamento ccp = new Controller_condicaoPagamento();
                ccp.CarregaObj(aCompra.ACondicaoPagamento);

                aCompra.Itens = ListarItensDaCompra(aCompra, conn);
                aCompra.Parcelas = ListarContasAPagarDaCompra(aCompra, conn);
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

        private void SalvarContaAPagar(contasAPagar conta, MySqlConnection conn, MySqlTransaction trans)
        {
            string sql = "INSERT INTO CONTAS_A_PAGAR (MODELO_COMPRA, SERIE_COMPRA, NUMERO_NOTA_COMPRA, ID_FORNECEDOR, NUMERO_PARCELA, DATA_EMISSAO, DATA_VENCIMENTO, VALOR_PARCELA, ID_FORMA_PAGAMENTO) VALUES " +
                         "(@ModeloCompra, @SerieCompra, @NumeroNotaCompra, @IdFornecedor, @NumeroParcela, @DataEmissao, @DataVencimento, @ValorParcela, @IdFormaPagamento)";
            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@ModeloCompra", conta.ModeloCompra);
            cmd.Parameters.AddWithValue("@SerieCompra", conta.SerieCompra);
            cmd.Parameters.AddWithValue("@NumeroNotaCompra", conta.NumeroNotaCompra);
            cmd.Parameters.AddWithValue("@IdFornecedor", conta.IdFornecedor);
            cmd.Parameters.AddWithValue("@NumeroParcela", conta.NumeroParcela);
            cmd.Parameters.AddWithValue("@DataEmissao", conta.DataEmissao);
            cmd.Parameters.AddWithValue("@DataVencimento", conta.DataVencimento);
            cmd.Parameters.AddWithValue("@ValorParcela", conta.ValorParcela);
            cmd.Parameters.AddWithValue("@IdFormaPagamento", conta.AFormaPagamento.Id);
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
                item.ModeloCompra = aCompra.Modelo;
                item.SerieCompra = aCompra.Serie;
                item.NumeroNotaCompra = aCompra.NumeroNota;
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

        private List<contasAPagar> ListarContasAPagarDaCompra(compra aCompra, MySqlConnection conn)
        {
            List<contasAPagar> parcelas = new List<contasAPagar>();
            string sql = "SELECT * FROM CONTAS_A_PAGAR WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
            cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
            cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);

            var dr = cmd.ExecuteReader();
            Controller_formaPagamento cfp = new Controller_formaPagamento();

            while (dr.Read())
            {
                contasAPagar parcela = new contasAPagar();
                parcela.ModeloCompra = aCompra.Modelo;
                parcela.SerieCompra = aCompra.Serie;
                parcela.NumeroNotaCompra = aCompra.NumeroNota;
                parcela.IdFornecedor = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                parcela.NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]);
                parcela.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                parcela.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                parcela.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                parcela.AFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);

                parcelas.Add(parcela);
            }
            dr.Close();

            foreach (var p in parcelas)
            {
                cfp.CarregaObj(p.AFormaPagamento);
            }

            return parcelas;
        }
    }
}
using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace projeto_patrica.dao
{
    class Dao_compra : Dao
    {
        public Dao_compra()
        {
        }

        public bool VerificarCompraExistente(int modelo, string serie, string numeroNota, int idFornecedor)
        {
            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "SELECT COUNT(*) FROM COMPRA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota AND ID_FORNECEDOR = @IdFornecedor";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Serie", serie);
                cmd.Parameters.AddWithValue("@NumeroNota", numeroNota);
                cmd.Parameters.AddWithValue("@IdFornecedor", idFornecedor);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
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

                string sqlCheck = "SELECT COUNT(*) FROM COMPRA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota AND ID_FORNECEDOR = @IdFornecedor";
                MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn, trans);
                cmdCheck.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                cmdCheck.Parameters.AddWithValue("@Serie", aCompra.Serie);
                cmdCheck.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                cmdCheck.Parameters.AddWithValue("@IdFornecedor", aCompra.OFornecedor.Id);
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
                          "DATA_EMISSAO = @DataEmissao, " +
                          "DATA_ENTREGA = @DataEntrega, " +
                          "VALOR_FRETE = @ValorFrete, " +
                          "SEGURO = @Seguro, " +
                          "DESPESAS = @Despesas, " +
                          "ID_CONDICAO_PAGAMENTO = @IdCondicaoPagamento, " +
                          "MOTIVO_CANCELAMENTO = @MotivoCancelamento, " +
                          "ATIVO = @Ativo, " +
                          "DATA_ULTIMA_EDICAO = CURRENT_TIMESTAMP " +
                          "WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota AND ID_FORNECEDOR = @IdFornecedor";
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
                    cmd.CommandText = "DELETE FROM ITEM_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota AND ID_FORNECEDOR = @IdFornecedor";
                    cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
                    cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
                    cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
                    cmd.Parameters.AddWithValue("@IdFornecedor", aCompra.OFornecedor.Id);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM CONTAS_A_PAGAR WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota";
                    cmd.ExecuteNonQuery();
                }

                if (aCompra.Ativo)
                {
                    decimal totalCustosAdicionais = aCompra.ValorFrete + aCompra.Seguro + aCompra.Despesas;
                    decimal valorTotalCompra = aCompra.Itens.Sum(i => i.ValorTotal);

                    foreach (itemCompra item in aCompra.Itens)
                    {
                        decimal custoUnitarioReal = item.ValorUnitario;
                        if (valorTotalCompra > 0 && item.Quantidade > 0)
                        {
                            custoUnitarioReal += (totalCustosAdicionais * (item.ValorTotal / valorTotalCompra)) / item.Quantidade;
                        }
                        item.CustoUnitarioReal = custoUnitarioReal;

                        SalvarItem(item, conn, trans);
                        AtualizarProdutoFornecedor(item, item.CustoUnitarioReal, aCompra.DataEmissao, conn, trans);
                        AtualizarProduto(item, item.CustoUnitarioReal, conn, trans);
                    }
                }
                else
                {
                    foreach (itemCompra item in aCompra.Itens)
                    {
                        SalvarItem(item, conn, trans);
                        ReverterAtualizacaoProduto(item, conn, trans);
                    }
                    foreach (var parcela in aCompra.Parcelas)
                    {
                        parcela.Ativo = false;
                    }
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
                return "Erro ao salvar compra: " + ex.Message;
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        private void AtualizarProdutoFornecedor(itemCompra item, decimal custoUnitarioReal, DateTime dataCompra, MySqlConnection conn, MySqlTransaction trans)
        {
            string sqlCheck = "SELECT VALOR_ATUAL_COMPRA FROM PRODUTO_FORNECEDOR WHERE ID_PRODUTO = @IdProduto AND ID_FORNECEDOR = @IdFornecedor";
            MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn, trans);
            cmdCheck.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
            cmdCheck.Parameters.AddWithValue("@IdFornecedor", item.IdFornecedor);
            var valorAtualCompraAnterior = cmdCheck.ExecuteScalar();

            string sql;
            if (valorAtualCompraAnterior != null)
            {
                sql = "UPDATE PRODUTO_FORNECEDOR SET VALOR_ULTIMA_COMPRA = @ValorUltimaCompra, DATA_ULTIMA_COMPRA = @DataUltimaCompra, VALOR_ATUAL_COMPRA = @ValorAtualCompra, VALOR_UNITARIO = @ValorUnitario " + 
                      "WHERE ID_PRODUTO = @IdProduto AND ID_FORNECEDOR = @IdFornecedor";
            }
            else
            {
                sql = "INSERT INTO PRODUTO_FORNECEDOR (ID_PRODUTO, ID_FORNECEDOR, VALOR_ULTIMA_COMPRA, DATA_ULTIMA_COMPRA, VALOR_ATUAL_COMPRA, VALOR_UNITARIO) " + 
                      "VALUES (@IdProduto, @IdFornecedor, @ValorUltimaCompra, @DataUltimaCompra, @ValorAtualCompra, @ValorUnitario)"; 
            }

            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
            cmd.Parameters.AddWithValue("@IdFornecedor", item.IdFornecedor);
            cmd.Parameters.AddWithValue("@ValorUltimaCompra", valorAtualCompraAnterior ?? (object)custoUnitarioReal);
            cmd.Parameters.AddWithValue("@DataUltimaCompra", dataCompra);
            cmd.Parameters.AddWithValue("@ValorAtualCompra", custoUnitarioReal);
            cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario); 
            cmd.ExecuteNonQuery();
        }

        private void AtualizarProduto(itemCompra item, decimal custoUnitarioReal, MySqlConnection conn, MySqlTransaction trans)
        {
            string sqlSelect = "SELECT ESTOQUE, VALOR_COMPRA, VALOR_VENDA FROM PRODUTO WHERE ID_PRODUTO = @IdProduto";
            MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn, trans);
            cmdSelect.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);

            using (var reader = cmdSelect.ExecuteReader())
            {
                if (reader.Read())
                {
                    int estoqueAtual = reader.GetInt32("ESTOQUE");
                    decimal custoAtual = reader.GetDecimal("VALOR_COMPRA");
                    decimal valorVenda = reader.GetDecimal("VALOR_VENDA");
                    reader.Close();

                    decimal novoCustoMedio = ((custoAtual * estoqueAtual) + (custoUnitarioReal * item.Quantidade)) / (estoqueAtual + item.Quantidade);

                    decimal novoPercentualLucro = 0;
                    if (novoCustoMedio > 0)
                    {
                        novoPercentualLucro = ((valorVenda / novoCustoMedio) - 1) * 100;
                    }

                    string sqlUpdate = "UPDATE PRODUTO SET ESTOQUE = @NovoEstoque, VALOR_COMPRA = @NovoCustoMedio, VALOR_COMPRAANTERIOR = @CustoAnterior, PERCENTUAL_LUCRO = @NovoPercentualLucro WHERE ID_PRODUTO = @IdProduto";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@NovoEstoque", estoqueAtual + item.Quantidade);
                    cmdUpdate.Parameters.AddWithValue("@NovoCustoMedio", novoCustoMedio);
                    cmdUpdate.Parameters.AddWithValue("@CustoAnterior", custoAtual);
                    cmdUpdate.Parameters.AddWithValue("@NovoPercentualLucro", novoPercentualLucro);
                    cmdUpdate.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                }
            }
        }

        private void ReverterAtualizacaoProduto(itemCompra item, MySqlConnection conn, MySqlTransaction trans)
        {
            string sqlSelect = "SELECT ESTOQUE, VALOR_COMPRA, VALOR_COMPRAANTERIOR, VALOR_VENDA FROM PRODUTO WHERE ID_PRODUTO = @IdProduto";
            MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn, trans);
            cmdSelect.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);

            using (var reader = cmdSelect.ExecuteReader())
            {
                if (reader.Read())
                {
                    int estoqueAtual = reader.GetInt32("ESTOQUE");
                    decimal custoMedioAtual = reader.GetDecimal("VALOR_COMPRA");
                    decimal valorCompraAnterior = reader.GetDecimal("VALOR_COMPRAANTERIOR");
                    decimal valorVenda = reader.GetDecimal("VALOR_VENDA");
                    reader.Close();

                    int novoEstoque = estoqueAtual - item.Quantidade;

                    decimal novoCustoMedio;
                    if (novoEstoque > 0)
                    {
                        novoCustoMedio = ((custoMedioAtual * estoqueAtual) - (item.CustoUnitarioReal * item.Quantidade)) / novoEstoque;
                    }
                    else
                    {
                        novoCustoMedio = valorCompraAnterior;
                    }

                    decimal novoPercentualLucro = 0;
                    if (novoCustoMedio > 0)
                    {
                        novoPercentualLucro = ((valorVenda / novoCustoMedio) - 1) * 100;
                    }

                    string sqlUpdate = "UPDATE PRODUTO SET ESTOQUE = @NovoEstoque, VALOR_COMPRA = @NovoCustoMedio, VALOR_COMPRAANTERIOR = @CustoAnterior, PERCENTUAL_LUCRO = @NovoPercentualLucro WHERE ID_PRODUTO = @IdProduto";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@NovoEstoque", novoEstoque);
                    cmdUpdate.Parameters.AddWithValue("@NovoCustoMedio", novoCustoMedio);
                    cmdUpdate.Parameters.AddWithValue("@CustoAnterior", valorCompraAnterior);
                    cmdUpdate.Parameters.AddWithValue("@NovoPercentualLucro", novoPercentualLucro);
                    cmdUpdate.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                }
            }
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
            string sql = "INSERT INTO ITEM_COMPRA (MODELO_COMPRA, SERIE_COMPRA, NUMERO_NOTA_COMPRA, ID_FORNECEDOR, ID_PRODUTO, QUANTIDADE, VALOR_UNITARIO, CUSTO_UNITARIO_REAL) VALUES " +
                         "(@ModeloCompra, @SerieCompra, @NumeroNotaCompra, @IdFornecedor, @IdProduto, @Quantidade, @ValorUnitario, @CustoUnitarioReal)";
            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@ModeloCompra", item.ModeloCompra);
            cmd.Parameters.AddWithValue("@SerieCompra", item.SerieCompra);
            cmd.Parameters.AddWithValue("@NumeroNotaCompra", item.NumeroNotaCompra);
            cmd.Parameters.AddWithValue("@IdFornecedor", item.IdFornecedor);
            cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
            cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
            cmd.Parameters.AddWithValue("@CustoUnitarioReal", item.CustoUnitarioReal);
            cmd.ExecuteNonQuery();
        }

        private void SalvarContaAPagar(contasAPagar conta, MySqlConnection conn, MySqlTransaction trans)
        {
            string sql = "INSERT INTO CONTAS_A_PAGAR (MODELO_COMPRA, SERIE_COMPRA, NUMERO_NOTA_COMPRA, ID_FORNECEDOR, NUMERO_PARCELA, DATA_EMISSAO, DATA_VENCIMENTO, VALOR_PARCELA, ID_FORMA_PAGAMENTO, ATIVO) VALUES " +
                         "(@ModeloCompra, @SerieCompra, @NumeroNotaCompra, @IdFornecedor, @NumeroParcela, @DataEmissao, @DataVencimento, @ValorParcela, @IdFormaPagamento, @Ativo)";
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
            cmd.Parameters.AddWithValue("@Ativo", conta.Ativo);
            cmd.ExecuteNonQuery();
        }

        private List<itemCompra> ListarItensDaCompra(compra aCompra, MySqlConnection conn)
        {
            List<itemCompra> itens = new List<itemCompra>();
            string sql = "SELECT * FROM ITEM_COMPRA WHERE MODELO_COMPRA = @Modelo AND SERIE_COMPRA = @Serie AND NUMERO_NOTA_COMPRA = @NumeroNota AND ID_FORNECEDOR = @IdFornecedor";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Modelo", aCompra.Modelo);
            cmd.Parameters.AddWithValue("@Serie", aCompra.Serie);
            cmd.Parameters.AddWithValue("@NumeroNota", aCompra.NumeroNota);
            cmd.Parameters.AddWithValue("@IdFornecedor", aCompra.OFornecedor.Id);

            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                itemCompra item = new itemCompra();
                item.ModeloCompra = aCompra.Modelo;
                item.SerieCompra = aCompra.Serie;
                item.NumeroNotaCompra = aCompra.NumeroNota;
                item.IdFornecedor = aCompra.OFornecedor.Id;
                item.OProduto.Id = Convert.ToInt32(dr["ID_PRODUTO"]);
                item.Quantidade = Convert.ToInt32(dr["QUANTIDADE"]);
                item.ValorUnitario = Convert.ToDecimal(dr["VALOR_UNITARIO"]);
                item.CustoUnitarioReal = Convert.ToDecimal(dr["CUSTO_UNITARIO_REAL"]);
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
                parcela.Ativo = Convert.ToBoolean(dr["ATIVO"]);

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
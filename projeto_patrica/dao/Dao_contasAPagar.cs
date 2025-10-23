using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.dao
{
    class Dao_contasAPagar : Dao
    {
        public Dao_contasAPagar()
        {
        }

        public override string Salvar(object obj)
        {
            contasAPagar oContaAPagar = (contasAPagar)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();

                string sqlCheck = "SELECT COUNT(*) FROM CONTAS_A_PAGAR " +
                                  "WHERE MODELO_COMPRA = @ModeloCompra AND SERIE_COMPRA = @SerieCompra " +
                                  "AND NUMERO_NOTA_COMPRA = @NumeroNotaCompra AND ID_FORNECEDOR = @IdFornecedor " +
                                  "AND NUMERO_PARCELA = @NumeroParcela";

                MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@ModeloCompra", oContaAPagar.ModeloCompra);
                cmdCheck.Parameters.AddWithValue("@SerieCompra", oContaAPagar.SerieCompra);
                cmdCheck.Parameters.AddWithValue("@NumeroNotaCompra", oContaAPagar.NumeroNotaCompra);
                cmdCheck.Parameters.AddWithValue("@IdFornecedor", oContaAPagar.OFornecedor.Id);
                cmdCheck.Parameters.AddWithValue("@NumeroParcela", oContaAPagar.NumeroParcela);

                bool existe = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;

                string sql;
                if (!existe)
                {
                    sql = "INSERT INTO CONTAS_A_PAGAR (MODELO_COMPRA, SERIE_COMPRA, NUMERO_NOTA_COMPRA, ID_FORNECEDOR, NUMERO_PARCELA, " +
                          "DATA_EMISSAO, DATA_VENCIMENTO, VALOR_PARCELA, ID_FORMA_PAGAMENTO, ATIVO, " +
                          "SITUACAO, JUROS, MULTA, DESCONTO, VALOR_PAGO, DATA_PAGAMENTO, DATA_ULTIMA_EDICAO, MOTIVO_CANCELAMENTO) VALUES " +
                          "(@ModeloCompra, @SerieCompra, @NumeroNotaCompra, @IdFornecedor, @NumeroParcela, " +
                          "@DataEmissao, @DataVencimento, @ValorParcela, @IdFormaPagamento, @Ativo, " +
                          "@Situacao, @Juros, @Multa, @Desconto, @ValorPago, @DataPagamento, @DataUltimaEdicao, @MotivoCancelamento)";
                }
                else
                {
                    sql = "UPDATE CONTAS_A_PAGAR SET " +
                          "DATA_EMISSAO = @DataEmissao, DATA_VENCIMENTO = @DataVencimento, VALOR_PARCELA = @ValorParcela, " +
                          "ID_FORMA_PAGAMENTO = @IdFormaPagamento, ATIVO = @Ativo, SITUACAO = @Situacao, " +
                          "JUROS = @Juros, MULTA = @Multa, DESCONTO = @Desconto, " +
                          "VALOR_PAGO = @ValorPago, DATA_PAGAMENTO = @DataPagamento, " +
                          "DATA_ULTIMA_EDICAO = @DataUltimaEdicao, MOTIVO_CANCELAMENTO = @MotivoCancelamento " +
                          "WHERE MODELO_COMPRA = @ModeloCompra AND SERIE_COMPRA = @SerieCompra " +
                          "AND NUMERO_NOTA_COMPRA = @NumeroNotaCompra AND ID_FORNECEDOR = @IdFornecedor " +
                          "AND NUMERO_PARCELA = @NumeroParcela";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ModeloCompra", oContaAPagar.ModeloCompra);
                cmd.Parameters.AddWithValue("@SerieCompra", oContaAPagar.SerieCompra);
                cmd.Parameters.AddWithValue("@NumeroNotaCompra", oContaAPagar.NumeroNotaCompra);
                cmd.Parameters.AddWithValue("@IdFornecedor", oContaAPagar.OFornecedor.Id);
                cmd.Parameters.AddWithValue("@NumeroParcela", oContaAPagar.NumeroParcela);
                cmd.Parameters.AddWithValue("@DataEmissao", oContaAPagar.DataEmissao);
                cmd.Parameters.AddWithValue("@DataVencimento", oContaAPagar.DataVencimento);
                cmd.Parameters.AddWithValue("@ValorParcela", oContaAPagar.ValorParcela);
                cmd.Parameters.AddWithValue("@IdFormaPagamento", oContaAPagar.AFormaPagamento.Id);
                cmd.Parameters.AddWithValue("@Ativo", oContaAPagar.Ativo);
                cmd.Parameters.AddWithValue("@Situacao", oContaAPagar.Situacao);
                cmd.Parameters.AddWithValue("@Juros", oContaAPagar.Juros);
                cmd.Parameters.AddWithValue("@Multa", oContaAPagar.Multa);
                cmd.Parameters.AddWithValue("@Desconto", oContaAPagar.Desconto);
                cmd.Parameters.AddWithValue("@ValorPago", (object)oContaAPagar.ValorPago ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DataPagamento", (object)oContaAPagar.DataPagamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DataUltimaEdicao", (object)oContaAPagar.DataUltimaEdicao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)oContaAPagar.MotivoCancelamento ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                ok = "Conta a Pagar salva com sucesso!";
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao salvar Conta a Pagar: " + ex.Message;
                MessageBox.Show(ok, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            contasAPagar oContaAPagar = (contasAPagar)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM CONTAS_A_PAGAR " +
                             "WHERE MODELO_COMPRA = @ModeloCompra AND SERIE_COMPRA = @SerieCompra " +
                             "AND NUMERO_NOTA_COMPRA = @NumeroNotaCompra AND ID_FORNECEDOR = @IdFornecedor " +
                             "AND NUMERO_PARCELA = @NumeroParcela";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ModeloCompra", oContaAPagar.ModeloCompra);
                cmd.Parameters.AddWithValue("@SerieCompra", oContaAPagar.SerieCompra);
                cmd.Parameters.AddWithValue("@NumeroNotaCompra", oContaAPagar.NumeroNotaCompra);
                cmd.Parameters.AddWithValue("@IdFornecedor", oContaAPagar.OFornecedor?.Id ?? 0);
                cmd.Parameters.AddWithValue("@NumeroParcela", oContaAPagar.NumeroParcela);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        oContaAPagar.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                        oContaAPagar.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                        oContaAPagar.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                        oContaAPagar.AFormaPagamento = new formaPagamento { Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]) };
                        oContaAPagar.OFornecedor = new fornecedor { Id = Convert.ToInt32(dr["ID_FORNECEDOR"]) };
                        oContaAPagar.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                        oContaAPagar.Situacao = Convert.ToInt32(dr["SITUACAO"]);
                        oContaAPagar.Juros = Convert.ToDecimal(dr["JUROS"]);
                        oContaAPagar.Multa = Convert.ToDecimal(dr["MULTA"]);
                        oContaAPagar.Desconto = Convert.ToDecimal(dr["DESCONTO"]);
                        oContaAPagar.ValorPago = dr.IsDBNull(dr.GetOrdinal("VALOR_PAGO")) ? (decimal?)null : Convert.ToDecimal(dr["VALOR_PAGO"]);
                        oContaAPagar.DataPagamento = dr.IsDBNull(dr.GetOrdinal("DATA_PAGAMENTO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                        oContaAPagar.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                        oContaAPagar.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                        oContaAPagar.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();
                    }
                    else
                    {
                        ok = "Conta a Pagar não encontrada.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao carregar Conta a Pagar: " + ex.Message;
                MessageBox.Show(ok, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public override string Excluir(object obj)
        {
            contasAPagar oContaAPagar = (contasAPagar)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "UPDATE CONTAS_A_PAGAR SET " +
                             "ATIVO = FALSE, " +
                             "MOTIVO_CANCELAMENTO = @MotivoCancelamento, " +
                             "DATA_ULTIMA_EDICAO = CURRENT_TIMESTAMP " +
                             "WHERE MODELO_COMPRA = @ModeloCompra AND SERIE_COMPRA = @SerieCompra " +
                             "AND NUMERO_NOTA_COMPRA = @NumeroNotaCompra AND ID_FORNECEDOR = @IdFornecedor " +
                             "AND NUMERO_PARCELA = @NumeroParcela";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)oContaAPagar.MotivoCancelamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ModeloCompra", oContaAPagar.ModeloCompra);
                cmd.Parameters.AddWithValue("@SerieCompra", oContaAPagar.SerieCompra);
                cmd.Parameters.AddWithValue("@NumeroNotaCompra", oContaAPagar.NumeroNotaCompra);
                cmd.Parameters.AddWithValue("@IdFornecedor", oContaAPagar.OFornecedor.Id);
                cmd.Parameters.AddWithValue("@NumeroParcela", oContaAPagar.NumeroParcela);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    ok = "Conta a Pagar cancelada com sucesso!";
                }
                else
                {
                    ok = "Nenhuma Conta a Pagar encontrada para cancelar com os dados fornecidos.";
                }
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao cancelar Conta a Pagar: " + ex.Message;
                MessageBox.Show(ok, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public List<contasAPagar> ListarContasAPagar()
        {
            List<contasAPagar> lista = new List<contasAPagar>();
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM CONTAS_A_PAGAR";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contasAPagar conta = new contasAPagar();
                        conta.ModeloCompra = Convert.ToInt32(dr["MODELO_COMPRA"]);
                        conta.SerieCompra = dr["SERIE_COMPRA"].ToString();
                        conta.NumeroNotaCompra = dr["NUMERO_NOTA_COMPRA"].ToString();
                        conta.OFornecedor.Id = Convert.ToInt32(dr["ID_FORNECEDOR"]);
                        conta.NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]);
                        conta.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                        conta.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                        conta.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                        conta.AFormaPagamento = new formaPagamento { Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]) };
                        conta.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                        conta.Situacao = Convert.ToInt32(dr["SITUACAO"]);
                        conta.Juros = Convert.ToDecimal(dr["JUROS"]);
                        conta.Multa = Convert.ToDecimal(dr["MULTA"]);
                        conta.Desconto = Convert.ToDecimal(dr["DESCONTO"]);
                        conta.ValorPago = dr.IsDBNull(dr.GetOrdinal("VALOR_PAGO")) ? (decimal?)null : Convert.ToDecimal(dr["VALOR_PAGO"]);
                        conta.DataPagamento = dr.IsDBNull(dr.GetOrdinal("DATA_PAGAMENTO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                        conta.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                        conta.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                        conta.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();

                        lista.Add(conta);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao listar Contas a Pagar: " + ex.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return lista;
        }
    }
}
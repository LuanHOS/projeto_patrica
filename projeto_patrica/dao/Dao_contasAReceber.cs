using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.dao
{
    class Dao_contasAReceber : Dao
    {
        public Dao_contasAReceber()
        {
        }

        public override string Salvar(object obj)
        {
            contasAReceber oContaAReceber = (contasAReceber)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();

                string sql = "UPDATE CONTAS_A_RECEBER SET " +
                      "DATA_EMISSAO = @DataEmissao, DATA_VENCIMENTO = @DataVencimento, VALOR_PARCELA = @ValorParcela, " +
                      "ID_FORMA_PAGAMENTO = @IdFormaPagamento, ATIVO = @Ativo, SITUACAO = @Situacao, " +
                      "JUROS = @Juros, MULTA = @Multa, DESCONTO = @Desconto, " +
                      "VALOR_PAGO = @ValorPago, DATA_PAGAMENTO = @DataPagamento, " +
                      "DATA_ULTIMA_EDICAO = @DataUltimaEdicao, MOTIVO_CANCELAMENTO = @MotivoCancelamento, " +
                      "JUROS_VALOR = @JurosValor, MULTA_VALOR = @MultaValor, DESCONTO_VALOR = @DescontoValor " +
                      "WHERE MODELO_VENDA = @ModeloVenda AND SERIE_VENDA = @SerieVenda " +
                      "AND NUMERO_NOTA_VENDA = @NumeroNotaVenda AND ID_CLIENTE = @IdCliente " +
                      "AND NUMERO_PARCELA = @NumeroParcela";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ModeloVenda", oContaAReceber.ModeloVenda);
                cmd.Parameters.AddWithValue("@SerieVenda", oContaAReceber.SerieVenda);
                cmd.Parameters.AddWithValue("@NumeroNotaVenda", oContaAReceber.NumeroNotaVenda);
                cmd.Parameters.AddWithValue("@IdCliente", oContaAReceber.OCliente.Id);
                cmd.Parameters.AddWithValue("@NumeroParcela", oContaAReceber.NumeroParcela);
                cmd.Parameters.AddWithValue("@DataEmissao", oContaAReceber.DataEmissao);
                cmd.Parameters.AddWithValue("@DataVencimento", oContaAReceber.DataVencimento);
                cmd.Parameters.AddWithValue("@ValorParcela", oContaAReceber.ValorParcela);
                cmd.Parameters.AddWithValue("@IdFormaPagamento", oContaAReceber.AFormaPagamento.Id);
                cmd.Parameters.AddWithValue("@Ativo", oContaAReceber.Ativo);
                cmd.Parameters.AddWithValue("@Situacao", oContaAReceber.Situacao);
                cmd.Parameters.AddWithValue("@Juros", oContaAReceber.Juros);
                cmd.Parameters.AddWithValue("@Multa", oContaAReceber.Multa);
                cmd.Parameters.AddWithValue("@Desconto", oContaAReceber.Desconto);
                cmd.Parameters.AddWithValue("@ValorPago", (object)oContaAReceber.ValorPago ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@JurosValor", (object)oContaAReceber.JurosValor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MultaValor", (object)oContaAReceber.MultaValor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DescontoValor", (object)oContaAReceber.DescontoValor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DataPagamento", (object)oContaAReceber.DataPagamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DataUltimaEdicao", (object)oContaAReceber.DataUltimaEdicao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)oContaAReceber.MotivoCancelamento ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                ok = "Conta a Receber salva com sucesso!";
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            contasAReceber oContaAReceber = (contasAReceber)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM CONTAS_A_RECEBER " +
                             "WHERE MODELO_VENDA = @ModeloVenda AND SERIE_VENDA = @SerieVenda " +
                             "AND NUMERO_NOTA_VENDA = @NumeroNotaVenda AND ID_CLIENTE = @IdCliente " +
                             "AND NUMERO_PARCELA = @NumeroParcela";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ModeloVenda", oContaAReceber.ModeloVenda);
                cmd.Parameters.AddWithValue("@SerieVenda", oContaAReceber.SerieVenda);
                cmd.Parameters.AddWithValue("@NumeroNotaVenda", oContaAReceber.NumeroNotaVenda);
                cmd.Parameters.AddWithValue("@IdCliente", oContaAReceber.OCliente?.Id ?? 0);
                cmd.Parameters.AddWithValue("@NumeroParcela", oContaAReceber.NumeroParcela);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        oContaAReceber.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                        oContaAReceber.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                        oContaAReceber.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                        oContaAReceber.AFormaPagamento = new formaPagamento { Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]) };
                        oContaAReceber.OCliente = new cliente { Id = Convert.ToInt32(dr["ID_CLIENTE"]) };
                        oContaAReceber.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                        oContaAReceber.Situacao = Convert.ToInt32(dr["SITUACAO"]);
                        oContaAReceber.Juros = Convert.ToDecimal(dr["JUROS"]);
                        oContaAReceber.Multa = Convert.ToDecimal(dr["MULTA"]);
                        oContaAReceber.Desconto = Convert.ToDecimal(dr["DESCONTO"]);
                        oContaAReceber.ValorPago = dr.IsDBNull(dr.GetOrdinal("VALOR_PAGO")) ? (decimal?)null : Convert.ToDecimal(dr["VALOR_PAGO"]);
                        oContaAReceber.JurosValor = dr.IsDBNull(dr.GetOrdinal("JUROS_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["JUROS_VALOR"]);
                        oContaAReceber.MultaValor = dr.IsDBNull(dr.GetOrdinal("MULTA_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["MULTA_VALOR"]);
                        oContaAReceber.DescontoValor = dr.IsDBNull(dr.GetOrdinal("DESCONTO_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["DESCONTO_VALOR"]);
                        oContaAReceber.DataPagamento = dr.IsDBNull(dr.GetOrdinal("DATA_PAGAMENTO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                        oContaAReceber.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                        oContaAReceber.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                        oContaAReceber.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();
                    }
                    else
                    {
                        ok = "Conta a Receber não encontrada.";
                    }
                }
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao carregar Conta a Receber: " + ex.Message;
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
            contasAReceber oContaAReceber = (contasAReceber)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "UPDATE CONTAS_A_RECEBER SET " +
                             "ATIVO = FALSE, " +
                             "MOTIVO_CANCELAMENTO = @MotivoCancelamento, " +
                             "DATA_ULTIMA_EDICAO = CURRENT_TIMESTAMP " +
                             "WHERE MODELO_VENDA = @ModeloVenda AND SERIE_VENDA = @SerieVenda " +
                             "AND NUMERO_NOTA_VENDA = @NumeroNotaVenda AND ID_CLIENTE = @IdCliente " +
                             "AND NUMERO_PARCELA = @NumeroParcela";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)oContaAReceber.MotivoCancelamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ModeloVenda", oContaAReceber.ModeloVenda);
                cmd.Parameters.AddWithValue("@SerieVenda", oContaAReceber.SerieVenda);
                cmd.Parameters.AddWithValue("@NumeroNotaVenda", oContaAReceber.NumeroNotaVenda);
                cmd.Parameters.AddWithValue("@IdCliente", oContaAReceber.OCliente.Id);
                cmd.Parameters.AddWithValue("@NumeroParcela", oContaAReceber.NumeroParcela);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    ok = "Conta a Receber cancelada com sucesso!";
                }
                else
                {
                    ok = "Nenhuma Conta a Receber encontrada para cancelar com os dados fornecidos.";
                }
            }
            catch (MySqlException ex)
            {
                ok = "Erro ao cancelar Conta a Receber: " + ex.Message;
                MessageBox.Show(ok, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        public List<contasAReceber> ListarContasAReceber()
        {
            List<contasAReceber> lista = new List<contasAReceber>();
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM CONTAS_A_RECEBER";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contasAReceber conta = new contasAReceber();
                        conta.ModeloVenda = Convert.ToInt32(dr["MODELO_VENDA"]);
                        conta.SerieVenda = dr["SERIE_VENDA"].ToString();
                        conta.NumeroNotaVenda = Convert.ToInt32(dr["NUMERO_NOTA_VENDA"]);
                        conta.OCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
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
                        conta.JurosValor = dr.IsDBNull(dr.GetOrdinal("JUROS_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["JUROS_VALOR"]);
                        conta.MultaValor = dr.IsDBNull(dr.GetOrdinal("MULTA_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["MULTA_VALOR"]);
                        conta.DescontoValor = dr.IsDBNull(dr.GetOrdinal("DESCONTO_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["DESCONTO_VALOR"]);
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
                MessageBox.Show("Erro ao listar Contas a Receber: " + ex.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return lista;
        }
    }
}
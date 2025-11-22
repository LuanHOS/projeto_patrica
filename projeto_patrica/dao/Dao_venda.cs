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
    class Dao_venda : Dao
    {
        public Dao_venda()
        {
        }

        public bool VerificarVendaExistente(int modelo, string serie, int numeroNota, int idCliente)
        {
            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "SELECT COUNT(*) FROM VENDA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota AND ID_CLIENTE = @IdCliente";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Serie", serie);
                cmd.Parameters.AddWithValue("@NumeroNota", numeroNota);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }


        public override string Salvar(object obj)
        {
            venda aVenda = (venda)obj;
            string ok = "";
            MySqlConnection conn = null;
            MySqlTransaction trans = null;
            bool existe = false;

            try
            {
                conn = Banco.Abrir();
                trans = conn.BeginTransaction();

                if (aVenda.NumeroNota == 0)
                {
                    string sqlGenNum = "SELECT IFNULL(MAX(NUMERO_NOTA), 0) + 1 FROM VENDA WHERE MODELO = @Modelo AND SERIE = @Serie";
                    MySqlCommand cmdGenNum = new MySqlCommand(sqlGenNum, conn, trans);
                    cmdGenNum.Parameters.AddWithValue("@Modelo", aVenda.Modelo);
                    cmdGenNum.Parameters.AddWithValue("@Serie", aVenda.Serie);
                    aVenda.NumeroNota = Convert.ToInt32(cmdGenNum.ExecuteScalar());
                    existe = false;
                }
                else
                {
                    existe = true;
                }

                string sql;
                if (!existe)
                {
                    sql = "INSERT INTO VENDA (MODELO, SERIE, NUMERO_NOTA, ID_CLIENTE, ID_FUNCIONARIO, DATA_EMISSAO, ID_CONDICAO_PAGAMENTO, MOTIVO_CANCELAMENTO, ATIVO, DATA_ULTIMA_EDICAO) " +
                          "VALUES (@Modelo, @Serie, @NumeroNota, @IdCliente, @IdFuncionario, @DataEmissao, @IdCondicaoPagamento, @MotivoCancelamento, @Ativo, @DataUltimaEdicao)";
                }
                else
                {
                    sql = "UPDATE VENDA SET " +
                          "DATA_EMISSAO = @DataEmissao, " +
                          "ID_FUNCIONARIO = @IdFuncionario, " +
                          "ID_CONDICAO_PAGAMENTO = @IdCondicaoPagamento, " +
                          "MOTIVO_CANCELAMENTO = @MotivoCancelamento, " +
                          "ATIVO = @Ativo, " +
                          "DATA_ULTIMA_EDICAO = @DataUltimaEdicao " +
                          "WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota AND ID_CLIENTE = @IdCliente";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Modelo", aVenda.Modelo);
                cmd.Parameters.AddWithValue("@Serie", aVenda.Serie);
                cmd.Parameters.AddWithValue("@NumeroNota", aVenda.NumeroNota);
                cmd.Parameters.AddWithValue("@IdCliente", aVenda.OCliente.Id);
                cmd.Parameters.AddWithValue("@IdFuncionario", aVenda.OFuncionario.Id);
                cmd.Parameters.AddWithValue("@DataEmissao", aVenda.DataEmissao);
                cmd.Parameters.AddWithValue("@IdCondicaoPagamento", aVenda.ACondicaoPagamento.Id);
                cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)aVenda.MotivoCancelamento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ativo", aVenda.Ativo);
                cmd.Parameters.AddWithValue("@DataUltimaEdicao", aVenda.Ativo ? (object)DBNull.Value : DateTime.Now);

                cmd.ExecuteNonQuery();

                if (aVenda.Ativo)
                {
                    if (existe)
                    {
                        List<itemVenda> itensAntigos = ListarItensDaVenda(aVenda, conn, trans);
                        foreach (itemVenda itemAntigo in itensAntigos)
                        {
                            ReverterAtualizacaoProduto(itemAntigo, conn, trans);
                        }

                        cmd.Parameters.Clear();
                        cmd.CommandText = "DELETE FROM ITEM_VENDA WHERE MODELO_VENDA = @Modelo AND SERIE_VENDA = @Serie AND NUMERO_NOTA_VENDA = @NumeroNota AND ID_CLIENTE = @IdCliente";
                        cmd.Parameters.AddWithValue("@Modelo", aVenda.Modelo);
                        cmd.Parameters.AddWithValue("@Serie", aVenda.Serie);
                        cmd.Parameters.AddWithValue("@NumeroNota", aVenda.NumeroNota);
                        cmd.Parameters.AddWithValue("@IdCliente", aVenda.OCliente.Id);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "DELETE FROM CONTAS_A_RECEBER WHERE MODELO_VENDA = @Modelo AND SERIE_VENDA = @Serie AND NUMERO_NOTA_VENDA = @NumeroNota AND ID_CLIENTE = @IdCliente";
                        cmd.ExecuteNonQuery();
                    }

                    foreach (itemVenda item in aVenda.Itens)
                    {
                        item.ModeloVenda = aVenda.Modelo;
                        item.SerieVenda = aVenda.Serie;
                        item.NumeroNotaVenda = aVenda.NumeroNota;
                        item.IdCliente = aVenda.OCliente.Id;
                        SalvarItem(item, conn, trans);
                        AtualizarProduto(item, conn, trans);
                    }

                    Controller_condicaoPagamento ccp = new Controller_condicaoPagamento();
                    ccp.CarregaObj(aVenda.ACondicaoPagamento);

                    foreach (contasAReceber conta in aVenda.Parcelas)
                    {
                        conta.ModeloVenda = aVenda.Modelo;
                        conta.SerieVenda = aVenda.Serie;
                        conta.NumeroNotaVenda = aVenda.NumeroNota;
                        conta.OCliente = aVenda.OCliente;
                        conta.Juros = aVenda.ACondicaoPagamento.Juros;
                        conta.Multa = aVenda.ACondicaoPagamento.Multa;
                        conta.Desconto = aVenda.ACondicaoPagamento.Desconto;
                        conta.JurosValor = null;
                        conta.MultaValor = null;
                        conta.DescontoValor = null;
                        conta.Situacao = 0;
                        conta.ValorPago = null;
                        conta.DataPagamento = null;
                        conta.Ativo = true;
                        conta.MotivoCancelamento = null;
                        conta.DataUltimaEdicao = null;
                        SalvarContaAReceber(conta, conn, trans);
                    }
                }
                else
                {
                    foreach (itemVenda item in aVenda.Itens)
                    {
                        ReverterAtualizacaoProduto(item, conn, trans);
                    }
                }

                trans.Commit();
                ok = "Venda salva com sucesso!";
            }
            catch (Exception ex)
            {
                trans?.Rollback();
                throw;
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }

        private void AtualizarProduto(itemVenda item, MySqlConnection conn, MySqlTransaction trans)
        {
            string sqlSelect = "SELECT ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @IdProduto";
            MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn, trans);
            cmdSelect.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);

            using (var reader = cmdSelect.ExecuteReader())
            {
                if (reader.Read())
                {
                    int estoqueAtual = reader.GetInt32("ESTOQUE");
                    reader.Close();

                    string sqlUpdate = "UPDATE PRODUTO SET ESTOQUE = @NovoEstoque WHERE ID_PRODUTO = @IdProduto";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@NovoEstoque", estoqueAtual - item.Quantidade);
                    cmdUpdate.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                }
            }
        }

        private void ReverterAtualizacaoProduto(itemVenda item, MySqlConnection conn, MySqlTransaction trans)
        {
            string sqlSelect = "SELECT ESTOQUE FROM PRODUTO WHERE ID_PRODUTO = @IdProduto";
            MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn, trans);
            cmdSelect.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);

            using (var reader = cmdSelect.ExecuteReader())
            {
                if (reader.Read())
                {
                    int estoqueAtual = reader.GetInt32("ESTOQUE");
                    reader.Close();

                    int novoEstoque = estoqueAtual + item.Quantidade;

                    string sqlUpdate = "UPDATE PRODUTO SET ESTOQUE = @NovoEstoque WHERE ID_PRODUTO = @IdProduto";
                    MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@NovoEstoque", novoEstoque);
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
            return "Operação de cancelamento realizada via Salvar.";
        }

        public override string CarregaObj(object obj)
        {
            venda aVenda = (venda)obj;
            string ok = "";
            MySqlConnection conn = null;

            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM VENDA WHERE MODELO = @Modelo AND SERIE = @Serie AND NUMERO_NOTA = @NumeroNota AND ID_CLIENTE = @IdCliente";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Modelo", aVenda.Modelo);
                cmd.Parameters.AddWithValue("@Serie", aVenda.Serie);
                cmd.Parameters.AddWithValue("@NumeroNota", aVenda.NumeroNota);
                cmd.Parameters.AddWithValue("@IdCliente", aVenda.OCliente.Id);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        aVenda.Modelo = Convert.ToInt32(dr["MODELO"]);
                        aVenda.Serie = dr["SERIE"].ToString();
                        aVenda.NumeroNota = Convert.ToInt32(dr["NUMERO_NOTA"]);
                        aVenda.OCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
                        aVenda.OFuncionario.Id = Convert.ToInt32(dr["ID_FUNCIONARIO"]);
                        aVenda.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                        aVenda.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                        aVenda.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();
                        aVenda.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                        aVenda.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                        aVenda.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                    }
                }

                Controller_cliente cc = new Controller_cliente();
                cc.CarregaObj(aVenda.OCliente);

                Controller_funcionario cf = new Controller_funcionario();
                cf.CarregaObj(aVenda.OFuncionario);

                Controller_condicaoPagamento ccp = new Controller_condicaoPagamento();
                ccp.CarregaObj(aVenda.ACondicaoPagamento);

                aVenda.Itens = ListarItensDaVenda(aVenda, conn, null);
                aVenda.Parcelas = ListarContasAReceberDaVenda(aVenda, conn, null);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn?.Close();
            }
            return ok;
        }


        public List<venda> ListarVendas()
        {
            List<venda> lista = new List<venda>();
            MySqlConnection conn = null;
            try
            {
                conn = Banco.Abrir();
                string sql = "SELECT * FROM VENDA";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    venda aVenda = new venda();
                    aVenda.Modelo = Convert.ToInt32(dr["MODELO"]);
                    aVenda.Serie = dr["SERIE"].ToString();
                    aVenda.NumeroNota = Convert.ToInt32(dr["NUMERO_NOTA"]);
                    aVenda.OCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
                    aVenda.OFuncionario.Id = Convert.ToInt32(dr["ID_FUNCIONARIO"]);
                    aVenda.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                    aVenda.ACondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                    aVenda.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();
                    aVenda.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    aVenda.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    aVenda.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);

                    lista.Add(aVenda);
                }
                dr.Close();

                Controller_cliente cc = new Controller_cliente();
                Controller_funcionario cf = new Controller_funcionario();
                Controller_condicaoPagamento ccp = new Controller_condicaoPagamento();
                foreach (var venda in lista)
                {
                    cc.CarregaObj(venda.OCliente);
                    cf.CarregaObj(venda.OFuncionario);
                    ccp.CarregaObj(venda.ACondicaoPagamento);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar vendas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn?.Close();
            }
            return lista;
        }


        private void SalvarItem(itemVenda item, MySqlConnection conn, MySqlTransaction trans)
        {
            string sql = "INSERT INTO ITEM_VENDA (MODELO_VENDA, SERIE_VENDA, NUMERO_NOTA_VENDA, ID_CLIENTE, ID_PRODUTO, QUANTIDADE, VALOR_UNITARIO) VALUES " +
                         "(@ModeloVenda, @SerieVenda, @NumeroNotaVenda, @IdCliente, @IdProduto, @Quantidade, @ValorUnitario)";
            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@ModeloVenda", item.ModeloVenda);
            cmd.Parameters.AddWithValue("@SerieVenda", item.SerieVenda);
            cmd.Parameters.AddWithValue("@NumeroNotaVenda", item.NumeroNotaVenda);
            cmd.Parameters.AddWithValue("@IdCliente", item.IdCliente);
            cmd.Parameters.AddWithValue("@IdProduto", item.OProduto.Id);
            cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            cmd.Parameters.AddWithValue("@ValorUnitario", item.ValorUnitario);
            cmd.ExecuteNonQuery();
        }

        private void SalvarContaAReceber(contasAReceber conta, MySqlConnection conn, MySqlTransaction trans)
        {
            string sql = "INSERT INTO CONTAS_A_RECEBER (MODELO_VENDA, SERIE_VENDA, NUMERO_NOTA_VENDA, ID_CLIENTE, NUMERO_PARCELA, " +
                         "DATA_EMISSAO, DATA_VENCIMENTO, VALOR_PARCELA, ID_FORMA_PAGAMENTO, ATIVO, " +
                         "SITUACAO, JUROS, MULTA, DESCONTO, VALOR_PAGO, DATA_PAGAMENTO, DATA_ULTIMA_EDICAO, MOTIVO_CANCELAMENTO, " +
                         "JUROS_VALOR, MULTA_VALOR, DESCONTO_VALOR) VALUES " +
                         "(@ModeloVenda, @SerieVenda, @NumeroNotaVenda, @IdCliente, @NumeroParcela, " +
                         "@DataEmissao, @DataVencimento, @ValorParcela, @IdFormaPagamento, @Ativo, " +
                         "@Situacao, @Juros, @Multa, @Desconto, @ValorPago, @DataPagamento, @DataUltimaEdicao, @MotivoCancelamento, " +
                         "@JurosValor, @MultaValor, @DescontoValor)";

            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@ModeloVenda", conta.ModeloVenda);
            cmd.Parameters.AddWithValue("@SerieVenda", conta.SerieVenda);
            cmd.Parameters.AddWithValue("@NumeroNotaVenda", conta.NumeroNotaVenda);
            cmd.Parameters.AddWithValue("@IdCliente", conta.OCliente.Id);
            cmd.Parameters.AddWithValue("@NumeroParcela", conta.NumeroParcela);
            cmd.Parameters.AddWithValue("@DataEmissao", conta.DataEmissao);
            cmd.Parameters.AddWithValue("@DataVencimento", conta.DataVencimento);
            cmd.Parameters.AddWithValue("@ValorParcela", conta.ValorParcela);
            cmd.Parameters.AddWithValue("@IdFormaPagamento", conta.AFormaPagamento.Id);
            cmd.Parameters.AddWithValue("@Ativo", conta.Ativo);
            cmd.Parameters.AddWithValue("@Situacao", conta.Situacao);
            cmd.Parameters.AddWithValue("@Juros", conta.Juros);
            cmd.Parameters.AddWithValue("@Multa", conta.Multa);
            cmd.Parameters.AddWithValue("@Desconto", conta.Desconto);
            cmd.Parameters.AddWithValue("@ValorPago", (object)conta.ValorPago ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@JurosValor", (object)conta.JurosValor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MultaValor", (object)conta.MultaValor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DescontoValor", (object)conta.DescontoValor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DataPagamento", (object)conta.DataPagamento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DataUltimaEdicao", (object)conta.DataUltimaEdicao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MotivoCancelamento", (object)conta.MotivoCancelamento ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }


        private List<itemVenda> ListarItensDaVenda(venda aVenda, MySqlConnection conn, MySqlTransaction trans)
        {
            List<itemVenda> itens = new List<itemVenda>();
            string sql = "SELECT * FROM ITEM_VENDA WHERE MODELO_VENDA = @Modelo AND SERIE_VENDA = @Serie AND NUMERO_NOTA_VENDA = @NumeroNota AND ID_CLIENTE = @IdCliente";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.Parameters.AddWithValue("@Modelo", aVenda.Modelo);
            cmd.Parameters.AddWithValue("@Serie", aVenda.Serie);
            cmd.Parameters.AddWithValue("@NumeroNota", aVenda.NumeroNota);
            cmd.Parameters.AddWithValue("@IdCliente", aVenda.OCliente.Id);

            bool closeReader = false;
            MySqlDataReader dr = null;
            try
            {
                dr = cmd.ExecuteReader();
                closeReader = true;

                while (dr.Read())
                {
                    itemVenda item = new itemVenda();
                    item.ModeloVenda = aVenda.Modelo;
                    item.SerieVenda = aVenda.Serie;
                    item.NumeroNotaVenda = aVenda.NumeroNota;
                    item.IdCliente = aVenda.OCliente.Id;
                    item.OProduto = new produto { Id = Convert.ToInt32(dr["ID_PRODUTO"]) };
                    item.Quantidade = Convert.ToInt32(dr["QUANTIDADE"]);
                    item.ValorUnitario = Convert.ToDecimal(dr["VALOR_UNITARIO"]);
                    itens.Add(item);
                }
            }
            finally
            {
                if (closeReader && dr != null)
                {
                    dr.Close();
                }
            }


            Controller_produto cp = new Controller_produto();
            foreach (var item in itens)
            {
                cp.CarregaObj(item.OProduto);
            }
            return itens;
        }


        private List<contasAReceber> ListarContasAReceberDaVenda(venda aVenda, MySqlConnection conn, MySqlTransaction trans)
        {
            List<contasAReceber> parcelas = new List<contasAReceber>();
            string sql = "SELECT * FROM CONTAS_A_RECEBER WHERE MODELO_VENDA = @Modelo AND SERIE_VENDA = @Serie AND NUMERO_NOTA_VENDA = @NumeroNota AND ID_CLIENTE = @IdCliente";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.Parameters.AddWithValue("@Modelo", aVenda.Modelo);
            cmd.Parameters.AddWithValue("@Serie", aVenda.Serie);
            cmd.Parameters.AddWithValue("@NumeroNota", aVenda.NumeroNota);
            cmd.Parameters.AddWithValue("@IdCliente", aVenda.OCliente.Id);

            bool closeReader = false;
            MySqlDataReader dr = null;
            try
            {
                dr = cmd.ExecuteReader();
                closeReader = true;

                while (dr.Read())
                {
                    contasAReceber parcela = new contasAReceber();
                    parcela.ModeloVenda = aVenda.Modelo;
                    parcela.SerieVenda = aVenda.Serie;
                    parcela.NumeroNotaVenda = aVenda.NumeroNota;
                    parcela.OCliente.Id = Convert.ToInt32(dr["ID_CLIENTE"]);
                    parcela.NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]);
                    parcela.DataEmissao = Convert.ToDateTime(dr["DATA_EMISSAO"]);
                    parcela.DataVencimento = Convert.ToDateTime(dr["DATA_VENCIMENTO"]);
                    parcela.ValorParcela = Convert.ToDecimal(dr["VALOR_PARCELA"]);
                    parcela.AFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                    parcela.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                    parcela.Situacao = Convert.ToInt32(dr["SITUACAO"]);
                    parcela.Juros = Convert.ToDecimal(dr["JUROS"]);
                    parcela.Multa = Convert.ToDecimal(dr["MULTA"]);
                    parcela.Desconto = Convert.ToDecimal(dr["DESCONTO"]);
                    parcela.ValorPago = dr.IsDBNull(dr.GetOrdinal("VALOR_PAGO")) ? (decimal?)null : Convert.ToDecimal(dr["VALOR_PAGO"]);
                    parcela.JurosValor = dr.IsDBNull(dr.GetOrdinal("JUROS_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["JUROS_VALOR"]);
                    parcela.MultaValor = dr.IsDBNull(dr.GetOrdinal("MULTA_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["MULTA_VALOR"]);
                    parcela.DescontoValor = dr.IsDBNull(dr.GetOrdinal("DESCONTO_VALOR")) ? (decimal?)null : Convert.ToDecimal(dr["DESCONTO_VALOR"]);
                    parcela.DataPagamento = dr.IsDBNull(dr.GetOrdinal("DATA_PAGAMENTO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_PAGAMENTO"]);
                    parcela.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                    parcela.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                    parcela.MotivoCancelamento = dr.IsDBNull(dr.GetOrdinal("MOTIVO_CANCELAMENTO")) ? null : dr["MOTIVO_CANCELAMENTO"].ToString();

                    parcelas.Add(parcela);
                }
            }
            finally
            {
                if (closeReader && dr != null)
                {
                    dr.Close();
                }
            }


            Controller_formaPagamento cfpForLoop = new Controller_formaPagamento();
            Controller_cliente ccForLoop = new Controller_cliente();
            foreach (var p in parcelas)
            {
                cfpForLoop.CarregaObj(p.AFormaPagamento);
                ccForLoop.CarregaObj(p.OCliente);
            }

            return parcelas;
        }

    }
}
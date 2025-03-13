using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using projeto_patrica.classes;

namespace projeto_patrica.dao
{
    internal class Dao_condicaoPagamento : Dao
    {
        public override string Salvar(object obj)
        {
            condicaoPagamento aCondicaoPagamento = (condicaoPagamento)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            using (MySqlConnection conn = Banco.Abrir())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (aCondicaoPagamento.Id == 0)
                {
                    sql = "INSERT INTO CONDICAO_PAGAMENTO (DESCRICAO, QUANTIDADE_PARCELAS) VALUES (@descricao, @qtdParcelas);";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@descricao", aCondicaoPagamento.Descricao);
                    cmd.Parameters.AddWithValue("@qtdParcelas", aCondicaoPagamento.QuantidadeParcelas);
                }
                else
                {
                    operacao = 'U';
                    sql = "UPDATE CONDICAO_PAGAMENTO SET DESCRICAO = @descricao, QUANTIDADE_PARCELAS = @qtdParcelas WHERE ID_CONDICAO_PAGAMENTO = @id;";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@descricao", aCondicaoPagamento.Descricao);
                    cmd.Parameters.AddWithValue("@qtdParcelas", aCondicaoPagamento.QuantidadeParcelas);
                    cmd.Parameters.AddWithValue("@id", aCondicaoPagamento.Id);
                }

                cmd.ExecuteNonQuery();

                if (operacao == 'I')
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    ok = cmd.ExecuteScalar().ToString();
                    aCondicaoPagamento.Id = Convert.ToInt32(ok);
                }

                conn.Close();
            }

            return ok;
        }

        public override string CarregaObj(object obj)
        {
            condicaoPagamento aCondicaoPagamento = (condicaoPagamento)obj;
            string ok = "";

            try
            {
                using (MySqlConnection conn = Banco.Abrir())
                {
                    string sql = "SELECT * FROM CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = @id;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", aCondicaoPagamento.Id);
                    var dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        aCondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                        aCondicaoPagamento.Descricao = dr["DESCRICAO"].ToString();
                        aCondicaoPagamento.QuantidadeParcelas = Convert.ToInt32(dr["QUANTIDADE_PARCELAS"]);
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
            condicaoPagamento aCondicaoPagamento = (condicaoPagamento)obj;
            string ok = "";

            try
            {
                using (MySqlConnection conn = Banco.Abrir())
                {
                    string sql = "DELETE FROM CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = @id;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", aCondicaoPagamento.Id);
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

        public List<condicaoPagamento> ListarCondicaoPagamento()
        {
            List<condicaoPagamento> lista = new List<condicaoPagamento>();

            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "SELECT * FROM CONDICAO_PAGAMENTO;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new condicaoPagamento
                    {
                        Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]),
                        Descricao = dr["DESCRICAO"].ToString(),
                        QuantidadeParcelas = Convert.ToInt32(dr["QUANTIDADE_PARCELAS"])
                    });
                }

                conn.Close();
            }

            return lista;
        }

        public string SalvarParcela(parcelaCondicaoPagamento parcela)
        {
            string ok = "";

            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "INSERT INTO PARCELA_CONDICAO_PAGAMENTO (ID_CONDICAO_PAGAMENTO, NUMERO_PARCELA, ID_FORMA_PAGAMENTO, VALOR_PERCENTUAL, DIAS_APOS_VENDA) " +
                             "VALUES (@codCondPagto, @numeroParcela, @codFormaPagto, @valorPercentual, @diasAposVenda);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codCondPagto", parcela.CodCondPagto);
                cmd.Parameters.AddWithValue("@numeroParcela", parcela.NumeroParcela);
                cmd.Parameters.AddWithValue("@codFormaPagto", parcela.CodFormaPagto);
                cmd.Parameters.AddWithValue("@valorPercentual", parcela.ValorPercentual);
                cmd.Parameters.AddWithValue("@diasAposVenda", parcela.DiasAposVenda);

                cmd.ExecuteNonQuery();
                conn.Close();

                ok = "Parcela salva com sucesso!";
            }

            return ok;
        }

        public string ExcluirParcela(parcelaCondicaoPagamento parcela)
        {
            string ok = "";

            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "DELETE FROM PARCELA_CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = @codCondPagto AND NUMERO_PARCELA = @numeroParcela;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codCondPagto", parcela.CodCondPagto);
                cmd.Parameters.AddWithValue("@numeroParcela", parcela.NumeroParcela);

                cmd.ExecuteNonQuery();
                conn.Close();

                ok = "Parcela excluída com sucesso!";
            }

            return ok;
        }

        public List<parcelaCondicaoPagamento> ListarParcelas(int codCondPagto)
        {
            List<parcelaCondicaoPagamento> lista = new List<parcelaCondicaoPagamento>();

            using (MySqlConnection conn = Banco.Abrir())
            {
                string sql = "SELECT * FROM PARCELA_CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = @codCondPagto;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codCondPagto", codCondPagto);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new parcelaCondicaoPagamento
                    {
                        CodCondPagto = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]),
                        NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]),
                        CodFormaPagto = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]),
                        ValorPercentual = Convert.ToDecimal(dr["VALOR_PERCENTUAL"]),
                        DiasAposVenda = Convert.ToInt32(dr["DIAS_APOS_VENDA"])
                    });
                }

                conn.Close();
            }

            return lista;
        }
    }
}

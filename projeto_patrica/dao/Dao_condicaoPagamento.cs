﻿using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace projeto_patrica.dao
{
    internal class Dao_condicaoPagamento : Dao
    {
        public Dao_condicaoPagamento()
        {
        }

        public override string Salvar(object obj)
        {
            condicaoPagamento aCondicaoPagamento = (condicaoPagamento)obj;
            string ok = "";
            char operacao = 'I';
            string sql;

            sql = "INSERT INTO CONDICAO_PAGAMENTO (DESCRICAO, QUANTIDADE_PARCELAS, ATIVO, JUROS, MULTA, DESCONTO) VALUES (" +
                  "'" + aCondicaoPagamento.Descricao + "', " +
                  "'" + aCondicaoPagamento.QuantidadeParcelas + "', " +
                  "'" + (aCondicaoPagamento.Ativo ? 1 : 0) + "', " +
                  "'" + aCondicaoPagamento.Juros.ToString().Replace(",", ".") + "', " +
                  "'" + aCondicaoPagamento.Multa.ToString().Replace(",", ".") + "', " +
                  "'" + aCondicaoPagamento.Desconto.ToString().Replace(",", ".") + "')";

            if (aCondicaoPagamento.Id != 0)
            { 
                operacao = 'U';
                sql = "UPDATE CONDICAO_PAGAMENTO SET " +
                      "DESCRICAO = '" + aCondicaoPagamento.Descricao + "', " +
                      "QUANTIDADE_PARCELAS = '" + aCondicaoPagamento.QuantidadeParcelas + "', " +
                      "ATIVO = '" + (aCondicaoPagamento.Ativo ? 1 : 0) + "', " +
                      "JUROS = '" + aCondicaoPagamento.Juros.ToString().Replace(",", ".") + "', " +
                      "MULTA = '" + aCondicaoPagamento.Multa.ToString().Replace(",", ".") + "', " +
                      "DESCONTO = '" + aCondicaoPagamento.Desconto.ToString().Replace(",", ".") + "', " +
                      "DATA_ULTIMA_EDICAO = CURRENT_DATE " +
                      "WHERE ID_CONDICAO_PAGAMENTO = '" + aCondicaoPagamento.Id + "'";
            }

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();

            if (operacao == 'I')
            {
                conn.CommandText = "SELECT @@IDENTITY";
                ok = conn.ExecuteScalar().ToString();
                aCondicaoPagamento.Id = Convert.ToInt32(ok);
            }
            else
            {
                ok = aCondicaoPagamento.Id.ToString();
            }

            foreach (parcelaCondicaoPagamento aParcela in aCondicaoPagamento.Parcelas)
            {
                aParcela.CodCondPagto = aCondicaoPagamento.Id;
                SalvarParcela(aParcela, conn.Connection);
            }

            List<parcelaCondicaoPagamento> parcelasBanco = ListarParcelas(aCondicaoPagamento.Id);

            foreach (parcelaCondicaoPagamento parcelaExistente in parcelasBanco)
            {
                bool existe = false;

                foreach (parcelaCondicaoPagamento novaParcela in aCondicaoPagamento.Parcelas)
                {
                    if (novaParcela.NumeroParcela == parcelaExistente.NumeroParcela)
                    {
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    ExcluirParcela(parcelaExistente);
                }
            }

            conn.Connection.Close();
            return ok;
        }


        public string SalvarParcela(parcelaCondicaoPagamento parcela, MySqlConnection conexaoAberta)
        {
            string sql;
            string ok = "";

            sql = "SELECT COUNT(*) FROM PARCELA_CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = '" + parcela.CodCondPagto + "' AND NUMERO_PARCELA = '" + parcela.NumeroParcela + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conexaoAberta);
            int qtd = Convert.ToInt32(cmd.ExecuteScalar());

            if (qtd > 0)
            {
                sql = "UPDATE PARCELA_CONDICAO_PAGAMENTO SET " +
                      "ID_FORMA_PAGAMENTO = '" + parcela.AFormaPagamento.Id + "', " +
                      "VALOR_PERCENTUAL = '" + parcela.ValorPercentual.ToString().Replace(",", ".") + "', " +
                      "DIAS_APOS_VENDA = '" + parcela.DiasAposVenda + "' " +
                      "WHERE ID_CONDICAO_PAGAMENTO = '" + parcela.CodCondPagto + 
                      "' AND NUMERO_PARCELA = '" + parcela.NumeroParcela + "'";
            }
            else
            {
                sql = "INSERT INTO PARCELA_CONDICAO_PAGAMENTO VALUES (" +
                      "'" + parcela.CodCondPagto + "', " +
                      "'" + parcela.NumeroParcela + "', " +
                      "'" + parcela.AFormaPagamento.Id + "', " +
                      "'" + parcela.ValorPercentual.ToString().Replace(",", ".") + "', " +
                      "'" + parcela.DiasAposVenda + "')";
            }

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            return ok;
        }


        public override string Excluir(object obj)
        {
            condicaoPagamento aCondicaoPagamento = (condicaoPagamento)obj;
            string ok = "";

            string sql = "DELETE FROM CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = '" + aCondicaoPagamento.Id + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();
            conn.Connection.Close();

            ok = "Excluído com sucesso!";
            return ok;
        }

        public override string CarregaObj(object obj)
        {
            condicaoPagamento aCondicaoPagamento = (condicaoPagamento)obj;
            string ok = "";

            string sql = "SELECT * FROM CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = '" + aCondicaoPagamento.Id + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                aCondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                aCondicaoPagamento.Descricao = dr["DESCRICAO"].ToString();
                aCondicaoPagamento.QuantidadeParcelas = Convert.ToInt32(dr["QUANTIDADE_PARCELAS"]);
                aCondicaoPagamento.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                aCondicaoPagamento.Juros = Convert.ToDecimal(dr["JUROS"]);
                aCondicaoPagamento.Multa = Convert.ToDecimal(dr["MULTA"]);
                aCondicaoPagamento.Desconto = Convert.ToDecimal(dr["DESCONTO"]);
                aCondicaoPagamento.DataUltimaEdicao = dr.IsDBNull(dr.GetOrdinal("DATA_ULTIMA_EDICAO")) ? (DateTime?)null : Convert.ToDateTime(dr["DATA_ULTIMA_EDICAO"]);
                aCondicaoPagamento.DataCadastro = Convert.ToDateTime(dr["DATA_CADASTRO"]);
                aCondicaoPagamento.Parcelas = ListarParcelas(aCondicaoPagamento.Id);
            }

            conn.Connection.Close();
            return ok;
        }

        public List<condicaoPagamento> ListarCondicaoPagamento()
        {
            condicaoPagamento aCondicaoPagamento;
            List<condicaoPagamento> lista = new List<condicaoPagamento>();
            string sql = "SELECT * FROM CONDICAO_PAGAMENTO";

            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                aCondicaoPagamento = new condicaoPagamento();
                aCondicaoPagamento.Id = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                aCondicaoPagamento.Descricao = dr["DESCRICAO"].ToString();
                aCondicaoPagamento.QuantidadeParcelas = Convert.ToInt32(dr["QUANTIDADE_PARCELAS"]);
                aCondicaoPagamento.Ativo = Convert.ToBoolean(dr["ATIVO"]);
                lista.Add(aCondicaoPagamento);
            }

            conn.Connection.Close();
            return lista;
        }

        public List<parcelaCondicaoPagamento> ListarParcelas(int idCondicaoPagamento)
        {
            parcelaCondicaoPagamento parcela;
            List<parcelaCondicaoPagamento> lista = new List<parcelaCondicaoPagamento>();

            string sql = "SELECT * FROM PARCELA_CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = '" + idCondicaoPagamento + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            var dr = conn.ExecuteReader();

            while (dr.Read())
            {
                parcela = new parcelaCondicaoPagamento();
                parcela.CodCondPagto = Convert.ToInt32(dr["ID_CONDICAO_PAGAMENTO"]);
                parcela.NumeroParcela = Convert.ToInt32(dr["NUMERO_PARCELA"]);
                parcela.AFormaPagamento.Id = Convert.ToInt32(dr["ID_FORMA_PAGAMENTO"]);
                parcela.ValorPercentual = Convert.ToDecimal(dr["VALOR_PERCENTUAL"]);
                parcela.DiasAposVenda = Convert.ToInt32(dr["DIAS_APOS_VENDA"]);

                lista.Add(parcela);
            }

            conn.Connection.Close();
            return lista;
        }

        public string ExcluirParcela(parcelaCondicaoPagamento parcela)
        {
            string ok = "";

            string sql = "DELETE FROM PARCELA_CONDICAO_PAGAMENTO WHERE ID_CONDICAO_PAGAMENTO = '" + parcela.CodCondPagto + "' AND NUMERO_PARCELA = '" + parcela.NumeroParcela + "'";
            MySqlCommand conn = new MySqlCommand();
            conn.Connection = Banco.Abrir();
            conn.CommandText = sql;
            conn.ExecuteNonQuery();
            conn.Connection.Close();

            return ok;
        }
    }
}

using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaContasAReceber : projeto_patrica.pages.consulta.frmConsulta
    {
        private frmCadastroContasAReceber oFrmCadastroContasAReceber;
        private contasAReceber oContaAReceber;
        private Controller_contasAReceber aController_contasAReceber;
        private List<contasAReceber> listaCompletaContas;

        public frmConsultaContasAReceber()
        {
            InitializeComponent();
            comboBoxFiltroStatus.SelectedIndex = 0;
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroContasAReceber = (frmCadastroContasAReceber)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaAReceber = new contasAReceber();
            aController_contasAReceber = (Controller_contasAReceber)ctrl;
            CarregaLV();
        }

        public override void Incluir()
        {
            if (listV.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum item selecionado. Selecione um registro para dar baixa.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            ListViewItem linhaSelecionada = listV.SelectedItems[0];
            contasAReceber contaSelecionada = (contasAReceber)linhaSelecionada.Tag;

            if (!contaSelecionada.Ativo)
            {
                MessageBox.Show(
                    "Esta conta está cancelada e não pode ser baixada.",
                    "Ação Interrompida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            aController_contasAReceber.CarregaObj(contaSelecionada);

            if (contaSelecionada.Situacao == 1)
            {
                MessageBox.Show(
                    "Esta conta já foi baixada.",
                    "Ação Interrompida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (contaSelecionada.NumeroParcela > 1)
            {
                bool parcelaAnteriorPendente = listaCompletaContas.Any(c =>
                    c.ModeloVenda == contaSelecionada.ModeloVenda &&
                    c.SerieVenda == contaSelecionada.SerieVenda &&
                    c.NumeroNotaVenda == contaSelecionada.NumeroNotaVenda &&
                    c.OCliente.Id == contaSelecionada.OCliente.Id &&
                    c.NumeroParcela < contaSelecionada.NumeroParcela &&
                    c.Situacao == 0 &&
                    c.Ativo == true
                );

                if (parcelaAnteriorPendente)
                {
                    MessageBox.Show(
                        "Não é possível dar baixa nesta parcela.\n\nExistem parcelas anteriores para esta mesma nota de venda que ainda estão em aberto.",
                        "Recebimento Fora de Ordem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            string aux = oFrmCadastroContasAReceber.btnSave.Text;
            oFrmCadastroContasAReceber.btnSave.Text = "Dar Baixa";
            oFrmCadastroContasAReceber.ConhecaObj(contaSelecionada, aController_contasAReceber);
            oFrmCadastroContasAReceber.Carregatxt();
            oFrmCadastroContasAReceber.Desbloqueiatxt();
            oFrmCadastroContasAReceber.ShowDialog();

            oFrmCadastroContasAReceber.btnSave.Text = aux;
            CarregaLV();
        }


        public override void Alterar()
        {
            string aux = oFrmCadastroContasAReceber.btnSave.Text;
            oFrmCadastroContasAReceber.btnSave.Text = "Visualizar";
            base.Alterar();
            aController_contasAReceber.CarregaObj(oContaAReceber);
            oFrmCadastroContasAReceber.ConhecaObj(oContaAReceber, aController_contasAReceber);
            oFrmCadastroContasAReceber.Carregatxt();
            oFrmCadastroContasAReceber.Bloqueiatxt();
            oFrmCadastroContasAReceber.ShowDialog();
            oFrmCadastroContasAReceber.Desbloqueiatxt();

            oFrmCadastroContasAReceber.btnSave.Text = aux;
            CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();

            if (!oContaAReceber.Ativo)
            {
                MessageBox.Show("Esta conta já está cancelada.", "Ação Interrompida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                "Contas vinculadas a uma nota fiscal de venda não podem ser canceladas individualmente.\n\n" +
                "Para cancelar esta conta, acesse a tela de Consulta de Vendas e cancele a nota fiscal inteira.",
                "Ação Interrompida",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listaCompletaContas = aController_contasAReceber.ListaContasAReceber();
            FiltrarEPreencherListView();
        }

        private void FiltrarEPreencherListView()
        {
            listV.Items.Clear();

            IEnumerable<contasAReceber> listaFiltrada =
                listaCompletaContas ?? Enumerable.Empty<contasAReceber>();

            string filtroStatus = comboBoxFiltroStatus.SelectedItem?.ToString() ?? "Todas";

            switch (filtroStatus)
            {
                case "Em Aberto":
                    listaFiltrada = listaFiltrada.Where(c => c.Ativo && c.Situacao == 0)
                                                 .OrderBy(c => c.DataVencimento);
                    break;

                case "Paga":
                    listaFiltrada = listaFiltrada.Where(c => c.Ativo && c.Situacao == 1);
                    break;

                case "Vencida":
                    listaFiltrada = listaFiltrada.Where(c => c.Ativo && c.Situacao == 0 && c.DataVencimento.Date < DateTime.Today)
                                                 .OrderBy(c => c.DataVencimento);
                    break;

                case "Cancelada":
                    listaFiltrada = listaFiltrada.Where(c => !c.Ativo);
                    break;

                case "Todas":
                    break;

                default:
                    break;
            }


            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(termoPesquisa))
            {
                listaFiltrada = listaFiltrada.Where(c =>
                     c.NumeroNotaVenda.ToString().ToUpper().Contains(termoPesquisa) ||
                     (c.OCliente != null && c.OCliente.Nome_razaoSocial != null && c.OCliente.Nome_razaoSocial.ToUpper().Contains(termoPesquisa)) ||
                     c.NumeroParcela.ToString().Contains(termoPesquisa) ||
                     c.OCliente.Id.ToString().Contains(termoPesquisa)
                 );
            }

            foreach (var conta in listaFiltrada)
            {
                ListViewItem item = new ListViewItem(conta.NumeroParcela.ToString());
                item.SubItems.Add(conta.ModeloVenda.ToString());
                item.SubItems.Add(conta.SerieVenda);
                item.SubItems.Add(conta.NumeroNotaVenda.ToString());
                item.SubItems.Add(conta.OCliente.Id.ToString());
                item.SubItems.Add(conta.OCliente.Nome_razaoSocial);
                item.SubItems.Add(conta.ValorParcela.ToString("C2"));
                item.SubItems.Add(conta.AFormaPagamento.Descricao);
                item.SubItems.Add(conta.DataEmissao.ToShortDateString());
                item.SubItems.Add(conta.DataVencimento.ToShortDateString());
                item.SubItems.Add(conta.Ativo ? "" : "CANCELADO");

                item.Tag = conta;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            FiltrarEPreencherListView();
        }

        public override void LimparPesquisa()
        {
            txtCodigo.Clear();
            FiltrarEPreencherListView();
        }

        private void comboBoxFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarEPreencherListView();
        }

        public override void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                contasAReceber contaSelecionada = (contasAReceber)linha.Tag;

                oContaAReceber.ModeloVenda = contaSelecionada.ModeloVenda;
                oContaAReceber.SerieVenda = contaSelecionada.SerieVenda;
                oContaAReceber.NumeroNotaVenda = contaSelecionada.NumeroNotaVenda;
                oContaAReceber.OCliente = contaSelecionada.OCliente;
                oContaAReceber.NumeroParcela = contaSelecionada.NumeroParcela;
                oContaAReceber.Situacao = contaSelecionada.Situacao;
                oContaAReceber.Ativo = contaSelecionada.Ativo;
            }
            else
            {
                oContaAReceber = new contasAReceber();
            }
        }
    }
}
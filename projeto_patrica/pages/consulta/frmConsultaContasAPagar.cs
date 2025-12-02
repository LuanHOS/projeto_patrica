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
    public partial class frmConsultaContasAPagar : projeto_patrica.pages.consulta.frmConsulta
    {
        private frmCadastroContasAPagar oFrmCadastroContasAPagar;
        private contasAPagar oContaAPagar;
        private Controller_contasAPagar aController_contasAPagar;
        private List<contasAPagar> listaCompletaContas;

        public frmConsultaContasAPagar()
        {
            InitializeComponent();
            comboBoxFiltroStatus.SelectedIndex = 0;
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroContasAPagar = (frmCadastroContasAPagar)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaAPagar = new contasAPagar();
            aController_contasAPagar = (Controller_contasAPagar)ctrl;
            CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();

            contasAPagar novaConta = new contasAPagar();

            if (oFrmCadastroContasAPagar == null)
                oFrmCadastroContasAPagar = new frmCadastroContasAPagar();

            oFrmCadastroContasAPagar.ConhecaObj(novaConta, aController_contasAPagar);
            oFrmCadastroContasAPagar.Limpartxt();
            oFrmCadastroContasAPagar.btnSave.Text = "Salvar";
            oFrmCadastroContasAPagar.Desbloqueiatxt();
            oFrmCadastroContasAPagar.ShowDialog();
            CarregaLV();
        }

        private void btnDarBaixa_Click(object sender, EventArgs e)
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
            contasAPagar contaSelecionada = (contasAPagar)linhaSelecionada.Tag;

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

            aController_contasAPagar.CarregaObj(contaSelecionada);

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
                    c.ModeloCompra == contaSelecionada.ModeloCompra &&
                    c.SerieCompra == contaSelecionada.SerieCompra &&
                    c.NumeroNotaCompra == contaSelecionada.NumeroNotaCompra &&
                    c.OFornecedor.Id == contaSelecionada.OFornecedor.Id &&
                    c.NumeroParcela < contaSelecionada.NumeroParcela &&
                    c.Situacao == 0 &&
                    c.Ativo == true
                );

                if (parcelaAnteriorPendente)
                {
                    MessageBox.Show(
                        "Não é possível dar baixa nesta parcela.\n\nExistem parcelas anteriores para esta mesma nota de compra que ainda estão em aberto.",
                        "Pagamento Fora de Ordem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            string aux = oFrmCadastroContasAPagar.btnSave.Text;
            oFrmCadastroContasAPagar.btnSave.Text = "Dar Baixa";
            oFrmCadastroContasAPagar.ConhecaObj(contaSelecionada, aController_contasAPagar);
            oFrmCadastroContasAPagar.Carregatxt();
            oFrmCadastroContasAPagar.Desbloqueiatxt();
            oFrmCadastroContasAPagar.ShowDialog();

            oFrmCadastroContasAPagar.btnSave.Text = aux;
            CarregaLV();
        }


        public override void Alterar()
        {
            string aux = oFrmCadastroContasAPagar.btnSave.Text;
            oFrmCadastroContasAPagar.btnSave.Text = "Visualizar";
            base.Alterar();
            aController_contasAPagar.CarregaObj(oContaAPagar);
            oFrmCadastroContasAPagar.ConhecaObj(oContaAPagar, aController_contasAPagar);
            oFrmCadastroContasAPagar.Carregatxt();
            oFrmCadastroContasAPagar.Bloqueiatxt();
            oFrmCadastroContasAPagar.ShowDialog();
            oFrmCadastroContasAPagar.Desbloqueiatxt();

            oFrmCadastroContasAPagar.btnSave.Text = aux;
            CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();

            if (!oContaAPagar.Ativo)
            {
                MessageBox.Show("Esta conta já está cancelada.", "Ação Interrompida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var daoCompra = new projeto_patrica.dao.Dao_compra();
            bool compraExiste = daoCompra.VerificarCompraExistente(
                oContaAPagar.ModeloCompra,
                oContaAPagar.SerieCompra,
                oContaAPagar.NumeroNotaCompra,
                oContaAPagar.OFornecedor.Id
            );

            if (compraExiste)
            {
                MessageBox.Show(
                    "Contas vinculadas a uma nota fiscal de compra não podem ser canceladas individualmente.\n" +
                    "Cancele a Nota Fiscal de Compra para cancelar esta conta.",
                    "Ação Interrompida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (oContaAPagar.Situacao == 1)
            {
                MessageBox.Show("Não é possível cancelar uma conta que já foi paga.", "Ação Interrompida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string aux = oFrmCadastroContasAPagar.btnSave.Text;
            oFrmCadastroContasAPagar.btnSave.Text = "Cancelar Conta";
            aController_contasAPagar.CarregaObj(oContaAPagar);
            oFrmCadastroContasAPagar.ConhecaObj(oContaAPagar, aController_contasAPagar);
            oFrmCadastroContasAPagar.Carregatxt();
            oFrmCadastroContasAPagar.Bloqueiatxt();
            oFrmCadastroContasAPagar.ShowDialog(this);
            oFrmCadastroContasAPagar.Desbloqueiatxt();

            oFrmCadastroContasAPagar.btnSave.Text = aux;
            CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listaCompletaContas = aController_contasAPagar.ListaContasAPagar();
            FiltrarEPreencherListView();
        }

        private void FiltrarEPreencherListView()
        {
            listV.Items.Clear();

            IEnumerable<contasAPagar> listaFiltrada =
                listaCompletaContas ?? Enumerable.Empty<contasAPagar>();

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
                     c.NumeroNotaCompra.ToUpper().Contains(termoPesquisa) ||
                     (c.OFornecedor != null && c.OFornecedor.Nome_razaoSocial != null && c.OFornecedor.Nome_razaoSocial.ToUpper().Contains(termoPesquisa)) ||
                     c.NumeroParcela.ToString().Contains(termoPesquisa) ||
                     c.OFornecedor.Id.ToString().Contains(termoPesquisa)
                 );
            }

            foreach (var conta in listaFiltrada)
            {
                ListViewItem item = new ListViewItem(conta.NumeroParcela.ToString());
                item.SubItems.Add(conta.ModeloCompra.ToString());
                item.SubItems.Add(conta.SerieCompra);
                item.SubItems.Add(conta.NumeroNotaCompra);
                item.SubItems.Add(conta.OFornecedor.Id.ToString());
                item.SubItems.Add(conta.OFornecedor.Nome_razaoSocial);
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
                contasAPagar contaSelecionada = (contasAPagar)linha.Tag;

                oContaAPagar.ModeloCompra = contaSelecionada.ModeloCompra;
                oContaAPagar.SerieCompra = contaSelecionada.SerieCompra;
                oContaAPagar.NumeroNotaCompra = contaSelecionada.NumeroNotaCompra;
                oContaAPagar.OFornecedor = contaSelecionada.OFornecedor;
                oContaAPagar.NumeroParcela = contaSelecionada.NumeroParcela;
                oContaAPagar.Situacao = contaSelecionada.Situacao;
                oContaAPagar.Ativo = contaSelecionada.Ativo;
            }
            else
            {
                oContaAPagar = new contasAPagar();
            }
        }
    }
}
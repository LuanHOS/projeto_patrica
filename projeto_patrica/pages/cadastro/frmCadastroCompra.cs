using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroCompra : projeto_patrica.pages.cadastro.frmCadastro
    {
        private compra oCompra;
        private Controller_compra aController_compra;

        // Formulários de Consulta
        private frmConsultaFornecedor oFrmConsultaFornecedor;
        private frmConsultaProduto oFrmConsultaProduto;
        private frmConsultaCondicaoPagamento oFrmConsultaCondicaoPagamento;

        // Listas locais para gerenciamento de dados na tela
        private List<itemCompra> listaItens = new List<itemCompra>();
        private List<parcelaCompra> listaParcelas = new List<parcelaCompra>();

        // Controle de edição de item
        private bool editandoItem = false;
        private int indiceItemEditando = -1;
        private produto produtoSelecionado = new produto();

        public frmCadastroCompra()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCompra = (compra)obj;
            aController_compra = (Controller_compra)ctrl;
        }

        public void setConsultaFornecedor(frmConsultaFornecedor consulta)
        {
            oFrmConsultaFornecedor = consulta;
        }

        public void setConsultaProduto(frmConsultaProduto consulta)
        {
            oFrmConsultaProduto = consulta;
        }

        public void setConsultaCondicaoPagamento(frmConsultaCondicaoPagamento consulta)
        {
            oFrmConsultaCondicaoPagamento = consulta;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(txtNumDaNota.Text) ||
                oCompra.OFornecedor == null || oCompra.OFornecedor.Id == 0 ||
                listaItens.Count == 0 ||
                oCompra.ACondicaoPagamento == null || oCompra.ACondicaoPagamento.Id == 0)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios da nota, adicione pelo menos um produto e selecione a condição de pagamento para salvar.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Popula o objeto principal com os dados do formulário
            oCompra.Modelo = Convert.ToInt32(txtCodigo.Text);
            oCompra.Serie = txtSerie.Text;
            oCompra.NumeroNota = txtNumDaNota.Text;
            oCompra.DataEmissao = dtpDataEmissao.Value;
            oCompra.DataEntrega = dtpDataEntrega.Value;
            oCompra.ValorFrete = string.IsNullOrWhiteSpace(txtValorFrete.Text) ? 0 : Convert.ToDecimal(txtValorFrete.Text);
            oCompra.Seguro = string.IsNullOrWhiteSpace(txtSeguro.Text) ? 0 : Convert.ToDecimal(txtSeguro.Text);
            oCompra.Despesas = string.IsNullOrWhiteSpace(txtDespesas.Text) ? 0 : Convert.ToDecimal(txtDespesas.Text);
            oCompra.Ativo = checkBoxAtivo.Checked;
            oCompra.Itens = listaItens;
            oCompra.Parcelas = listaParcelas;
            oCompra.MotivoCancelamento = null; // Preenchido apenas ao cancelar

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    // Lógica de Exclusão
                }
                else
                {
                    aController_compra.Salvar(oCompra);
                    MessageBox.Show("Compra salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar a compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos de Controle do Formulário
        public override void Limpartxt()
        {
            base.Limpartxt();
            txtSerie.Clear();
            txtNumDaNota.Clear();
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            dtpDataEmissao.Value = DateTime.Today;
            dtpDataEntrega.Value = DateTime.Today;
            LimparCamposProduto();
            btnLimparListaProduto_Click(null, null);
            txtValorFrete.Text = "0,00";
            txtSeguro.Text = "0,00";
            txtDespesas.Text = "0,00";
            txtCodCondicaoDePagamento.Clear();
            txtCondicaoDePagamento.Clear();
            btnLimparParcelas_Click(null, null);

            oCompra = new compra();
        }
        #endregion

        #region Gerenciamento de Itens
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (ValidarCamposItem())
            {
                itemCompra item = new itemCompra
                {
                    ModeloCompra = Convert.ToInt32(txtCodigo.Text),
                    SerieCompra = txtSerie.Text,
                    NumeroNotaCompra = txtNumDaNota.Text,
                    OProduto = produtoSelecionado,
                    Quantidade = Convert.ToInt32(txtQuantidade.Text),
                    ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text)
                };

                listaItens.Add(item);
                CarregarItensNaListView();
                LimparCamposProduto();
            }
        }

        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            if (editandoItem) // Salvar edição
            {
                if (ValidarCamposItem())
                {
                    var item = listaItens[indiceItemEditando];
                    item.OProduto = produtoSelecionado;
                    item.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    item.ValorUnitario = Convert.ToDecimal(txtValorUnitario.Text);

                    CarregarItensNaListView();
                    LimparCamposProduto();
                    FinalizarEdicaoItem();
                }
            }
            else // Entrar no modo de edição
            {
                if (listVProdutos.SelectedItems.Count > 0)
                {
                    indiceItemEditando = listVProdutos.SelectedItems[0].Index;
                    var item = listaItens[indiceItemEditando];

                    produtoSelecionado = item.OProduto;
                    txtCodProduto.Text = item.OProduto.Id.ToString();
                    txtProduto.Text = item.OProduto.Nome;
                    txtQuantidade.Text = item.Quantidade.ToString();
                    txtValorUnitario.Text = item.ValorUnitario.ToString("F2");
                    txtTotalProduto.Text = item.ValorTotal.ToString("F2");

                    btnAdicionarProduto.Enabled = false;
                    btnEditarProduto.Text = "Salvar Item";
                    btnRemoverProduto.Text = "Cancelar";
                    editandoItem = true;
                }
                else
                {
                    MessageBox.Show("Selecione um produto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (editandoItem)
            {
                LimparCamposProduto();
                FinalizarEdicaoItem();
            }
            else
            {
                if (listVProdutos.SelectedItems.Count > 0)
                {
                    listaItens.RemoveAt(listVProdutos.SelectedItems[0].Index);
                    CarregarItensNaListView();
                }
                else
                {
                    MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLimparListaProduto_Click(object sender, EventArgs e)
        {
            listaItens.Clear();
            CarregarItensNaListView();
        }
        #endregion

        #region Geração de Parcelas
        private void btnGerarParcelas_Click(object sender, EventArgs e)
        {
            if (oCompra.ACondicaoPagamento == null || oCompra.ACondicaoPagamento.Id == 0)
            {
                MessageBox.Show("Selecione uma condição de pagamento primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalProdutos = listaItens.Sum(item => item.ValorTotal);
            decimal totalCompra = totalProdutos + Convert.ToDecimal(txtValorFrete.Text) + Convert.ToDecimal(txtSeguro.Text) + Convert.ToDecimal(txtDespesas.Text);

            // Lógica para aplicar desconto/juros da condição de pagamento
            totalCompra = totalCompra * (1 - (oCompra.ACondicaoPagamento.Desconto / 100));
            totalCompra = totalCompra * (1 + (oCompra.ACondicaoPagamento.Juros / 100));

            listaParcelas.Clear();
            foreach (var parcelaCondicao in oCompra.ACondicaoPagamento.Parcelas)
            {
                parcelaCompra novaParcela = new parcelaCompra
                {
                    ModeloCompra = Convert.ToInt32(txtCodigo.Text),
                    SerieCompra = txtSerie.Text,
                    NumeroNotaCompra = txtNumDaNota.Text,
                    NumeroParcela = parcelaCondicao.NumeroParcela,
                    DataVencimento = dtpDataEmissao.Value.AddDays(parcelaCondicao.DiasAposVenda),
                    ValorParcela = totalCompra * (parcelaCondicao.ValorPercentual / 100)
                };
                listaParcelas.Add(novaParcela);
            }

            CarregarParcelasNaListView();
        }

        private void btnLimparParcelas_Click(object sender, EventArgs e)
        {
            listaParcelas.Clear();
            CarregarParcelasNaListView();
        }
        #endregion

        #region Métodos de Pesquisa
        private void btnPesquisarFornecedor_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaFornecedor == null) oFrmConsultaFornecedor = new frmConsultaFornecedor();

            fornecedor fornecedorSelecionado = new fornecedor();
            Controller_fornecedor controller = new Controller_fornecedor();

            oFrmConsultaFornecedor.ConhecaObj(fornecedorSelecionado, controller);
            oFrmConsultaFornecedor.ShowDialog();

            if (fornecedorSelecionado.Id != 0)
            {
                oCompra.OFornecedor = fornecedorSelecionado;
                txtCodFornecedor.Text = fornecedorSelecionado.Id.ToString();
                txtFornecedor.Text = fornecedorSelecionado.Nome_razaoSocial;
            }
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaProduto == null) oFrmConsultaProduto = new frmConsultaProduto();

            produto p = new produto();
            Controller_produto controller = new Controller_produto();

            oFrmConsultaProduto.ConhecaObj(p, controller);
            oFrmConsultaProduto.ShowDialog();

            if (p.Id != 0)
            {
                produtoSelecionado = p;
                txtCodProduto.Text = p.Id.ToString();
                txtProduto.Text = p.Nome;
                txtValorUnitario.Text = p.ValorCompra.ToString("F2");
                txtQuantidade.Text = "1";
                txtTotalProduto.Text = p.ValorCompra.ToString("F2");
            }
        }

        private void btnPesquisarCondicaoDePagamento_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCondicaoPagamento == null) oFrmConsultaCondicaoPagamento = new frmConsultaCondicaoPagamento();

            condicaoPagamento condicaoSelecionada = new condicaoPagamento();
            Controller_condicaoPagamento controller = new Controller_condicaoPagamento();

            oFrmConsultaCondicaoPagamento.ConhecaObj(condicaoSelecionada, controller);
            oFrmConsultaCondicaoPagamento.ShowDialog();

            if (condicaoSelecionada.Id != 0)
            {
                controller.CarregaObj(condicaoSelecionada); // Carrega as parcelas da condição
                oCompra.ACondicaoPagamento = condicaoSelecionada;
                txtCodCondicaoDePagamento.Text = condicaoSelecionada.Id.ToString();
                txtCondicaoDePagamento.Text = condicaoSelecionada.Descricao;
            }
        }
        #endregion

        #region Métodos Auxiliares
        private void CarregarItensNaListView()
        {
            listVProdutos.Items.Clear();
            foreach (var item in listaItens)
            {
                ListViewItem lvi = new ListViewItem(item.OProduto.Id.ToString());
                lvi.SubItems.Add(item.OProduto.Nome);
                lvi.SubItems.Add(item.Quantidade.ToString());
                lvi.SubItems.Add(item.ValorUnitario.ToString("C2"));
                lvi.SubItems.Add(item.ValorTotal.ToString("C2"));
                listVProdutos.Items.Add(lvi);
            }
            AtualizarTotais();
        }

        private void CarregarParcelasNaListView()
        {
            listVParcelas.Items.Clear();
            foreach (var parcela in listaParcelas)
            {
                ListViewItem lvi = new ListViewItem(parcela.NumeroParcela.ToString());
                lvi.SubItems.Add(parcela.DataVencimento.ToShortDateString());
                lvi.SubItems.Add(parcela.ValorParcela.ToString("C2"));
                listVParcelas.Items.Add(lvi);
            }
            AtualizarTotais();
        }

        private void LimparCamposProduto()
        {
            produtoSelecionado = new produto();
            txtCodProduto.Clear();
            txtProduto.Clear();
            txtQuantidade.Clear();
            txtValorUnitario.Clear();
            txtTotalProduto.Clear();
        }

        private void FinalizarEdicaoItem()
        {
            editandoItem = false;
            indiceItemEditando = -1;
            btnAdicionarProduto.Enabled = true;
            btnEditarProduto.Text = "Editar";
            btnRemoverProduto.Text = "Remover";
        }

        private bool ValidarCamposItem()
        {
            if (produtoSelecionado.Id == 0 ||
                string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                string.IsNullOrWhiteSpace(txtValorUnitario.Text) ||
                !int.TryParse(txtQuantidade.Text, out _) ||
                !decimal.TryParse(txtValorUnitario.Text, out _))
            {
                MessageBox.Show("Selecione um produto e preencha a quantidade e o valor unitário corretamente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AtualizarTotais()
        {
            decimal totalProdutos = listaItens.Sum(item => item.ValorTotal);
            lblValorTotalGeralProdutos.Text = totalProdutos.ToString("C2");

            decimal frete = string.IsNullOrWhiteSpace(txtValorFrete.Text) ? 0 : Convert.ToDecimal(txtValorFrete.Text);
            decimal seguro = string.IsNullOrWhiteSpace(txtSeguro.Text) ? 0 : Convert.ToDecimal(txtSeguro.Text);
            decimal despesas = string.IsNullOrWhiteSpace(txtDespesas.Text) ? 0 : Convert.ToDecimal(txtDespesas.Text);

            txtValorTotalValores.Text = (totalProdutos + frete + seguro + despesas).ToString("C2");

            decimal totalParcelas = listaParcelas.Sum(p => p.ValorParcela);
            lblValorTotalParcelas.Text = totalParcelas.ToString("C2");
        }

        private void txtQuantidade_Leave(object sender, EventArgs e) => AtualizaTotalProduto();
        private void txtValorUnitario_Leave(object sender, EventArgs e) => AtualizaTotalProduto();

        private void AtualizaTotalProduto()
        {
            if (int.TryParse(txtQuantidade.Text, out int qtd) && decimal.TryParse(txtValorUnitario.Text, out decimal val))
            {
                txtTotalProduto.Text = (qtd * val).ToString("F2");
            }
        }

        private void txtValoresAdicionais_Leave(object sender, EventArgs e)
        {
            AtualizarTotais();
        }
        #endregion
    }
}


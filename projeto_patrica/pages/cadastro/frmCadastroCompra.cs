using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private List<contasAPagar> listaParcelas = new List<contasAPagar>();

        // Controle de edição de item
        private bool editandoItem = false;
        private int indiceItemEditando = -1;
        private produto produtoSelecionado = new produto();

        public frmCadastroCompra()
        {
            InitializeComponent();
            dtpDataEmissao.MaxDate = DateTime.Today;
            GerenciarEstadoDosControles();
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

        public override bool ValidacaoCampos()
        {
            base.ValidacaoCampos();

            if (string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(txtNumDaNota.Text) ||
                oCompra.OFornecedor == null || oCompra.OFornecedor.Id == 0 ||
                listaItens.Count == 0 ||
                oCompra.ACondicaoPagamento == null || oCompra.ACondicaoPagamento.Id == 0)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios da nota, adicione pelo menos um produto e selecione a condição de pagamento para salvar.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        public override void Salvar()
        {
            if (btnSave.Text == "Cancelar Nota")
            {
                using (Form prompt = new Form())
                {
                    prompt.Width = 500;
                    prompt.Height = 250;
                    prompt.Text = "Motivo do Cancelamento";
                    prompt.StartPosition = FormStartPosition.CenterParent;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.MinimizeBox = false;
                    prompt.MaximizeBox = false;

                    Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Para cancelar esta nota, digite o motivo do cancelamento abaixo." };
                    TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Height = 80, Multiline = true, ScrollBars = ScrollBars.Vertical };
                    Button confirmation = new Button() { Text = "Confirmar", Left = 240, Width = 100, Top = 150, DialogResult = DialogResult.OK };
                    Button cancel = new Button() { Text = "Voltar", Left = 350, Width = 100, Top = 150, DialogResult = DialogResult.Cancel };

                    confirmation.Click += (sender, e) => { prompt.Close(); };
                    cancel.Click += (sender, e) => { prompt.Close(); };

                    prompt.Controls.Add(textBox);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(cancel);
                    prompt.Controls.Add(textLabel);
                    prompt.AcceptButton = confirmation;
                    prompt.CancelButton = cancel;

                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        oCompra.MotivoCancelamento = textBox.Text;
                        oCompra.Ativo = false;
                        aController_compra.Salvar(oCompra);
                        MessageBox.Show("Compra cancelada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                if (!ValidacaoCampos())
                    return;

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
                oCompra.MotivoCancelamento = null;

                try
                {
                    aController_compra.Salvar(oCompra);
                    MessageBox.Show("Compra salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    base.Salvar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao salvar a compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            lblMotivoCancelamentoTitulo.Visible = false;
            lblMotivCancelamentoExplicacao.Visible = false;
            lblMotivCancelamentoExplicacao.Text = "";


            oCompra = new compra();
            GerenciarEstadoDosControles();
        }

        public override void Carregatxt()
        {
            this.dtpDataEmissao.ValueChanged -= new System.EventHandler(this.dtpDataEmissao_ValueChanged);

            base.Carregatxt();
            txtCodigo.Text = oCompra.Modelo.ToString();
            txtSerie.Text = oCompra.Serie;
            txtNumDaNota.Text = oCompra.NumeroNota;
            txtCodFornecedor.Text = oCompra.OFornecedor.Id.ToString();
            txtFornecedor.Text = oCompra.OFornecedor.Nome_razaoSocial;
            dtpDataEmissao.Value = oCompra.DataEmissao;
            dtpDataEntrega.MinDate = dtpDataEmissao.Value;
            dtpDataEntrega.Value = oCompra.DataEntrega;
            txtValorFrete.Text = oCompra.ValorFrete.ToString("F2");
            txtSeguro.Text = oCompra.Seguro.ToString("F2");
            txtDespesas.Text = oCompra.Despesas.ToString("F2");
            txtCodCondicaoDePagamento.Text = oCompra.ACondicaoPagamento.Id.ToString();
            txtCondicaoDePagamento.Text = oCompra.ACondicaoPagamento.Descricao;
            checkBoxAtivo.Checked = oCompra.Ativo;

            // Lógica para exibir o motivo do cancelamento
            if (!oCompra.Ativo)
            {
                lblMotivoCancelamentoTitulo.Visible = true;
                lblMotivCancelamentoExplicacao.Visible = true;
                lblMotivCancelamentoExplicacao.Text = oCompra.MotivoCancelamento;
            }
            else
            {
                lblMotivoCancelamentoTitulo.Visible = false;
                lblMotivCancelamentoExplicacao.Visible = false;
                lblMotivCancelamentoExplicacao.Text = "";
            }


            listaItens = oCompra.Itens;
            CarregarItensNaListView();

            listaParcelas = oCompra.Parcelas;
            CarregarParcelasNaListView();

            this.dtpDataEmissao.ValueChanged += new System.EventHandler(this.dtpDataEmissao_ValueChanged);
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            HabilitarSecaoCabecalho(false);
            HabilitarSecaoProdutos(false);
            HabilitarSecaoRodape(false);
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            HabilitarSecaoCabecalho(true);
            HabilitarSecaoProdutos(true);
            HabilitarSecaoRodape(true);
            GerenciarEstadoDosControles();
        }
        #endregion

        #region Gerenciamento de Estado dos Controles
        private void GerenciarEstadoDosControles()
        {
            bool cabecalhoPreenchido = !string.IsNullOrWhiteSpace(txtSerie.Text) &&
                                       !string.IsNullOrWhiteSpace(txtNumDaNota.Text) &&
                                       !string.IsNullOrWhiteSpace(txtCodigo.Text) &&
                                       oCompra != null && oCompra.OFornecedor != null && oCompra.OFornecedor.Id > 0;

            bool temItens = listaItens.Any();
            bool temParcelas = listaParcelas.Any();

            if (!temItens)
            {
                HabilitarSecaoCabecalho(true);
                HabilitarSecaoProdutos(cabecalhoPreenchido);
                HabilitarSecaoRodape(false);
            }
            else if (temItens && !temParcelas)
            {
                HabilitarSecaoCabecalho(false);
                HabilitarSecaoProdutos(true);
                HabilitarSecaoRodape(true);
            }
            else // temItens && temParcelas
            {
                HabilitarSecaoCabecalho(false);
                HabilitarSecaoProdutos(false);
                HabilitarSecaoRodape(false);
                btnLimparParcelas.Enabled = true;
            }
        }

        private void HabilitarSecaoCabecalho(bool habilitar)
        {
            txtCodigo.Enabled = habilitar;
            txtSerie.Enabled = habilitar;
            txtNumDaNota.Enabled = habilitar;
            txtCodFornecedor.Enabled = habilitar;
            txtFornecedor.Enabled = habilitar;
            btnPesquisarFornecedor.Enabled = habilitar;
            dtpDataEmissao.Enabled = habilitar;
            dtpDataEntrega.Enabled = habilitar;
        }

        private void HabilitarSecaoProdutos(bool habilitar)
        {
            txtCodProduto.Enabled = habilitar;
            txtProduto.Enabled = habilitar;
            btnPesquisarProduto.Enabled = habilitar;
            txtQuantidade.Enabled = habilitar;
            txtValorUnitario.Enabled = habilitar;
            txtTotalProduto.Enabled = habilitar;
            btnAdicionarProduto.Enabled = habilitar;
            btnEditarProduto.Enabled = habilitar;
            btnRemoverProduto.Enabled = habilitar;
            btnLimparListaProduto.Enabled = habilitar;
        }

        private void HabilitarSecaoRodape(bool habilitar)
        {
            txtValorFrete.Enabled = habilitar;
            txtSeguro.Enabled = habilitar;
            txtDespesas.Enabled = habilitar;
            txtValorTotalValores.Enabled = habilitar;
            txtCodCondicaoDePagamento.Enabled = habilitar;
            txtCondicaoDePagamento.Enabled = habilitar;
            btnPesquisarCondicaoDePagamento.Enabled = habilitar;
            btnGerarParcelas.Enabled = habilitar;
            btnLimparParcelas.Enabled = habilitar;
        }

        private void Cabecalho_TextChanged(object sender, EventArgs e)
        {
            GerenciarEstadoDosControles();
        }

        #endregion

        #region Gerenciamento de Itens
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (ValidarCamposItem())
            {
                if (listaItens.Any(i => i.OProduto.Id == produtoSelecionado.Id))
                {
                    MessageBox.Show("Este produto já foi adicionado à lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                GerenciarEstadoDosControles();
            }
        }

        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            if (editandoItem)
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
            else
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
                    GerenciarEstadoDosControles();
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
            GerenciarEstadoDosControles();
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
            decimal.TryParse(txtValorFrete.Text, out decimal frete);
            decimal.TryParse(txtSeguro.Text, out decimal seguro);
            decimal.TryParse(txtDespesas.Text, out decimal despesas);

            decimal totalCompra = totalProdutos + frete + seguro + despesas;

            totalCompra = totalCompra * (1 - (oCompra.ACondicaoPagamento.Desconto / 100));
            totalCompra = totalCompra * (1 + (oCompra.ACondicaoPagamento.Juros / 100));

            listaParcelas.Clear();
            foreach (var parcelaCondicao in oCompra.ACondicaoPagamento.Parcelas)
            {
                contasAPagar novaParcela = new contasAPagar
                {
                    ModeloCompra = Convert.ToInt32(txtCodigo.Text),
                    SerieCompra = txtSerie.Text,
                    NumeroNotaCompra = txtNumDaNota.Text,
                    IdFornecedor = oCompra.OFornecedor.Id,
                    NumeroParcela = parcelaCondicao.NumeroParcela,
                    DataEmissao = dtpDataEmissao.Value,
                    DataVencimento = dtpDataEmissao.Value.AddDays(parcelaCondicao.DiasAposVenda),
                    ValorParcela = totalCompra * (parcelaCondicao.ValorPercentual / 100),
                    AFormaPagamento = parcelaCondicao.AFormaPagamento
                };
                listaParcelas.Add(novaParcela);
            }

            CarregarParcelasNaListView();
            GerenciarEstadoDosControles();
        }

        private void btnLimparParcelas_Click(object sender, EventArgs e)
        {
            listaParcelas.Clear();
            CarregarParcelasNaListView();
            GerenciarEstadoDosControles();
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
                aController_compra.AController_fornecedor.CarregaObj(fornecedorSelecionado);

                oCompra.OFornecedor = fornecedorSelecionado;
                txtCodFornecedor.Text = fornecedorSelecionado.Id.ToString();
                txtFornecedor.Text = fornecedorSelecionado.Nome_razaoSocial;

                if (fornecedorSelecionado.ACondicaoPagamento != null && fornecedorSelecionado.ACondicaoPagamento.Id != 0)
                {
                    oCompra.ACondicaoPagamento = fornecedorSelecionado.ACondicaoPagamento;
                    txtCodCondicaoDePagamento.Text = oCompra.ACondicaoPagamento.Id.ToString();
                    txtCondicaoDePagamento.Text = oCompra.ACondicaoPagamento.Descricao;
                }
                else
                {
                    oCompra.ACondicaoPagamento = new condicaoPagamento();
                    txtCodCondicaoDePagamento.Clear();
                    txtCondicaoDePagamento.Clear();
                }
            }
            GerenciarEstadoDosControles();
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
                aController_compra.AController_produto.CarregaObj(p);
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
                controller.CarregaObj(condicaoSelecionada);
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

            decimal.TryParse(txtValorFrete.Text, out decimal frete);
            decimal.TryParse(txtSeguro.Text, out decimal seguro);
            decimal.TryParse(txtDespesas.Text, out decimal despesas);

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

        private void dtpDataEmissao_ValueChanged(object sender, EventArgs e)
        {
            dtpDataEntrega.MinDate = dtpDataEmissao.Value;
            Cabecalho_TextChanged(sender, e);
        }

        #endregion

        private void txtValorFrete_Leave(object sender, EventArgs e)
        {
            AtualizarTotais();
        }

        private void txtSeguro_Leave(object sender, EventArgs e)
        {
            AtualizarTotais();
        }

        private void txtDespesas_Leave(object sender, EventArgs e)
        {
            AtualizarTotais();
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtCodigo.MaxLength = 2;
            txtSerie.MaxLength = 3;
            txtNumDaNota.MaxLength = 9;
            txtQuantidade.MaxLength = 5;
            txtValorUnitario.MaxLength = 11;
            txtTotalProduto.MaxLength = 11;
            txtValorFrete.MaxLength = 11;
            txtSeguro.MaxLength = 11;
            txtDespesas.MaxLength = 11;
            txtValorTotalValores.MaxLength = 11;


            txtCodigo.KeyPress -= ApenasNumeros;
            txtCodigo.KeyPress += ApenasNumeros;

            txtSerie.KeyPress -= ApenasNumeros;
            txtSerie.KeyPress += ApenasNumeros;

            txtNumDaNota.KeyPress -= ApenasNumeros;
            txtNumDaNota.KeyPress += ApenasNumeros;

            txtQuantidade.KeyPress -= ApenasNumeros;
            txtQuantidade.KeyPress += ApenasNumeros;

            txtValorUnitario.KeyPress -= ApenasNumerosDecimal;
            txtValorUnitario.KeyPress += ApenasNumerosDecimal;

            txtValorFrete.KeyPress -= ApenasNumerosDecimal;
            txtValorFrete.KeyPress += ApenasNumerosDecimal;

            txtSeguro.KeyPress -= ApenasNumerosDecimal;
            txtSeguro.KeyPress += ApenasNumerosDecimal;

            txtDespesas.KeyPress -= ApenasNumerosDecimal;
            txtDespesas.KeyPress += ApenasNumerosDecimal;

            txtValorTotalValores.KeyPress -= ApenasNumerosDecimal;
            txtValorTotalValores.KeyPress += ApenasNumerosDecimal;
        }
    }
}
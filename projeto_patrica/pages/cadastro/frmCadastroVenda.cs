using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.dao;
using projeto_patrica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroVenda : projeto_patrica.pages.cadastro.frmCadastro
    {
        private venda oVenda;
        private Controller_venda aController_venda;
        private frmConsultaCliente oFrmConsultaCliente;
        private frmConsultaFuncionario oFrmConsultaFuncionario;
        private frmConsultaProduto oFrmConsultaProduto;
        private frmConsultaCondicaoPagamento oFrmConsultaCondicaoPagamento;
        private List<itemVenda> listaItens = new List<itemVenda>();
        private List<contasAReceber> listaParcelas = new List<contasAReceber>();
        private bool editandoItem = false;
        private int indiceItemEditando = -1;
        private produto produtoSelecionado = new produto();
        private bool vendaExistente = false;
        private bool _isLoading = false;
        private Dao_venda aDao_venda;

        public frmCadastroVenda()
        {
            InitializeComponent();
            dtpDataEmissao.MaxDate = DateTime.Today;
            aDao_venda = new Dao_venda();
            GerenciarEstadoDosControles();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oVenda = (venda)obj;
            aController_venda = (Controller_venda)ctrl;
        }

        public void setConsultaCliente(frmConsultaCliente consulta)
        {
            oFrmConsultaCliente = consulta;
        }

        public void setConsultaFuncionario(frmConsultaFuncionario consulta)
        {
            oFrmConsultaFuncionario = consulta;
        }

        public void setConsultaProduto(frmConsultaProduto consulta)
        {
            oFrmConsultaProduto = consulta;
        }

        public void setConsultaCondicaoPagamento(frmConsultaCondicaoPagamento consulta)
        {
            oFrmConsultaCondicaoPagamento = consulta;
        }

        private void VerificarVendaExistente()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(txtNumDaNota.Text) ||
                oVenda.OCliente == null || oVenda.OCliente.Id == 0)
            {
                vendaExistente = false;
                GerenciarEstadoDosControles();
                return;
            }

            int modelo = Convert.ToInt32(txtCodigo.Text);
            string serie = txtSerie.Text;
            string numeroNota = txtNumDaNota.Text;
            int idCliente = oVenda.OCliente.Id;

            if (aDao_venda.VerificarVendaExistente(modelo, serie, numeroNota, idCliente))
            {
                MessageBox.Show("Esta nota de venda já foi cadastrada para este cliente.", "Venda Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vendaExistente = true;
            }
            else
            {
                vendaExistente = false;
            }
            GerenciarEstadoDosControles();
        }


        public override bool ValidacaoCampos()
        {
            base.ValidacaoCampos();

            if (string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(txtNumDaNota.Text) ||
                oVenda.OCliente == null || oVenda.OCliente.Id == 0 ||
                oVenda.OFuncionario == null || oVenda.OFuncionario.Id == 0 ||
                listaItens.Count == 0 ||
                oVenda.ACondicaoPagamento == null || oVenda.ACondicaoPagamento.Id == 0 ||
                listaParcelas.Count == 0)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios, adicione produtos e gere as parcelas antes de salvar.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Para cancelar esta nota, digite o motivo do cancelamento (mínimo 20 caracteres)." };
                    TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Height = 80, Multiline = true, ScrollBars = ScrollBars.Vertical, MaxLength = 100, CharacterCasing = CharacterCasing.Upper };
                    Button confirmation = new Button() { Text = "Confirmar", Left = 240, Width = 100, Top = 150, DialogResult = DialogResult.OK };
                    Button cancel = new Button() { Text = "Voltar", Left = 350, Width = 100, Top = 150, DialogResult = DialogResult.Cancel };

                    confirmation.Enabled = false;
                    textBox.TextChanged += (sender, e) =>
                    {
                        confirmation.Enabled = textBox.Text.Trim().Length >= 20;
                    };

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
                        oVenda.MotivoCancelamento = textBox.Text;
                        oVenda.Ativo = false;
                        aController_venda.Salvar(oVenda);
                        MessageBox.Show("Venda cancelada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                if (!ValidacaoCampos())
                    return;

                oVenda.Modelo = Convert.ToInt32(txtCodigo.Text);
                oVenda.Serie = txtSerie.Text;
                oVenda.NumeroNota = txtNumDaNota.Text;
                oVenda.DataEmissao = dtpDataEmissao.Value;
                oVenda.Ativo = checkBoxAtivo.Checked;
                oVenda.Itens = listaItens;
                oVenda.Parcelas = listaParcelas;
                oVenda.MotivoCancelamento = null;
                // OCliente, OFuncionario e ACondicaoPagamento já definidos

                try
                {
                    aController_venda.Salvar(oVenda);
                    MessageBox.Show("Venda salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    base.Salvar();
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1062:
                            MessageBox.Show(
                                "Não foi possível salvar o item.\n\nJá existe um item salvo com estes dados.",
                                "Erro: Item duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            break;

                        default:
                            MessageBox.Show(
                                "Não foi possível concluir a operação. Verifique os dados e tente novamente.\n\nDetalhes técnicos: " + ex.Message,
                                "Erro no Banco de Dados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            break;
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Métodos de Controle do Formulário
        public override void Limpartxt()
        {
            _isLoading = true;
            try
            {
                base.Limpartxt();
                txtCodigo.Text = "55";
                txtSerie.Text = "1";
                txtNumDaNota.Clear();
                txtCodCliente.Clear();
                txtCliente.Clear();
                txtCodFuncionario.Clear();
                txtFuncionario.Clear();
                dtpDataEmissao.Value = DateTime.Today;
                LimparCamposProduto();
                btnLimparListaProduto_Click(null, null);
                txtCodCondicaoDePagamento.Clear();
                txtCondicaoDePagamento.Clear();
                btnLimparParcelas_Click(null, null);
                lblMotivoCancelamentoTitulo.Visible = false;
                lblMotivCancelamentoExplicacao.Visible = false;
                lblMotivCancelamentoExplicacao.Text = "";
                txtCodProduto.Clear();
                txtProduto.Clear();

                checkBoxAtivo.Text = checkBoxAtivo.Checked ? "Ativo" : "Cancelado";


                oVenda = new venda();
                vendaExistente = false;
                GerenciarEstadoDosControles();
            }
            finally
            {
                _isLoading = false;
            }
        }

        public override void Carregatxt()
        {
            _isLoading = true;
            try
            {
                base.Carregatxt();
                txtCodigo.Text = oVenda.Modelo.ToString();
                txtSerie.Text = oVenda.Serie;
                txtNumDaNota.Text = oVenda.NumeroNota;
                txtCodCliente.Text = oVenda.OCliente.Id.ToString();
                txtCliente.Text = oVenda.OCliente.Nome_razaoSocial;
                txtCodFuncionario.Text = oVenda.OFuncionario.Id.ToString();
                txtFuncionario.Text = oVenda.OFuncionario.Nome_razaoSocial;
                dtpDataEmissao.Value = oVenda.DataEmissao;

                txtCodCondicaoDePagamento.Text = oVenda.ACondicaoPagamento.Id.ToString();
                txtCondicaoDePagamento.Text = oVenda.ACondicaoPagamento.Descricao;
                checkBoxAtivo.Checked = oVenda.Ativo;

                checkBoxAtivo.Text = checkBoxAtivo.Checked ? "Ativo" : "Cancelado";

                lblDataCadastroData.Text = oVenda.DataCadastro.ToShortDateString();
                lblDataUltimaEdicaoData.Text = oVenda.DataUltimaEdicao?.ToString("dd/MM/yyyy HH:mm");
                if (!oVenda.Ativo)
                {
                    lblMotivoCancelamentoTitulo.Visible = true;
                    lblMotivCancelamentoExplicacao.Visible = true;
                    lblMotivCancelamentoExplicacao.Text = oVenda.MotivoCancelamento;
                }
                else
                {
                    lblMotivoCancelamentoTitulo.Visible = false;
                    lblMotivCancelamentoExplicacao.Visible = false;
                    lblMotivCancelamentoExplicacao.Text = "";
                }

                listaItens = oVenda.Itens;
                CarregarItensNaListView();

                listaParcelas = oVenda.Parcelas;
                CarregarParcelasNaListView();
            }
            finally
            {
                _isLoading = false;
            }
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
                                       oVenda != null &&
                                       oVenda.OCliente != null && oVenda.OCliente.Id > 0 &&
                                       oVenda.OFuncionario != null && oVenda.OFuncionario.Id > 0;

            bool temItens = listaItens.Any();
            bool temParcelas = listaParcelas.Any();

            bool podeProsseguirCabecalho = cabecalhoPreenchido && !vendaExistente;


            if (!temItens)
            {
                HabilitarSecaoCabecalho(true);
                HabilitarSecaoProdutos(podeProsseguirCabecalho);
                HabilitarSecaoRodape(false);
            }
            else if (temItens && !temParcelas)
            {
                HabilitarSecaoCabecalho(false);
                HabilitarSecaoProdutos(podeProsseguirCabecalho);
                HabilitarSecaoRodape(true);
            }
            else
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
            txtCodCliente.Enabled = habilitar;
            txtCliente.Enabled = habilitar;
            btnPesquisarCliente.Enabled = habilitar;
            txtCodFuncionario.Enabled = habilitar;
            txtFuncionario.Enabled = habilitar;
            btnPesquisarFuncionario.Enabled = habilitar;
            dtpDataEmissao.Enabled = habilitar;
        }

        private void HabilitarSecaoProdutos(bool habilitar)
        {
            txtCodProduto.Enabled = habilitar;
            txtProduto.Enabled = habilitar;
            txtUnidadeDeMedida.Enabled = habilitar;
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
            txtValorTotalValores.Enabled = habilitar;
            txtCodCondicaoDePagamento.Enabled = habilitar;
            txtCondicaoDePagamento.Enabled = habilitar;
            btnPesquisarCondicaoDePagamento.Enabled = habilitar;
            btnGerarParcelas.Enabled = habilitar;
            btnLimparParcelas.Enabled = habilitar;
        }

        private void Cabecalho_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            VerificarVendaExistente();
        }

        #endregion

        #region Gerenciamento de Itens
        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (ValidarCamposItem())
            {
                int quantidadeDesejada = Convert.ToInt32(txtQuantidade.Text);
                if (quantidadeDesejada > produtoSelecionado.Estoque)
                {
                    MessageBox.Show($"Estoque insuficiente. Estoque atual do produto: {produtoSelecionado.Estoque}", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (listaItens.Any(i => i.OProduto.Id == produtoSelecionado.Id))
                {
                    MessageBox.Show("Este produto já foi adicionado à lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                itemVenda item = new itemVenda
                {
                    ModeloVenda = Convert.ToInt32(txtCodigo.Text),
                    SerieVenda = txtSerie.Text,
                    NumeroNotaVenda = txtNumDaNota.Text,
                    IdCliente = oVenda.OCliente.Id,
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
                    int quantidadeDesejada = Convert.ToInt32(txtQuantidade.Text);
                    if (quantidadeDesejada > produtoSelecionado.Estoque)
                    {
                        MessageBox.Show($"Estoque insuficiente. Estoque atual do produto: {produtoSelecionado.Estoque}", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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
                    txtUnidadeDeMedida.Text = item.OProduto.OUnidadeMedida.Sigla;
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
            aController_venda.AController_condicaoPagamento.CarregaObj(oVenda.ACondicaoPagamento);

            decimal totalProdutos = listaItens.Sum(item => item.ValorTotal);
            decimal totalVenda = totalProdutos;

            listaParcelas.Clear();
            decimal totalParcelasCalculado = 0;
            var parcelasCondicao = oVenda.ACondicaoPagamento.Parcelas;

            for (int i = 0; i < parcelasCondicao.Count; i++)
            {
                var parcelaCondicao = parcelasCondicao[i];
                decimal valorEstaParcela;

                if (i == parcelasCondicao.Count - 1)
                {
                    valorEstaParcela = totalVenda - totalParcelasCalculado;
                }
                else
                {
                    valorEstaParcela = Math.Round(totalVenda * (parcelaCondicao.ValorPercentual / 100), 2);
                    totalParcelasCalculado += valorEstaParcela;
                }

                contasAReceber novaParcela = new contasAReceber
                {
                    ModeloVenda = Convert.ToInt32(txtCodigo.Text),
                    SerieVenda = txtSerie.Text,
                    NumeroNotaVenda = txtNumDaNota.Text,
                    OCliente = oVenda.OCliente,
                    NumeroParcela = parcelaCondicao.NumeroParcela,
                    DataEmissao = dtpDataEmissao.Value,
                    DataVencimento = dtpDataEmissao.Value.AddDays(parcelaCondicao.DiasAposVenda),
                    ValorParcela = valorEstaParcela,
                    AFormaPagamento = parcelaCondicao.AFormaPagamento,
                    Ativo = true,
                    Situacao = 0,
                    Juros = oVenda.ACondicaoPagamento.Juros,
                    Multa = oVenda.ACondicaoPagamento.Multa,
                    Desconto = oVenda.ACondicaoPagamento.Desconto,
                    ValorPago = null,
                    DataPagamento = null
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
        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCliente == null) oFrmConsultaCliente = new frmConsultaCliente();

            cliente clienteSelecionado = new cliente();
            Controller_cliente controller = new Controller_cliente();

            oFrmConsultaCliente.ConhecaObj(clienteSelecionado, controller);
            oFrmConsultaCliente.ShowDialog();

            if (clienteSelecionado.Id != 0)
            {
                aController_venda.AController_cliente.CarregaObj(clienteSelecionado);

                oVenda.OCliente = clienteSelecionado;
                txtCodCliente.Text = clienteSelecionado.Id.ToString();
                txtCliente.Text = clienteSelecionado.Nome_razaoSocial;

                if (clienteSelecionado.ACondicaoPagamento != null && clienteSelecionado.ACondicaoPagamento.Id != 0)
                {
                    oVenda.ACondicaoPagamento = clienteSelecionado.ACondicaoPagamento;
                    txtCodCondicaoDePagamento.Text = oVenda.ACondicaoPagamento.Id.ToString();
                    txtCondicaoDePagamento.Text = oVenda.ACondicaoPagamento.Descricao;
                }
                else
                {
                    oVenda.ACondicaoPagamento = new condicaoPagamento();
                    txtCodCondicaoDePagamento.Clear();
                    txtCondicaoDePagamento.Clear();
                }
            }
            GerenciarEstadoDosControles();
        }

        private void btnPesquisarFuncionario_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaFuncionario == null) oFrmConsultaFuncionario = new frmConsultaFuncionario();

            funcionario funcionarioSelecionado = new funcionario();
            Controller_funcionario controller = new Controller_funcionario();

            oFrmConsultaFuncionario.ConhecaObj(funcionarioSelecionado, controller);
            oFrmConsultaFuncionario.ShowDialog();

            if (funcionarioSelecionado.Id != 0)
            {
                aController_venda.AController_funcionario.CarregaObj(funcionarioSelecionado);

                oVenda.OFuncionario = funcionarioSelecionado;
                txtCodFuncionario.Text = funcionarioSelecionado.Id.ToString();
                txtFuncionario.Text = funcionarioSelecionado.Nome_razaoSocial;
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
                aController_venda.AController_produto.CarregaObj(p);
                produtoSelecionado = p;
                txtCodProduto.Text = p.Id.ToString();
                txtProduto.Text = p.Nome;
                txtUnidadeDeMedida.Text = p.OUnidadeMedida.Sigla;
                txtValorUnitario.Text = p.ValorVenda.ToString("F2"); // Alterado de 0,00 para Preço de Venda
                txtQuantidade.Text = "1";
                AtualizaTotalProduto();
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
                oVenda.ACondicaoPagamento = condicaoSelecionada;
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
                lvi.SubItems.Add(item.OProduto.OUnidadeMedida.Sigla);
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
                lvi.SubItems.Add(parcela.DataEmissao.ToShortDateString());
                lvi.SubItems.Add(parcela.DataVencimento.ToShortDateString());
                lvi.SubItems.Add(parcela.ValorParcela.ToString("C2"));
                lvi.SubItems.Add(parcela.AFormaPagamento.Descricao);
                listVParcelas.Items.Add(lvi);
            }
            AtualizarTotais();
        }

        private void LimparCamposProduto()
        {
            produtoSelecionado = new produto();
            txtCodProduto.Clear();
            txtProduto.Clear();
            txtUnidadeDeMedida.Clear();
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
                !int.TryParse(txtQuantidade.Text, out int qtd) ||
                !decimal.TryParse(txtValorUnitario.Text, out _) ||
                qtd <= 0)
            {
                MessageBox.Show("Selecione um produto e preencha a quantidade (maior que zero) e o valor unitário corretamente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AtualizarTotais()
        {
            int totalQuantidade = listaItens.Sum(item => item.Quantidade);
            lblValorQtdTotalProdutos.Text = totalQuantidade.ToString();

            decimal totalProdutos = listaItens.Sum(item => item.ValorTotal);
            lblValorTotalGeralProdutos.Text = totalProdutos.ToString("C2");

            txtValorTotalValores.Text = totalProdutos.ToString("C2");

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
            Cabecalho_TextChanged(sender, e);
        }

        #endregion

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtCodigo.MaxLength = 2;
            txtSerie.MaxLength = 4;
            txtNumDaNota.MaxLength = 9;
            txtQuantidade.MaxLength = 5;
            txtValorUnitario.MaxLength = 11;
            txtTotalProduto.MaxLength = 11;
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

            txtValorTotalValores.KeyPress -= ApenasNumerosDecimal;
            txtValorTotalValores.KeyPress += ApenasNumerosDecimal;
        }
    }
}
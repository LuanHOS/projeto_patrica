﻿using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroContasAPagar : projeto_patrica.pages.cadastro.frmCadastro
    {
        private contasAPagar oContaAPagar;
        private Controller_contasAPagar aController_contasAPagar;
        private frmConsultaFornecedor oFrmConsultaFornecedor;
        private frmConsultaFormaPagamento oFrmConsultaFormaPagamento;

        public frmCadastroContasAPagar()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaAPagar = (contasAPagar)obj;
            aController_contasAPagar = (Controller_contasAPagar)ctrl;
        }

        public void setConsultaFornecedor(frmConsultaFornecedor consulta)
        {
            oFrmConsultaFornecedor = consulta;
        }

        public void setConsultaFormaPagamento(frmConsultaFormaPagamento consulta)
        {
            oFrmConsultaFormaPagamento = consulta;
        }

        public override void Salvar()
        {
            if (!ValidacaoCampos())
                return;

            oContaAPagar.ModeloCompra = Convert.ToInt32(txtCodigo.Text);
            oContaAPagar.SerieCompra = txtSerie.Text;
            oContaAPagar.NumeroNotaCompra = txtNumDaNota.Text;
            oContaAPagar.OFornecedor.Id = Convert.ToInt32(txtCodFornecedor.Text);
            oContaAPagar.NumeroParcela = Convert.ToInt32(txtNumParcela.Text);
            oContaAPagar.DataEmissao = dtpDataEmissao.Value;
            oContaAPagar.DataVencimento = dtpDataVencimento.Value;
            oContaAPagar.ValorParcela = Convert.ToDecimal(txtValorParcela.Text);
            oContaAPagar.AFormaPagamento.Id = Convert.ToInt32(txtCodFormaPagamento.Text);

            if (oContaAPagar.AFormaPagamento == null || oContaAPagar.AFormaPagamento.Id == 0)
            {
                oContaAPagar.AFormaPagamento = new formaPagamento { Id = Convert.ToInt32(txtCodFormaPagamento.Text) };
            }
            if (oContaAPagar.OFornecedor == null || oContaAPagar.OFornecedor.Id == 0)
            {
                oContaAPagar.OFornecedor = new fornecedor { Id = Convert.ToInt32(txtCodFornecedor.Text) };
            }

            try
            {
                if (btnSave.Text == "Cancelar Conta")
                {
                    string motivo = SolicitarMotivoCancelamento();
                    if (string.IsNullOrEmpty(motivo)) return;

                    oContaAPagar.Ativo = false;
                    oContaAPagar.MotivoCancelamento = motivo;
                    oContaAPagar.DataUltimaEdicao = DateTime.Now;

                    aController_contasAPagar.Salvar(oContaAPagar);
                    MessageBox.Show("Conta a Pagar cancelada com sucesso.");
                }
                else if (btnSave.Text == "Dar Baixa")
                {
                    RecalcularValorPago(null, null); 
                    if (ConfirmarBaixa())
                    {
                        oContaAPagar.Juros = Convert.ToDecimal(txtJuros.Text);
                        oContaAPagar.Multa = Convert.ToDecimal(txtMulta.Text);
                        oContaAPagar.Desconto = Convert.ToDecimal(txtDesconto.Text);
                        oContaAPagar.Situacao = 1;
                        oContaAPagar.ValorPago = Convert.ToDecimal(txtValorPago.Text);
                        oContaAPagar.DataPagamento = dtpDataPagamento.Value;
                        oContaAPagar.DataUltimaEdicao = DateTime.Now;
                        oContaAPagar.Ativo = true;

                        aController_contasAPagar.Salvar(oContaAPagar);
                        MessageBox.Show("Conta a Pagar baixada com sucesso.");
                    }
                    else
                    {
                        return; 
                    }
                }
                else
                {
                    oContaAPagar.Juros = Convert.ToDecimal(txtJuros.Text);
                    oContaAPagar.Multa = Convert.ToDecimal(txtMulta.Text);
                    oContaAPagar.Desconto = Convert.ToDecimal(txtDesconto.Text);
                    oContaAPagar.Situacao = 0; 
                    oContaAPagar.ValorPago = null;
                    oContaAPagar.DataPagamento = null;
                    oContaAPagar.Ativo = checkBoxAtivo.Checked; 

                    aController_contasAPagar.Salvar(oContaAPagar);
                    MessageBox.Show("Conta a Pagar salva com sucesso.");
                }

                base.Salvar();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1062: 
                        MessageBox.Show(
                            "Não foi possível salvar.\n\nJá existe uma parcela com este Modelo, Série, Número da Nota, Fornecedor e Número de Parcela.",
                            "Erro: Item duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;
                    case 1452: 
                        MessageBox.Show(
                            "Não foi possível salvar.\n\nO Fornecedor ou a Forma de Pagamento especificada não existe.",
                            "Erro: Referência inválida",
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
                return;
            }
        }

        public override void Limpartxt()
        {
            base.Limpartxt();
            txtCodigo.Text = "55";
            txtSerie.Text = "1";
            txtNumDaNota.Clear();
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            txtNumParcela.Text = "1"; 
            dtpDataEmissao.Value = DateTime.Today;
            dtpDataVencimento.Value = DateTime.Today;
            txtValorParcela.Text = "0,00";
            txtFormaPagamento.Clear();
            txtCodFormaPagamento.Clear();
            txtJuros.Text = "0,00";
            txtMulta.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtValorPago.Text = "0,00";
            dtpDataPagamento.Value = DateTime.Today;
            dtpDataPagamento.Checked = false;

            lblMotivoCancelamentoTitulo.Visible = false;
            lblMotivCancelamentoExplicacao.Visible = false;

            oContaAPagar = new contasAPagar();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oContaAPagar.ModeloCompra.ToString();
            txtSerie.Text = oContaAPagar.SerieCompra;
            txtNumDaNota.Text = oContaAPagar.NumeroNotaCompra;
            txtCodFornecedor.Text = oContaAPagar.OFornecedor.Id.ToString();
            txtNumParcela.Text = oContaAPagar.NumeroParcela.ToString();
            aController_contasAPagar.AController_fornecedor.CarregaObj(oContaAPagar.OFornecedor);
            txtFornecedor.Text = oContaAPagar.OFornecedor.Nome_razaoSocial;
            aController_contasAPagar.AController_formaPagamento.CarregaObj(oContaAPagar.AFormaPagamento);
            txtFormaPagamento.Text = oContaAPagar.AFormaPagamento.Descricao;
            txtCodFormaPagamento.Text = oContaAPagar.AFormaPagamento.Id.ToString();
            dtpDataEmissao.Value = (oContaAPagar.DataEmissao >= dtpDataEmissao.MinDate) ? oContaAPagar.DataEmissao : DateTime.Today;
            dtpDataVencimento.Value = (oContaAPagar.DataVencimento >= dtpDataVencimento.MinDate) ? oContaAPagar.DataVencimento : DateTime.Today;

            if (oContaAPagar.DataPagamento.HasValue)
            {
                dtpDataPagamento.Value = oContaAPagar.DataPagamento.Value;
                dtpDataPagamento.Checked = true;
            }
            else
            {
                dtpDataPagamento.Value = DateTime.Today;
                dtpDataPagamento.Checked = false;
            }

            txtValorParcela.Text = oContaAPagar.ValorParcela.ToString("F2");
            txtJuros.Text = oContaAPagar.Juros.ToString("F2");
            txtMulta.Text = oContaAPagar.Multa.ToString("F2");
            txtDesconto.Text = oContaAPagar.Desconto.ToString("F2");
            txtValorPago.Text = oContaAPagar.ValorPago.HasValue ? oContaAPagar.ValorPago.Value.ToString("F2") : "0,00";

            checkBoxAtivo.Checked = oContaAPagar.Ativo;
            lblDataCadastroData.Text = oContaAPagar.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oContaAPagar.DataUltimaEdicao?.ToString("dd/MM/yyyy HH:mm") ?? " ";

            lblMotivoCancelamentoTitulo.Visible = !oContaAPagar.Ativo;
            lblMotivCancelamentoExplicacao.Visible = !oContaAPagar.Ativo;
            lblMotivCancelamentoExplicacao.Text = oContaAPagar.MotivoCancelamento ?? "";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            txtCodFornecedor.Enabled = false;
            txtFornecedor.Enabled = false;
            btnPesquisarFornecedor.Enabled = false;
            txtNumParcela.Enabled = false;
            dtpDataEmissao.Enabled = false;
            dtpDataVencimento.Enabled = false;
            txtValorParcela.Enabled = false;
            txtCodFormaPagamento.Enabled = false;
            txtFormaPagamento.Enabled = false;
            btnPesquisarFormaPagamento.Enabled = false;
            txtJuros.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;
            txtValorPago.Enabled = false;
            dtpDataPagamento.Enabled = false;

            if (btnSave.Text == "Visualizar")
            {
                btnSave.Visible = false; // Botão Salvar fica invisível

                // Mostra campos de pagamento se estiver paga
                bool pago = oContaAPagar.Situacao == 1;
                dtpDataPagamento.Visible = pago;
                txtValorPago.Visible = pago;
                lblDataPagamento.Visible = pago;
                lblValorFinal.Visible = pago;

                // Mostra campos de cancelamento se estiver cancelada
                bool cancelado = !oContaAPagar.Ativo;
                lblMotivoCancelamentoTitulo.Visible = cancelado;
                lblMotivCancelamentoExplicacao.Visible = cancelado;
            }
            else if (btnSave.Text == "Cancelar Conta")
            {
                btnSave.Visible = true; // Botão "Cancelar Conta" visível
                // Esconde campos de pagamento
                dtpDataPagamento.Visible = false;
                txtValorPago.Visible = false;
                lblDataPagamento.Visible = false;
                lblValorFinal.Visible = false;
            }
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();


            if (btnSave.Text == "Salvar") // Modo Inclusão
            {
                txtCodigo.Enabled = true;
                txtSerie.Enabled = true;
                txtNumDaNota.Enabled = true;
                btnPesquisarFornecedor.Enabled = true;
                txtNumParcela.Enabled = true;
                dtpDataEmissao.Enabled = true;
                dtpDataVencimento.Enabled = true;
                txtValorParcela.Enabled = true;
                btnPesquisarFormaPagamento.Enabled = true;
                txtJuros.Enabled = true;
                txtMulta.Enabled = true;
                txtDesconto.Enabled = true;
                txtCodFormaPagamento.Enabled = true;
                txtFormaPagamento.Enabled = true;
                txtCodFornecedor.Enabled = true;
                txtFornecedor.Enabled = true;
                btnSave.Visible = true;
                checkBoxAtivo.Enabled = false;

                // Campos de baixa/visualização ficam ocultos
                dtpDataPagamento.Visible = false;
                txtValorPago.Visible = false;
                lblDataPagamento.Visible = false;
                lblValorFinal.Visible = false;
                lblMotivoCancelamentoTitulo.Visible = false;
                lblMotivCancelamentoExplicacao.Visible = false;
            }
            else if (btnSave.Text == "Dar Baixa")
            {
                // Bloqueia a chave primária e dados da nota
                txtCodigo.Enabled = false;
                txtSerie.Enabled = false;
                txtNumDaNota.Enabled = false;
                btnPesquisarFornecedor.Enabled = false;
                txtNumParcela.Enabled = false;
                dtpDataEmissao.Enabled = false;
                dtpDataVencimento.Enabled = false;
                txtValorParcela.Enabled = false;
                checkBoxAtivo.Enabled = false; 
                txtCodFornecedor.Enabled = false;
                txtFornecedor.Enabled = false;
                btnSave.Visible = true;

                // Habilita campos da baixa
                txtJuros.Enabled = true;
                txtMulta.Enabled = true;
                txtDesconto.Enabled = true;
                btnPesquisarFormaPagamento.Enabled = true;
                dtpDataPagamento.Enabled = true;

                // Campos de baixa ficam visíveis
                dtpDataPagamento.Visible = true;
                txtValorPago.Visible = true;
                lblDataPagamento.Visible = true;
                lblValorFinal.Visible = true;

                dtpDataPagamento.Checked = true;
                RecalcularValorPago(null, null); 
            }
        }

        public override bool ValidacaoCampos()
        {
            base.ValidacaoCampos();

            if (btnSave.Text == "Salvar")
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtCodFornecedor.Text) ||
                    string.IsNullOrWhiteSpace(txtNumParcela.Text) ||
                    string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text) ||
                    string.IsNullOrWhiteSpace(txtValorParcela.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios (*).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (btnSave.Text == "Dar Baixa")
            {
                if (!dtpDataPagamento.Checked)
                {
                    MessageBox.Show("Selecione uma data de pagamento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text))
                {
                    MessageBox.Show("Selecione a forma de pagamento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!decimal.TryParse(txtValorPago.Text, out decimal valorPago) || valorPago <= 0)
                {
                    MessageBox.Show("O Valor Final (Pago) deve ser maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorPago.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnPesquisarFornecedor_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaFornecedor == null)
                oFrmConsultaFornecedor = new frmConsultaFornecedor();

            fornecedor forn = new fornecedor();
            Controller_fornecedor controller = new Controller_fornecedor();
            oFrmConsultaFornecedor.ConhecaObj(forn, controller);
            oFrmConsultaFornecedor.ShowDialog();

            if (forn.Id != 0)
            {
                oContaAPagar.OFornecedor = forn;
                txtCodFornecedor.Text = forn.Id.ToString();
                txtFornecedor.Text = forn.Nome_razaoSocial;
            }
        }

        private void btnPesquisarFormaPagamento_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaFormaPagamento == null)
                oFrmConsultaFormaPagamento = new frmConsultaFormaPagamento();

            formaPagamento forma = new formaPagamento();
            Controller_formaPagamento controller = new Controller_formaPagamento();
            oFrmConsultaFormaPagamento.ConhecaObj(forma, controller);
            oFrmConsultaFormaPagamento.ShowDialog();

            if (forma.Id != 0)
            {
                oContaAPagar.AFormaPagamento = forma;
                txtCodFormaPagamento.Text = forma.Id.ToString();
                txtFormaPagamento.Text = forma.Descricao;
            }
        }

        private void dtpDataPagamento_ValueChanged(object sender, EventArgs e)
        {
            RecalcularValorPago(sender, e);
        }

        private void RecalcularValorPago(object sender, EventArgs e)
        {
            if (btnSave.Text != "Dar Baixa")
            {
                if (sender == dtpDataPagamento && !dtpDataPagamento.Checked)
                {
                    txtValorPago.Text = "0,00";
                }
                return;
            }

            decimal.TryParse(txtValorParcela.Text, out decimal valorParcela);
            decimal.TryParse(txtJuros.Text, out decimal juros);
            decimal.TryParse(txtMulta.Text, out decimal multa);
            decimal.TryParse(txtDesconto.Text, out decimal desconto);

            decimal total = valorParcela;

            // Juros (influencia sempre, se houver)
            total += (valorParcela * (juros / 100));

            if (dtpDataPagamento.Checked)
            {
                // Multa (só se data pagto > vencimento)
                if (dtpDataPagamento.Value.Date > dtpDataVencimento.Value.Date)
                {
                    total += (valorParcela * (multa / 100));
                }
                // Desconto (só se data pagto <= vencimento)
                else
                {
                    total -= (valorParcela * (desconto / 100));
                }
            }
            else
            {
                // Se desmarcar a data, zera o valor pago
                total = 0;
            }

            txtValorPago.Text = total.ToString("F2");
        }

        // Pop-up de confirmação para "Dar Baixa"
        private bool ConfirmarBaixa()
        {
            string dataPagto = dtpDataPagamento.Value.ToShortDateString();
            string valorFinal = txtValorPago.Text;

            string mensagem = $"Confirma a baixa desta conta?\n\n" +
                              $"Data do Pagamento: {dataPagto}\n" +
                              $"Valor Final: R$ {valorFinal}";

            DialogResult resp = MessageBox.Show(mensagem, "Confirmar Baixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resp == DialogResult.Yes;
        }

        // Pop-up para solicitar motivo do cancelamento
        private string SolicitarMotivoCancelamento()
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

                Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = "Para cancelar esta conta, digite o motivo (mínimo 20 caracteres)." };
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
                    return textBox.Text.Trim();
                }
                else
                {
                    return null;
                }
            }
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtCodigo.MaxLength = 2;
            txtSerie.MaxLength = 3;
            txtNumDaNota.MaxLength = 9;
            txtNumParcela.MaxLength = 10;
            txtValorParcela.MaxLength = 11;
            txtJuros.MaxLength = 11;
            txtMulta.MaxLength = 11;
            txtDesconto.MaxLength = 11;
            txtValorPago.MaxLength = 11;



            txtCodigo.KeyPress -= ApenasNumeros;
            txtCodigo.KeyPress += ApenasNumeros;

            txtSerie.KeyPress -= ApenasNumeros;
            txtSerie.KeyPress += ApenasNumeros;

            txtNumDaNota.KeyPress -= ApenasNumeros;
            txtNumDaNota.KeyPress += ApenasNumeros;

            txtNumParcela.KeyPress -= ApenasNumeros;
            txtNumParcela.KeyPress += ApenasNumeros;

            txtValorParcela.KeyPress -= ApenasNumerosDecimal;
            txtValorParcela.KeyPress += ApenasNumerosDecimal;

            txtJuros.KeyPress -= ApenasNumerosDecimal;
            txtJuros.KeyPress += ApenasNumerosDecimal;

            txtMulta.KeyPress -= ApenasNumerosDecimal;
            txtMulta.KeyPress += ApenasNumerosDecimal;

            txtDesconto.KeyPress -= ApenasNumerosDecimal;
            txtDesconto.KeyPress += ApenasNumerosDecimal;

            txtValorPago.KeyPress -= ApenasNumerosDecimal;
            txtValorPago.KeyPress += ApenasNumerosDecimal;
        }
    }
}
using MySql.Data.MySqlClient;
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.dao;
using projeto_patrica.pages.consulta;
using System;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroContasAReceber : projeto_patrica.pages.cadastro.frmCadastro
    {
        private contasAReceber oContaAReceber;
        private Controller_contasAReceber aController_contasAReceber;
        private frmConsultaCliente oFrmConsultaCliente;
        private frmConsultaFormaPagamento oFrmConsultaFormaPagamento;
        private Dao_venda aDao_venda;

        public frmCadastroContasAReceber()
        {
            InitializeComponent();
            dtpDataEmissao.MaxDate = DateTime.Today;
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            aDao_venda = new Dao_venda();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaAReceber = (contasAReceber)obj;
            aController_contasAReceber = (Controller_contasAReceber)ctrl;
        }

        public void setConsultaCliente(frmConsultaCliente consulta)
        {
            oFrmConsultaCliente = consulta;
        }

        public void setConsultaFormaPagamento(frmConsultaFormaPagamento consulta)
        {
            oFrmConsultaFormaPagamento = consulta;
        }

        public override void Salvar()
        {
            // O modo "Salvar" (novo) foi removido. Este form só lida com Dar Baixa, Visualizar ou Cancelar.

            try
            {
                if (btnSave.Text == "Cancelar Conta")
                {
                    string motivo = SolicitarMotivoCancelamento();
                    if (string.IsNullOrEmpty(motivo)) return;

                    oContaAReceber.Ativo = false;
                    oContaAReceber.MotivoCancelamento = motivo;
                    oContaAReceber.DataUltimaEdicao = DateTime.Now;

                    aController_contasAReceber.Salvar(oContaAReceber);
                    MessageBox.Show("Conta a Receber cancelada com sucesso.");
                }
                else if (btnSave.Text == "Dar Baixa")
                {
                    AtualizarValorPagoFinal();
                    if (!ValidacaoCampos())
                        return;

                    if (ConfirmarBaixa())
                    {
                        oContaAReceber.Juros = Convert.ToDecimal(txtJuros.Text);
                        oContaAReceber.Multa = Convert.ToDecimal(txtMulta.Text);
                        oContaAReceber.Desconto = Convert.ToDecimal(txtDesconto.Text);
                        oContaAReceber.JurosValor = Convert.ToDecimal(txtJurosReais.Text);
                        oContaAReceber.MultaValor = Convert.ToDecimal(txtMultaReais.Text);
                        oContaAReceber.DescontoValor = Convert.ToDecimal(txtDescontoReais.Text);
                        oContaAReceber.Situacao = 1; // 1 = Pago
                        oContaAReceber.ValorPago = Convert.ToDecimal(txtValorPago.Text);
                        oContaAReceber.DataPagamento = dtpDataPagamento.Value;
                        oContaAReceber.DataUltimaEdicao = DateTime.Now;
                        oContaAReceber.Ativo = true;

                        aController_contasAReceber.Salvar(oContaAReceber);
                        MessageBox.Show("Conta a Receber baixada com sucesso.");
                    }
                    else
                    {
                        return;
                    }
                }

                base.Salvar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Não foi possível concluir a operação. Verifique os dados e tente novamente.\n\nDetalhes técnicos: " + ex.Message,
                    "Erro no Banco de Dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
            txtCodigo.Clear(); // Modelo
            txtSerie.Clear();
            txtNumDaNota.Clear();
            txtCodCliente.Clear();
            txtCliente.Clear();
            txtNumParcela.Clear();
            dtpDataEmissao.Value = DateTime.Today;
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            dtpDataVencimento.Value = DateTime.Today;
            txtValorParcela.Text = "0,00";
            txtFormaPagamento.Clear();
            txtCodFormaPagamento.Clear();
            txtJuros.Text = "0,00";
            txtMulta.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtJurosReais.Text = "0,00";
            txtMultaReais.Text = "0,00";
            txtDescontoReais.Text = "0,00";
            txtValorPago.Text = "0,00";
            dtpDataPagamento.Value = DateTime.Today;
            dtpDataPagamento.Checked = false;

            lblMotivoCancelamentoTitulo.Visible = false;
            lblMotivCancelamentoExplicacao.Visible = false;

            oContaAReceber = new contasAReceber();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = oContaAReceber.ModeloVenda.ToString();
            txtSerie.Text = oContaAReceber.SerieVenda;
            txtNumDaNota.Text = oContaAReceber.NumeroNotaVenda;
            txtCodCliente.Text = oContaAReceber.OCliente.Id.ToString();
            txtNumParcela.Text = oContaAReceber.NumeroParcela.ToString();
            aController_contasAReceber.AController_cliente.CarregaObj(oContaAReceber.OCliente);
            txtCliente.Text = oContaAReceber.OCliente.Nome_razaoSocial;
            aController_contasAReceber.AController_formaPagamento.CarregaObj(oContaAReceber.AFormaPagamento);
            txtFormaPagamento.Text = oContaAReceber.AFormaPagamento.Descricao;
            txtCodFormaPagamento.Text = oContaAReceber.AFormaPagamento.Id.ToString();
            dtpDataEmissao.Value = oContaAReceber.DataEmissao;
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            dtpDataVencimento.Value = oContaAReceber.DataVencimento;

            if (oContaAReceber.DataPagamento.HasValue)
            {
                dtpDataPagamento.Value = oContaAReceber.DataPagamento.Value;
                dtpDataPagamento.Checked = true;
            }
            else
            {
                dtpDataPagamento.Value = DateTime.Today;
                dtpDataPagamento.Checked = false;
            }

            txtValorParcela.Text = oContaAReceber.ValorParcela.ToString("F2");
            txtJuros.Text = oContaAReceber.Juros.ToString("F2");
            txtMulta.Text = oContaAReceber.Multa.ToString("F2");
            txtDesconto.Text = oContaAReceber.Desconto.ToString("F2");
            txtJurosReais.Text = oContaAReceber.JurosValor.HasValue ? oContaAReceber.JurosValor.Value.ToString("F2") : "0,00";
            txtMultaReais.Text = oContaAReceber.MultaValor.HasValue ? oContaAReceber.MultaValor.Value.ToString("F2") : "0,00";
            txtDescontoReais.Text = oContaAReceber.DescontoValor.HasValue ? oContaAReceber.DescontoValor.Value.ToString("F2") : "0,00";
            txtValorPago.Text = oContaAReceber.ValorPago.HasValue ? oContaAReceber.ValorPago.Value.ToString("F2") : "0,00";
            checkBoxAtivo.Checked = oContaAReceber.Ativo;

            checkBoxAtivo.Text = checkBoxAtivo.Checked ? "Ativo" : "Cancelado";
            lblDataCadastroData.Text = oContaAReceber.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oContaAReceber.DataUltimaEdicao?.ToString("dd/MM/yyyy HH:mm") ?? " ";

            lblMotivoCancelamentoTitulo.Visible = !oContaAReceber.Ativo;
            lblMotivCancelamentoExplicacao.Visible = !oContaAReceber.Ativo;
            lblMotivCancelamentoExplicacao.Text = oContaAReceber.MotivoCancelamento ?? "";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            txtCodCliente.Enabled = false;
            txtCliente.Enabled = false;
            btnPesquisarCliente.Enabled = false;
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
            txtJurosReais.Enabled = false;
            txtMultaReais.Enabled = false;
            txtDescontoReais.Enabled = false;
            txtValorPago.Enabled = false;
            dtpDataPagamento.Enabled = false;

            if (btnSave.Text == "Visualizar")
            {
                btnSave.Visible = false;

                bool pago = oContaAReceber.Situacao == 1;
                dtpDataPagamento.Visible = pago;
                txtValorPago.Visible = pago;
                lblDataPagamento.Visible = pago;
                lblValorFinal.Visible = pago;
                txtJurosReais.Visible = pago;
                txtMultaReais.Visible = pago;
                txtDescontoReais.Visible = pago;
                lblJurosReais.Visible = pago;
                lblMultaReais.Visible = pago;
                lblDescontoReais.Visible = pago;

                bool cancelado = !oContaAReceber.Ativo;
                lblMotivoCancelamentoTitulo.Visible = cancelado;
                lblMotivCancelamentoExplicacao.Visible = cancelado;
            }
            else if (btnSave.Text == "Cancelar Conta")
            {
                btnSave.Visible = true;
                dtpDataPagamento.Visible = false;
                txtValorPago.Visible = false;
                lblDataPagamento.Visible = false;
                lblValorFinal.Visible = false;
                txtJurosReais.Visible = false;
                txtMultaReais.Visible = false;
                txtDescontoReais.Visible = false;
                lblJurosReais.Visible = false;
                lblMultaReais.Visible = false;
                lblDescontoReais.Visible = false;
            }
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            // O modo "Salvar" (novo) não existe mais
            if (btnSave.Text == "Dar Baixa")
            {
                txtCodigo.Enabled = false;
                txtSerie.Enabled = false;
                txtNumDaNota.Enabled = false;
                btnPesquisarCliente.Enabled = false;
                txtNumParcela.Enabled = false;
                dtpDataEmissao.Enabled = false;
                dtpDataVencimento.Enabled = false;
                txtValorParcela.Enabled = false;
                checkBoxAtivo.Enabled = false;
                txtCodCliente.Enabled = false;
                txtCliente.Enabled = false;
                btnSave.Visible = true;
                txtCodFormaPagamento.Enabled = true;
                txtFormaPagamento.Enabled = true;

                txtJuros.Enabled = false;
                txtMulta.Enabled = false;
                txtDesconto.Enabled = false;
                txtJurosReais.Enabled = true;
                txtMultaReais.Enabled = true;
                txtDescontoReais.Enabled = true;
                btnPesquisarFormaPagamento.Enabled = true;
                dtpDataPagamento.Enabled = true;
                txtValorPago.Enabled = false;

                dtpDataPagamento.Visible = true;
                txtValorPago.Visible = true;
                lblDataPagamento.Visible = true;
                lblValorFinal.Visible = true;
                txtJurosReais.Visible = true;
                txtMultaReais.Visible = true;
                txtDescontoReais.Visible = true;
                lblJurosReais.Visible = true;
                lblMultaReais.Visible = true;
                lblDescontoReais.Visible = true;

                dtpDataPagamento.MinDate = dtpDataEmissao.Value.Date;
                dtpDataPagamento.MaxDate = DateTime.Today;

                if (DateTime.Today < dtpDataPagamento.MinDate)
                {
                    dtpDataPagamento.Value = dtpDataPagamento.MinDate;
                }
                else
                {
                    dtpDataPagamento.Value = DateTime.Today;
                }

                dtpDataPagamento.Checked = true;
                CalcularValoresReaisAutomaticamente();
                AtualizarValorPagoFinal();
            }
        }

        public override bool ValidacaoCampos()
        {
            base.ValidacaoCampos();

            if (btnSave.Text == "Dar Baixa")
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
                if (!decimal.TryParse(txtValorPago.Text, out decimal valorPago) || valorPago < 0)
                {
                    MessageBox.Show("O Valor Final (Pago) não pode ser negativo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorPago.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCliente == null)
                oFrmConsultaCliente = new frmConsultaCliente();

            cliente cli = new cliente();
            Controller_cliente controller = new Controller_cliente();
            oFrmConsultaCliente.ConhecaObj(cli, controller);
            oFrmConsultaCliente.ShowDialog();

            if (cli.Id != 0)
            {
                oContaAReceber.OCliente = cli;
                txtCodCliente.Text = cli.Id.ToString();
                txtCliente.Text = cli.Nome_razaoSocial;
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
                oContaAReceber.AFormaPagamento = forma;
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

            if (sender == dtpDataPagamento)
            {
                CalcularValoresReaisAutomaticamente();
            }

            AtualizarValorPagoFinal();
        }

        private void CalcularValoresReaisAutomaticamente()
        {
            decimal.TryParse(txtValorParcela.Text, out decimal valorParcela);
            decimal.TryParse(txtJuros.Text, out decimal jurosPerc);
            decimal.TryParse(txtMulta.Text, out decimal multaPerc);
            decimal.TryParse(txtDesconto.Text, out decimal descontoPerc);

            if (dtpDataPagamento.Checked)
            {
                if (dtpDataPagamento.Value.Date > dtpDataVencimento.Value.Date)
                {
                    TimeSpan diasAtraso = dtpDataPagamento.Value.Date - dtpDataVencimento.Value.Date;
                    txtMultaReais.Text = (valorParcela * (multaPerc / 100)).ToString("F2");
                    txtJurosReais.Text = (valorParcela * (jurosPerc / 100) * diasAtraso.Days).ToString("F2");
                    txtDescontoReais.Text = "0,00";
                }
                else
                {
                    txtMultaReais.Text = "0,00";
                    txtJurosReais.Text = "0,00";
                    txtDescontoReais.Text = (valorParcela * (descontoPerc / 100)).ToString("F2");
                }
            }
            else
            {
                txtMultaReais.Text = "0,00";
                txtJurosReais.Text = "0,00";
                txtDescontoReais.Text = "0,00";
            }
        }

        private void AtualizarValorPagoFinal_Handler(object sender, EventArgs e)
        {
            AtualizarValorPagoFinal();
        }


        private void AtualizarValorPagoFinal()
        {
            decimal.TryParse(txtValorParcela.Text, out decimal valorParcela);
            decimal.TryParse(txtJurosReais.Text, out decimal jurosValor);
            decimal.TryParse(txtMultaReais.Text, out decimal multaValor);
            decimal.TryParse(txtDescontoReais.Text, out decimal descontoValor);

            decimal total = valorParcela + jurosValor + multaValor - descontoValor;
            txtValorPago.Text = total.ToString("F2");
        }


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

        private void DtpDataEmissao_ValueChanged(object sender, EventArgs e)
        {
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            if (dtpDataVencimento.Value < dtpDataVencimento.MinDate)
            {
                dtpDataVencimento.Value = dtpDataVencimento.MinDate;
            }
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtCodigo.MaxLength = 2;
            txtSerie.MaxLength = 4;
            txtNumDaNota.MaxLength = 9;
            txtNumParcela.MaxLength = 10;
            txtValorParcela.MaxLength = 11;
            txtJuros.MaxLength = 20;
            txtMulta.MaxLength = 20;
            txtDesconto.MaxLength = 20;
            txtJurosReais.MaxLength = 11;
            txtMultaReais.MaxLength = 11;
            txtDescontoReais.MaxLength = 11;
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

            txtJurosReais.KeyPress -= ApenasNumerosDecimal;
            txtJurosReais.KeyPress += ApenasNumerosDecimal;

            txtMultaReais.KeyPress -= ApenasNumerosDecimal;
            txtMultaReais.KeyPress += ApenasNumerosDecimal;

            txtDescontoReais.KeyPress -= ApenasNumerosDecimal;
            txtDescontoReais.KeyPress += ApenasNumerosDecimal;

            txtValorPago.KeyPress -= ApenasNumerosDecimal;
            txtValorPago.KeyPress += ApenasNumerosDecimal;
        }
    }
}
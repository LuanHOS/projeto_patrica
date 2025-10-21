using MySql.Data.MySqlClient;
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
            if (btnSave.Text == "Excluir")
            {
                DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        aController_contasAPagar.Excluir(oContaAPagar);
                        MessageBox.Show("Conta a Pagar excluída com sucesso.");
                        Sair();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Não foi possível excluir o item.\n\nDetalhes técnicos: " + ex.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                return;
            }

            if (!ValidacaoCampos())
                return;

            // Preenche o objeto com os dados da tela
            oContaAPagar.ModeloCompra = Convert.ToInt32(txtCodigo.Text); // txtCodigo é o Modelo
            oContaAPagar.SerieCompra = txtSerie.Text;
            oContaAPagar.NumeroNotaCompra = txtNumDaNota.Text;
            oContaAPagar.OFornecedor.Id = Convert.ToInt32(txtCodFornecedor.Text);
            oContaAPagar.NumeroParcela = Convert.ToInt32(txtNumParcela.Text);
            oContaAPagar.DataEmissao = dtpDataEmissao.Value;
            oContaAPagar.DataVencimento = dtpDataVencimento.Value;
            oContaAPagar.ValorParcela = Convert.ToDecimal(txtValorParcela.Text);
            oContaAPagar.Ativo = checkBoxAtivo.Checked;
            oContaAPagar.Juros = Convert.ToDecimal(txtJuros.Text);
            oContaAPagar.Multa = Convert.ToDecimal(txtMulta.Text);
            oContaAPagar.Desconto = Convert.ToDecimal(txtDesconto.Text);

            if (oContaAPagar.AFormaPagamento == null || oContaAPagar.AFormaPagamento.Id == 0)
            {
                oContaAPagar.AFormaPagamento = new formaPagamento { Id = Convert.ToInt32(txtCodFormaPagamento.Text) };
            }
            if (oContaAPagar.OFornecedor == null || oContaAPagar.OFornecedor.Id == 0)
            {
                oContaAPagar.OFornecedor = new fornecedor { Id = Convert.ToInt32(txtCodFornecedor.Text) };
            }

            // Define Situação, ValorPago e DataPagamento baseado na interação
            if (dtpDataPagamento.Checked && decimal.TryParse(txtValorPago.Text, out decimal valorPago) && valorPago > 0)
            {
                oContaAPagar.Situacao = 1; // Pago
                oContaAPagar.ValorPago = valorPago;
                oContaAPagar.DataPagamento = dtpDataPagamento.Value;
            }
            else
            {
                oContaAPagar.Situacao = 0; // Em Aberto
                oContaAPagar.ValorPago = null;
                oContaAPagar.DataPagamento = null;
            }

            // Os CheckBoxes checkBoxMulta, checkBoxJuros, checkBoxDesconto parecem ser para outra lógica (cálculo),
            // que não afeta o 'Salvar' diretamente no banco (os valores de juros/multa/desconto vêm dos TextBoxes).

            try
            {
                string msgSucesso = "";
                if (btnSave.Text == "Alterar")
                {
                    aController_contasAPagar.Salvar(oContaAPagar);
                    msgSucesso = "Conta a Pagar alterada com sucesso.";
                }
                else // "Salvar"
                {
                    aController_contasAPagar.Salvar(oContaAPagar);
                    msgSucesso = "Conta a Pagar salva com sucesso.";
                }

                MessageBox.Show(msgSucesso, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                base.Salvar(); // Fecha o formulário
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1062: // Chave duplicada (PK composta)
                        MessageBox.Show(
                            "Não foi possível salvar.\n\nJá existe uma parcela com este Modelo, Série, Número da Nota, Fornecedor e Número de Parcela.",
                            "Erro: Item duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;
                    case 1451: // Chave estrangeira
                        MessageBox.Show(
                            "Não foi possível salvar.\n\nO Fornecedor ou Forma de Pagamento especificado não existe.",
                            "Erro: Referência inválida",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;
                    default: // Outros erros
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
            txtCodigo.Text = "0";
            txtSerie.Clear();
            txtNumDaNota.Clear();
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            txtNumParcela.Clear();
            dtpDataEmissao.Value = DateTime.Today;
            dtpDataVencimento.Value = DateTime.Today;
            txtValorParcela.Text = "0,00";
            txtFormaPagamento.Clear();
            txtCodFormaPagamento.Clear();
            txtSituacao.Text = "0"; // 0 = Em Aberto
            txtJuros.Text = "0,00";
            txtMulta.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtValorPago.Text = "0,00"; 
            dtpDataPagamento.Value = DateTime.Today;
            dtpDataPagamento.Checked = false;
            checkBoxJuros.Checked = false;
            checkBoxMulta.Checked = false;
            checkBoxDesconto.Checked = false;

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

            if (oContaAPagar.OFornecedor.Id > 0)
            {
                aController_contasAPagar.AController_fornecedor.CarregaObj(oContaAPagar.OFornecedor);
                txtFornecedor.Text = oContaAPagar.OFornecedor.Nome_razaoSocial;
            }
            if (oContaAPagar.AFormaPagamento.Id > 0)
            {
                aController_contasAPagar.AController_formaPagamento.CarregaObj(oContaAPagar.AFormaPagamento);
                txtFormaPagamento.Text = oContaAPagar.AFormaPagamento.Descricao;
                txtCodFormaPagamento.Text = oContaAPagar.AFormaPagamento.Id.ToString();
            }





            dtpDataEmissao.Value =
                (oContaAPagar.DataEmissao >= dtpDataEmissao.MinDate && oContaAPagar.DataEmissao <= dtpDataEmissao.MaxDate)
                ? oContaAPagar.DataEmissao
                : DateTime.Today;

            dtpDataVencimento.Value =
                (oContaAPagar.DataVencimento >= dtpDataVencimento.MinDate && oContaAPagar.DataVencimento <= dtpDataVencimento.MaxDate)
                ? oContaAPagar.DataVencimento
                : DateTime.Today;

            if (oContaAPagar.DataPagamento.HasValue &&
                oContaAPagar.DataPagamento.Value >= dtpDataPagamento.MinDate &&
                oContaAPagar.DataPagamento.Value <= dtpDataPagamento.MaxDate)
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
            txtSituacao.Text = oContaAPagar.Situacao.ToString(); // 0 ou 1

            txtValorPago.Text = oContaAPagar.ValorPago.HasValue ? oContaAPagar.ValorPago.Value.ToString("F2") : "0,00";
            dtpDataPagamento.Value = oContaAPagar.DataPagamento.HasValue ? oContaAPagar.DataPagamento.Value : DateTime.Today;
            dtpDataPagamento.Checked = oContaAPagar.DataPagamento.HasValue;

            checkBoxJuros.Checked = false; 
            checkBoxMulta.Checked = false;
            checkBoxDesconto.Checked = false;

            checkBoxAtivo.Checked = oContaAPagar.Ativo;
            lblDataCadastroData.Text = "-";
            lblDataUltimaEdicaoData.Text = "-";
            lblUltimoUsuarioQueEditouNome.Text = "-";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
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
            txtSituacao.Enabled = false;
            txtJuros.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;
            txtValorPago.Enabled = false;
            dtpDataPagamento.Enabled = false;
            checkBoxJuros.Enabled = false;
            checkBoxMulta.Enabled = false;
            checkBoxDesconto.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            bool inclusao = (btnSave.Text == "Salvar");

            
            txtSerie.Enabled = inclusao;
            txtNumDaNota.Enabled = inclusao;
            txtCodFornecedor.Enabled = inclusao;
            btnPesquisarFornecedor.Enabled = inclusao;
            txtNumParcela.Enabled = inclusao;

            dtpDataEmissao.Enabled = true;
            dtpDataVencimento.Enabled = true;
            txtValorParcela.Enabled = true;
            btnPesquisarFormaPagamento.Enabled = true;
            txtSituacao.Enabled = false; 
            txtJuros.Enabled = true;
            txtMulta.Enabled = true;
            txtDesconto.Enabled = true;
            txtValorPago.Enabled = true;
            dtpDataPagamento.Enabled = true;
            checkBoxJuros.Enabled = true;
            checkBoxMulta.Enabled = true;
            checkBoxDesconto.Enabled = true;
        }

        public override bool ValidacaoCampos()
        {
            base.ValidacaoCampos();

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text) ||
                string.IsNullOrWhiteSpace(txtNumDaNota.Text) ||
                string.IsNullOrWhiteSpace(txtCodFornecedor.Text) ||
                string.IsNullOrWhiteSpace(txtNumParcela.Text) ||
                string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios (Modelo, Série, Nota, Fornecedor, Parcela, Forma Pag.).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpDataPagamento.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtValorPago.Text) || !decimal.TryParse(txtValorPago.Text, out decimal valorPago) || valorPago <= 0)
                {
                    MessageBox.Show("Se a Data de Pagamento está marcada, o Valor Final (Pago) deve ser preenchido e maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorPago.Focus();
                    return false;
                }
            }

            return true;
        }

        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtSerie.MaxLength = 3;
            txtNumDaNota.MaxLength = 9;
            txtNumParcela.MaxLength = 10;
            txtValorParcela.MaxLength = 11;
            txtJuros.MaxLength = 11;
            txtMulta.MaxLength = 11;
            txtDesconto.MaxLength = 11;
            txtValorPago.MaxLength = 11;

            txtNumParcela.KeyPress += ApenasNumeros;
            txtNumDaNota.KeyPress += ApenasNumeros;

            txtValorParcela.KeyPress += ApenasNumerosDecimal;
            txtJuros.KeyPress += ApenasNumerosDecimal;
            txtMulta.KeyPress += ApenasNumerosDecimal;
            txtDesconto.KeyPress += ApenasNumerosDecimal;
            txtValorPago.KeyPress += ApenasNumerosDecimal;
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
                oContaAPagar.OFornecedor.Id = forn.Id;
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
            if (dtpDataPagamento.Checked)
            {
                txtSituacao.Text = "1"; // Pago
                if (string.IsNullOrWhiteSpace(txtValorPago.Text) || txtValorPago.Text == "0,00")
                {
                    txtValorPago.Text = txtValorParcela.Text;
                }
            }
            else
            {
                txtSituacao.Text = "0"; // Em Aberto
                txtValorPago.Text = "0,00";
            }
        }
    }
}
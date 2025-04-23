using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroCondicaoPagamento : projeto_patrica.pages.cadastro.frmCadastro
    {
        private frmConsultaFormaPagamento oFrmConFormPag;
        private condicaoPagamento aCondicaoPagamento;
        private Controller_condicaoPagamento aController_condicaoPagamento;
        private List<parcelaCondicaoPagamento> listaParcelas = new List<parcelaCondicaoPagamento>();
        private bool editandoParcela = false;
        private int indiceParcelaEditando = -1;

        public frmCadastroCondicaoPagamento() : base()
        {
            InitializeComponent();
            CarregarFormasDePagamento();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCondicaoPagamento = (condicaoPagamento)obj;
            aController_condicaoPagamento = (Controller_condicaoPagamento)ctrl;
        }

        public override void Salvar()
        {
            if (
                string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtQtdParcelas.Text) ||
                !int.TryParse(txtQtdParcelas.Text, out int qtdInformada) ||
                listaParcelas.Count != qtdInformada
            )
            {
                txtDescricao.Focus();
                txtQtdParcelas.Focus();
                listVParcelas.Focus();

                if (!int.TryParse(txtQtdParcelas.Text, out qtdInformada) || listaParcelas.Count != qtdInformada)
                    MessageBox.Show("A quantidade de parcelas informada não corresponde à quantidade de parcelas na lista. Verifique antes de salvar.");
                else
                    MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");

                return;
            }

            decimal totalPercentual = 0;
            foreach (var parcela in listaParcelas)
            {
                totalPercentual += parcela.ValorPercentual;
            }

            if (totalPercentual != 100)
            {
                MessageBox.Show("A soma das porcentagens das parcelas deve ser exatamente 100%. Ajuste os valores antes de salvar.");
                listVParcelas.Focus();
                return;
            }

            aCondicaoPagamento.Id = Convert.ToInt32(txtCodigo.Text);
            aCondicaoPagamento.Descricao = txtDescricao.Text;
            aCondicaoPagamento.QuantidadeParcelas = Convert.ToInt32(txtQtdParcelas.Text);
            aCondicaoPagamento.Multa = Convert.ToDecimal(txtMulta.Text);
            aCondicaoPagamento.Juros = Convert.ToDecimal(txtJuros.Text);
            aCondicaoPagamento.Desconto = Convert.ToDecimal(txtDesconto.Text);
            aCondicaoPagamento.Parcelas = listaParcelas;
            aCondicaoPagamento.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_condicaoPagamento.Excluir(aCondicaoPagamento);
                        MessageBox.Show("A condição de pagamento \"" + aCondicaoPagamento.Descricao + "\" foi excluída com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_condicaoPagamento.Salvar(aCondicaoPagamento);
                    MessageBox.Show("A condição de pagamento \"" + aCondicaoPagamento.Descricao + "\" foi alterada com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_condicaoPagamento.Salvar(aCondicaoPagamento);
                    MessageBox.Show("A condição de pagamento \"" + aCondicaoPagamento.Descricao + "\" foi salva com o código " + txtCodigo.Text + ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível concluir a operação. Verifique os dados e tente novamente.\n\nDetalhes técnicos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            base.Salvar();
        }




        public override void Limpartxt()
        {
            base.Limpartxt();

            txtDescricao.Clear();
            txtQtdParcelas.Text = "1";
            txtJuros.Clear();
            txtMulta.Clear();
            txtDesconto.Clear();
            listaParcelas.Clear();
            listVParcelas.Items.Clear();
            LimparCamposParcela();
        }


        public override void Carregatxt()
        {
            base.Carregatxt();

            txtCodigo.Text = aCondicaoPagamento.Id.ToString();
            txtDescricao.Text = aCondicaoPagamento.Descricao;
            txtQtdParcelas.Text = aCondicaoPagamento.QuantidadeParcelas.ToString();
            txtMulta.Text = aCondicaoPagamento.Multa.ToString("F2");
            txtJuros.Text = aCondicaoPagamento.Juros.ToString("F2");
            txtDesconto.Text = aCondicaoPagamento.Desconto.ToString("F2");
            checkBoxAtivo.Checked = aCondicaoPagamento.Ativo;
            lblDataCadastroData.Text = aCondicaoPagamento.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = aCondicaoPagamento.DataUltimaEdicao?.ToShortDateString() ?? " ";

            if (btnSave.Text == "Alterar" || btnSave.Text == "Excluir")
                CarregarParcelasDoBanco();
            else
                CarregarParcelasNaListView();
        }


        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();

            txtDescricao.Enabled = false;
            txtQtdParcelas.Enabled = false;
            btnPesquisarFormaPagamento.Enabled = false;
            txtMulta.Enabled = false;
            txtJuros.Enabled = false;
            txtDesconto.Enabled = false;
            BloquearCamposParcela();
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();

            txtDescricao.Enabled = true;
            txtQtdParcelas.Enabled = true;
            btnPesquisarFormaPagamento.Enabled = true;
            txtMulta.Enabled = true;
            txtJuros.Enabled = true;
            txtDesconto.Enabled = true; 
            DesbloquearCamposParcela();
        }

        private void CarregarParcelasNaListView()
        {
            listVParcelas.Items.Clear();
            Controller_formaPagamento controllerFormaPagamento = new Controller_formaPagamento();

            foreach (var parcela in listaParcelas)
            {
                var formaPagamento = controllerFormaPagamento.CarregaPorId(parcela.AFormaPagamento.Id);
                var item = new ListViewItem(parcela.NumeroParcela.ToString());
                item.SubItems.Add(formaPagamento?.Descricao ?? "Desconhecida");
                item.SubItems.Add(parcela.ValorPercentual.ToString("F2"));
                item.SubItems.Add(parcela.DiasAposVenda.ToString());
                listVParcelas.Items.Add(item);
            }

            AtualizarPorcentagemTotal();

        }

        private void btnAdicionarParcela_Click(object sender, EventArgs e)
        {
            if (ValidarCamposParcela())
            {
                var parcela = new parcelaCondicaoPagamento
                {
                    NumeroParcela = Convert.ToInt32(txtNumParcela.Text),
                    AFormaPagamento = (formaPagamento)comboBoxFormaPagamento.SelectedItem,
                    ValorPercentual = Convert.ToDecimal(txtPercentualParcela.Text),
                    DiasAposVenda = Convert.ToInt32(txtPrazoDias.Text)
                };

                listaParcelas.Add(parcela);
                CarregarParcelasNaListView();
                LimparCamposParcela();
            }

            AtualizarPorcentagemTotal();

        }

        private void btnEditarParcela_Click(object sender, EventArgs e)
        {
            if (editandoParcela)
            {
                if (ValidarCamposParcela())
                {
                    var parcela = listaParcelas[indiceParcelaEditando];
                    parcela.NumeroParcela = Convert.ToInt32(txtNumParcela.Text);
                    parcela.AFormaPagamento = (formaPagamento)comboBoxFormaPagamento.SelectedItem;
                    parcela.ValorPercentual = Convert.ToDecimal(txtPercentualParcela.Text);
                    parcela.DiasAposVenda = Convert.ToInt32(txtPrazoDias.Text);

                    CarregarParcelasNaListView();
                    LimparCamposParcela();
                    FinalizarEdicaoParcela();
                }
            }
            else
            {
                if (listVParcelas.SelectedItems.Count > 0)
                {
                    indiceParcelaEditando = listVParcelas.SelectedItems[0].Index;
                    var parcela = listaParcelas[indiceParcelaEditando];

                    txtNumParcela.Text = parcela.NumeroParcela.ToString();
                    comboBoxFormaPagamento.SelectedValue = parcela.AFormaPagamento.Id;
                    txtPercentualParcela.Text = parcela.ValorPercentual.ToString("F2");
                    txtPrazoDias.Text = parcela.DiasAposVenda.ToString();

                    btnAdicionarParcela.Enabled = false;
                    btnAdicionarParcela.Visible = false;

                    btnEditarParcela.Text = "Salvar";
                    btnRemoverParcela.Text = "Cancelar";
                    editandoParcela = true;
                }
                else
                {
                    MessageBox.Show("Selecione uma parcela para editar.");
                }
            }

            AtualizarPorcentagemTotal();
        }

        private void btnRemoverParcela_Click(object sender, EventArgs e)
        {
            if (editandoParcela)
            {
                LimparCamposParcela();
                FinalizarEdicaoParcela();
            }
            else
            {
                if (listVParcelas.SelectedItems.Count > 0)
                {
                    var indice = listVParcelas.SelectedItems[0].Index;
                    listaParcelas.RemoveAt(indice);
                    CarregarParcelasNaListView();
                }
                else
                {
                    MessageBox.Show("Selecione uma parcela para remover.");
                }
            }

            AtualizarPorcentagemTotal();
        }

        private void FinalizarEdicaoParcela()
        {
            editandoParcela = false;
            indiceParcelaEditando = -1;

            btnEditarParcela.Text = "Editar Parcela";
            btnRemoverParcela.Text = "Remover Parcela";

            btnAdicionarParcela.Enabled = true;
            btnAdicionarParcela.Visible = true;
        }

        private void LimparCamposParcela()
        {
            txtNumParcela.Clear();
            txtPercentualParcela.Text = "0";
            txtPrazoDias.Text = "0";
            if (comboBoxFormaPagamento.Items.Count > 0)
                comboBoxFormaPagamento.SelectedIndex = 0;
        }

        private void BloquearCamposParcela()
        {
            txtNumParcela.Enabled = false;
            txtPercentualParcela.Enabled = false;
            txtPrazoDias.Enabled = false;
            comboBoxFormaPagamento.Enabled = false;
            btnAdicionarParcela.Enabled = false;
            btnEditarParcela.Enabled = false;
            btnRemoverParcela.Enabled = false;
        }

        private void DesbloquearCamposParcela()
        {
            txtNumParcela.Enabled = true;
            txtPercentualParcela.Enabled = true;
            txtPrazoDias.Enabled = true;
            comboBoxFormaPagamento.Enabled = true;
            btnAdicionarParcela.Enabled = true;
            btnEditarParcela.Enabled = true;
            btnRemoverParcela.Enabled = true;
        }

        private bool ValidarCamposParcela()
        {
            if (txtNumParcela.Text == "" || txtPercentualParcela.Text == "" || txtPrazoDias.Text == "" || comboBoxFormaPagamento.SelectedIndex < 0)
            {
                MessageBox.Show("Preencha todos os campos da parcela corretamente.");
                return false;
            }

            if (!int.TryParse(txtNumParcela.Text, out int numParcela) ||
                !decimal.TryParse(txtPercentualParcela.Text, out decimal percentual) ||
                !int.TryParse(txtPrazoDias.Text, out int prazoDias))
            {
                MessageBox.Show("Campos numéricos inválidos.");
                return false;
            }

            if (numParcela <= 0)
            {
                MessageBox.Show("O número da parcela deve ser maior que zero.");
                return false;
            }

            if (prazoDias < 0)
            {
                MessageBox.Show("O prazo em dias não pode ser negativo.");
                return false;
            }

            if (percentual <= 0)
            {
                MessageBox.Show("O percentual da parcela deve ser maior que zero.");
                return false;
            }

            if (!editandoParcela)
            {
                foreach (var parcela in listaParcelas)
                {
                    if (parcela.NumeroParcela == numParcela)
                    {
                        MessageBox.Show("Já existe uma parcela com esse número.");
                        return false;
                    }
                }
            }

            return true;
        }



        private void CarregarParcelasDoBanco()
        {
            if (int.TryParse(txtCodigo.Text, out int condicaoPagamentoId))
            {
                listaParcelas = aController_condicaoPagamento.ObterParcelasPorCondicaoPagamentoId(condicaoPagamentoId);
                CarregarParcelasNaListView();
            }
            else
            {
                MessageBox.Show("Código de condição de pagamento inválido.");
            }
        }

        private void CarregarFormasDePagamento()
        {
            Controller_formaPagamento controllerFormaPagamento = new Controller_formaPagamento();
            var formasDePagamento = controllerFormaPagamento.ListaFormaPagamento();

            comboBoxFormaPagamento.DataSource = formasDePagamento;
            comboBoxFormaPagamento.DisplayMember = "Descricao";
            comboBoxFormaPagamento.ValueMember = "Id";
        }

        public void setConsultaFormaPagamento(object obj)
        {
            oFrmConFormPag = (frmConsultaFormaPagamento)obj;
        }

        private void btnPesquisarFormaPagamento_Click(object sender, EventArgs e)
        {
            if (oFrmConFormPag == null)
            {
                oFrmConFormPag = new frmConsultaFormaPagamento();
            }

            formaPagamento formaSelecionada = new formaPagamento();
            Controller_formaPagamento controller = new Controller_formaPagamento();

            oFrmConFormPag.ConhecaObj(formaSelecionada, controller);
            oFrmConFormPag.ShowDialog();

            CarregarFormasDePagamento();

            if (formaSelecionada.Id != 0)
            {
                comboBoxFormaPagamento.SelectedValue = formaSelecionada.Id;
            }
        }

        private void AtualizarPorcentagemTotal()
        {
            decimal total = 0;

            foreach (var parcela in listaParcelas)
            {
                total += parcela.ValorPercentual;
            }

            lblPorcentagemTotalNum.Text = total.ToString("F2");
        }

    }
}

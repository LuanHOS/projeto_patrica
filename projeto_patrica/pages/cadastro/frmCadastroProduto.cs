using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.consulta;
using projeto_patrica.validacao;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroProduto : projeto_patrica.pages.cadastro.frmCadastro
    {
        private produto oProduto;
        private Controller_produto aController_produto;

        private frmConsultaMarca oFrmConsultaMarca;
        private frmConsultaCategoria oFrmConsultaCategoria;
        private frmConsultaUnidade_medida oFrmConsultaUnidadeMedida;
        private frmConsultaFornecedor oFrmConsultaFornecedor;

        public frmCadastroProduto() : base()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oProduto = (produto)obj;
            aController_produto = (Controller_produto)ctrl;
        }

        public void setConsultaMarca(frmConsultaMarca consulta)
        {
            oFrmConsultaMarca = consulta;
        }

        public void setConsultaCategoria(frmConsultaCategoria consulta)
        {
            oFrmConsultaCategoria = consulta;
        }

        public void setConsultaUnidadeMedida(frmConsultaUnidade_medida consulta)
        {
            oFrmConsultaUnidadeMedida = consulta;
        }

        public void setConsultaFornecedor(frmConsultaFornecedor consulta)
        {
            oFrmConsultaFornecedor = consulta;
        }

        public override void Salvar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCodBarras.Text) ||
                string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtUnidadeMedida.Text) ||
                string.IsNullOrWhiteSpace(txtFornecedor.Text) ||
                string.IsNullOrWhiteSpace(txtValorCompra.Text) ||
                string.IsNullOrWhiteSpace(txtValorVenda.Text) ||
                string.IsNullOrWhiteSpace(txtPorcentagemLucro.Text) ||
                string.IsNullOrWhiteSpace(txtEstoque.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios para salvar.");
                return;
            }

            oProduto.Id = Convert.ToInt32(txtCodigo.Text);
            oProduto.Nome = txtNome.Text;
            oProduto.Descricao = txtDescricao.Text;
            oProduto.CodigoBarras = txtCodBarras.Text;
            oProduto.ValorCompra = Convert.ToDecimal(txtValorCompra.Text);
            oProduto.ValorVenda = Convert.ToDecimal(txtValorVenda.Text);
            oProduto.PercentualLucro = Convert.ToDecimal(txtPorcentagemLucro.Text);
            oProduto.Estoque = Convert.ToInt32(txtEstoque.Text);
            oProduto.Ativo = checkBoxAtivo.Checked;

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        txtCodigo.Text = aController_produto.Excluir(oProduto);
                        MessageBox.Show("O produto \"" + oProduto.Nome + "\" foi excluído com sucesso.");
                        Sair();
                    }
                }
                else if (btnSave.Text == "Alterar")
                {
                    txtCodigo.Text = aController_produto.Salvar(oProduto);
                    MessageBox.Show("O produto \"" + oProduto.Nome + "\" foi alterado com sucesso.");
                }
                else
                {
                    txtCodigo.Text = aController_produto.Salvar(oProduto);
                    MessageBox.Show("O produto \"" + oProduto.Nome + "\" foi salvo com o código " + txtCodigo.Text + ".");
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
            txtNome.Clear();
            txtDescricao.Clear();
            txtCodBarras.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtUnidadeMedida.Clear();
            txtFornecedor.Clear();
            txtValorCompra.Text = 0.ToString("F2");
            txtValorVenda.Text = 0.ToString("F2");
            txtPorcentagemLucro.Text = 0.ToString("F2");
            txtEstoque.Text = "0";

            oProduto.OMarca = new marca();
            oProduto.OCategoria = new categoria();
            oProduto.OUnidadeMedida = new unidade_medida();
            oProduto.OFornecedor = new fornecedor();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();
            txtCodigo.Text = oProduto.Id.ToString();
            txtNome.Text = oProduto.Nome;
            txtDescricao.Text = oProduto.Descricao;
            txtCodBarras.Text = oProduto.CodigoBarras;
            txtMarca.Text = oProduto.OMarca.Nome;
            txtCategoria.Text = oProduto.OCategoria.Nome;
            txtUnidadeMedida.Text = oProduto.OUnidadeMedida.Nome;
            txtFornecedor.Text = oProduto.OFornecedor.Nome_razaoSocial;
            txtValorCompra.Text = oProduto.ValorCompra.ToString("F2");
            txtValorVenda.Text = oProduto.ValorVenda.ToString("F2");
            txtPorcentagemLucro.Text = oProduto.PercentualLucro.ToString("F2");
            txtEstoque.Text = oProduto.Estoque.ToString();
            checkBoxAtivo.Checked = oProduto.Ativo;
            lblDataCadastroData.Text = oProduto.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oProduto.DataUltimaEdicao?.ToShortDateString() ?? " ";
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtCodBarras.Enabled = false;
            txtMarca.Enabled = false;
            txtCategoria.Enabled = false;
            txtUnidadeMedida.Enabled = false;
            txtFornecedor.Enabled = false;
            txtValorCompra.Enabled = false;
            txtValorVenda.Enabled = false;
            txtPorcentagemLucro.Enabled = false;
            txtEstoque.Enabled = false;
            btnPesquisarMarca.Enabled = false;
            btnPesquisarCategoria.Enabled = false;
            btnPesquisarUnidadeMedida.Enabled = false;
            btnPesquisarFornecedor.Enabled = false;
        }

        public override void Desbloqueiatxt()
        {
            base.Desbloqueiatxt();
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
            txtCodBarras.Enabled = true;
            txtMarca.Enabled = true;
            txtCategoria.Enabled = true;
            txtUnidadeMedida.Enabled = true;
            txtFornecedor.Enabled = true;
            txtValorCompra.Enabled = true;
            txtValorVenda.Enabled = true;
            txtPorcentagemLucro.Enabled = true;
            txtEstoque.Enabled = true;
            btnPesquisarMarca.Enabled = true;
            btnPesquisarCategoria.Enabled = true;
            btnPesquisarUnidadeMedida.Enabled = true;
            btnPesquisarFornecedor.Enabled = true;
        }

        private void btnPesquisarMarca_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaMarca == null)
                oFrmConsultaMarca = new frmConsultaMarca();

            marca oMarca = new marca();
            Controller_marca controller = new Controller_marca();
            oFrmConsultaMarca.ConhecaObj(oMarca, controller);
            oFrmConsultaMarca.ShowDialog();

            if (oMarca.Id != 0)
            {
                oProduto.OMarca = oMarca;
                txtMarca.Text = oMarca.Nome;
            }
        }

        private void btnPesquisarCategoria_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaCategoria == null)
                oFrmConsultaCategoria = new frmConsultaCategoria();

            categoria oCategoria = new categoria();
            Controller_categoria controller = new Controller_categoria();
            oFrmConsultaCategoria.ConhecaObj(oCategoria, controller);
            oFrmConsultaCategoria.ShowDialog();

            if (oCategoria.Id != 0)
            {
                oProduto.OCategoria = oCategoria;
                txtCategoria.Text = oCategoria.Nome;
            }
        }

        private void btnPesquisarUnidadeMedida_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaUnidadeMedida == null)
                oFrmConsultaUnidadeMedida = new frmConsultaUnidade_medida();

            unidade_medida oUnidadeMedida = new unidade_medida();
            Controller_unidade_medida controller = new Controller_unidade_medida();
            oFrmConsultaUnidadeMedida.ConhecaObj(oUnidadeMedida, controller);
            oFrmConsultaUnidadeMedida.ShowDialog();

            if (oUnidadeMedida.Id != 0)
            {
                oProduto.OUnidadeMedida = oUnidadeMedida;
                txtUnidadeMedida.Text = oUnidadeMedida.Nome;
            }
        }

        private void btnPesquisarFornecedor_Click(object sender, EventArgs e)
        {
            if (oFrmConsultaFornecedor == null)
                oFrmConsultaFornecedor = new frmConsultaFornecedor();

            fornecedor oFornecedor = new fornecedor();
            Controller_fornecedor controller = new Controller_fornecedor();
            oFrmConsultaFornecedor.ConhecaObj(oFornecedor, controller);
            oFrmConsultaFornecedor.ShowDialog();

            if (oFornecedor.Id != 0)
            {
                oProduto.OFornecedor = oFornecedor;
                txtFornecedor.Text = oFornecedor.Nome_razaoSocial;
            }
        }


        // Cálculos de Valor Venda e Porcentagem de Lucro
        private void txtValorCompra_Leave(object sender, EventArgs e)
        {
            CalculaValorVenda();
        }

        private void txtPorcentagemLucro_Leave(object sender, EventArgs e)
        {
            CalculaValorVenda();
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            CalculaPorcentagemLucro();
        }

        private void CalculaValorVenda()
        {
            if (decimal.TryParse(txtValorCompra.Text, out decimal valorCompra) &&
                decimal.TryParse(txtPorcentagemLucro.Text, out decimal percentualLucro))
            {
                decimal valorVenda = valorCompra * (1 + (percentualLucro / 100));
                txtValorVenda.Text = valorVenda.ToString("F2");
            }
        }

        private void CalculaPorcentagemLucro()
        {
            if (decimal.TryParse(txtValorCompra.Text, out decimal valorCompra) &&
                decimal.TryParse(txtValorVenda.Text, out decimal valorVenda))
            {
                if (valorCompra > 0)
                {
                    decimal percentualLucro = ((valorVenda / valorCompra) - 1) * 100;
                    txtPorcentagemLucro.Text = percentualLucro.ToString("F2");
                }
            }
        }

        public override void CamposRestricoes()
        {
            txtCodBarras.MaxLength = 13;
            txtNome.MaxLength = 40;
            txtDescricao.MaxLength = 80;
            txtValorCompra.MaxLength = 11;
            txtValorVenda.MaxLength = 11;
            txtPorcentagemLucro.MaxLength = 11;
            txtEstoque.MaxLength = 10;


            txtCodBarras.KeyPress -= ApenasNumeros;
            txtCodBarras.KeyPress += ApenasNumeros;

            txtValorCompra.KeyPress -= ApenasNumerosDecimal;
            txtValorCompra.KeyPress += ApenasNumerosDecimal;

            txtValorVenda.KeyPress -= ApenasNumerosDecimal;
            txtValorVenda.KeyPress += ApenasNumerosDecimal;

            txtPorcentagemLucro.KeyPress -= ApenasNumerosDecimal;
            txtPorcentagemLucro.KeyPress += ApenasNumerosDecimal;

            txtEstoque.KeyPress -= ApenasNumeros;
            txtEstoque.KeyPress += ApenasNumeros;
        }
    }
}

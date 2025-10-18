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
    public partial class frmCadastroProduto : projeto_patrica.pages.cadastro.frmCadastro
    {
        private produto oProduto;
        private Controller_produto aController_produto;
        private List<produto_fornecedor> listaProdutoFornecedor = new List<produto_fornecedor>();
        private Controller_produto_fornecedor aController_prod_forn;
        private Controller_fornecedor aController_fornecedor;
        private frmConsultaMarca oFrmConsultaMarca;
        private frmConsultaCategoria oFrmConsultaCategoria;
        private frmConsultaUnidade_medida oFrmConsultaUnidadeMedida;
        private frmConsultaFornecedor oFrmConsultaFornecedor;

        public frmCadastroProduto() : base()
        {
            InitializeComponent();
            aController_prod_forn = new Controller_produto_fornecedor();
            aController_fornecedor = new Controller_fornecedor();
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
            if (!ValidacaoCampos())
                return;

            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCodBarras.Text) ||
                string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtUnidadeMedida.Text) ||
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
            oProduto.ValorVenda = Convert.ToDecimal(txtValorVenda.Text);
            oProduto.PercentualLucro = Convert.ToDecimal(txtPorcentagemLucro.Text);
            oProduto.Estoque = Convert.ToInt32(txtEstoque.Text);
            oProduto.Ativo = checkBoxAtivo.Checked;
            oProduto.ValorCompra = Convert.ToDecimal(txtValorCompra.Text);
            oProduto.ValorCompraAnterior = Convert.ToDecimal(txtValorCompraAnterior.Text);

            try
            {
                if (btnSave.Text == "Excluir")
                {
                    DialogResult resp = MessageBox.Show("Deseja realmente excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp == DialogResult.Yes)
                    {
                        aController_produto.Excluir(oProduto);
                        MessageBox.Show("O produto \"" + oProduto.Nome + "\" foi excluído com sucesso.");
                        Sair();
                    }
                }
                else
                {
                    // 1. Salva o produto principal (INSERT ou UPDATE). O ID do produto é atualizado no objeto oProduto.
                    aController_produto.Salvar(oProduto);

                    // 2. Gerencia os fornecedores associados
                    var fornecedoresAtuaisNoBanco = aController_prod_forn.ListarPorProduto(oProduto.Id);

                    // Remove do banco os fornecedores que não estão mais na lista da tela
                    foreach (var relacaoBanco in fornecedoresAtuaisNoBanco)
                    {
                        if (!listaProdutoFornecedor.Any(itemTela => itemTela.IdFornecedor == relacaoBanco.IdFornecedor))
                        {
                            aController_prod_forn.Excluir(relacaoBanco);
                        }
                    }

                    // Adiciona/Atualiza os fornecedores que estão na lista da tela
                    foreach (var relacaoTela in listaProdutoFornecedor)
                    {
                        relacaoTela.IdProduto = oProduto.Id; // Garante que o ID do produto está correto
                        aController_prod_forn.Salvar(relacaoTela);
                    }

                    if (btnSave.Text == "Alterar")
                    {
                        MessageBox.Show("O produto \"" + oProduto.Nome + "\" foi alterado com sucesso.");
                    }
                    else
                    {
                        MessageBox.Show("O produto \"" + oProduto.Nome + "\" foi salvo com o código " + oProduto.Id + ".");
                    }
                }

                base.Salvar();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1062: // Entrada duplicada
                        MessageBox.Show(
                            "Não foi possível salvar o item.\n\nJá existe um item salvo com estes dados.",
                            "Erro: Item duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;

                    case 1451: //  Entrada interligada
                        MessageBox.Show(
                            "Não foi possível excluir o item.\n\nEle está interligado a outro item existente.",
                            "Erro: Item em uso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;

                    default: // Outros erros de banco de dados
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
            txtNome.Clear();
            txtDescricao.Clear();
            txtCodBarras.Clear();
            txtMarca.Clear();
            txtCodMarca.Clear();
            txtCategoria.Clear();
            txtCodCategoria.Clear();
            txtUnidadeMedida.Clear();
            txtCodUnidadeDeMedida.Clear();
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            txtValorCompra.Text = 0.ToString("F2");
            txtValorVenda.Text = 0.ToString("F2");
            txtValorCompraAnterior.Text = 0.ToString("F2");
            txtPorcentagemLucro.Text = 0.ToString("F2");
            txtEstoque.Text = "0";

            listaProdutoFornecedor.Clear();
            CarregarFornecedoresNaListView();

            oProduto = new produto();
            oProduto.OMarca = new marca();
            oProduto.OCategoria = new categoria();
            oProduto.OUnidadeMedida = new unidade_medida();
        }

        public override void Carregatxt()
        {
            base.Carregatxt();
            txtCodigo.Text = oProduto.Id.ToString();
            txtNome.Text = oProduto.Nome;
            txtDescricao.Text = oProduto.Descricao;
            txtCodBarras.Text = oProduto.CodigoBarras;
            txtMarca.Text = oProduto.OMarca.Nome;
            txtCodMarca.Text = oProduto.OMarca.Id.ToString();
            txtCategoria.Text = oProduto.OCategoria.Nome;
            txtCodCategoria.Text = oProduto.OCategoria.Id.ToString();
            txtUnidadeMedida.Text = oProduto.OUnidadeMedida.Nome;
            txtCodUnidadeDeMedida.Text = oProduto.OUnidadeMedida.Id.ToString();
            txtValorCompra.Text = oProduto.ValorCompra.ToString("F2");
            txtValorVenda.Text = oProduto.ValorVenda.ToString("F2");
            txtValorCompraAnterior.Text = oProduto.ValorCompraAnterior.ToString("F2");
            txtPorcentagemLucro.Text = oProduto.PercentualLucro.ToString("F2");
            txtEstoque.Text = oProduto.Estoque.ToString();
            checkBoxAtivo.Checked = oProduto.Ativo;
            lblDataCadastroData.Text = oProduto.DataCadastro.ToShortDateString();
            lblDataUltimaEdicaoData.Text = oProduto.DataUltimaEdicao?.ToShortDateString() ?? " ";

            // Carrega os fornecedores associados do banco
            listaProdutoFornecedor = aController_prod_forn.ListarPorProduto(oProduto.Id);
            CarregarFornecedoresNaListView();
        }

        public override void Bloqueiatxt()
        {
            base.Bloqueiatxt();
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtCodBarras.Enabled = false;
            txtMarca.Enabled = false;
            txtCodMarca.Enabled = false;
            txtCategoria.Enabled = false;
            txtCodCategoria.Enabled = false;
            txtUnidadeMedida.Enabled = false;
            txtCodUnidadeDeMedida.Enabled = false;
            txtFornecedor.Enabled = false;
            txtCodFornecedor.Enabled = false;
            txtValorCompra.Enabled = false;
            txtValorVenda.Enabled = false;
            txtValorCompraAnterior.Enabled = false;
            txtPorcentagemLucro.Enabled = false;
            txtEstoque.Enabled = false;
            btnPesquisarMarca.Enabled = false;
            btnPesquisarCategoria.Enabled = false;
            btnPesquisarUnidadeMedida.Enabled = false;
            btnPesquisarFornecedor.Enabled = false;
            btnAdicionarFornecedor.Enabled = false;
            btnRemoverFornecedor.Enabled = false;
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
            txtValorCompraAnterior.Enabled = true;
            txtPorcentagemLucro.Enabled = true;
            txtEstoque.Enabled = true;
            btnPesquisarMarca.Enabled = true;
            btnPesquisarCategoria.Enabled = true;
            btnPesquisarUnidadeMedida.Enabled = true;
            btnPesquisarFornecedor.Enabled = true;
            btnAdicionarFornecedor.Enabled = true;
            btnRemoverFornecedor.Enabled = true;
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
                txtCodMarca.Text = oMarca.Id.ToString();
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
                txtCodCategoria.Text = oCategoria.Id.ToString();
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
                txtCodUnidadeDeMedida.Text = oUnidadeMedida.Id.ToString();
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
                txtCodFornecedor.Text = oFornecedor.Id.ToString();
                txtFornecedor.Text = oFornecedor.Nome_razaoSocial;
            }
        }

        private void btnAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodFornecedor.Text))
            {
                MessageBox.Show("Selecione um fornecedor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idFornecedor = Convert.ToInt32(txtCodFornecedor.Text);

            if (listaProdutoFornecedor.Any(f => f.IdFornecedor == idFornecedor))
            {
                MessageBox.Show("Este fornecedor já foi adicionado a este produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            produto_fornecedor novaRelacao = new produto_fornecedor
            {
                IdProduto = string.IsNullOrEmpty(txtCodigo.Text) ? 0 : Convert.ToInt32(txtCodigo.Text),
                IdFornecedor = idFornecedor,
                ValorAtualCompra = 0,
                ValorUltimaCompra = 0,
                DataUltimaCompra = DateTime.Now
            };

            listaProdutoFornecedor.Add(novaRelacao);
            CarregarFornecedoresNaListView();

            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
        }

        private void btnRemoverFornecedor_Click(object sender, EventArgs e)
        {
            if (listVFornecedores.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um fornecedor da lista para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resp = MessageBox.Show("Deseja realmente remover o vínculo deste produto com este fornecedor?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                int index = listVFornecedores.SelectedItems[0].Index;
                listaProdutoFornecedor.RemoveAt(index);
                CarregarFornecedoresNaListView();
            }
        }

        private void CarregarFornecedoresNaListView()
        {
            listVFornecedores.Items.Clear();
            foreach (var relacao in listaProdutoFornecedor)
            {
                fornecedor f = new fornecedor { Id = relacao.IdFornecedor };
                aController_fornecedor.CarregaObj(f);

                ListViewItem item = new ListViewItem(f.Id.ToString());
                item.SubItems.Add(f.Nome_razaoSocial);
                item.SubItems.Add(f.TipoPessoa == 'F' ? "FÍSICA" : "JURÍDICA");
                listVFornecedores.Items.Add(item);
            }
        }

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
                else
                {
                    txtPorcentagemLucro.Text = "0";
                }
            }
        }

        public override bool ValidacaoCampos()
        {
            return true;
        }
        public override void CamposRestricoes()
        {
            base.CamposRestricoes();

            txtCodBarras.MaxLength = 13;
            txtNome.MaxLength = 40;
            txtDescricao.MaxLength = 80;
            txtValorCompra.MaxLength = 11;
            txtValorVenda.MaxLength = 11;
            txtValorCompraAnterior.MaxLength = 11;
            txtPorcentagemLucro.MaxLength = 11;
            txtEstoque.MaxLength = 10;

            txtCodBarras.KeyPress -= ApenasNumeros;
            txtCodBarras.KeyPress += ApenasNumeros;

            txtValorCompra.KeyPress -= ApenasNumerosDecimal;
            txtValorCompra.KeyPress += ApenasNumerosDecimal;

            txtValorVenda.KeyPress -= ApenasNumerosDecimal;
            txtValorVenda.KeyPress += ApenasNumerosDecimal;

            txtValorCompraAnterior.KeyPress -= ApenasNumerosDecimal;
            txtValorCompraAnterior.KeyPress += ApenasNumerosDecimal;

            txtPorcentagemLucro.KeyPress -= ApenasNumerosDecimal;
            txtPorcentagemLucro.KeyPress += ApenasNumerosDecimal;

            txtEstoque.KeyPress -= ApenasNumeros;
            txtEstoque.KeyPress += ApenasNumeros;
        }
    }
}
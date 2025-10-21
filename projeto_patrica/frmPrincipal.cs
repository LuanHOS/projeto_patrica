using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Windows.Forms;

namespace projeto_patrica
{
    public partial class frmPrincipal : Form
    {
        //Interface
        private Interfaces aInter;

        //Classes
        private formaPagamento aFormaPagamento;
        private condicaoPagamento aCondicaoPagamento;
        private pais oPais;
        private estado oEstado;
        private cidade aCidade;
        private cliente oCliente;
        private funcionario oFuncionario;
        private fornecedor oFornecedor;
        private categoria aCategoria;
        private marca aMarca;
        private transportadora aTransportadora;
        private unidade_medida aUnidadeMedida;
        private produto oProduto;
        private compra aCompra;
        private contasAPagar aContasAPagar;

        //Controllers
        private Controller_formaPagamento oController_formaPagamento;
        private Controller_condicaoPagamento oController_condicaoPagamento;
        private Controller_pais oController_pais;
        private Controller_estado oController_estado;
        private Controller_cidade oController_cidade;
        private Controller_cliente oController_cliente;
        private Controller_funcionario oController_funcionario;
        private Controller_fornecedor oController_fornecedor;
        private Controller_categoria oController_categoria;
        private Controller_marca oController_marca;
        private Controller_transportadora oController_transportadora;
        private Controller_unidade_medida oController_unidade_medida;
        private Controller_produto oController_produto;
        private Controller_compra oController_compra;
        private Controller_contasAPagar oController_contasAPagar;

        /*
         * */

        public frmPrincipal()
        {
            InitializeComponent();

            // Instanciando Interface
            aInter = new Interfaces();

            // Instanciando Classes
            aFormaPagamento = new formaPagamento();
            aCondicaoPagamento = new condicaoPagamento();
            oPais = new pais();
            oEstado = new estado();
            aCidade = new cidade();
            oCliente = new cliente();
            oFuncionario = new funcionario();
            oFornecedor = new fornecedor();
            aCategoria = new categoria();
            aMarca = new marca();
            aTransportadora = new transportadora();
            aUnidadeMedida = new unidade_medida();
            oProduto = new produto();
            aCompra = new compra();
            aContasAPagar = new contasAPagar();

            // Instanciando Controllers
            oController_formaPagamento = new Controller_formaPagamento();
            oController_condicaoPagamento = new Controller_condicaoPagamento();
            oController_pais = new Controller_pais();
            oController_estado = new Controller_estado();
            oController_cidade = new Controller_cidade();
            oController_cliente = new Controller_cliente();
            oController_funcionario = new Controller_funcionario();
            oController_fornecedor = new Controller_fornecedor();
            oController_categoria = new Controller_categoria();
            oController_marca = new Controller_marca();
            oController_transportadora = new Controller_transportadora();
            oController_unidade_medida = new Controller_unidade_medida();
            oController_produto = new Controller_produto();
            oController_compra = new Controller_compra();
            oController_contasAPagar = new Controller_contasAPagar();

            // Passando dependências de controllers
            oController_condicaoPagamento.AController_formaPagamento = oController_formaPagamento;
            oController_cidade.AController_estado = oController_estado;
            oController_cliente.AController_cidade = oController_cidade;
            oController_funcionario.AController_cidade = oController_cidade;
            oController_fornecedor.AController_cidade = oController_cidade;
            oController_cliente.AController_condicaoPagamento = oController_condicaoPagamento;
            oController_fornecedor.AController_condicaoPagamento = oController_condicaoPagamento;
            oController_transportadora.AController_cidade = oController_cidade;
            oController_transportadora.AController_condicaoPagamento = oController_condicaoPagamento;
            oController_produto.AController_marca = oController_marca;
            oController_produto.AController_categoria = oController_categoria;
            oController_produto.AController_unidade_medida = oController_unidade_medida;
            oController_compra.AController_fornecedor = oController_fornecedor;
            oController_compra.AController_produto = oController_produto;
            oController_compra.AController_condicaoPagamento = oController_condicaoPagamento;
            oController_contasAPagar.AController_fornecedor = oController_fornecedor;
            oController_contasAPagar.AController_formaPagamento = oController_formaPagamento;

        }

        /*
         * */

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaProduto(oProduto, oController_produto);
        }

        /*
         * */

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaUnidadeMedida(aUnidadeMedida, oController_unidade_medida);
        }

        /*
         * */

        private void transportadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaTransportadora(aTransportadora, oController_transportadora);
        }

        /*
         * */

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaMarca(aMarca, oController_marca);
        }

        /*
         * */

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCategoria(aCategoria, oController_categoria);
        }

        /*
         * */

        private void formaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFormaPagamento(aFormaPagamento, oController_formaPagamento);
        }

        /*
         * */

        private void condiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCondicaoPagamento(aCondicaoPagamento, oController_condicaoPagamento);
        }

        /*
         * */

        private void paísToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaPais(oPais, oController_pais);
        }

        /*
         * */

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaEstado(oEstado, oController_estado);
        }

        /*
         * */

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCidade(aCidade, oController_cidade);
        }

        /*
         * */

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCliente(oCliente, oController_cliente);
        }

        /*
         * */

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFuncionario(oFuncionario, oController_funcionario);
        }

        /*
         * */

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaFornecedor(oFornecedor, oController_fornecedor);
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaCompra(aCompra, oController_compra);
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aInter.pecaConsultaContasAPagar(aContasAPagar, oController_contasAPagar);
        }
    }
}
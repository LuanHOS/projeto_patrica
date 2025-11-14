using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using projeto_patrica.pages.consulta;
using System;

namespace projeto_patrica
{
    internal class Interfaces
    {
        // Formulários de Cadastro
        frmCadastroCondicaoPagamento oFrmCadCondPag;
        frmCadastroFormaPagamento oFrmCadFormPag;
        frmCadastroPais oFrmCadPais;
        frmCadastroEstado oFrmCadEstado;
        frmCadastroCidade oFrmCadCidade;
        frmCadastroCliente oFrmCadCliente;
        frmCadastroFuncionario oFrmCadFuncionario;
        frmCadastroFornecedor oFrmCadFornecedor;
        frmCadastroCategoria oFrmCadCategoria;
        frmCadastroMarca oFrmCadMarca;
        frmCadastroTransportadora oFrmCadTransportadora;
        frmCadastroUnidade_medida oFrmCadUnidadeMedida;
        frmCadastroProduto oFrmCadProduto;
        frmCadastroCompra oFrmCadCompra;
        frmCadastroContasAPagar oFrmCadContasAPagar;
        frmCadastroVenda oFrmCadVenda;
        frmCadastroContasAReceber oFrmCadContasAReceber;

        // Formulários de Consulta
        frmConsultaCondicaoPagamento oFrmConCondPag;
        frmConsultaFormaPagamento oFrmConFormPag;
        frmConsultaPais oFrmConPais;
        frmConsultaEstado oFrmConEstado;
        frmConsultaCidade oFrmConCidade;
        frmConsultaCliente oFrmConCliente;
        frmConsultaFuncionario oFrmConFuncionario;
        frmConsultaFornecedor oFrmConFornecedor;
        frmConsultaCategoria oFrmConCategoria;
        frmConsultaMarca oFrmConMarca;
        frmConsultaTransportadora oFrmConTransportadora;
        frmConsultaUnidade_medida oFrmConUnidadeMedida;
        frmConsultaProduto oFrmConProduto;
        frmConsultaCompra oFrmConCompra;
        frmConsultaContasAPagar oFrmConContasAPagar;
        frmConsultaVenda oFrmConVenda;
        frmConsultaContasAReceber oFrmConContasAReceber;

        /*
         * */

        public Interfaces()
        {
            // Instancia Formulários de Consulta
            oFrmConCondPag = new frmConsultaCondicaoPagamento();
            oFrmConFormPag = new frmConsultaFormaPagamento();
            oFrmConPais = new frmConsultaPais();
            oFrmConEstado = new frmConsultaEstado();
            oFrmConCidade = new frmConsultaCidade();
            oFrmConCliente = new frmConsultaCliente();
            oFrmConFuncionario = new frmConsultaFuncionario();
            oFrmConFornecedor = new frmConsultaFornecedor();
            oFrmConCategoria = new frmConsultaCategoria();
            oFrmConMarca = new frmConsultaMarca();
            oFrmConTransportadora = new frmConsultaTransportadora();
            oFrmConUnidadeMedida = new frmConsultaUnidade_medida();
            oFrmConProduto = new frmConsultaProduto();
            oFrmConCompra = new frmConsultaCompra();
            oFrmConContasAPagar = new frmConsultaContasAPagar();
            oFrmConVenda = new frmConsultaVenda();
            oFrmConContasAReceber = new frmConsultaContasAReceber();

            // Instancia Formulários de Cadastro
            oFrmCadCondPag = new frmCadastroCondicaoPagamento();
            oFrmCadFormPag = new frmCadastroFormaPagamento();
            oFrmCadPais = new frmCadastroPais();
            oFrmCadEstado = new frmCadastroEstado();
            oFrmCadCidade = new frmCadastroCidade();
            oFrmCadCliente = new frmCadastroCliente();
            oFrmCadFuncionario = new frmCadastroFuncionario();
            oFrmCadFornecedor = new frmCadastroFornecedor();
            oFrmCadCategoria = new frmCadastroCategoria();
            oFrmCadMarca = new frmCadastroMarca();
            oFrmCadTransportadora = new frmCadastroTransportadora();
            oFrmCadUnidadeMedida = new frmCadastroUnidade_medida();
            oFrmCadProduto = new frmCadastroProduto();
            oFrmCadCompra = new frmCadastroCompra();
            oFrmCadContasAPagar = new frmCadastroContasAPagar();
            oFrmCadVenda = new frmCadastroVenda();
            oFrmCadContasAReceber = new frmCadastroContasAReceber();

            // Vincula Formulários de Consulta aos de Cadastro
            oFrmConCondPag.setFrmCadastro(oFrmCadCondPag);
            oFrmConFormPag.setFrmCadastro(oFrmCadFormPag);
            oFrmConPais.setFrmCadastro(oFrmCadPais);
            oFrmConEstado.setFrmCadastro(oFrmCadEstado);
            oFrmConCidade.setFrmCadastro(oFrmCadCidade);
            oFrmConCliente.setFrmCadastro(oFrmCadCliente);
            oFrmConFuncionario.setFrmCadastro(oFrmCadFuncionario);
            oFrmConFornecedor.setFrmCadastro(oFrmCadFornecedor);
            oFrmConCategoria.setFrmCadastro(oFrmCadCategoria);
            oFrmConMarca.setFrmCadastro(oFrmCadMarca);
            oFrmConTransportadora.setFrmCadastro(oFrmCadTransportadora);
            oFrmConUnidadeMedida.setFrmCadastro(oFrmCadUnidadeMedida);
            oFrmConProduto.setFrmCadastro(oFrmCadProduto);
            oFrmConCompra.setFrmCadastro(oFrmCadCompra);
            oFrmConContasAPagar.setFrmCadastro(oFrmCadContasAPagar);
            oFrmConVenda.setFrmCadastro(oFrmCadVenda);
            oFrmConContasAReceber.setFrmCadastro(oFrmCadContasAReceber);

            // Vincula Consultas necessárias aos Cadastros
            oFrmCadCondPag.setConsultaFormaPagamento(oFrmConFormPag);
            oFrmCadEstado.setConsultaPais(oFrmConPais);
            oFrmCadCidade.setConsultaEstado(oFrmConEstado);
            oFrmCadCliente.setConsultaCidade(oFrmConCidade);
            oFrmCadFuncionario.setConsultaCidade(oFrmConCidade);
            oFrmCadFornecedor.setConsultaCidade(oFrmConCidade);
            oFrmCadFornecedor.setConsultaCondicaoPagamento(oFrmConCondPag);
            oFrmCadCliente.setConsultaCondicaoPagamento(oFrmConCondPag);
            oFrmCadTransportadora.setConsultaCidade(oFrmConCidade);
            oFrmCadTransportadora.setConsultaCondicaoPagamento(oFrmConCondPag);
            oFrmCadProduto.setConsultaMarca(oFrmConMarca);
            oFrmCadProduto.setConsultaCategoria(oFrmConCategoria);
            oFrmCadProduto.setConsultaUnidadeMedida(oFrmConUnidadeMedida);
            oFrmCadProduto.setConsultaFornecedor(oFrmConFornecedor);
            oFrmCadCompra.setConsultaFornecedor(oFrmConFornecedor);
            oFrmCadCompra.setConsultaProduto(oFrmConProduto);
            oFrmCadCompra.setConsultaCondicaoPagamento(oFrmConCondPag);
            oFrmCadContasAPagar.setConsultaFornecedor(oFrmConFornecedor);
            oFrmCadContasAPagar.setConsultaFormaPagamento(oFrmConFormPag);
            oFrmCadVenda.setConsultaCliente(oFrmConCliente);
            oFrmCadVenda.setConsultaFuncionario(oFrmConFuncionario);
            oFrmCadVenda.setConsultaProduto(oFrmConProduto);
            oFrmCadVenda.setConsultaCondicaoPagamento(oFrmConCondPag);
            oFrmCadContasAReceber.setConsultaCliente(oFrmConCliente);
            oFrmCadContasAReceber.setConsultaFormaPagamento(oFrmConFormPag);
        }

        /*
         * */
        public void pecaConsultaProduto(produto oProduto, Controller_produto oController_produto)
        {
            oFrmConProduto.ConhecaObj(oProduto, oController_produto);
            oFrmConProduto.ShowDialog();
        }

        public void pecaConsultaCompra(compra aCompra, Controller_compra oController_compra)
        {
            oFrmConCompra.ConhecaObj(aCompra, oController_compra);
            oFrmConCompra.ShowDialog();
        }

        public void pecaConsultaVenda(venda aVenda, Controller_venda oController_venda)
        {
            oFrmConVenda.ConhecaObj(aVenda, oController_venda);
            oFrmConVenda.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaUnidadeMedida(unidade_medida oUnidadeMedida, Controller_unidade_medida oController_unidade_medida)
        {
            oFrmConUnidadeMedida.ConhecaObj(oUnidadeMedida, oController_unidade_medida);
            oFrmConUnidadeMedida.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaTransportadora(transportadora oTransportadora, Controller_transportadora oController_transportadora)
        {
            oFrmConTransportadora.ConhecaObj(oTransportadora, oController_transportadora);
            oFrmConTransportadora.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaMarca(marca oMarca, Controller_marca oController_marca)
        {
            oFrmConMarca.ConhecaObj(oMarca, oController_marca);
            oFrmConMarca.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaCategoria(categoria oCategoria, Controller_categoria oController_categoria)
        {
            oFrmConCategoria.ConhecaObj(oCategoria, oController_categoria);
            oFrmConCategoria.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaCondicaoPagamento(condicaoPagamento oCondicaoPagamento, Controller_condicaoPagamento oController_condicaoPagamento)
        {
            oFrmConCondPag.ConhecaObj(oCondicaoPagamento, oController_condicaoPagamento);
            oFrmConCondPag.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaFormaPagamento(formaPagamento aFormaPagamento, Controller_formaPagamento oController_formaPagamento)
        {
            oFrmConFormPag.ConhecaObj(aFormaPagamento, oController_formaPagamento);
            oFrmConFormPag.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaPais(pais oPais, Controller_pais oController_pais)
        {
            oFrmConPais.ConhecaObj(oPais, oController_pais);
            oFrmConPais.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaEstado(estado oEstado, Controller_estado oController_estado)
        {
            oFrmConEstado.ConhecaObj(oEstado, oController_estado);
            oFrmConEstado.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaCidade(cidade aCidade, Controller_cidade oController_cidade)
        {
            oFrmConCidade.ConhecaObj(aCidade, oController_cidade);
            oFrmConCidade.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaFuncionario(funcionario oFuncionario, Controller_funcionario oController_funcionario)
        {
            oFrmConFuncionario.ConhecaObj(oFuncionario, oController_funcionario);
            oFrmConFuncionario.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaCliente(cliente oCliente, Controller_cliente oController_cliente)
        {
            oFrmConCliente.ConhecaObj(oCliente, oController_cliente);
            oFrmConCliente.ShowDialog();
        }

        /*
         * */

        public void pecaConsultaFornecedor(fornecedor oFornecedor, Controller_fornecedor oController_fornecedor)
        {
            oFrmConFornecedor.ConhecaObj(oFornecedor, oController_fornecedor);
            oFrmConFornecedor.ShowDialog();
        }

        public void pecaConsultaContasAPagar(contasAPagar oContaAPagar, Controller_contasAPagar oController_contasAPagar)
        {
            oFrmConContasAPagar.ConhecaObj(oContaAPagar, oController_contasAPagar);
            oFrmConContasAPagar.ShowDialog();
        }

        public void pecaConsultaContasAReceber(contasAReceber oContaAReceber, Controller_contasAReceber oController_contasAReceber)
        {
            oFrmConContasAReceber.ConhecaObj(oContaAReceber, oController_contasAReceber);
            oFrmConContasAReceber.ShowDialog();
        }
    }
}
using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaContasAPagar : projeto_patrica.pages.consulta.frmConsulta
    {
        private frmCadastroContasAPagar oFrmCadastroContasAPagar;
        private contasAPagar oContaAPagar;
        private Controller_contasAPagar aController_contasAPagar;
        private List<contasAPagar> listaCompletaContas;

        public frmConsultaContasAPagar()
        {
            InitializeComponent();
            comboBoxFiltroStatus.SelectedIndex = 0;
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroContasAPagar = (frmCadastroContasAPagar)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaAPagar = (contasAPagar)obj;
            aController_contasAPagar = (Controller_contasAPagar)ctrl;
            CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            contasAPagar novaConta = new contasAPagar();
            oFrmCadastroContasAPagar.ConhecaObj(novaConta, aController_contasAPagar);
            oFrmCadastroContasAPagar.Limpartxt();
            oFrmCadastroContasAPagar.Desbloqueiatxt();
            oFrmCadastroContasAPagar.btnSave.Text = "Salvar";
            oFrmCadastroContasAPagar.ShowDialog();
            CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();

            aController_contasAPagar.CarregaObj(oContaAPagar);

            string aux = oFrmCadastroContasAPagar.btnSave.Text;
            oFrmCadastroContasAPagar.btnSave.Text = "Alterar";

            oFrmCadastroContasAPagar.ConhecaObj(oContaAPagar, aController_contasAPagar);
            oFrmCadastroContasAPagar.Carregatxt();
            oFrmCadastroContasAPagar.Desbloqueiatxt();
            oFrmCadastroContasAPagar.ShowDialog();

            oFrmCadastroContasAPagar.btnSave.Text = aux;
            CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();

            aController_contasAPagar.CarregaObj(oContaAPagar);

            string aux = oFrmCadastroContasAPagar.btnSave.Text;
            oFrmCadastroContasAPagar.btnSave.Text = "Excluir";

            oFrmCadastroContasAPagar.ConhecaObj(oContaAPagar, aController_contasAPagar);
            oFrmCadastroContasAPagar.Carregatxt();
            oFrmCadastroContasAPagar.Bloqueiatxt();
            oFrmCadastroContasAPagar.ShowDialog(this);

            oFrmCadastroContasAPagar.Desbloqueiatxt();
            oFrmCadastroContasAPagar.btnSave.Text = aux;
            CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listaCompletaContas = aController_contasAPagar.ListaContasAPagar();
            FiltrarEPreencherListView();
        }

        private void FiltrarEPreencherListView()
        {
            listV.Items.Clear();

            IEnumerable<contasAPagar> listaFiltrada =
                listaCompletaContas ?? Enumerable.Empty<contasAPagar>();

            string filtroStatus = comboBoxFiltroStatus.SelectedItem?.ToString() ?? "Todas";

            switch (filtroStatus)
            {
                case "Em Aberto":
                    listaFiltrada = listaFiltrada.Where(c => c.Ativo && c.Situacao == 0 && c.DataVencimento.Date >= DateTime.Today);
                    break;

                case "Paga":
                    listaFiltrada = listaFiltrada.Where(c => c.Ativo && c.Situacao == 1);
                    break;

                case "Vencida":
                    listaFiltrada = listaFiltrada.Where(c => c.Ativo && c.Situacao == 0 && c.DataVencimento.Date < DateTime.Today);
                    break;

                case "Cancelada":
                    listaFiltrada = listaFiltrada.Where(c => !c.Ativo);
                    break;

                case "Todas":
                    break;

                default:
                    break;
            }


            // Filtrar pelo campo de Pesquisa (txtCodigo herdado)
            string termoPesquisa = txtCodigo.Text.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(termoPesquisa))
            {
                listaFiltrada = listaFiltrada.Where(c =>
                     c.NumeroNotaCompra.ToUpper().Contains(termoPesquisa) ||
                     (c.OFornecedor != null && c.OFornecedor.Nome_razaoSocial != null && c.OFornecedor.Nome_razaoSocial.ToUpper().Contains(termoPesquisa)) ||
                     c.NumeroParcela.ToString().Contains(termoPesquisa) ||
                     c.OFornecedor.Id.ToString().Contains(termoPesquisa)
                 );
            }

            // Preencher a ListView
            foreach (var conta in listaFiltrada)
            {
                ListViewItem item = new ListViewItem(conta.NumeroParcela.ToString()); 
                item.SubItems.Add(conta.ModeloCompra.ToString());         
                item.SubItems.Add(conta.SerieCompra);                     
                item.SubItems.Add(conta.NumeroNotaCompra);                 
                item.SubItems.Add(conta.OFornecedor.Id.ToString());          
                item.SubItems.Add(conta.OFornecedor.Nome_razaoSocial);
                item.SubItems.Add(conta.ValorParcela.ToString("C2"));   
                item.SubItems.Add(conta.AFormaPagamento.Descricao);
                item.SubItems.Add(conta.DataEmissao.ToShortDateString());  
                item.SubItems.Add(conta.DataVencimento.ToShortDateString());
                item.SubItems.Add(conta.Ativo ? "" : "CANCELADO"); 

                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            FiltrarEPreencherListView();
        }

        public override void LimparPesquisa()
        {
            txtCodigo.Clear();
            FiltrarEPreencherListView();
        }

        private void comboBoxFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarEPreencherListView();
        }
    }
}
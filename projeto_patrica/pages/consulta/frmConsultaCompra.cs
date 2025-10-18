using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaCompra : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroCompra oFrmCadastroCompra;
        private compra oCompra;
        Controller_compra aController_compra;

        public frmConsultaCompra() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroCompra = (frmCadastroCompra)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCompra = (compra)obj;
            aController_compra = (Controller_compra)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            // Passa um novo objeto para o formulário de cadastro
            oFrmCadastroCompra.ConhecaObj(new compra(), aController_compra);
            oFrmCadastroCompra.Limpartxt();
            oFrmCadastroCompra.btnSave.Text = "Salvar"; // Garante que o modo é de inclusão
            oFrmCadastroCompra.btnSave.Visible = true;
            oFrmCadastroCompra.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            oFrmCadastroCompra.Limpartxt();
            aController_compra.CarregaObj(oCompra);
            oFrmCadastroCompra.ConhecaObj(oCompra, aController_compra);
            oFrmCadastroCompra.Carregatxt();
            oFrmCadastroCompra.Bloqueiatxt();
            oFrmCadastroCompra.btnSave.Text = "Visualizar"; // Define o modo de visualização
            oFrmCadastroCompra.btnSave.Visible = false; // Esconde o botão Salvar
            oFrmCadastroCompra.ShowDialog();
            oFrmCadastroCompra.btnSave.Visible = true; // Mostra o botão Salvar novamente ao fechar
            oFrmCadastroCompra.btnSave.Text = "Salvar"; // Restaura o texto original
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            oFrmCadastroCompra.Limpartxt();
            aController_compra.CarregaObj(oCompra);

            if (!oCompra.Ativo)
            {
                MessageBox.Show("Esta compra já está cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oFrmCadastroCompra.ConhecaObj(oCompra, aController_compra);
            oFrmCadastroCompra.Carregatxt();
            oFrmCadastroCompra.Bloqueiatxt();
            oFrmCadastroCompra.btnSave.Text = "Cancelar Nota";
            oFrmCadastroCompra.btnSave.Visible = true;
            oFrmCadastroCompra.ShowDialog(this);
            oFrmCadastroCompra.btnSave.Text = "Salvar"; // Restaura o texto original do botão
            this.CarregaLV();
        }


        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();

            var lista = aController_compra.ListaCompras();

            foreach (var compra in lista)
            {
                // Carrega os dados completos para calcular o valor total
                aController_compra.CarregaObj(compra);
                decimal totalItens = compra.Itens.Sum(i => i.ValorTotal);
                decimal valorTotal = totalItens + compra.ValorFrete + compra.Seguro + compra.Despesas;

                ListViewItem item = new ListViewItem(compra.Modelo.ToString()); // clmCod (0)
                item.SubItems.Add(compra.Serie); // clmSerie (1)
                item.SubItems.Add(compra.NumeroNota); // clmNumNota (2)
                item.SubItems.Add(compra.OFornecedor.Id.ToString()); // clmIdFornecedor (3)
                item.SubItems.Add(compra.OFornecedor.Nome_razaoSocial); // clmFornecedor (4)
                item.SubItems.Add(compra.DataEmissao.ToShortDateString()); // clmDataEmissao (5)
                item.SubItems.Add(compra.DataEntrega.ToShortDateString()); // clmDataEntrega (6)
                item.SubItems.Add(valorTotal.ToString("C2")); // clmValorTotal (7)
                item.SubItems.Add(compra.ACondicaoPagamento.Descricao); // clmCondicaoPagamento (8)
                item.SubItems.Add(compra.Ativo ? "" : "CANCELADO"); // clmAtivo (9)
                item.SubItems.Add(compra.MotivoCancelamento ?? ""); // clmMotivoCancelamento (10)

                item.Tag = compra;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();

            var lista = aController_compra.ListaCompras();
            var listaResultados = new List<compra>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (var compra in lista)
            {
                if (compra.NumeroNota.ToUpper().Contains(termo) ||
                    compra.OFornecedor.Nome_razaoSocial.ToUpper().Contains(termo))
                {
                    listaResultados.Add(compra);
                }
            }

            foreach (var compra in listaResultados)
            {
                aController_compra.CarregaObj(compra);
                decimal totalItens = compra.Itens.Sum(i => i.ValorTotal);
                decimal valorTotal = totalItens + compra.ValorFrete + compra.Seguro + compra.Despesas;

                ListViewItem item = new ListViewItem(compra.Modelo.ToString()); // clmCod (0)
                item.SubItems.Add(compra.Serie); // clmSerie (1)
                item.SubItems.Add(compra.NumeroNota); // clmNumNota (2)
                item.SubItems.Add(compra.OFornecedor.Id.ToString()); // clmIdFornecedor (3)
                item.SubItems.Add(compra.OFornecedor.Nome_razaoSocial); // clmFornecedor (4)
                item.SubItems.Add(compra.DataEmissao.ToShortDateString()); // clmDataEmissao (5)
                item.SubItems.Add(compra.DataEntrega.ToShortDateString()); // clmDataEntrega (6)
                item.SubItems.Add(valorTotal.ToString("C2")); // clmValorTotal (7)
                item.SubItems.Add(compra.ACondicaoPagamento.Descricao); // clmCondicaoPagamento (8)
                item.SubItems.Add(compra.Ativo ? "" : "CANCELADO"); // clmAtivo (9)
                item.SubItems.Add(compra.MotivoCancelamento ?? ""); // clmMotivoCancelamento (10)


                item.Tag = compra;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                compra compraSelecionada = (compra)linha.Tag;

                // Define as chaves da compra selecionada para as operações de Alterar/Excluir
                oCompra.Modelo = compraSelecionada.Modelo;
                oCompra.Serie = compraSelecionada.Serie;
                oCompra.NumeroNota = compraSelecionada.NumeroNota;
                oCompra.OFornecedor.Id = compraSelecionada.OFornecedor.Id;
            }
        }
    }
}
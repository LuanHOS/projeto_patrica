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
    public partial class frmConsultaVenda : projeto_patrica.pages.consulta.frmConsulta
    {
        frmCadastroVenda oFrmCadastroVenda;
        private venda oVenda;
        Controller_venda aController_venda;

        public frmConsultaVenda() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroVenda = (frmCadastroVenda)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oVenda = (venda)obj;
            aController_venda = (Controller_venda)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroVenda.ConhecaObj(new venda(), aController_venda);
            oFrmCadastroVenda.Limpartxt();
            oFrmCadastroVenda.btnSave.Text = "Salvar";
            oFrmCadastroVenda.btnSave.Visible = true;
            oFrmCadastroVenda.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            oFrmCadastroVenda.Limpartxt();
            aController_venda.CarregaObj(oVenda);
            oFrmCadastroVenda.ConhecaObj(oVenda, aController_venda);
            oFrmCadastroVenda.Carregatxt();
            oFrmCadastroVenda.Bloqueiatxt();
            oFrmCadastroVenda.btnSave.Text = "Visualizar";
            oFrmCadastroVenda.btnSave.Visible = false;
            oFrmCadastroVenda.ShowDialog();
            oFrmCadastroVenda.btnSave.Visible = true;
            oFrmCadastroVenda.btnSave.Text = "Salvar";
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            oFrmCadastroVenda.Limpartxt();
            aController_venda.CarregaObj(oVenda);

            if (!oVenda.Ativo)
            {
                MessageBox.Show("Esta venda já está cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (oVenda.Parcelas.Any(p => p.Situacao == 1))
            {
                MessageBox.Show("Esta venda não pode ser cancelada pois possui uma ou mais parcelas que já foram pagas.", "Ação Interrompida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oFrmCadastroVenda.ConhecaObj(oVenda, aController_venda);
            oFrmCadastroVenda.Carregatxt();
            oFrmCadastroVenda.Bloqueiatxt();
            oFrmCadastroVenda.btnSave.Text = "Cancelar Nota";
            oFrmCadastroVenda.btnSave.Visible = true;
            oFrmCadastroVenda.ShowDialog(this);
            oFrmCadastroVenda.btnSave.Text = "Salvar";
            this.CarregaLV();
        }


        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();

            var lista = aController_venda.ListarVendas();

            foreach (var venda in lista)
            {
                aController_venda.CarregaObj(venda);
                decimal totalItens = venda.Itens.Sum(i => i.ValorTotal);
                decimal valorTotal = totalItens;

                ListViewItem item = new ListViewItem(venda.Modelo.ToString());
                item.SubItems.Add(venda.Serie);
                item.SubItems.Add(venda.NumeroNota);
                item.SubItems.Add(venda.OCliente.Id.ToString());
                item.SubItems.Add(venda.OCliente.Nome_razaoSocial);
                item.SubItems.Add(venda.OFuncionario.Id.ToString());
                item.SubItems.Add(venda.OFuncionario.Nome);
                item.SubItems.Add(venda.DataEmissao.ToShortDateString());
                item.SubItems.Add(valorTotal.ToString("C2"));
                item.SubItems.Add(venda.Ativo ? "" : "CANCELADO");
                item.SubItems.Add(venda.MotivoCancelamento ?? "");
                item.SubItems.Add(venda.DataUltimaEdicao.HasValue ? venda.DataUltimaEdicao.Value.ToString("dd/MM/yyyy HH:mm") : "");

                if (!venda.Ativo)
                {
                    item.ForeColor = Color.Red;
                }

                item.Tag = venda;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();

            var lista = aController_venda.ListarVendas();
            var listaResultados = new List<venda>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                LimparPesquisa();
                return;
            }

            foreach (var venda in lista)
            {
                if (venda.NumeroNota.ToUpper().Contains(termo) ||
                    venda.OCliente.Nome_razaoSocial.ToUpper().Contains(termo))
                {
                    listaResultados.Add(venda);
                }
            }

            foreach (var venda in listaResultados)
            {
                aController_venda.CarregaObj(venda);
                decimal totalItens = venda.Itens.Sum(i => i.ValorTotal);
                decimal valorTotal = totalItens;

                ListViewItem item = new ListViewItem(venda.Modelo.ToString());
                item.SubItems.Add(venda.Serie);
                item.SubItems.Add(venda.NumeroNota);
                item.SubItems.Add(venda.OCliente.Id.ToString());
                item.SubItems.Add(venda.OCliente.Nome_razaoSocial);
                item.SubItems.Add(venda.OFuncionario.Id.ToString());
                item.SubItems.Add(venda.OFuncionario.Nome);
                item.SubItems.Add(venda.DataEmissao.ToShortDateString());
                item.SubItems.Add(valorTotal.ToString("C2"));
                item.SubItems.Add(venda.Ativo ? "" : "CANCELADO");
                item.SubItems.Add(venda.MotivoCancelamento ?? "");
                item.SubItems.Add(venda.DataUltimaEdicao.HasValue ? venda.DataUltimaEdicao.Value.ToString("dd/MM/yyyy HH:mm") : "");

                if (!venda.Ativo)
                {
                    item.ForeColor = Color.Red;
                }

                item.Tag = venda;
                listV.Items.Add(item);
            }
        }


        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                venda vendaSelecionada = (venda)linha.Tag;

                oVenda.Modelo = vendaSelecionada.Modelo;
                oVenda.Serie = vendaSelecionada.Serie;
                oVenda.NumeroNota = vendaSelecionada.NumeroNota;
                oVenda.OCliente.Id = vendaSelecionada.OCliente.Id;
            }
        }
    }
}
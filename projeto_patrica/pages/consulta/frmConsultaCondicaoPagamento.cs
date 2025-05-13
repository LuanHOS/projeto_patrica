using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaCondicaoPagamento : projeto_patrica.pages.consulta.frmConsulta
    {
        private frmCadastroCondicaoPagamento oFrmCadCondicaoPagamento;
        private condicaoPagamento aCondicaoPagamento;
        private Controller_condicaoPagamento aController_condicaoPagamento;

        public frmConsultaCondicaoPagamento() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadCondicaoPagamento = (frmCadastroCondicaoPagamento)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCondicaoPagamento = (condicaoPagamento)obj;
            aController_condicaoPagamento = (Controller_condicaoPagamento)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadCondicaoPagamento.ConhecaObj(aCondicaoPagamento, aController_condicaoPagamento);
            oFrmCadCondicaoPagamento.Limpartxt();
            oFrmCadCondicaoPagamento.ShowDialog();
            oFrmCadCondicaoPagamento.Desbloqueiatxt();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            string aux = oFrmCadCondicaoPagamento.btnSave.Text;
            oFrmCadCondicaoPagamento.btnSave.Text = "Alterar";
            base.Alterar();
            aController_condicaoPagamento.CarregaObj(aCondicaoPagamento);
            oFrmCadCondicaoPagamento.ConhecaObj(aCondicaoPagamento, aController_condicaoPagamento);
            oFrmCadCondicaoPagamento.Carregatxt();
            oFrmCadCondicaoPagamento.ShowDialog();
            oFrmCadCondicaoPagamento.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            string aux = oFrmCadCondicaoPagamento.btnSave.Text;
            oFrmCadCondicaoPagamento.btnSave.Text = "Excluir";
            base.Excluir();
            aController_condicaoPagamento.CarregaObj(aCondicaoPagamento);
            oFrmCadCondicaoPagamento.ConhecaObj(aCondicaoPagamento, aController_condicaoPagamento);
            oFrmCadCondicaoPagamento.Carregatxt();
            oFrmCadCondicaoPagamento.Bloqueiatxt();
            oFrmCadCondicaoPagamento.ShowDialog(this);
            oFrmCadCondicaoPagamento.Desbloqueiatxt();
            oFrmCadCondicaoPagamento.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();

            foreach (condicaoPagamento aCondPag in aController_condicaoPagamento.ListaCondicaoPagamento())
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aCondPag.Id));
                item.SubItems.Add(aCondPag.Descricao);
                item.SubItems.Add(Convert.ToString(aCondPag.QuantidadeParcelas));
                item.Tag = aCondPag;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();

            string termo = txtCodigo.Text.Trim().ToUpper();
            List<condicaoPagamento> lista = new List<condicaoPagamento>();

            if (string.IsNullOrWhiteSpace(termo))
            {
                lista = aController_condicaoPagamento.ListaCondicaoPagamento();
            }
            else
            {
                foreach (condicaoPagamento cp in aController_condicaoPagamento.ListaCondicaoPagamento())
                {
                    if (termo == cp.Id.ToString() || cp.Descricao.ToUpper().Contains(termo))
                    {
                        lista.Add(cp);
                    }
                }
            }

            foreach (condicaoPagamento aCondPag in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aCondPag.Id));
                item.SubItems.Add(aCondPag.Descricao);
                item.SubItems.Add(Convert.ToString(aCondPag.QuantidadeParcelas));
                item.Tag = aCondPag;
                listV.Items.Add(item);
            }
        }

        public override void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);

            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                condicaoPagamento condicaoPagamentoSelecionada = (condicaoPagamento)linha.Tag;

                aCondicaoPagamento.Id = condicaoPagamentoSelecionada.Id;
                aCondicaoPagamento.Descricao = condicaoPagamentoSelecionada.Descricao;
                aCondicaoPagamento.QuantidadeParcelas = condicaoPagamentoSelecionada.QuantidadeParcelas;
            }
        }

        private void frmConsultaCondicaoPagamento_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                condicaoPagamento condicaoPagamentoSelecionada = (condicaoPagamento)linha.Tag;

                if (!condicaoPagamentoSelecionada.Ativo)
                {
                    MessageBox.Show("Este item está inativo e não pode ser selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                aCondicaoPagamento.Id = condicaoPagamentoSelecionada.Id;
                aCondicaoPagamento.Descricao = condicaoPagamentoSelecionada.Descricao;
                aCondicaoPagamento.QuantidadeParcelas = condicaoPagamentoSelecionada.QuantidadeParcelas;

                this.Close();
            }
        }

        public override void Sair()
        {
            aCondicaoPagamento.Id = 0;
            base.Sair();
        }
    }
}
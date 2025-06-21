using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaTransportadora : frmConsulta
    {
        private frmCadastroTransportadora oFrmCadastroTransportadora;
        private transportadora oTransportadora;
        private Controller_transportadora aController_transportadora;

        public frmConsultaTransportadora() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroTransportadora = (frmCadastroTransportadora)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oTransportadora = (transportadora)obj;
            aController_transportadora = (Controller_transportadora)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroTransportadora.ConhecaObj(new transportadora(), aController_transportadora);
            oFrmCadastroTransportadora.Desbloqueiatxt();
            oFrmCadastroTransportadora.Limpartxt();
            oFrmCadastroTransportadora.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            if (listV.SelectedItems.Count > 0)
            {
                string aux = oFrmCadastroTransportadora.btnSave.Text;
                oFrmCadastroTransportadora.btnSave.Text = "Alterar";
                base.Alterar();
                aController_transportadora.CarregaObj(oTransportadora);
                oFrmCadastroTransportadora.ConhecaObj(oTransportadora, aController_transportadora);
                oFrmCadastroTransportadora.Carregatxt();
                oFrmCadastroTransportadora.Desbloqueiatxt();
                oFrmCadastroTransportadora.ShowDialog();
                oFrmCadastroTransportadora.btnSave.Text = aux;
                this.CarregaLV();
            }
            else
            {
                MessageBox.Show("Selecione um item para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Excluir()
        {
            if (listV.SelectedItems.Count > 0)
            {
                base.Excluir();
                string aux = oFrmCadastroTransportadora.btnSave.Text;
                oFrmCadastroTransportadora.btnSave.Text = "Excluir";
                aController_transportadora.CarregaObj(oTransportadora);
                oFrmCadastroTransportadora.ConhecaObj(oTransportadora, aController_transportadora);
                oFrmCadastroTransportadora.Carregatxt();
                oFrmCadastroTransportadora.Bloqueiatxt();
                oFrmCadastroTransportadora.ShowDialog(this);
                oFrmCadastroTransportadora.Desbloqueiatxt();
                oFrmCadastroTransportadora.btnSave.Text = aux;
                this.CarregaLV();
            }
            else
            {
                MessageBox.Show("Selecione um item para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            listV.Items.Clear();
            var lista = aController_transportadora.ListaTransportadoras();

            foreach (var oTransp in lista)
            {
                ListViewItem item = new ListViewItem(oTransp.Id.ToString());
                item.SubItems.Add(oTransp.Nome_razaoSocial);
                item.SubItems.Add(oTransp.TipoPessoa == 'F' ? "FÍSICA" : oTransp.TipoPessoa == 'J' ? "JURÍDICA" : "");
                item.SubItems.Add(oTransp.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oTransp.Cpf_cnpj);
                item.SubItems.Add(oTransp.Rg_inscricaoEstadual);
                item.SubItems.Add(oTransp.Genero == 'M' ? "MASCULINO" : oTransp.Genero == 'F' ? "FEMININO" : "");
                item.SubItems.Add(oTransp.ACidade.Nome);
                item.SubItems.Add(oTransp.Email);
                item.SubItems.Add(oTransp.Telefone);
                item.SubItems.Add(oTransp.Ativo ? "Sim" : "Não");
                item.Tag = oTransp;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();
            var resultados = new List<transportadora>();
            var listaCompleta = aController_transportadora.ListaTransportadoras();

            if (string.IsNullOrWhiteSpace(termo))
            {
                resultados = listaCompleta;
            }
            else
            {
                foreach (var oTransp in listaCompleta)
                {
                    if (oTransp.Id.ToString().Contains(termo) ||
                        oTransp.Nome_razaoSocial.ToUpper().Contains(termo) ||
                        (oTransp.Cpf_cnpj ?? "").ToUpper().Contains(termo) ||
                        oTransp.Rg_inscricaoEstadual.ToUpper().Contains(termo))
                    {
                        resultados.Add(oTransp);
                    }
                }
            }

            foreach (var oTransp in resultados)
            {
                ListViewItem item = new ListViewItem(oTransp.Id.ToString());
                item.SubItems.Add(oTransp.Nome_razaoSocial);
                item.SubItems.Add(oTransp.TipoPessoa.ToString());
                item.SubItems.Add(oTransp.ACondicaoPagamento.Descricao);
                item.SubItems.Add(oTransp.Cpf_cnpj);
                item.SubItems.Add(oTransp.Rg_inscricaoEstadual);
                item.SubItems.Add(oTransp.Genero == ' ' ? "" : oTransp.Genero.ToString());
                item.SubItems.Add(oTransp.ACidade.Nome);
                item.SubItems.Add(oTransp.Email);
                item.SubItems.Add(oTransp.Telefone);
                item.SubItems.Add(oTransp.Ativo ? "Sim" : "Não");
                item.Tag = oTransp;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oTransportadora = (transportadora)linha.Tag;
            }
        }

        private void frmConsultaTransportadora_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oTransportadora = (transportadora)linha.Tag;

                if (!oTransportadora.Ativo)
                {
                    MessageBox.Show("Esta transportadora está inativa e não pode ser selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.Close();
            }
        }

        public override void Sair()
        {
            oTransportadora.Id = 0;
            base.Sair();
        }
    }
}

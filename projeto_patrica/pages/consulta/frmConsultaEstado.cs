using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
	public partial class frmConsultaEstado : projeto_patrica.pages.consulta.frmConsulta
	{
        frmCadastroEstado oFrmCadastroEstado;
        private estado oEstado;
        Controller_estado aController_estado;

        public frmConsultaEstado()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oEstado = (estado)obj;
            aController_estado = (Controller_estado)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroEstado.ConhecaObj(oEstado, aController_estado);
            oFrmCadastroEstado.Limpartxt();
            oFrmCadastroEstado.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            //base.Alterar();
            aController_estado.CarregaObj(oEstado);
            oFrmCadastroEstado.ConhecaObj(oEstado, aController_estado);
            oFrmCadastroEstado.Carregatxt();
            oFrmCadastroEstado.ShowDialog();
            this.CarregaLV();
        }
        public override void Pesquisar()
        {

        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = oFrmCadastroEstado.btnSave.Text;
            oFrmCadastroEstado.btnSave.Text = "Excluir";
            aController_estado.CarregaObj(oEstado);
            oFrmCadastroEstado.ConhecaObj(oEstado, aController_estado);
            oFrmCadastroEstado.Carregatxt();
            oFrmCadastroEstado.Bloqueiatxt();
            oFrmCadastroEstado.ShowDialog(this);
            oFrmCadastroEstado.Desbloqueiatxt();
            oFrmCadastroEstado.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            this.listV.Items.Clear();
            var lista = aController_estado.ListaEstados();
            foreach (var oEstado in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oEstado.Id));
                item.SubItems.Add(oEstado.Nome);
                //item.SubItems.Add(Convert.ToString(oEstado.OPais.Id));
                item.SubItems.Add(oEstado.OPais.Nome);
                listV.Items.Add(item);
            }

        }

        public override void setFrmCadastro(object obj)
        {
            if (obj != null)
            {
                oFrmCadastroEstado = (frmCadastroEstado)obj;
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oEstado.Id = Convert.ToInt16(linha.SubItems[0].Text);
                oEstado.Nome = linha.SubItems[1].Text;
                oEstado.OPais.Id = Convert.ToInt16(linha.SubItems[2].Text);
            }
        }
    }
}

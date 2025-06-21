using projeto_patrica.classes;
using projeto_patrica.controller;
using projeto_patrica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_patrica.pages.consulta
{
    public partial class frmConsultaMarca : frmConsulta
    {
        private frmCadastroMarca oFrmCadastroMarca;
        private marca oMarca;
        private Controller_marca aController_marca;

        public frmConsultaMarca() : base()
        {
            InitializeComponent();
        }

        public override void setFrmCadastro(object obj)
        {
            oFrmCadastroMarca = (frmCadastroMarca)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oMarca = (marca)obj;
            aController_marca = (Controller_marca)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oFrmCadastroMarca.ConhecaObj(new marca(), aController_marca);
            oFrmCadastroMarca.Desbloqueiatxt();
            oFrmCadastroMarca.Limpartxt();
            oFrmCadastroMarca.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            if (listV.SelectedItems.Count > 0)
            {
                string aux = oFrmCadastroMarca.btnSave.Text;
                oFrmCadastroMarca.btnSave.Text = "Alterar";
                base.Alterar();
                aController_marca.CarregaObj(oMarca);
                oFrmCadastroMarca.ConhecaObj(oMarca, aController_marca);
                oFrmCadastroMarca.Carregatxt();
                oFrmCadastroMarca.Desbloqueiatxt();
                oFrmCadastroMarca.ShowDialog();
                oFrmCadastroMarca.btnSave.Text = aux;
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
                string aux = oFrmCadastroMarca.btnSave.Text;
                oFrmCadastroMarca.btnSave.Text = "Excluir";
                aController_marca.CarregaObj(oMarca);
                oFrmCadastroMarca.ConhecaObj(oMarca, aController_marca);
                oFrmCadastroMarca.Carregatxt();
                oFrmCadastroMarca.Bloqueiatxt();
                oFrmCadastroMarca.ShowDialog(this);
                oFrmCadastroMarca.Desbloqueiatxt();
                oFrmCadastroMarca.btnSave.Text = aux;
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
            List<marca> lista = aController_marca.ListaMarcas();

            foreach (var m in lista)
            {
                ListViewItem item = new ListViewItem(m.Id.ToString());
                item.SubItems.Add(m.Nome);
                item.Tag = m;
                listV.Items.Add(item);
            }
        }

        public override void Pesquisar()
        {
            listV.Items.Clear();
            string termo = txtCodigo.Text.Trim().ToUpper();
            var resultados = new List<marca>();
            var listaCompleta = aController_marca.ListaMarcas();

            if (string.IsNullOrWhiteSpace(termo))
            {
                resultados = listaCompleta;
            }
            else
            {
                foreach (var m in listaCompleta)
                {
                    if (m.Id.ToString().Contains(termo) ||
                        m.Nome.ToUpper().Contains(termo))
                    {
                        resultados.Add(m);
                    }
                }
            }

            foreach (var m in resultados)
            {
                ListViewItem item = new ListViewItem(m.Id.ToString());
                item.SubItems.Add(m.Nome);
                item.Tag = m;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.ListV_SelectedIndexChanged(sender, e);
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oMarca = (marca)linha.Tag;
            }
        }

        private void frmConsultaMarca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                ListViewItem linha = listV.SelectedItems[0];
                oMarca = (marca)linha.Tag;

                if (!oMarca.Ativo)
                {
                    MessageBox.Show("Esta marca está inativa e não pode ser selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.Close();
            }
        }

        public override void Sair()
        {
            oMarca.Id = 0;
            base.Sair();
        }
    }
}

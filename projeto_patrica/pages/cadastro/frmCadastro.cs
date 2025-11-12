using projeto_patrica.classes;
using projeto_patrica.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastro : projeto_patrica.frmBase
    {
        public frmCadastro() : base()
        {
            InitializeComponent();
            txtCodigo.Enabled = false;
            this.Shown += (s, e) => CamposRestricoes();
        }

        public virtual void Salvar()
        {
            Sair();
        }

        public virtual void Alterar()
        {
            Sair();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        public virtual void Limpartxt()
        {
            txtCodigo.Text = "0";
            lblDataCadastroData.Text = "-";
            lblDataUltimaEdicaoData.Text = "-";
            lblUltimoUsuarioQueEditouNome.Text = "-";
            checkBoxAtivo.Checked = true;
            checkBoxAtivo.Enabled = false;
        }

        public virtual void Carregatxt()
        {
        }

        public virtual void Bloqueiatxt()
        {
            txtCodigo.Enabled = false;
            checkBoxAtivo.Enabled = false;
        }

        public virtual void Desbloqueiatxt()
        {
            checkBoxAtivo.Enabled = true;

        }

        public override void ConhecaObj(object obj, object ctrl)
        {

        }

        public virtual bool ValidacaoCampos()
        {
            return false;
        }

        public virtual void CamposRestricoes()
        {
            DisablePasteInTextBoxes(this.Controls);
        }

        public virtual void ApenasNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            e.Handled = true;
        }

        public virtual void ApenasNumerosDecimal(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                char ch = e.KeyChar;

                if (char.IsControl(ch))
                {
                    e.Handled = false;
                    return;
                }

                if (char.IsDigit(ch))
                {
                    if (textBox.Text.Contains(","))
                    {
                        int commaIndex = textBox.Text.IndexOf(',');
                        int decimalDigits = textBox.Text.Length - (commaIndex + 1);

                        if (textBox.SelectionStart > commaIndex && decimalDigits >= 6)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (textBox.Text.Length >= 18 && textBox.SelectionStart == textBox.Text.Length)
                        {
                            e.Handled = true;
                            return;
                        }
                    }

                    e.Handled = false;
                    return;
                }

                if (ch == '.')
                {
                    if (!textBox.Text.Contains(",") && textBox.Text.Length > 0)
                    {
                        int pos = textBox.SelectionStart;

                        textBox.Text = textBox.Text.Insert(pos, ",");
                        textBox.SelectionStart = pos + 1;
                    }

                    e.Handled = true;
                    return;
                }

                if (ch == ',')
                {
                    if (!textBox.Text.Contains(",") && textBox.Text.Length > 0)
                    {
                        e.Handled = false;
                        return;
                    }
                }

                e.Handled = true;
            }
        }

        private void DisablePasteInTextBoxes(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ShortcutsEnabled = false;
                }

                if (control.HasChildren)
                {
                    DisablePasteInTextBoxes(control.Controls);
                }
            }
        }
    }
}
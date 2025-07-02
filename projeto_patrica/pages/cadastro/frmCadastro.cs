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
            lblDataCadastroData.Text = " ";
            lblDataUltimaEdicaoData.Text = " ";
            lblUltimoUsuarioQueEditouNome.Text = " ";
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

        /// Permite a digitação apenas de números inteiros (0-9) e teclas de controle (ex: Backspace).
        /// Não permite vírgulas, pontos ou outros caracteres.
        public virtual void ApenasNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite caracteres de controle (como Backspace, Delete)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permite apenas dígitos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloqueia qualquer outro caractere (incluindo vírgulas e pontos)
            e.Handled = true;
        }

        /// Permite a digitação de números decimais com até 2 casas após a vírgula.
        /// Permite apenas uma vírgula, e a vírgula só pode ser digitada após pelo menos um número.
        /// Limita a 8 dígitos antes da vírgula.
        public virtual void ApenasNumerosDecimal(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                char ch = e.KeyChar;

                // Permite caracteres de controle (como Backspace, Delete)
                if (char.IsControl(ch))
                {
                    e.Handled = false;
                    return;
                }

                // Se for um dígito
                if (char.IsDigit(ch))
                {
                    // Se já houver uma vírgula
                    if (textBox.Text.Contains(","))
                    {
                        int commaIndex = textBox.Text.IndexOf(',');
                        // Calcula quantos dígitos já existem após a vírgula
                        int decimalDigits = textBox.Text.Length - (commaIndex + 1);

                        // Se o cursor estiver após a vírgula E já houver 2 dígitos decimais
                        if (textBox.SelectionStart > commaIndex && decimalDigits >= 2)
                        {
                            e.Handled = true; // Impede a digitação de mais dígitos decimais
                            return;
                        }
                    }
                    else // Se não houver vírgula
                    {
                        // Limita a 8 dígitos inteiros antes que a vírgula seja digitada
                        // (DECIMAL(10,2) = 8 inteiros + 2 decimais + 1 vírgula)
                        if (textBox.Text.Length >= 8 && textBox.SelectionStart == textBox.Text.Length)
                        {
                            e.Handled = true; // Impede mais de 8 dígitos inteiros
                            return;
                        }
                    }
                    e.Handled = false; // Permite o dígito
                    return;
                }

                // Se for uma vírgula
                if (ch == ',')
                {
                    // Permite apenas uma vírgula E não permite que seja o primeiro caractere
                    // (ou seja, deve haver pelo menos um número antes da vírgula)
                    if (!textBox.Text.Contains(",") && textBox.Text.Length > 0)
                    {
                        e.Handled = false; // Permite a vírgula
                        return;
                    }
                }

                // Bloqueia qualquer outro caractere
                e.Handled = true;
            }
        }

        // Desabilitar a colagem em todos os textboxes
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

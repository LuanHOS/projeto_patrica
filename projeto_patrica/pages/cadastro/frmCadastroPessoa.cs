using projeto_patrica.validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projeto_patrica.pages.cadastro
{
    public partial class frmCadastroPessoa : projeto_patrica.pages.cadastro.frmCadastro
    {
        public frmCadastroPessoa() : base()
        {
            InitializeComponent();
        }

        public void ApenasNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        public override void CamposRestricoes()
        {
            txtNomeRazaoSocial.MaxLength = 40;
            txtApelidoNomeFantasia.MaxLength = 40;
            txtCpfCnpj.MaxLength = 14;
            txtRgInscEstadual.MaxLength = 10;
            txtEmail.MaxLength = 40;
            txtTelefone.MaxLength = 20;
            txtEndereco.MaxLength = 40;
            txtNumeroEndereco.MaxLength = 20;
            txtComplementoEndereco.MaxLength = 40;
            txtBairro.MaxLength = 40;
            txtCep.MaxLength = 8;


            txtCpfCnpj.KeyPress -= ApenasNumeros;
            txtCpfCnpj.KeyPress += ApenasNumeros;

            txtRgInscEstadual.KeyPress -= ApenasNumeros;
            txtRgInscEstadual.KeyPress += ApenasNumeros;

            txtTelefone.KeyPress -= ApenasNumeros;
            txtTelefone.KeyPress += ApenasNumeros;

            txtCep.KeyPress -= ApenasNumeros;
            txtCep.KeyPress += ApenasNumeros;
        }

        public override bool ValidacaoCampos()
        {
            base.ValidacaoCampos();

            // --- CPF ou CNPJ ---
            string doc = txtCpfCnpj.Text.Trim();
            if (!string.IsNullOrEmpty(doc))
            {
                if (doc.Length <= 11 && !validaCPF.IsCpf(doc))
                {
                    MessageBox.Show("CPF inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpfCnpj.Focus();

                    return false;
                }
                else if (doc.Length > 11 && !validaCNPJ.IsCnpj(doc))
                {
                    MessageBox.Show("CNPJ inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpfCnpj.Focus();

                    return false;
                }
            }

            // --- E-mail ---
            txtEmail.MaxLength = 40;
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                MessageBox.Show("E-mail inválido. Informe um endereço de e-mail no formato correto (ex: nome@dominio.com).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();

                return false;
            }

            // --- CEP ---
            if (!string.IsNullOrWhiteSpace(txtCep.Text) && txtCep.Text.Length < 8)
            {
                MessageBox.Show("CEP inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCep.Focus();

                return false;
            }

            return true;
        }
    }
}
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
        protected bool isFisica;

        public frmCadastroPessoa() : base()
        {
            InitializeComponent();
            this.isFisica = true;
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
                if (isFisica) // Se for Pessoa Física (CPF)
                {
                    if (doc.Length != 11)
                    {
                        MessageBox.Show("CPF deve conter 11 dígitos.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCpfCnpj.Focus();
                        return false;
                    }
                    if (!validaCPF.IsCpf(doc))
                    {
                        MessageBox.Show("CPF inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCpfCnpj.Focus();
                        return false;
                    }
                }
                else // Se for Pessoa Jurídica (CNPJ)
                {
                    if (doc.Length != 14)
                    {
                        MessageBox.Show("CNPJ deve conter 14 dígitos.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCpfCnpj.Focus();
                        return false;
                    }
                    if (!validaCNPJ.IsCnpj(doc))
                    {
                        MessageBox.Show("CNPJ inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCpfCnpj.Focus();
                        return false;
                    }
                }
            }

            // --- Data de Nascimento/Criação ---
            if (dtpDataNascimentoCriacao.Value > DateTime.Today)
            {
                MessageBox.Show("A Data de Nascimento/Criação não pode ser uma data futura.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataNascimentoCriacao.Focus();
                return false;
            }

            // --- E-mail ---
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
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

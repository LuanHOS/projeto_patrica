using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_patrica
{
	public partial class frmBase : Form
	{
        public frmBase()
        {
            InitializeComponent();
            ConfigurarFormularioBase();
        }


        /*
         * 
         */


        private void frmBase_Load(object sender, EventArgs e)
        {

        }


        /*
         * 
         */


        public virtual void Sair()
        {
            Close();
        }


        /*
         * 
         */


        public virtual void ConhecaObj(object obj, object ctrl)
        {

        }


        /*
         * 
         */


        public void btnSair_Click(object sender, EventArgs e)
        {
            Sair();
        }


        /*
         * 
         */


        public void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public virtual void ConfigurarFormularioBase()
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.AutoScroll = true;
            this.CancelButton = this.btnSair;
            this.Size = new Size(1360, 728);
            this.MinimumSize = new Size(1360, 728);
            this.MaximumSize = new Size(1360, 728);
            this.AutoSize = false;
            //this.AutoSizeMode = AutoSizeMode.GrowOnly;
        }
    }
}

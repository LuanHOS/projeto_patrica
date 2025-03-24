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


        private void btnSair_Click(object sender, EventArgs e)
        {
            Sair();
        }
    }
}

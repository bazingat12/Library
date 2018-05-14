using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class WorkwithBooks : Form
    {
        public WorkwithBooks()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        }

        private void btnExemplar_Click(object sender, EventArgs e)
        {
            ListExemplar frm = new ListExemplar();
            this.Hide();
            frm.ShowDialog();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

        }

        private void btnWork_Click(object sender, EventArgs e)
        {
        }
    }
}

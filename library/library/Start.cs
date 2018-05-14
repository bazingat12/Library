using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace library
{
    public partial class Start : Form
    {
        
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-6OUPHJC/SQLEXPRESS; Initial Catalog = library5; Integrated Security = True");
        public Start()
        {
            InitializeComponent();
        }
        private void btnReader_Click(object sender, EventArgs e)
        {
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            txtLogin.Visible = true;
            btnLogin.Visible = true;
            btnClose.Visible = true;
            lbPass.Visible = true;
            btnReader.Visible = false;
            btnEmployee.Visible = false;
            btnExit.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "1")
            {
                MenuForEmployeeNew f2 = new MenuForEmployeeNew();
                this.Hide();
                f2.ShowDialog();
            }
            else
                MessageBox.Show("Пароль не введен или введен неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLogin.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtLogin.Visible = false;
            btnLogin.Visible = false;
            btnClose.Visible = false;
            lbPass.Visible = false;
            btnReader.Visible = true;
            btnExit.Visible = true;
            btnEmployee.Visible = true;
        }
    }
    }
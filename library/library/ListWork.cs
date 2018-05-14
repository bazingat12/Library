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
    public partial class ListWork : Form
    {
        //строка соединения, вязто из обозреватель решений App.config
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);
        public ListWork()
        {
            InitializeComponent();
        }

        //функция вывода информации в DataGridView по произведениям
        private void ShowWork()
        {
            try
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Author.name_author,Name FROM [library5].[dbo].[Works] INNER JOIN Author ON Works.ID_author = Author.ID_author", con);
                    da.Fill(dt);
                    dgvListBook.DataSource = dt.DefaultView;
                }
                catch (Exception)
                {
                    MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        private void dgvListBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int number = dgvListBook.CurrentRow.Index;
            //var k = dgvListBook.Rows[e.RowIndex].Cells[0].Value;
            // int l = Convert.ToInt32(k);
            AddBooks.id = number;
            AddBooks.text2 = "(" + dgvListBook[0, number].Value.ToString() + " '" + dgvListBook[1, number].Value.ToString() + "')";
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ListWork_Load(object sender, EventArgs e)
        {
            ShowWork();
        }
    }
}

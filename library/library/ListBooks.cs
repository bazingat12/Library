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
    public partial class ListBooks : Form
    {
        //строка соединения, вязто из обозреватель решений App.config
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);
        public ListBooks()
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
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Publisher._Publisher AS ПУБЛИКАТОР, NameBook AS НАИМЕНОВАНИЕ_КНИГИ, book_genre.Genre AS ЖАНР FROM dbo.Books INNER JOIN dbo.Publisher ON Books._ID_Publisher = Publisher.ID_Publisher INNER JOIN dbo.book_genre ON Books.GenreID = book_genre.GenreID", con);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int number = dgvListBook.CurrentRow.Index;
            //var k = dgvListBook.Rows[e.RowIndex].Cells[0].Value;
            // int l = Convert.ToInt32(k);
            AddBooks.work = number;
            AddBooks.text = "(" + dgvListBook[0, number].Value.ToString() + " '" + dgvListBook[1, number].Value.ToString() + "')";
            this.Hide();
        }

        private void ListBooks_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Works". При необходимости она может быть перемещена или удалена.
           // this.worksTableAdapter.Fill(this.library5DataSet.Works);
            ShowWork();

        }
    }
}

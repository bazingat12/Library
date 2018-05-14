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
    public partial class AddBooks : Form
    {
        public static int work = 0;
        public static string text = "";
        public static int id = 0;
        public static string text2 = "";
        //строка соединения, вязто из обозреватель решений App.config
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);
        public AddBooks()
        {
            InitializeComponent();
            panelListBook.Visible = false;
            panelBooks.Visible = false;
        }

        //функция вывода информации в DataGridView по книгам
        private void ShowBook()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Book AS КОД_КНИГИ, Publisher._Publisher AS ПУБЛИКАТОР, NameBook AS НАИМЕНОВАНИЕ_КНИГИ, book_genre.Genre AS ЖАНР FROM dbo.Books INNER JOIN dbo.Publisher ON Books._ID_Publisher = Publisher.ID_Publisher INNER JOIN dbo.book_genre ON Books.GenreID = book_genre.GenreID", con);
                da.Fill(dt);
                dgvBooks.DataSource = dt.DefaultView;
                dgvListBook.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по произведениям
        private void ShowWork()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Work AS КОД_ПРОИЗВЕДЕНИЯ, Author.name_author AS АВТОР, Name AS НАИМЕНОВАНИЕ_ПРОИЗВЕДЕНИЯ FROM dbo.Works INNER JOIN dbo.Author ON Works.ID_author = Author.ID_author", con);
                da.Fill(dt);
                dgvWork.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по авторам
        private void ShowAuthordgv()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_author AS КОД_АВТОРА, name_author AS ИМЯ_АВТОРА FROM Author", con);
                da.Fill(dt);
                dgvAuthor.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по жанрам
        private void ShowGenredgv()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT GenreID  AS КОД_ЖАНРА, Genre AS НАИМЕНОВАНИЕ FROM book_genre", con);
                da.Fill(dt);
                dgvGenre.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по издательствам
        private void ShowPub()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Publisher  AS КОД_ИЗДАТЕЛЬСТВА, _Publisher AS НАИМЕНОВАНИЕ FROM Publisher", con);
                da.Fill(dt);
                dgvPub.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по книгохранилищам
        private void ShowSafe()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_hr  AS КОД_ХРАНИЛИЩА, Name_Safe AS НАИМЕНОВАНИЕ FROM Book_depository", con);
                da.Fill(dt);
                dgvSafe.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по новым книга
        private void ShowNew()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT id_New AS КОД_КНИГИ, Employee.Surname AS ФАМИЛИЯ, Employee.Name AS ИМЯ, Employee.Patronymic AS ОТЧЕСТВО, ID_exemplar AS КОД_ЭКЗЕМПЛЯРА, view_book AS ПРИОБРЕТЕНИЕ, _price AS ЦЕНА, Name_Post AS ПОСТАВЩИК, Date_accept AS ДАТА FROM dbo.new_book INNER JOIN dbo.Employee ON new_book.ID_Employee = Employee.ID_Employee ", con);
                da.Fill(dt);
                dgvNew.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по выбывшим книга
        private void ShowOut()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT id_acces AS КОД_КНИГИ, Employee.Surname AS ФАМИЛИЯ, Employee.Name AS ИМЯ, Employee.Patronymic AS ОТЧЕСТВО, ID_exemplar AS КОД_ЭКЗЕМПЛЯРА, Data_access AS ДАТА, cause AS ПРИЧИНА FROM dbo.unfaithful_book INNER JOIN dbo.Employee ON unfaithful_book.ID_Employee = Employee.ID_Employee ", con);
                da.Fill(dt);
                dgvOut.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по экземплярам
        private void ShowExemplar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_exemplar AS КОД_ЭКЗЕМПЛЯРА, Books.NameBook AS НАИМЕНОВАНИЕ_КНИГИ, CountBook AS ТИП_ЭКЗЕМПЛЯРА FROM dbo.Exemplar INNER JOIN dbo.Books ON Exemplar.ID_Books = Books.ID_Book", con);
                da.Fill(dt);
                dgvExemplar.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по содержанию
        private void ShowContent()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Books.NameBook AS ИМЯ_КНКИГИ, Works.Name AS ИМЯ_ПРОИЗВЕДЕНИЯ, NumberBook AS СТРАНИЦА FROM [library5].[dbo].[Content] INNER JOIN Books ON Content.ID_Book = Books.ID_Book INNER JOIN Works ON Content.ID_Work = Works.ID_Work", con);
                da.Fill(dt);
                dgvContent.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }




        //класс для работы с данными
        public class Employee
        {
            public int ID_Employee { get; private set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }

            private Employee()
            {
                Surname = Name = Patronymic = string.Empty;
            }

            public Employee(SqlDataReader DR)
                : this()
            {
                ID_Employee = DR.GetInt32(DR.GetOrdinal("ID_Employee"));

                if (DR.GetValue(DR.GetOrdinal("Surname")) != null)
                    Surname = DR.GetString(DR.GetOrdinal("Surname"));

                if (DR.GetValue(DR.GetOrdinal("Name")) != null)
                    Name = DR.GetString(DR.GetOrdinal("Name"));

                if (DR.GetValue(DR.GetOrdinal("Patronymic")) != null)
                    Patronymic = DR.GetString(DR.GetOrdinal("Patronymic"));
            }

            public override string ToString()
            { return string.Format("{0} {1} {2}", Surname, Name, Patronymic); }

            public static List<Employee> EmployeeList(string strConn)
            {
                List<Employee> list = new List<Employee>();

                using (SqlConnection conn = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString))
                {
                    conn.Open();
                    SqlDataReader DR = null;
                    SqlCommand cmnd = new SqlCommand(qLoad, conn);
                    try
                    {
                        DR = cmnd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (DR.Read()) list.Add(new Employee(DR));
                    }
                    finally { if (DR != null) DR.Close(); }
                }

                return list;
            }

            // функция вывода в combobox
            public static void FillListBox(ComboBox lmb, string strConn)
            {
                lmb.Items.Clear();
                foreach (Employee fio in EmployeeList(strConn)) lmb.Items.Add(fio);
            }

            //запрос
            public static string qLoad { get { return "SELECT ID_Employee, Surname, Name, Patronymic FROM dbo.Employee"; } }
        }

        private void ShowEmployee()
        {
            FIO.FillListBox(cbEmployeeNew, "строкасоединениясбазойданных");
        }

        //класс для работы с данными
        public class FI
        {
            public int ID_Publisher { get; private set; }
            public string _Publisher { get; set; }
            private FI()
            {
                _Publisher = string.Empty;
            }

            public FI(SqlDataReader DR)
                : this()
            {
                ID_Publisher = (int)DR.GetInt32(DR.GetOrdinal("ID_Publisher"));

                if (DR.GetValue(DR.GetOrdinal("_Publisher")) != null)
                    _Publisher = DR.GetString(DR.GetOrdinal("_Publisher"));
            }
            public override string ToString()
            { return string.Format("{0}", _Publisher); }
            public static List<FI> FIOList(string strConn)
            {
                List<FI> list = new List<FI>();
                using (SqlConnection conn = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString))
                {
                    conn.Open();
                    SqlDataReader DR = null;
                    SqlCommand cmnd = new SqlCommand(qLoad, conn);
                    try
                    {
                        DR = cmnd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (DR.Read()) list.Add(new FI(DR));
                    }
                    finally { if (DR != null) DR.Close(); }
                }
                return list;
            }
            // функция вывода в combobox
            public static void FillListBox(ComboBox lmb, string strConn)
            {
                lmb.Items.Clear();
                foreach (FI fio in FIOList(strConn)) lmb.Items.Add(fio);
            }
            //запрос
            public static string qLoad { get { return "SELECT ID_Publisher, _Publisher FROM Publisher"; } }
        }
        private void ShowPublisher()
        {
            FI.FillListBox(cbPublisher, "строкасоединениясбазойданных");
        }



        //класс для работы с данными
        public class Author
        {
            public int ID_author { get; private set; }
            public string name_author { get; set; }
            private Author()
            {
                name_author = string.Empty;
            }
            public Author(SqlDataReader DR)
                : this()
            {
                ID_author = (int)DR.GetInt32(DR.GetOrdinal("ID_author"));

                if (DR.GetValue(DR.GetOrdinal("name_author")) != null)
                    name_author = DR.GetString(DR.GetOrdinal("name_author"));
            }
            public override string ToString()
            { return string.Format("{0}", name_author); }

            public static List<Author> AuthorList(string strConn)
            {
                List<Author> list = new List<Author>();
                using (SqlConnection conn = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString))
                {
                    conn.Open();
                    SqlDataReader DR = null;
                    SqlCommand cmnd = new SqlCommand(qLoad, conn);
                    try
                    {
                        DR = cmnd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (DR.Read()) list.Add(new Author(DR));
                    }
                    finally { if (DR != null) DR.Close(); }
                }
                return list;
            }
            // функция вывода в combobox
            public static void FillComboBox(ComboBox lmb, string strConn)
            {
                lmb.Items.Clear();
                foreach (Author authors in AuthorList(strConn)) lmb.Items.Add(authors);
            }
            //запрос
            public static string qLoad { get { return "SELECT ID_author, name_author FROM Author"; } }
        }
        private void ShowAuthor()
        {
            Author.FillComboBox(cbAuthor, "строкасоединениясбазойданных");
        }


        //класс для работы с данными
        public class FIO
        {
            public int GenreID { get; private set; }
            public string Genre { get; set; }


            private FIO()
            {
                Genre = string.Empty;
            }

            public FIO(SqlDataReader DR)
                : this()
            {
                GenreID = (int)DR.GetInt32(DR.GetOrdinal("GenreID"));

                if (DR.GetValue(DR.GetOrdinal("Genre")) != null)
                    Genre = DR.GetString(DR.GetOrdinal("Genre"));
            }

            public override string ToString()
            { return string.Format("{0}", Genre); }

            public static List<FIO> FIOList(string strConn)
            {
                List<FIO> list = new List<FIO>();

                using (SqlConnection conn = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString))
                {
                    conn.Open();
                    SqlDataReader DR = null;
                    SqlCommand cmnd = new SqlCommand(qLoad, conn);
                    try
                    {
                        DR = cmnd.ExecuteReader(CommandBehavior.CloseConnection);
                        while (DR.Read()) list.Add(new FIO(DR));
                    }
                    finally { if (DR != null) DR.Close(); }
                }

                return list;
            }

            // функция вывода в combobox
            public static void FillListBox(ComboBox lmb, string strConn)
            {
                lmb.Items.Clear();
                foreach (FIO fio in FIOList(strConn)) lmb.Items.Add(fio);
            }

            //запрос
            public static string qLoad { get { return "SELECT GenreID, Genre FROM book_genre"; } }
        }

        private void ShowGenre()
        {
            FIO.FillListBox(cbGenre, "строкасоединениясбазойданных");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int ID_Book = 15;
            if (ID_Book <= dgvBooks.Rows.Count)
                ID_Book = dgvBooks.Rows.Count + 1;
            int k = cbGenre.SelectedIndex + 1;
            int l = cbPublisher.SelectedIndex + 1;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Books", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Book;
            r[1] = l;
            r[2] = txtBook.Text;
            r[3] = k;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowBook();

            MessageBox.Show("Данные о книге добавлены!", "Сообщение");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            ShowBook();
            ShowGenre();
            ShowPublisher();
        }

        private void mnuListBook_Click(object sender, EventArgs e)
        {
            this.Height = 109;
            this.Width = 517;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelWork.Visible = false;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;          
            panelListBook.Visible = true;
            panelListBook.Location = new Point(12, 27);
            this.dgvBooks.Height = 177;
            this.dgvBooks.Width = 458;
            label13.Visible = false;
            dgvBooks.Visible = true;


        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int k = cbGenre.SelectedIndex + 1;
                int l = cbPublisher.SelectedIndex + 1;

                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Books where ID_Book=" + Convert.ToInt16(dgvBooks.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = l;
                dt.Rows[0][2] = txtBook.Text;
                dt.Rows[0][3] = k;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowBook();
                MessageBox.Show("Данные о книге изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void txtGoogleBook_TextChanged(object sender, EventArgs e)
        {
            btnDeleteBook.Visible = false;
            btnChangeBook.Visible = true;
            dgvBooks.Visible = true;
            this.Height = 289;
            this.Width = 517;
            dgvBooks.CurrentCell = null;
            {
                for (int i = 0; i < dgvBooks.RowCount; i++)
                {
                    dgvBooks.Rows[i].Visible = false;
                    for (int j = 0; j < dgvBooks.ColumnCount; j++)
                        if (dgvBooks.Rows[i].Cells[j].Value != null)
                            if (dgvBooks.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleBook.Text.ToLower()))
                            {
                                dgvBooks.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void txtGoogleListBook_TextChanged(object sender, EventArgs e)
        {
            btnChangeBook.Visible = true;
            dgvListBook.Visible = true;
            this.Height = 263;
            this.Width = 517;
            dgvListBook.CurrentCell = null;
            {
                for (int i = 0; i < dgvListBook.RowCount; i++)
                {
                    dgvListBook.Rows[i].Visible = false;
                    for (int j = 0; j < dgvListBook.ColumnCount; j++)
                        if (dgvListBook.Rows[i].Cells[j].Value != null)
                            if (dgvListBook.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleListBook.Text.ToLower()))
                            {
                                dgvListBook.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuAddBook_Click(object sender, EventArgs e)
        {
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = true;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            label2.Visible = false;
            txtID_Book.Visible = false;
            label13.Visible = false;
            lblGoogleBook.Visible = false;
            txtGoogleBook.Visible = false;
            btnListBook.Visible = false;
            dgvBooks.Visible = false;
            btnEditBook.Visible = false;
            this.Width = 517;
            this.Height = 179;
            label1.Visible = false;
            txtID_Book.Visible = false;
            label6.Visible = true;
            label6.Location = new Point(25, 26);
            label2.Location = new Point(25, 90);
            label5.Location = new Point(25, 52);
            label4.Location = new Point(25, 85);
            cbPublisher.Location = new Point(150, 20);
            txtBook.Location = new Point(150, 52);
            cbGenre.Location = new Point(150, 77);
        }

        private void mnuEditBook_Click(object sender, EventArgs e)
        {
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            label6.Visible = false;
            txtGoogleBook.Visible = true;
            lblGoogleBook.Visible = true;
            label13.Visible = true;
            btnListBook.Visible = true;
            btnAdd.Visible = false;
            label1.Location = new Point(25, 61);
            label2.Location = new Point(25, 90);
            label5.Location = new Point(25, 122);
            label4.Location = new Point(25, 155);
            txtID_Book.Location = new Point(150, 58);
            cbPublisher.Location = new Point(150, 90);
            txtBook.Location = new Point(150, 122);
            cbGenre.Location = new Point(150, 147);

            panelBooks.Visible = true;
            this.Height = 109;
            this.Width = 517;
        }

        private void btnChangeBook_Click(object sender, EventArgs e)
        {
            btnChangeBook.Visible = false;
            this.Height = 248;
            dgvBooks.Visible = false;
            int number = dgvBooks.CurrentRow.Index;
            txtID_Book.Text = dgvBooks[0, number].Value.ToString();
            cbPublisher.Text = dgvBooks[1, number].Value.ToString();
            txtBook.Text = (String)dgvBooks[2, number].Value;
            cbGenre.Text = dgvBooks[3, number].Value.ToString();
            lblNameExemplar.Visible = true;
            btnListBooks.Visible = true;
        }

        private void btnListBook_Click(object sender, EventArgs e)
        {
            btnDeleteBook.Visible = false;
            btnChangeBook.Visible = true;
            dgvBooks.Visible = true;
            this.Height = 289;
            this.Width = 517;
            dgvBooks.CurrentCell = null;
            {
                for (int i = 0; i < dgvBooks.RowCount; i++)
                {
                    dgvBooks.Rows[i].Visible = false;
                    for (int j = 0; j < dgvBooks.ColumnCount; j++)
                        if (dgvBooks.Rows[i].Cells[j].Value != null)
                            if (dgvBooks.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleBook.Text.ToLower()))
                            {
                                dgvBooks.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuDeleteBook_Click(object sender, EventArgs e)
        {
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = true;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            btnDeleteBook.Visible = true;
            this.Height = 263;
            this.Width = 517;
            panelBooks.Visible = false;
            panelListBook.Visible = true;
            panelListBook.Location = new Point(12, 27);
            this.dgvBooks.Height = 177;
            this.dgvBooks.Width = 458;
            label13.Visible = false;
            dgvListBook.Visible = true;
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Books where ID_Book=" + Convert.ToInt16(dgvListBook.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowBook();
                MessageBox.Show("Данные о книге удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnChangeBook.Visible = true;
            dgvListBook.Visible = true;
            this.Height = 263;
            this.Width = 517;
            dgvListBook.CurrentCell = null;
            {
                for (int i = 0; i < dgvListBook.RowCount; i++)
                {
                    dgvListBook.Rows[i].Visible = false;
                    for (int j = 0; j < dgvListBook.ColumnCount; j++)
                        if (dgvListBook.Rows[i].Cells[j].Value != null)
                            if (dgvListBook.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleListBook.Text.ToLower()))
                            {
                                dgvListBook.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            MenuForEmployeeNew frm = new MenuForEmployeeNew();
            this.Hide();
            frm.ShowDialog();
        }

        private void dgvListBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 288;
            btnDeleteBook.Visible = true;
        }

        private void mnuListWork_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            ShowWork();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            label7.Visible = false;
            cbAuthor.Visible = false;
            lblNameWork.Visible = false;
            txtNameWork.Visible = false;
            btnAddWork.Visible = false;
            btnEditWork.Visible = false;
            dgvWork.Visible = true;
            label8.Visible = false;
            lblGoogleWork.Visible = true;
            txtGoogleWork.Visible = true;
            btnGoogleWork.Visible = true;
            this.Height = 109;
            this.Width = 392;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = true;
            panelWork.Location = new Point(12, 27);
        }

        private void txtGoogleWork_TextChanged(object sender, EventArgs e)
        {
            btnChangeWork.Visible = true;
            btnGoogleWork.Visible = true;
            dgvWork.Visible = true;
            this.Height = 263;
            this.Width = 392;
            dgvWork.CurrentCell = null;
            {
                for (int i = 0; i < dgvWork.RowCount; i++)
                {
                    dgvWork.Rows[i].Visible = false;
                    for (int j = 0; j < dgvWork.ColumnCount; j++)
                        if (dgvWork.Rows[i].Cells[j].Value != null)
                            if (dgvWork.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleWork.Text.ToLower()))
                            {
                                dgvWork.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleWork_Click(object sender, EventArgs e)
        {
            dgvWork.Visible = true;
            this.Height = 263;
            this.Width = 392;
        }

        private void dgvWork_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvWork.Visible = true;
            this.Height = 287;
            this.Width = 392;
            btnChangeWork.Visible = true;
        }

        private void btnChangeWork_Click(object sender, EventArgs e)
        {
            ShowAuthor();
            btnChangeWork.Visible = false;
            this.Height = 211;
            dgvWork.Visible = false;
            txtIDWork.Visible = true;
            cbAuthor.Visible = true;
            txtNameWork.Visible = true;
            label12.Visible = true;
            label7.Visible = true;
            lblNameWork.Visible = true;
            btnEditWork.Visible = true;
            btnAddWork.Visible = false;
            int number = dgvWork.CurrentRow.Index;
            txtIDWork.Text = dgvWork[0, number].Value.ToString();
            cbAuthor.Text = dgvWork[1, number].Value.ToString();
            txtNameWork.Text = dgvWork[2, number].Value.ToString();
            panelWork.Location = new Point(12, 27);
            label12.Location = new Point(13, 61);
            label7.Location = new Point(13, 93);
            lblNameWork.Location = new Point(13, 125);
            cbAuthor.Location = new Point(120, 85);
            txtIDWork.Location = new Point(120, 51);
            txtNameWork.Location = new Point(120, 118);
        }

        private void mnuAddWork_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = true;
            panelWork.Location = new Point(12, 27);
            ShowAuthor();
            this.Height = 147;
            dgvWork.Visible = false;
            label8.Visible = false;
            lblGoogleWork.Visible = false;
            txtGoogleWork.Visible = false;
            btnGoogleWork.Visible = false;
            label12.Visible = false;
            txtIDWork.Visible = false;
            label7.Visible = true;
            cbAuthor.Visible = true;
            lblNameWork.Visible = true;
            txtNameWork.Visible = true;
            btnAddWork.Visible = true;
            btnEditWork.Visible = false;
            label7.Location = new Point(13, 25);
            lblNameWork.Location = new Point(13, 58);
            cbAuthor.Location = new Point(120, 17);
            txtNameWork.Location = new Point(120, 51);

        }

        private void mnuEditWork_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = true;
            panelWork.Location = new Point(12, 27);
            ShowWork();
            label7.Visible = false;
            cbAuthor.Visible = false;
            lblNameWork.Visible = false;
            txtNameWork.Visible = false;
            btnAddWork.Visible = false;
            btnEditWork.Visible = false;
            dgvWork.Visible = true;
            label8.Visible = false;
            lblGoogleWork.Visible = true;
            txtGoogleWork.Visible = true;
            btnGoogleWork.Visible = true;
            this.Height = 109;
            this.Width = 392;
            panelBooks.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = true;
        }

        private void btnAddWork_Click(object sender, EventArgs e)
        {
            int ID_Work = 11;
            if (ID_Work <= dgvWork.Rows.Count)
                ID_Work = dgvWork.Rows.Count + 1;
            int k = cbAuthor.SelectedIndex + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Works", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Work;
            r[1] = k;
            r[2] = txtNameWork.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowWork();
            MessageBox.Show("Данные о произведение добавлены!", "Сообщение");
        }

        private void btnEditWork_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                int k = cbAuthor.SelectedIndex + 1;
                DataTable dt = new DataTable();
                //  int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Works where ID_Work=" + Convert.ToInt16(dgvWork.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = k;
                dt.Rows[0][2] = txtNameWork.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowBook();
                MessageBox.Show("Данные о книге изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void mnuDeleteWork_Click(object sender, EventArgs e)
        {
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = true;
            panelWork.Location = new Point(12, 27);
            this.Height = 287;
            dgvWork.Visible = true;
            txtGoogleWork.Visible = false;
            btnGoogleWork.Visible = false;
            textBox1.Visible = true;
            label8.Visible = false;
            btnDeleteWork.Visible = true;
        }

        private void btnDeleteWork_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Works where ID_Work=" + Convert.ToInt16(dgvWork.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowWork();
                MessageBox.Show("Данные о произведение удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvWork.CurrentCell = null;
            {
                for (int i = 0; i < dgvWork.RowCount; i++)
                {
                    dgvWork.Rows[i].Visible = false;
                    for (int j = 0; j < dgvWork.ColumnCount; j++)
                        if (dgvWork.Rows[i].Cells[j].Value != null)
                            if (dgvWork.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleWork.Text.ToLower()))
                            {
                                dgvWork.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuListAuthor_Click(object sender, EventArgs e)
        {
            ShowAuthordgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = true;
            panelAuthor.Location = new Point(12, 27);

            lblStartAuthor.Visible = false;
            txtGoogleAuthor.Visible = true;
            lblGoogleAuthor.Visible = true;
            btnGoogleAuthor.Visible = true;
            txtGoogleAuthor2.Visible = false;
            txtIDAuthor.Visible = false;
            txtNameAuthor.Visible = false;
            lblIDAuthor.Visible = false;
            lblNameAuthor.Visible = false;
            btnDeleteAuthor.Visible = false;
            btnChangeAuthor.Visible = false;
            btnAddAuthor.Visible = false;
            btnEditAuthor.Visible = false;
            this.Height = 109;
            this.Width = 305;


        }

        private void txtGoogleAuthor_TextChanged(object sender, EventArgs e)
        {
            ShowGenredgv();
            this.Width = 305;
            btnChangeAuthor.Visible = true;
            btnDeleteAuthor.Visible = false;
            btnGoogleAuthor.Visible = true;
            txtGoogleAuthor.Visible = true;
            lblGoogleAuthor.Visible = true;
            dgvAuthor.Visible = true;
            this.Height = 263;
            dgvAuthor.CurrentCell = null;
            {
                for (int i = 0; i < dgvAuthor.RowCount; i++)
                {
                    dgvAuthor.Rows[i].Visible = false;
                    for (int j = 0; j < dgvAuthor.ColumnCount; j++)
                        if (dgvAuthor.Rows[i].Cells[j].Value != null)
                            if (dgvAuthor.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleAuthor.Text.ToLower()))
                            {
                                dgvAuthor.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleAuthor_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            btnChangeAuthor.Visible = true;
            btnDeleteAuthor.Visible = false;
            btnGoogleAuthor.Visible = true;
            txtGoogleAuthor.Visible = true;
            lblGoogleAuthor.Visible = true;
            dgvAuthor.Visible = true;
            this.Height = 263;
            this.Width = 305;
        }

        private void dgvAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 287;
        }

        private void mnuAddAuthor_Click(object sender, EventArgs e)
        {
            ShowAuthordgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = true;
            panelAuthor.Location = new Point(12, 27);

            dgvAuthor.Visible = false;
            lblStartAuthor.Visible = false;
            txtGoogleAuthor.Visible = false;
            lblGoogleAuthor.Visible = false;
            btnGoogleAuthor.Visible = false;
            txtGoogleAuthor2.Visible = false;
            txtIDAuthor.Visible = false;
            txtNameAuthor.Visible = true;
            lblIDAuthor.Visible = false;
            lblNameAuthor.Visible = true;
            btnDeleteAuthor.Visible = false;
            btnChangeAuthor.Visible = false;
            btnAddAuthor.Visible = true;
            btnEditAuthor.Visible = false;
            lblNameAuthor.Location = new Point(7, 21);
            txtNameAuthor.Location = new Point(86, 20);
            this.Height = 145;
            this.Width = 305;


        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            int ID_Author = 8;
            if (ID_Author <= dgvAuthor.Rows.Count)
                ID_Author = dgvAuthor.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Author", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Author;
            r[1] = txtNameAuthor.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowAuthordgv();

            MessageBox.Show("Данные о авторе добавлены!", "Сообщение");
        }

        private void mnuEditAuthor_Click(object sender, EventArgs e)
        {
            ShowAuthordgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = true;
            panelAuthor.Location = new Point(12, 27);

            lblStartAuthor.Visible = true;
            txtGoogleAuthor.Visible = true;
            lblGoogleAuthor.Visible = true;
            btnGoogleAuthor.Visible = true;
            txtGoogleAuthor2.Visible = false;
            txtIDAuthor.Visible = false;
            txtNameAuthor.Visible = false;
            lblIDAuthor.Visible = false;
            lblNameAuthor.Visible = false;
            btnDeleteAuthor.Visible = false;
            btnChangeAuthor.Visible = false;
            btnAddAuthor.Visible = false;
            btnEditAuthor.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void btnChangeAuthor_Click(object sender, EventArgs e)
        {
            btnChangeAuthor.Visible = false;
            this.Height = 202;
            dgvAuthor.Visible = false;
            lblStartAuthor.Visible = true;
            txtGoogleAuthor.Visible = true;
            lblGoogleAuthor.Visible = true;
            btnGoogleAuthor.Visible = true;
            txtGoogleAuthor2.Visible = false;
            txtIDAuthor.Visible = true;
            txtNameAuthor.Visible = true;
            lblIDAuthor.Visible = true;
            lblNameAuthor.Visible = true;
            btnDeleteAuthor.Visible = false;
            btnChangeAuthor.Visible = false;
            btnAddAuthor.Visible = false;
            btnEditAuthor.Visible = true;
            lblNameAuthor.Location = new Point(13, 90);
            txtNameAuthor.Location = new Point(97, 82);

            int number = dgvAuthor.CurrentRow.Index;
            txtIDAuthor.Text = dgvAuthor[0, number].Value.ToString();
            txtNameAuthor.Text = dgvAuthor[1, number].Value.ToString();
        }

        private void btnEditAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                //   con.Open();
                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Author where ID_author=" + Convert.ToInt16(dgvAuthor.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = txtNameAuthor.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowAuthordgv();
                MessageBox.Show("Данные об авторе изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void mnuDeleteAuthor_Click(object sender, EventArgs e)
        {
            ShowAuthordgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = true;
            panelAuthor.Location = new Point(12, 27);
            this.Height = 311;
            this.Width = 305;

            btnChangeAuthor.Visible = false;
            btnDeleteAuthor.Visible = true;
            lblStartAuthor.Visible = true;
            txtGoogleAuthor.Visible = true;
            lblGoogleAuthor.Visible = true;
            btnGoogleAuthor.Visible = false;
            txtGoogleAuthor2.Visible = true;
            dgvAuthor.Visible = true;


        }

        private void txtGoogleAuthor2_TextChanged(object sender, EventArgs e)
        {
            this.Width = 305;
            dgvAuthor.CurrentCell = null;
            {
                for (int i = 0; i < dgvAuthor.RowCount; i++)
                {
                    dgvAuthor.Rows[i].Visible = false;
                    for (int j = 0; j < dgvAuthor.ColumnCount; j++)
                        if (dgvAuthor.Rows[i].Cells[j].Value != null)
                            if (dgvAuthor.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleAuthor.Text.ToLower()))
                            {
                                dgvAuthor.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Author where ID_author=" + Convert.ToInt16(dgvAuthor.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowAuthordgv();
                MessageBox.Show("Данные об авторе удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }


        private void txtGoogleGenre_TextChanged(object sender, EventArgs e)
        {
            this.Width = 305;
            btnChangeGenre.Visible = true;
            btnDeleteGenre.Visible = false;
            btnGoogleGenre.Visible = true;
            txtGoogleGenre.Visible = true;
            lblGoogleGenre.Visible = true;
            dgvGenre.Visible = true;
            this.Height = 263;
            dgvGenre.CurrentCell = null;
            {
                for (int i = 0; i < dgvGenre.RowCount; i++)
                {
                    dgvGenre.Rows[i].Visible = false;
                    for (int j = 0; j < dgvGenre.ColumnCount; j++)
                        if (dgvGenre.Rows[i].Cells[j].Value != null)
                            if (dgvGenre.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleGenre.Text.ToLower()))
                            {
                                dgvGenre.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void txtGoogleGenre2_TextChanged(object sender, EventArgs e)
        {
            ShowGenredgv();
            this.Width = 305;
            dgvGenre.CurrentCell = null;
            {
                for (int i = 0; i < dgvGenre.RowCount; i++)
                {
                    dgvGenre.Rows[i].Visible = false;
                    for (int j = 0; j < dgvGenre.ColumnCount; j++)
                        if (dgvGenre.Rows[i].Cells[j].Value != null)
                            if (dgvGenre.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleGenre.Text.ToLower()))
                            {
                                dgvGenre.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from book_genre where GenreID=" + Convert.ToInt16(dgvGenre.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowGenredgv();
                MessageBox.Show("Данные о жанре удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void btnChangeGenre_Click(object sender, EventArgs e)
        {
            btnChangeGenre.Visible = false;
            this.Height = 202;
            dgvGenre.Visible = false;
            lblStartGenre.Visible = true;
            txtGoogleGenre.Visible = true;
            lblGoogleGenre.Visible = true;
            btnGoogleGenre.Visible = true;
            txtGoogleGenre2.Visible = false;
            txtIDGenre.Visible = true;
            txtNameGenre.Visible = true;
            lblIDGenre.Visible = true;
            lblNameGenre.Visible = true;
            btnDeleteGenre.Visible = false;
            btnChangeGenre.Visible = false;
            btnAddGenre.Visible = false;
            btnEditGenre.Visible = true;
            lblNameGenre.Location = new Point(13, 90);
            txtNameGenre.Location = new Point(97, 82);

            int number = dgvGenre.CurrentRow.Index;
            txtIDGenre.Text = dgvGenre[0, number].Value.ToString();
            txtNameGenre.Text = dgvGenre[1, number].Value.ToString();
        }

        private void btnEditGenre_Click(object sender, EventArgs e)
        {
            try
            {
                //   con.Open();
                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from book_genre where GenreID=" + Convert.ToInt16(dgvGenre.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = txtNameGenre.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowGenredgv();
                MessageBox.Show("Данные о жанре изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            int ID_Genre = 9;
            if (ID_Genre <= dgvGenre.Rows.Count)
                ID_Genre = dgvGenre.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from book_genre", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Genre;
            r[1] = txtNameGenre.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowGenredgv();

            MessageBox.Show("Данные о жанре добавлены!", "Сообщение");
        }

        private void mnuAddGenre_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = true;
            panelGenre.Location = new Point(12, 27);

            dgvGenre.Visible = false;
            lblStartGenre.Visible = false;
            txtGoogleGenre.Visible = false;
            lblGoogleGenre.Visible = false;
            btnGoogleGenre.Visible = false;
            txtGoogleGenre2.Visible = false;
            txtIDGenre.Visible = false;
            txtNameGenre.Visible = true;
            lblIDGenre.Visible = false;
            lblNameGenre.Visible = true;
            btnDeleteGenre.Visible = false;
            btnChangeGenre.Visible = false;
            btnAddGenre.Visible = true;
            btnEditGenre.Visible = false;
            lblNameGenre.Location = new Point(7, 21);
            txtNameGenre.Location = new Point(86, 20);
            this.Height = 145;
            this.Width = 305;
        }

        private void mnuEditGenre_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = true;
            panelGenre.Location = new Point(12, 27);

            lblStartGenre.Visible = true;
            txtGoogleGenre.Visible = true;
            lblGoogleGenre.Visible = true;
            btnGoogleGenre.Visible = true;
            txtGoogleGenre2.Visible = false;
            txtIDGenre.Visible = false;
            txtNameGenre.Visible = false;
            lblIDGenre.Visible = false;
            lblNameGenre.Visible = false;
            btnDeleteGenre.Visible = false;
            btnChangeGenre.Visible = false;
            btnAddGenre.Visible = false;
            btnEditGenre.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void mnuDeleteGenre_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = true;
            panelGenre.Location = new Point(12, 27);
            this.Height = 311;
            this.Width = 305;

            btnChangeGenre.Visible = false;
            btnDeleteGenre.Visible = true;
            lblStartGenre.Visible = true;
            txtGoogleGenre.Visible = true;
            lblGoogleGenre.Visible = true;
            btnGoogleGenre.Visible = false;
            txtGoogleGenre2.Visible = true;
            dgvGenre.Visible = true;
        }

        private void btnGoogleGenre_Click(object sender, EventArgs e)
        {
            btnChangeGenre.Visible = true;
            btnDeleteGenre.Visible = false;
            btnGoogleGenre.Visible = true;
            txtGoogleGenre.Visible = true;
            lblGoogleGenre.Visible = true;
            dgvGenre.Visible = true;
            this.Height = 263;
            this.Width = 305;
        }

        private void dgvGenre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 287;
        }

        private void mnuListPub_Click(object sender, EventArgs e)
        {
            ShowPub();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = true;
            panelPub.Location = new Point(12, 27);

            lblStartPub.Visible = false;
            txtGooglePub.Visible = true;
            lblGooglePub.Visible = true;
            btnGooglePub.Visible = true;
            txtGooglePub2.Visible = false;
            txtIDPub.Visible = false;
            txtNamePub.Visible = false;
            lblIDPub.Visible = false;
            lblNamePub.Visible = false;
            btnDeletePub.Visible = false;
            btnChangePub.Visible = false;
            btnAddPub.Visible = false;
            btnEditPub.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void mnuAddPub_Click(object sender, EventArgs e)
        {
            ShowPub();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = true;
            panelPub.Location = new Point(12, 27);

            dgvPub.Visible = false;
            lblStartPub.Visible = false;
            txtGooglePub.Visible = false;
            lblGooglePub.Visible = false;
            btnGooglePub.Visible = false;
            txtGooglePub2.Visible = false;
            txtIDPub.Visible = false;
            txtNamePub.Visible = true;
            lblIDPub.Visible = false;
            lblNamePub.Visible = true;
            btnDeletePub.Visible = false;
            btnChangePub.Visible = false;
            btnAddPub.Visible = true;
            btnEditPub.Visible = false;
            lblNamePub.Location = new Point(7, 21);
            txtNamePub.Location = new Point(86, 20);
            this.Height = 145;
            this.Width = 305;
        }

        private void mnuEditPub_Click(object sender, EventArgs e)
        {
            ShowPub();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = true;
            panelPub.Location = new Point(12, 27);

            lblStartPub.Visible = true;
            txtGooglePub.Visible = true;
            lblGooglePub.Visible = true;
            btnGooglePub.Visible = true;
            txtGooglePub2.Visible = false;
            txtIDPub.Visible = false;
            txtNamePub.Visible = false;
            lblIDPub.Visible = false;
            lblNamePub.Visible = false;
            btnDeletePub.Visible = false;
            btnChangePub.Visible = false;
            btnAddPub.Visible = false;
            btnEditPub.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void mnuDeletePub_Click(object sender, EventArgs e)
        {
            ShowPub();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = true;
            panelPub.Location = new Point(12, 27);
            this.Height = 311;
            this.Width = 305;

            btnChangePub.Visible = false;
            btnDeletePub.Visible = true;
            lblStartPub.Visible = true;
            txtGooglePub.Visible = true;
            lblGooglePub.Visible = true;
            btnGooglePub.Visible = false;
            txtGooglePub2.Visible = true;
            dgvPub.Visible = true;
        }

        private void txtGooglePub2_TextChanged(object sender, EventArgs e)
        {
            ShowPub();
            this.Width = 305;
            dgvPub.CurrentCell = null;
            {
                for (int i = 0; i < dgvPub.RowCount; i++)
                {
                    dgvPub.Rows[i].Visible = false;
                    for (int j = 0; j < dgvPub.ColumnCount; j++)
                        if (dgvPub.Rows[i].Cells[j].Value != null)
                            if (dgvPub.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGooglePub.Text.ToLower()))
                            {
                                dgvPub.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void txtGooglePub_TextChanged(object sender, EventArgs e)
        {
            ShowPub();
            this.Width = 305;
            btnChangePub.Visible = true;
            btnDeletePub.Visible = false;
            btnGooglePub.Visible = true;
            txtGooglePub.Visible = true;
            lblGooglePub.Visible = true;
            dgvPub.Visible = true;
            this.Height = 263;
            dgvPub.CurrentCell = null;
            {
                for (int i = 0; i < dgvPub.RowCount; i++)
                {
                    dgvPub.Rows[i].Visible = false;
                    for (int j = 0; j < dgvPub.ColumnCount; j++)
                        if (dgvPub.Rows[i].Cells[j].Value != null)
                            if (dgvPub.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGooglePub.Text.ToLower()))
                            {
                                dgvPub.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGooglePub_Click(object sender, EventArgs e)
        {
            ShowPub();
            btnChangePub.Visible = true;
            btnDeletePub.Visible = false;
            btnGooglePub.Visible = true;
            txtGooglePub.Visible = true;
            lblGooglePub.Visible = true;
            dgvPub.Visible = true;
            this.Height = 263;
            this.Width = 305;
        }

        private void dgvPub_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 287;
        }

        private void btnDeletePub_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Publisher where ID_Publisher=" + Convert.ToInt16(dgvPub.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowPub();
                MessageBox.Show("Данные о издателе удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void btnChangePub_Click(object sender, EventArgs e)
        {
            btnChangePub.Visible = false;
            this.Height = 202;
            dgvPub.Visible = false;
            lblStartPub.Visible = true;
            txtGooglePub.Visible = true;
            lblGooglePub.Visible = true;
            btnGooglePub.Visible = true;
            txtGooglePub2.Visible = false;
            txtIDPub.Visible = true;
            txtNamePub.Visible = true;
            lblIDPub.Visible = true;
            lblNamePub.Visible = true;
            btnDeletePub.Visible = false;
            btnChangePub.Visible = false;
            btnAddPub.Visible = false;
            btnEditPub.Visible = true;
            lblNamePub.Location = new Point(13, 90);
            txtNamePub.Location = new Point(97, 82);

            int number = dgvPub.CurrentRow.Index;
            txtIDPub.Text = dgvPub[0, number].Value.ToString();
            txtNamePub.Text = dgvPub[1, number].Value.ToString();
        }

        private void btnAddPub_Click(object sender, EventArgs e)
        {
            int ID_Pub = 8;
            if (ID_Pub <= dgvPub.Rows.Count)
                ID_Pub = dgvPub.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Publisher", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Pub;
            r[1] = txtNamePub.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowPub();

            MessageBox.Show("Данные об издателе добавлены!", "Сообщение");
        }

        private void btnEditPub_Click(object sender, EventArgs e)
        {
            try
            {
                //   con.Open();
                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Publisher where ID_publisher=" + Convert.ToInt16(dgvPub.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = txtNamePub.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowPub();
                MessageBox.Show("Данные об издателе изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void mnuListSafe_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = true;
            panelSafe.Location = new Point(12, 27);

            lblStartSafe.Visible = false;
            txtGoogleSafe.Visible = true;
            lblGoogleSafe.Visible = true;
            btnGoogleSafe.Visible = true;
            dgvPub.Visible = false;
            txtIDSafe.Visible = false;
            txtNameSafe.Visible = false;
            lblIDSafe.Visible = false;
            lblNameSafe.Visible = false;
            btnDeleteSafe.Visible = false;
            btnChangeSafe.Visible = false;
            btnAddSafe.Visible = false;
            btnEditSafe.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void mnuAddSafe_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = true;
            panelSafe.Location = new Point(12, 27);

            lblStartSafe.Visible = false;
            txtGoogleSafe.Visible = false;
            lblGoogleSafe.Visible = false;
            btnGoogleSafe.Visible = false;
            txtGoogleSafe2.Visible = false;
            txtIDSafe.Visible = false;
            txtNameSafe.Visible = true;
            lblIDSafe.Visible = false;
            lblNameSafe.Visible = true;
            btnDeleteSafe.Visible = false;
            btnChangeSafe.Visible = false;
            btnAddSafe.Visible = true;
            btnEditSafe.Visible = false;
            lblNameSafe.Location = new Point(7, 21);
            txtNameSafe.Location = new Point(86, 20);
            dgvSafe.Visible = false;
            this.Height = 145;
            this.Width = 305;
        }

        private void mnuEditSafe_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = true;
            panelSafe.Location = new Point(12, 27);

            lblStartSafe.Visible = true;
            txtGoogleSafe.Visible = true;
            lblGoogleSafe.Visible = true;
            btnGoogleSafe.Visible = true;
            txtGoogleSafe2.Visible = false;
            txtIDSafe.Visible = false;
            txtNameSafe.Visible = false;
            lblIDSafe.Visible = false;
            lblNameSafe.Visible = false;
            btnDeleteSafe.Visible = false;
            btnChangeSafe.Visible = false;
            btnAddSafe.Visible = false;
            btnEditSafe.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void mnuDeleteSafe_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = true;
            panelSafe.Location = new Point(12, 27);
            this.Height = 311;
            this.Width = 305;

            btnChangeSafe.Visible = false;
            btnDeleteSafe.Visible = true;
            lblStartSafe.Visible = true;
            txtGoogleSafe.Visible = true;
            lblGoogleSafe.Visible = true;
            btnGoogleSafe.Visible = false;
            txtGoogleSafe2.Visible = true;
            dgvSafe.Visible = true;
        }

        private void txtGoogleSafe_TextChanged(object sender, EventArgs e)
        {
            ShowSafe();
            this.Width = 305;
            btnChangeSafe.Visible = true;
            btnDeleteSafe.Visible = false;
            btnGoogleSafe.Visible = true;
            txtGoogleSafe.Visible = true;
            lblGoogleSafe.Visible = true;
            dgvSafe.Visible = true;
            this.Height = 263;
            dgvSafe.CurrentCell = null;
            {
                for (int i = 0; i < dgvSafe.RowCount; i++)
                {
                    dgvSafe.Rows[i].Visible = false;
                    for (int j = 0; j < dgvSafe.ColumnCount; j++)
                        if (dgvSafe.Rows[i].Cells[j].Value != null)
                            if (dgvSafe.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleSafe.Text.ToLower()))
                            {
                                dgvSafe.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleSafe_Click(object sender, EventArgs e)
        {
            ShowSafe();
            btnChangeSafe.Visible = true;
            btnDeleteSafe.Visible = false;
            btnGoogleSafe.Visible = true;
            txtGoogleSafe.Visible = true;
            lblGoogleSafe.Visible = true;
            dgvSafe.Visible = true;
            this.Height = 263;
            this.Width = 305;
        }

        private void txtGoogleSafe2_TextChanged(object sender, EventArgs e)
        {
            ShowSafe();
            this.Width = 305;
            dgvSafe.CurrentCell = null;
            {
                for (int i = 0; i < dgvSafe.RowCount; i++)
                {
                    dgvSafe.Rows[i].Visible = false;
                    for (int j = 0; j < dgvSafe.ColumnCount; j++)
                        if (dgvSafe.Rows[i].Cells[j].Value != null)
                            if (dgvSafe.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleSafe.Text.ToLower()))
                            {
                                dgvSafe.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void dgvSafe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 287;
        }

        private void btnAddSafe_Click(object sender, EventArgs e)
        {
            int ID_Safe = 5;
            if (ID_Safe <= dgvSafe.Rows.Count)
                ID_Safe = dgvSafe.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Book_depository", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Safe;
            r[1] = txtNameSafe.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowSafe();

            MessageBox.Show("Данные о книгохранилище добавлены!", "Сообщение");
        }

        private void btnEditSafe_Click(object sender, EventArgs e)
        {
            try
            {
                //   con.Open();
                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Book_depository where ID_hr=" + Convert.ToInt16(dgvSafe.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = txtNameSafe.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowSafe();
                MessageBox.Show("Данные о книгохранилище изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void btnDeleteSafe_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Book_depository where ID_hr=" + Convert.ToInt16(dgvSafe.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowSafe();
                MessageBox.Show("Данные о книгохранилище удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void btnChangeSafe_Click(object sender, EventArgs e)
        {
            btnChangeSafe.Visible = false;
            this.Height = 202;
            dgvSafe.Visible = false;
            lblStartSafe.Visible = true;
            txtGoogleSafe.Visible = true;
            lblGoogleSafe.Visible = true;
            btnGoogleSafe.Visible = true;
            txtGoogleSafe2.Visible = false;
            txtIDSafe.Visible = true;
            txtNameSafe.Visible = true;
            lblIDSafe.Visible = true;
            lblNameSafe.Visible = true;
            btnDeleteSafe.Visible = false;
            btnChangeSafe.Visible = false;
            btnAddSafe.Visible = false;
            btnEditSafe.Visible = true;
            lblNameSafe.Location = new Point(13, 90);
            txtNameSafe.Location = new Point(97, 82);

            int number = dgvSafe.CurrentRow.Index;
            txtIDSafe.Text = dgvSafe[0, number].Value.ToString();
            txtNameSafe.Text = dgvSafe[1, number].Value.ToString();
        }

        private void mnuListGenre_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = true;
            panelGenre.Location = new Point(12, 27);

            lblStartGenre.Visible = false;
            txtGoogleGenre.Visible = true;
            lblGoogleGenre.Visible = true;
            btnGoogleGenre.Visible = true;
            txtGoogleGenre2.Visible = false;
            txtIDGenre.Visible = false;
            txtNameGenre.Visible = false;
            lblIDGenre.Visible = false;
            lblNameGenre.Visible = false;
            btnDeleteGenre.Visible = false;
            btnChangeGenre.Visible = false;
            btnAddGenre.Visible = false;
            btnEditGenre.Visible = false;
            this.Height = 109;
            this.Width = 305;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            int ID_New = 2;
            int z = cbEmployeeNew.SelectedIndex + 1;
            if (ID_New <= dgvNew.Rows.Count)
                ID_New = dgvNew.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from new_book", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_New;
            r[1] = z;
            r[2] = txtIDExemplar.Text;
            r[3] = txtPostNew.Text;
            r[4] = txtPriceNew.Text;
            r[5] = txtDeliveryNew.Text; 
            r[6] = DateTime.Now.ToString("yyyy-MM-dd");
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowNew();

            MessageBox.Show("Данные о новой книге добавлены!", "Сообщение");
        }

        private void mnuListNew_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = true;
            panelNew.Location = new Point(12, 27);

            lblStartNew.Visible = false;
            txtGoogleNew.Visible = true;
            lblGoogleNew.Visible = true;
            btnGoogleNew.Visible = true;
            dgvNew.Visible = false;
            txtIDNew.Visible = false;
            lblIDNew.Visible = false;
            lblEmployeeNew.Visible = false;
            lblIDExemplar.Visible = false;
            lblPostNew.Visible = false;
            lblPriceNew.Visible = false;
            lblDeliveryNew.Visible = false;
            cbEmployeeNew.Visible = false;
            txtIDExemplar.Visible = false;
            txtPostNew.Visible = false;
            txtPriceNew.Visible = false;
            txtDeliveryNew.Visible = false;
            btnDeleteNew.Visible = false;
            btnChangeNew.Visible = false;
            btnAddNew.Visible = false;
            btnEditNew.Visible = false;
            this.Height = 109;
            this.Width = 506;


        }

        private void mnuAddNew_Click(object sender, EventArgs e)
        {
            ShowEmployee();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = true;
            dgvNew.Visible = false;
            panelNew.Location = new Point(12, 27);

            lblStartNew.Visible = false;
            txtGoogleNew.Visible = false;
            lblGoogleNew.Visible = false;
            btnGoogleNew.Visible = false;
            txtGoogleNew2.Visible = false;
            txtIDNew.Visible = false;
            lblIDNew.Visible = false;
            lblEmployeeNew.Visible = true;
            lblIDExemplar.Visible = true;
            lblPostNew.Visible = true;
            lblPriceNew.Visible = true;
            lblDeliveryNew.Visible = true;
            cbEmployeeNew.Visible = true;
            txtIDExemplar.Visible = true;
            txtPostNew.Visible = true;
            txtPriceNew.Visible = true;
            txtDeliveryNew.Visible = true;
            btnDeleteNew.Visible = false;
            btnChangeNew.Visible = false;
            btnAddNew.Visible = true;
            btnEditNew.Visible = false;
            lblEmployeeNew.Location = new Point(14, 21);
            lblIDExemplar.Location = new Point(14, 61);
            lblPostNew.Location = new Point (14, 95);
            lblPriceNew.Location = new Point(247, 21);
            lblDeliveryNew.Location = new Point(247, 61);
            cbEmployeeNew.Location = new Point(120, 18);
            txtIDExemplar.Location = new Point(120, 54);
            txtPostNew.Location = new Point(120, 84);
            txtPriceNew.Location = new Point(341, 17);
            txtDeliveryNew.Location = new Point(341, 58);
            this.Height = 179;
            this.Width = 512;
        }

        private void txtGoogleNew2_TextChanged(object sender, EventArgs e)
        {
            ShowNew();
            this.Height = 261;
            this.Width = 506;
            btnChangeNew.Visible = false;
            btnDeleteNew.Visible = true;
            btnGoogleNew.Visible = true;
            txtGoogleNew.Visible = true;
            lblGoogleNew.Visible = true;
            dgvNew.Visible = true;
            dgvNew.CurrentCell = null;
            {
                for (int i = 0; i < dgvNew.RowCount; i++)
                {
                    dgvNew.Rows[i].Visible = false;
                    for (int j = 0; j < dgvNew.ColumnCount; j++)
                        if (dgvNew.Rows[i].Cells[j].Value != null)
                            if (dgvNew.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleNew.Text.ToLower()))
                            {
                                dgvNew.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleNew_Click(object sender, EventArgs e)
        {
            ShowNew();
            this.Height = 261;
            this.Width = 506;
            dgvNew.Visible = true;
        }

        private void txtGoogleNew_TextChanged(object sender, EventArgs e)
        {
            ShowNew();
            this.Height = 261;
            this.Width = 506;
            btnChangeNew.Visible = true;
            btnDeleteNew.Visible = false;
            btnGoogleNew.Visible = true;
            txtGoogleNew.Visible = true;
            lblGoogleNew.Visible = true;
            dgvNew.Visible = true;
            dgvNew.CurrentCell = null;
            {
                for (int i = 0; i < dgvNew.RowCount; i++)
                {
                    dgvNew.Rows[i].Visible = false;
                    for (int j = 0; j < dgvNew.ColumnCount; j++)
                        if (dgvNew.Rows[i].Cells[j].Value != null)
                            if (dgvNew.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleNew.Text.ToLower()))
                            {
                                dgvNew.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuDeleteNew_Click(object sender, EventArgs e)
        {
            ShowNew();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = true;
            dgvNew.Visible = false;
            panelNew.Location = new Point(12, 27);

            this.Height =  265;
            dgvNew.Visible = true;
            btnDeleteNew.Visible = true;
        }

        private void dgvNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 289;
        }

        private void btnChangeNew_Click(object sender, EventArgs e)
        {
            btnChangeNew.Visible = false;
            this.Height = 248;
            dgvNew.Visible = false;
            lblStartNew.Visible = true;
            txtGoogleNew.Visible = true;
            lblGoogleNew.Visible = true;
            btnGoogleNew.Visible = true;
            txtGoogleNew2.Visible = false;
            txtIDNew.Visible = true;
            lblIDNew.Visible = true;
            lblEmployeeNew.Visible = true;
            lblIDExemplar.Visible = true;
            lblPostNew.Visible = true;
            lblPriceNew.Visible = true;
            lblDeliveryNew.Visible = true;
            cbEmployeeNew.Visible = true;
            txtIDExemplar.Visible = true;
            txtPostNew.Visible = true; ;
            txtPriceNew.Visible = true;
            txtDeliveryNew.Visible = true;
            btnDeleteNew.Visible = false;
            btnChangeNew.Visible = false;
            btnAddNew.Visible = false;
            btnEditNew.Visible = true;
            txtIDNew.Location = new Point(120, 54);
            lblIDNew.Location = new Point(13, 61);
            lblEmployeeNew.Location = new Point(13, 93);
            lblIDExemplar.Location = new Point(13, 125);
            lblPostNew.Location = new Point(247, 61);
            lblPriceNew.Location = new Point(247, 93);
            lblDeliveryNew.Location = new Point(247, 121);
            cbEmployeeNew.Location = new Point(120, 85);
            txtIDExemplar.Location = new Point(120, 118);
            txtPostNew.Location = new Point(341, 58);
            txtPriceNew.Location = new Point(341, 86);
            txtDeliveryNew.Location = new Point(341, 118);

            int number = dgvNew.CurrentRow.Index;
            txtIDNew.Text = dgvNew[0, number].Value.ToString();
            cbEmployeeNew.Text = dgvNew[1, number].Value.ToString();
            txtIDExemplar.Text = dgvNew[2, number].Value.ToString();
            txtPostNew.Text = dgvNew[3, number].Value.ToString();
            txtPriceNew.Text = dgvNew[4, number].Value.ToString();
            txtDeliveryNew.Text = dgvNew[5, number].Value.ToString();
        }

        private void btnEditNew_Click(object sender, EventArgs e)
        {
            try
            {
                //   con.Open();
                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from new_book where id_New=" + Convert.ToInt16(dgvNew.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = cbEmployeeNew.Text;
                dt.Rows[0][2] = txtIDExemplar.Text;
                dt.Rows[0][3] = txtPostNew.Text;
                dt.Rows[0][4] = txtPriceNew.Text;
                dt.Rows[0][5] = txtDeliveryNew.Text;

                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowNew();
                MessageBox.Show("Данные о новой книге изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void btnDeleteNew_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from new_book where id_New=" + Convert.ToInt16(dgvNew.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowNew();
                MessageBox.Show("Данные о новой книге удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void mnuEditNew_Click(object sender, EventArgs e)
        {
            ShowGenredgv();
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelSafe.Visible = true;
            panelNew.Visible = true;
            panelNew.Location = new Point(12, 27);

            lblStartNew.Visible = false;
            txtGoogleNew.Visible = true;
            lblGoogleNew.Visible = true;
            btnGoogleNew.Visible = true;
            dgvNew.Visible = false;
            txtIDNew.Visible = false;
            lblIDNew.Visible = false;
            lblEmployeeNew.Visible = false;
            lblIDExemplar.Visible = false;
            lblPostNew.Visible = false;
            lblPriceNew.Visible = false;
            lblDeliveryNew.Visible = false;
            cbEmployeeNew.Visible = false;
            txtIDExemplar.Visible = false;
            txtPostNew.Visible = false;
            txtPriceNew.Visible = false;
            txtDeliveryNew.Visible = false;
            btnDeleteNew.Visible = false;
            btnChangeNew.Visible = false;
            btnAddNew.Visible = false;
            btnEditNew.Visible = false;
            this.Height = 251;
            this.Width = 512;
        }

        private void mnuListOut_Click(object sender, EventArgs e)
        {
            ShowOut();
            panelNew.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelOut.Visible = true;
            panelOut.Location = new Point(12, 27);

            lblStartOut.Visible = false;
            txtGoogleOut.Visible = true;
            lblGoogleOut.Visible = true;
            btnGoogleOut.Visible = true;
            dgvOut.Visible = false;
            txtIDOut.Visible = false;
            lblIDOut.Visible = false;
            lblEmployeeOut.Visible = false;
            lblIDExemplarOut.Visible = false;
            lblWhy.Visible = false;
            cbEmployeeOut.Visible = false;
            txtIDExemplarOut.Visible = false;
            txtWhy.Visible = false;
            btnDeleteOut.Visible = false;
            btnChangeOut.Visible = false;
            btnAddOut.Visible = false;
            btnEditOut.Visible = false;
            this.Height = 109;
            this.Width = 506;
        }

        private void btnGoogleOut_Click(object sender, EventArgs e)
        {
            ShowOut();
            this.Height = 261;
            this.Width = 506;
            dgvOut.Visible = true;
        }

        private void txtGoogleOut2_TextChanged(object sender, EventArgs e)
        {
            ShowOut();
            this.Height = 261;
            this.Width = 506;
            btnChangeOut.Visible = false;
            btnDeleteOut.Visible = true;
            btnGoogleOut.Visible = true;
            txtGoogleOut.Visible = true;
            lblGoogleOut.Visible = true;
            dgvOut.Visible = true;
            dgvOut.CurrentCell = null;
            {
                for (int i = 0; i < dgvOut.RowCount; i++)
                {
                    dgvOut.Rows[i].Visible = false;
                    for (int j = 0; j < dgvOut.ColumnCount; j++)
                        if (dgvOut.Rows[i].Cells[j].Value != null)
                            if (dgvOut.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleOut.Text.ToLower()))
                            {
                                dgvOut.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void txtGoogleOut_TextChanged(object sender, EventArgs e)
        {
            ShowOut();
            this.Height = 261;
            this.Width = 506;
            btnChangeOut.Visible = true;
            btnDeleteOut.Visible = false;
            btnGoogleOut.Visible = true;
            txtGoogleOut.Visible = true;
            lblGoogleOut.Visible = true;
            dgvOut.Visible = true;
            dgvOut.CurrentCell = null;
            {
                for (int i = 0; i < dgvOut.RowCount; i++)
                {
                    dgvOut.Rows[i].Visible = false;
                    for (int j = 0; j < dgvOut.ColumnCount; j++)
                        if (dgvOut.Rows[i].Cells[j].Value != null)
                            if (dgvOut.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleOut.Text.ToLower()))
                            {
                                dgvOut.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuDeleteOut_Click(object sender, EventArgs e)
        {
            ShowOut();
            panelNew.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelOut.Visible = true;
            panelOut.Location = new Point(12, 27);

            this.Height = 265;
            dgvOut.Visible = true;
            btnDeleteOut.Visible = true;
        }

        private void mnuAddOut_Click(object sender, EventArgs e)
        {
            ShowOut();
            panelNew.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelOut.Visible = true;
            panelOut.Location = new Point(12, 27);

            lblStartOut.Visible = false;
            txtGoogleOut.Visible = false;
            lblGoogleOut.Visible = false;
            btnGoogleOut.Visible = false;
            txtGoogleOut2.Visible = false;
            txtIDOut.Visible = false;
            lblIDOut.Visible = false;
            lblEmployeeOut.Visible = true;
            lblIDExemplarOut.Visible = true;
            lblWhy.Visible = true;
            cbEmployeeOut.Visible = true;
            txtIDExemplarOut.Visible = true;
            txtWhy.Visible = true;
            btnDeleteNew.Visible = false;
            btnChangeNew.Visible = false;
            btnAddNew.Visible = true;
            btnEditNew.Visible = false;
            lblEmployeeOut.Location = new Point(14, 21);
            lblIDExemplarOut.Location = new Point(14, 61);
            lblWhy.Location = new Point(14, 95);
            cbEmployeeOut.Location = new Point(120, 18);
            txtIDExemplarOut.Location = new Point(120, 54);
            txtWhy.Location = new Point(120, 84);
            this.Height = 179;
            this.Width = 512;
        }

        private void mnuEditOut_Click(object sender, EventArgs e)
        {
            ShowOut();
            panelNew.Visible = false;
            panelExemplar.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelOut.Visible = true;
            panelOut.Location = new Point(12, 27);

            lblStartOut.Visible = false;
            txtGoogleOut.Visible = true;
            lblGoogleOut.Visible = true;
            btnGoogleOut.Visible = true;
            dgvOut.Visible = false;
            txtIDOut.Visible = false;
            lblIDOut.Visible = false;
            lblEmployeeOut.Visible = false;
            lblIDExemplarOut.Visible = false;
            lblWhy.Visible = false;
            cbEmployeeOut.Visible = false;
            txtIDExemplarOut.Visible = false;
            txtWhy.Visible = false;
            btnDeleteOut.Visible = false;
            btnChangeOut.Visible = false;
            btnAddOut.Visible = false;
            btnEditOut.Visible = false;
            this.Height = 251;
            this.Width = 512;
        }

        private void dgvOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 289;
        }

        private void btnAddOut_Click(object sender, EventArgs e)
        {
            int ID_Out = 2;
            int z = cbEmployeeOut.SelectedIndex + 1;
            if (ID_Out <= dgvOut.Rows.Count)
                ID_Out = dgvOut.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from dbo.unfaithful_book", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ID_Out;
            r[1] = txtIDExemplar.Text;
            r[2] = z;
            r[3] = DateTime.Now.ToString("yyyy-MM-dd");
            r[4] = txtWhy.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowOut();

            MessageBox.Show("Данные о выбывшей книге добавлены!", "Сообщение");
        }

        private void btnEditOut_Click(object sender, EventArgs e)
        {
            try
            {
                //   con.Open();
                DataTable dt = new DataTable();
                int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from dbo.unfaithful_book where ID_acces=" + Convert.ToInt16(dgvOut.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = txtIDExemplar.Text;
                dt.Rows[0][2] = cbEmployeeNew.Text;
                dt.Rows[0][4] = txtWhy.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowOut();
                MessageBox.Show("Данные о выбывшей книге изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void btnDeleteOut_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from dbo.unfaithful_book where ID_acces=" + Convert.ToInt16(dgvOut.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowOut();
                MessageBox.Show("Данные о выбывшей книге удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void btnChangeOut_Click(object sender, EventArgs e)
        {
            btnChangeOut.Visible = false;
            this.Height = 248;
            dgvOut.Visible = false;
            lblStartOut.Visible = true;
            txtGoogleOut.Visible = true;
            lblGoogleOut.Visible = true;
            btnGoogleOut.Visible = true;
            txtGoogleOut2.Visible = false;
            txtIDOut.Visible = true;
            lblIDOut.Visible = true;
            lblEmployeeOut.Visible = true;
            lblIDExemplarOut.Visible = true;
            lblWhy.Visible = true;
            cbEmployeeOut.Visible = true;
            txtIDExemplarOut.Visible = true;
            txtWhy.Visible = true;
            btnDeleteOut.Visible = false;
            btnChangeOut.Visible = false;
            btnAddOut.Visible = false;
            btnEditOut.Visible = true;
            txtIDOut.Location = new Point(120, 54);
            lblIDOut.Location = new Point(13, 61);
            lblEmployeeOut.Location = new Point(13, 93);
            lblIDExemplarOut.Location = new Point(13, 125);
            lblWhy.Location = new Point(247, 61);
            cbEmployeeNew.Location = new Point(120, 85);
            txtIDExemplarOut.Location = new Point(120, 118);
            txtWhy.Location = new Point(347, 61);

            int number = dgvOut.CurrentRow.Index;
            txtIDOut.Text = dgvOut[0, number].Value.ToString();
            cbEmployeeOut.Text = dgvOut[1, number].Value.ToString();
            txtIDExemplarOut.Text = dgvOut[2, number].Value.ToString();
            txtWhy.Text = dgvOut[3, number].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void btnAddExemplar_Click(object sender, EventArgs e)
        {
            string gender = "единичная";
            if (rdb1.Checked == true)
            {
                gender = "единичная";
            }
            else if (rdb2.Checked == true)
            {
                gender = "сборник";
            }
            int ExemplarID = 17;
            if (ExemplarID <= dgvExemplar.Rows.Count)
                ExemplarID = dgvExemplar.Rows.Count + 1;
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Exemplar", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ExemplarID;
            r[1] = work + 1;
            r[2] = gender;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowExemplar();

            MessageBox.Show("Данные об экземпляре добавлены!", "Сообщение");
        }

        private void mnuListExemplar_Click(object sender, EventArgs e)
        {
            ShowExemplar();
            this.Width = 509;
            this.Height = 110;
            panelOut.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = false;
            panelExemplar.Visible = true;
            panelExemplar.Location = new Point(12, 27);
            btnDeleteExemplar.Visible = false;
            btnChangeExemplar.Visible = true;
            btnListBooks.Visible = false;
            lblNameExemplar.Visible = false;

            lblStartExemplar.Visible = true;
            lblGoogleExemplar.Visible = true;
            txtGoogleExemplar.Visible = true;
            btnGoogleExemplar.Visible = true;
            lblNameExemplar.Visible = false;
            btnListBooks.Visible = false;
        }

        private void btnListBooks_Click(object sender, EventArgs e)
        {
            ListBooks frm = new ListBooks();
            frm.ShowDialog();
            lblWork.Visible = true;
            lblWork.Text = text;
        }

        private void txtGoogleExemplar_TextChanged(object sender, EventArgs e)
        {
            ShowExemplar();
            // btnDeleteExemplar.Visible = false;
            //  btnChangeExemplar.Visible = true;
            dgvExemplar.Visible = true;
            this.Height = 262;
            this.Width = 509;
            btnChangeExemplar.Visible = true;
            btnDeleteExemplar.Visible = false;
            dgvExemplar.CurrentCell = null;
            {
                for (int i = 0; i < dgvExemplar.RowCount; i++)
                {
                    dgvExemplar.Rows[i].Visible = false;
                    for (int j = 0; j < dgvExemplar.ColumnCount; j++)
                        if (dgvExemplar.Rows[i].Cells[j].Value != null)
                            if (dgvExemplar.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleExemplar.Text.ToLower()))
                            {
                                dgvExemplar.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleExemplar_Click(object sender, EventArgs e)
        {
            ShowExemplar();
            dgvExemplar.Visible = true;
            this.Height = 262;
            this.Width = 509;
        }

        private void dgvExemplar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 288;
        }

        private void mnuEditExemplar_Click(object sender, EventArgs e)
        {
            ShowExemplar();
            this.Width = 509;
            this.Height = 110;
            panelOut.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = false;
            panelExemplar.Visible = true;
            panelExemplar.Location = new Point(12, 27);

            // btnListBooks.Visible = false;
            // lblNameExemplar.Visible = false;

            lblStartExemplar.Visible = true;
            lblGoogleExemplar.Visible = true;
            txtGoogleExemplar.Visible = true;
            btnGoogleExemplar.Visible = true;
            btnListBooks.Visible = false;
            lblNameExemplar.Visible = false;
            btnDeleteExemplar.Visible = false;
            btnChangeExemplar.Visible = true;
            lblStartExemplar.Visible = true;
            lblGoogleExemplar.Visible = true;
            txtGoogleExemplar.Visible = true;
            btnGoogleExemplar.Visible = true;
            label14.Visible = true;
            textBox2.Visible = true;
            lblNameExemplar.Location = new Point(28, 94);
            lblTipExemplar.Location = new Point(28, 128);
            btnListBooks.Location = new Point(152, 92);
            rdb1.Location = new Point(146, 127);
            rdb2.Location = new Point(231, 127);
        }

        private void mnuDeleteexemplar_Click(object sender, EventArgs e)
        {
            ShowExemplar();
            this.Width = 509;
            this.Height = 287;
            btnListBooks.Visible = false;
            lblNameExemplar.Visible = false;
            panelOut.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = false;
            panelExemplar.Visible = true;
            panelExemplar.Location = new Point(12, 27);

            dgvExemplar.Visible = true;
            lblStartExemplar.Visible = true;
            lblGoogleExemplar.Visible = true;
            txtGoogleExemplar.Visible = true;
            btnDeleteExemplar.Visible = true;
            btnChangeExemplar.Visible = false;
            btnChangeExemplar.Visible = false;
            btnDeleteExemplar.Visible = true;
            lblNameExemplar.Visible = false;
            btnListBooks.Visible = false;
        }

        private void mnuAddExemplar_Click(object sender, EventArgs e)
        {
            panelOut.Visible = false;
            panelContent.Visible = false;
            panelBooks.Visible = false;
            panelWork.Visible = false;
            panelListBook.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelNew.Visible = false;
            panelExemplar.Visible = true;
            panelExemplar.Location = new Point(12, 27);

            dgvExemplar.Visible = false;
            lblStartExemplar.Visible = false;
            lblGoogleExemplar.Visible = false;
            btnGoogleExemplar.Visible = false;
            txtGoogleExemplar.Visible = false;
            lblWork.Visible = false;
            btnEditExemplar.Visible = false;
            btnChangeExemplar.Visible = false;
            btnDeleteExemplar.Visible = false;
            label14.Visible = false;
            textBox2.Visible = false;
            lblNameExemplar.Visible = true;
            lblTipExemplar.Visible = true;
            btnListBooks.Visible = true;
            rdb1.Visible = true;
            rdb2.Visible = true;
            btnAddExemplar.Visible = true;
            this.Height = 150;
            this.Width = 509;


            lblNameExemplar.Location = new Point(10, 20);
            lblTipExemplar.Location = new Point(14, 54);
            btnListBooks.Location = new Point(152, 18);
            rdb1.Location = new Point(152, 58);
            rdb2.Location = new Point(237, 58);
        }

        private void btnChangeExemplar_Click(object sender, EventArgs e)
        {
            lblNameExemplar.Visible = true;
            btnListBooks.Visible = true;
            btnChangeExemplar.Visible = false;
            btnAddExemplar.Visible = false;
            btnEditExemplar.Visible = true;
            this.Height = 219;
            lblWork.Visible = true;
            dgvExemplar.Visible = false;
            int number = dgvExemplar.CurrentRow.Index;
            textBox2.Text = dgvExemplar[0, number].Value.ToString();
            lblWork.Text = dgvExemplar[1, number].Value.ToString();
            if (dgvExemplar[2, number].Value.ToString() == "единичная")
                rdb1.Checked = true;
            else
                rdb2.Checked = true;
        }

        private void btnEditExemplar_Click(object sender, EventArgs e)
        {
            btnChangeExemplar.Visible = true;
            btnDeleteExemplar.Visible = true;
            try
            {
                //con.Open();


                DataTable dt = new DataTable();
                // int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Exemplar where ID_Exemplar=" + Convert.ToInt16(dgvExemplar.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = work;
                if (rdb1.Checked == true)
                    dt.Rows[0][2] = "единичная";
                else
                    dt.Rows[0][2] = "сборник";
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowExemplar();
                MessageBox.Show("Данные об экземпляре изменены!", "Сообщение");

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void txtGoogleExemplar2_TextChanged(object sender, EventArgs e)
        {
            ShowExemplar();
            // btnDeleteExemplar.Visible = false;
            //  btnChangeExemplar.Visible = true;
            dgvExemplar.Visible = true;
            this.Height = 262;
            this.Width = 509;
            btnChangeExemplar.Visible = false;
            btnDeleteExemplar.Visible = true;
            dgvExemplar.CurrentCell = null;
            {
                for (int i = 0; i < dgvExemplar.RowCount; i++)
                {
                    dgvExemplar.Rows[i].Visible = false;
                    for (int j = 0; j < dgvExemplar.ColumnCount; j++)
                        if (dgvExemplar.Rows[i].Cells[j].Value != null)
                            if (dgvExemplar.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleExemplar.Text.ToLower()))
                            {
                                dgvExemplar.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnDeleteExemplar_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Exemplar where ID_Exemplar=" + Convert.ToInt16(dgvExemplar.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowExemplar();
                MessageBox.Show("Данные об экземпляре удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void mnuListContent_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            ShowContent();
            textBox1.Visible = false;
            ShowWork();
            label7.Visible = false;
            cbAuthor.Visible = false;
            lblNameWork.Visible = false;
            txtNameWork.Visible = false;
            btnAddWork.Visible = false;
            btnEditWork.Visible = false;
            label8.Visible = false;
            this.Height = 109;
            this.Width = 390;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelContent.Visible = true;
            panelContent.Location = new Point(12, 27);
            lblStartContent.Visible = true;
            lblGoogleContent.Visible = true;
            txtGoogleContent.Visible = true;
            btnGoogleContent.Visible = true;
            btnChangeContent.Visible = true;
            btnDeleteContent.Visible = false;
            btnListBooks2.Visible = false;
            lblBookContent.Visible = false;
        }

        private void txtGoogleContent_TextChanged(object sender, EventArgs e)
        {
            ShowContent();
            btnDeleteContent.Visible = false;
            btnChangeContent.Visible = true;
            dgvContent.Visible = true;
            this.Height = 260;
            dgvContent.CurrentCell = null;
            {
                for (int i = 0; i < dgvContent.RowCount; i++)
                {
                    dgvContent.Rows[i].Visible = false;
                    for (int j = 0; j < dgvContent.ColumnCount; j++)
                        if (dgvContent.Rows[i].Cells[j].Value != null)
                            if (dgvContent.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleContent.Text.ToLower()))
                            {
                                dgvContent.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleContent_Click(object sender, EventArgs e)
        {
            ShowContent();
            btnDeleteContent.Visible = false;
            btnChangeContent.Visible = true;
            dgvContent.Visible = true;
            this.Height = 260;
            dgvContent.CurrentCell = null;
            {
                for (int i = 0; i < dgvContent.RowCount; i++)
                {
                    dgvContent.Rows[i].Visible = false;
                    for (int j = 0; j < dgvContent.ColumnCount; j++)
                        if (dgvContent.Rows[i].Cells[j].Value != null)
                            if (dgvContent.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleContent.Text.ToLower()))
                            {
                                dgvContent.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void dgvContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 288;
        }

        private void mnuEditContent_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            ShowContent();
            textBox1.Visible = false;
            ShowWork();
            label7.Visible = false;
            cbAuthor.Visible = false;
            lblNameWork.Visible = false;
            txtNameWork.Visible = false;
            btnAddWork.Visible = false;
            btnEditWork.Visible = false;
            label8.Visible = false;
            this.Height = 109;
            this.Width = 390;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelContent.Visible = true;
            panelContent.Location = new Point(12, 27);
            lblStartContent.Visible = true;
            lblGoogleContent.Visible = true;
            txtGoogleContent.Visible = true;
            btnGoogleContent.Visible = true;
            btnChangeContent.Visible = true;
            btnDeleteContent.Visible = false;
            btnListBooks2.Visible = false;
            lblBookContent.Visible = false;
        }

        private void mnuDeleteContent_Click(object sender, EventArgs e)
        {
            btnGoogleContent.Visible = false;
            ShowContent();
            textBox1.Visible = false;
            ShowWork();
            label7.Visible = false;
            cbAuthor.Visible = false;
            lblNameWork.Visible = false;
            txtNameWork.Visible = false;
            btnAddWork.Visible = false;
            btnEditWork.Visible = false;
            label8.Visible = false;
            this.Height = 288;
            this.Width = 390;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelContent.Visible = true;
            panelContent.Location = new Point(12, 27);
            lblStartContent.Visible = true;
            lblGoogleContent.Visible = true;
            txtGoogleContent.Visible = true;
            btnGoogleContent.Visible = true;
            btnChangeContent.Visible = false;
            btnDeleteContent.Visible = true;
            dgvContent.Visible = true;
        }

        private void mnuAddContent_Click(object sender, EventArgs e)
        {
            this.Height = 172;
            this.Width = 390;
            panelOut.Visible = false;
            panelExemplar.Visible = false;
            panelBooks.Visible = false;
            panelAuthor.Visible = false;
            panelGenre.Visible = false;
            panelNew.Visible = false;
            panelPub.Visible = false;
            panelSafe.Visible = false;
            panelListBook.Visible = false;
            panelWork.Visible = false;
            panelContent.Visible = true;
            panelContent.Location = new Point(12, 27);
            lblStartContent.Visible = false;
            lblGoogleContent.Visible = false;
            txtGoogleContent.Visible = false;
            btnGoogleContent.Visible = false;
            btnChangeContent.Visible = false;
            btnDeleteContent.Visible = false;

            dgvContent.Visible = false;
            lblBookContent.Visible = true;
            lblWorkContent.Visible = true;
            lblContent.Visible = true;
            btnListBooks2.Visible = true;
            btnListWorks.Visible = true;
            txtContent.Visible = true;
            btnAddContent.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label9.Location = new Point(183, 21);
            label10.Location = new Point(183, 52);
            lblBookContent.Location = new Point(9, 24);
            lblWorkContent.Location = new Point(9, 53);
            lblContent.Location = new Point(9, 81);
            btnListBooks2.Location = new Point(99, 15);
            btnListWorks.Location = new Point(99, 47);
            txtContent.Location = new Point(99, 78);
        }

        private void btnChangeContent_Click(object sender, EventArgs e)
        {
            btnAddContent.Visible = false;
            btnChangeContent.Visible = false;
            this.Height = 202;
            dgvContent.Visible = false;
            int number = dgvContent.CurrentRow.Index;
            label9.Text = dgvContent[0, number].Value.ToString();
            label10.Text = dgvContent[1, number].Value.ToString();
            txtContent.Text = dgvContent[2, number].Value.ToString();
            lblBookContent.Visible = true;
            lblWorkContent.Visible = true;
            lblContent.Visible = true;
            btnListBooks2.Visible = true;
            btnListWorks.Visible = true;
            txtContent.Visible = true;
            btnAddContent.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label9.Location = new Point(183, 52);
            label10.Location = new Point(183, 85);
            lblBookContent.Location = new Point(11, 56);
            lblWorkContent.Location = new Point(11, 87);
            lblContent.Location = new Point(11, 114);
            btnListBooks2.Location = new Point(101, 48);
            btnListWorks.Location = new Point(101, 80);
            txtContent.Location = new Point(101, 111);
        }

        private void btnListBooks2_Click(object sender, EventArgs e)
        {
            ListBooks frm = new ListBooks();
            frm.ShowDialog();
            label9.Text = text;
        }

        private void btnListWorks_Click(object sender, EventArgs e)
        {
            ListWork frm = new ListWork();
            frm.ShowDialog();
            label10.Text = text2;
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            // con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Content", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = work+1;
            r[1] = id + 1;
            r[2] = txtContent.Text;
            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowContent();

            MessageBox.Show("Данные о нахождение произвдения добавлены!", "Сообщение");
        }

        private void btnEditContent_Click(object sender, EventArgs e)
        {
            btnChangeContent.Visible = true;
            btnDeleteContent.Visible = true;
           /* try
            {*/
                //con.Open();
                DataTable dt = new DataTable();
                // int number = dgvBooks.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Content where ID_Book=" + Convert.ToInt16(dgvContent.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
            int number = dgvContent.CurrentRow.Index;
            dt.Rows[0].BeginEdit();
                dt.Rows[0][0] = work+1;
                dt.Rows[0][1] = id+1;
                dt.Rows[0][2] = txtContent.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowContent();
                MessageBox.Show("Данные о расположение произвдения изменены!", "Сообщение");

           /* }
           catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }*/
        }

        private void btnDeleteContent_Click(object sender, EventArgs e)
        {
            try
            {
                // con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Content where ID_Book=" + Convert.ToInt16(dgvContent.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowContent();
                MessageBox.Show("Данные о расположение книги удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }
    }
    }



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
    public partial class whatbooks : Form
    {
        //string s;
        //строка соединения, вязто из обозреватель решений App.config
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);

        public whatbooks()
        {
            InitializeComponent();
            //s = frm.Text;
        }
        //класс для работы с данными
        public class FIO
        {
            public int ID_Book { get; private set; }
            public string NameBook { get; set; }


            private FIO()
            {
                NameBook = string.Empty;
            }

            public FIO(SqlDataReader DR)
                : this()
            {
                ID_Book = (int)DR.GetInt32(DR.GetOrdinal("ID_Book"));

                if (DR.GetValue(DR.GetOrdinal("NameBook")) != null)
                    NameBook = DR.GetString(DR.GetOrdinal("NameBook"));
            }

            public override string ToString()
            { return string.Format("{0}", NameBook); }

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

            // функция вывода в listbox
            public static void FillListBox(ListBox lmb, string strConn)
            {
                lmb.Items.Clear();
                foreach (FIO fio in FIOList(strConn)) lmb.Items.Add(fio);
            }


            //запрос
            public static string qLoad { get { return "SELECT ID_Book, NameBook FROM Books"; } }
        }
        //вызов события
        private void ShowBooks()
        {
            FIO.FillListBox(lbReader, "строкасоединениясбазойданных");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Обработчик события SelectedIndexChanged
            // if (lbReader.SelectedItem == null) return;
            // FIO fio = lbReader.SelectedItem as FIO;
            //string numbEmployee = s.lbReader.SelectedItem.ToString();
            // string k = lbReader.SelectedItem.ToString();
            // MessageBox.Show(k);
            // lbl1.Text = lbEmployee.SelectedIndex.ToString();
            //return;
            // can do anything...
            int k = lbReader.SelectedIndex + 1;
            Exemplar.book = k;
            AddExemplar.book = k;
            //date = k;
            //  return;
            Close();
        }

        /*
        //строка соединения, вязто из обозреватель решений App.config
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);
        public whatbooks()
        {
            InitializeComponent();
        }    
 
        //класс для работы с данными
        public class FIO
        {
            public int ID_Book { get; private set; }
            public string NameBook { get; set; }
            //public int GenreID { get; set; }

            private FIO()
            {
                NameBook = string.Empty;
            }

            public FIO(SqlDataReader DR)
                : this()
            {
                ID_Book = DR.GetInt32(DR.GetOrdinal("ID_Book"));

               // if (DR.GetValue(DR.GetOrdinal("_ID_Publisher")) != null)
                   // _ID_Publisher = DR.GetInt32(DR.GetOrdinal("_ID_Publisher"));

                if (DR.GetValue(DR.GetOrdinal("NameBook")) != null)
                    NameBook = DR.GetString(DR.GetOrdinal("NameBook"));

              //  if (DR.GetValue(DR.GetOrdinal("GenreID")) != null)
                   // GenreID = DR.GetInt32(DR.GetOrdinal("GenreID"));
            }

            public override string ToString()
            { return string.Format("{1} ", NameBook); }

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

            // функция вывода в listbox
            public static void FillListBox(ListBox lmb, string strConn)
            {
                lmb.Items.Clear();
                foreach (FIO fio in FIOList(strConn)) lmb.Items.Add(fio);
            }


            //запрос
           //public static string qLoad { get { return "SELECT ID_Book, Publisher._Publisher, NameBook, book_genre.Genre FROM dbo.Books INNER JOIN Publisher ON Books._ID_Publisher = Publisher.ID_Publisher INNER JOIN book_genre ON Books.GenreID = book_genre.GenreID"; } }
            public static string qLoad { get { return "SELECT  ID_Book, NameBook FROM Books"; } }
        }
        //вызов события
        private void ShowReader()
        {
            //  try
            // {
            FIO.FillListBox(lbReader, "строкасоединениясбазойданных");
            /*DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Readers AS КОД_ЧИТАТЕЛЯ, Surname AS ФАМИЛИЯ, Name AS ИМЯ, Patronymic AS ОТЧЕСТВО, AdressReader AS ПОЛ, Telefone AS ТЕЛЕФОН FROM Reader", con);
            da.Fill(dt);
            lbReader.DataSource = dt.DefaultView;
            lbReader.ValueMember = "ФАМИЛИЯ";

        }
        catch (Exception)
        {
            MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
        }*/
            /*  SqlCommand cmd2 = con.CreateCommand();
              cmd2.CommandText = "SELECT ID_Readers AS ID, Surname AS Фамилия, Name AS Имя, Patronymic Отчество FROM Reader";
              DataTable dt = new DataTable();
              SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
              con.Open();
              try
              {
                  adapter.Fill(dt);
                  lbReader.DataSource = dt;
                  lbReader.DisplayMember = "Фамилия";
                  lbReader.DisplayMember = "Фамилия";
              }
              finally
              {
                  con.Close();
              }*/
        

        private void whatbooks_Load(object sender, EventArgs e)
        {
            ShowBooks();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }


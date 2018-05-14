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
    public partial class MenuForEmployeeNew : Form
    {
        library5DataSet.ReaderRow dataRow;
        //строка соединения, вязто из обозреватель решений App.config
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);
        public static int reader = 0;

        public MenuForEmployeeNew()
        {
            InitializeComponent();
        }

        private void MenuForEmployeeNew_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Position". При необходимости она может быть перемещена или удалена.
          //  this.positionTableAdapter.Fill(this.library5DataSet.Position);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Publisher". При необходимости она может быть перемещена или удалена.
            this.publisherTableAdapter.Fill(this.library5DataSet.Publisher);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Delivery". При необходимости она может быть перемещена или удалена.
            this.deliveryTableAdapter.Fill(this.library5DataSet.Delivery);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.library5DataSet.Employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Reader". При необходимости она может быть перемещена или удалена.
            this.readerTableAdapter.Fill(this.library5DataSet.Reader);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "library5DataSet.Position". При необходимости она может быть перемещена или удалена.
            //this.positionTableAdapter.Fill(this.library5DataSet.Position);
          //  ShowEmployee();
        }

        private void Position()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT PositionName FROM Position", con);
            da.Fill(dt);
            cbEmployeePosition.DataSource = dt;
            cbEmployeePosition.DisplayMember = "PositionName";
            cbEmployeePosition.SelectedIndex = 0;
        }

        //функция вывода информации в DataGridView по читателям 
        private void ShowReader()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Readers AS КОД_ЧИТАТЕЛЯ, Surname AS ФАМИЛИЯ, Name AS ИМЯ, Patronymic AS ОТЧЕСТВО, AdressReader AS ПОЛ, Telefone AS ТЕЛЕФОН FROM Reader", con);
                da.Fill(dt);
              //  dgvListReader.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по сотрудникам
        private void ShowEmployeeList()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Employee AS КОД_CОТРУДНИКА, Position.PositionName AS ДОЛЖНОСТЬ, Surname AS ФАМИЛИЯ, Name AS ИМЯ, Patronymic AS ОТЧЕСТВО, DateBirthday AS ДАТА_РОЖДЕНИЯ FROM Employee INNER JOIN Position ON Employee.ID_Position=Position.ID_Position", con);
                da.Fill(dt);
                dgvEmployee.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        // функция очистки информации
        private void ClearReader()
        {
            txtReaderID.Text = "";
            txtSurname.Text = "";
            txtName.Text = "";
            txtPatronymic.Text = "";
            mxtTelefone.Text = "";
        }

        //функция вывода информации в DataGridView по Выдаче книг
        private void ShowDelivery()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Delivery AS КОД_ВЫДАЧИ, ID_exemplar AS КОД_ЭКЗЕМПЛЯРА, Reader.Surname AS ФАМИЛИЯ_ЧИТАТЕЛЯ, Reader.Name AS ИМЯ_ЧИТАТЕЛЯ, Reader.Patronymic AS ОТЧЕСТВО_ЧИТАТЕЛЯ, Employee.Surname AS ФАМИЛИЯ_СОТРУДНИКА, Employee.Name AS ИМЯ_СОТРУДНИКА, Employee.Patronymic AS ОТЧЕСТВО_СОТРУДНИКА,DateDelivery AS ДАТА_ВЫДАЧИ, TimeDelivery AS ВРЕМЯ_ВЫДАЧИ FROM dbo.Delivery INNER JOIN dbo.Reader ON Delivery.ID_Readers = Reader.ID_Readers INNER JOIN dbo.Employee ON Delivery.ID_Employee = Employee.ID_Employee", con);
                da.Fill(dt);
                dgvDelivery.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //функция вывода информации в DataGridView по возврату
        private void ShowReturn()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Return AS КОД_ВОЗВРАТА, ID_exemplar AS КОД_ЭКЗЕМПЛЯРА, Reader.Surname AS ФАМИЛИЯ_ЧИТАТЕЛЯ, Reader.Name AS ИМЯ_ЧИТАТЕЛЯ, Reader.Patronymic AS ОТЧЕСТВО_ЧИТАТЕЛЯ, Employee.Surname AS ФАМИЛИЯ_СОТРУДНИКА, Employee.Name AS ИМЯ_СОТРУДНИКА, Employee.Patronymic AS ОТЧЕСТВО_СОТРУДНИКА,DataReturn AS ДАТА_ВОЗВРАТА, TimeReturn AS ВРЕМЯ_ВОЗВРАТА FROM dbo.return_book INNER JOIN dbo.Reader ON return_book.ID_Reader = Reader.ID_Readers INNER JOIN dbo.Employee ON return_book.ID_Employee = Employee.ID_Employee", con);
                da.Fill(dt);
                dgvDelivery.DataSource = dt.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("При отображении информации произошла ошибка! Проверьте подключение к БД", "Сообщение об ошибке");
            }
        }

        //класс для работы с данными
        public class FIO
        {
            public int ID_Employee { get; private set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }

            private FIO()
            {
                Surname = Name = Patronymic = string.Empty;
            }

            public FIO(SqlDataReader DR)
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
            public static string qLoad { get { return "SELECT ID_Employee, Surname, Name, Patronymic FROM dbo.Employee"; } }
        }

        private void ShowEmployee()
        {
            FIO.FillListBox(cbDeliveryEmployee, "строкасоединениясбазойданных");
        }

        private void mnuReaturnBook_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            ShowEmployee();
            lblReader.Visible = false;
            this.Height = 222;
            this.Width = 495;
            ShowReturn();
            btnReturnBooks.Visible = true;
            label3.Text = "Принял(а)";

            label4.Visible = false;
            txtGoogle.Visible = false;
            btnListReturnBook.Visible = true;
            btnAdd.Visible = false;
            btnReaders.Visible = false;
            panelDelivery.Visible = true;
            panelReader.Visible = false;
            panelReadAdd.Visible = false;
        }

        private void mnuDeliveryBook_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            ShowEmployee();
            lblReader.Visible = false;
            this.Height = 222;
            this.Width = 495;
            panelDelivery.Visible = true;
            panelReadAdd.Visible = false;
            panelReader.Visible = false;
            label4.Visible = false;
            txtGoogle.Visible = false;
            btnAdd.Visible = true;
            btnReaders.Visible = true;
            btnReturnBooks.Visible = false;
            btnListReturnBook.Visible = false;
            btnReturn2.Visible = false;
            ShowDelivery();
        }



        private void btnListReader_Click(object sender, EventArgs e)
        {
            panelReader.Visible = true;
            panelReader.Location = new Point(12, 188);
            this.Height = 412;
            dgvReader.Visible = true;
            dgvReader.Columns[0].Visible = false;
            dgvReader.Columns[4].Visible = false;
            dgvReader.Columns[5].Visible = false;


        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            dgvDelivery.Visible = true;
            label4.Visible = true;
            txtGoogle.Visible = true;
            btnReaders.Visible = false;
            btnReturn.Visible = true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int l, z;
            l = reader;
            z = cbDeliveryEmployee.SelectedIndex + 1; ;
            int DeliveryID = 12;
            if (DeliveryID <= dgvDelivery.Rows.Count)
                DeliveryID = dgvDelivery.Rows.Count + 1;

            string Exemplar = Convert.ToString(this.txtExemplar.Text);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Delivery", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = DeliveryID++;
            r[1] = Exemplar;
            r[2] = l;
            r[3] = z;
            r[4] = DateTime.Now.ToString("yyyy-MM-dd");
            r[5] = DateTime.Now.ToString("HH:mm:ss");

            if (txtExemplar.Text == "")
            {
                MessageBox.Show("Введите номер экземпляра!", "Сообщение");
                return;
            }

            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowDelivery();

            MessageBox.Show("Книга выдана!", "Сообщение");
        }

        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            int l, z;
            l = reader;
            z = cbDeliveryEmployee.SelectedIndex + 1;
            int ReturnID = 12;
            if (ReturnID <= dgvDelivery.Rows.Count)
                ReturnID = dgvDelivery.Rows.Count + 1;

            string Exemplar = Convert.ToString(this.txtExemplar.Text);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from return_book", con);
            da.Fill(dt);
            DataRow r = dt.NewRow();
            DateTime now = DateTime.Now;
            r[0] = ReturnID++;
            r[1] = Exemplar;
            r[2] = l;
            r[3] = z;
            r[4] = DateTime.Now.ToString("yyyy-MM-dd");
            r[5] = DateTime.Now.ToString("HH:mm:ss");

            if (txtExemplar.Text == "")
            {
                MessageBox.Show("Введите номер экземпляра!", "Сообщение");
                return;
            }

            dt.Rows.Add(r);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            con.Close();
            ShowDelivery();

            MessageBox.Show("Книга возвращена!", "Сообщение");
        }



        private void cbDeliveryReader_TextUpdate(object sender, EventArgs e)
        {
            int index = cbDeliveryEmployee.FindString(Text);
            cbDeliveryEmployee.SelectedIndex = index;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dgvDelivery.Visible = false;
            label4.Visible = false;
            txtGoogle.Visible = false;
            btnReturn.Visible = false;
            btnReaders.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Start frm = new Start();
            this.Hide();
            frm.ShowDialog();

        }

        private void btnListReturnBook_Click(object sender, EventArgs e)
        {
            dgvDelivery.Visible = true;
            label4.Visible = true;
            txtGoogle.Visible = true;
            btnListReturnBook.Visible = false;
            btnReturn.Visible = true;
        }

        private void btnReturn2_Click(object sender, EventArgs e)
        {
            dgvDelivery.Visible = false;
            label4.Visible = false;
            txtGoogle.Visible = false;
            btnReturn.Visible = false;
            btnListReturnBook.Visible = true;
        }

        private void cbDeliveryEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtGoogle_TextChanged(object sender, EventArgs e)
        {
            dgvDelivery.CurrentCell = null;
            {
                for (int i = 0; i < dgvDelivery.RowCount - 1; i++)
                {
                    dgvDelivery.Rows[i].Visible = false;
                    for (int j = 0; j < dgvDelivery.ColumnCount; j++)
                        if (dgvDelivery.Rows[i].Cells[j].Value != null)
                            if (dgvDelivery.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogle.Text.ToLower()))
                            {
                                dgvDelivery.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void dgvReader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblReader.Visible = true;
            int number = dgvReader.CurrentCellAddress.Y;
            var table = library5DataSet.Reader;
            if (number < 0 || number > table.Rows.Count)
            {
                return;
            }
            var row = table.Rows[number] as library5DataSet.ReaderRow;
            dataRow = row;
            var k = dgvReader.Rows[e.RowIndex].Cells[0].Value;
            int l = Convert.ToInt32(k);
            reader = l;
            panelReader.Visible = false;
            this.Height = 227;
            lblReader.Text = "(" + dataRow.Surname + " " + dataRow.Name + " " + dataRow.Patronymic + ")";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvReader.CurrentCell = null;
            {
                for (int i = 0; i < dgvReader.RowCount; i++)
                {
                    dgvReader.Rows[i].Visible = false;
                    for (int j = 0; j < dgvReader.ColumnCount; j++)
                        if (dgvReader.Rows[i].Cells[j].Value != null)
                            if (dgvReader.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                            {
                                dgvReader.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void mnuListReader_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            btnDeleteReader.Visible = false;
            this.readerTableAdapter.Fill(this.library5DataSet.Reader);
            dgvReader.Refresh();
            panelReader.Location = new Point(12, 27);
            dgvReader.Visible = true;
            panelReader.Visible = true;
            panelDelivery.Visible = false;

            panelReadAdd.Visible = false;
            panelReader.Width = 653;
            dgvReader.Width = 645;
            this.Width = 687;
            this.Height = 259;
            dgvReader.Location = new Point(8, 40);
            label5.Location = new Point(21, 13);
            textBox1.Location = new Point(120, 12);
            label6.Visible = false;

        }

        private void mnuAddReader_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            btnDeleteReader.Visible = false;
            btnAddReader.Visible = true;
           // dgvListReader.Visible = false;
            dgvReaderss.Visible = false;
            dgvReader.Visible = false;
            this.Height = 190;
            this.Width = 495;
            ShowReader();
            textBox2.Visible = false;
            button1.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            btnEdit.Visible = false;
            label11.Location = new Point(11, 12);
            label10.Location = new Point(11, 36);
            label9.Location = new Point(11, 62);
            label8.Location = new Point(240, 24);
            label7.Location = new Point(240, 50);
            txtSurname.Location = new Point(78, 12);
            txtName.Location = new Point(78, 38);
            txtPatronymic.Location = new Point(78, 64);
            mxtTelefone.Location = new Point(298, 50);
            rdbGenderF.Location = new Point(298, 22);
            rdbGenderM.Location = new Point(376, 22);
            panelReader.Visible = false;
            label14.Visible = false;
            txtReaderID.Visible = false;
            panelDelivery.Visible = false;
            panelReadAdd.Visible = true;
            panelReadAdd.Location = new Point(12, 27);
        }

        private void btnAddReader_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "муж";
                if (rdbGenderF.Checked == true)
                {
                    gender = "жен";
                }
                else if (rdbGenderM.Checked == true)
                {
                    gender = "муж";
                }
                int ReaderID = 0;
                if (ReaderID <= dgvReader.Rows.Count)
                    ReaderID = dgvReader.Rows.Count + 1;

                string Surname = Convert.ToString(this.txtSurname.Text);
                string Name = Convert.ToString(this.txtName.Text);
                string Patronymic = Convert.ToString(this.txtPatronymic.Text);
                string Telefone = Convert.ToString(this.mxtTelefone.Text);

                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Reader", con);
                da.Fill(dt);
                DataRow r = dt.NewRow();
                r[0] = ReaderID++;
                r[1] = Surname;
                r[2] = Name;
                r[3] = Patronymic;
                r[4] = gender;
                r[5] = Telefone;


                if (txtName.Text == "")
                {
                    MessageBox.Show("Введите имя!", "Сообщение");
                    return;
                }
                else if (txtSurname.Text == "")
                {
                    MessageBox.Show("Введите фамилию!", "Сообщение");
                    return;
                }

                else if (txtPatronymic.Text == "")
                {
                    MessageBox.Show("Введите отчество!", "Сообщение");
                    return;
                }

                else if (mxtTelefone.Text == "")
                {
                    MessageBox.Show("Введите телефон!", "Сообщение");
                    return;
                }

                dt.Rows.Add(r);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowReader();

                MessageBox.Show("Данные о читателе добавлены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При добавлении данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void списокКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuEditReader_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            btnDeleteReader.Visible = false;
            ShowReader();
            panelReader.Visible = false;
            label14.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            txtReaderID.Visible = true;
            label14.Location = new Point(9, 78);
            label11.Location = new Point(9, 105);
            label10.Location = new Point(9, 132);
            label9.Location = new Point(9, 159);
            label8.Location = new Point(236, 70);
            label7.Location = new Point(236, 96);
            txtReaderID.Location = new Point(78,68);
            txtSurname.Location = new Point(78, 98);
            txtName.Location = new Point(78, 126);
            txtPatronymic.Location = new Point(78, 152);
            mxtTelefone.Location = new Point(294, 96);
            rdbGenderF.Location = new Point(294, 68);
            rdbGenderM.Location = new Point(372, 68);
            btnAddReader.Visible = false;
            label14.Visible = true;
            panelReadAdd.Visible = true;
            panelReadAdd.Location = new Point(6, 27);
            this.Height = 123;
            this.Width = 499;
        }
        //поиск по читателям
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDeleteReader.Visible = false;
            this.readerTableAdapter.Fill(this.library5DataSet.Reader);
            dgvReaderss.Visible = true;
            this.Height = 273;
            this.Width = 499;
            dgvReaderss.CurrentCell = null;
            {
                for (int i = 0; i < dgvReaderss.RowCount; i++)
                {
                    dgvReaderss.Rows[i].Visible = false;
                    for (int j = 0; j < dgvReaderss.ColumnCount; j++)
                        if (dgvReaderss.Rows[i].Cells[j].Value != null)
                            if (dgvReaderss.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox2.Text.ToLower()))
                            {
                                dgvReaderss.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string gender = "муж";
                if (rdbGenderF.Checked == true)
                {
                    gender = "жен";
                }
                else if (rdbGenderM.Checked == true)
                {
                    gender = "муж";
                }
                DataTable dt = new DataTable();
               // int number = dgvListReader.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Reader where ID_Readers=" + Convert.ToInt16(dgvReaderss.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = txtSurname.Text;
                dt.Rows[0][2] = txtName.Text;
                dt.Rows[0][3] = txtPatronymic.Text;
                dt.Rows[0][4] = gender;
                dt.Rows[0][5] = mxtTelefone.Text;
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowReader();
                ClearReader();
                MessageBox.Show("Данные о читателе изменены!", "Сообщение");
                dgvReaderss.Refresh();

            }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            label14.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            textBox2.Visible = true;
            button1.Visible = true;
            txtReaderID.Visible = true;
            txtReaderID.Location = new Point(78, 68);
            label14.Location = new Point(9, 78);
            label11.Location = new Point(9, 105);
            label10.Location = new Point(9, 132);
            label9.Location = new Point(9, 159);
            label8.Location = new Point(236, 70);
            label7.Location = new Point(236, 96);
            txtSurname.Location = new Point(78, 98);
            txtName.Location = new Point(78, 126);
            txtPatronymic.Location = new Point(78, 152);
            mxtTelefone.Location = new Point(294, 96);
            rdbGenderF.Location = new Point(294, 68);
            rdbGenderM.Location = new Point(372, 68);
            btnEdit.Visible = true;
            btnAddReader.Visible = false;
            this.Height = 280;
            var table = library5DataSet.Reader;
            int number = dgvReaderss.CurrentCellAddress.Y;
            if (number < 0 || number > table.Rows.Count)
            {
                return;
            }
            var row = table.Rows[number] as library5DataSet.ReaderRow;
            dataRow = row;

            txtReaderID.Text = Convert.ToString(dataRow.ID_Readers);
            txtSurname.Text = dataRow.Surname;
            txtName.Text = dataRow.Name;
            txtPatronymic.Text = dataRow.Patronymic;
            mxtTelefone.Text = dataRow.Telefone;
            if (dataRow.AdressReader == "жен")
                rdbGenderF.Checked = true;
            else
                rdbGenderM.Checked = true;
            dgvReaderss.Visible = false;
            btnChange.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDeleteReader.Visible = false;
            this.readerTableAdapter.Fill(this.library5DataSet.Reader);
            btnChange.Visible = true;
            dgvReaderss.Visible = true;
            this.Height = 273;
            this.Width = 499;

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readerTableAdapter.Update(library5DataSet);
        }

        private void btnDeleteReader_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Reader where ID_Readers=" + Convert.ToInt16(dgvReaderss.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowReader();
                ClearReader();
                this.readerTableAdapter.Fill(this.library5DataSet.Reader);
                MessageBox.Show("Данные о читателе удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void mnuDeleteReader_Click(object sender, EventArgs e)
        {
            panelEmployee.Visible = false;
            this.Height = 276;
            this.Width = 495;
            panelReadAdd.Visible = true;
            panelReadAdd.Location = new Point(12, 27);
            label13.Visible = true;
            label12.Visible = true;
            textBox2.Visible = true;
            button1.Visible = false;
            dgvReaderss.Visible = true;
            btnDeleteReader.Visible = true;
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuWorkWithBooks_Click(object sender, EventArgs e)
        {
            AddBooks frm = new AddBooks();
            this.Hide();
            frm.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void mnuListEmployee_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            ShowEmployeeList();
            panelEmployee.Location = new Point(12, 27);
            txtID_Employee.Visible = false;
            txtSurnameEmployee.Visible = false;
            txtNameEmployee.Visible = false;
            txtPatronumicEmployee.Visible = false;
            txtID_Employee.Visible = false;
            label20.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
            label22.Visible = false;
            cbEmployeePosition.Visible = false;
            dateBirthdayEmployee.Visible = false;
            btnAddEmployee.Visible = false;
            btnChangeEmployee.Visible = false;
            dgvEmployee.Visible = false;
            this.Height = 123;
            txtGoogleEmployee.Visible = true;
            label21.Visible = true;
            label15.Visible = true;
            btnGoogleEmployee.Visible = true;
            panelEmployee.Visible = true;
            panelDelivery.Visible = false;
            panelReader.Visible = false;
            panelReadAdd.Visible = false;
            dgvEmployee.Visible = true;
        }

        private void txtGoogleEmployee_TextChanged(object sender, EventArgs e)
        {
            btnEditEmployee.Visible = false;
            btnDeleteEmployee.Visible = false;
            dgvEmployee.Visible = true;
            this.Height = 245;
            this.Width = 499;
            btnChangeEmployee.Visible = true;
            btnDeleteEmployee.Visible = false;
            dgvEmployee.CurrentCell = null;
            {
                for (int i = 0; i < dgvEmployee.RowCount; i++)
                {
                    dgvEmployee.Rows[i].Visible = false;
                    for (int j = 0; j < dgvEmployee.ColumnCount; j++)
                        if (dgvEmployee.Rows[i].Cells[j].Value != null)
                            if (dgvEmployee.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtGoogleEmployee.Text.ToLower()))
                            {
                                dgvEmployee.Rows[i].Visible = true;
                                break;
                            }
                }
            }
        }

        private void btnGoogleEmployee_Click(object sender, EventArgs e)
        {
            btnChangeEmployee.Visible = false;
            btnEditEmployee.Visible = false;
            ShowEmployeeList();
            btnDeleteEmployee.Visible = false;
            dgvEmployee.Visible = true;
            this.Height = 245;
            this.Width = 499;
            btnChangeEmployee.Visible = true;
            btnDeleteEmployee.Visible = false;
        }

        private void mnuEditEmployee_Click(object sender, EventArgs e)
        {
            Position();
            ShowEmployeeList();
            panelEmployee.Visible = true;
            panelEmployee.Location = new Point(6, 27);
            this.Height = 123;
            txtGoogleEmployee.Visible = true;
            label21.Visible = true;
            label15.Visible = true;
            btnGoogleEmployee.Visible = true;
            txtID_Employee.Visible = false;
            txtSurnameEmployee.Visible = false;
            txtNameEmployee.Visible = false;
            txtPatronumicEmployee.Visible = false;
            txtID_Employee.Visible = false;
            label20.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
            label22.Visible = false;
            cbEmployeePosition.Visible = false;
            dateBirthdayEmployee.Visible = false;
            btnAddEmployee.Visible = false;
        }

        private void mnuDeleteEmployee_Click(object sender, EventArgs e)
        {
            txtID_Employee.Visible = false;
            txtSurnameEmployee.Visible = false;
            txtNameEmployee.Visible = false;
            txtPatronumicEmployee.Visible = false;
            txtID_Employee.Visible = false;
            label20.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
            label22.Visible = false;
            cbEmployeePosition.Visible = false;
            dateBirthdayEmployee.Visible = false;
            btnAddEmployee.Visible = false;
            btnChangeEmployee.Visible = false;
            dgvEmployee.Visible = true;
            txtGoogleEmployee.Visible = true;
            label21.Visible = true;
            label15.Visible = true;
            btnGoogleEmployee.Visible = true;
            panelEmployee.Visible = true;
            panelDelivery.Visible = false;
            panelReader.Visible = false;
            panelReadAdd.Visible = false;
            btnDeleteEmployee.Visible = true;
            btnEditEmployee.Visible = false;
            dgvEmployee.Visible = true;
            panelEmployee.Location = new Point(6, 27);
            this.Height = 277;
            btnChangeEmployee.Visible = false;
            ShowEmployeeList();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {

                int ID_Employee = 15;
                if (ID_Employee <= dgvEmployee.Rows.Count)
                    ID_Employee = dgvEmployee.Rows.Count + 1;
                int k = cbEmployeePosition.SelectedIndex + 1;
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Employee", con);
                da.Fill(dt);
                DataRow r = dt.NewRow();
                DateTime now = DateTime.Now;
                r[0] = ID_Employee;
                r[1] = k;
                r[2] = txtNameEmployee.Text;
                r[3] = txtSurnameEmployee.Text;
                r[4] = txtPatronumicEmployee.Text;
                r[5] = dateBirthdayEmployee.Value.ToString("yyyy-MM-dd");
                dt.Rows.Add(r);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowEmployeeList();

                MessageBox.Show("Данные о сотруднике добавлены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При добавлении данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }
        }

        private void mnuAddEmployee_Click(object sender, EventArgs e)
        {
            panelEmployee.Location = new Point(6, 27);
            ShowEmployeeList();
            Position();
            txtSurnameEmployee.Visible = true;
            txtNameEmployee.Visible = true;
            txtPatronumicEmployee.Visible = true;
            txtID_Employee.Visible = true;
            label20.Visible = true;
            label19.Visible = true;
            label18.Visible = true;
            label17.Visible = true;
            label16.Visible = true;
            label22.Visible = true;
            cbEmployeePosition.Visible = true;
            dateBirthdayEmployee.Visible = true;
            btnAddEmployee.Visible = true;
            btnChangeEmployee.Visible = false;
            panelEmployee.Visible = true;
            label15.Visible = false;
            label21.Visible = false;
            txtGoogleEmployee.Visible = false;
            btnGoogleEmployee.Visible = false;
            dgvEmployee.Visible = false;
            btnEditEmployee.Visible = false;
            txtID_Employee.Visible = false;
            label22.Visible = false;
            label20.Location = new Point(13,21);
            label19.Location = new Point(13,48);
            label18.Location = new Point(13,75);
            label17.Location = new Point(248,18);
            label16.Location = new Point(248,45);
            txtSurnameEmployee.Location = new Point(82,14);
            txtNameEmployee.Location = new Point(82,42);
            txtPatronumicEmployee.Location = new Point(82,68);
            cbEmployeePosition.Location = new Point(340,9);
            dateBirthdayEmployee.Location = new Point(340, 39);
            this.Height = 194;

        }

        private void btnChangeEmployee_Click(object sender, EventArgs e)
        {
            txtSurnameEmployee.Visible = true;
            txtNameEmployee.Visible = true;
            txtPatronumicEmployee.Visible = true;
            txtID_Employee.Visible = true;
            label20.Visible = true;
            label19.Visible = true;
            label18.Visible = true;
            label17.Visible = true;
            label16.Visible = true;
            label22.Visible = true;
            cbEmployeePosition.Visible = true;
            dateBirthdayEmployee.Visible = true;
            btnChangeEmployee.Visible = false;
            this.Height = 244;
            dgvEmployee.Visible = false;
            txtID_Employee.Visible = true;
            int number = dgvEmployee.CurrentRow.Index;
            txtID_Employee.Text = dgvEmployee[0, number].Value.ToString();
            txtSurnameEmployee.Text = dgvEmployee[2, number].Value.ToString();
            txtNameEmployee.Text = (String)dgvEmployee[3, number].Value;
            txtPatronumicEmployee.Text = dgvEmployee[4, number].Value.ToString();
            cbEmployeePosition.Text = dgvEmployee[1, number].Value.ToString();
            dateBirthdayEmployee.Text = dgvEmployee[5, number].Value.ToString();
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
           /* try
            {*/
                con.Open();
                int k = cbEmployeePosition.SelectedIndex + 1;
            
                DataTable dt = new DataTable();
                int number = dgvEmployee.CurrentCellAddress.Y;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Employee where ID_Employee=" + Convert.ToInt16(dgvEmployee.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                dt.Rows[0].BeginEdit();
                dt.Rows[0][1] = k;
                dt.Rows[0][2] = txtSurnameEmployee.Text;
                dt.Rows[0][3] = txtNameEmployee.Text;
                dt.Rows[0][4] = txtPatronumicEmployee.Text;
                dt.Rows[0][5] = dateBirthdayEmployee.Value.ToString("yyyy-MM-dd");
                dt.Rows[0].EndEdit();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowEmployeeList();
                MessageBox.Show("Данные о сотруднике изменены!", "Сообщение");

         /*   }
            catch (Exception)
            {
                MessageBox.Show("При редактировании данных произошла ошибка. Перезапустите программу и повторите попытку!", "Сообщение об ошибке");
            }*/
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Delete from Employee where ID_Employee=" + Convert.ToInt16(dgvEmployee.CurrentRow.Cells[0].Value.ToString()) + "  ", con);
                da.Fill(dt);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                con.Close();
                ShowEmployeeList();
                MessageBox.Show("Данные о сотруднике удалены!", "Сообщение");
            }
            catch (Exception)
            {
                MessageBox.Show("При удалении данных произошла ошибка. Запись об удаляемом объекте содержится в других таблицах!", "Сообщение об ошибке");
            }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Height = 275;
            btnEditEmployee.Visible = true;
        }
    }
}



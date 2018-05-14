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
    public partial class HandReaderscs : Form
    {
        SqlConnection con = new SqlConnection(library.Properties.Settings.Default.library5ConnectionString);
        public HandReaderscs()
        {
            InitializeComponent();
        }
        //функция вывода информации в DataGridView
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HandReaderscs_Load(object sender, EventArgs e)
        {
            ShowDelivery();
        }
    }
}

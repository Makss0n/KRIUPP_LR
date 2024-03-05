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

namespace KRiUPP_LR1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection=new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\maksp\source\repos\KRiUPP_LR1\Database1.mdf; Integrated Security = True");
            sqlConnection.Open();
            // CreateColumns();
            //RefreshDaraGrid(dataGridView1);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand comm = new SqlCommand(string.Format($"Select ФИО, Должность, Оклад from Employes "));
            comm.Connection = sqlConnection;

            adapter.SelectCommand = comm;
            adapter.Fill(table);
            int sum = 0;
            SqlDataReader reader = comm.ExecuteReader();
            string s = "";
            //if (status == "На рассмотрении")
            //{
            while (reader.Read()) // построчно считываем данные
            {
                
                string marka = Convert.ToString(reader.GetValue(0));
                string model = Convert.ToString(reader.GetValue(1));
                string Date = Convert.ToString(reader.GetValue(2));
                sum += Convert.ToInt32(reader.GetValue(2));
                s = String.Concat(s, $"{marka} {model} {Date}\n");
            }
            textBox1.Text = s+"Суммарная выплата"+sum;
            //}
            reader.Close();
            sqlConnection.Close();
        }
    }
}

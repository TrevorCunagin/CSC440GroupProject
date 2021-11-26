using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC440GroupProject
{
    public partial class PrintReport : Form
    {
        public PrintReport()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            populateDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void populateDataGrid()
        {
            dataGridView1.Rows.Clear();
            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String ID;
            String classID;
            String grade;
           

           

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn3.Open();
                string sql = "SELECT ID, ClassID, Grade FROM dtk_grades";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);




                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    ID = myReader["ID"].ToString();
                    classID = myReader["ClassID"].ToString();
                    grade = myReader["Grade"].ToString();

                   

                    var row = dataGridView1.Rows.Add(ID, classID, grade); //adds to datagridview




                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn3.Close();
            Console.WriteLine("Done.");
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }
    }
}

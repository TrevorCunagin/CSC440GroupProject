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
            getStudentData();
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
            String inputID;
            inputID = textBox1.Text;
          

           

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn3.Open();
                string sql = "SELECT ID, ClassID, Grade FROM dtk_grades WHERE ID = @id";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);
                cmd.Parameters.AddWithValue("@id", inputID);



                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    ID = myReader["ID"].ToString();
                    classID = myReader["ClassID"].ToString();
                    grade = myReader["Grade"].ToString();
                    findClass(classID, grade);
                   

                    




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

        public void getStudentData()
        {

            dataGridView2.Rows.Clear();
            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn5 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String fName;
            String lName;
            String GPA;
            String inputID;
            inputID = textBox1.Text;




            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn5.Open();
                string sql = "SELECT firstName, lastName, GPA FROM dtk_student WHERE ID = @id";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn5);
                cmd.Parameters.AddWithValue("@id", inputID);



                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    fName = myReader["firstName"].ToString();
                    lName = myReader["lastName"].ToString();
                    GPA = myReader["GPA"].ToString();


                    var row = dataGridView2.Rows.Add(fName, lName, GPA); //adds to datagridview2





                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn5.Close();
            Console.WriteLine("Done.");
        }


        public void findClass(String classID, String grade)
        {
            
            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn4 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String Teacher;
            String Name;
            String Prefix;
            String Number;




            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn4.Open();
                string sql = "SELECT Teacher, Name, Prefix, Number FROM dtk_classes WHERE ClassID = @classID";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn4);
                cmd.Parameters.AddWithValue("@classID", classID);



                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    Teacher = myReader["Teacher"].ToString();
                    Name = myReader["Name"].ToString();
                    Prefix = myReader["Prefix"].ToString();
                    Number = myReader["Number"].ToString();


                    var row = dataGridView1.Rows.Add(Teacher, Prefix, Number, Name, grade); //adds to datagridview




                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn4.Close();
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

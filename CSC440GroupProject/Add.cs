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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddGrade();
            calcGPA();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void AddGrade()
        {
            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn4 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String id = textBox1.Text;
            String classID = textBox2.Text;
            String Grade = textBox3.Text;
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn4.Open();
                string sql = "INSERT INTO dtk_grades (ID, ClassID, Grade) VALUES (@ID,@ClassID,@Grade)";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn4);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@classID", classID);
                cmd.Parameters.AddWithValue("@Grade", Grade);

                int numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected > 0)
                {
                    label2.Text = "Grade Added Successfully";
                }
                else
                {
                    label2.Text = "Error";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn4.Close();

            Console.WriteLine("Done.");
        }

        public void calcGPA()

        {
           
            

            List<double> gradeValues = new List<double>();
            




            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn5 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String id = textBox1.Text;
            
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn5.Open();
                string sql = "SELECT Grade FROM dtk_grades WHERE ID = @ID";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn5);
                cmd.Parameters.AddWithValue("@ID", id);


                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    String tempGrade = myReader["Grade"].ToString();
                  
                    if (tempGrade == "A")
                        gradeValues.Add(4.0);
                    else if (tempGrade == "B")
                        gradeValues.Add(3.0);
                    else if (tempGrade == "C")
                        gradeValues.Add(2.0);
                    else if (tempGrade == "D")
                        gradeValues.Add(1.0);
                    else if (tempGrade == "F")
                        gradeValues.Add(0.0);









                }
              
                myReader.Close();
                double sum = 0.0; ;
                int count = gradeValues.Count;
                for(int j = 0; j < count; j++)
                {
                    sum = sum + gradeValues[j];
                    
                }
                double GPA = sum / count;
                



                int numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected > 0)
                {
                    label2.Text = "GPA calcualted";
                }
                else
                {
                    label2.Text = "Error";
                }

                setGPA(GPA);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn5.Close();

            Console.WriteLine("Done.");
        }

        public void setGPA(double gpa)

        {



            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn6 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String id = textBox1.Text;

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn6.Open();
                string sql = "UPDATE dtk_student SET GPA = @gpa WHERE ID=@ID";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn6);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@gpa", gpa);

               


                int numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected > 0)
                {
                    label2.Text = "GPA set";
                }
                else
                {
                    label2.Text = "Error";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn6.Close();

            Console.WriteLine("Done.");
        }

    }
}

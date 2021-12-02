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


    }
}

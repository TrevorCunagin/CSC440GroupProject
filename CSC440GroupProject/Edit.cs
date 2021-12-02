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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            editGrade();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void editGrade()
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
                string sql = "UPDATE dtk_grades SET Grade = @Grade WHERE ID=@ID AND ClassID=@ClassID";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn4);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@classID", classID);
                cmd.Parameters.AddWithValue("@Grade", Grade);

                int numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected > 0)
                {
                    label2.Text = "Grade Edited Successfully";
                }
                else
                {
                    label2.Text = "Error: Could not complete";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn4.Close();

            Console.WriteLine("Done.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Main mainForm = new Main();
            mainForm.Show();
        }
    }



}


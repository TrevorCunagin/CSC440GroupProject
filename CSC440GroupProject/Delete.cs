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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteGrade();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public void DeleteGrade()
        {

            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn4 = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            String id = textBox1.Text;
            String classID = textBox2.Text;


            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn4.Open();
                string sql = "DELETE FROM dtk_grades WHERE ID = @ID AND ClassID = @ClassID";


                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn4);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@classID", classID);

                int numRowsAffected = cmd.ExecuteNonQuery();
                if (numRowsAffected > 0)
                {
                    label4.Text = "The record was found and deleted";
                }
                else
                {
                    label4.Text = "The record was not found";
                }


                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

           



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






    }
}

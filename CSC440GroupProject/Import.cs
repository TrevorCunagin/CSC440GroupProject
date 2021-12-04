using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace CSC440GroupProject {
    public partial class Import : Form {
        public Import() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            _Application importExcelToDataGridViewAppl;
            _Workbook importExcelToDataGridViewWorkbook;
            _Worksheet importExcelToDataGridViewWorksheet;
            Range importExcelToDataGridViewRange;
            try {
                importExcelToDataGridViewAppl = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog importExcelToDataGridViewFileDialog = new OpenFileDialog();

                //Filter Excel Files
                importExcelToDataGridViewFileDialog.Filter = "Excel Files | *.xls;*.xlsx;*.xlsm";

                importExcelToDataGridViewFileDialog.Title = "Import Excel File";
                if (importExcelToDataGridViewFileDialog.ShowDialog() == DialogResult.OK) {
                    importExcelToDataGridViewWorkbook = importExcelToDataGridViewAppl.Workbooks.Open(importExcelToDataGridViewFileDialog.FileName);
                    importExcelToDataGridViewWorksheet = importExcelToDataGridViewWorkbook.Sheets.get_Item(1);
                    importExcelToDataGridViewRange = importExcelToDataGridViewWorksheet.UsedRange;

                    string fileName = System.IO.Path.GetFileName(importExcelToDataGridViewFileDialog.FileName);
                    string[] fileList = fileName.Split(' ', '.');
                    

                    //Get Excel Rows
                    for (int excelRows = 2; excelRows <= importExcelToDataGridViewRange.Rows.Count; excelRows++) {
                        string studentName = importExcelToDataGridViewRange.Cells[excelRows, 1].value;
                        string[] nameList = studentName.Split(' ');
                        dataGridView1.Rows.Add(nameList[0], nameList[1], importExcelToDataGridViewRange.Cells[excelRows, 2].value, importExcelToDataGridViewRange.Cells[excelRows, 3].value, fileList[0],
                            fileList[1], fileList[2], fileList[3]);
                    }

                }
            }
            catch (Exception exError) {
                MessageBox.Show(exError.StackTrace);

            }
            finally {
                //importExcelToDataGridViewWorkbook.Close();
                //importExcelToDataGridViewAppl.Quit();

            }
        }

            private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            //import button, puts excel data into database
            string connStr = "server=157.89.28.29;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn3 = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            conn3.Open();
            for (int rows = 0; rows < dataGridView1.Rows.Count-1; rows++) {
                try {
                    string firstName = Convert.ToString(dataGridView1.Rows[rows].Cells[0].Value);
                    string lastName = Convert.ToString(dataGridView1.Rows[rows].Cells[1].Value);
                    int ID = Convert.ToInt32(dataGridView1.Rows[rows].Cells[2].Value);
                    char grade = Convert.ToChar(dataGridView1.Rows[rows].Cells[3].Value);
                    string prefix = Convert.ToString(dataGridView1.Rows[rows].Cells[4].Value);
                    string classNumber = Convert.ToString(dataGridView1.Rows[rows].Cells[5].Value);
                    string classYear = Convert.ToString(dataGridView1.Rows[rows].Cells[6].Value);
                    string classSemester = Convert.ToString(dataGridView1.Rows[rows].Cells[7].Value);

                    try {
                        Console.WriteLine("Connecting to MySQL...");
                        string sql = "INSERT INTO dtk_student (ID, firstName, lastName) VALUES (@uid, @ufname, @ulname);INSERT INTO dtk_classes (Prefix, Number, Semester, Year) values (@uprefix,@unumber,@uyear, @usemester);INSERT INTO dtk_grades (Grade) values (@ugrade);";
                        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn3);
                        cmd.Parameters.AddWithValue("@uid", ID);
                        cmd.Parameters.AddWithValue("@ufname", firstName);
                        cmd.Parameters.AddWithValue("@ulname", lastName);
                        cmd.Parameters.AddWithValue("@uprefix", prefix);
                        cmd.Parameters.AddWithValue("@unumber", classNumber);
                        cmd.Parameters.AddWithValue("@uyear", classYear);
                        cmd.Parameters.AddWithValue("@usemester", classSemester);
                        cmd.Parameters.AddWithValue("@ugrade", grade);
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                    }
                
                }
                catch (NullReferenceException) {
                    continue;
                }
            }
                

            
            conn3.Close();
            Console.WriteLine("Done.");
            System.Windows.Forms.MessageBox.Show("Import completed!");
        }

        private void button3_Click(object sender, EventArgs e) {
            this.Close();
            Main form = new Main();
            form.Show();
        }
    }
}


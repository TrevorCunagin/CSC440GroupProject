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

namespace CSC440GroupProject {
    public partial class Import : Form {
        public Import() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            _Application importExcelToDataGridViewAppl;
            _Workbook importExcelToDataGridViewWorkbook;
            _Worksheet importExcelToDataGridViewWorksheet;
            Range importExcelToDataDataGridViewRange;
            try {
                importExcelToDataGridViewAppl = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog importExcelToDataGridViewFileDialog = new OpenFileDialog();
                
                //Filter Excel Files
                importExcelToDataGridViewFileDialog.Filter = "Excel Files | *.xls;*.xlsx;*.xlsm";

                importExcelToDataGridViewFileDialog.Title = "Import Excel File";
                if (importExcelToDataGridViewFileDialog.ShowDialog() == DialogResult.OK) {

                }

            }
            catch {

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YetAnotherCOBieQCReporter
{
    public partial class Form1 : Form
    {
        
        OpenFileDialog fileBrowse = new OpenFileDialog();
        SaveFileDialog saveBrowse = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
        }
        private void inputFileBrowse_Click(object sender, EventArgs e)
        {
            fileBrowse.FileName = inputLocation.Text;
            fileBrowse.Filter = "Excel 2007+|*.xlsx|SpreadsheetML|*.xls";
            fileBrowse.CheckFileExists = true;
            if (fileBrowse.ShowDialog() == DialogResult.OK)
            {
                inputLocation.Text = fileBrowse.FileName;
            }
        }

        private void outputFileBrowse_Click(object sender, EventArgs e)
        {
            saveBrowse.FileName = outputLocation.Text;
            saveBrowse.Filter = "text|*.txt";
            saveBrowse.CheckFileExists = false;
            if (saveBrowse.ShowDialog() == DialogResult.OK)
            {
                outputLocation.Text = saveBrowse.FileName;
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            var cobie = inputLocation.Text;
            var output = outputLocation.Text;
            //var isDesign = design.Checked;

            var succeeded = Processor.ProcessFromExcel(cobie, output);
            if (succeeded)
            {
                MessageBox.Show("Processing succeeded");
            } else { 
                MessageBox.Show("Failed to process");
            }
            
        }
    }
}

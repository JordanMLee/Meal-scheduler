using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; // necessary for file io in c#


namespace Lee_Hooymans_V1
{
    public partial class ImportData : Form
    {
        public ImportData()
        {
            InitializeComponent();
        }

        private void ImportData_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inFileName = textBox1.Text;
            //string[] lines = File.ReadAllLines(inFileName);
            //foreach (string line in lines)
            //{
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Lee_Hooymans_V1
{
    public partial class ManageCadets : Form
    {
        public ManageCadets()
        {
            InitializeComponent();
        }

        private void ManageCadets_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'jah_Lab2_DBDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter1.Fill(this.jah_Lab2_DBDataSet.Table1);
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //To Allow Database Updates
            try
            {
                table1TableAdapter1.Update(jah_Lab2_DBDataSet);
                this.textBox1.Text = "Updated " +
                System.DateTime.Now.ToString();
            }
            catch (Exception f)
            {
                this.textBox1.Text = "Not Updated " +
                f.Source.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

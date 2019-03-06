using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lee_Hooymans_V1
{
    public partial class CreateAMeal : Form
    {

        

        public CreateAMeal()
        {
            InitializeComponent(); 
        }

        bool day = false;
        bool type = false;
        bool month = false;
        bool year = false;
        string theday;
        string thetype;
        string themonth;
        int theyear;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            day = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (day && type && month && year)
            {
                theday = comboBox1.SelectedItem.ToString();
                thetype = comboBox2.SelectedItem.ToString();
                themonth = comboBox3.SelectedItem.ToString();
                theyear = Int32.Parse(comboBox4.SelectedItem.ToString());
                CMeal ameal = new CMeal(theday, thetype, themonth, theyear);
                CMealMini aminimeal = new CMealMini(ameal);
                CadetEntry cadets = new CadetEntry(ameal,aminimeal);
                cadets.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Some Data!");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = true;
        }
    }
}

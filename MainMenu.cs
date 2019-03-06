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
    public partial class MainMenu : Form
    {
        public ImportData importData = new ImportData();
        public ScheduleMeals scheduleMeals = new ScheduleMeals();
        public Login login = new Login();
        public ManageCadets manage = new ManageCadets();
        public PredictMeal predictMeal = new PredictMeal();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login.ShowDialog();
        }

        private void MainMenu_Activated(object sender, EventArgs e)
        {
            bool Pass = login.admin;
            if (Pass)
            {
                foreach (Control tbY in this.Controls) //this is a cool piece of code that moves through all controls on form
                {
                    tbY.Visible = true;
                }
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
            }
            else
            {
                foreach (Control tbY in this.Controls) //this is a cool piece of code that moves through all controls on form
                {
                    tbY.Visible = false;
                }
                label2.Visible = true;
                label1.Visible = true;
                button1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (Control tbY in this.Controls) //this is a cool piece of code that moves through all controls on form
            {
                tbY.Visible = false;
            }
            label2.Visible = true;
            label1.Visible = true;
            button1.Visible = true;
            login.admin = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scheduleMeals.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manage.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            importData.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            predictMeal.ShowDialog();
        }



       
    }
}

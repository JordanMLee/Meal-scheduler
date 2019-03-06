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
    public partial class ScheduleMeals : Form
    {

        public CadetEntry cadets = new CadetEntry();
        public CreateAMeal meal = new CreateAMeal();

        public ScheduleMeals()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button3.Hide();
            button4.Hide();

            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            radioButton3.Hide();
            radioButton4.Hide();
            radioButton5.Hide();
            radioButton6.Hide();
            radioButton7.Hide();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Show();
            radioButton2.Show();
            label2.Show();
            label3.Show();
            textBox1.Show();
            textBox2.Show();

            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            radioButton3.Hide();
            radioButton4.Hide();
            radioButton5.Hide();
            radioButton6.Hide();
            radioButton7.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button4.Show();
            button3.Show();
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            button3.Hide();
            button4.Hide();
            label2.Show();
            label3.Show();
            textBox1.Show();
            textBox2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button3.Hide();

            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            textBox6.Show();
            radioButton3.Show();
            radioButton4.Show();
            radioButton5.Show();
            radioButton6.Show();
            radioButton7.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            meal.ShowDialog();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //button3.Show();
        }

    
    }
}

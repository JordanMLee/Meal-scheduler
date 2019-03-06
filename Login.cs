using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography; //For MD5 Method

namespace Lee_Hooymans_V1
{
    public partial class Login : Form
    {

        public bool admin = true;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pHash = MD5(textBox1.Text);
            if (pHash == "5F4DCC3B5AA765D61D8327DEB882CF99") //MD5 Hash for "Password" from http://www.miraclesalad.com/webtools/md5.php
            {
                admin = true;
                this.Hide();
            }
            else
            {
                admin = false;
                MessageBox.Show("Password is Incorrect");
            }
            textBox1.Text = ""; //clears password textbox
        
        }

        //From http://www.vcskicks.com/compute-hash.php
        private string MD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 is the ASCII code for Enter
            {
                this.button1_Click(sender, e); //if user presses enter, same as clicking button
            }
        }

    }
}

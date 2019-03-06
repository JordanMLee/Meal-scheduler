using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; //For database useage

namespace Lee_Hooymans_V1
{
    public partial class PinEntry : Form
    {
        //Needed for MS Access DB Use: (update, sort, filter, etc)
        public string connString;
        public string query;
        public OleDbDataAdapter dAdapter;
        public DataTable dTable;
        public OleDbCommandBuilder cBuilder;
        public DataView myDataView;
        //MS Access lines complete.
        public PinEntry()
        {
            InitializeComponent();
            this.textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            this.textBox2.KeyPress += new KeyPressEventHandler(textBox2_KeyPress);
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
            //if (e.KeyChar= vbKeyBack) {return;} 
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
            //if (e.KeyChar = (char 8) (return;}
        }

        private void PinEntry_Load(object sender, EventArgs e)
        {
            label4.Hide();
            label5.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            string cadetcode = textBox1.Text;
            string cadetPIN = textBox2.Text;

           
                //Invalid if there is no barcode entered
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Error please input Cadet Code and PIN");
                }//end if

                
                // if there is a cadet code and PIN entered, search through the cadets database to try and match
                // that particular cadet code and PIN with a cadet.
                else
                {

           // Int32 CadetCode = Convert.ToInt32(cadetcode);
            //Int32 CadetPIN = Convert.ToInt32(cadetPIN);
                    //database containing the information for all of the cadets
                    OleDbConnection co = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=jah_Lab2_DB.accdb;Persist Security Info=False");
                    co.Open();
                    //OleDbCommand getID = new OleDbCommand("SELECT * FROM Table1 WHERE ID = @num", co);
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Table1 WHERE CadetCode = @num AND PIN = @num2", co);
                    //OleDbCommand cmdPIN = new OleDbCommand("SELECT *FROM Table1 WHERE PIN = @num", co);
                    cmd.Parameters.AddWithValue("@num", textBox1.Text);
                    cmd.Parameters.AddWithValue("@num2", textBox2.Text);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    //OleDbDataReader readerPIN = cmdPIN.ExecuteReader();
                    int i = 1;//control variable intially set to 1
            
                    //while it searches through the database, incriment 1 if any cadet with that barcode
                    //is encountered
                    while (reader.Read())
                    {
                        i++;
                    } //end while

                
                    //database containing information on all of the blacklisted cadets
                    OleDbConnection co2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb;Persist Security Info=False");
                    co2.Open();
                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Table1 WHERE CadetCode = @num", co2);
                    cmd2.Parameters.AddWithValue("@num", textBox1.Text);
                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    int i2 = 1;//control variable intially set to 1

                    //while it searches through the blacklist database, increment i2 if any cadet with that
                    //barcode is encountered
                   
                    while (reader2.Read())
                    {
                        i2++;
                    }//end while

                    
                    
                     //If control variable is still 1, no valid cadets were found. Display the invalid
                    //label and ensure the valid label is hidden
                    if (i == 1 )
                    {
                        label5.Show();
                        label4.Hide();
                    }
                    //if the control variable is incrimented, there is a valid cadet with that barcode
                    //so display valid label and ensure invalid label is hidden
                    else
                    {
                        //display the valid cadet label
                        if (i2 == 1)
                        {
                            label4.Visible = true;
                            label5.Visible = false;
                           
      
                        }//end if not blacklisted cadets were found
                        else
                        {
                            //tell the user that they are unable to eat and set the label to blacklisted
                            MessageBox.Show("You are not authorized to eat. Please contact a system adminstrator.");
                            
                            textBox1.Visible = false;
                            textBox2.Visible = false;
                        }//end else
                    }//end else
                }//end else

                

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Text = ""; //clears barcode textbox
                textBox2.Text = "";
               timer1.Enabled = false;
           
        }//end timer tick
    }
}

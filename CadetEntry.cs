using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography; //For MD5 Method
using System.Data.OleDb; //For database useage

namespace Lee_Hooymans_V1
{
    public partial class CadetEntry : Form
    {
        public PinEntry pinEntry = new PinEntry();

        CMeal LocalAMeal;
        CMealMini LocalMiniMeal;

        //Analysis Variables Follow
        //*****************************************************************
        public string Analysis_connString;                   
        public string Analysis_query;                        
        public OleDbDataAdapter Analysis_dAdapter;        
        public DataSet dsADB;                                    
        public OleDbCommandBuilder Analysis_query_cBuilder;  
        public BindingSource AnalysisTable_bndSrc;             
        //AnalysisDB.accdb & AnalysisTable
        //CadetCode    dDay    mMonth    yYear
        //******************************************************************


        //*****************************************************************
        public string TAnalysis_connString;
        public string TAnalysis_query;
        public OleDbDataAdapter TAnalysis_dAdapter;
        public DataSet dsTADB;
        public OleDbCommandBuilder TAnalysis_query_cBuilder;
        public BindingSource TAnalysisTable_bndSrc;
        //*****************************************************************

        //Needed for MS Access DB Use: (update, sort, filter, etc)
        public string connString;
        public string query;
        public OleDbDataAdapter dAdapter;
        public DataTable dTable;
        public OleDbCommandBuilder cBuilder;
        public DataView myDataView;
        //MS Access lines complete.

        //DB Step 2
        public string BaseTracker_connString;
        //Connects to Base Tracker (BT) DB
        public string BaseTracker_query;
        //Holds SQL query strings to run on database
        public OleDbDataAdapter CGAAccessTable_dAdapter;
        //Adapter to CGAAccessTable TABLE
        public DataSet dsBT;
        //Place for data to reside in program
        public OleDbCommandBuilder BaseTracker_query_cBuilder;
        //Command Builders to add/update/delete tables in DB
        public BindingSource CGAAccessTable_bndSrc;
        //Bound source between program and DB for CGAAccessTable

        //allows access to login menu
        public Login login = new Login();

        //variable to use timer manipulation
        bool trycadet = false;

        bool doubleeater = false;

        //variables to populate CCadet
        string cadetname;
        string cadetcode;

        //default initialization
        public CadetEntry()
        {
            InitializeComponent();
        }

        //initilization that recieves a CMeal to manipulate
        public CadetEntry(CMeal Ameal, CMealMini Aminimeal)
        {
            InitializeComponent();
            LocalAMeal = Ameal;
            LocalMiniMeal = Aminimeal;
            //************************************************************
            //Populate database with cadet code, day, month and year
            //DB Step 3: Connect to DB and configure Data Set
            Analysis_connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AnalysisDB.accdb;Persist Security Info=False";
            dsADB = new DataSet();
            Analysis_query = "SELECT * from AnalysisTable";
            Analysis_dAdapter = new OleDbDataAdapter(Analysis_query, Analysis_connString);

            Analysis_query_cBuilder = new OleDbCommandBuilder(Analysis_dAdapter);
            Analysis_query_cBuilder.QuotePrefix = "[";
            Analysis_query_cBuilder.QuoteSuffix = "]";

            Analysis_dAdapter.Fill(dsADB, "AnalysisTable");

            //DB Step 4: Bind database fields to C# fields
            AnalysisTable_bndSrc = new BindingSource();
            AnalysisTable_bndSrc.DataSource = dsADB.Tables["AnalysisTable"];

            this.CadetCodetextBox.DataBindings.Add(new Binding("Text", AnalysisTable_bndSrc, "CadetCode", true));
            this.DayTextBox.DataBindings.Add(new Binding("Text", AnalysisTable_bndSrc, "dDay", true));
            this.MonthTextBox.DataBindings.Add(new Binding("Text", AnalysisTable_bndSrc, "mMonth", true));
            this.YearTextBox.DataBindings.Add(new Binding("Text", AnalysisTable_bndSrc, "yYear", true));
            //DB Step 5: Move database to a new record
            AnalysisTable_bndSrc.AddNew();
            //**********************************************************


            TAnalysis_connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TotalAnalysis.accdb;Persist Security Info=False";
            dsTADB = new DataSet();
            TAnalysis_query = "SELECT * from TAnalysisTable";
            TAnalysis_dAdapter = new OleDbDataAdapter(TAnalysis_query, TAnalysis_connString);

            TAnalysis_query_cBuilder = new OleDbCommandBuilder(TAnalysis_dAdapter);
            TAnalysis_query_cBuilder.QuotePrefix = "[";
            TAnalysis_query_cBuilder.QuoteSuffix = "]";

            TAnalysis_dAdapter.Fill(dsTADB, "TAnalysisTable");

            // DB Step 4: Bind database fields to C# fields
            TAnalysisTable_bndSrc = new BindingSource();
            TAnalysisTable_bndSrc.DataSource = dsTADB.Tables["TAnalysisTable"];


            //this.DayTextBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "DDay", true));
            //this.MonthTextBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "MMonth", true));
            //this.YearTextBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "YYear", true));
            //this.textBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "total", true));
            ////DB Step 5: Move database to a new record
            ////AnalysisTable_bndSrc.AddNew();
            ////**********************************************************

            //this.DayTextBox.Text = LocalAMeal.getday();
            //this.MonthTextBox.Text = LocalAMeal.getmonth();
            //this.YearTextBox.Text = LocalAMeal.getyear().ToString(); //?????????
            //this.textBox.Text = LocalAMeal.counttotal().ToString();


            this.textBox4.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "DDay", true));
            this.textBox5.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "MMonth", true));
            this.textBox6.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "YYear", true));
            this.textBox7.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "total", true));
            //DB Step 5: Move database to a new record
            AnalysisTable_bndSrc.AddNew();
        }

        //Occurs on each key press
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 is the ASCII code for Enter
            {
                //Invalid if there is no barcode entered
                if (textBox1.Text == "")
                {
                    MessageBox.Show("No Barcode Detected!");
                }

                //if there is a barcode entered, search through the cadets database to try and match
                //that particular barcode with a cadet
                else
                {

                    OleDbConnection co = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=jah_Lab2_DB.accdb;Persist Security Info=False");
                    co.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Table1 WHERE Barcode = @num", co);
                    cmd.Parameters.AddWithValue("@num", textBox1.Text);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    int i = 1;//control variable intially set to 1

                    //DB Step 3: Connect to DB and configure Data Set
                    BaseTracker_connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=jah_Lab2_DB.accdb;Persist Security Info=False";
                    dsBT = new DataSet();
                    BaseTracker_query = "SELECT * from Table1 WHERE Barcode = '" + textBox1.Text + "'";
                    CGAAccessTable_dAdapter = new OleDbDataAdapter(BaseTracker_query, BaseTracker_connString);
                    BaseTracker_query_cBuilder = new OleDbCommandBuilder(CGAAccessTable_dAdapter);
                    BaseTracker_query_cBuilder.QuotePrefix = "[";
                    BaseTracker_query_cBuilder.QuoteSuffix = "]";
                    CGAAccessTable_dAdapter.Fill(dsBT,"Table1");
                    
                    //while it searches through the database, incriment 1 if any cadet with that barcode
                    //is encountered
                    while (reader.Read())
                    {
                        i++;
                        //DB Step 4: Bind database fields to C# fields
                        CGAAccessTable_bndSrc = new BindingSource();
                        CGAAccessTable_bndSrc.DataSource = dsBT.Tables["Table1"];
                        this.textBox2.DataBindings.Add(new Binding("Text", CGAAccessTable_bndSrc, "CadetName", true));
                        this.textBox3.DataBindings.Add(new Binding("Text", CGAAccessTable_bndSrc, "CadetCode", true));
                        cadetname = textBox2.Text;
                        cadetcode = textBox3.Text;
                        CCadet Cadet = new CCadet(cadetname, Int32.Parse(cadetcode));
                        doubleeater = LocalAMeal.checkdup(Cadet);
                        if (!doubleeater)
                        {
                            LocalAMeal.addcadet(Cadet);
                            Cadet.addemeal(LocalMiniMeal);
                        }
                    } //end while

                    OleDbConnection co2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb;Persist Security Info=False");
                    co2.Open();
                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Table1 WHERE Barcode = @num", co2);
                    cmd2.Parameters.AddWithValue("@num", textBox1.Text);
                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    int i2 = 1;//control variable intially set to 1

                    while (reader2.Read())
                    {
                        i2++;
                    }

                    //If control variable is still 1, no valid cadets were found. Display the invalid
                    //label and ensure the valid label is hidden
                    if (i == 1)
                    {
                        label2.Visible = true;
                        label1.Visible = false;
                        label3.Visible = false;
                        trycadet = true;
                    } //end if

                    //if the control variable is incrimented, there is a valid cadet with that barcode
                    //so display valid label and ensure invalid label is hidden
                    else
                    {
                        if (i2 == 1 && !doubleeater)
                        {

                           DayTextBox.Text = LocalAMeal.getday();
                           MonthTextBox.Text = LocalAMeal.getmonth();
                           YearTextBox.Text = LocalAMeal.getyear().ToString();
                           CadetCodetextBox.Text = cadetcode;

                           try
                           {
                               AnalysisTable_bndSrc.EndEdit();
                               Analysis_dAdapter.Update(dsADB, "AnalysisTable");
                           }
                           catch (OleDbException f)
                           {
                               MessageBox.Show("Record Update Failed! Error: " + f.ErrorCode.ToString());
                           }
                           AnalysisTable_bndSrc.AddNew();

                           label1.Visible = true;
                           label2.Visible = false;
                           label3.Visible = false;
                           trycadet = true;



                        }//end if not blacklisted cadets were found
                        else if (!doubleeater)
                        {
                            MessageBox.Show("You are not authorized to eat. Please contact a system adminstrator.");
                            label3.Visible = true;
                            label2.Visible = false;
                            label1.Visible = false;
                            textBox1.Visible = false;
                            textBox2.Visible = false;
                            textBox3.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to eat more than once per meal!");
                            label4.Visible = true;
                            label5.Visible = true;
                            trycadet = true;
                        }
                    }//end else
                }//end else

                //enables the timer
                timer1.Enabled = true;
            }//end if
        }//end keyDown method

        //makes sure the valid and invalid labels are hidden upon initial form access
        private void CadetEntry_Activated(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        //selected in order to return to the main menu, runs the login function to ensure
        //that only admins have access to the main menu
        private void returnToMainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login.ShowDialog();
            bool Pass = login.admin;
            if (Pass)
            {
                LocalAMeal.exportdata();

                DayTextBox.DataBindings.Clear();
                MonthTextBox.DataBindings.Clear();
                YearTextBox.DataBindings.Clear();

                //add day, month, year and LocalAMeal.counttotal()
                //************************************************************
                //Populate database with cadet code, day, month and year
                //DB Step 3: Connect to DB and configure Data Set
               // TAnalysis_connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TotalAnalysis.accdb;Persist Security Info=False";
               // dsTADB = new DataSet();
               // TAnalysis_query = "SELECT * from TAnalysisTable";
               // TAnalysis_dAdapter = new OleDbDataAdapter(TAnalysis_query, TAnalysis_connString);

               // TAnalysis_query_cBuilder = new OleDbCommandBuilder(TAnalysis_dAdapter);
               // TAnalysis_query_cBuilder.QuotePrefix = "[";
               // TAnalysis_query_cBuilder.QuoteSuffix = "]";

               // TAnalysis_dAdapter.Fill(dsTADB, "TAnalysisTable");

               //// DB Step 4: Bind database fields to C# fields
               // TAnalysisTable_bndSrc = new BindingSource();
               // TAnalysisTable_bndSrc.DataSource = dsTADB.Tables["TAnalysisTable"];
                
                
               // //this.DayTextBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "DDay", true));
               // //this.MonthTextBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "MMonth", true));
               // //this.YearTextBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "YYear", true));
               // //this.textBox.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "total", true));
               // ////DB Step 5: Move database to a new record
               // ////AnalysisTable_bndSrc.AddNew();
               // ////**********************************************************

               // //this.DayTextBox.Text = LocalAMeal.getday();
               // //this.MonthTextBox.Text = LocalAMeal.getmonth();
               // //this.YearTextBox.Text = LocalAMeal.getyear().ToString(); //?????????
               // //this.textBox.Text = LocalAMeal.counttotal().ToString();


               // this.textBox4.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "DDay", true));
               // this.textBox5.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "MMonth", true));
               // this.textBox6.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "YYear", true));
               // this.textBox7.DataBindings.Add(new Binding("Text", TAnalysisTable_bndSrc, "total", true));
               // //DB Step 5: Move database to a new record
               // AnalysisTable_bndSrc.AddNew();
                //**********************************************************

                this.textBox4.Text = LocalAMeal.getday();
                this.textBox5.Text = LocalAMeal.getmonth();
                this.textBox6.Text = LocalAMeal.getyear().ToString(); //?????????
                this.textBox7.Text = LocalAMeal.counttotal().ToString();




                try
                {
                    TAnalysisTable_bndSrc.EndEdit();
                    TAnalysis_dAdapter.Update(dsTADB, "TAnalysisTable");
                }
                catch (OleDbException f)
                {
                    MessageBox.Show("Record Update Failed! Error: " + f.ErrorCode.ToString());
                }
                TAnalysisTable_bndSrc.AddNew();

                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(trycadet)
            {
                label1.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Text = ""; //clears barcode textbox
                trycadet = false;
                timer1.Enabled = false;
                textBox2.DataBindings.Clear();
                textBox3.DataBindings.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void CadetEntry_Load(object sender, EventArgs e)
        {

        }

        private void adminOverrideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login.ShowDialog();
            bool Pass = login.admin;
            if (Pass)
            {
                MessageBox.Show("Admin override Accepted.");
                label3.Visible = false;
                label2.Visible = false;
                label1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;

                DayTextBox.Text = LocalAMeal.getday();
                MonthTextBox.Text = LocalAMeal.getmonth();
                YearTextBox.Text = LocalAMeal.getyear().ToString();
                CadetCodetextBox.Text = cadetcode;

                try
                {
                    AnalysisTable_bndSrc.EndEdit();
                    Analysis_dAdapter.Update(dsADB, "AnalysisTable");
                }
                catch (OleDbException f)
                {
                    MessageBox.Show("Record Update Failed! Error: " + f.ErrorCode.ToString());
                }
                AnalysisTable_bndSrc.AddNew();

                trycadet = true;
                SendKeys.Send("{tab}");

                //enables the timer
                timer1.Enabled = true;
            }
        }

        private void cadetCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pinEntry.ShowDialog();
        }

        private void addAGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

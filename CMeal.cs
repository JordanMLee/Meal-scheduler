using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee_Hooymans_V1
{
    public class CMeal
    {
        //private data members
        private int totalccount; //stores total number of cadets
        private int totalgcount; //stores total number of guests
        private string day; //stores the day of the week
        private string MealID; //stores the type of meal (dinner lunch or breakfast)
        private string month; //store the month
        private int year; //stores the year
        private CCadet[] attendies = new CCadet[1000]; //Array of CCadets attending
        private CGuest[] attend = new CGuest[100]; //Array of CGuests attending

        //constructor that sets initial counts to 0, and assigns the day of the
        //week, month, year, and meal ID to user entered values
        public CMeal(string theday, string themeal, string themonth, int theyear)
        {
            totalccount = 0; //initially set to 0
            totalgcount = 0; //initially set to 0
            day = theday; //set to the entered day
            MealID = themeal; //set to the entered meal type
            month = themonth; //set month to the entered month
            year = theyear; //set year to the entered year
        }//end constructor

        //returns the day
        public string getday()
        {
            return day;
        }//end getday

        //returns the meal ID
        public string getMealID()
        {
            return MealID;
        }//end getMealID

        //returns the month
        public string getmonth()
        {
            return month;
        }//end getmonth

        //returns the year
        public int getyear()
        {
            return year;
        }//end getyear

        //Adds a new cadet to the array of CCadets
        public void addcadet(CCadet newcadet)
        {
            attendies[totalccount] = newcadet;
            totalccount++;
        }//end addcadet

        //Adds a new guest to the array of CGuests
        public void addguest(CGuest newguest)
        {
            attend[totalgcount] = newguest;
            totalgcount++;
        }//end addguest

        //returns the total number of people who ate a particular meal
        public int counttotal()
        {
            return totalgcount + totalccount;
        }//end ccounttotal

        public bool checkdup(CCadet mystery)
        {
            bool isdup = false;
            for (int j = 0; j < totalccount; j++)
            {
                if (attendies[j].getcc() == mystery.getcc())
                {
                    isdup = true;
                }//end if
            }//end write cadets
            return isdup;
        }

        //export the data of a meal and the attendies to a .csv file to be opened in excel
        public void exportdata()
        {
            string filename = day + "_" + MealID + "_" + month + "_" + year + ".csv";
            string text = day + "," + MealID + "," + month + "," + year + "\n" + "Total Count," + (totalccount + totalgcount) + "\n";
            System.IO.File.WriteAllText(filename, text);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true))
            {
                //junk strings for writing
                string junk;
                string junk2;

                //for each CGuest stored in the array, write the letter G, their name and 
                //their affiliaiton all seperated by ,
                for (int i = 0; i < totalgcount; i++)
                {
                    junk = "G," + attend[i].getname() + "," + attend[i].getaffil();
                    file.WriteLine(junk);
                }//end write guests

                //for each CCadet in the array, write their name and cadet code following
                //a C seperated by ,
                for (int j = 0; j < totalccount; j++)
                {
                    junk2 = "C," + attendies[j].getname() + "," + attendies[j].getcc();
                    file.WriteLine(junk2);
                }//end write cadets
            }//end append to file  
        }//end exportdata

        // Destructor
        ~CMeal()
        {
        }//end deconstructor

    }//end CMeal
}//end namespace
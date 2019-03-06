using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee_Hooymans_V1
{
    public class CMealMini
    {
        private string day; //stores the day of the week
        private string MealID; //stores the type of meal (dinner lunch or breakfast)
        private string month; //store the month
        private int year; //stores the year

        //constructor that sets initial counts to 0, and assigns the day of the
        //week, month, year, and meal ID to user entered values
        public CMealMini(CMeal bigmeal)
        {
            day = bigmeal.getday(); //set to the entered day
            MealID = bigmeal.getMealID(); //set to the entered meal type
            month = bigmeal.getmonth(); //set month to the entered month
            year = bigmeal.getyear(); //set year to the entered year
        }//end constructor

        //returns the day
        public string getday()
        {
            return day;
        }//end get day

        //returns the MealID
        public string getMealID()
        {
            return MealID;
        }//end MealID

        //returns getmonth
        public string getmonth()
        {
            return month;
        }//end getmonth

        //returns the year
        public int getyear()
        {
            return year;
        }//end getyear

        // Destructor
        ~CMealMini()
        {
        }//end deconstructor

    }//end minimeal
}//end class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee_Hooymans_V1
{
    public class CCadet
    {
        private string name;//cadet name
        private int cadetcode;//cadet code
        private CMealMini[] meals = new CMealMini[1000]; //Array of CMealMini's
        private int mealsatt;//keeps track of the meals attended

        //constructor that takes a name and a cadet code
        public CCadet(string thename, int cc)
        {
            name = thename;
            cadetcode = cc;
            mealsatt = 0;
        }//end constructor

        //function that returns the cadet name
        public string getname()
        {
            return name;
        }//end getname

        //returns the cadet code
        public int getcc()
        {
            return cadetcode;
        }//end getcc

        //Adds a new cadet to the array of CCadets
        public void addemeal(CMealMini mmeal)
        {
            meals[mealsatt] = mmeal;
            mealsatt++;
        }//end addcadet

        ////export the data of a meal and the attendies to a .csv file to be opened in excel
        //public void exportdata()
        //{
        //    string text = name + "," + cadetcode + "\n";
        //    System.IO.File.WriteAllText("Cadet.csv", text);
        //    using (System.IO.StreamWriter file = new System.IO.StreamWriter("Cadet.csv", true))
        //    {
        //        //junk strings for writing
        //        string junk;

        //        //for each CGuest stored in the array, write the letter G, their name and 
        //        //their affiliaiton all seperated by ,
        //        for (int i = 0; i < mealsatt; i++)
        //        {
        //            junk = meals[i].getday() + "," + meals[i].getMealID() + "," + meals[i].getmonth() + "," + meals[i].getyear();
        //            file.WriteLine(junk);
        //        }//end write guests
        //    }//end append to file  
        //}//end exportdata

        // Destructor
        ~CCadet()
        {
        }//end deconstructor

    }//end CCadet   
}//end namespace

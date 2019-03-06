using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lee_Hooymans_V1
{
    public class CGuest
    {
        private string Name; //the guest's name
        private string affiliation; //the guest's affiliation

        //constructer that takes the name and affiliation and creates
        //a CGuest
        public CGuest(string thename, string theorg)
        {
            Name = thename;
            affiliation = theorg;
        }//end constructor

        //returns the name
        public string getname()
        {
            return Name;
        }//end getname

        //returns the affiliation of the guest
        public string getaffil()
        {
            return affiliation;
        }//end getaffil

        // Destructor
        ~CGuest()
        {
        }//end deconstructor

    }//end CGuest
}//end class

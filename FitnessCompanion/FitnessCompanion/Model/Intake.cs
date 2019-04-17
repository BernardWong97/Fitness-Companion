using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace FitnessCompanion
{
    public class Intake
    {
        #region Member Attributes
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Protein { get; set; }
        public int Sodium { get; set; }
        public int Sugar { get; set; }
        #endregion

        #region Constructors
        public Intake() { }

        public Intake(string iName, int iCal, int iCarbs, int iFat, int iProtein, int iSodium, int iSugar)
        {
            Name = iName;
            Calories = iCal;
            Carbs = iCarbs;
            Fat = iFat;
            Protein = iProtein;
            Sodium = iSodium;
            Sugar = iSugar;
        }
        #endregion
    } // class

} // namespace

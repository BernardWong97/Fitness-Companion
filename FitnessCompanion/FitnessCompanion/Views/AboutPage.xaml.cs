using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessCompanion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
        #region Constructors
        public AboutPage ()
		{
			InitializeComponent ();
            SetLabels();
		}
        #endregion

        #region Methods
        /// <summary>
        /// Just a simple set label texts method.
        /// </summary>
        public void SetLabels()
        {
            string description = "This is a Fitness Companion Application design to keep track " +
                "of your personal nutrition values, your goal and how much intakes you have.";
            lblDesc.Text = description;

            string page1Desc = "Tracker Page: Add/Delete any intake you have and displayed onto the screen. " +
                "It shows total nutrition you need and have.";
            lblPage1.Text = page1Desc;

            string page2Desc = "BMI Page: Calculate the BMI by inputting height and weight. The default value" +
                "for the two parameters are taken from user's account own height and weight.";
            lblPage2.Text = page2Desc;

            string page3Desc = "Account Page: Where you can modify your nutrition goals and weight and height.";
            lblPage3.Text = page3Desc;
        } // SetLabels()
        #endregion
    } // class
} // namespace
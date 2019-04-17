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
	public partial class BMICalculator : ContentPage
	{
        #region Constructor
        public BMICalculator ()
		{
			InitializeComponent ();
            // default height and weight in entry boxes 
            // are current user's height and weight
            entH.Text = Util.currentUser.Height.ToString();
            entWeight.Text = Util.currentUser.Weight.ToString();
        }
        #endregion

        #region Click Event Handler
        /// <summary>
        /// Get values from entry boxes and calculate BMI (kg/m^2), 
        /// output result to view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalculate_Clicked(object sender, EventArgs e)
        {
            double height = Convert.ToDouble(entH.Text) / 100;
            double weight = Convert.ToDouble(entWeight.Text);
            double result = (weight / (height * height));

            labelAns.Text = result.ToString("0.00");
        } // BtnCalculate_Clicked()
        #endregion
    } // class
} // namespace
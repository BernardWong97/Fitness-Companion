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
		public BMICalculator ()
		{
			InitializeComponent ();
            entH.Text = Util.currentUser.Height.ToString();
            entWeight.Text = Util.currentUser.Weight.ToString();
        }

        private void BtnCalculate_Clicked(object sender, EventArgs e)
        {
            double height = Convert.ToDouble(entH.Text) / 100;
            double weight = Convert.ToDouble(entWeight.Text);
            double result = (weight / (height * height));

            labelAns.Text = result.ToString("0.00");
        }
    }
}
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
	public partial class AccountPage : ContentPage
	{
		public AccountPage ()
		{
			InitializeComponent ();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if(ValidateInputs())
                (BindingContext as MainPageViewModel).SaveUserList();
        }

        public bool ValidateInputs()
        {
            if (entH.Text == "" || entWeight.Text == "" || entCal.Text == "" || entCarbs.Text == "" ||
                entFat.Text == "" || entProtein.Text == "" || entSodium.Text == "" ||
                entSugar.Text == "")
            {
                errorLabel.Text = "Please enter all fields.";
                errorLabel.TextColor = Color.Red;
                return false;
            }
            else if (!entH.Text.All(char.IsDigit) || !entWeight.Text.All(char.IsDigit) ||
                !entCal.Text.All(char.IsDigit) || !entCarbs.Text.All(char.IsDigit) ||
                !entFat.Text.All(char.IsDigit) || !entProtein.Text.All(char.IsDigit) ||
                !entSodium.Text.All(char.IsDigit) || !entSugar.Text.All(char.IsDigit))
            {
                errorLabel.Text = "Please enter positive numberic for all nutrition values.";
                errorLabel.TextColor = Color.Red;
                return false;
            }
            else
            {
                errorLabel.Text = "Successfully Saved!";
                errorLabel.TextColor = Color.Green;
            }

            return true;
        }
    }
}
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
    public partial class RegisterPage : ContentPage
    {
        User registerUser;

        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
            CreateSelectBox();
        }

        private void CreateSelectBox()
        {
            List<string> cmList = new List<string>();
            List<string> weightList = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                cmList.Add(i.ToString("00"));
            } // for

            pckHCM.ItemsSource = cmList;
            pckHCM.SelectedIndex = 75;

            for (int i = 0; i < 400; i++)
            {
                weightList.Add(i.ToString("00"));
            } // for

            pckWKG.ItemsSource = weightList;
            pckWKG.SelectedIndex = 60;
        } // CreateSelectBox()

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as MainPageViewModel).RegisterPage(false);
        } // BtnBack_Clicked()

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            ValidateInputs();
        } // BtnRegister_Clicked()

        private void ValidateInputs()
        {
            string password = entPassword.Text;
            string retypePw = entRePassword.Text;
            string username = entUsername.Text;

            
            if (username == "" || password == "" || retypePw == "")
                errorLabel.Text = "Please enter all fields.";
            else if (password != retypePw)
                errorLabel.Text = "Passwords do not match.";
            else
                errorLabel.Text = "";
        } // BtnRegister_Clicked()
    } // class
} // namespace
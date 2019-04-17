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
        #region Member Attributes
        User registerUser;
        #endregion

        #region Constructors
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
            CreateSelectBox();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create and add Height and Weight select box onto the view.
        /// </summary>
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

        /// <summary>
        /// Call MainPageViewModel.RegisterPage and parse in boolean false value
        /// to pop a page from the navigation stack.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as MainPageViewModel).RegisterPage(false);
        } // BtnBack_Clicked()

        /// <summary>
        /// Validate all inputs, if returns true, create a new User object from user inputs and parse into
        /// MainPageViewModel.Register. If return false, means username has been taken, else "Register"
        /// successful and auto logged in as the new User.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                int height = (Convert.ToInt32(pckHM.SelectedItem) * 100) + Convert.ToInt32(pckHCM.SelectedItem);
                int weight = (Convert.ToInt32(pckWKG.SelectedItem));
                registerUser = new User(entUsername.Text, entPassword.Text, height, weight);
                bool successReg = (BindingContext as MainPageViewModel).Register(registerUser);

                if (!successReg)
                {
                    errorLabel.Text = "Username has been taken.";
                }
                else
                {
                    errorLabel.Text = "Register successful, auto logging in.";
                    errorLabel.TextColor = Color.Green;
                    await Task.Delay(2000); // Wait 2 seconds for users to read the message above
                    Util.currentUser = registerUser; // set Global variable currentUser as this user
                    (BindingContext as MainPageViewModel).Login(registerUser);
                } // if..else
            } // if
        } // BtnRegister_Clicked()

        /// <summary>
        /// Validates all the user inputs from the view by checking whether all fields are not empty
        /// or passwords are match.
        /// </summary>
        /// <returns>true - if everything is alright/false - if password mismatch or a field is empty</returns>
        private bool ValidateInputs()
        {
            string password = entPassword.Text;
            string retypePw = entRePassword.Text;
            string username = entUsername.Text;

            if (username == "" || password == "" || retypePw == "")
            {
                errorLabel.Text = "Please enter all fields.";
                return false;
            }
            else if (password != retypePw)
            {
                errorLabel.Text = "Passwords do not match.";
                return false;
            }   
            else
            {
                errorLabel.Text = "";
            } //if..else..if

            return true;
        } // ValidateInputs()
        #endregion
    } // class
} // namespace
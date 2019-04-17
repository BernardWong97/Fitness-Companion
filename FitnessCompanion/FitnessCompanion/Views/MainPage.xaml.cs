using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public partial class MainPage : ContentPage
    {
        #region Constructors
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }
        #endregion

        #region Click Event Handler
        /// <summary>
        /// Call MainPageViewModel.Login and parse the loggingUser object into it.
        /// If login failed, output error onto label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool success;
            User loggingUser = new User(entUsername.Text, entPassword.Text);

            success = (BindingContext as MainPageViewModel).Login(loggingUser);

            if (!success)
                errorLabel.Text = "Username/Password incorrect";
        } // BtnLogin_Clicked()

        /// <summary>
        /// Call MainPageViewModel.RegisterPage() and parse in boolean true value
        /// to push Register Page onto the navigation stack.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as MainPageViewModel).RegisterPage(true);
        } // BtnRegister_Clicked()
        #endregion
    } // class
} // namespace

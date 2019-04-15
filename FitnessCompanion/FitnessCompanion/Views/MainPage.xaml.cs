﻿using System;
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
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        #region Click Event Handler
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool success;
            User loggingUser = new User(entUsername.Text, entPassword.Text);
            GlobalVariable.user = loggingUser;

            success = (BindingContext as MainPageViewModel).Login(loggingUser);

            if (success)
                test.Text = "logged in";
            else
                test.Text = "failed";
        } // BtnLogin_Clicked()

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as MainPageViewModel).Register();
        } // BtnRegister_Clicked()
        #endregion
    } // class
} // namespace

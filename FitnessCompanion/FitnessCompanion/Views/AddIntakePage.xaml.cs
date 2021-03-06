﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessCompanion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddIntakePage : ContentPage
	{
        #region Member Attributes
        public List<Intake> IntakeList;
        public string MealType;
        public Intake NewIntake;
        #endregion

        #region Constructors
        public AddIntakePage(List<Intake> intakeList, string title)
        {
            InitializeComponent();
            this.BindingContext = new TrackerViewModel(new PageService());
            IntakeList = intakeList;
            MealType = title;
            titleLabel.Text = "Add " + MealType + " Food";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new Intake object from user inputs and add to the IntakeList
        /// then update the local data file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                string foodName = entFoodname.Text;
                int calories = Convert.ToInt32(entCal.Text);
                int carbs = Convert.ToInt32(entCarbs.Text);
                int fat = Convert.ToInt32(entFat.Text);
                int protein = Convert.ToInt32(entProtein.Text);
                int sodium = Convert.ToInt32(entSodium.Text);
                int sugar = Convert.ToInt32(entSugar.Text);

                NewIntake = new Intake(foodName, calories, carbs, fat, protein, sodium, sugar);
                IntakeList.Add(NewIntake);
                (BindingContext as TrackerViewModel).UpdateIntakeList(IntakeList, MealType);
            }
        } // BtnAdd_Clicked()

        /// <summary>
        /// Validates all the user inputs from the view by checking whether all fields are not empty
        /// or inputs are not number when they need to be.
        /// </summary>
        /// <returns>true - if everything is alright/false - if inputs not numeric or a field is empty</returns>
        public bool ValidateInputs()
        {
            if (entFoodname.Text == null || entCal.Text == null || entCarbs.Text == null ||
                entFat.Text == null || entProtein.Text == null || entSodium.Text == null ||
                entSugar.Text == null)
            {
                errorLabel.Text = "Please enter all fields.";
                return false;
            }
            else if (!entCal.Text.All(char.IsDigit) || !entCarbs.Text.All(char.IsDigit) ||
                !entFat.Text.All(char.IsDigit) || !entProtein.Text.All(char.IsDigit) ||
                !entSodium.Text.All(char.IsDigit) || !entSugar.Text.All(char.IsDigit))
            {
                errorLabel.Text = "Please enter positive numberic for all nutrition values.";
                return false;
            }
            else
            {
                errorLabel.Text = "Successfully Added Intake!";
                errorLabel.TextColor = Color.Green;
            } // if..else..if

            return true;
        } // ValidateInputs()

        /// <summary>
        /// Call TrackerViewModel.PopPage to pop a page from the navigation stack.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await(BindingContext as TrackerViewModel).PopPage();
        } // BtnBack_Clicked()
        #endregion
    } // class
} // namespace
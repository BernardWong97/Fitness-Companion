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
	public partial class AddIntakePage : ContentPage
	{
        public List<Intake> IntakeList;
        public string MealType;
        public Intake NewIntake;

        public AddIntakePage(List<Intake> intakeList, string title)
        {
            InitializeComponent();
            this.BindingContext = new TrackerViewModel(new PageService());
            IntakeList = intakeList;
            MealType = title;
            titleLabel.Text = "Add " + MealType + " Food";
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
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
    }
}
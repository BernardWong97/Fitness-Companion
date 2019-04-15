using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public class TrackerViewModel: BaseViewModel
    {    
        #region member attributes
        public ObservableCollection<IntakesList> IntakeList { get; private set; } = new ObservableCollection<IntakesList>();
        public List<Intake> BreakfastIntake { get; private set; } = new List<Intake>();
        public List<Intake> LunchIntake { get; private set; } = new List<Intake>();
        public List<Intake> DinnerIntake { get; private set; } = new List<Intake>();
        public List<Intake> SnacksIntake { get; private set; } = new List<Intake>();
        public Grid BreakfastGrid { get; private set; } = new Grid { BackgroundColor = Color.Black, ColumnSpacing = 1, RowSpacing = 1 };
        private readonly IPageService _pageService;
        #endregion

        #region constructors
        public TrackerViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadIntakeList();
            BreakfastGrid = DataGrid(BreakfastIntake);
        }
        #endregion

        #region public methods
        public void ReadIntakeList()
        {
            IntakeList = IntakesList.ReadIntakeListData();
            BreakfastIntake = IntakeList[0].Breakfast;
            LunchIntake = IntakeList[0].Lunch;
            DinnerIntake = IntakeList[0].Dinner;
            SnacksIntake = IntakeList[0].Snacks;
        } // ReadIntakeList()

        public Grid DataGrid(List<Intake> intakeList)
        {
            Grid dataGrid = new Grid { BackgroundColor = Color.Green, ColumnSpacing = 1, RowSpacing = 1 };
            int rowNum = 0;

            for(var i = 0; i < BreakfastIntake.Count; i++)
            {
                if (i == 0)
                    dataGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star)});

                dataGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            }

            for (var i = 0; i < 7; i++)
            {
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            }

            foreach(var intake in intakeList)
            {
                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Name,
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 0, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Name,
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 1, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Calories.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 2, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Carbs.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 3, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Fat.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 4, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Protein.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 5, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sodium.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 6, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sugar.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = 2,
                }, 7, rowNum);

                rowNum++;
            }
            return dataGrid;
        }
        #endregion
    } // class
} // namespace

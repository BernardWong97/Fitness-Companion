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
        public Grid BreakfastGrid;
        public Grid LunchGrid;
        public Grid DinnerGrid;
        public Grid SnacksGrid;
        private readonly IPageService _pageService;
        #endregion

        #region constructors
        public TrackerViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadIntakeList();
            BreakfastGrid = DataGrid(BreakfastIntake, "Breakfast");
            LunchGrid = DataGrid(LunchIntake, "Lunch");
            DinnerGrid = DataGrid(DinnerIntake, "Dinner");
            SnacksGrid = DataGrid(SnacksIntake, "Snacks");
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

        public Grid DataGrid(List<Intake> intakeList, string title)
        {
            Grid dataGrid = new Grid { ColumnSpacing = 1, RowSpacing = 1, Padding = 2};
            int rowNum = 1;

            for(var i = 0; i < intakeList.Count + 2; i++)
            {
                dataGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            } // for

            for (var i = 0; i < 7; i++)
            {
                if (i == 0)
                    dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            } // for

            SetHeadings(dataGrid, title);
            
            foreach (var intake in intakeList)
            {
                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Name,
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 0, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Calories.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 1, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Carbs.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 2, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Fat.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 3, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Protein.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 4, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sodium.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 5, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sugar.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                }, 6, rowNum);

                rowNum++;
            } // foreach

            SetFootings(dataGrid, intakeList, rowNum);

            return dataGrid;
        } // DataGrid()

        public void SetHeadings(Grid dataGrid, string title)
        {
            string txt = "";
            for(var i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        txt = title;
                        break;
                    case 1:
                        txt = "Calories";
                        break;
                    case 2:
                        txt = "Carbs";
                        break;
                    case 3:
                        txt = "Fat";
                        break;
                    case 4:
                        txt = "Protein";
                        break;
                    case 5:
                        txt = "Sodium";
                        break;
                    case 6:
                        txt = "Sugar";
                        break;
                } // switch

                Label label = new Label
                {
                    Text = txt,
                    BackgroundColor = Color.Blue,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White
                };

                if (i == 0)
                {
                    label.BackgroundColor = Color.White;
                    label.TextColor = Color.Blue;
                    label.FontSize = 25;
                    label.FontAttributes = FontAttributes.Bold;
                } // if
                    

                dataGrid.Children.Add(label, i, 0);
            } // for
        } // SetHeadings()

        public void SetFootings(Grid dataGrid, List<Intake> intakeList, int rowNum)
        {
            string txt = "";

            for (var i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        txt = "Totals";
                        break;
                    case 1:
                        txt = CalcTotals(intakeList, "Calories");
                        break;
                    case 2:
                        txt = CalcTotals(intakeList, "Carbs");
                        break;
                    case 3:
                        txt = CalcTotals(intakeList, "Fat");
                        break;
                    case 4:
                        txt = CalcTotals(intakeList, "Protein");
                        break;
                    case 5:
                        txt = CalcTotals(intakeList, "Sodium");
                        break;
                    case 6:
                        txt = CalcTotals(intakeList, "Sugar");
                        break;
                } // switch

                Label label = new Label
                {
                    Text = txt,
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.Blue
                };

                dataGrid.Children.Add(label, i, rowNum);
            } // for

        } // SetFootings()

        public string CalcTotals(List<Intake> intakeList, string nutrientType)
        {
            int total = 0;
            foreach(var intake in intakeList)
            {
                switch (nutrientType)
                {
                    case "Calories":
                        total += intake.Calories;
                        break;
                    case "Carbs":
                        total += intake.Carbs;
                        break;
                    case "Fat":
                        total += intake.Fat;
                        break;
                    case "Protein":
                        total += intake.Protein;
                        break;
                    case "Sodium":
                        total += intake.Sodium;
                        break;
                    case "Sugar":
                        total += intake.Sugar;
                        break;
                } // switch
            } // foreach

            return total.ToString();
        } // CalcTotals
        #endregion
    } // class
} // namespace

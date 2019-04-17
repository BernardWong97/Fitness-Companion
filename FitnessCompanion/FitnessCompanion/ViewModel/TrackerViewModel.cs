using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public class TrackerViewModel
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
        public IDictionary<string, int> dailyTotals = new Dictionary<string, int>();
        private readonly IPageService _pageService;
        #endregion

        #region constructors
        public TrackerViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadIntakeList();
            dailyTotals.Add("Calories", 0);
            dailyTotals.Add("Carbs", 0);
            dailyTotals.Add("Fat", 0);
            dailyTotals.Add("Protein", 0);
            dailyTotals.Add("Sodium", 0);
            dailyTotals.Add("Sugar", 0);
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

        public void UpdateIntakeList(List<Intake> newList, string mealType)
        {
            switch (mealType)
            {
                case "Breakfast":
                    IntakeList[0].Breakfast = newList;
                    break;
                case "Lunch":
                    IntakeList[0].Lunch = newList;
                    break;
                case "Dinner":
                    IntakeList[0].Dinner = newList;
                    break;
                case "Snacks":
                    IntakeList[0].Snacks = newList;
                    break;
            } // switch

            IntakesList.SaveIntakeListData(IntakeList);
            _pageService.ChangeMainPage(new NavigationPage(new CaloriesTracker()));
        } // UpdateIntakeList()

        public Grid DataGrid(List<Intake> intakeList, string title)
        {
            Grid dataGrid = new Grid { ColumnSpacing = 1, RowSpacing = 1, Padding = 2};
            int rowNum = 1;

            for(var i = 0; i < intakeList.Count + 3; i++)
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
                    HorizontalTextAlignment = TextAlignment.Start,
                }, 0, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Calories.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 1, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Carbs.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 2, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Fat.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 3, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Protein.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 4, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sodium.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 5, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sugar.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 6, rowNum);

                rowNum++;
            } // foreach

            SetFootings(dataGrid, intakeList, rowNum);

            Button addButton = new Button()
            {
                Text = "Add Intake",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                CornerRadius = 7,
                BackgroundColor = Color.Cyan,
            };
            addButton.Clicked += async (s, e) =>
            {
                await _pageService.PushAsync(new AddIntakePage(intakeList, title));
            };

            dataGrid.Children.Add(addButton, 0, rowNum + 1);

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
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };

                if (i == 0)
                {
                    label.BackgroundColor = Color.White;
                    label.TextColor = Color.Blue;
                    label.FontSize = 25;
                    label.FontAttributes = FontAttributes.Bold;
                    label.HorizontalTextAlignment = TextAlignment.Start;
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
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Blue,
                };

                if(i == 0)
                {
                    label.BackgroundColor = Color.White;
                    label.HorizontalTextAlignment = TextAlignment.End;
                }

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

            int value = 0;

            foreach(var kv in dailyTotals)
            {
                if (kv.Key == nutrientType)
                {
                    value = kv.Value + total;
                } // if  
            } // foreach

            dailyTotals.Remove(nutrientType);
            dailyTotals.Add(nutrientType, value);

            return total.ToString();
        } // CalcTotals()

        public string CalcDaily(string nutrientType)
        {
            foreach(var kv in dailyTotals)
            {
                if (kv.Key == nutrientType)
                    return kv.Value.ToString();
            } // foreach

            return "Fail to get KeyValue";
        } // CalcDaily()

        public string CalcRemaining(string nutrientType)
        {
            int remaining = 0;

            switch (nutrientType)
            {
                case "Calories":
                    remaining = Util.currentUser.DailyCalories;
                    break;
                case "Carbs":
                    remaining = Util.currentUser.DailyCarbs;
                    break;
                case "Fat":
                    remaining = Util.currentUser.DailyFat;
                    break;
                case "Protein":
                    remaining = Util.currentUser.DailyProtein;
                    break;
                case "Sodium":
                    remaining = Util.currentUser.DailySodium;
                    break;
                case "Sugar":
                    remaining = Util.currentUser.DailySugar;
                    break;
            } // switch

            foreach(var kv in dailyTotals)
            {
                if(kv.Key == nutrientType)
                {
                    remaining -= kv.Value;
                } // if
            } // foreach

            if (remaining < 0)
                return "0";

            return remaining.ToString();
        } // CalcRemaining()
        #endregion
    } // class
} // namespace

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public class TrackerViewModel : BaseViewModel
    {
        #region member attributes
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<IntakesList> IntakeList { get; private set; } = new ObservableCollection<IntakesList>();

        private List<Intake> breakfastIntake = new List<Intake>();
        private List<Intake> lunchIntake = new List<Intake>();
        private List<Intake> dinnerIntake = new List<Intake>();
        private List<Intake> snacksIntake = new List<Intake>();

        public Grid BreakfastGrid;
        public Grid LunchGrid;
        public Grid DinnerGrid;
        public Grid SnacksGrid;

        public IDictionary<string, int> dailyTotals = new Dictionary<string, int>();
        public Intake selectedIntake;
        private readonly IPageService _pageService;

        public List<Intake> BreakfastIntake
        {
            get { return breakfastIntake; }
            set { SetValue(ref breakfastIntake, value); }
        }

        public List<Intake> LunchIntake
        {
            get { return lunchIntake; }
            set { SetValue(ref lunchIntake, value); }
        }

        public List<Intake> DinnerIntake
        {
            get { return dinnerIntake; }
            set { SetValue(ref dinnerIntake, value); }
        }

        public List<Intake> SnacksIntake
        {
            get { return snacksIntake; }
            set { SetValue(ref snacksIntake, value); }
        }
        #endregion

        #region Constructors
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
        /// <summary>
        /// Read IntakeListData and disassemble into different list of Intake
        /// </summary>
        public void ReadIntakeList()
        {
            IntakeList = IntakesList.ReadIntakeListData();
            BreakfastIntake = IntakeList[0].Breakfast;
            LunchIntake = IntakeList[0].Lunch;
            DinnerIntake = IntakeList[0].Dinner;
            SnacksIntake = IntakeList[0].Snacks;
        } // ReadIntakeList()

        /// <summary>
        /// After added Intake object into the new list,
        /// overwrite the old list into the new list.
        /// </summary>
        /// <param name="newList">The updated list</param>
        /// <param name="mealType">Each mealType has different list</param>
        public async void UpdateIntakeList(List<Intake> newList, string mealType)
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
            await Task.Delay(2000); // Delay to let user read message
            await _pageService.PopAsync(); // Called from AddIntakePage, pop that page and go back to TrackerPage
        } // UpdateIntakeList()

        /// <summary>
        /// Dynamically create a grid contains all the updated data about intakes.
        /// </summary>
        /// <param name="intakeList">The list that needs to be on the grid view</param>
        /// <param name="mealType">The meal type determines which list to take</param>
        /// <returns>The generated data grid</returns>
        public Grid DataGrid(List<Intake> intakeList, string mealType)
        {
            Grid dataGrid = new Grid { ColumnSpacing = 1, RowSpacing = 1, Padding = 2};
            int rowNum = 1;

            for(var i = 0; i < intakeList.Count + 2; i++) // create row definitions based on how many intakes in the list + meal type & total
            {
                dataGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            } // for

            for (var i = 0; i <= 7; i++) // create 7 standard columns (last column for delete button image)
            {
                if (i == 0) // first column should be longer
                    dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            } // for

            SetHeadings(dataGrid, mealType);
            
            foreach (var intake in intakeList) // for each intake, label each data onto the cell
            {
                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Name,
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Start,
                }, 0, rowNum); // name

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Calories.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 1, rowNum); // calories

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Carbs.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 2, rowNum); // carbs

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Fat.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 3, rowNum); // fat

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Protein.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 4, rowNum); // protein

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sodium.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 5, rowNum); // sodium

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sugar.ToString(),
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                }, 6, rowNum); // sugar

                ImageButton deleteBtn = new ImageButton()
                {
                    Source = "deleteIcon.png",
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.Center,
                    WidthRequest = 20,
                    HeightRequest = 20,
                };
                deleteBtn.Clicked += (s, e) =>
                {
                    selectedIntake = intake;
                    DeleteIntake(selectedIntake, mealType);
                };

                dataGrid.Children.Add(deleteBtn, 7, rowNum);

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
                await _pageService.PushAsync(new AddIntakePage(intakeList, mealType));
            };

            dataGrid.Children.Add(addButton, 0, rowNum + 1);

            return dataGrid;
        } // DataGrid()

        /// <summary>
        /// Delete the row of Intake.
        /// </summary>
        /// <param name="selectedIntake">The selected intake to be delete</param>
        /// <param name="mealType">The meal type of the intake</param>
        public void DeleteIntake(Intake selectedIntake, string mealType)
        {
            switch (mealType)
            {
                case "Breakfast":
                    BreakfastIntake.Remove(selectedIntake);
                    IntakeList[0].Breakfast = BreakfastIntake;
                    break;
                case "Lunch":
                    LunchIntake.Remove(selectedIntake);
                    IntakeList[0].Lunch = LunchIntake;
                    break;
                case "Dinner":
                    DinnerIntake.Remove(selectedIntake);
                    IntakeList[0].Dinner = DinnerIntake;
                    break;
                case "Snacks":
                    SnacksIntake.Remove(selectedIntake);
                    IntakeList[0].Snacks = SnacksIntake;
                    break;
            } // switch

            IntakesList.SaveIntakeListData(IntakeList);
            _pageService.ChangeMainPage(new CaloriesTracker()); // As data has changed, need to refresh page
        } // DeleteIntake()

        /// <summary>
        /// Set the headings of each data grid
        /// </summary>
        /// <param name="dataGrid">The targeted data grid to be set</param>
        /// <param name="mealType">The meal type of the data grid</param>
        public void SetHeadings(Grid dataGrid, string mealType)
        {
            string txt = "";

            for(var i = 0; i < 7; i++) // for each column
            {
                switch (i)
                {
                    case 0:
                        txt = mealType;
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

                if (i == 0) // if first column, be the heading of the grid
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

        /// <summary>
        /// Set the footing of each data grid.
        /// </summary>
        /// <param name="dataGrid">The targeted data grid to be set</param>
        /// <param name="intakeList">Needed to calculate total nutritions per meal type</param>
        /// <param name="rowNum">Row number depends on how many Intakes are there, need to be the last row</param>
        public void SetFootings(Grid dataGrid, List<Intake> intakeList, int rowNum)
        {
            string txt = "";

            for (var i = 0; i < 7; i++) // for each column
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

                if(i == 0) // if first column, be the title
                {
                    label.BackgroundColor = Color.White;
                    label.HorizontalTextAlignment = TextAlignment.End;
                }

                dataGrid.Children.Add(label, i, rowNum);
            } // for
        } // SetFootings()

        /// <summary>
        /// Calculate the total nutrition values in each data grid.
        /// </summary>
        /// <param name="intakeList">The targeted list contains all the values to be added</param>
        /// <param name="nutritionType">The type of nutrition determine which value should be adding</param>
        /// <returns>the total values of that nutrition type</returns>
        public string CalcTotals(List<Intake> intakeList, string nutritionType)
        {
            int total = 0;

            foreach(var intake in intakeList)
            {
                switch (nutritionType)
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

            // Find the key value pair in dailyTotals Dictionary
            foreach(var kv in dailyTotals)
            {
                if (kv.Key == nutritionType)
                {
                    value = kv.Value + total;
                } // if  
            } // foreach

            // Dictionary is immutable, so need to remove and re-add
            dailyTotals.Remove(nutritionType);
            dailyTotals.Add(nutritionType, value);

            return total.ToString();
        } // CalcTotals()

        /// <summary>
        /// Get the total nutrition values of each nutrientType
        /// </summary>
        /// <param name="nutritionType">The nutrition type that needs to get the values</param>
        /// <returns>The total nutrition values or "Failed to get KeyValue"</returns>
        public string CalcDaily(string nutritionType)
        {
            foreach(var kv in dailyTotals)
            {
                if (kv.Key == nutritionType)
                    return kv.Value.ToString();
            } // foreach

            return "Fail to get KeyValue";
        } // CalcDaily()

        /// <summary>
        /// Get the remaining nutrition values where User goals - Total values.
        /// </summary>
        /// <param name="nutritionType">The nutrition type that needs to get the values</param>
        /// <returns>The remaining nutrition values or 0 if goal reached</returns>
        public string CalcRemaining(string nutritionType)
        {
            int remaining = 0;

            switch (nutritionType)
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
                if(kv.Key == nutritionType)
                {
                    remaining -= kv.Value;
                } // if
            } // foreach

            if (remaining < 0)
                return "0";

            return remaining.ToString();
        } // CalcRemaining()

        /// <summary>
        /// Pop a page from navigation stack.
        /// </summary>
        /// <returns>Task</returns>
        public async Task PopPage()
        {
            await _pageService.PopAsync();
        }
        #endregion
    } // class
} // namespace

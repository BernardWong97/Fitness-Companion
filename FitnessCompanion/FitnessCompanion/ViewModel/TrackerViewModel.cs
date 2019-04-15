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
            BreakfastGrid = DataGrid(BreakfastIntake, "Breakfast");
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
            Grid dataGrid = new Grid { BackgroundColor = Color.Black, ColumnSpacing = 1, RowSpacing = 1, Padding = 2};
            int rowNum = 1;

            for(var i = 0; i <= BreakfastIntake.Count; i++)
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
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 0, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Calories.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 1, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Carbs.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 2, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Fat.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 3, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Protein.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 4, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sodium.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 5, rowNum);

                dataGrid.Children.Add(new Label()
                {
                    Text = intake.Sugar.ToString(),
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 2,
                }, 6, rowNum);

                rowNum++;
            } // foreach
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
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                dataGrid.Children.Add(label, i, 0);
            } // for
        } // SetHeadings()
        #endregion
    } // class
} // namespace

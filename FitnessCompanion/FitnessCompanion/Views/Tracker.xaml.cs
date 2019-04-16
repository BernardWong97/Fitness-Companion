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
	public partial class Tracker : ContentPage
	{
		public Tracker ()
		{
			InitializeComponent ();
            this.BindingContext = new TrackerViewModel(new PageService());
            SetDataGrids();
            SetDailyGrid();
            SetUserGoal();
            SetRemaining();
        }

        public void SetDataGrids()
        {
            breakfastGrid = (BindingContext as TrackerViewModel).BreakfastGrid;
            Grid.SetRow(breakfastGrid, 1);
            contentGrid.Children.Add(breakfastGrid);

            lunchGrid = (BindingContext as TrackerViewModel).LunchGrid;
            Grid.SetRow(lunchGrid, 2);
            contentGrid.Children.Add(lunchGrid);

            dinnerGrid = (BindingContext as TrackerViewModel).DinnerGrid;
            Grid.SetRow(dinnerGrid, 3);
            contentGrid.Children.Add(dinnerGrid);

            snacksGrid = (BindingContext as TrackerViewModel).SnacksGrid;
            Grid.SetRow(snacksGrid, 4);
            contentGrid.Children.Add(snacksGrid);
        }

        public void SetDailyGrid()
        {
            string txt;
            string nutrientType = "";
            for(var i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        nutrientType = "Calories";
                        break;
                    case 1:
                        nutrientType = "Carbs";
                        break;
                    case 2:
                        nutrientType = "Fat";
                        break;
                    case 3:
                        nutrientType = "Protein";
                        break;
                    case 4:
                        nutrientType = "Sodium";
                        break;
                    case 5:
                        nutrientType = "Sugar";
                        break;
                } // switch

                txt = (BindingContext as TrackerViewModel).CalcDaily(nutrientType);

                Label label = new Label
                {
                    Text = txt,
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Blue,
                };

                dailyGrid.Children.Add(label, i+1, 0);
            } // for
        } // SetDailyGrid()

        public void SetUserGoal()
        {
            User currentUser = Util.currentUser;
            string txt = "0";

            for (var i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        txt = currentUser.DailyCalories.ToString();
                        break;
                    case 1:
                        txt = currentUser.DailyCarbs.ToString();
                        break;
                    case 2:
                        txt = currentUser.DailyFat.ToString();
                        break;
                    case 3:
                        txt = currentUser.DailyProtein.ToString();
                        break;
                    case 4:
                        txt = currentUser.DailySodium.ToString();
                        break;
                    case 5:
                        txt = currentUser.DailySugar.ToString();
                        break;
                } // switch

                Label label = new Label
                {
                    Text = txt,
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                };

                dailyGrid.Children.Add(label, i + 1, 1);
            } // for
        } // SetUserGoal()

        public void SetRemaining()
        {
            string txt;
            string nutrientType = "";
            for (var i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        nutrientType = "Calories";
                        break;
                    case 1:
                        nutrientType = "Carbs";
                        break;
                    case 2:
                        nutrientType = "Fat";
                        break;
                    case 3:
                        nutrientType = "Protein";
                        break;
                    case 4:
                        nutrientType = "Sodium";
                        break;
                    case 5:
                        nutrientType = "Sugar";
                        break;
                } // switch

                txt = (BindingContext as TrackerViewModel).CalcRemaining(nutrientType);

                Label label = new Label
                {
                    Text = txt,
                    BackgroundColor = Color.LightGray,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.Green,
                };

                dailyGrid.Children.Add(label, i + 1, 2);
            } // for
        } // SetRemaining()
    } // class
} // namespace
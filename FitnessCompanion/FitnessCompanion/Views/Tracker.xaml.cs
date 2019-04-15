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
	public partial class Tracker : ContentPage
	{
		public Tracker ()
		{
			InitializeComponent ();
            this.BindingContext = new TrackerViewModel(new PageService());
            SetDataGrids();
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
	}
}
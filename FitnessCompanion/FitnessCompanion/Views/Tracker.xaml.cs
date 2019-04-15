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
            bfastDataGrid = (BindingContext as TrackerViewModel).BreakfastGrid;
            Grid.SetRow(bfastDataGrid, 1);
            Grid.SetColumnSpan(bfastDataGrid, 7);
            breakfastGrid.Children.Add(bfastDataGrid);
        }
	}
}
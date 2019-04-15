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
            breakfastGrid = (BindingContext as TrackerViewModel).BreakfastGrid;
            Grid.SetRow(breakfastGrid, 1);
            contentGrid.Children.Add(breakfastGrid);
        }
	}
}
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

        public AddIntakePage(List<Intake> intakeList)
        {
            InitializeComponent();
            IntakeList = intakeList;

            foreach (var i in IntakeList)
                System.Diagnostics.Debug.WriteLine(i.Name);
        }
    }
}
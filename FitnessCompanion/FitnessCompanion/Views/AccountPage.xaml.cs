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
	public partial class AccountPage : ContentPage
	{
		public AccountPage ()
		{
			InitializeComponent ();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainPageViewModel).SaveUserList();
        }
    }
}
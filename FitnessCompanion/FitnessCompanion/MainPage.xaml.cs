using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        #region Click Event Handler
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            
        } // BtnLogin_Clicked()

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {

        } // BtnRegister_Clicked()

        #endregion
    } // class
} // namespace

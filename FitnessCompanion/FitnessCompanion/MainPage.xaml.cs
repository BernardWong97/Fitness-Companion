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
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            List<User> userList = new List<User>();
            userList = User.ReadUserListData();
            User user1 = userList[0];

            u1.BindingContext = user1;
        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {

        }
    }
}

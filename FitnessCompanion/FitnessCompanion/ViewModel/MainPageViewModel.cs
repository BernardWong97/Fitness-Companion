using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCompanion
{
    class MainPageViewModel
    {
        #region member attributes
        public ObservableCollection<User> UsersList { get; private set; } = new ObservableCollection<User>();
        private readonly IPageService _pageService;
        #endregion

        #region constructors
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadUserList();
        }
        #endregion

        #region public methods
        public void ReadUserList()
        {
            UsersList = User.ReadUserListData();
        } // ReadUserList()

        public void SaveUserList()
        {
            User.SaveUserListData(UsersList);
        } // SaveUserList()

        public bool Login(User loggingUser)
        {
            bool success = false;

            foreach (User u in UsersList)
            {
                success = u.Equals(loggingUser);

                if (success)
                {
                    _pageService.ChangeMainPage(new CaloriesTracker());
                    break;
                }
            }

            return success;
        } // Login()

        public async Task RegisterPage(bool push)
        {
            if (push)
                await _pageService.PushAsync(new RegisterPage());
            else
                await _pageService.PopAsync();
        } // RegisterPage()

        public bool Register(User registerUser)
        {
            foreach(User u in UsersList)
            {
                if (u.Username == registerUser.Username)
                    return false;
            } // foreach
            
            UsersList.Add(registerUser);
            SaveUserList();
            return true;
        } // Register()
        #endregion
    } // class
} // namespace

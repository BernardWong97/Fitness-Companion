using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FitnessCompanion
{
    class MainPageViewModel : BaseViewModel
    {
        #region member attributes
        public ObservableCollection<User> UsersList { get; private set; } = new ObservableCollection<User>();
        private readonly IPageService _pageService;
        #endregion

        #region constructors
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadList();
        }
        #endregion

        #region public methods
        public void ReadList()
        {
            UsersList = User.ReadUserListData();
        } // ReadList()

        public void SaveList()
        {
            User.SaveUserListData(UsersList);
        } // SaveList()

        public bool Login(User loggingUser)
        {
            bool success = false;

            foreach (User u in UsersList)
            {
                success = u.Equals(loggingUser);
                break;
            }

            return success;
        } // Login()
        #endregion
    } // class
} // namespace

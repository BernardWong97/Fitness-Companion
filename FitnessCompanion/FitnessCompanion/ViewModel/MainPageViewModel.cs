using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCompanion
{
    class MainPageViewModel : BaseViewModel
    {
        #region Member Attributes
        public event PropertyChangedEventHandler PropertyChanged;
        private User currentUser;
        public ObservableCollection<User> UsersList { get; private set; } = new ObservableCollection<User>();
        private readonly IPageService _pageService;

        public User CurrentUser
        {
            get { return currentUser; }
            set { SetValue(ref currentUser, value); }
        }
        #endregion

        #region constructors
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            currentUser = Util.currentUser;
            ReadUserList();
        }
        #endregion

        #region public methods
        /// <summary>
        /// Read the user list.
        /// </summary>
        public void ReadUserList()
        {
            UsersList = User.ReadUserListData();
        } // ReadUserList()

        /// <summary>
        /// Overwrite the old User to the updated User object and save the list.
        /// </summary>
        public void SaveUserList()
        {
            int index = 0;
            foreach(var u in UsersList)
            {
                if (u.Username == currentUser.Username)
                    break;

                index++;
            }
            UsersList.RemoveAt(index);
            UsersList.Add(currentUser);
            User.SaveUserListData(UsersList);
        } // SaveUserList()

        /// <summary>
        /// Validate login by checking if the User object contains in the list.
        /// </summary>
        /// <param name="loggingUser">The logging User object</param>
        /// <returns>true if login success, else return false</returns>
        public bool Login(User loggingUser)
        {
            bool success = false;

            foreach (User u in UsersList)
            {
                success = u.Equals(loggingUser);

                if (success)
                {
                    Util.currentUser = u;
                    _pageService.ChangeMainPage(new CaloriesTracker());
                    break;
                } // if
            } // foreach

            return success;
        } // Login()

        /// <summary>
        /// push RegisterPage if parse true, else pop a page from navigation stack.
        /// </summary>
        /// <param name="push">The boolean determines to push or pop the navigation stack</param>
        /// <returns>Task</returns>
        public async Task RegisterPage(bool push)
        {
            if (push)
                await _pageService.PushAsync(new RegisterPage());
            else
                await _pageService.PopAsync();
        } // RegisterPage()

        /// <summary>
        /// Check if username exist, if true, return false, else add to list and save,
        /// return true
        /// </summary>
        /// <param name="registerUser">User object that needs to be registered</param>
        /// <returns>false if username exist, true if success</returns>
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

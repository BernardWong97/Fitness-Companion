using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace FitnessCompanion
{
    public class User
    {
        #region Member Attributes
        public string Username { get; set; }
        public string Password { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int DailyCalories { get; set; }
        public int DailyCarbs { get; set; }
        public int DailyFat { get; set; }
        public int DailyProtein { get; set; }
        public int DailySodium { get; set; }
        public int DailySugar { get; set; }
        #endregion

        #region Constructors
        public User(){ }

        public User(string uname, string pw)
        {
            Username = uname;
            Password = pw;
            Height = 0;
            Weight = 0;
            DailyCalories = 0;
            DailyCarbs = 0;
            DailyFat = 0;
            DailyProtein = 0;
            DailySodium = 0;
            DailySugar = 0;
        }

        public User(string uname, string pw, int h, int w)
        {
            Username = uname;
            Password = pw;
            Height = h;
            Weight = w;
            DailyCalories = 0;
            DailyCarbs = 0;
            DailyFat = 0;
            DailyProtein = 0;
            DailySodium = 0;
            DailySugar = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Read the user list from the local special folder, if no, read from the default folder.
        /// </summary>
        /// <returns>The ObservableCollection of User object</returns>
        public static ObservableCollection<User> ReadUserListData()
        {
            ObservableCollection<User> userList = new ObservableCollection<User>();
            string jsonText;

            try
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, Util.CREDENTIAL_FILE);

                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                } // using
            }
            catch
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FitnessCompanion.Data.credentials.txt");

                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                } // using
            } // try..catch

            userList = JsonConvert.DeserializeObject<ObservableCollection<User>>(jsonText);

            return userList;
        } // ReadUserListData()

        /// <summary>
        /// Save the ObservableCollection of User into the local special folder.
        /// </summary>
        /// <param name="saveList">The User list that needs to be save</param>
        public static void SaveUserListData(ObservableCollection<User> saveList)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, Util.CREDENTIAL_FILE);
           
            using (var writer = new StreamWriter(filename, false))
            {
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            } // using
        } // SaveUserListData()

        /// <summary>
        /// A method to compare two Users by comparing username and password.
        /// </summary>
        /// <param name="anotherUser">The other User to compare</param>
        /// <returns>true if match, false if not match</returns>
        public bool Equals(User anotherUser)
        {
            if(this.Username.Equals(anotherUser.Username)
                && this.Password.Equals(anotherUser.Password))
            {
                return true;
            } // if

            return false;
        } // Equals()
        #endregion
    } // class
} // namespace

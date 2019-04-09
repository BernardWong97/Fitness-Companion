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
        #region member attributes
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        #region constructors
        public User(){ }

        public User(string uname, string pw)
        {
            Username = uname;
            Password = pw;
        }
        #endregion

        #region public methods
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
                }
            }
            catch
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;

                Stream stream = assembly.GetManifestResourceStream("FitnessCompanion.Data.credentials.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                }
            }

            userList = JsonConvert.DeserializeObject<ObservableCollection<User>>(jsonText);

            return userList;
        } // ReadUserListData()

        public static void SaveUserListData(ObservableCollection<User> saveList)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string filename = Path.Combine(path, Util.CREDENTIAL_FILE);
           
            using (var writer = new StreamWriter(filename, false))
            {
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        } // SaveUserListData()
        #endregion
    } // class
} // namespace

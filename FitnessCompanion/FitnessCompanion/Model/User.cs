using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FitnessCompanion
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(){ }

        public User(string uname, string pw)
        {
            Username = uname;
            Password = pw;
        }

        public static List<User> ReadUserListData()
        {
            List<User> userList = new List<User>();
            string jsonText;

            try  // reading the localApplicationFolder first
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, Util.CREDENTIAL_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    // need json library
                }
            }
            catch // fallback is to read the default file
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(
                                                typeof(MainPage)).Assembly;
                // create the stream
                Stream stream = assembly.GetManifestResourceStream(
                                    "FitnessCompanion.Data.credentials.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    // include JSON library now
                }
            }

            userList = JsonConvert.DeserializeObject<List<User>>(jsonText);

            return userList;
        }

        public static void SaveUserListData(List<User> saveList)
        {
            // need the path to the file
            string path = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, Util.CREDENTIAL_FILE);
            // use a stream writer to write the list
            using (var writer = new StreamWriter(filename, false))
            {
                // stringify equivalent
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }
    }
}

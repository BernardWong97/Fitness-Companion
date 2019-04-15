using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace FitnessCompanion
{
    public class IntakesList
    {
        #region member attributes
        public string MealType { get; set; }
        public List<Intake> Intakes { get; set; }
        #endregion

        #region constructors
        public IntakesList() { }

        public IntakesList(string mealType, List<Intake> list)
        {
            MealType = mealType;
            Intakes = list;
        }
        #endregion
        #region public methods
        public static ObservableCollection<IntakesList> ReadIntakeListData()
        {
            ObservableCollection<IntakesList> intakesList = new ObservableCollection<IntakesList>();
            string jsonText;

            try
            {
                string path = Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, Util.INTAKE_FILE);
                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                }
            }
            catch
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;

                Stream stream = assembly.GetManifestResourceStream("FitnessCompanion.Data.intakes.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                }
            }

            intakesList = JsonConvert.DeserializeObject<ObservableCollection<IntakesList>>(jsonText);

            return intakesList;
        } // ReadIntakeListData()
        #endregion
    } // class
} // namespace

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FitnessCompanion
{
    public class TrackerViewModel: BaseViewModel
    {    
        #region member attributes
        public ObservableCollection<IntakesList> IntakeList { get; private set; } = new ObservableCollection<IntakesList>();
        public List<Intake> BreakfastIntake = new List<Intake>();
        public List<Intake> LunchIntake = new List<Intake>();
        public List<Intake> DinnerIntake = new List<Intake>();
        public List<Intake> SnacksIntake = new List<Intake>();
        private readonly IPageService _pageService;
        #endregion

        #region constructors
        public TrackerViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadIntakeList();
        }
        #endregion

        #region public methods
        public void ReadIntakeList()
        {
            IntakeList = IntakesList.ReadIntakeListData();

            foreach (var i in IntakeList)
            {
                switch (i.MealType)
                {
                    case "breakfast":
                        BreakfastIntake = i.Intakes;
                        break;
                    case "lunch":
                        LunchIntake = i.Intakes;
                        break;
                    case "dinner":
                        DinnerIntake = i.Intakes;
                        break;
                    case "snacks":
                        SnacksIntake = i.Intakes;
                        break;
                } // switch
            } // foreach
        } // ReadIntakeList()
        #endregion
    } // class
} // namespace

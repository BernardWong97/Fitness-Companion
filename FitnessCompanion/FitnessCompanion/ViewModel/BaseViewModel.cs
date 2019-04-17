using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FitnessCompanion
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Member Attributes
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method
        /// <summary>
        /// Notify property changes
        /// </summary>
        /// <param name="propertyName">The property name</param>
        protected void OnPropertyChanged([MemberCallerName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                   new PropertyChangedEventArgs(propertyName));
        } // OnPropertyChanged()

        /// <summary>
        /// Set the value if the property notified changes
        /// </summary>
        /// <typeparam name="T">Dynamic type</typeparam>
        /// <param name="backingField">Old value</param>
        /// <param name="value">New value</param>
        /// <param name="propertyName">Property name</param>
        protected void SetValue<T>(ref T backingField, T value, [MemberCallerName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propertyName);
        } // SetValue<T>()
        #endregion
    } // class
} // namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FitnessCompanion
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([MemberCallerName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                   new PropertyChangedEventArgs(propertyName));
        } // OnPorpertyChanged()

        protected void SetValue<T>(ref T backingField, T value, [MemberCallerName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propertyName);
        } // SetValue<T>()

    } // class
} // namespace

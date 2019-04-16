using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        void ChangeMainPage(Page page);
    } // interface
} // namespace

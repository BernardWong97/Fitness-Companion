using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        } // DisplayAlert()

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        } // PushAsync

        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        } // PushAsync

        public void ChangeMainPage(Page page)
        {
            Application.Current.MainPage = new NavigationPage(page);
        } // ChangeMainPage
    } // class
} // namespace

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessCompanion
{
    public class PageService : IPageService
    {
        #region Methods
        /// <summary>
        /// Display an Alert on view.
        /// </summary>
        /// <param name="title">The title of the alert</param>
        /// <param name="message">The message of the alert</param>
        /// <param name="ok">The OK button of the alert</param>
        /// <param name="cancel">The Cancel button of the alert</param>
        /// <returns>Task<bool></bool></returns>
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        } // DisplayAlert()

        /// <summary>
        /// Push a page onto the navigation stack.
        /// </summary>
        /// <param name="page">The page that is going to be push</param>
        /// <returns>Task</returns>
        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        } // PushAsync

        /// <summary>
        /// Pop a page from the navigation stack.
        /// </summary>
        /// <returns>Task</returns>
        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        } // PushAsync

        /// <summary>
        /// Reset the navigation stack by changing the root page.
        /// </summary>
        /// <param name="page">The root page of the navigation stack</param>
        public void ChangeMainPage(Page page)
        {
            Application.Current.MainPage = new NavigationPage(page);
        } // ChangeMainPage
        #endregion
    } // class
} // namespace

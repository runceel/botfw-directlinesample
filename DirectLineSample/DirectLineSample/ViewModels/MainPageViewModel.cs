using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace DirectLineSample.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string message;

        public string Message
        {
            get { return this.message; }
            set { this.SetProperty(ref this.message, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            this.Message = "Hello world Prism.Forms!!";
        }
    }
}

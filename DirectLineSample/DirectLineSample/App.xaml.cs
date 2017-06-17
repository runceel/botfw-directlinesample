using DirectLineSample.Views;
using Prism.Autofac;
using Prism.Autofac.Forms;
using Xamarin.Forms;

namespace DirectLineSample
{
    public partial class App : PrismApplication
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override async void OnInitialized()
        {
            await this.NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            this.Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}

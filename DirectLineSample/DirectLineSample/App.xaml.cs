using Autofac;
using DirectLineSample.Services;
using DirectLineSample.Views;
using Microsoft.Bot.Connector.DirectLine;
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
            await this.NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance<IDirectLineClient>(new DirectLineClient(Secrets.DirectLineApiKey));
            builder.RegisterType<BotService>().As<IBotService>().SingleInstance();
            builder.Update(this.Container);

            this.Container.RegisterTypeForNavigation<NavigationPage>();
            this.Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}

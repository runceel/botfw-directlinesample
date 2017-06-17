using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using DirectLineSample.Services;
using Microsoft.Bot.Connector.DirectLine;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace DirectLineSample.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private static PropertyChangedEventArgs CanSendMessagePropertyChangedEventArgs { get; } = new PropertyChangedEventArgs(nameof(CanSendMessage));

        private IBotService BotService { get; }

        private string Watermark { get; set; }

        private string conversationId;

        public string ConversationId
        {
            get { return this.conversationId; }
            set { this.SetProperty(ref this.conversationId, value); this.OnPropertyChanged(CanSendMessagePropertyChangedEventArgs); }
        }

        private string inputMessage;

        public string InputMessage
        {
            get { return this.inputMessage; }
            set { this.SetProperty(ref this.inputMessage, value); this.OnPropertyChanged(CanSendMessagePropertyChangedEventArgs); }
        }

        public bool CanSendMessage => !string.IsNullOrWhiteSpace(this.ConversationId) && !string.IsNullOrWhiteSpace(this.InputMessage);

        public ObservableCollection<Activity> Messages { get; } = new ObservableCollection<Activity>();

        public DelegateCommand SendMessageCommand { get; }

        public MainPageViewModel(IBotService botService)
        {
            this.BotService = botService;

            this.SendMessageCommand = new DelegateCommand(async () => await this.SendMessageExecuteAsync())
                .ObservesCanExecute(() => this.CanSendMessage);
        }

        private async Task SendMessageExecuteAsync()
        {
            await this.BotService.SendMessageAsync(this.ConversationId, this.InputMessage);
            this.InputMessage = "";
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            this.ConversationId = await this.BotService.StartConversationAsync();
            var ignore = this.StartGetMessagesLoopAsync(CancellationToken.None);
        }

        private async Task StartGetMessagesLoopAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var result = await this.BotService.GetMessagesAsync(this.ConversationId, this.Watermark);
                this.Watermark = result.watermark;
                foreach (var message in result.messages)
                {
                    this.Messages.Add(message);
                }

                await Task.Delay(5000);
            }
        }
    }
}

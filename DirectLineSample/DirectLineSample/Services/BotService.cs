using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Connector.DirectLine;

namespace DirectLineSample.Services
{
    public class BotService : IBotService
    {
        private static string BotUserName { get; } = "DirectLineSample";

        private IDirectLineClient DirectLineClient { get; }

        public BotService(IDirectLineClient directLineClient)
        {
            this.DirectLineClient = directLineClient;
        }

        public Task<IEnumerable<Activity>> GetMessagesAsync(string conversationId, string watermark)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessageAsync(string conversationId, string message)
        {
            await this.DirectLineClient.Conversations.PostActivityAsync(
                conversationId,
                new Activity
                {
                    From = new ChannelAccount(BotUserName),
                    Text = message,
                    Type = ActivityTypes.Message,
                });
        }

        public async Task<string> StartConversationAsync()
        {
            var conversation = await this.DirectLineClient.Conversations.StartConversationAsync();
            return conversation.ConversationId;
        }
    }
}

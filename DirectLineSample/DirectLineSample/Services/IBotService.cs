using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Connector.DirectLine;

namespace DirectLineSample.Services
{
    public interface IBotService
    {
        Task<string> StartConversationAsync();
        Task SendMessageAsync(string conversationId, string message);
        Task<(IEnumerable<Activity> messages, string watermark)> GetMessagesAsync(string conversationId, string watermark);
    }
}

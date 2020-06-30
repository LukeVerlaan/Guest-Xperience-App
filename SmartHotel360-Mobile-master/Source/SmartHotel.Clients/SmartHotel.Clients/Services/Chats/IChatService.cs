using SmartHotel.Clients.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Chats
{
    public interface IChatService
    {
        Task ConnectAsync();
        Task SendMessage(Message message);
        event EventHandler<Message> OnMessageReceived;
    }
}

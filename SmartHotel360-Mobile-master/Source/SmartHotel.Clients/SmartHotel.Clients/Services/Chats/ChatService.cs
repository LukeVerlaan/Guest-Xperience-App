using Microsoft.AspNetCore.SignalR.Client;
using SmartHotel.Clients.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly HubConnection hubConnection;
        //private readonly IHubProxy hubProxy;

        public event EventHandler<Message> OnMessageReceived;

        public ChatService()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://192.168.2.9:6101/chatHub")
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) => OnMessageReceived(this, new Message
             {
                User = user,
                Text = message
             }));
        }

        public async Task ConnectAsync()
        {
            await hubConnection.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            await hubConnection.StopAsync();
        }

        public async Task SendMessage(Message message)
        {
            await hubConnection.InvokeAsync("SendMessage", message.User, message.Text, message.SendTime);
        }
    }
}

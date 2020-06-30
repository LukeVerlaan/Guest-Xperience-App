using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Services.Chats;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ChatViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Chat chat;
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        private string textToSend;
        public ICommand OnSendCommand { get; set; }

        private IChatService _chatService;

        public ChatViewModel(IChatService chatService)
        {

            _chatService = chatService;

            OnSendCommand = new Command(SendExecute);

            _chatService.OnMessageReceived += OnMessageReceived;
            _chatService.ConnectAsync();

            //OnSendCommand = new Command(() =>
            //{
            //    if (!string.IsNullOrEmpty(TextToSend))
            //    {
            //        chat.Messages.Add(new Message() { Text = textToSend, User = AppSettings.User?.Name, SendTime = DateTime.Now });
            //        textToSend = string.Empty;
            //        OnPropertyChanged(nameof(textToSend));
            //    }

            //});
        }

        public Chat Chat
        {
            get => chat;
            set => SetProperty(ref chat, value);
        }

        public string TextToSend
        {
            get => textToSend;
            set => SetProperty(ref textToSend, value);
        }

        private void OnMessageReceived(object sender, Message message)
        {
            Chat.Messages.Add(message);
        }

        private async void SendExecute()
        {
            var message = new Message
            {
                User = AppSettings.User?.Name,
                Text = TextToSend
            };

            await _chatService.SendMessage(message);

            TextToSend = string.Empty;
        }


        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Chat = navigationData as Chat;
            }

            return base.InitializeAsync(navigationData);
        }

    }
}

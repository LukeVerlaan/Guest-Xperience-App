using SmartHotel.Clients.Core.Models;
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
        Chat chat;
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }

        public ChatViewModel()
        {

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    chat.Messages.Add(new Message() { Text = TextToSend, User = AppSettings.User?.Name, SendTime = DateTime.Now });
                    TextToSend = string.Empty;
                    OnPropertyChanged(nameof(TextToSend));
                }

            });
        }

        public Chat Chat
        {
            get => chat;
            set => SetProperty(ref chat, value);
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

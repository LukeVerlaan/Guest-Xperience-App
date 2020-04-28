//using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ChatViewModel : ViewModelBase, INotifyPropertyChanged
    {
        Models.Chat chat;
        public string TextToSend { get; set; }
        
        public ChatViewModel()
        {

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    chat.Messages.Add(new Models.Message() { Text = TextToSend, User = AppSettings.User?.Name, SendTime = DateTime.Now });
                    TextToSend = string.Empty;
                }

            });
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public Models.Chat Chat
        {
            get => chat;
            set => SetProperty(ref chat, value);
        }

        public ICommand OnSendCommand { get; set; }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Chat = navigationData as Models.Chat;
            }

            return base.InitializeAsync(navigationData);
        }

    }
}

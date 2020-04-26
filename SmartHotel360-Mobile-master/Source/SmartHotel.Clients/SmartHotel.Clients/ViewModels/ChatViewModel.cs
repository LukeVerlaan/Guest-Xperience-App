//using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.ViewModels.Base;
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
        public ObservableCollection<Models.Message> Messages { get; set; } = new ObservableCollection<Models.Message>();
        public string TextToSend { get; set; }
        
        public ChatViewModel()
        {
            Messages.Add(new Models.Message() { Text = "Hi", User = "ChatBot" });
            Messages.Add(new Models.Message() { Text = "How are you?", User = "ChatBot" });

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Add(new Models.Message() { Text = TextToSend, User = AppSettings.User?.Name });
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

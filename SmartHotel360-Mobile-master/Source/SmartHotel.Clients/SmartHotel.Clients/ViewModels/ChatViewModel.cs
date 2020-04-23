using SmartHotel.Clients.Core.ViewModels.Base;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        Models.Chat chat;
        public ChatViewModel()
        {
        }

        public Models.Chat Chat
        {
            get => chat;
            set => SetProperty(ref chat, value);
        }

    }
}

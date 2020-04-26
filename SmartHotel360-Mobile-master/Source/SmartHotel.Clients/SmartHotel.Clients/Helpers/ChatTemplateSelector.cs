using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Views.Templates;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Helpers
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessageViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingMessageViewCell));
        }

        public string UserName => AppSettings.User?.Name;

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;


            return (messageVm.User == UserName) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}

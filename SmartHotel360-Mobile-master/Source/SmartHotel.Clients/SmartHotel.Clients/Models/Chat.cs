using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartHotel.Clients.Core.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Message> Messages { get; set; }

        public override string ToString() => $"{Name}";

    }
}

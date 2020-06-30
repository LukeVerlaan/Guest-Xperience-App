using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartHotel.Clients.Core.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public int HotelId { get; set; }
        public int StatusId { get; set; }
        public int ChatType { get; set; }

        public string Name { get; set; }
        public int? EventId { get; set; }

        public ObservableCollection<Message> Messages { get; set; }

        public IEnumerable<User> Users { get; set; }
        public override string ToString() => $"{Name}";

    }
}

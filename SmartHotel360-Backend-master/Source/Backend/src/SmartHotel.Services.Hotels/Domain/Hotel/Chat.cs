using System.Collections.ObjectModel;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class Chat
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public ChatType ChatType { get; set; }
        public ObservableCollection<Message> Messages { get; set; }

    }
}

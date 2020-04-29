using System.Collections.Generic;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class Chat
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public List<Message> Messages { get; set; }

    }
}

using System.Collections.Generic;

namespace SmartHotel.Clients.Core.Models
{
    public class ShopOrder
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public List<ShopItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

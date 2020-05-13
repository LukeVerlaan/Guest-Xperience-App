using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    class ShopOrder
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public IEnumerable<ShopItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

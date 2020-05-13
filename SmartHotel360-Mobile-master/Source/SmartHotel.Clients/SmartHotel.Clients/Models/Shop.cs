using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string ShopType { get; set; }
        public List<ShopItem> Items { get; set; }

        public override string ToString() => $"{Name}";
    }
}

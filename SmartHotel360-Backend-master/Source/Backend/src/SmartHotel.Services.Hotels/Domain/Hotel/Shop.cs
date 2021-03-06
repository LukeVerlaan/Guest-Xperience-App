﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class Shop
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string ShopType { get; set; }
        public List<ShopItem> Items { get; set; }

    }
}

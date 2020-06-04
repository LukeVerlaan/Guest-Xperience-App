using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class ShopItem
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string ProductImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        //public decimal? PriceExVat { get; set; }
        //public decimal? Vat { get; set; }
        //public int? VatRate { get; set; }
        //public decimal? PriceIncVat { get; set; }
        //public int? VatRateId { get; set; }
        public List<Size> Sizes { get; set; }
        public string Category { get; set; }
    }
}

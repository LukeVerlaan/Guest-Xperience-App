using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class Item
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PriceExVat { get; set; }
        public decimal? Vat { get; set; }
        public int? VatRate { get; set; }
        public decimal? PriceIncVat { get; set; }
        public int? VatRateId { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}

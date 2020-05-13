using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string ProductImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public decimal? PriceExVat { get; set; }
       // public decimal? Vat { get; set; }
        //public int? VatRate { get; set; }
        //public decimal? PriceIncVat { get; set; }
        //public int? VatRateId { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public override string ToString() => $"{Name}";
    }
}

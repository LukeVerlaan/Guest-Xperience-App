using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class RestaurantServiceOption
    {
        public int Id { get; set; }
        public int RestaurantServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PriceExVat { get; set; }
        public int? VatRateId { get; set; }
        public bool? Blocked { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string ImageLink { get; set; }
        public decimal? PrinceIncVat { get; set; }
        public int? VatRate { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public decimal? Vat { get; set; }
    }
}

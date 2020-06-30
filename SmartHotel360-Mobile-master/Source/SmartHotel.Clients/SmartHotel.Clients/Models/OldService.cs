using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class OldService
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceGroupId { get; set; }
        public decimal? Basic_Price { get; set; }
        public int? Vat_ID { get; set; }
        public bool? Blocked { get; set; }
        public string ImageLink { get; set; }
    }
}

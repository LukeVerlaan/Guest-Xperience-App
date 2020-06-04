using SmartHotel.Clients.Core.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Repository
{
    [Table("OrderItems")]
    public class OrderItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public int ShopId { get; set; }
        [ForeignKey(typeof(ShopOrderModel))]
        public int OrderId { get; set; }
        public string ProductImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        //public decimal? PriceExVat { get; set; }
        // public decimal? Vat { get; set; }
        //public int? VatRate { get; set; }
        //public decimal? PriceIncVat { get; set; }
        //public int? VatRateId { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}

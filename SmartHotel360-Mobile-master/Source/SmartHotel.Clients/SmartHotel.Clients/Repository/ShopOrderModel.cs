using SmartHotel.Clients.Core.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SmartHotel.Clients.Core.Repository
{
    [Table("ShopOrders")]
    public class ShopOrderModel
    {
        [PrimaryKey, AutoIncrement]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        [OneToMany]
        public List<OrderItemModel> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

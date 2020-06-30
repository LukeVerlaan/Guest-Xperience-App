using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class ServiceGroup
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EmailAddres { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string Notes { get; set; }
        public bool? Blocked { get; set; }
        public string ImageLink { get; set; }
    }
}

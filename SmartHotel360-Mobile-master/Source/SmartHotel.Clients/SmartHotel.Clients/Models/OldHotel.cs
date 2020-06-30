using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class OldHotel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? HotelGroupId { get; set; }
        public decimal? LocationX { get; set; }
        public decimal? LocationY { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ReservationUrl { get; set; }
        public string Facilities { get; set; }
        public string Surroundings { get; set; }
        public string ParkingDescription { get; set; }
        public string RouteDescription { get; set; }

        public override string ToString() => $"{Name}, {Code}";
    }
}

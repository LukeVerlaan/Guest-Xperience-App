using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHotel.Clients.Core.Models
{
    public class HotelEventServiceOption
    {
        public int Id { get; set; }
        public int HotelEventServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PricePerPersonExVat { get; set; }
        public int? VatRateId { get; set; }
        public int? CategoryId { get; set; }
        public string ImageLink1 { get; set; }
        public string ImageLink2 { get; set; }
        public string VideoLink { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime TimeEnd { get; set; }
        public int? TotalOfPersons { get; set; }
        public int? RepeatingDays { get; set; }
        public string MeetingRoom { get; set; }
        public decimal? PricePerPersonIncVat { get; set; }
        public int? VatRate { get; set; }
        public string Category { get; set; }
        public decimal? Vat { get; set; }
        public bool? Blocked { get; set; }
    }
}

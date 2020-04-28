using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class Message
    {
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime SendTime { get; set; }
    }
}

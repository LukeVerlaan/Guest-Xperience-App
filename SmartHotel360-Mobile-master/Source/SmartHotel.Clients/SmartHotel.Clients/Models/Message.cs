﻿using System;

namespace SmartHotel.Clients.Core.Models
{
    public class Message
    {
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime SendTime { get; set; }
    }
}

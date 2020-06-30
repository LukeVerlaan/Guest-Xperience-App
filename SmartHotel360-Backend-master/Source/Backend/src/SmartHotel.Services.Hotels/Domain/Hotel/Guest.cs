using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Domain.Hotel
{
    public class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public string MailAddress { get; set; }
        public string Company { get; set; }
        public int? MainGuestId { get; set; }
        public int? LanguageId { get; set; }
        public string PhoneModel { get; set; }
        public DateTime LastCheckIn { get; set; }
        public bool Active { get; set; }
        public string Roomnumber { get; set; }
        public bool Blocked { get; set; }
        public bool Inactive { get; set; }
        public int HotelId { get; set; }
        public string PhoneGuid { get; set; }
        public string DeviceType { get; set; }

        //public List<GuestNotificationViewModel> GetNotifications()
        //{
        //    return new GuestNotificationService().GetByGuest(Id);
        //}

        //public override void LoadTranslationApi(int language)
        //{
        //}
    }
}

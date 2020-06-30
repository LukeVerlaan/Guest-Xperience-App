using System.Threading.Tasks;
using SmartHotel.Clients.Core.Models;
using System.Collections.Generic;
using SmartHotel.Clients.Core.Extensions;
using System.Linq;
using System;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Services.Hotel
{
    public class FakeHotelService : IHotelService
    {
        static readonly List<City> cities = new List<City>
        {
            new City
            {
                Id = 1,
                Name = "Seattle",
                Country = "United States",
            },
            new City
            {
                Id = 2,
                Name = "Seville",
                Country = "Spain",
            },
            new City
            {
                Id = 3,
                Name = "Barcelona",
                Country = "Spain"
            }
        };

        static readonly List<Chat> chats = new List<Chat>
        {
            new Chat
            {
                Id = 1,
                Name = "Reception Chat"
            },
            new Chat
            {
                Id = 2,
                Name = "Bar Chat"
            },
            new Chat
            {
                Id = 3,
                Name = "Event Chat"
            }
        };

        static readonly List<Shop> shops = new List<Shop>
        {
            new Shop
            {
                Id = 1,
                Name = "Jewelz"
            },
            new Shop
            {
                Id = 2,
                Name = "Clothes"
            },
            new Shop
            {
                Id = 3,
                Name = "Souvenir"
            }
        };

        static List<Models.Hotel> hotels = new List<Models.Hotel>
        {
            new Models.Hotel
            {
                Id = 1,
                CityId = 3,
                Name = "Secret Camp Hotel",
                Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_1.png" : "img_1",
                City = "Barcelona, Spain",
                PricePerNight = 76,
                Price = 76,
                Rating = 3,
                Latitude = 47.612081510010654,
                Longitude = -122.330555830464,
                CheckInTime = "12:00:00",
                CheckOutTime = "15:00:00",
                Services = new List<Service>
                {
                    new Service { Id = 1, Name = "Free Wi-fi" }
                },
                Rooms = new List<Room>
                {
                    new Room { RoomId = 1, Quantity = 1, RoomName = "Single Room", RoomType = 1 }
                },
                Description = "The Hotel is the right choice for visitors who are searching for a combination of charm, peace and quiet. The buffet breakfast is served in the lounge on the ground floor, and also outside on our little patio during the summer months. The hotel provides an internet point, and a Wi-Fi service."
            },
            new Models.Hotel
            {
                Id = 2,
                CityId = 2,
                Name = "Prism Hotel",
                Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_2.png" : "img_2",
                City = "Seville, Spain",
                PricePerNight = 161,
                Price = 161,
                Rating = 3,
                Latitude = 47.612081510010654,
                Longitude = -122.330555830464,
                CheckInTime = "12:00:00",
                CheckOutTime = "15:00:00",
                Services = new List<Service>
                {
                    new Service { Id = 1, Name = "Free Wi-fi" }
                },
                Rooms = new List<Room>
                {
                    new Room { RoomId = 1, Quantity = 1, RoomName = "Single Room", RoomType = 1 }
                },
                Description = "The Hotel is the right choice for visitors who are searching for a combination of charm, peace and quiet. The buffet breakfast is served in the lounge on the ground floor, and also outside on our little patio during the summer months. The hotel provides an internet point, and a Wi-Fi service."
            },
            new Models.Hotel
            {
                Id = 3,
                CityId = 1,
                Name = "Elite Hotel",
                Picture = Device.RuntimePlatform == Device.UWP ? "Assets/img_3.png" : "img_3",
                City = "Seattle, United States",
                PricePerNight = 202,
                Price = 202,
                Rating = 4,
                Latitude = 47.612081510010654,
                Longitude = -122.330555830464,
                CheckInTime = "12:00:00",
                CheckOutTime = "15:00:00",
                Services = new List<Service>
                {
                    new Service { Id = 1, Name = "Free Wi-fi" }
                },
                Rooms = new List<Room>
                {
                    new Room { RoomId = 1, Quantity = 1, RoomName = "Single Room", RoomType = 1 }
                },
                Description = "The Hotel is the right choice for visitors who are searching for a combination of charm, peace and quiet. The buffet breakfast is served in the lounge on the ground floor, and also outside on our little patio during the summer months. The hotel provides an internet point, and a Wi-Fi service."
            }
        };

        static List<Review> reviews = new List<Review>
        {
            new Review
            {
                HotelId = 1,
                User = "John Doe",
                Message = "Have some work to do? Grab a good Full English and sit on one of the comfortable sofas with your laptop.",
                Room = "Single room",
                Date = DateTime.Today.AddDays(-1),
                Rating = 3
            },
            new Review
            {
                HotelId = 2,
                User = "Larry Cross",
                Message = "Great concept. Modern without being too clean.",
                Room = "Double room",
                Date = DateTime.Today.AddDays(-2),
                Rating = 3
            },
            new Review
            {
                HotelId = 3,
                User = "Carolyne Breit",
                Message = "Trendy hotel with the best lounge area I've ever seen. Cozy place with comfy beds.",
                Room = "Single room",
                Date = DateTime.Today.AddDays(-3),
                Rating = 4
            }
        };

        static List<Service> hotelServices = new List<Service>
        {
            new Service
            {
                Id = 1,
                Name = "Free Wi-Fi"
            },
            new Service
            {
                Id = 2,
                Name = "Pool"
            },
            new Service
            {
                Id = 2,
                Name = "Air conditioning"
            }
        };

        static List<Service> roomServices = new List<Service>
        {
            new Service
            {
                Id = 1,
                Name = "Air conditioning"
            },
            new Service
            {
                Id = 2,
                Name = "Green"
            },
            new Service
            {
                Id = 3,
                Name = "Jacuzzi"
            }
        };

        static List<OldHotel> oldHotels = new List<OldHotel>
        {
            new OldHotel
            {
                Id = 1,
                Code = "ELP",
                HotelGroupId = 1,
                LocationX = 51,
                LocationY = 4,
                CountryId = 1,
                Name = "East Lane Park Hotel",
                Description = "Het hotel ligt dicht bij de polders, waar u kunt genieten van een prachtig Nederlands landschap.",
                ImageLink1 = "images.sbit.enixe.com/hotel.jpg",
                ImageLink2 = "images.sbit.enixe.com/hotel.jpg",
                Phone = "+31348430222",
                Email = "info@sbit-woerden.nl",
                ReservationUrl = "s-bit.nl",
                Facilities = "Shop, Zwembad",
                Surroundings = "Gelegen in de bosrijke omgeving van Woerden. Leuke fiets- en wandelroutes in de omgeving. Bezoekt u vooral ook een keer de heksenwaag in het nabije Oudewater",
                ParkingDescription = "Parking outside hotel",
                RouteDescription = "Vanuit Utrecht neemt u de snelweg richting Den Haag. Bij Woerden slaat u af richting Woerden centrum. U volgt de borden naar de McDonalds. Rechts naast de McDonalds bevindt zich ons hotel.",
    },
            new OldHotel
            {
                Id = 2,
                Code = "ELP",
                HotelGroupId = 1,
                LocationX = 51,
                LocationY = 4,
                CountryId = 1,
                Name = "East Lane Park Hotel",
                Description = "Het hotel ligt dicht bij de polders, waar u kunt genieten van een prachtig Nederlands landschap.",
                ImageLink1 = "images.sbit.enixe.com/hotel.jpg",
                ImageLink2 = "images.sbit.enixe.com/hotel.jpg",
                Phone = "+31348430222",
                Email = "info@sbit-woerden.nl",
                ReservationUrl = "s-bit.nl",
                Facilities = "Shop, Zwembad",
                Surroundings = "Gelegen in de bosrijke omgeving van Woerden. Leuke fiets- en wandelroutes in de omgeving. Bezoekt u vooral ook een keer de heksenwaag in het nabije Oudewater",
                ParkingDescription = "Parking outside hotel",
                RouteDescription = "Vanuit Utrecht neemt u de snelweg richting Den Haag. Bij Woerden slaat u af richting Woerden centrum. U volgt de borden naar de McDonalds. Rechts naast de McDonalds bevindt zich ons hotel.",
            },
            new OldHotel
            {
                Id = 3,
                Code = "ELP",
                HotelGroupId = 1,
                LocationX = 51,
                LocationY = 4,
                CountryId = 1,
                Name = "East Lane Park Hotel",
                Description = "Het hotel ligt dicht bij de polders, waar u kunt genieten van een prachtig Nederlands landschap.",
                ImageLink1 = "images.sbit.enixe.com/hotel.jpg",
                ImageLink2 = "images.sbit.enixe.com/hotel.jpg",
                Phone = "+31348430222",
                Email = "info@sbit-woerden.nl",
                ReservationUrl = "s-bit.nl",
                Facilities = "Shop, Zwembad",
                Surroundings = "Gelegen in de bosrijke omgeving van Woerden. Leuke fiets- en wandelroutes in de omgeving. Bezoekt u vooral ook een keer de heksenwaag in het nabije Oudewater",
                ParkingDescription = "Parking outside hotel",
                RouteDescription = "Vanuit Utrecht neemt u de snelweg richting Den Haag. Bij Woerden slaat u af richting Woerden centrum. U volgt de borden naar de McDonalds. Rechts naast de McDonalds bevindt zich ons hotel.",
            }
        };

        static List<RoomType> roomTypes = new List<RoomType>
        {
            new RoomType
            {
                Id = 1,
                Name = "Standard Room"
            },
            new RoomType
            {
                Id = 2,
                Name = "Executive Room"
            },
            new RoomType
            {
                Id = 3,
                Name = "Single Room"
            }
        };

        static List<ServiceGroup> serviceGroups = new List<ServiceGroup>
        {
            new ServiceGroup
            {
                Id = 1,
                Name = "Room Service"
            },
            new ServiceGroup
            {
                Id = 2,
                Name = "Restaurant"
            },
            new ServiceGroup
            {
                Id = 3,
                Name = "Shop"
            },
            new ServiceGroup
            {
                Id = 4,
                Name = "Event"
            }
        };

        static List<OldService> oldServices = new List<OldService>
        {
            new OldService
            {
                Id = 1,
                Name = "Food"
            },
            new OldService
            {
                Id = 2,
                Name = "Drinks"
            },
            new OldService
            {
                Id = 3,
                Name = "Wake up Call"
            },
            new OldService
            {
                Id = 4,
                Name = "Laundry"
            }
        };

        static List<ServiceOption> serviceOptions = new List<ServiceOption>
        {
            new ServiceOption
            {
                Id = 1,
                Name = "Wake Up Call Date"            
            },
            new ServiceOption
            {
                Id = 2,
                Name = "Breakfast"
            },
            new ServiceOption
            {
                Id = 3,
                Name = "Breakfast Continental"
            },
        };

        static List<HotelShopService> hotelShopServices = new List<HotelShopService>
        {
            new HotelShopService
            {
                Id = 1,
                Name = "Clothing"
            },
            new HotelShopService
            {
                Id = 2,
                Name = "Jewels"
            },
            new HotelShopService
            {
                Id = 3,
                Name = "Souvenirs"
            },
        };

        static List<HotelShopServiceOption> hotelShopServiceOptions = new List<HotelShopServiceOption>
        {
            new HotelShopServiceOption
            {
                Id = 1,
                Name = "Quality Trousers"
            },
            new HotelShopServiceOption
            {
                Id = 2,
                Name = "Shirts - Various Colours"
            },
            new HotelShopServiceOption
            {
                Id = 3,
                Name = "Gold Bracelet"
            },
        };

        static List<HotelEventService> hotelEventServices = new List<HotelEventService>
        {
            new HotelEventService
            {
                Id = 1,
                Name = "Bar"
            },
            new HotelEventService
            {
                Id = 2,
                Name = "Children"
            },
            new HotelEventService
            {
                Id = 3,
                Name = "Other Events"
            },
        };

        static List<HotelEventServiceOption> hotelEventServiceOptions = new List<HotelEventServiceOption>
        {
            new HotelEventServiceOption
            {
                Id = 1,
                Name = "Tuesday Evening"
            },
            new HotelEventServiceOption
            {
                Id = 2,
                Name = "Karaoke"
            },
            new HotelEventServiceOption
            {
                Id = 3,
                Name = "Children"
            },
        };

        static List<RestaurantService> restaurantServices = new List<RestaurantService>
        {
            new RestaurantService
            {
                Id = 1,
                Name = "Menu Selection"
            },
            new RestaurantService
            {
                Id = 2,
                Name = "Wine Menu"
            },
        };

        static List<RestaurantServiceOption> restaurantServiceOptions = new List<RestaurantServiceOption>
        {
            new RestaurantServiceOption
            {
                Id = 1,
                Name = "Shrimp Cocktail"
            },
            new RestaurantServiceOption
            {
                Id = 2,
                Name = "Chicken Wings"
            },
            new RestaurantServiceOption
            {
                Id = 3,
                Name = "Tomato soup"
            },
        };

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            await Task.Delay(500);

            return cities;
        }

        public async Task<IEnumerable<Chat>> GetChatsAsync()
        {
            await Task.Delay(500);

            return chats;
        }
        public async Task<IEnumerable<Shop>> GetShopsAsync()
        {
            await Task.Delay(500);

            return shops;
        }

        public async Task<Models.Hotel> GetHotelByIdAsync(int id)
        {
            await Task.Delay(500);

            return hotels.FirstOrDefault(h => h.Id == id);
        }

        public async Task<IEnumerable<Models.Hotel>> GetMostVisitedAsync()
        {
            await Task.Delay(500);

            return hotels;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int id)
        {
            await Task.Delay(500);

            return reviews.Where(r => r.HotelId == id).ToObservableRangeCollection();
        }

        public async Task<IEnumerable<Models.Hotel>> SearchAsync(int cityId)
        {
            await Task.Delay(500);

            return hotels
                .Where(h => h.CityId == cityId);
        }

        public async Task<IEnumerable<Models.Hotel>> SearchAsync(int cityId, int rating, int minPrice, int maxPrice)
        {
            await Task.Delay(500);

            return hotels
                .Where(h => h.CityId == cityId && h.Rating == rating && h.PricePerNight >= minPrice && h.PricePerNight < maxPrice)
                .ToObservableRangeCollection();
        }

        public async Task<IEnumerable<Service>> GetHotelServicesAsync()
        {
            await Task.Delay(500);

            return hotelServices;
        }

        public async Task<IEnumerable<Service>> GetRoomServicesAsync()
        {
            await Task.Delay(500);

            return roomServices;
        }

        public async Task<IEnumerable<OldHotel>> GetOldHotelsAsync()
        {
            await Task.Delay(500);

            return oldHotels;
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypesAsync()
        {
            await Task.Delay(500);

            return roomTypes;
        }

        public async Task<IEnumerable<ServiceGroup>> GetServiceGroupsAsync()
        {
            await Task.Delay(500);

            return serviceGroups;
        }

        public async Task<IEnumerable<OldService>> GetOldServicesAsync()
        {
            await Task.Delay(500);

            return oldServices;
        }

        public async Task<IEnumerable<ServiceOption>> GetServiceOptionsAsync()
        {
            await Task.Delay(500);

            return serviceOptions;
        }

        public async Task<IEnumerable<HotelShopService>> GetHotelShopServicesAsync()
        {
            await Task.Delay(500);

            return hotelShopServices;
        }

        public async Task<IEnumerable<HotelShopServiceOption>> GetHotelShopServiceOptionsAsync()
        {
            await Task.Delay(500);

            return hotelShopServiceOptions;
        }

        public async Task<IEnumerable<HotelEventService>> GetHotelEventServicesAsync()
        {
            await Task.Delay(500);

            return hotelEventServices;
        }

        public async Task<IEnumerable<HotelEventServiceOption>> GetHotelEventServiceOptionsAsync()
        {
            await Task.Delay(500);

            return hotelEventServiceOptions;
        }

        public async Task<IEnumerable<RestaurantService>> GetRestaurantServicesAsync()
        {
            await Task.Delay(500);

            return restaurantServices;
        }

        public async Task<IEnumerable<RestaurantServiceOption>> GetRestaurantServiceOptionsAsync()
        {
            await Task.Delay(500);
            
            return restaurantServiceOptions;
        }
    }
}
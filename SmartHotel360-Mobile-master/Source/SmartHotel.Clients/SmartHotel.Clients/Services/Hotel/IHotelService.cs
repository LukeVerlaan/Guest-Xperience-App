using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Hotel
{
    public interface IHotelService
    {
        Task<IEnumerable<Models.City>> GetCitiesAsync();

        Task<IEnumerable<Models.Chat>> GetChatsAsync();

        Task<IEnumerable<Models.Shop>> GetShopsAsync();

        Task<IEnumerable<Models.Hotel>> SearchAsync(int cityId);

        Task<IEnumerable<Models.Hotel>> SearchAsync(int cityId, int rating, int minPrice, int maxPrice);

        Task<IEnumerable<Models.Hotel>> GetMostVisitedAsync();

        Task<Models.Hotel> GetHotelByIdAsync(int id);

        Task<IEnumerable<Models.Review>> GetReviewsAsync(int id);

        Task<IEnumerable<Models.Service>> GetHotelServicesAsync();

        Task<IEnumerable<Models.Service>> GetRoomServicesAsync();

        Task<IEnumerable<Models.OldHotel>> GetOldHotelsAsync();

        Task<IEnumerable<Models.RoomType>> GetRoomTypesAsync();

        Task<IEnumerable<Models.ServiceGroup>> GetServiceGroupsAsync();

        Task<IEnumerable<Models.OldService>> GetOldServicesAsync();

        Task<IEnumerable<Models.ServiceOption>> GetServiceOptionsAsync();

        Task<IEnumerable<Models.HotelShopService>> GetHotelShopServicesAsync();

        Task<IEnumerable<Models.HotelShopServiceOption>> GetHotelShopServiceOptionsAsync();

        Task<IEnumerable<Models.HotelEventService>> GetHotelEventServicesAsync();

        Task<IEnumerable<Models.HotelEventServiceOption>> GetHotelEventServiceOptionsAsync();

        Task<IEnumerable<Models.RestaurantService>> GetRestaurantServicesAsync();

        Task<IEnumerable<Models.RestaurantServiceOption>> GetRestaurantServiceOptionsAsync();
    }
}
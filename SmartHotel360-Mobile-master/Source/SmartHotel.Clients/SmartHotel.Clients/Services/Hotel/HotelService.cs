using SmartHotel.Clients.Core.Extensions;
using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Services.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Hotel
{
    public class HotelService : IHotelService
    {
        readonly IRequestService requestService;

        public HotelService(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public Task<string> PostLoginAsync(string roomNumber, string lastName)
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("guest/Authenticate");

            var uri = builder.ToString();

            return requestService.PostAsync<string>(uri, roomNumber, lastName);
        }

        public Task<string> PostChatAsync(string roomNumber, string lastName)
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("guest/Authenticate");

            var uri = builder.ToString();

            return requestService.PostAsync<string>(uri, roomNumber, lastName);
        }

        public Task<IEnumerable<City>> GetCitiesAsync()
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("cities");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<City>>(uri);
        }

        public Task<IEnumerable<Chat>> GetChatsAsync()
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("chats");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Chat>>(uri);
        }

        public Task<IEnumerable<Shop>> GetShopsAsync()
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("shop");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Shop>>(uri);
        }

        public Task<IEnumerable<Models.Hotel>> SearchAsync(int cityId)
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("Hotels/search");
            builder.Query = $"cityId={cityId}";

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Models.Hotel>>(uri);
        }

        public Task<IEnumerable<Models.Hotel>> SearchAsync(int cityId, int rating, int minPrice, int maxPrice)
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("Hotels/search");
            builder.Query = $"cityId={cityId}&rating={rating}&minPrice={minPrice}&maxPrice={maxPrice}";

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Models.Hotel>>(uri);
        }

        public Task<IEnumerable<Models.Hotel>> GetMostVisitedAsync()
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("Hotels/mostVisited");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Models.Hotel>>(uri);
        }

        public Task<Models.Hotel> GetHotelByIdAsync(int id)
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath($"Hotels/{id}");

            var uri = builder.ToString();

            return requestService.GetAsync<Models.Hotel>(uri);
        }

        public Task<IEnumerable<Review>> GetReviewsAsync(int id)
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath($"Reviews/{id}");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Review>>(uri);
        }

        public Task<IEnumerable<Service>> GetHotelServicesAsync()
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("Services/hotel");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Service>>(uri);
        }

        public Task<IEnumerable<Service>> GetRoomServicesAsync()
        {
            var builder = new UriBuilder(AppSettings.HotelsEndpoint);
            builder.AppendToPath("Services/room");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<Service>>(uri);
        }

        public Task<IEnumerable<OldHotel>> GetOldHotelsAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("hotel");
            
            var uri = builder.ToString();
            
            return requestService.GetAsync<IEnumerable<OldHotel>>(uri);
        }

        public Task<IEnumerable<RoomType>> GetRoomTypesAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("roomtype");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<RoomType>>(uri);
        }

        public Task<IEnumerable<ServiceGroup>> GetServiceGroupsAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("servicegroup");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<ServiceGroup>>(uri);
        }

        public Task<IEnumerable<OldService>> GetOldServicesAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("service");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<OldService>>(uri);
        }

        public Task<IEnumerable<ServiceOption>> GetServiceOptionsAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("serviceoption");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<ServiceOption>>(uri);
        }

        public Task<IEnumerable<HotelShopService>> GetHotelShopServicesAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("hotelshopservice");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<HotelShopService>>(uri);
        }

        public Task<IEnumerable<HotelShopServiceOption>> GetHotelShopServiceOptionsAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("hotelshopserviceoption");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<HotelShopServiceOption>>(uri);
        }

        public Task<IEnumerable<HotelEventService>> GetHotelEventServicesAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("hoteleventservice");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<HotelEventService>>(uri);
        }

        public Task<IEnumerable<HotelEventServiceOption>> GetHotelEventServiceOptionsAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("hoteleventserviceoption");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<HotelEventServiceOption>>(uri);
        }

        public Task<IEnumerable<RestaurantService>> GetRestaurantServicesAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("restaurantservice");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<RestaurantService>>(uri);
        }

        public Task<IEnumerable<RestaurantServiceOption>> GetRestaurantServiceOptionsAsync()
        {
            var builder = new UriBuilder(AppSettings.OldHotelsEndpoint);
            builder.AppendToPath("restaurantserviceoption");

            var uri = builder.ToString();

            return requestService.GetAsync<IEnumerable<RestaurantServiceOption>>(uri);
        }
    }
}
using SmartHotel.Clients.Core.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Database
{
    public interface IDatabaseService
    {
        Task<List<OrderItemModel>> GetOrderItemsAsync(int id);
        Task<int> SaveOrderItemAsync(OrderItemModel item);
        Task<int> CreateShopOrder();
        Task<List<ShopOrderModel>> GetShopOrdersAsync();
        Task<ShopOrderModel> GetShopOrderAsync(int id);
        Task<int> SaveShopOrderAsync(ShopOrderModel order);
        Task<int> DeleteShopOrderAsync(ShopOrderModel order);
        Task UpdateShopOrderAsync(ShopOrderModel order, OrderItemModel item);
    }
}

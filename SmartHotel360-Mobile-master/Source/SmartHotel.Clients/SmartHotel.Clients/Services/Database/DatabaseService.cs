using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.Repository;
using SmartHotel.Clients.Core.Services.Authentication;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SmartHotel.Clients.Core.Services.Database
{
    public class DatabaseService : IDatabaseService
    {
        readonly SQLiteAsyncConnection _database;
        readonly IAuthenticationService authenticationService;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopOrderModel>().Wait();
            _database.CreateTableAsync<OrderItemModel>().Wait();
            //_database.DeleteAllAsync<ShopOrderModel>().Wait();
            //_database.DeleteAllAsync<OrderItemModel>().Wait();
        }


        public Task<List<OrderItemModel>> GetOrderItemsAsync(int id)
        {
            return _database.Table<OrderItemModel>()
                            .Where(i => i.OrderId == id)
                            .ToListAsync();
                            //.FirstOrDefaultAsync();
            //return _database.Table<OrderItemModel>().ToListAsync();
        }
        public Task<int> SaveOrderItemAsync(OrderItemModel item)
        {
            return _database.InsertAsync(item);
        }

        public Task<int> CreateShopOrder()
        {
            //var authenticatedUser = authenticationService.AuthenticatedUser;
            //ShopOrderModel order = new ShopOrderModel { UserId = Convert.ToInt32(authenticatedUser.Id), HotelId = 1 };
            ShopOrderModel order = new ShopOrderModel { UserId = 1, HotelId = 1 };
            return _database.InsertAsync(order);
        }

        public Task<List<ShopOrderModel>> GetShopOrdersAsync()
        {
            return _database.Table<ShopOrderModel>().ToListAsync();
        }

        public Task<ShopOrderModel> GetShopOrderAsync(int id)
        {
            return _database.Table<ShopOrderModel>()
                            .Where(i => i.OrderId == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveShopOrderAsync(ShopOrderModel order)
        {
            return _database.InsertAsync(order);
        }

        public Task<int> DeleteShopOrderAsync(ShopOrderModel order)
        {
            return _database.DeleteAsync(order);
        }

        public Task UpdateShopOrderAsync(ShopOrderModel order, OrderItemModel item)
        {
            order.Items.Add(item);
            return _database.UpdateWithChildrenAsync(order);
        }
    }
}

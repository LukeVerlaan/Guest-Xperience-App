using Microsoft.EntityFrameworkCore;
using SmartHotel.Services.Hotels.Data;
using SmartHotel.Services.Hotels.Domain.Hotel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Queries
{
    public class ShopResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShopType { get; set; }
        public List<ShopItem> Items { get; set; }
    }

    public class ShopsQuery
    {
        private readonly HotelsDbContext _db;

        public ShopsQuery(HotelsDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ShopResult>> Get(string name = "", int take = 5)
        {
            return await _db
                .Shops
                .Where(shop => shop.Name.StartsWith(name))
                .Take(take)
                .Select(shop => new ShopResult
                {
                    Id = shop.Id,
                    Name = shop.Name,
                    ShopType = shop.ShopType,
                    Items = shop.Items

                })
                .ToListAsync();
        }

        public Task<IEnumerable<ShopResult>> GetDefaultShops()
        {
            return Task.FromResult(new[]
            {
                new ShopResult() { Id = 1, Name = "Jewelz", ShopType = "Jewels", Items = new List<ShopItem>{ new ShopItem(){ Id = 1, ShopId = 1, Name = "Bracelet", Description = "Gold Bracelet", Price=299.99m, Rating = 4, Sizes= new List<Size> { new Size{ Name = "s" }, new Size { Name="m" }, new Size { Name = "l" } } }, new ShopItem(){ Id = 2, ShopId = 1, Name = "Necklace", Description = "Gold Necklace", Price=499.99m, Rating = 5, Sizes = new List<Size> { new Size { Name = "s" }, new Size { Name = "m" }, new Size { Name = "l" } } } } },
                new ShopResult() { Id = 2, Name = "Clothes", ShopType = "Clothing", Items  = new List<ShopItem>{ new ShopItem() { Id = 1, ShopId = 2, Name = "Shirt", Description = "Red Shirt", Price = 49.99m, Rating = 3, Sizes = new List<Size> { new Size { Name = "xs" }, new Size { Name = "s" }, new Size { Name = "m" }, new Size { Name = "l" }, new Size { Name = "xl" } } }, new ShopItem() { Id = 2, ShopId = 2, Name = "Jeans", Description = "Black Jeans", Price = 79.99m, Rating = 3, Sizes = new List<Size> { new Size { Name = "xs" }, new Size { Name = "s" }, new Size { Name = "m" }, new Size { Name = "l" }, new Size { Name = "xl" } } } }},
                new ShopResult() { Id = 3,  Name = "Souvenir", ShopType = "Souvenirs", Items = new List<ShopItem>{ new ShopItem() { Id = 1, ShopId = 3, Name = "Magnet", Description = "Magnet with city name", Price = 49.99m, Rating = 5 }, new ShopItem() { Id = 2, ShopId = 3, Name = "Figurine", Description = "Stone figurine of a man", Price = 49.99m, Rating = 4 } }}

            } as IEnumerable<ShopResult>);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SmartHotel.Services.Hotels.Data;
using SmartHotel.Services.Hotels.Domain.Hotel;
using System;
using System.Collections.Generic;
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
                new ShopResult() { Id = 1, Name = "Jewelz", ShopType = "Jewels", Items = new List<ShopItem>{ new ShopItem(){ Id = 1, ShopId = 1, Name = "Bracelet", Description = "Gold Bracelet" }, new ShopItem(){ Id = 2, ShopId = 1, Name = "Necklace", Description = "Gold Necklace" } } },
                new ShopResult() { Id = 2, Name = "Clothes", ShopType = "Clothing", Items  = new List<ShopItem>{ new ShopItem() { Id = 1, ShopId = 2, Name = "Shirt", Description = "Red Shirt" }, new ShopItem() { Id = 2, ShopId = 2, Name = "Jeans", Description = "Black Jeans" } }},
                new ShopResult() { Id = 3,  Name = "Souvenir", ShopType = "Souvenirs", Items = new List<ShopItem>{ new ShopItem() { Id = 1, ShopId = 3, Name = "Magnet", Description = "Magnet with city name" }, new ShopItem() { Id = 2, ShopId = 3, Name = "Figurine", Description = "Stone figurine of a man" } }}

            } as IEnumerable<ShopResult>);
        }
    }
}

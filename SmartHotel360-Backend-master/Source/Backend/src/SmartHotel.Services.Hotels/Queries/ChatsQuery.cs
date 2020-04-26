using Microsoft.EntityFrameworkCore;
using SmartHotel.Services.Hotels.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Queries
{
    public class ChatResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ChatsQuery
    {
        private readonly HotelsDbContext _db;

        public ChatsQuery(HotelsDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ChatResult>> Get(string name = "", int take = 5)
        {
            return await _db
                .Chats
                .Where(chat => chat.Name.StartsWith(name))
                .Take(take)
                .Select(chat => new ChatResult
                {
                    Id = chat.Id,
                    Name = chat.Name
                })
                .ToListAsync();
        }

        public Task<IEnumerable<ChatResult>> GetDefaultCities()
        {
            return Task.FromResult(new[]
            {
                new ChatResult() { Id = 1, Name = "Reception Chat"},
                new ChatResult() { Id = 2, Name = "Bar Chat"},
                new ChatResult() { Id = 3,  Name = "Event Chat"}

            } as IEnumerable<ChatResult>);
        }
    }
}

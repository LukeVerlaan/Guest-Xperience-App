using Microsoft.EntityFrameworkCore;
using SmartHotel.Services.Hotels.Data;
using SmartHotel.Services.Hotels.Domain.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Queries
{
    public class ChatResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Message> Messages { get; set; }
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
                    Name = chat.Name,
                    Messages = chat.Messages
                })
                .ToListAsync();
        }

        public Task<IEnumerable<ChatResult>> GetDefaultChats()
        {
            return Task.FromResult(new[]
            {
                new ChatResult() { Id = 1, Name = "Reception Chat", Messages = new List<Message>{ new Message(){ Text = "Hi", User = "ChatBot", SendTime = DateTime.Now  }, new Message(){ Text = "How are you?", User = "ChatBot", SendTime = DateTime.Now } } },
                new ChatResult() { Id = 2, Name = "Bar Chat", Messages = new List<Message>{ new Message(){ Text = "Hi", User = "Kevin Bos", SendTime = DateTime.Now  }, new Message(){ Text = "Hey", User = "Jordy Schepers", SendTime = DateTime.Now }}},
                new ChatResult() { Id = 3,  Name = "Event Chat", Messages = new List<Message>{ new Message(){ Text = "Nice Event", User = "Kevin Bos", SendTime = DateTime.Now  }, new Message(){ Text = "Yes", User = "Jordy Schepers", SendTime = DateTime.Now }}}

            } as IEnumerable<ChatResult>);
        }
    }
}

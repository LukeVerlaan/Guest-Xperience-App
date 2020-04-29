using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHotel.Services.Hotels.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Controllers
{
    [Route("[controller]")]
    public class ChatsController : Controller
    {
        private readonly ChatsQuery _chatsQueries;
        private readonly ILogger _logger;

        public ChatsController(ChatsQuery chatsQueries, ILogger<ChatsController> logger)
        {
            _chatsQueries = chatsQueries;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string name = "")
        {
            var chats = string.IsNullOrEmpty(name) ?
                await _chatsQueries.GetDefaultChats() :
                await _chatsQueries.Get(name);

            if (chats.Count() == 0)
                _logger.LogWarning("Chat search {0} returned 0 results.", name);

            return Ok(chats);
        }
    }
}

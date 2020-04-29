using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHotel.Services.Hotels.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel.Services.Hotels.Controllers
{
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly ShopsQuery _shopsQueries;
        private readonly ILogger _logger;

        public ShopController(ShopsQuery shopsQueries, ILogger<ShopController> logger)
        {
            _shopsQueries = shopsQueries;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string name = "")
        {
            var shops = string.IsNullOrEmpty(name) ?
                await _shopsQueries.GetDefaultShops() :
                await _shopsQueries.Get(name);

            if (shops.Count() == 0)
                _logger.LogWarning("Shop search {0} returned 0 results.", name);

            return Ok(shops);
        }
    }
}

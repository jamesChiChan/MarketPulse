using MarketPulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPulse.Controllers
{
    class GlobalPricesControl
    {
        public async Task<List<GlobalPricesInfo>> GetGlobalPrices()
        {
            return await GlobalPricesFetcher.GetGlobalPricesAsync();
        }
    }
}

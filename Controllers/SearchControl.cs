using MarketPulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPulse.Controllers
{
    public class SearchControl
    {
        public async Task<List<SearchInfo>> SearchStocks(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return new List<SearchInfo>();

            return await StockInfo.GetStockList(keyword);
        }
    }
}

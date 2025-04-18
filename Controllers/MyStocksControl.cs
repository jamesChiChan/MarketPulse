using MarketPulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace MarketPulse.Controllers
{
    internal class MyStocksControl
    {
        public async Task<List<MyStocksInfo>> FetchStockData(List<string> symbol)
        {
            return await MyStocksInfo.GetStockPrices(symbol);
        }

        public async Task<List<MyStocksInfo>> FetchStockDataByYahoo(string filePath)
        {
            List<string> symbols = MyStocksInfo.ReadSymbolsFromFile(filePath);
            return await MyStocksInfo.GetStockPricesByYahoo(symbols);
        }
    }
}
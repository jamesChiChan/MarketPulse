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
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<List<MyStocksInfo>> GetStockPrices(List<string> stockSymbols)
        {
            List<MyStocksInfo> stockList = new List<MyStocksInfo>();

            foreach (var symbol in stockSymbols)
            {
                string url = $"https://tw.stock.yahoo.com/quote/{symbol}";

                try
                {
                    string html = await _httpClient.GetStringAsync(url);

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    // 股票名稱 (通常在 <h1> 標籤內)
                    var nameNode = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'C($c-link-text) Fw(b)')]");
                    string stockName = nameNode?.InnerText?.Trim() ?? "未知";

                    // 股票價格 (通常在 <span> 並且有特定 class)
                    var priceNode = doc.DocumentNode.SelectSingleNode("//span[contains(@class, 'Fz(32px) Fw(b) Lh(1) Mend(16px)')]");
                    decimal stockPrice = priceNode != null ? decimal.Parse(priceNode.InnerText) : 0;

                    // 漲跌幅 (通常在 <span> 有特定 class)
                    var changeNode = doc.DocumentNode.SelectSingleNode("//span[contains(@class, 'Fz(20px) Fw(b) Lh(1.2) Mend(4px)')]");
                    double stockChange = changeNode != null ? double.Parse(changeNode.InnerText) : 0;

                    // 建立物件並加入清單
                    stockList.Add(new MyStocksInfo
                    {
                        StockName = stockName,
                        Price = stockPrice,
                        Change = stockChange
                    });

                    Console.WriteLine($"成功抓取 {stockName}: {stockPrice} ({stockChange})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ 無法抓取 {symbol}: {ex.Message}");
                }
            }

            return stockList;
        }
    }
}

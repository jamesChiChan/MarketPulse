using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace MarketPulse.Models
{
    internal class MyStocksInfo
    {
        public string StockSymbol { get; set; }
        public decimal Price { get; set; }
        public double Change { get; set; }
        public long Volume { get; set; }
        public double Open { get; set; }
        public string TradeTime { get; set; }

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
                        StockSymbol = stockName,
                        Price = stockPrice,
                        Change = stockChange
                    });

                    Console.WriteLine($"成功抓取 {stockName}: {stockPrice} ({stockChange})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"無法抓取 {symbol}: {ex.Message}");
                }
            }

            return stockList;
        }

        public static async Task<List<MyStocksInfo>> GetStockPricesByYahoo(List<string> stockSymbols)
        {
            List<MyStocksInfo> stockList = new List<MyStocksInfo>();

            try
            {
                var securities = await Yahoo.Symbols(stockSymbols.ToArray()).Fields(
                    Field.ShortName,
                    Field.RegularMarketPrice,
                    Field.RegularMarketChange,
                    Field.RegularMarketVolume,
                    Field.RegularMarketOpen,
                    Field.RegularMarketTime)
                .QueryAsync();

                foreach (var symbol in stockSymbols)
                {
                    var stock = securities[symbol];
                    stockList.Add(new MyStocksInfo
                    {
                        StockSymbol = symbol,
                        Price = Convert.ToDecimal(stock[Field.RegularMarketPrice]),
                        Change = Math.Round(Convert.ToDouble(stock[Field.RegularMarketChange]), 2),
                        Volume = Convert.ToInt64(stock[Field.RegularMarketVolume]),
                        Open = Convert.ToDouble(stock[Field.RegularMarketOpen]),
                        TradeTime = DateTimeOffset.FromUnixTimeSeconds(stock[Field.RegularMarketTime]).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
                    });

                    //Console.WriteLine($"{symbol}: {stock[Field.RegularMarketPrice]} ({stock[Field.RegularMarketChange]})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("無法獲取股票數據：" + ex.Message);
            }

            return stockList;
        }

        public static List<string> ReadSymbolsFromFile(string filePath)
        {
            var stockSymbols = new List<string>();

            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var trimmed = line.Trim();
                        if (!string.IsNullOrEmpty(trimmed))
                            stockSymbols.Add(trimmed);
                    }
                }
                else
                {
                    Console.WriteLine($"找不到檔案：{filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("讀取股票清單失敗：" + ex.Message);
            }

            return stockSymbols;
        }
    }
}
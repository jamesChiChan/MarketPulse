using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace MarketPulse.Models
{
    public class SearchInfo
    {
        public string Symbol { get; set; }    // 股票代號
        public string Name { get; set; }      // 股票名稱
        public double Price { get; set; }     // 最新成交價
        public double Change { get; set; }    // 漲跌
        public long Volume { get; set; }      // 交易量
        public double Open { get; set; }      // 開盤價
        public string TradeTime { get; set; } // 最新交易時間

        private static readonly HttpClient client = new HttpClient();

        // 因需要授權所以此方法無法執行
        public static async Task<List<SearchInfo>> SearchStocksAsync(string keyword)
        {
            string url = $"https://query1.finance.yahoo.com/v1/finance/search?q={keyword}";
            List<SearchInfo> stockList = new List<SearchInfo>();

            try
            {
                string json = await client.GetStringAsync(url);
                dynamic data = JsonConvert.DeserializeObject(json);

                if (data?.quotes != null)
                {
                    foreach (var stock in data.quotes)
                    {
                        string symbol = stock.symbol;
                        SearchInfo stockData = await GetStockDataAsync(symbol);
                        if (stockData != null)
                        {
                            stockData.Name = stock.shortname;
                            stockList.Add(stockData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"錯誤: {ex.Message}");
            }

            return stockList;
        }

        // 查詢 Yahoo Finance API 取得即時股價
        public static async Task<SearchInfo> GetStockDataAsync(string symbol)
        {
            string url = $"https://query1.finance.yahoo.com/v7/finance/quote?symbols={symbol}";

            try
            {
                string json = await client.GetStringAsync(url);
                dynamic data = JsonConvert.DeserializeObject(json);

                if (data?.quoteResponse?.result != null && data.quoteResponse.result.Count > 0)
                {
                    var stock = data.quoteResponse.result[0];
                    return new SearchInfo
                    {
                        Symbol = stock.symbol,
                        Price = stock.regularMarketPrice ?? 0,
                        Change = stock.regularMarketChange ?? 0,
                        Volume = stock.regularMarketVolume ?? 0,
                        Open = stock.regularMarketOpen ?? 0,
                        TradeTime = stock.regularMarketTime != null
                            ? DateTimeOffset.FromUnixTimeSeconds((long)stock.regularMarketTime).ToString("yyyy-MM-dd HH:mm:ss")
                            : "N/A"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"錯誤: {ex.Message}");
            }

            return null;
        }


    }

    public class StockInfo
    {
        public string Code { get; set; }  // 股票代號
        public string Name { get; set; }  // 股票名稱

        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<SearchInfo>> GetStockList(string keyword)
        {
            //List<StockInfo> stocks = await GetAllStockList();
            List<StockInfo> allStocks = await GetAllStockList();
            var matchedStocks = allStocks.Where(s => s.Code.Contains(keyword) || s.Name.Contains(keyword)).ToList();

            if (matchedStocks.Count == 0)
            {
                Console.WriteLine("未找到符合的股票");
                return new List<SearchInfo>();
            }

            // 取得匹配的股票代號
            List<string> stockSymbols = matchedStocks.Select(s => s.Code + ".TW").ToList();

            // 取得 Yahoo Finance 的股價數據
            List<SearchInfo> stockData = await GetStockData(stockSymbols);

            foreach (var stock in stockData)
            {
                var match = allStocks.FirstOrDefault(s => s.Code == stock.Symbol.Replace(".TW", ""));
                stock.Name = match != null ? match.Name : "未知股票"; // 如果沒有對應名稱，預設為 "未知股票"
            }

            return stockData;
        }

        // 取得所有上市股票
        public static async Task<List<StockInfo>> GetAllStockList()
        {
            string url = "https://openapi.twse.com.tw/v1/exchangeReport/STOCK_DAY_ALL";
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<StockInfo>>(json) ?? new List<StockInfo>();
        }

        // 用 YahooFinanceApi 查詢股價
        public static async Task<List<SearchInfo>> GetStockData(List<string> stockSymbols)
        {
            List<SearchInfo> stockList = new List<SearchInfo>();
            try
            {
                var securities = await Yahoo.Symbols(stockSymbols.ToArray()).Fields(
                    Field.Symbol,
                    Field.RegularMarketPrice,
                    Field.RegularMarketChange,
                    Field.RegularMarketVolume,
                    Field.RegularMarketOpen,
                    Field.RegularMarketTime
                ).QueryAsync();

                foreach (var symbol in stockSymbols)
                {
                    var stock = securities[symbol];
                    stockList.Add(new SearchInfo
                    {
                        Symbol = symbol,
                        Price = Convert.ToDouble(stock[Field.RegularMarketPrice]),
                        Change = Math.Round(Convert.ToDouble(stock[Field.RegularMarketChange]), 2),
                        Volume = Convert.ToInt64(stock[Field.RegularMarketVolume]),
                        Open = Convert.ToDouble(stock[Field.RegularMarketOpen]),
                        TradeTime = DateTimeOffset.FromUnixTimeSeconds(stock[Field.RegularMarketTime]).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"錯誤: {ex.Message}");
            }

            return stockList;
        }
    }
}

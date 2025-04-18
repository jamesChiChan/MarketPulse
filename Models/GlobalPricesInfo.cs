using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace MarketPulse.Models
{
    public class GlobalPricesInfo
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public decimal Volume { get; set; }
        public string LastUpdated { get; set; }
    }

    public class GlobalPricesFetcher
    {
        public static async Task<List<GlobalPricesInfo>> GetGlobalPricesAsync()
        {
            //var symbols = new[] { "GC=F", "CL=F", "SI=F", "NG=F", "ZC=F", "KC=F" };
            var symbols = new[] {
                "GC=F", "SI=F", "HG=F", "PL=F", "PA=F",   // 金屬
                "CL=F", "BZ=F", "NG=F", "HO=F", "RB=F",   // 能源
                "ZC=F", "ZW=F", "ZS=F", "ZO=F", "ZM=F", "ZL=F", // 穀物
                "KC=F", "SB=F", "CC=F", "OJ=F", "CT=F",   // 軟性商品
                "LE=F", "HE=F", "GF=F"                   // 家畜類
            };

            var result = await Yahoo
                .Symbols(symbols)
                .Fields(Field.RegularMarketPrice,
                        Field.RegularMarketChange,
                        Field.ShortName,
                        Field.RegularMarketChangePercent,
                        Field.RegularMarketTime,
                        Field.RegularMarketVolume
                        )
                .QueryAsync();

            //var commodityMap = new Dictionary<string, string>
            //{
            //    { "GC=F", "黃金" },
            //    { "CL=F", "原油(WTI)" },
            //    { "SI=F", "白銀" },
            //    { "NG=F", "天然氣" },
            //    { "ZC=F", "玉米" },
            //    { "KC=F", "咖啡" }
            //};
            var commodityMap = new Dictionary<string, string>
            {
                { "GC=F", "黃金" }, { "SI=F", "白銀" }, { "HG=F", "銅" }, { "PL=F", "鉑金" }, { "PA=F", "鈀金" },
                { "CL=F", "原油" }, { "BZ=F", "原油" }, { "NG=F", "天然氣" }, { "HO=F", "燃油" }, { "RB=F", "汽油" },
                { "ZC=F", "玉米" }, { "ZW=F", "小麥" }, { "ZS=F", "黃豆" }, { "ZO=F", "燕麥" }, { "ZM=F", "黃豆粉" }, { "ZL=F", "黃豆油" },
                { "KC=F", "咖啡" }, { "SB=F", "糖" }, { "CC=F", "可可" }, { "OJ=F", "橙汁" }, { "CT=F", "棉花" },
                { "LE=F", "活牛" }, { "HE=F", "活豬" }, { "GF=F", "牛肉" }
            };

            var globalPrices = new List<GlobalPricesInfo>();

            foreach (var symbol in symbols)
            {
                var security = result[symbol];

                globalPrices.Add(new GlobalPricesInfo
                {
                    Symbol = symbol,
                    Name = commodityMap[symbol],
                    Price = Convert.ToDouble(security[Field.RegularMarketPrice]),
                    Change = Math.Round(Convert.ToDouble(security[Field.RegularMarketChange]), 2),
                    ChangePercent = Math.Round(Convert.ToDouble(security[Field.RegularMarketChangePercent]), 2),
                    LastUpdated = DateTimeOffset.FromUnixTimeSeconds(security[Field.RegularMarketTime]).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
                    Volume = Convert.ToDecimal(security[Field.RegularMarketVolume])
                });
            }

            return globalPrices;
        }
    }
}

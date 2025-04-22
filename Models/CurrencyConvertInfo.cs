using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MarketPulse.Models
{
    class CurrencyConvertInfo
    {
        public string CurrencyCode { get; set; }      // 幣別代碼
        public string CurrencyName { get; set; }      // 幣別名稱
        public string CashBuy { get; set; }           // 現金買入
        public string CashSell { get; set; }          // 現金賣出
        public string SpotBuy { get; set; }           // 即期買入
        public string SpotSell { get; set; }          // 即期賣出

        private static readonly HttpClient _client = new HttpClient();

        public async Task<(List<CurrencyConvertInfo>, string)> GetRatesFromWeb()
        {
            var url = "https://rate.bot.com.tw/xrt";
            var list = new List<CurrencyConvertInfo>();
            string updateTime = "";

            try
            {
                string html = await _client.GetStringAsync(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                // 更新時間
                var timeNode = doc.DocumentNode.SelectSingleNode("//span[@class='time']");
                updateTime = timeNode?.InnerText?.Trim() ?? "未知";

                // 找所有幣別的表格列
                var rows = doc.DocumentNode.SelectNodes("//table[@title='牌告匯率']/tbody/tr");

                foreach (var row in rows)
                {
                    var currencyName = row.SelectSingleNode(".//div[contains(@class,'visible-phone')]")?.InnerText?.Trim();
                    var tds = row.SelectNodes(".//td");

                    if (tds != null && tds.Count >= 9)
                    {
                        string code = currencyName?.Split('(')[1].Trim(')'); // 取 USD
                        list.Add(new CurrencyConvertInfo
                        {
                            CurrencyName = currencyName?.Split('(')[0].Trim(), // 取 美元
                            CurrencyCode = code,
                            CashBuy = tds[1].InnerText.Trim(),
                            CashSell = tds[2].InnerText.Trim(),
                            SpotBuy = tds[3].InnerText.Trim(),
                            SpotSell = tds[4].InnerText.Trim()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string error = $"Error：{ex.Message}";
                updateTime = "無法取得更新時間";
            }

            return (list, updateTime);
        }
    }
}

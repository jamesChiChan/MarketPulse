using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using MarketPulse.Models;

namespace MarketPulse.Controllers
{
    class CurrencyConvertControl
    {
        private readonly CurrencyConvertInfo _repository = new CurrencyConvertInfo();
        public List<CurrencyConvertInfo> AllRates { get; private set; } = new List<CurrencyConvertInfo>();
        public string LastUpdateTime { get; private set; } = "";

        public async Task LoadRatesAsync()
        {
            (AllRates, LastUpdateTime) = await _repository.GetRatesFromWeb();
        }

        public double Convert(string from, string to, double amount)
        {
            if (from == to) return amount;

            var fromRate = AllRates.FirstOrDefault(x => x.CurrencyCode == from);
            var toRate = AllRates.FirstOrDefault(x => x.CurrencyCode == to);

            if (fromRate == null || toRate == null) return 0;

            if (!double.TryParse(fromRate.SpotSell, out double fromSell) ||
                !double.TryParse(toRate.SpotBuy, out double toBuy) ||
                fromSell <= 0 || toBuy <= 0)
            {
                return 0;
            }

            double toTWD = amount * fromSell;
            double toTarget = toTWD / toBuy;

            return toTarget;
        }
    }
}

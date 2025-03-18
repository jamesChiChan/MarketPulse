using MarketPulse.Controllers;
using MarketPulse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketPulse.View
{
    public partial class MyStocksForm : Form
    {
        public MyStocksForm()
        {
            InitializeComponent();
        }

        private async void MyStocksForm_Load(object sender, EventArgs e)
        {
            List<string> stockSymbols = new List<string> { "2330.TW", "0050.TW", "2412.TW", "2610.TW" };
            List<MyStocksInfo> stocks = await MyStocksControl.GetStockPrices(stockSymbols);

            // 將資料綁定到 StockDataGrid
            stockDataGrid.DataSource = stocks;
            stockDataGrid.Columns[0].HeaderText = "股票名稱";
            stockDataGrid.Columns[1].HeaderText = "價格";
            stockDataGrid.Columns[2].HeaderText = "漲跌";
        }
    }
}

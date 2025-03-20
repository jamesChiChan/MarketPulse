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
        private readonly MyStocksControl _controller = new MyStocksControl();

        public MyStocksForm()
        {
            InitializeComponent();
        }

        private void MyStocksForm_Load(object sender, EventArgs e)
        {
            buttonUpdate_Click(sender, e);
        }

        // CellFormatting 方法
        private void StockDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null) // 第三行 (漲跌)
            {
                if (double.TryParse(e.Value.ToString(), out double changeValue))
                {
                    if (changeValue > 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;   // 上漲 (紅色)
                        //e.CellStyle.BackColor = Color.Red;
                    }
                    else if (changeValue < 0)
                    {
                        e.CellStyle.ForeColor = Color.Green; // 下跌 (綠色)
                        //e.CellStyle.BackColor = Color.Green;
                    }
                }
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            List<string> stockSymbols = new List<string> { "2330.TW", "0050.TW", "2412.TW", "2610.TW", "00650L.TW" };
            //List<MyStocksInfo> stocks = await _controller.FetchStockData(stockSymbols);
            List<MyStocksInfo> stocks = await _controller.FetchStockDataByYahoo(stockSymbols);
            // 將Grid綁定事件，觸發漲跌幅的顏色變化
            stockDataGrid.CellFormatting += StockDataGrid_CellFormatting;

            // 將資料綁定到 StockDataGrid
            stockDataGrid.DataSource = stocks;
            stockDataGrid.Columns[0].HeaderText = "股票代號";
            stockDataGrid.Columns[1].HeaderText = "價格";
            stockDataGrid.Columns[2].HeaderText = "漲跌";

            // 設定更新按鈕的圖示
            //Image originalImage = Image.FromFile("D:\\7000\\Programming\\C#\\MarketPulse\\Images\\update.png");
            //buttonUpdate.Image = new Bitmap(originalImage, new Size(40, 32));
        }
    }
}

using MarketPulse.Controllers;
using MarketPulse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mystocks.txt"); ;
            //List<string> stockSymbols = new List<string> { "2330.TW", "0050.TW", "2412.TW", "2610.TW", "00650L.TW" };
            List<MyStocksInfo> stocks = await _controller.FetchStockDataByYahoo(filePath);
            // 將Grid綁定事件，觸發漲跌幅的顏色變化
            DGView_MyStocks.CellFormatting += StockDataGrid_CellFormatting;

            // 將資料綁定到 StockDataGrid
            DGView_MyStocks.DataSource = stocks;
            DGView_MyStocks.Columns[0].HeaderText = "股票代號";
            DGView_MyStocks.Columns[1].HeaderText = "價格";
            DGView_MyStocks.Columns[2].HeaderText = "漲跌";
            DGView_MyStocks.Columns[3].HeaderText = "成交量";
            DGView_MyStocks.Columns[4].HeaderText = "開盤價";
            DGView_MyStocks.Columns[5].HeaderText = "更新時間";

            var delBtn = new DataGridViewButtonColumn
            {
                Name = "DeleteButton",
                HeaderText = "",
                Text = "刪除",
                UseColumnTextForButtonValue = true
            };
            if (!DGView_MyStocks.Columns.Contains("DeleteButton"))
                DGView_MyStocks.Columns.Add(delBtn);
            DGView_MyStocks.Columns[6].HeaderText = "刪除";
        }

        private void DGView_MyStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGView_MyStocks.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                string symbol = DGView_MyStocks.Rows[e.RowIndex].Cells["StockSymbol"].Value.ToString();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mystocks.txt");
                var lines = File.ReadAllLines(filePath).ToList();
                lines.RemoveAll(l => l.Trim() == symbol);
                File.WriteAllLines(filePath, lines);
                MessageBox.Show($"{symbol} 已從清單中移除");
                buttonUpdate_Click(sender, e); // 重新載入顯示
            }
        }
    }
}

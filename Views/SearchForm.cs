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

namespace MarketPulse.Views
{
    public partial class SearchForm: Form
    {
        private SearchControl _controller = new SearchControl();
        public SearchForm()
        {
            InitializeComponent();
        }

        private async void Button_SearchStocks_Click(object sender, EventArgs e)
        {
            string keyword = textBox_Search.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("請輸入股票代號或名稱");
                return;
            }

            button_SearchStocks.Enabled = false; // 防止重複點擊
            List<SearchInfo> stocks = await _controller.SearchStocks(keyword);
            button_SearchStocks.Enabled = true;

            if (stocks.Count == 0)
            {
                MessageBox.Show("未找到符合的股票");
                return;
            }

            // 更新 DataGridView
            DGView_Search.DataSource = stocks;
            // 將Grid綁定事件，觸發漲跌幅的顏色變化
            DGView_Search.CellFormatting += DGView_Search_CellFormatting;
            DGView_Search.Columns[0].HeaderText = "股票代號";
            DGView_Search.Columns[1].HeaderText = "股票名稱";
            DGView_Search.Columns[2].HeaderText = "價格";
            DGView_Search.Columns[3].HeaderText = "漲跌";
            DGView_Search.Columns[4].HeaderText = "成交量";
            DGView_Search.Columns[5].HeaderText = "開盤價";
            DGView_Search.Columns[6].HeaderText = "更新時間";

            // 加入新增按鈕與欄位
            var addBtn = new DataGridViewButtonColumn
            {
                Name = "AddButton",
                HeaderText = "",
                Text = "新增",
                UseColumnTextForButtonValue = true
            };
            if (!DGView_Search.Columns.Contains("AddButton"))
                DGView_Search.Columns.Add(addBtn);
        }

        private void DGView_Search_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null) // 第4行 (漲跌)
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

        private void DGView_Search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGView_Search.Columns[e.ColumnIndex].Name == "AddButton")
            {
                string stockSymbol = DGView_Search.Rows[e.RowIndex].Cells["Symbol"].Value.ToString();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mystocks.txt");
                var allLines = File.Exists(filePath) ? File.ReadAllLines(filePath).ToList() : new List<string>();

                if (!allLines.Contains(stockSymbol))
                {
                    File.AppendAllLines(filePath, new[] { stockSymbol });
                    MessageBox.Show($"{stockSymbol} 已加入我的股票清單");
                }
                else
                {
                    MessageBox.Show($"{stockSymbol} 已經存在！");
                }
            }
        }
    }
}

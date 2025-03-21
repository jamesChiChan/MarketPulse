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

namespace MarketPulse.Views
{
    public partial class GlobalPricesForm: Form
    {
        private GlobalPricesControl _controller = new GlobalPricesControl();
        public GlobalPricesForm()
        {
            InitializeComponent();
        }

        private async void GlobalPricesForm_Load(object sender, EventArgs e)
        {
            List<GlobalPricesInfo> globalPrices = await _controller.GetGlobalPrices();
            DGView_GP.DataSource = globalPrices;
            DGView_GP.CellFormatting += DGView_GP_CellFormatting;

            DGView_GP.Columns[0].HeaderText = "商品代號";
            DGView_GP.Columns[1].HeaderText = "商品名稱";
            DGView_GP.Columns[2].HeaderText = "價格";
            DGView_GP.Columns[3].HeaderText = "漲跌";
            DGView_GP.Columns[4].HeaderText = "漲跌幅";
            DGView_GP.Columns[5].HeaderText = "成交量";
            DGView_GP.Columns[6].HeaderText = "最後更新時間";
        }

        private void DGView_GP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 4) && e.Value != null) // 第4、5行 (漲跌)
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
    }
}

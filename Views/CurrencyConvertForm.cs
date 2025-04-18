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
    public partial class CurrencyConvertForm: Form
    {
        private readonly CurrencyConvertControl _controller = new CurrencyConvertControl();

        public CurrencyConvertForm()
        {
            InitializeComponent();
        }

        private async void CurrencyConvertForm_Load(object sender, EventArgs e)
        {
            await _controller.LoadRatesAsync();

            comBox_From.DataSource = _controller.AllRates.Select(r => r.CurrencyCode).ToList();
            comBox_To.DataSource = _controller.AllRates.Select(r => r.CurrencyCode).ToList();
            comBox_From.SelectedItem = "TWD";
            comBox_To.SelectedItem = "USD";

            DGView_Currency.DataSource = _controller.AllRates;
            label_UpdateTime.Text = $"更新時間：{_controller.LastUpdateTime}";

            DGView_Currency.Columns[0].HeaderText = "幣別代碼";
            DGView_Currency.Columns[1].HeaderText = "名稱";
            DGView_Currency.Columns[2].HeaderText = "現金買入";
            DGView_Currency.Columns[3].HeaderText = "現金賣出";
            DGView_Currency.Columns[4].HeaderText = "即期買入";
            DGView_Currency.Columns[5].HeaderText = "即期賣出";
        }

        private void txtAmountOrCurrencyChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_From.Text, out double amount) &&
                comBox_From.SelectedItem != null && comBox_To.SelectedItem != null)
            {
                string from = comBox_From.SelectedItem.ToString();
                string to = comBox_To.SelectedItem.ToString();
                double converted = _controller.Convert(from, to, amount);
                textBox_To.Text = $"{converted:F2} {to}";
            }
        }

        private void button_changeCurrency_Click(object sender, EventArgs e)
        {
            string temp = comBox_From.Text;
            comBox_From.Text = comBox_To.Text;
            comBox_To.Text = temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarketPulse.View;
using MarketPulse.Views;

namespace MarketPulse
{
    public partial class MainForm : Form
    {
        // 用 Dictionary 記錄已開啟的 Tab，方便查詢
        private Dictionary<string, TabPage> openedTabs = new Dictionary<string, TabPage>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenFormInTab(string tabKey, string tabTitle, Form form)
        {
            if (openedTabs.ContainsKey(tabKey))
            {
                // 若已開啟，直接切換到該 Tab
                tabControl1.SelectedTab = openedTabs[tabKey];
            }
            else
            {
                // 建立新的 TabPage
                TabPage newTab = new TabPage(tabTitle);

                // 嵌入 Form 到 TabPage 中
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                newTab.Controls.Add(form);
                form.Show();

                // 將 TabPage 加入到 TabControl
                tabControl1.TabPages.Add(newTab);
                tabControl1.SelectedTab = newTab;

                // 記錄已開啟的 Tab
                openedTabs[tabKey] = newTab;

                // 當 Tab 被關閉時，自動從 Dictionary 中移除
                newTab.Disposed += (s, e) => openedTabs.Remove(tabKey);
            }
        }

        private void buttonToolboxCollapse_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                // 展開 Panel1
                splitContainer1.Panel1Collapsed = false;
                buttonToolboxCollapse.Text = "收合工具列←";
            }
            else
            {
                // 收合 Panel1
                splitContainer1.Panel1Collapsed = true;
                buttonToolboxCollapse.Text = "展開工具列→";
            }
        }

        private void ButtonStock_Click(object sender, EventArgs e)
        {
            OpenFormInTab("MyStocks", "股票資訊", new MyStocksForm());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            OpenFormInTab("SearchStocks", "搜尋股票", new SearchForm());
        }
    }
}

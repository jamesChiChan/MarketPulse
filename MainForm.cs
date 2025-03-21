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
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Padding = new Point(20, 4); // 預留空間給關閉按鈕

            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.MouseDown += tabControl1_MouseDown;
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

        private void buttonGlobalPrices_Click(object sender, EventArgs e)
        {
            OpenFormInTab("GlobalPrices", "國際物價", new GlobalPricesForm());
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl1.TabPages[e.Index];
            Rectangle tabRect = tabControl1.GetTabRect(e.Index);

            // 繪製標籤文字
            TextRenderer.DrawText(e.Graphics, tabPage.Text, e.Font, tabRect, tabPage.ForeColor);

            // 畫關閉按鈕 (✕)
            Rectangle closeButton = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 12, 12);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, closeButton.Location);
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle tabRect = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(tabRect.Right - 15, tabRect.Top + 4, 12, 12);

                if (closeButton.Contains(e.Location))
                {
                    var tabPage = tabControl1.TabPages[i];

                    string keyToRemove = openedTabs.FirstOrDefault(x => x.Value == tabPage).Key;
                    if (!string.IsNullOrEmpty(keyToRemove))
                    {
                        openedTabs.Remove(keyToRemove);
                    }

                    tabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketPulse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 用 Dictionary 記錄已開啟的 Tab，方便查詢
        private Dictionary<string, TabPage> openedTabs = new Dictionary<string, TabPage>();

        private void OpenTab(string tabKey, string tabTitle, string tabContent)
        {
            // 檢查是否已經存在該 Tab
            if (openedTabs.ContainsKey(tabKey))
            {
                // 若已存在，直接切換到該 Tab
                tabControl1.SelectedTab = openedTabs[tabKey];
            }
            else
            {
                // 建立新的 TabPage
                TabPage newTab = new TabPage(tabTitle);

                // 可選：在 Tab 中加入內容
                Label label = new Label();
                label.Text = tabContent;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                newTab.Controls.Add(label);

                // 將 Tab 加入 TabControl
                tabControl1.TabPages.Add(newTab);
                tabControl1.SelectedTab = newTab;

                // 記錄已開啟的 Tab
                openedTabs[tabKey] = newTab;

                // 加入關閉按鈕功能（可選）
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
            OpenTab("Stock", "Stock", "這是 Stock 的內容");
        }
    }
}

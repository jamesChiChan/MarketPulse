﻿namespace MarketPulse
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonForeignExchange = new System.Windows.Forms.Button();
            this.buttonGlobalPrices = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonStock = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonToolboxCollapse = new System.Windows.Forms.Button();
            this.buttonAsktoAI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.buttonAsktoAI);
            this.splitContainer1.Panel1.Controls.Add(this.buttonForeignExchange);
            this.splitContainer1.Panel1.Controls.Add(this.buttonGlobalPrices);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStock);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.buttonToolboxCollapse);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 562);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonForeignExchange
            // 
            this.buttonForeignExchange.BackColor = System.Drawing.SystemColors.Control;
            this.buttonForeignExchange.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonForeignExchange.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonForeignExchange.Location = new System.Drawing.Point(0, 165);
            this.buttonForeignExchange.Name = "buttonForeignExchange";
            this.buttonForeignExchange.Size = new System.Drawing.Size(200, 55);
            this.buttonForeignExchange.TabIndex = 3;
            this.buttonForeignExchange.Text = "外匯";
            this.buttonForeignExchange.UseVisualStyleBackColor = false;
            this.buttonForeignExchange.Click += new System.EventHandler(this.buttonForeignExchange_Click);
            // 
            // buttonGlobalPrices
            // 
            this.buttonGlobalPrices.BackColor = System.Drawing.SystemColors.Control;
            this.buttonGlobalPrices.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGlobalPrices.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonGlobalPrices.Location = new System.Drawing.Point(0, 110);
            this.buttonGlobalPrices.Name = "buttonGlobalPrices";
            this.buttonGlobalPrices.Size = new System.Drawing.Size(200, 55);
            this.buttonGlobalPrices.TabIndex = 2;
            this.buttonGlobalPrices.Text = "國際物價";
            this.buttonGlobalPrices.UseVisualStyleBackColor = false;
            this.buttonGlobalPrices.Click += new System.EventHandler(this.buttonGlobalPrices_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSearch.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSearch.Location = new System.Drawing.Point(0, 55);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(200, 55);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "搜尋";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonStock
            // 
            this.buttonStock.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStock.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonStock.Location = new System.Drawing.Point(0, 0);
            this.buttonStock.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Size = new System.Drawing.Size(200, 55);
            this.buttonStock.TabIndex = 0;
            this.buttonStock.Text = "個人股票";
            this.buttonStock.UseVisualStyleBackColor = false;
            this.buttonStock.Click += new System.EventHandler(this.ButtonStock_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(27, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 562);
            this.tabControl1.TabIndex = 1;
            // 
            // buttonToolboxCollapse
            // 
            this.buttonToolboxCollapse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonToolboxCollapse.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonToolboxCollapse.Location = new System.Drawing.Point(0, 0);
            this.buttonToolboxCollapse.Margin = new System.Windows.Forms.Padding(4);
            this.buttonToolboxCollapse.Name = "buttonToolboxCollapse";
            this.buttonToolboxCollapse.Size = new System.Drawing.Size(27, 562);
            this.buttonToolboxCollapse.TabIndex = 0;
            this.buttonToolboxCollapse.Text = "收合工具列←";
            this.buttonToolboxCollapse.UseVisualStyleBackColor = false;
            this.buttonToolboxCollapse.Click += new System.EventHandler(this.buttonToolboxCollapse_Click);
            // 
            // buttonAsktoAI
            // 
            this.buttonAsktoAI.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAsktoAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAsktoAI.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAsktoAI.Location = new System.Drawing.Point(0, 220);
            this.buttonAsktoAI.Name = "buttonAsktoAI";
            this.buttonAsktoAI.Size = new System.Drawing.Size(200, 55);
            this.buttonAsktoAI.TabIndex = 4;
            this.buttonAsktoAI.Text = "問問題";
            this.buttonAsktoAI.UseVisualStyleBackColor = false;
            this.buttonAsktoAI.Click += new System.EventHandler(this.buttonAsktoAI_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MyStock";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonToolboxCollapse;
        private System.Windows.Forms.Button buttonStock;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonGlobalPrices;
        private System.Windows.Forms.Button buttonForeignExchange;
        private System.Windows.Forms.Button buttonAsktoAI;
    }
}


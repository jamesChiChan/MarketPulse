namespace MarketPulse
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
            this.buttonStock = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonToolboxCollapse = new System.Windows.Forms.Button();
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
            // buttonStock
            // 
            this.buttonStock.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonStock.Location = new System.Drawing.Point(0, 0);
            this.buttonStock.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Size = new System.Drawing.Size(200, 41);
            this.buttonStock.TabIndex = 0;
            this.buttonStock.Text = "股票";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
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
    }
}


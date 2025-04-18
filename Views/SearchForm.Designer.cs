namespace MarketPulse.Views
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayout_Search = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.button_SearchStocks = new System.Windows.Forms.Button();
            this.DGView_Search = new System.Windows.Forms.DataGridView();
            this.flowLayout_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGView_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayout_Search
            // 
            this.flowLayout_Search.Controls.Add(this.textBox_Search);
            this.flowLayout_Search.Controls.Add(this.button_SearchStocks);
            this.flowLayout_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayout_Search.Location = new System.Drawing.Point(0, 0);
            this.flowLayout_Search.Name = "flowLayout_Search";
            this.flowLayout_Search.Size = new System.Drawing.Size(800, 75);
            this.flowLayout_Search.TabIndex = 0;
            // 
            // textBox_Search
            // 
            this.textBox_Search.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Search.Location = new System.Drawing.Point(3, 3);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(596, 34);
            this.textBox_Search.TabIndex = 0;
            // 
            // button_SearchStocks
            // 
            this.button_SearchStocks.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button_SearchStocks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SearchStocks.Location = new System.Drawing.Point(605, 3);
            this.button_SearchStocks.Name = "button_SearchStocks";
            this.button_SearchStocks.Size = new System.Drawing.Size(122, 34);
            this.button_SearchStocks.TabIndex = 1;
            this.button_SearchStocks.Text = "Search";
            this.button_SearchStocks.UseVisualStyleBackColor = false;
            this.button_SearchStocks.Click += new System.EventHandler(this.Button_SearchStocks_Click);
            // 
            // DGView_Search
            // 
            this.DGView_Search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGView_Search.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGView_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGView_Search.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGView_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGView_Search.Location = new System.Drawing.Point(0, 75);
            this.DGView_Search.Name = "DGView_Search";
            this.DGView_Search.RowHeadersWidth = 51;
            this.DGView_Search.RowTemplate.Height = 27;
            this.DGView_Search.Size = new System.Drawing.Size(800, 375);
            this.DGView_Search.TabIndex = 1;
            this.DGView_Search.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGView_Search_CellContentClick);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGView_Search);
            this.Controls.Add(this.flowLayout_Search);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.flowLayout_Search.ResumeLayout(false);
            this.flowLayout_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGView_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout_Search;
        private System.Windows.Forms.DataGridView DGView_Search;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button button_SearchStocks;
    }
}
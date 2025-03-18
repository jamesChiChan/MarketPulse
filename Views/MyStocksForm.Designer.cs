namespace MarketPulse.View
{
    partial class MyStocksForm
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.stockDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.stockDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(800, 100);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // stockDataGrid
            // 
            this.stockDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockDataGrid.Location = new System.Drawing.Point(0, 100);
            this.stockDataGrid.Name = "stockDataGrid";
            this.stockDataGrid.RowHeadersWidth = 51;
            this.stockDataGrid.RowTemplate.Height = 27;
            this.stockDataGrid.Size = new System.Drawing.Size(800, 350);
            this.stockDataGrid.TabIndex = 2;
            // 
            // MyStocksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stockDataGrid);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "MyStocksForm";
            this.Text = "MyStocksForm";
            this.Load += new System.EventHandler(this.MyStocksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridView stockDataGrid;
    }
}
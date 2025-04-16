namespace MarketPulse.Views
{
    partial class CurrencyConvertForm
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
            this.groupBox_Convert = new System.Windows.Forms.GroupBox();
            this.DGView_Currency = new System.Windows.Forms.DataGridView();
            this.comBox_From = new System.Windows.Forms.ComboBox();
            this.button_changeCurrency = new System.Windows.Forms.Button();
            this.comBox_To = new System.Windows.Forms.ComboBox();
            this.textBox_From = new System.Windows.Forms.TextBox();
            this.textBox_To = new System.Windows.Forms.TextBox();
            this.label_UpdateTime = new System.Windows.Forms.Label();
            this.groupBox_Convert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGView_Currency)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Convert
            // 
            this.groupBox_Convert.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox_Convert.Controls.Add(this.label_UpdateTime);
            this.groupBox_Convert.Controls.Add(this.textBox_To);
            this.groupBox_Convert.Controls.Add(this.textBox_From);
            this.groupBox_Convert.Controls.Add(this.comBox_To);
            this.groupBox_Convert.Controls.Add(this.button_changeCurrency);
            this.groupBox_Convert.Controls.Add(this.comBox_From);
            this.groupBox_Convert.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Convert.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_Convert.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Convert.Name = "groupBox_Convert";
            this.groupBox_Convert.Size = new System.Drawing.Size(841, 100);
            this.groupBox_Convert.TabIndex = 0;
            this.groupBox_Convert.TabStop = false;
            this.groupBox_Convert.Text = "外匯換算";
            // 
            // DGView_Currency
            // 
            this.DGView_Currency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGView_Currency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGView_Currency.Location = new System.Drawing.Point(0, 100);
            this.DGView_Currency.Name = "DGView_Currency";
            this.DGView_Currency.RowHeadersWidth = 51;
            this.DGView_Currency.RowTemplate.Height = 27;
            this.DGView_Currency.Size = new System.Drawing.Size(841, 350);
            this.DGView_Currency.TabIndex = 1;
            // 
            // comBox_From
            // 
            this.comBox_From.FormattingEnabled = true;
            this.comBox_From.Location = new System.Drawing.Point(12, 43);
            this.comBox_From.Name = "comBox_From";
            this.comBox_From.Size = new System.Drawing.Size(153, 33);
            this.comBox_From.TabIndex = 0;
            this.comBox_From.SelectedIndexChanged += new System.EventHandler(this.txtAmountOrCurrencyChanged);
            // 
            // button_changeCurrency
            // 
            this.button_changeCurrency.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_changeCurrency.Location = new System.Drawing.Point(171, 43);
            this.button_changeCurrency.Name = "button_changeCurrency";
            this.button_changeCurrency.Size = new System.Drawing.Size(53, 33);
            this.button_changeCurrency.TabIndex = 1;
            this.button_changeCurrency.Text = "⮂";
            this.button_changeCurrency.UseVisualStyleBackColor = true;
            this.button_changeCurrency.Click += new System.EventHandler(this.button_changeCurrency_Click);
            // 
            // comBox_To
            // 
            this.comBox_To.FormattingEnabled = true;
            this.comBox_To.Location = new System.Drawing.Point(230, 43);
            this.comBox_To.Name = "comBox_To";
            this.comBox_To.Size = new System.Drawing.Size(153, 33);
            this.comBox_To.TabIndex = 2;
            this.comBox_To.SelectedIndexChanged += new System.EventHandler(this.txtAmountOrCurrencyChanged);
            // 
            // textBox_From
            // 
            this.textBox_From.Location = new System.Drawing.Point(413, 42);
            this.textBox_From.Name = "textBox_From";
            this.textBox_From.Size = new System.Drawing.Size(130, 34);
            this.textBox_From.TabIndex = 3;
            this.textBox_From.TextChanged += new System.EventHandler(this.txtAmountOrCurrencyChanged);
            // 
            // textBox_To
            // 
            this.textBox_To.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_To.Enabled = false;
            this.textBox_To.Location = new System.Drawing.Point(549, 42);
            this.textBox_To.Name = "textBox_To";
            this.textBox_To.Size = new System.Drawing.Size(130, 34);
            this.textBox_To.TabIndex = 4;
            // 
            // label_UpdateTime
            // 
            this.label_UpdateTime.AutoSize = true;
            this.label_UpdateTime.Location = new System.Drawing.Point(685, 72);
            this.label_UpdateTime.Name = "label_UpdateTime";
            this.label_UpdateTime.Size = new System.Drawing.Size(92, 25);
            this.label_UpdateTime.TabIndex = 5;
            this.label_UpdateTime.Text = "更新時間";
            // 
            // CurrencyConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 450);
            this.Controls.Add(this.DGView_Currency);
            this.Controls.Add(this.groupBox_Convert);
            this.Name = "CurrencyConvertForm";
            this.Text = "ForeignExchangeForm";
            this.Load += new System.EventHandler(this.CurrencyConvertForm_Load);
            this.groupBox_Convert.ResumeLayout(false);
            this.groupBox_Convert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGView_Currency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Convert;
        private System.Windows.Forms.DataGridView DGView_Currency;
        private System.Windows.Forms.Button button_changeCurrency;
        private System.Windows.Forms.ComboBox comBox_From;
        private System.Windows.Forms.TextBox textBox_To;
        private System.Windows.Forms.TextBox textBox_From;
        private System.Windows.Forms.ComboBox comBox_To;
        private System.Windows.Forms.Label label_UpdateTime;
    }
}
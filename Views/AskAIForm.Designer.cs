namespace MarketPulse.Views
{
    partial class AskAIForm
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
            this.GB_Ask = new System.Windows.Forms.GroupBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.GB_Answer = new System.Windows.Forms.GroupBox();
            this.btnAsk = new System.Windows.Forms.Button();
            this.richtxtboxAnswer = new System.Windows.Forms.RichTextBox();
            this.GB_Ask.SuspendLayout();
            this.GB_Answer.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Ask
            // 
            this.GB_Ask.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GB_Ask.Controls.Add(this.btnAsk);
            this.GB_Ask.Controls.Add(this.txtQuestion);
            this.GB_Ask.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GB_Ask.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GB_Ask.Location = new System.Drawing.Point(0, 353);
            this.GB_Ask.Name = "GB_Ask";
            this.GB_Ask.Size = new System.Drawing.Size(800, 97);
            this.GB_Ask.TabIndex = 0;
            this.GB_Ask.TabStop = false;
            this.GB_Ask.Text = "Ask any question";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestion.Location = new System.Drawing.Point(3, 26);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(794, 30);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.Text = "告訴我今天台股情勢與建議";
            // 
            // GB_Answer
            // 
            this.GB_Answer.Controls.Add(this.richtxtboxAnswer);
            this.GB_Answer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_Answer.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GB_Answer.Location = new System.Drawing.Point(0, 0);
            this.GB_Answer.Name = "GB_Answer";
            this.GB_Answer.Size = new System.Drawing.Size(800, 353);
            this.GB_Answer.TabIndex = 1;
            this.GB_Answer.TabStop = false;
            this.GB_Answer.Text = "AI answer";
            // 
            // btnAsk
            // 
            this.btnAsk.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAsk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAsk.Location = new System.Drawing.Point(3, 58);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(794, 36);
            this.btnAsk.TabIndex = 1;
            this.btnAsk.Text = "Enter";
            this.btnAsk.UseVisualStyleBackColor = false;
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            // 
            // richtxtboxAnswer
            // 
            this.richtxtboxAnswer.BackColor = System.Drawing.Color.White;
            this.richtxtboxAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richtxtboxAnswer.Location = new System.Drawing.Point(3, 26);
            this.richtxtboxAnswer.Name = "richtxtboxAnswer";
            this.richtxtboxAnswer.ReadOnly = true;
            this.richtxtboxAnswer.Size = new System.Drawing.Size(794, 324);
            this.richtxtboxAnswer.TabIndex = 0;
            this.richtxtboxAnswer.Text = "";
            // 
            // AskAIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GB_Answer);
            this.Controls.Add(this.GB_Ask);
            this.Name = "AskAIForm";
            this.Text = "AskAIForm";
            this.GB_Ask.ResumeLayout(false);
            this.GB_Ask.PerformLayout();
            this.GB_Answer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Ask;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.GroupBox GB_Answer;
        private System.Windows.Forms.RichTextBox richtxtboxAnswer;
    }
}
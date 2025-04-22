using MarketPulse.Controllers;
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
    public partial class AskAIForm: Form
    {
        private readonly AskAIControl _controller = new AskAIControl();

        public AskAIForm()
        {
            InitializeComponent();
        }

        private async void btnAsk_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text.Trim();

            if (string.IsNullOrEmpty(question))
            {
                MessageBox.Show("請輸入問題");
                return;
            }

            richtxtboxAnswer.Text = "請稍候，正在向 Gemini 詢問...";
            string answer = await _controller.AskQuestionAsync(question);
            richtxtboxAnswer.Text = answer;
        }
    }
}

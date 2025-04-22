using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPulse.Models;

namespace MarketPulse.Controllers
{
    class AskAIControl
    {
        public async Task<string> AskQuestionAsync(string question)
        {
            // return await Task.Run(() => AskAIInfo.Ask(question));
            //return await Task.Run(() => AskAIInfo.AsktoChatGPT(question));
            return await Task.Run(() => AskAIInfo.AsktoGemini(question));
        }
    }
}

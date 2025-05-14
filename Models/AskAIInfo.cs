using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MarketPulse.Models
{
    class AskAIInfo
    {
        public static string Ask(string question)
        {
            string result = "";
            var options = new EdgeOptions();
            //options.AddArgument("headless");
            options.AddArgument("disable-gpu");

            question = "用繁體中文回答以下問題，並簡短敘述重點，字數在50以內：" + question;

            string url = $"https://chat.openai.com/?q={Uri.EscapeDataString(question)}";

            using (var driver = new EdgeDriver(options))
            {
                try
                {
                    driver.Navigate().GoToUrl(url);

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                    // 等待 markdown 容器出現
                    wait.Until(d => d.FindElements(By.CssSelector("div.markdown.prose")).Count > 0);

                    string lastText = "", currentText = "";
                    int stableCount = 0;
                    bool startCheckingStability = false;

                    for (int i = 0; i < 30; i++) // 最多等30秒
                    {
                        var element = driver.FindElements(By.CssSelector("div.markdown.prose")).LastOrDefault();
                        currentText = element?.Text.Trim() ?? "";

                        // 只有超過 N 字才開始判斷穩定性
                        if (currentText.Length > 10)
                            startCheckingStability = true;

                        if (startCheckingStability)
                        {
                            if (currentText == lastText)
                                stableCount++;
                            else
                                stableCount = 0;

                            if (stableCount >= 3) break; // 連續3次都沒變就當作穩定
                        }

                        lastText = currentText;
                        Thread.Sleep(1000); // 每秒檢查一次
                    }

                    result = currentText;
                }
                catch (Exception ex)
                {
                    result = $"Error：{ex.Message}";
                }
                finally
                {
                    driver.Quit();
                }
            }

            return result;
        }

        public static string AsktoChatGPT(string question)
        {
            string result = "";

            // ChatGPT 網址 + 問題帶入
            question = "用繁體中文回答以下問題，並簡短敘述重點，字數在50以內：" + question;
            string url = $"https://chat.openai.com/?q={Uri.EscapeDataString(question)}";

            var options = new EdgeOptions();
            // 不使用 headless 模式，才能穩定互動
            options.AddArgument("disable-gpu");
            options.AddArgument("--start-maximized");

            // 強化 User-Agent 避免被辨識為機器人
            options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120 Safari/537.36");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            var service = EdgeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            using (var driver = new EdgeDriver(service, options))
            {
                try
                {
                    driver.Navigate().GoToUrl(url);

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                    // 等待輸入框出現
                    var inputBox = wait.Until(d => d.FindElement(By.CssSelector("textarea")));
                    //inputBox.SendKeys(Keys.Enter); // 模擬按 Enter 發送問題
                    // 改用 JavaScript 觸發送出問題
                    ((IJavaScriptExecutor)driver).ExecuteScript(@"
                        const textarea = document.querySelector('textarea');
                        const event = new KeyboardEvent('keydown', { key: 'Enter', bubbles: true });
                        textarea.dispatchEvent(event);
                    ");

                    // 等回答容器出現
                    wait.Until(d => d.FindElements(By.CssSelector("div.markdown.prose")).Count > 0);

                    // 等回答載入並穩定
                    string lastText = "", currentText = "";
                    int stableCount = 0;

                    for (int i = 0; i < 60; i++)
                    {
                        var element = driver.FindElements(By.CssSelector("div.markdown.prose")).LastOrDefault();
                        currentText = element?.Text.Trim() ?? "";

                        if (currentText.Length > 10)
                        {
                            if (currentText == lastText)
                                stableCount++;
                            else
                                stableCount = 0;

                            if (stableCount >= 3) break;

                            lastText = currentText;
                        }

                        Thread.Sleep(1000);
                    }

                    result = currentText;
                }
                catch (Exception ex)
                {
                    result = $"Error：{ex.Message}";
                }
                finally
                {
                    driver.Quit();
                }
            }

            return result;
        }

        private static readonly HttpClient _client = new HttpClient();
        private const string ApiKey = "ApplyYourKey";
        private const string Endpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + ApiKey;

        public static string AsktoGemini(string question)
        {
            string result = "";

            question = "用繁體中文回答以下問題，並簡短敘述重點，不參雜符號、圖案或圖片：" + question;

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = question }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = _client.PostAsync(Endpoint, content).Result;
                var responseContent = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine("Gemini 原始回應 JSON：");
                Console.WriteLine(responseContent);

                JsonDocument doc = null;
                try
                {
                    doc = JsonDocument.Parse(responseContent);
                    var root = doc.RootElement;

                    JsonElement candidates, contentElement, parts, textElement;
                    if (root.TryGetProperty("candidates", out candidates) &&
                        candidates.GetArrayLength() > 0 &&
                        candidates[0].TryGetProperty("content", out contentElement) &&
                        contentElement.TryGetProperty("parts", out parts) &&
                        parts.GetArrayLength() > 0 &&
                        parts[0].TryGetProperty("text", out textElement))
                    {
                        result = textElement.GetString();
                    }
                    else
                    {
                        result = "無法擷取 Gemini 回應的內容。可能是 API 錯誤或格式變動。";
                    }
                }
                finally
                {
                    if (doc != null)
                        doc.Dispose();
                }
            }
            catch (Exception ex)
            {
                result = $"Error：{ex.Message}";
            }

            return result;
        }
    }
}

# MarketPulse
## 📁 Project Type
- Windows Forms Desktop Application
- Language: C#
- Architecture design: MVC mode (Model-View-Controller)

## 🔐 This project needs to set GEMINI_API_KEY by yourself.
Please go to https://ai.google.dev/gemini-api/docs/api-key to apply for a Google Gemini API Key.
Then go to Models/AskAIInfo.cs and fill in the key on line 163

## 🎯 Project Goal
Develop a desktop platform that integrates real-time **stock tracking**, **currency conversion**, **international commodities** and **AI Q&A**, allowing users to conveniently query market information and quickly ask financial questions and get concise answers.

## 🧱 Architecture design description (MVC)
### 1. Model
Responsible for logic processing and data source integration:
- `MyStocksInfo.cs`: A wrapper model for handling stock symbols and prices, supporting the retrieval of stock information from the Yahoo Finance API.
- `SearchInfo.cs`: Real-time price query through stock codes, supporting stock information extraction from Yahoo Finance API and Taiwan Stock Exchange OpenAPI.
- `GlobalPricesInfo.cs`: Reads the Yahoo Finance API to get the raw material prices.
- `CurrencyConvertInfo.cs`: Reads Taiwan Bank’s public exchange rate data (using a crawler to fetch from the web) and provides spot/cash buying and selling prices.
- `AskAIInfo.cs`: Responsible for sending questions to the Google Gemini 2.0 Flash model and parsing responses.

### 2. Controller
- `MyStocksControl.cs`: Encapsulates functions related to stock reading, querying, and deleting logic.
- `SearchControl.cs`: Pass the code to the model for real-time query service and load the query results.
- `GlobalPricesControl.cs`: Handle the loading of international raw material data.
- `CurrencyConvertControl.cs`: handles the loading and conversion logic of exchange rate data.
- `AskAIControl.cs`: responsible for passing questions to the model service and returning answers to the interface.

### 3. View
- `MyStocksForm.cs`: Displays the user's selected stocks form and provides deletion function.
- `SearchForm.cs`: Search for real-time stock prices of any symbol, support adding to my stock list.
- `GlobalPricesForm.cs`: Provides a tabular display of international raw materials.
- `CurrencyConvertForm.cs`: provides exchange rate query, currency conversion, table display and update time display.
- `AskAIForm.cs`: The user enters a question and the answer will be displayed through Gemini Q&A.

## Interface
### My Stocks
- Can read the local `MyStocks.txt` list of selected stock codes
- Instantly check stock quotes (including name, current price, increase or decrease)
- Add to favorites is now supported in the search function page
- My Stocks page supports "Delete My Selections"
![image](https://github.com/user-attachments/assets/4516eb97-ca28-4788-9fda-43cdc83735f8)

### Instant query page function
- Users can enter any stock code in the search bar (supports fuzzy matching)
- Display query results including stock code, name, real-time price and change
- There is an "Add" button at the end of each query result, which can be used to add the stock to the watchlist (write to MyStocks.txt)
- Easy to operate, supports quick addition and real-time update of stock tables
![image](https://github.com/user-attachments/assets/6a70d6eb-cba3-44d0-8c5e-77b941b8096a)

### International raw materials page features
- Use Yahoo Finance API to query major commodity codes such as gold, crude oil, and natural gas (such as GC=F, CL=F)
- Displays the item name, real-time price and daily increase or decrease, integrated in a table
- Users can quickly browse the real-time market prices of various raw materials to grasp the global market trends
![image](https://github.com/user-attachments/assets/c58ff8ae-867d-4d85-9807-c7e515599033)


### Currency
- Displays spot and cash buying and selling exchange rates for all currencies, mainly Taiwan dollars
- Instantly display the latest update time
- Provides upper and lower currency conversion menus + number input field + automatic conversion results
![image](https://github.com/user-attachments/assets/d4e38b20-a609-40af-9bf2-294d826a6f7f)

### AI Q&A function (Gemini)
- Users enter any financial or market question
- Automatically send to Gemini API (gemini-2.0-flash)
- Send back a JSON response and extract the text content to display on the platform
![image](https://github.com/user-attachments/assets/24f6dd8c-aa6b-4b30-a6ac-9ae557f6fd60)

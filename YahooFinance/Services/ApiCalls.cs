using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text;

namespace MoneyMachine.Services
{
    public class ApiCalls
    {
        public string apiKey;
        public string symbol;

        public List<AlphaVantageData> MonthlyPrices(string apiKey, string symbol)
        {
            var monthlyQuotes = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<AlphaVantageData>>();
            return monthlyQuotes;
        }

        public List<StockQuote> DailyPrices(string apiKey, string symbol)
        {
            var dailyQuote = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<StockQuote>>();

            return dailyQuote;
        }

        public List<CompanyName> CompanyName(string apiKey, string symbol)
        {
            var companyName = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<CompanyName>>();
            return companyName;
        }
    }
}

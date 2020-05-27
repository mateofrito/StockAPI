using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Text;



namespace YahooFinance
{
    class Program
    {
        static void Main(string[] args)
        {
            // retrieve monthly prices for Microsoft
            var symbol = "DKNG";
            var apiKey = "EXGBU46FGX9CDJ24"; // retrieve your api key from https://www.alphavantage.co/support/#api-key
            //var monthlyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}&datatype=csv"
            //                .GetStringFromUrl().FromCsv<List<AlphaVantageData>>();
            var currentquote = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<StockQuote>>();
            currentquote.PrintDump();
            
            // some simple stats
            //var maxPrice = monthlyPrices.Max(u => u.Close);
            //var minPrice = monthlyPrices.Min(u => u.Close);
            Console.WriteLine("These quotes were for:  " + symbol);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace YahooFinance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a stock symbol");
            var symbol = Console.ReadLine();
            Console.WriteLine("How many months?");
            string months = Console.ReadLine();
            int monthInt = months.ToInt();
            
            // retrieve monthly prices for Microsoft
            var stockQuote = new StockQuote();
            //var symbol = "DKNG";
            var apiKey = "EXGBU46FGX9CDJ24"; 
            // retrieve your api key from https://www.alphavantage.co/support/#api-key
            var monthlyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<AlphaVantageData>>();

            var ticker = symbol;
            var search = new Search { Ticker = ticker };

            int totalRecords = monthlyPrices.Count;

            var stockOutput = search.Results = monthlyPrices.OrderByDescending(x => x.Timestamp).Take(monthInt).ToList();
            //monthlyPrices.PrintDump();
            stockOutput.PrintDump();

			
			//Console.WriteLine("The current price for " + symbol + " is: " + price);
			//var maxPrice = monthlyPrices.Max(u => u.Close);
			//var minPrice = monthlyPrices.Min(u => u.Close);
			//Console.WriteLine("These quotes were for:  " + symbol);
		}
    }
}

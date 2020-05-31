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
            
            var monthlyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<AlphaVantageData>>();
            var dailyPrices = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}&datatype=csv".GetStringFromUrl().FromCsv<List<StockQuote>>(); 
            
            var ticker = symbol;
            var search = new Search { Ticker = ticker };
            var daySearch = new DailySearch { Ticker = ticker };
            int totalRecords = monthlyPrices.Count;

            var stockOutput = search.Results = monthlyPrices.OrderByDescending(x => x.Timestamp).Take(monthInt).ToList();
            
            
            var changePercent = daySearch.Results = dailyPrices.Take(1).ToList();
            //monthlyPrices.PrintDump();
            //stockOutput.PrintDump();

            Console.WriteLine("Trailing Monthly Closing Prices for " + symbol);
            Console.WriteLine("-------------------");

            foreach (var m in search.Results)
            {
                Console.WriteLine("Timestamp:  " + m.Timestamp);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Close:  " + m.Close);
                Console.ResetColor();
                Console.WriteLine("-------------------");
            }

            foreach (var x in daySearch.Results)
            {
                Console.WriteLine("Change Perfecntage" + x.changePercent);
            }
                    
			//Console.WriteLine("The current price for " + symbol + " is: " + price);
			//var maxPrice = monthlyPrices.Max(u => u.Close);
			//var minPrice = monthlyPrices.Min(u => u.Close);
			//Console.WriteLine("These quotes were for:  " + symbol);
		}
    }
}

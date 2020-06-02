using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
using ServiceStack.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using MoneyMachine.Services;


namespace MoneyMachine
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

            var apiCall = new ApiCalls();
           // apiCall.MonthlyPrices(apiKey, symbol);
 

            var ticker = symbol;
            var search = new Search { Ticker = ticker };
            var daySearch = new DailySearch { Ticker = ticker };
            var companySearch = new CompanySearch { Ticker = ticker };
            int totalRecords = apiCall.MonthlyPrices(apiKey, symbol).Count;

            var stockOutput = search.Results = apiCall.MonthlyPrices(apiKey, symbol).OrderByDescending(x => x.Timestamp).Take(monthInt).ToList();
            
            
            var changePercent = daySearch.Results = apiCall.DailyPrices(apiKey, symbol).Take(1).ToList();
            var companyNameResponse = companySearch.Results = apiCall.CompanyName(apiKey, symbol).Take(1).ToList();
            var company = "";
            foreach (var c in companySearch.Results)
            {
                company = c.name;
            }

            //monthlyPrices.PrintDump();
            //stockOutput.PrintDump();

            Console.WriteLine("Trailing Monthly Closing Prices for " + company);
            Console.WriteLine("-------------------");

            foreach (var m in search.Results)
            {
                Console.WriteLine("Date:  " + m.Timestamp);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Close:  " + m.Close);
                Console.ResetColor();
                Console.WriteLine("-------------------");
            }

            foreach (var x in daySearch.Results)
            {
                if (x.changePercent.StartsWith("-"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("Percentage Change:  " + x.changePercent);
            }
            Console.ResetColor();
            //Console.WriteLine("The current price for " + symbol + " is: " + price);
            //var maxPrice = monthlyPrices.Max(u => u.Close);
            //var minPrice = monthlyPrices.Min(u => u.Close);
            //Console.WriteLine("These quotes were for:  " + symbol);
        }
    }
}

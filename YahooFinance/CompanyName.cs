using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFinance
{
    public class CompanyName
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string region { get; set; }
        public string marketOpen { get; set; }
        public string marketClose { get; set; }
        public string timezone { get; set; }
        public string currency { get; set; }
        public decimal matchScore { get; set; }
         
    }
}

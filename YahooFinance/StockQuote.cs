﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YahooFinance
{
    class StockQuote
    {
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal price { get; set; }
        public decimal volume { get; set;}
        public DateTime latestDay { get; set; }

        public decimal previousClose { get; set; }
        public decimal change { get; set; }

        public string changePercent { get; set; }
    }
}

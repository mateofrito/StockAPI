﻿using System;
using System.Collections.Generic;

namespace YahooFinance
{


    public class Search
    {
        public string Ticker { get; set; } = "";

        public int PageNr { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public int TotalRecords { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
        public List<AlphaVantageData> Results { get; set; } = new List<AlphaVantageData>();
        public string ErrorMessage { get; set; } = "";
    }

}
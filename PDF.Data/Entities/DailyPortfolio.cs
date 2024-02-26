using System;

namespace PDF.Data.Entities
{
    public class DailyPortfolio
    {
        public DateTime HoldingDate { get; set; }

        public decimal MarketValue { get; set; }
    }
}
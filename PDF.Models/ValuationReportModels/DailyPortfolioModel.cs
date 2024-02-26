using System;

namespace PDF.Models.ValuationReportModels
{
    public class DailyPortfolioModel
    {
        public DateTime HoldingDate { get; set; }

        public decimal MarketValue { get; set; }
    }
}
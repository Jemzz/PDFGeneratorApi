using System;

namespace PDF.Data.Entities
{
    public class ReportSummary
    {
        public string ClientName { get; set; }

        public string AccountReference { get; set; }

        public string PortfolioReference { get; set; }

        public string PortfolioName { get; set; }

        public string ProductCode { get; set; }

        public string ProductTitle { get; set; }

        public string StrategyTitle { get; set; }

        public decimal InitialAmount { get; set; }
        public decimal MarketValue { get; set; }
        public string TargetRisk { get; set; }

        public DateTime PortfolioInception { get; set; }
    }
}
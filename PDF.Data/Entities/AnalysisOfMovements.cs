using System;

namespace PDF.Data.Entities
{
    public class AnalysisOfMovements
    {
        public string ValuationRangeType { get; set; }

        public DateTime OpeningDate { get; set; }

        public decimal OpeningValuation { get; set; }

        public decimal CapitalIntroduced { get; set; }

        public decimal CapitalWithdrawn { get; set; }

        public decimal IncomeReceived { get; set; }

        public decimal FeesAndExpensesCharged { get; set; }

        public decimal RealisedProfitOrLoss { get; set; }

        public decimal MarketMovements { get; set; }

        public DateTime ClosingDate { get; set; }

        public decimal ClosingValue { get; set; }

        public decimal ApproximateReturn { get; set; }

        public decimal ApproximatePerformance { get; set; }
    }
}
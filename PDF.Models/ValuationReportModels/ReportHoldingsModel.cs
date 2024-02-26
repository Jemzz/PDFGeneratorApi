namespace PDF.Models.ValuationReportModels
{
    public class ReportHoldingsModel
    {
        public string Holding { get; set; }

        public decimal Units { get; set; }

        public string AssetCurrency { get; set; }

        public decimal Cost { get; set; }

        public decimal LatestPrice { get; set; }

        public decimal GainLoss { get; set; }
        public decimal GainLossPercent { get; set; }
        public decimal MarketValue { get; set; }
    }
}
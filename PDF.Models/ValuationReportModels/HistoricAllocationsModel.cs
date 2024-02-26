using System;

namespace PDF.Models.ValuationReportModels
{
    public class HistoricAllocationsModel
    {
        public DateTime HoldingDate { get; set; }

        public decimal Cash { get; set; }

        public decimal Equity { get; set; }

        public decimal Commodity { get; set; }

        public decimal Alternatives { get; set; }

        public decimal Bonds { get; set; }
        public decimal Property { get; set; }
    }
}
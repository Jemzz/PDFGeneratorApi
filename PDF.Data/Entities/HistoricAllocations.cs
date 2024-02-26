using System;

namespace PDF.Data.Entities
{
    public class HistoricAllocations
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
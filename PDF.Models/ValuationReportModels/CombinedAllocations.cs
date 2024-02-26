using System.Collections.Generic;

namespace PDF.Models.ValuationReportModels
{
    public class CombinedAllocations
    {
        public CombinedAllocations()
        {
            this.Regions = new List<CombinedAllocations>();
            this.Currencies = new List<CombinedAllocations>();
            this.AssetTypes = new List<CombinedAllocations>();
        }

        public string Label { get; set; }

        public string Colour { get; set; }

        public decimal? Percentage { get; set; }

        public List<CombinedAllocations> Regions { get; set; }

        public List<CombinedAllocations> Currencies { get; set; }

        public List<CombinedAllocations> AssetTypes { get; set; }
    }
}
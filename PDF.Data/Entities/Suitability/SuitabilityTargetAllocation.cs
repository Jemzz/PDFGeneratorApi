namespace PDF.Data.Entities.Suitability
{
    public class SuitabilityTargetAllocation
    {
        public decimal OCF { get; set; }
        public decimal AMC { get; set; }
        public string SecurityName { get; set; }
        public string SecurityDescription { get; set; }
        public string AssetClass { get; set; }
        public string AssetType { get; set; }
        public decimal StrategyAmc { get; set; }
        public string StrategyCode { get; set; }
        public string FactsheetHyperlink { get; set; }
        public decimal AllocationWeight { get; set; }
    }
}
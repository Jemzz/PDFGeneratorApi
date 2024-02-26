namespace PDF.Data.Entities.CostDisclosure
{
    public class CostDisclosureOngoingCharge
    {
        public int PortfolioId { get; set; }
        public decimal InvestmentMgntCharge { get; set; }
        public decimal InvestmentMgntPercentage { get; set; }
        public decimal MgntCharge { get; set; }
        public decimal MgntChargePercentage { get; set; }
        public decimal MultiAssetFundCharge { get; set; }
        public decimal MultiAssetFundChargePercentage { get; set; }
        public decimal FundManagerCharge { get; set; }
        public decimal FundManagerChargePercentage { get; set; }
        public decimal RetainedInterest { get; set; }
        public decimal RetainedInterestPercentage { get; set; }
    }
}

namespace PDF.Data.Entities.Suitability
{
    public class SuitabilityPortfilio
    {
        public decimal TotalInvestment { get; set; }
        public decimal TotalHoldings { get; set; }
        public decimal TotalCash { get; set; }
        public decimal RetainedInterestRate { get; set; }
        public decimal RetainedInterestRateValue { get; set; }
        public decimal CashInterestRate { get; set; }
        public decimal CashInterestRateValue { get; set; }
        public decimal InvestmentProportion { get; set; }
        public decimal LowValueAtTerm { get; set; }
        public decimal HighValueAtTerm { get; set; }
        public decimal ExpectedValueAtTerm { get; set; }
        public decimal CostPerMonth { get; set; }
        public decimal ManagementFee { get; set; }
        public decimal ManagementFeeValue { get; set; }
        public decimal FundFee { get; set; }
        public decimal FundFeeValue { get; set; }
        public decimal TotalFees { get; set; }
        public decimal TotalFeesValue { get; set; }
        public decimal EstimatedAnnualCostForMonth { get; set; }
        public decimal EstimatedAnnualCostForFirstYear { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal RetainedInvestmentPerAnnum { get; set; }
        public decimal ReportedValue { get; set; }
        public decimal RegularInvestment { get; set; }

    }
}
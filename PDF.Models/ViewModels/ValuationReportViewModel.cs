using System;
using System.Collections.Generic;
using PDF.Models.ValuationReportModels;

namespace PDF.Models.ViewModels
{
    public class ValuationReportViewModel : BaseModel
    {
        public ValuationReportViewModel()
        {
            this.ReportHoldings = new List<ReportHoldingsModel>();
            this.Allocations = new List<CombinedAllocations>();
            this.AssetExposure = new List<CombinedAllocations>();
            this.AnalysisOfMovements = new List<AnalysisOfMovementsModel>();
            this.CashAccount = new List<CashAccountModel>();
            this.HistoricAllocations = new List<HistoricAllocationsModel>();
            this.DailyPortfolioValues = new List<DailyPortfolioModel>();
            this.Sections = new List<string>();
        }

        public List<ReportHoldingsModel> ReportHoldings { get; set; }

        public ReportSummaryModel ReportSummary { get; set; }

        public CombinedAllocations CompositeAllocations { get; set; }

        public List<CombinedAllocations> Allocations { get; set; }

        public List<CombinedAllocations> AssetExposure { get; set; }

        public List<AnalysisOfMovementsModel> AnalysisOfMovements { get; set; }

        public List<SecurityTradesModel> SecurityTrades { get; set; }

        public List<CashAccountModel> CashAccount { get; set; }

        public List<HistoricAllocationsModel> HistoricAllocations { get; set; }

        public List<DailyPortfolioModel> DailyPortfolioValues { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime AsAtDate => (EndDate ?? DateTime.Now);

        public DateTime? PeriodStartDate =>
            (ReportSummary?.PortfolioInception ?? StartDate) > StartDate.GetValueOrDefault()
                ? ReportSummary?.PortfolioInception
                : StartDate;

        public List<string> Sections { get; set; }
    }
}
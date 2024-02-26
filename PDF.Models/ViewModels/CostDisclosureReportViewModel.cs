using System;
using System.Collections.Generic;
using PDF.Models.CostDisclosureModels;

namespace PDF.Models.ViewModels
{
    public class CostDisclosureReportViewModel : BaseModel
    {
        public CostDisclosureReportViewModel()
        {
            this.AnalysisOfMovements = new List<CostDisclosureAnalysisOfMovementModel>();

        }

        public CostDisclosureSummaryModel ReportSummary { get; set; }

        public List<CostDisclosureAnalysisOfMovementModel> AnalysisOfMovements { get; set; }

        public CostDisclosureOngoingChargeModel OngoingCharge { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime AsAtDate => (EndDate ?? DateTime.Now);

        public DateTime? PeriodStartDate =>
            (ReportSummary?.PortfolioInception ?? StartDate) > StartDate.GetValueOrDefault()
                ? ReportSummary?.PortfolioInception
                : StartDate;
    }
}
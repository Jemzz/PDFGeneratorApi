using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Services.Dtos;

namespace PDF.Services.Interfaces
{
    public interface ICostDisclosureReportService
    {
        Task<CostDisclosureSummaryDto> GetCostDisclosureReportSummary(long portfolioId, DateTime asAtDate);

        Task<List<CostDisclosureAnalysisOfMovementDto>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate);

        Task<CostDisclosureOngoingChargeDto> GetOngoingCharge(long portfolioId, DateTime startDate, DateTime endDate);
    }
}

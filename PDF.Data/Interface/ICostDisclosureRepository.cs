using PDF.Data.Entities.CostDisclosure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDF.Data.Interface
{
    public interface ICostDisclosureRepository
    {
        Task<CostDisclosureSummary> GetCostDisclosureReportSummary(long portfolioId, DateTime asAtDate);

        Task<IEnumerable<CostDisclosureAnalysisOfMovement>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate);

        Task<CostDisclosureOngoingCharge> GetOngoingCharge(long portfolioId, DateTime startDate, DateTime endDate);
    }
}

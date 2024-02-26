using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Data.Entities;

namespace PDF.Data.Interface
{
    public interface IValuationRepository
    {
        Task<IEnumerable<ReportHoldings>> GetReportHoldings(long portfolioId, DateTime asAtDate);

        Task<ReportSummary> GetReportSummary(long portfolioId, DateTime asAtDate);

        Task<IEnumerable<AnalysisOfMovements>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate);

        Task<IEnumerable<SecurityTrades>> GetSecurityTrades(long portfolioId, DateTime startDate, DateTime endDate);

        Task<IEnumerable<CashAccount>> GetCashAccount(long portfolioId, DateTime startDate, DateTime endDate);
    }
}

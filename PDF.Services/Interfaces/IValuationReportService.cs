using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Services.Dtos;

namespace PDF.Services.Interfaces
{
    public interface IValuationReportService
    {
        Task<List<ReportHoldingsDto>> GetReportHoldings(long portfolioId, DateTime asAtDate);

        Task<ReportSummaryDto> GetReportSummary(long portfolioId, DateTime asAtDate);

        Task<List<AnalysisOfMovementsDto>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate);

        Task<List<SecurityTradesDto>> GetSecurityTrades(long portfolioId, DateTime startDate, DateTime endDate);

        Task<List<CashAccountDto>> GetCashAccount(long portfolioId, DateTime startDate, DateTime endDate);
    }
}

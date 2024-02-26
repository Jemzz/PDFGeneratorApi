using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PDF.Data.Entities;
using PDF.Data.Interface;

namespace PDF.Data.Implementation
{
    public class ValuationRepository : RepositoryBase, IValuationRepository
    {
        public ValuationRepository(IOptions<RepositoryOptions> configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ReportHoldings>> GetReportHoldings(long portfolioId, DateTime asAtDate)
        {
            using var cn = Connection;
            const string sql = "reporting.Valuation_Holdings";

            return await cn.QueryAsync<ReportHoldings>(sql, new
            {
                portfolioId,
                asAtDate
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<ReportSummary> GetReportSummary(long portfolioId, DateTime asAtDate)
        {
            using var cn = Connection;
            cn.Open();
            const string sql = "reporting.Valuation_Summary";

            var data = await cn.QueryFirstOrDefaultAsync<ReportSummary>(sql, new
            {
                portfolioId,
                AsAtDate = asAtDate
            }, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<IEnumerable<AnalysisOfMovements>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate)
        {
            using var cn = Connection;
            const string sql = "reporting.Valuation_AnalysisOfMovements";

            return await cn.QueryAsync<AnalysisOfMovements>(sql, new
            {
                portfolioId,
                startDate,
                endDate
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SecurityTrades>> GetSecurityTrades(long portfolioId, DateTime startDate, DateTime endDate)
        {
            using var cn = Connection;
            const string sql = "reporting.Valuation_SecurityTrades";

            return await cn.QueryAsync<SecurityTrades>(sql, new
            {
                portfolioId,
                startDate,
                endDate
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CashAccount>> GetCashAccount(long portfolioId, DateTime startDate, DateTime endDate)
        {
            using var cn = Connection;
            const string sql = "reporting.Valuation_Transactions";

            return await cn.QueryAsync<CashAccount>(sql, new
            {
                portfolioId,
                startDate,
                endDate
            }, commandType: CommandType.StoredProcedure);
        }
    }
}

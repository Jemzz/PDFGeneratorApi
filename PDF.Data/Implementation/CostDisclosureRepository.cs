using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PDF.Data.Entities.CostDisclosure;
using PDF.Data.Interface;

namespace PDF.Data.Implementation
{
    public class CostDisclosureRepository : RepositoryBase, ICostDisclosureRepository
    {
        public CostDisclosureRepository(IOptions<RepositoryOptions> configuration) : base(configuration)
        {
        }

        public async Task<CostDisclosureSummary> GetCostDisclosureReportSummary(long portfolioId, DateTime asAtDate)
        {
            using var cn = Connection;
            cn.Open();
            const string sql = "reporting.CostDisclosure_Summary";

            var data = await cn.QueryFirstOrDefaultAsync<CostDisclosureSummary>(sql, new
            {
                portfolioId,
                AsAtDate = asAtDate
            }, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<IEnumerable<CostDisclosureAnalysisOfMovement>> GetAnalysisOfMovements(long portfolioId, DateTime startDate, DateTime endDate)
        {
            using var cn = Connection;
            const string sql = "reporting.CostDisclosure_AnalysisOfMovements";

            return await cn.QueryAsync<CostDisclosureAnalysisOfMovement>(sql, new
            {
                portfolioId,
                startDate,
                endDate
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<CostDisclosureOngoingCharge> GetOngoingCharge(long portfolioId, DateTime startDate, DateTime endDate)
        {
            using var cn = Connection;
            const string sql = "reporting.CostDisclosure_OngoingCharges";

            return await cn.QueryFirstOrDefaultAsync<CostDisclosureOngoingCharge>(sql, new
            {
                portfolioId,
                startDate,
                endDate
            }, commandType: CommandType.StoredProcedure);
        }
    }
}

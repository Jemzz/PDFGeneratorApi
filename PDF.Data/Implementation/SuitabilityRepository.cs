using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PDF.Data.Entities.Suitability;
using PDF.Data.Interface;

namespace PDF.Data.Implementation
{
    public class SuitabilityRepository : RepositoryBase, ISuitabilityRepository
    {
        public SuitabilityRepository(IOptions<RepositoryOptions> configuration) : base(configuration)
        {
        }

        public async Task<SuitabilityIndividualDetails> GetSuitabilityIndividualDetails(long mandateId)
        {
            using var cn = Connection;
            const string sql = "reporting.Suitability_IndividualDetails";

            return await cn.QueryFirstOrDefaultAsync<SuitabilityIndividualDetails>(sql, new
            {
                mandateId
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SuitabilityAttitudeToRisk>> GetSuitabilityAttitudeToRisk(long mandateId, bool isChangeOfRisk)
        {
            using var cn = Connection;
            const string sql = "reporting.Suitability_AttitudeToRisk";

            return await cn.QueryAsync<SuitabilityAttitudeToRisk>(sql, new
            {
                mandateId,
                isChangeOfRisk
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SuitabilityTargetAllocation>> GetSuitabilityTargetAllocation(long mandateId, bool isChangeOfRisk)
        {
            using var cn = Connection;
            const string sql = "reporting.Suitability_TargetAllocation";

            return await cn.QueryAsync<SuitabilityTargetAllocation>(sql, new
            {
                mandateId,
                isChangeOfRisk
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<SuitabilityPortfilio> GetSuitabilityPortfolioData(long mandateId, bool isChangeOfRisk)
        {
            using var cn = Connection;
            const string sql = "reporting.Suitability_Portfolio";

            return await cn.QueryFirstOrDefaultAsync<SuitabilityPortfilio>(sql, new
            {
                mandateId,
                isChangeOfRisk
            }, commandType: CommandType.StoredProcedure);
        }

        public async Task<SuitabilityPortfilio> GetPostSuitabilityPortfolioData(long mandateId, int reportType, int correlationId)
        {
            using var cn = Connection;
            const string sql = "reporting.PostEnrolment_Suitability_Portfolio";

            return await cn.QueryFirstOrDefaultAsync<SuitabilityPortfilio>(sql, new
            {
                mandateId,
                ReportSubTypeId = reportType,
                CorrelationId = correlationId
            }, commandType: CommandType.StoredProcedure);
        }
    }
}

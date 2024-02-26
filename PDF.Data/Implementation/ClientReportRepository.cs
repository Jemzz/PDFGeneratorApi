using System;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PDF.Core.Options;
using PDF.Data.Entities.ClientReport;

namespace PDF.Data.Implementation
{
    public class ClientReportRepository : RepositoryBase, IClientReportRepository
    {
        private readonly IOptions<ConnectOptions> _connectOptions;

        public ClientReportRepository(IOptions<RepositoryOptions> configuration, IOptions<ConnectOptions> connectOptions) : base(configuration)
        {
            _connectOptions = connectOptions;
        }

        public async Task<IndividualDetails> GetParticipantSummary(long mandateId, long individualId)
        {
            using var cn = MrDbConnection;
            cn.Open();
            const string sql = "reporting.ClientReport_PersonalDetails_Read";

            var data = await cn.QueryFirstOrDefaultAsync<IndividualDetails>(sql, new
            {
                IndividualId = individualId
            }, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<IEnumerable<IndividualAddress>> GetParticipantAddresses(long individualId)
        {
            using var cn = MrDbConnection;
            cn.Open();
            const string sql = "reporting.ClientReport_Addresses_Read";

            var data = await cn.QueryAsync<IndividualAddress>(sql, new
            {
                IndividualId = individualId
            }, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<IndividualContactInformation> GetParticipantContactInfo(long individualId)
        {
            using var cn = MrDbConnection;
            cn.Open();
            const string sql = "reporting.ClientReport_PhoneNumbers_Read";

            var data = await cn.QueryFirstOrDefaultAsync<IndividualContactInformation>(sql, new
            {
                IndividualId = individualId
            }, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<IEnumerable<TaxResidency>> GetParticipantTaxResidencies(long individualId)
        {
            using var cn = MrDbConnection;
            cn.Open();
            const string sql = "reporting.ClientReport_TaxResidencies_Read";

            var data = await cn.QueryAsync<TaxResidency>(sql, new
            {
                IndividualId = individualId
            }, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<Tuple<SummaryMainDetail,
            IEnumerable<SummaryPreviousAddress>,
            IEnumerable<SummaryIsaProvider>,
            IEnumerable<SummaryFinancialDependent>,
            IEnumerable<SummaryTaxDetail>,
            IEnumerable<SummaryInterestedParty>>> ReadIndividualSummaryAsync(long individualId)
        {
            const string sql = "reporting.ClientReport_IndividualSummary_Read";

            using var cn = MrDbConnection;
            cn.Open();

            var reader = await cn.QueryMultipleAsync(sql, new
            {
                UserId = _connectOptions.Value.UserId,
                IndividualId = individualId
            }, commandType: CommandType.StoredProcedure);

            var mainDetail = await reader.ReadFirstOrDefaultAsync<SummaryMainDetail>();
            var previousAddreses = await reader.ReadAsync<SummaryPreviousAddress>();
            var isaProviders = await reader.ReadAsync<SummaryIsaProvider>();
            var financialDependents = await reader.ReadAsync<SummaryFinancialDependent>();
            var taxDetails = await reader.ReadAsync<SummaryTaxDetail>();
            var interestedParties = await reader.ReadAsync<SummaryInterestedParty>();

            var response = new Tuple<SummaryMainDetail,
                IEnumerable<SummaryPreviousAddress>,
                IEnumerable<SummaryIsaProvider>,
                IEnumerable<SummaryFinancialDependent>,
                IEnumerable<SummaryTaxDetail>,
                IEnumerable<SummaryInterestedParty>>(mainDetail, previousAddreses, isaProviders, financialDependents, taxDetails, interestedParties);

            return response;
        }
    }
}

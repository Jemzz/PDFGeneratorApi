using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Data.Entities.ClientReport;

namespace PDF.Data.Implementation
{
    public interface IClientReportRepository
    {
        Task<IndividualDetails> GetParticipantSummary(long mandateId, long individualId);
        Task<IEnumerable<IndividualAddress>> GetParticipantAddresses(long individualId);
        Task<IndividualContactInformation> GetParticipantContactInfo(long individualId);
        Task<IEnumerable<TaxResidency>> GetParticipantTaxResidencies(long individualId);

        Task<Tuple<SummaryMainDetail,
            IEnumerable<SummaryPreviousAddress>,
            IEnumerable<SummaryIsaProvider>,
            IEnumerable<SummaryFinancialDependent>,
            IEnumerable<SummaryTaxDetail>,
            IEnumerable<SummaryInterestedParty>>> ReadIndividualSummaryAsync(long individualId);
    }
}
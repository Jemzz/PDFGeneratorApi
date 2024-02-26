using System.Collections.Generic;

namespace PDF.Services.Dtos.ClientReport;

public class IndividualSummaryReportDataDto
{
    public SummaryMainDetailDto ParticipantMainDetail { get; set; }
    public IEnumerable<SummaryInterestedPartyDto> SummaryInterestedParties { get; set; }
    public IEnumerable<SummaryIsaProviderDto> SummaryIsaProviders { get; set; }
    public IEnumerable<SummaryPreviousAddressDto> SummaryPreviousAddresses { get; set; }
    public IEnumerable<SummaryTaxDetailDto> SummaryTaxDetails { get; set; }
    public IEnumerable<SummaryFinancialDependentDto> SummaryFinancialDependents { get; set; }
}
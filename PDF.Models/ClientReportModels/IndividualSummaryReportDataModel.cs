using System.Collections.Generic;

namespace PDF.Models.ClientReportModels;

public class IndividualSummaryReportDataModel
{
    public SummaryMainDetailModel ParticipantMainDetail { get; set; }
    public IEnumerable<SummaryInterestedPartyModel> SummaryInterestedParties { get; set; }
    public IEnumerable<SummaryIsaProviderModel> SummaryIsaProviders { get; set; }
    public IEnumerable<SummaryPreviousAddressModel> SummaryPreviousAddresses { get; set; }
    public IEnumerable<SummaryTaxDetailModel> SummaryTaxDetails { get; set; }
    public IEnumerable<SummaryFinancialDependentModel> SummaryFinancialDependents { get; set; }
}
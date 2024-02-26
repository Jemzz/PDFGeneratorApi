using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Models.ClientReportModels;
using PDF.Models.SuitabilityReportModels;

namespace PDF.Models.ViewModels
{
    public class PrimaryParticipantSummaryViewModel : BaseModel
    {
        //public RequestedParticipantPersonalDetailsModel PersonalDetail { get; set; }
        //public IEnumerable<ParticipantTaxResidencyModel> TaxResidencies { get; set; }
        //public ParticipantPersonalDetailModel OtherApplicantDetail { get; set; }
        //public ResidentialAddressModel CurrentResidentialAddress { get; set; }
        //public List<InterestedPartyModel> InterestedParties { get; set; }
        //public List<ResidentialAddressModel> PreviousAddresses { get; set; }
        //public ResidentialAddressModel PostalAddress { get; set; }
        //public ParticipantContactInformationModel ContactDetails { get; set; }
        public IndividualSummaryReportDataModel IndividualDetails { get; set; }
    }
}

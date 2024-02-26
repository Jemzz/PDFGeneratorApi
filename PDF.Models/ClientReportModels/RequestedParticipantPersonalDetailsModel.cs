namespace PDF.Models.ClientReportModels;

public class RequestedParticipantPersonalDetailsModel : ParticipantPersonalDetailModel
{
    public string AccountType { get; set; }
    public string MandateReference { get; set; }
    public string CustomerReference { get; set; }
    public bool IsMainApplicant { get; set; }
    public string PlaceOfBirth { get; set; }
    public string TownOfBirth { get; set; }
    public string CountryOfDomicile { get; set; }
    public string[] Nationality { get; set; }
    public TaxEmploymentModel TaxEmployment { get; set; }
}
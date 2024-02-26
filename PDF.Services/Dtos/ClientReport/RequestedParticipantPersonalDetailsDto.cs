namespace PDF.Services.Dtos.ClientReport;

public class RequestedParticipantPersonalDetailsDto : ParticipantPersonalDetailDto
{
    public string AccountType { get; set; }
    public string MandateReference { get; set; }
    public string CustomerReference { get; set; }
    public string PlaceOfBirth { get; set; }
    public string TownOfBirth { get; set; }
    public string CountryOfDomicile { get; set; }
    public string[] Nationality { get; set; }
    public TaxEmploymentDto TaxEmployment { get; set; }

}

public class ParticipantTaxResidencyDto
{
    public string CountryName { get; set; }
    public string TaxIdNo { get; set; }
    public double MaxMargin { get; set; }
    public bool IsPrimary { get; set; }
}
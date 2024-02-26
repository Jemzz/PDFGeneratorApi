namespace PDF.Models.ClientReportModels;

public class ParticipantTaxResidencyModel
{
    public string CountryName { get; set; }
    public string TaxIdNo { get; set; }
    public double MaxMargin { get; set; }
    public bool IsPrimary { get; set; }
}
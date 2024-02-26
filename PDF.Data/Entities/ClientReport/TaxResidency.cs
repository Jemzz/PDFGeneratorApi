namespace PDF.Data.Entities.ClientReport;

public class TaxResidency
{
    public string CountryName { get; set; }
    public string TaxIdNo { get; set; }
    public double MaxMargin { get; set; }
    public bool IsPrimary { get; set; }
}
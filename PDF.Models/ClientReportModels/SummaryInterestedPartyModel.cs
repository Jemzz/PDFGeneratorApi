namespace PDF.Models.ClientReportModels;

public class SummaryInterestedPartyModel
{
    public string Relationship { get; set; }
    public string CompanyName { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string ResidentialAddress { get; set; }
    public string ResidentialAddressPostCode { get; set; }
    public string PhoneType { get; set; }
    public string PhoneCountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public string OnlineAccess { get; set; }
    public string QuarterlyStatements { get; set; }
    public string QuarterlyValuations { get; set; }
    public string YearEndTaxStatement { get; set; }
    public string ContractNotes { get; set; }
    public string Invitations { get; set; }
    public string AuthorizationToAcceptInstruction { get; set; }
}
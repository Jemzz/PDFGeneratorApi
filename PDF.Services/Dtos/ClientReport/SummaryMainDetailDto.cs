namespace PDF.Services.Dtos.ClientReport;

public class SummaryMainDetailDto
{
    public string AccountType { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Relationship { get; set; }
    public string MaidenName { get; set; }
    public string KnownByName { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public string PlaceOfBirth { get; set; }
    public string CountryOfDomicile { get; set; }
    public string Nationality { get; set; }
    public string ResidentialAddress { get; set; }
    public string ResidentialAddressPostCode { get; set; }
    public string ResidentialAddressFrom { get; set; }
    public string ResidentialSubBuilding { get; set; }
    public string ResidentialBuildingNumber { get; set; }
    public string ResidentialBuildingName { get; set; }
    public string ResidentialStreet { get; set; }
    public string ResidentialCity { get; set; }
    public string ResidentialProvinceName { get; set; }
    public string ResidentialProvinceCode { get; set; }
    public string ResidentialDistrict { get; set; }
    public string ResidentialCountry { get; set; }
    public string PostalAddress { get; set; }
    public string PostalAddressPostCode { get; set; }
    public string PostalAddressFrom { get; set; }
    public string PostalSubBuilding { get; set; }
    public string PostalBuildingNumber { get; set; }
    public string PostalBuildingName { get; set; }
    public string PostalStreet { get; set; }
    public string PostalCity { get; set; }
    public string PostalProvinceName { get; set; }
    public string PostalProvinceCode { get; set; }
    public string PostalDistrict { get; set; }
    public string PostalCountry { get; set; }
    public string MobilePhone { get; set; }
    public string HomePhone { get; set; }
    public string BusinessPhone {get;set;}
	public string EmploymentStatus { get; set; }
    public string EmploymentPosition { get; set; }
    public string EmploymentStartDate { get; set; }
    public string EmploymentOverseas {get;set;}
	public string YearsWorkedAbroad { get; set; }
    public string YearsWorkedDuration { get; set; }
    public string YearsWorkedReturnCountry { get; set; }
    public string DirectorOfPublicQuotedCompany {get;set;}
    public string IsPEP {get;set;}
	public string PersonalSalary { get; set; }
    public string PersonalSavingsIncome { get; set; }
    public string PersonalInvestmentIncome { get; set; }
    public string PersonalPensionIncome {get;set;}
	public string PersonalPropertyIncome { get; set; }
    public string PersonalOtherSources { get; set; }
    public string PartnerSalary { get; set; }
    public string PartnerSavingsIncome { get; set; }
    public string PartnerInvestmentIncome { get; set; }
    public string PartnerPensionIncome {get;set;}
	public string PartnerPropertyIncome { get; set; }
	public string PartnerOtherSources { get; set; }
    public string JointSalary { get; set; }
    public string JointSavingsIncome { get; set; }
    public string JointInvestmentIncome { get; set; }
    public string JointPensionIncome {get;set;}
	public string JointPropertyIncome { get; set; }
    public string JointOtherSources { get; set; }
    public string InvestmentIncomeTaxableIncome { get; set; }
    public string InvestmentIncomePaid { get; set; }
    public string InvestmentIncomeAnnualSpendingRequired {get;set;}
	public string AnnualSpendingIncomeRequired { get; set; }
    public string AnnualSpendingIncomeFrequency { get; set; }
    public string OtherInvestmentRequirements { get; set; }
    public string PartnerInvestmentAssets { get; set; }
    public string PartnerInsuranceLinkedPolicies {get;set;}
	public string PartnerOtherSavings { get; set; }
    public string PartnerMainResidence { get; set; }
    public string PartnerOtherProperties { get; set; }
    public string PartnerSignificantAssets { get; set; }
    public string PersonalBankBuildingSocietyAssets { get; set; }
    public string PersonalInvestmentAssets { get; set; }
    public string PersonalInsuranceLinkedPolicies {get;set;}
	public string PersonalOtherSavings { get; set; }
    public string PersonalMainResidence { get; set; }
    public string PersonalOtherProperties { get; set; }
    public string PersonalSignificantAssets { get; set; }
    public string PartnerBankBuildingSocietyAssets { get; set; }
    public string JointBankBuildingSocietyAssets { get; set; }
    public string JointInvestmentAssets { get; set; }
    public string JointInsuranceLinkedPolicies {get;set;}
	public string JointOtherSavings { get; set; }
    public string JointMainResidence { get; set; }
    public string JointOtherProperties { get; set; }
    public string JointSignificantAssets { get; set; }
    public string TotalAssetsSelf { get; set; }
    public string TotalAssetsPartner { get; set; }
    public string TotalAssetsJoint { get; set; }
    public string TotalAssetsPortfolioIsolation {get;set;}
	public string PersonalLiabilitiesMortgage { get; set; }
    public string PersonalLiabilitiesLoans { get; set; }
    public string PersonalLiabilitiesOverdraft { get; set; }
    public string PersonalLiabilitiesMortgageRedemption { get; set; }
    public string PersonalLiabilitiesLoanRedemption {get;set;}
	public string PersonalLiabilitiesOther {get;set;}
	public string PartnerLiabilitiesMortgage { get; set; }
    public string PartnerLiabilitiesLoans { get; set; }
    public string PartnerLiabilitiesOverdraft { get; set; }
    public string PartnerLiabilitiesMortgageRedemption { get; set; }
    public string PartnerLiabilitiesLoanRedemption {get;set;}
	public string PartnerLiabilitiesOther {get;set;}
	public string JointLiabilitiesMortgage { get; set; }
    public string JointLiabilitiesLoans { get; set; }
    public string JointLiabilitiesOverdraft { get; set; }
    public string JointLiabilitiesMortgageRedemption { get; set; }
    public string JointLiabilitiesLoanRedemption {get;set;}
	public string JointLiabilitiesOther {get;set;}
	public string RetirementProvisionSelf { get; set; }
    public string RetirementProvisionPartner { get; set; }
    public string SourceOfFundsSourceOfCash { get; set; }
    public string SourceOfFundsTransferredFrom { get; set; }
    public string SourceOfFundsMeansOfTransfer { get; set; }
    public string BankAccountName { get; set; }
    public string BankAccountSortCode { get; set; }
    public string BankAccountNumber { get; set; }
    public string BankAccountBic {get;set;}
	public string BankAccountIBAN {get;set;}
	public string InvestmentAmountSecurities { get; set; }
    public string InvestmentAccountCash { get; set; }
    public string InvestmentAmountToBeTransferred {get;set;}
	public string TaxInformationPortfolioCurrency { get; set; }
    public string TaxInformationCustody { get; set; }
    public string TaxInformationMainCGTRecords {get;set;}
	public string TaxInformationTaxationYearEnd { get; set; }
    public string TaxInformationQuarterlyYearEnd { get; set; }
    public string IsaAccountHoldIsa {get;set;}
	public string IsaAccountCurrentYearSubscription {get;set;}
	public string IsaAccountOpenIsaAccount {get;set;}
	public string IsaAccountToBeTransferred {get;set;}
	public string IsaAccountIncomePreferences {get;set;}
    public string QuarterlyReviewLetters {get;set;}
	public string QuarterlyValuations {get;set;}
	public string YearEndTaxStatements {get;set;}
	public string ContractNotes {get;set;}
    public string IsOnlineAccessRequired { get; set; }
    public string SelectPeriod {get;set;}
    public string TaxCountry {get;set;}
	public string TaxNumber {get;set;}
	public string DateOfTaxResidency {get;set;}
    public bool IsMainApplicant { get; set; }
    public string CustomerReference { get; set; }
    public string MandateReference { get; set; }
    public string FullName { get; set; }
    public string TownOfBirth { get; set; }
    public string SecondNationality { get; set; }
    public string DirectorshipDetails { get; set; }
    public string PepDetails { get; set; }
    public string JointTitle { get; set; }
    public string JointFirstName { get; set; }
    public string JointMiddleName { get; set; }
    public string JointSurname { get; set; }
    public string JointMaidenName { get; set; }
    public string JointOtherTitle { get; set; }
    public string JointKnownByName { get; set; }
    public string JointEmail { get; set; }
    public string JointDateOfBirth { get; set; }
    public string JointGender { get; set; }
    public string JointMaritalStatus { get; set; }
    public string JointRelationship { get; set; }
    public bool HasInterestedParties { get; set; }
    public string TotalIncomeSelf { get; set; }
    public string TotalIncomePartner { get; set; }
    public string TotalIncomeJoint { get; set; }
    public string TotalIncomeCombined { get; set; }
    public string TotalSalary { get; set; }
    public string TotalSavings { get; set; }
    public string TotalInvestments { get; set; }
    public string TotalPensions { get; set; }
    public string TotalProperty { get; set; }
    public string TotalOtherSources { get; set; }
    public string TotalBankBuildingSocietyAssets { get; set; }
    public string TotalInvestmentAssets { get; set; }
    public string TotalInsuranceLinkedPolicies { get; set; }
    public string TotalOtherSavings { get; set; }
    public string TotalMainResidence { get; set; }
    public string TotalOtherProperties { get; set; }
    public string TotalSignificantAssets { get; set; }
    public string TotalAssetsCombined { get; set; }
    public string TotalLiabilitiesMortgage { get; set; }
    public string TotalLiabilitiesLoans { get; set; }
    public string TotalLiabilitiesOverdraft { get; set; }
    public string TotalLiabilitiesOther { get; set; }
    public string TotalLiabilitiesSelf { get; set; }
    public string TotalLiabilitiesPartner { get; set; }
    public string TotalLiabilitiesJoint { get; set; }
    public string TotalLiabilitiesCombined { get; set; }
    public string HasFinancialDependents { get; set; }
}
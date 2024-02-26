using System;

namespace PDF.Models.SuitabilityReportModels
{
    public class SuitabilityIndividualDetailsModel
    {

        public long IndividualId { get; set; }
        public int? TitleId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string PortfolioReference { get; set; }
        public string MandateRererence { get; set; }
        public string PortfolioInvestableProportionName { get; set; }
        public int? EmploymentStatusTypeId { get; set; }
        public string EmploymentStatusType { get; set; }
        public string EmployerName { get; set; }
        public string Position { get; set; }
        public DateTime? PositionStartDate { get; set; }
        public decimal? AnnualGrossIncome { get; set; }
        public decimal? Salary { get; set; }
        public decimal? MonthlyDisposableIncome { get; set; }
        public int? CountryOfBirthId { get; set; }
        public string CountryOfBirth { get; set; }
        public int? CountryOfNationalityId { get; set; }
        public string CountryOfNationality { get; set; }
        public int? CountryOfSecondNationalityId { get; set; }
        public bool IsDualNationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int? MaritalStatusTypeId { get; set; }
        public string MaritalStatusType { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PortfolioTitle { get; set; }
        public string PortfolioTypeCode { get; set; }
        public DateTime? PortfolioActivationDate { get; set; }
        public decimal? InitialTopUp { get; set; }
        public bool IsPartPension { get; set; }
        public decimal? InitialTargetAmount { get; set; }
        public decimal? InitialYearsToInvest { get; set; }
        public decimal? InitialAmount { get; set; }
        public decimal? RequestedAmount { get; set; }
        public decimal? TransferValue { get; set; }
        public string TargetRiskLabel { get; set; }
        public string TargetRiskDescription { get; set; }
        public string StrategyCode { get; set; }
        public int? SourceOfFundsId { get; set; }
        public string SourceOfFundsName { get; set; }
        public DateTime GeneratedDateTime { get; set; }

        public int? Age
        {
            get
            {
                if (DateOfBirth.HasValue)
                {
                    return GetAge(DateOfBirth.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        public static int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }
    }
}
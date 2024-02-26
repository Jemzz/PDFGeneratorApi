using System;

namespace PDF.Data.Entities.ClientReport
{
    public class IndividualDetails
    {
        public string ReferenceId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string MaidenName { get; set; }
        public string KnownByName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string GenderTypeName { get; set; }
        public string MaritalStatusTypeName { get; set; }
        public string CountryOfBirthCountryName { get; set; }
        public string TownOfBirth { get; set; }
        public string CountryOfDomicileCountryName { get; set; }
        public string CountryOfNationalityName { get; set; }
        public bool IsDualNationality { get; set; }
        public string CountryOfSecondNationalityName { get; set; }
        public string EmploymentStatusTypeName { get; set; }
        public string Position { get; set; }
        public DateTime? PositionStartDate { get; set; }
        public double Salary { get; set; }
        public bool? IsDirectorship { get; set; }
        public string DirectorshipDetails { get; set; }
        public bool? IsPep { get; set; }
        public string PepDetails { get; set; }
        public string EmailAddress { get; set; }
    }
}

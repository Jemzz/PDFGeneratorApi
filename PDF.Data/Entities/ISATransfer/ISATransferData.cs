using System;

namespace PDF.Data.Entities.ISATransfer
{
    public class ISATransferData
    {
        public long IndividualId { get; set; }
        public long MandateId { get; set; }
        public int PortfolioId { get; set; }
        public string ExternalReferenceId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime TransferDate { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostZipCard { get; set; }
        public string CountryName { get; set; }
        public string Nationality { get; set; }
        public int IsaTransferId { get; set; }
        public string TransferReference { get; set; }
        public decimal TransferValue { get; set; }
        public int IsaTypeId { get; set; }
        public string IsaTypeName { get; set; }
        public int IsaProviderId { get; set; }
        public string ProviderAddress { get; set; }
        public string ProviderRegisteredName { get; set; }
        public int IsaTransferTypeId { get; set; }
        public string IsaTransferTypeName { get; set; }
        public string ChildTitle { get; set; }
        public string ChildFirstName { get; set; }
        public string ChildMiddleName { get; set; }
        public string ChildLastName { get; set; }
        public DateTime ChildDateOfBirth { get; set; }
        public string ChildNationality { get; set; }
        public string ChildAddress { get; set; }
        public string ChildPostZipCard { get; set; }
        public string RelationshipTypeName { get; set; }
    }
}

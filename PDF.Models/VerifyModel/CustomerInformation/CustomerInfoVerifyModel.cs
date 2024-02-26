using System;

namespace PDF.Models.VerifyModel.CustomerInformation
{
    public class CustomerInfoVerifyModel
    {
        public string Title { get; set; }
        public PersonalDetailModel PersonalDetails { get; set; }
        public CurrentResidentialAddressModel CurrentResidentialAddress { get; set; }
        public ContactInformationModel ContactInformation { get; set; }
        public DateTime? TermsAgreed { get; set; }
    }
}
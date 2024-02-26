using System.Collections.Generic;

namespace PDF.Models.VerifyModel.CustomerInformation
{
    public class PersonalDetailModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string CustomerReference { get; set; }
        public List<FormerNameDetails> FormerNameDetails { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string[] Nationality { get; set; }
    }
}
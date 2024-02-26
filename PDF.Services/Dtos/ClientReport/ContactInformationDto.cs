namespace PDF.Services.Dtos.ClientReport
{

    //public class ParticipantInfoDto
    //{
    //    public string AccountType { get; set; }
    //    public string MandateReference { get; set; }
    //    public string CustomerReference { get; set; }
    //    public RequestedParticipantPersonalDetailsDto PersonalDetail { get; set; }
    //    public ParticipantPersonalDetailDto JointApplicantDetail { get; set; }
    //    public CurrentResidentialAddressDto CurrentResidentialAddress { get; set; }
    //    public List<CurrentResidentialAddressDto> PreviousAddresses { get; set; }
    //    public CurrentResidentialAddressDto PostalAddress { get; set; }
    //    public ContactInformationDto ContactDetails { get; set; }

    //}

    public class ParticipantContactInformationDto
    {
        public string Mobile { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
    }
}

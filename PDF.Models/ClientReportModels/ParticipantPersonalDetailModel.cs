using System;

namespace PDF.Models.ClientReportModels;

public class ParticipantPersonalDetailModel
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Surname { get; set; }
    public string MaidenName { get; set; }
    public string KnownAs { get; set; }
    public string DateOfBirth { get; set; }
    public string Sex { get; set; }
    public string MaritalStatus { get; set; }
    public string Relationship { get; set; }
    public string EmailAddress { get; set; }
}
using System;

namespace PDF.Services.Dtos.ClientReport;

public class ParticipantPersonalDetailDto
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Surname { get; set; }
    public string MaidenName { get; set; }
    public string KnownAs { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; }
    public string MaritalStatus { get; set; }
    public string EmailAddress { get; set; }
    public string Relationship { get; set; }
}
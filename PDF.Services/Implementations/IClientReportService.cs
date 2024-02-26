using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Services.Dtos.ClientReport;

namespace PDF.Services.Implementations;

public interface IClientReportService
{
    Task<RequestedParticipantPersonalDetailsDto> GetParticipantPersonalDetails(long mandateId, long individualId);
    Task<ParticipantAddressDetailsDto> GetParticipantAddresses(long individualId);
    Task<ParticipantContactInformationDto> GetParticipantContactInfo(long individualId);
    Task<IEnumerable<ParticipantTaxResidencyDto>> GetParticipantTaxResidencies(long individualId);
    Task<IndividualSummaryReportDataDto> GetParticipantSummaryDetails(long individualId);
}
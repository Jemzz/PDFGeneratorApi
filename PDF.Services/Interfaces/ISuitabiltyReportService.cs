using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Services.Dtos;

namespace PDF.Services.Interfaces
{
    public interface ISuitabilityReportService
    {
        Task<SuitabilityIndividualDetailsDto> GetSuitabilityIndividualDetails(long mandateId, bool isChangeOfRisk);
        Task<List<SuitabilityAttitudeToRiskDto>> GetSuitabilityAttitudeToRisk(long mandateId, bool isChangeOfRisk);
        Task<List<SuitabilityTargetAllocationDto>> GetSuitabilityTargetAllocation(long mandateId, bool isChangeOfRisk);
        Task<SuitabilityPortfilioDto> GetSuitabilityPortfolioData(long mandateId, bool isChangeOfRisk);
        Task<SuitabilityPortfilioDto> GetPostSuitabilityPortfolioData(long mandateId, int reportType, int correlationId);
    }
}

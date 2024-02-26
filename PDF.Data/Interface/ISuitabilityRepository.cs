using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Data.Entities.Suitability;

namespace PDF.Data.Interface
{
    public interface ISuitabilityRepository
    {
        Task<SuitabilityIndividualDetails> GetSuitabilityIndividualDetails(long mandateId);
        Task<IEnumerable<SuitabilityAttitudeToRisk>> GetSuitabilityAttitudeToRisk(long mandateId, bool isChangeOfRisk);
        Task<IEnumerable<SuitabilityTargetAllocation>> GetSuitabilityTargetAllocation(long mandateId, bool isChangeOfRisk);
        Task<SuitabilityPortfilio> GetSuitabilityPortfolioData(long mandateId, bool isChangeOfRisk);
        Task<SuitabilityPortfilio> GetPostSuitabilityPortfolioData(long mandateId, int reportType, int correlationId);

    }
}

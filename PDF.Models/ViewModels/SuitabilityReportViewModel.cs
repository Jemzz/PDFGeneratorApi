using System.Collections.Generic;
using PDF.Models.SuitabilityReportModels;

namespace PDF.Models.ViewModels
{
    public class SuitabilityReportViewModel : BaseModel
    {
        public SuitabilityReportViewModel()
        {
            this.AssetData = new List<SuitabilityAttitudeToRiskModel>();
            this.TargetAllocatedData = new List<SuitabilityAttitudeToRiskModel>();
            this.AttitudeToRisk = new List<SuitabilityAttitudeToRiskModel>();
            this.TargetAllocation = new List<SuitabilityTargetAllocationModel>();
        }

        public SuitabilityIndividualDetailsModel Suitability { get; set; }

        public List<SuitabilityAttitudeToRiskModel> AssetData { get; set; }

        public List<SuitabilityAttitudeToRiskModel> TargetAllocatedData { get; set; }

        public List<SuitabilityTargetAllocationModel> TargetAllocation { get; set; }

        public SuitabilityPortfilioModel PortfolioData { get; set; }

        public List<SuitabilityAttitudeToRiskModel> AttitudeToRisk { get; set; }

        public bool IsChangeOfRisk { get; set; }
    }
}
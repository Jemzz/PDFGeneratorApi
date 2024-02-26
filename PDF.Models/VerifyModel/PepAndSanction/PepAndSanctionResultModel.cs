using System.Collections.Generic;

namespace PDF.Models.VerifyModel.PepAndSanction
{
    public class PepAndSanctionResultModel
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public List<PepAndSanctionReasonModel> Reasons { get; set; }
    }
}

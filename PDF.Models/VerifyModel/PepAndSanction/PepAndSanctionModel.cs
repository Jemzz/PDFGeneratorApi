using System.Collections.Generic;
using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.PepAndSanction
{
    public class PepAndSanctionModel
    {
        public PepAndSanctionModel()
        {
            Results = new List<PepAndSanctionResultModel>();
        }

        public string Title { get; set; }
        public PepAndSanctionHeaderModel Header { get; set; }
        public PepCheckModel PepCheck { get; set; }
        public ApprovalCommentModel ApprovalComment { get; set; }
        public PepAndSanctionsCheckModel SanctionsCheck { get; set; }
        public List<PepAndSanctionResultModel> Results { get; set; }
    }
}

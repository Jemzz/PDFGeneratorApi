using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.AdverseMedia
{
    public class AdverseMediaModel
    {
        public string Title { get; set; }
        public AdverseMediaHeaderModel Header { get; set; }
        public ApprovalCommentModel ApprovalComment { get; set; }
        public AdverseMediaDetailsModel AdverseMediaDetails { get; set; }
    }
}

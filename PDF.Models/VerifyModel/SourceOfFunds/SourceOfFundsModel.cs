using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.SourceOfFunds
{
    public class SourceOfFundsModel
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public ApprovalCommentModel ApprovalComment { get; set; }
        public SourceOfFundsAmountModel SourceOfFunds { get; set; }
        public SourceOfFundsTypesModel SourceOfFundTypes { get; set; }
    }
}

using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.Bank
{
    public class BankModel
    {
        public BankHeaderModel Header { get; set; }

        public ApprovalCommentModel ApprovalComment { get; set; }
        public BankResultModel Results { get; set; }
    }
}

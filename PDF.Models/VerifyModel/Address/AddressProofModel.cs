using System;
using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.Address
{
    public class AddressProofModel
    {
        public ApprovalCommentModel ApprovalComment { get; set; }
        public string DocumentImage { get; set; }
        public string Description { get; set; }
        public string DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
        public string Title { get; set; }
        public string Result { get; set; }
    }
}

using System.Collections.Generic;
using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.Address
{
    public class AddressVerificationModel
    {
        public AddressVerificationModel()
        {
            Results = new List<AddressSourceModel>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public AddressHeaderModel Header { get; set; }
        public ApprovalCommentModel ApprovalComment { get; set; }
        public List<AddressSourceModel> Results { get; set; }
    }
}

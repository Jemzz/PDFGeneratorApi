using System.Collections.Generic;

namespace PDF.Models.VerifyModel.Address
{
    public class AddressSourceModel
    {
        public AddressSourceModel()
        {
            Reasons = new List<AddressVerificationReasonModel>();
        }

        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public List<AddressVerificationReasonModel> Reasons { get; set; }
    }
}

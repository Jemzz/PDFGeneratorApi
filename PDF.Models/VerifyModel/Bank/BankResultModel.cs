using System.Collections.Generic;

namespace PDF.Models.VerifyModel.Bank
{
    public class BankResultModel
    {
        public BankResultModel()
        {
            Reasons = new List<BankReasonModel>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<BankReasonModel> Reasons { get; set; }
    }
}

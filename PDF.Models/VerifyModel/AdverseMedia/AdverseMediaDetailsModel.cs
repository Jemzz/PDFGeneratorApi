using System.Collections.Generic;

namespace PDF.Models.VerifyModel.AdverseMedia
{
    public class AdverseMediaDetailsModel
    {
        public AdverseMediaDetailsModel()
        {
            Details = new List<AdverseMediaDetailsResultsModel>();
        }

        public string Status { get; set; }
        public List<AdverseMediaDetailsResultsModel> Details { get; set; }
    }
}

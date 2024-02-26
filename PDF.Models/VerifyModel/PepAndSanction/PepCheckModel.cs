using System.Collections.Generic;

namespace PDF.Models.VerifyModel.PepAndSanction
{
    public class PepCheckModel
    {
        public PepCheckModel()
        {
            Details = new List<PepCheckDetailsModel>();
        }

        public string Status { get; set; }
        public string Reason { get; set; }
        public string Country { get; set; }
        public List<PepCheckDetailsModel> Details { get; set; }
    }
}

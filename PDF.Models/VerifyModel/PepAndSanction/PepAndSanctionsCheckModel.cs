using System.Collections.Generic;

namespace PDF.Models.VerifyModel.PepAndSanction
{
    public class PepAndSanctionsCheckModel
    {
        public PepAndSanctionsCheckModel()
        {
            Details = new List<PepAndSanctionsCheckDetail>();
        }

        public string Status { get; set; }
        public string Reason { get; set; }
        public List<PepAndSanctionsCheckDetail> Details { get; set; }
    }
}

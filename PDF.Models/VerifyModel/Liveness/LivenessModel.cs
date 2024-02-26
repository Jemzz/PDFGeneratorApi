using System.Collections.Generic;

namespace PDF.Models.VerifyModel.Liveness
{
    public class LivenessModel
    {
        public LivenessModel()
        {
            Images = new List<LivenessImagesModel>();
        }

        public string Status { get; set; }
        public string Title { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDescription { get; set; }
        public List<LivenessImagesModel> Images { get; set; }
    }
}
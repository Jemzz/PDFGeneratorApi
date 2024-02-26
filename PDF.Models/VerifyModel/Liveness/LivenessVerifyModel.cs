using System.Collections.Generic;
using PDF.Models.VerifyModel.Comments;

namespace PDF.Models.VerifyModel.Liveness
{
    public class LivenessVerifyModel
    {
        public LivenessVerifyModel()
        {
            Summary = new List<LivenessSummaryModel>();
            //SummaryImages = new List<LivenessImagesModel>();
            Details = new List<LivenessRecognisedDocumentDetailModel>();
            Images = new List<LivenessImagesModel>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public LivenessHeaderModel Header { get; set; }
        public List<LivenessSummaryModel> Summary { get; set; }
        //public List<LivenessImagesModel> SummaryImages { get; set; }
        public LivenessVerifiedDocumentModel VerifiedDocument { get; set; }
        public ApprovalCommentModel ApprovalComment { get; set; }
        public List<LivenessRecognisedDocumentDetailModel> Details { get; set; }
        public LivenessModel Liveness { get; set; }
        public List<LivenessImagesModel> Images { get; set; }
        public LivenessVerifyFaceMatchModel VerifyFaceMatch { get; set; }
    }
}

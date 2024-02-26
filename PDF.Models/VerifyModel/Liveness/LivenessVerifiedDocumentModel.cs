namespace PDF.Models.VerifyModel.Liveness
{
    public class LivenessVerifiedDocumentModel
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public string RecognisedDocument { get; set; }
        public string ExpectedDocument { get; set; }
    }
}
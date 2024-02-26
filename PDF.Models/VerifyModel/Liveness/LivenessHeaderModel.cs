namespace PDF.Models.VerifyModel.Liveness
{
    public class LivenessHeaderModel
    {
        public string Status { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string CountryName { get; set; }
        public string InitiatedDate { get; set; }
    }
}
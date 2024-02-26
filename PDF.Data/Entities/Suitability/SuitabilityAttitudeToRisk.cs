namespace PDF.Data.Entities.Suitability
{
    public class SuitabilityAttitudeToRisk
    {
        public int QuestionOrder { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string ResponseText { get; set; }
        public int ResponseOrder { get; set; }
        public long IndividualId { get; set; }
        public int SelectedResponseId { get; set; }
        public int SelectedResponseOrder { get; set; }
        public string DisplayText { get; set; }
    }
}
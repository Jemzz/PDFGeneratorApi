using System.Collections.Generic;

namespace PDF.Models.SuitabilityReportModels
{
    public class SuitabilityAttitudeToRiskModel
    {
        public SuitabilityAttitudeToRiskModel()
        {
            this.Answers = new List<QuestionAnswerModel>();
        }

        public string Question { get; set; }
        public int QuestionOrder { get; set; }
        public int SelectedResponse { get; set; }

        public List<QuestionAnswerModel> Answers { get; set; }
    }
}
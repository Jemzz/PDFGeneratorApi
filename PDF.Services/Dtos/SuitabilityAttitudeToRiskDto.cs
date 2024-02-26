using System.Collections.Generic;

namespace PDF.Services.Dtos
{
    public class SuitabilityAttitudeToRiskDto
    {
        public SuitabilityAttitudeToRiskDto()
        {
            this.Answers = new List<QuestionAnswerDto>();
        }

        public string Question { get; set; }
        public int QuestionOrder { get; set; }
        public int SelectedResponse { get; set; }

        public List<QuestionAnswerDto> Answers { get; set; }
    }
}

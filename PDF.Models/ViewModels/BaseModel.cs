using System.Collections.Generic;

namespace PDF.Models.ViewModels
{
    public class BaseModel : IBaseModel
    {
        public BaseModel()
        {
            this.ErrorList = new List<string>();
            this.AdditionalContent = new Dictionary<string, string>();
        }

        public string Css { get; set; }

        public string FirstPageCss { get; set; }

        public string LayoutPath { get; set; }

        public string ViewPath { get; set; }

        public string FileName { get; set; }

        public string SpecificPageViewPath { get; set; }

        public string ReportName { get; set; }
        public string ReportRender { get; set; }

        public List<string> ErrorList { get; set; }

        public Dictionary<string, string> AdditionalContent { get; set; }
        public byte[] ReportData { get; set; }
        public int? ReportSubType { get; set; }
        public int? Mode { get; set; }
    }
}
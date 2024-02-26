using System.Collections.Generic;

namespace PDF.Models.ViewModels
{
    public interface IBaseModel
    {
        string Css { get; set; }
        string FirstPageCss { get; set; }
        string LayoutPath { get; set; }
        string ViewPath { get; set; }
        string FileName { get; set; }
        string ReportName { get; set; }
        string SpecificPageViewPath { get; set; }
        byte[] ReportData { get; set; }
        string ReportRender { get; set; }
        int? ReportSubType { get; set; }
        int? Mode { get; set; }
        List<string> ErrorList { get; set; }
        Dictionary<string, string> AdditionalContent { get; set; }
    }
}
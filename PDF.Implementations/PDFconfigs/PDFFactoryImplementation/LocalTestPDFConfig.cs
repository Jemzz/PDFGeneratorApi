using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation
{
    public class LocalTestPDFConfig : PDFAbstractConfig
    {
        public override async Task<byte[]> BuildPDF(string mainContent, Dictionary<string, string> additionalContent)
        {
            var pdf = new IronPdf.ChromePdfRenderer();
            //pdf.RenderingOptions.FitToPaperMode = IronPdf.Engines.Chrome.FitToPaperModes.FixedPixelWidth;
            //pdf.RenderingOptions.MarginTop = 5;
            //pdf.RenderingOptions.MarginLeft = 20;
            //pdf.RenderingOptions.MarginRight = 20;
            //pdf.RenderingOptions.UseMarginsOnHeaderAndFooter = UseMargins.All;
            //pdf.RenderingOptions.ViewPortWidth = 1280;
            //pdf.RenderingOptions.HtmlHeader = new IronPdf.HtmlHeaderFooter
            pdf.RenderingOptions.PaperOrientation = IronPdf.Rendering.PdfPaperOrientation.Portrait;
            //{
            //    MaxHeight = 20,
            //    HtmlFragment = "Page",
            //    DrawDividerLine = true
            //};
            //pdf.RenderingOptions.MarginLeft = 30;
            //pdf.RenderingOptions.MarginRight = 30;
            //pdf.RenderingOptions.Zoom = 100;
            //var baseUri = new Uri(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/custom/verify/"));
            //using var doc = pdf.RenderUrlAsPdf("https://endwswxlpdfqa.azurewebsites.net/reportengine/downloadashtml?reporttype=8");
            using var doc = pdf.RenderHtmlAsPdf(mainContent, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/custom/verify/"));

            //var header = new HtmlHeaderFooter();
            //header.HtmlFragment = "<div style='color:red; font-size:15px;font-weight:bold;'>My Header </div>";
            //header.MaxHeight = 10;
            //doc.AddHtmlHeaders(header, 5, 5, 5);

            return doc.Stream.ToArray();
        }
    }
}

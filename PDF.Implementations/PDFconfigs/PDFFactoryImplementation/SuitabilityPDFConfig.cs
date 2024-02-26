using SelectPdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PDF.Models.Enums;
using PDF.Models.Extensions;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation
{
    public class SuitabilityPDFConfig : PDFAbstractConfig
    {

        public override async Task<byte[]> BuildPDF(string mainContent, Dictionary<string, string> additionalContent)
        {
            //var fontFile = "Content/font/MuseoSans-100.otf";
            var fontFile = "Content/font/Calibri_Regular.ttf";
            var fontDir = Path.Combine(Directory.GetCurrentDirectory(), fontFile);
            var pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontDir);
 
            var headerImageFile = "Content/Brand/MWise-logoRGB.png";
            var dir = Path.Combine(Directory.GetCurrentDirectory(), headerImageFile);
            var firstPageHeaderImage = new PdfImageElement(10, 30, 140, Image.FromFile(dir));

            var footerLine = new PdfLineElement(
                    30,
                    20,
                    515, 20);
            footerLine.LineStyle.LineWidth = 2;
            footerLine.LineStyle.LineDashStyle = PdfLineDashStyle.Solid;
            footerLine.ForeColor = ColorTranslator.FromHtml("#4A4F55");

            // Rest of pages
            var pdf = new HtmlToPdf
            {
                Options =
                {
                    RenderingEngine = RenderingEngine.WebKitRestricted,
                    MarginLeft = 30,
                    MarginRight = 30,
                    WebPageWidth = 800,
                    DisplayFooter = true,
                    DisplayHeader = true
                },
                Header =
                {
                    Height = 95
                },
                Footer =
                {
                    Height = 80
                }
            };

            //pdf.Options.PdfCompressionLevel = PdfCompressionLevel.NoCompression;

            var doc = await Task.Run(() => pdf.ConvertHtmlString(mainContent, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/")));

            var headerImage = new PdfImageElement(10, 34, 100, Image.FromFile(dir));

            var firstPageHeaderFont = doc.Fonts.Add(new Font(pfc.Families[0], 12, GraphicsUnit.Pixel));

            var clientDeets = SetHeader(firstPageHeaderFont, additionalContent);

            var headerLine = new PdfLineElement(
               30,
               85,
               515, 85);
            headerLine.LineStyle.LineWidth = 2;
            headerLine.LineStyle.LineDashStyle = PdfLineDashStyle.Solid;
            headerLine.ForeColor = ColorTranslator.FromHtml("#4A4F55");

            doc.Header.Add(headerImage);
            doc.Header.Add(headerLine);

            var page = doc.Pages[0];
            page.Margins.Left = 30;
            page.Margins.Right = 30;
            page.Margins.Top = 50;

            var customHeader = doc.AddTemplate(page.PageSize.Width - 40, 90);
            customHeader.Add(firstPageHeaderImage);
            customHeader.Add(clientDeets);

            page.CustomHeader = customHeader;

            doc.Footer.Add(footerLine);

            var pageFooterDisclaimerFont = doc.Fonts.Add(
               new Font(pfc.Families[0], 8, GraphicsUnit.Pixel));

            var disclaimer = SetFooterDisclaimer(pageFooterDisclaimerFont);

            doc.Footer.Add(disclaimer);

            var barr = await Task.Run(() => doc.Save());

            return barr;
        }

        private static PdfTextElement SetFooterDisclaimer(PdfFont font)
        {
            var footerDisclaimer = new PdfTextElement(-10, 25, 540, @"
                Mattioli Woods is authorised and regulated by the Financial Conduct Authority. Mattioli Woods plc is a limited company registered in England and Wales at Companies House.
                Registered office: Mattioli Woods plc, 1 New Walk Place, Leicester, LE1 6RU. Registered number 3140521.", font);

            footerDisclaimer.HorizontalAlign = PdfTextHorizontalAlign.Center;
            footerDisclaimer.ForeColor = Color.Gray;

            return footerDisclaimer;
        }

        private static PdfTextElement SetHeader(PdfFont font, Dictionary<string, string> additionalContent)
        {
            var portfolioReference = additionalContent.Where(x => x.Key == "referenceid").FirstOrDefault().Value;
            var accountId = additionalContent.Where(x => x.Key == "mandatereferenceid").FirstOrDefault().Value;
            var subTypeId = additionalContent.Where(x => x.Key == "subtypeid") != null ? Convert.ToInt32(additionalContent.Where(x => x.Key == "subtypeid").FirstOrDefault().Value) : (int?)null;

            var acceptedReportTypes = new[] { 1, 2, 3, 4 };

            var header = new PdfTextElement(-10, 100, 530, @"
               Portfolio reference: " + portfolioReference + @"
               Account reference: " + accountId + @"
               " + (acceptedReportTypes.Any(x => x == subTypeId) ? @$"{((ReportServiceSubTypes)subTypeId).ToString().ToReadableName()}" : null)
               , font);

            header.HorizontalAlign = PdfTextHorizontalAlign.Right;
            header.ForeColor = ColorTranslator.FromHtml("#333");

            return header;
        }
    }
}
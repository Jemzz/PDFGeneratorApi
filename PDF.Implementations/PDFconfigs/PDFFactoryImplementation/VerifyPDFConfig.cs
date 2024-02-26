using SelectPdf;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation
{
    public class VerifyPDFConfig : PDFAbstractConfig
    {
        public override async Task<byte[]> BuildPDF(string mainContent, Dictionary<string, string> additionalContent)
        {
            var coverPage = additionalContent.FirstOrDefault(x => x.Key == "content").Value;
            var clientName = additionalContent.FirstOrDefault(x => x.Key == "clientname").Value;

            const string fontFile = "wwwroot/css/font/Inter-Regular.ttf";
            var fontDir = Path.Combine(Directory.GetCurrentDirectory(), fontFile);

            var pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontDir);

            var converterCover = new HtmlToPdf
            {
                Options =
                {
                    AutoFitWidth = HtmlToPdfPageFitMode.AutoFit, //.WebPageWidth = 1500;
                    MarginLeft = 0,
                    MarginRight = 0
                }
            };

            var coverPageDoc = await Task.Run(() => converterCover.ConvertHtmlString(coverPage, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/")));

            var mainDocument = new PdfDocument();

            const string footerImageFile = "wwwroot/images/verify-logo-full-colour-big.png";

            var dir = Path.Combine(Directory.GetCurrentDirectory(), footerImageFile);
            var pagesFooter = new PdfImageElement(0, 0, 50, Image.FromFile(dir));

            var converter = new HtmlToPdf
            {
                Options =
                {
                    WebPageWidth = 850,
                    MarginLeft = 30,
                    MarginTop = 10,
                    MarginRight = 30,
                    DisplayFooter = true,
                    DisplayHeader = false,
                    PdfBookmarkOptions =
                    {
                        CssSelectors = new string[] { "*." + "bookmark" }
                    },
                    WebElementsMappingOptions =
                    {
                        CssSelectors = new string[] { "*." + "toc" }
                    },
                    ExternalLinksEnabled = true
                }
            };

            var doc = await Task.Run(() => converter.ConvertHtmlString(mainContent, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/")));

            var footerFont = doc.Fonts.Add(new Font(pfc.Families[0], 10, GraphicsUnit.Pixel));

            var footerName = new PdfTextElement(150, 5, clientName, footerFont)
            {
                HorizontalAlign = PdfTextHorizontalAlign.Justify,
                ForeColor = ColorTranslator.FromHtml("#acb1bb")
            };

            var footerStamp = new PdfTextElement(300, 5, "Customer verification report", footerFont)
            {
                HorizontalAlign = PdfTextHorizontalAlign.Justify,
                ForeColor = ColorTranslator.FromHtml("#acb1bb")
            };

            var pageNumFooter = new PdfTextElement(500, 5, "{page_number}", footerFont)
            {
                ForeColor = ColorTranslator.FromHtml("#acb1bb")
            };

            doc.Footer.Add(pagesFooter);
            doc.Footer.Add(footerName);
            doc.Footer.Add(footerStamp);
            doc.Footer.Add(pageNumFooter);

            var pageNumberFont = doc.Fonts.Add(new Font(pfc.Families[0], 12, GraphicsUnit.Pixel));

            var tocRight = doc.Pages[0].ClientRectangle.Width - 60;

            // add page numbers for the table of contents items
            for (var tocItem = 0; tocItem <= 18 /*int.Parse(additionalContent.Where(x => x.Key == "sections").FirstOrDefault().Value)*/; tocItem++)
            {
                var tocTitleID = $"TOC_Title{tocItem}";
                var tocTargetID = $"TOC_Target{tocItem}";

                var tocTitle = converter.Options.WebElementsMappingOptions
                    .Result.GetElementByHtmlId(tocTitleID);
                var tocTarget = converter.Options.WebElementsMappingOptions
                    .Result.GetElementByHtmlId(tocTargetID);

                if (tocTitle != null && tocTarget != null)
                {
                    // get the TOC title page and rendering rectangle
                    var tocPage = doc.Pages[tocTitle.PdfRectangles[0].PageIndex];
                    var tocTitleRectangle = tocTitle.PdfRectangles[0].Rectangle;

                    // get the page number of target where the TOC entry points
                    var tocTargetPageNumber = tocTarget.PdfRectangles[0].PageIndex + 1;

                    // create the page number text element to the right of the TOC title
                    var pageNumberTextElement = new PdfTextElement(tocRight + 5,
                            tocTitleRectangle.Y - 5, -1, tocTitleRectangle.Height,
                            tocTargetPageNumber.ToString(), pageNumberFont)
                    {
                        HorizontalAlign = PdfTextHorizontalAlign.Left,
                        VerticalAlign = PdfTextVerticalAlign.Middle,
                        ForeColor = Color.Black
                    };

                    // add the page number to the right of the TOC entry
                    tocPage.Add(pageNumberTextElement);
                }
                else
                {
                    continue;
                }
            }

            mainDocument.Append(coverPageDoc);
            mainDocument.Append(doc);

            var data = await Task.Run(() => mainDocument.Save());

            return data;
        }
    }
}

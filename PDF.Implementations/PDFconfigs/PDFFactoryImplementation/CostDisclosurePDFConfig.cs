using SelectPdf;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation
{
    public class CostDisclosurePDFConfig : PDFAbstractConfig
    {
        public override async Task<byte[]> BuildPDF(string mainContent, Dictionary<string, string> additionalContent)
        {
            var clientName = additionalContent.FirstOrDefault(x => x.Key == "clientname").Value;

            const string fontFile = "Content/font/MuseoSans-100.otf";
            var fontDir = Path.Combine(Directory.GetCurrentDirectory(), fontFile);
            var pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontDir);

            var headerImageFile = "Content/Brand/MWise-logoRGB.png";
            var dir = Path.Combine(Directory.GetCurrentDirectory(), headerImageFile);
            var firstPageHeaderImage = new PdfImageElement(0, -10, 180, Image.FromFile(dir));

            var mainDoc = new PdfDocument();

            // first page
            var firstPageConverter = new HtmlToPdf
            {
                Options =
                {
                    //firstPageConverter.Options.RenderingEngine = RenderingEngine.WebKitRestricted;
                    PdfPageOrientation = PdfPageOrientation.Landscape,
                    MarginTop = 50,
                    MarginBottom = 20,
                    MarginLeft = 20,
                    MarginRight = 20,
                    DisplayCutText = true,
                    WebPageWidth = 1250,
                    DisplayHeader = true,
                    DisplayFooter = true
                },
                Header =
                {
                    Height = 80
                },
                Footer =
                {
                    Height = 180
                }
            };

            var contentString = additionalContent.FirstOrDefault(x => x.Key == "content").Value;
            var baseUrl = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/");

            var firstPageDoc = await Task.Run(() => firstPageConverter.ConvertHtmlString(contentString, baseUrl));

            var fontFirst = new Font(pfc.Families[0], 11, GraphicsUnit.Pixel);
            var fontSecond = new Font(pfc.Families[0], 10, GraphicsUnit.Pixel);

            var footFirst = firstPageDoc.Fonts.Add(fontFirst);
            var footSecond = firstPageDoc.Fonts.Add(fontSecond);

            mainDoc.AddFont(fontFirst, true);
            mainDoc.AddFont(fontSecond, true);

            var firstPageFooterDisclaimer = new PdfTextElement(40, 10, firstPageConverter.Options.WebPageWidth - 550,
                "DISCLAIMER: This document is not intended as an offer or solicitation or recommendation to use or invest in any of the services or products mentioned in this document.\nReceipt of this document does not constitute a personal investment recommendation. Investors should be aware that prices may fall as well as rise and that the income derived can go down as well as up. When buying or selling any investment that fluctuates in price or value you may get back less than you invested. Past performance is not necessarily a guide to future performance. The value of investments denominated in foreign currency may fall as a result of exchange rate movements. The investments and services referred to in this document may not be suitable for all investors and if in doubt you should seek independent financial advice. While due care and attention has been taken to ensure that the information contained within this valuation is both correct and complete, Mattioli Woods plc or the managers, cannot accept responsibility for any errors or omissions herein. The prices upon which this valuation is based do not reflect a guarantee of the selling prices available. If there are any details or valuations herein you believe are inaccurate, please contact us."
                , footFirst)
            {
                HorizontalAlign = PdfTextHorizontalAlign.Justify,
                ForeColor = ColorTranslator.FromHtml("#000")
            };

            firstPageDoc.Footer.Add(firstPageFooterDisclaimer);

            var firstPageFooterPrint = new PdfTextElement(40, 115, "Mattioli Woods plc is authorised and regulated by the Financial Conduct Authority.\nMattioli Woods plc is a limited company registered in England and Wales at Companies House.\r\n\r\nRegistered office: Mattioli Woods plc, 1 New Walk Place, Leicester, LE1 6RU. Registered number 3140521.", footSecond)
            {
                HorizontalAlign = PdfTextHorizontalAlign.Justify,
                ForeColor = Color.Gray
            };

            firstPageDoc.Footer.Add(firstPageFooterPrint);

            var footerImageFile = "Content/Brand/simplified-investing.png";
            var footerDir = Path.Combine(Directory.GetCurrentDirectory(), footerImageFile);
            var firstPageFooterImage = new PdfImageElement(1250 - 660, 110, 180, Image.FromFile(footerDir));

            firstPageDoc.Header.Add(firstPageHeaderImage);
            firstPageDoc.Footer.Add(firstPageFooterImage);

            //table of content page
            var converter = new HtmlToPdf
            {
                Options =
                {
                    PdfPageOrientation = PdfPageOrientation.Landscape,
                    MarginTop = 5,
                    MarginBottom = 20,
                    MarginLeft = 20,
                    MarginRight = 20,
                    //converter.Options.DisplayCutText = true;
                    WebPageWidth = 1250,
                    DisplayHeader = true,
                    DisplayFooter = true,
                    RenderingEngine = RenderingEngine.WebKitRestricted,
                    PdfBookmarkOptions =
                    {
                        CssSelectors = new[] { "*." + "bookmark" }
                    },
                    WebElementsMappingOptions =
                    {
                        CssSelectors = new[] { "*." + "toc" }
                    },
                    ViewerPreferences =
                    {
                        PageMode = PdfViewerPageMode.UseOutlines
                    }
                },
                Header =
                {
                    Height = 60
                },
                Footer =
                {
                    Height = 50
                }
            };

            var doc = await Task.Run(() => converter.ConvertHtmlString(mainContent, baseUrl));
            var headerImage = new PdfImageElement(12, 10, 110, Image.FromFile(dir));
            var footerImage = new PdfImageElement(1250 - 660, 10, 180, Image.FromFile(footerDir));
            doc.Header.Add(headerImage);
            doc.Footer.Add(footerImage);

            doc.AddFont(fontFirst, true);
            doc.AddFont(fontSecond, true);

            var footerCenter1 = new PdfTextElement(40, 30, "Mattioli Woods plc is authorised and regulated by the Financial Conduct Authority.\nMattioli Woods plc is a limited company registered in England and Wales at Companies House.\r\n\r\nRegistered office: Mattioli Woods plc, 1 New Walk Place, Leicester, LE1 6RU. Registered number 3140521.", footSecond);
            footerCenter1.ForeColor = ColorTranslator.FromHtml("#828080");
            footerCenter1.HorizontalAlign = PdfTextHorizontalAlign.Justify;
            doc.Footer.Add(footerCenter1);

            // create font for page numbers yo
            var pageNumberFont = doc.Fonts.Add(
                new Font(pfc.Families[0], 18, GraphicsUnit.Pixel));

            var tocRight = doc.Pages[0].ClientRectangle.Width - 50;

            // add page numbers for the table of contents items
            for (var tocItem = 1; tocItem <= 3 /*int.Parse(additionalContent.Where(x => x.Key == "sections").FirstOrDefault().Value)*/; tocItem++)
            {
                var tocTitleID = $"TOC_Title{tocItem}";
                var tocTargetID = $"TOC_Target{tocItem}";

                var tocTitle = converter.Options.WebElementsMappingOptions.Result.GetElementByHtmlId(tocTitleID);
                var tocTarget = converter.Options.WebElementsMappingOptions.Result.GetElementByHtmlId(tocTargetID);

                // get the TOC title page and rendering rectangle
                var tocPage = doc.Pages[tocTitle.PdfRectangles[0].PageIndex];
                var tocTitleRectangle = tocTitle.PdfRectangles[0].Rectangle;

                // get the page number of target where the TOC entry points
                var tocTargetPageNumber = tocTarget.PdfRectangles[0].PageIndex + 2;

                // create the page number text element to the right of the TOC title
                var pageNumberTextElement = new PdfTextElement(tocRight + 5, tocTitleRectangle.Y, -1, tocTitleRectangle.Height, tocTargetPageNumber.ToString(), pageNumberFont)
                {
                    HorizontalAlign = PdfTextHorizontalAlign.Left,
                    VerticalAlign = PdfTextVerticalAlign.Middle,
                    ForeColor = Color.Black
                };

                // add the page number to the right of the TOC entry
                tocPage.Add(pageNumberTextElement);
            }

            // append to actual pdf
            mainDoc.Append(firstPageDoc);
            mainDoc.Append(doc);

            mainDoc.Footer = mainDoc.AddTemplate(doc.Pages[0].ClientRectangle.Width, 46);
            mainDoc.Footer.DisplayOnFirstPage = false;

            var foot = mainDoc.Fonts.Add(
            new Font(pfc.Families[0], 14, GraphicsUnit.Pixel));

            var footerRight = new PdfTextElement(60, -35, "Page {page_number} of {total_pages} | " + clientName, foot)
            {
                HorizontalAlign = PdfTextHorizontalAlign.Left,
                ForeColor = ColorTranslator.FromHtml("#4A4F55")
            };

            mainDoc.Footer.Add(footerRight);

            var data = await Task.Run(() => mainDoc.Save());

            return data;
        }
    }
}
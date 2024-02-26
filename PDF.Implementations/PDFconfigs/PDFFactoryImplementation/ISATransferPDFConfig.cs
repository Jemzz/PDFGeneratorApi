using SelectPdf;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation
{
    public class ISATransferPDFConfig : PDFAbstractConfig
    {
        public override async Task<byte[]> BuildPDF(string mainContent, Dictionary<string, string> additionalContent)
        {
            var mainDoc = new PdfDocument();

            var fontFile = "Content/font/MuseoSans-100.otf";
            var fontDir = Path.Combine(Directory.GetCurrentDirectory(), fontFile);
            var pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontDir);

            var headerImageFile = "Content/Brand/MWise-logoRGB.png";
            var dir = Path.Combine(Directory.GetCurrentDirectory(), headerImageFile);

            var pdf = new HtmlToPdf();
            pdf.Options.MarginLeft = 30;
            pdf.Options.MarginRight = 30;
            pdf.Options.MarginTop = 20;
            pdf.Options.WebPageWidth = 800;
            pdf.Options.DisplayFooter = true;
            pdf.Options.DisplayHeader = true;
            pdf.Header.Height = 50;
            pdf.Footer.Height = 50;

            var doc = await Task.Run(() => pdf.ConvertHtmlString(mainContent, Directory.GetCurrentDirectory()));

            var headerImage = new PdfImageElement(440, 0, 100, Image.FromFile(dir));
            doc.Header.Add(headerImage);

            var pageNumberFont = doc.Fonts.Add(new Font(pfc.Families[0], 11, GraphicsUnit.Pixel));

            doc.Header.Add(SetHeaderLeft(pageNumberFont));
            doc.Header.Add(SetHeaderCenter(pageNumberFont));
            doc.Header.Add(SetHeaderRight(pageNumberFont, additionalContent));


            var disclaimerFont = doc.Fonts.Add(new Font(pfc.Families[0], 9, GraphicsUnit.Pixel));

            var disclaimerImage = SetFooterImageDisclaimer();
            var disclaimer = SetFooterContentDisclaimer(disclaimerFont);

            doc.Footer.Add(disclaimerImage);
            doc.Footer.Add(disclaimer);
            //doc.Fonts.Add(new Font("Museo Sans 700", 10, FontStyle.Regular, GraphicsUnit.Pixel));
            mainDoc.Append(doc);

            var barr = await Task.Run(() => mainDoc.Save());

            return barr;

        }

        private static PdfTextElement SetHeaderLeft(PdfFont font)
        {
            var headerLeft = new PdfTextElement(0, 130, 140, @"
               Document Version" + @"
               v1.0", font);

            headerLeft.HorizontalAlign = PdfTextHorizontalAlign.Left;
            headerLeft.ForeColor = ColorTranslator.FromHtml("#333");

            return headerLeft;
        }

        private static PdfTextElement SetHeaderCenter(PdfFont font)
        {
            var headerCenter = new PdfTextElement(150, 130, 140, @"
               Mattioli Woods plc" + @"
               https://mattioliwoods.com/", font);

            headerCenter.HorizontalAlign = PdfTextHorizontalAlign.Left;
            headerCenter.ForeColor = ColorTranslator.FromHtml("#333");

            return headerCenter;
        }

        private static PdfTextElement SetHeaderRight(PdfFont font, Dictionary<string, string> additionalContent)
        {
            var externalReferenceId = additionalContent.Where(x => x.Key == "externalReferenceid").FirstOrDefault().Value;
            var headerRight = new PdfTextElement(300, 130, 140, @"
               Account Reference" + @"
               " + externalReferenceId, font);

            headerRight.HorizontalAlign = PdfTextHorizontalAlign.Left;
            headerRight.ForeColor = ColorTranslator.FromHtml("#333");

            return headerRight;
        }

        private static PdfImageElement SetFooterImageDisclaimer()
        {
            var headerImageFile = "Content/Brand/Pershing.jpg";
            var dir = Path.Combine(Directory.GetCurrentDirectory(), headerImageFile);
            var footerImage = new PdfImageElement(10, 0, 100, Image.FromFile(dir));

            return footerImage;
        }

        private static PdfTextElement SetFooterContentDisclaimer(PdfFont font)
        {
            var footerDisclaimer = new PdfTextElement(100, 100, 500, @"
                Pershing Securities Limited is an affiliate of Pershing LLC, a subsidiary of The Bank of New York Mellon Corporation. 
                Registered in England and Wales under No. 2474912. Member of the London Stock Exchange. Authorised and 
                regulated by the Financial Conduct Authority, No. 146576. Registered address: Royal Liver Building, Pier Head, Liverpool L3 1LL", font);

            footerDisclaimer.HorizontalAlign = PdfTextHorizontalAlign.Left;
            footerDisclaimer.ForeColor = Color.Gray;

            return footerDisclaimer;
        }
    }
}

using Microsoft.Extensions.Options;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PDF.Core.Options;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation.GenerationService
{
    public class PdfGenerationService : IPdfGenerationService
    {
        private readonly IOptions<SelectPdfOptions> _options;

        //private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public PdfGenerationService(IOptions<SelectPdfOptions> options)
        {
            _options = options;
        }

        public async Task<byte[]> RenderPdf(string content, int reportType, Dictionary<string, string> additionalContent)
        {
            try
            {
                GlobalProperties.LicenseKey = _options.Value.LicenseKey;

                // to force azure hosting mode as this uses different rendering engine than that of a vm or local development pc
                GlobalProperties.EnableRestrictedRenderingEngine = true;

                var factory = new PDFFactory();
                var config = factory.GetConfig(reportType);

                var byteArr = await config?.BuildPDF(content, additionalContent);

                return byteArr;
            }
            catch (Exception ex)
            {
                ex.Data.Add("SerialNumber", GlobalProperties.LicenseKey);
                ex.Data.Add("ReportType", reportType);
                ex.Data.Add("Content", content);
                //_logger.Error(ex);
                throw;
            }
        }
    }
}

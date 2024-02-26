using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDF.Implementations.PDFConfigs.PDFFactoryImplementation.GenerationService
{
    public interface IPdfGenerationService
    {
        Task<byte[]> RenderPdf(string content, int reportType, Dictionary<string, string> additionalContent);
    }
}
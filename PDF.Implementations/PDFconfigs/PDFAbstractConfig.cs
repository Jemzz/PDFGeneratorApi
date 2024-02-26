using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDF.Implementations.PDFConfigs
{
    public abstract class PDFAbstractConfig
    {
        public abstract Task<byte[]> BuildPDF(string mainContent, Dictionary<string, string> additionalContent);
    }
}
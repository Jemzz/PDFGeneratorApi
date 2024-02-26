using System.Net;

namespace PDF.PDFGeneration
{
    public class ReportModel
    {
        public string FileName { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public string ReportName { get; set; }

        public int Size { get; set; }

        public byte[] File { get; set; }

        public HttpStatusCode Status { get; set; }
    }
}

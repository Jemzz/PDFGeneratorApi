using PDF.Implementations.PDFconfigs.PDFFactoryImplementation;
using PDF.Implementations.PDFConfigs.PDFFactoryImplementation;

namespace PDF.Implementations.PDFConfigs
{
    public class PDFFactory
    {
        // need to convert from case statement :) - Tolu
        public PDFAbstractConfig GetConfig(int i)
        {
            switch (i)
            {
                case 1:
                case 7:
                    return new SuitabilityPDFConfig();
                case 2:
                case 3:
                    return new ValuationPDFConfig();
                case 4:
                case 5:
                case 6:
                    return new ISATransferPDFConfig();
                case 8:
                    return new VerifyPDFConfig();
                case 9:
                    return new CostDisclosurePDFConfig();
                case 10:
                    return new LocalTestPDFConfig();
                case 11:
                case 12:
                case 13:
                    return new ClientReportPdfConfig();
            }

            return null;
        }
    }
}
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
                    return new SuitabilityPDFConfig();
                case 2:
                    return new VerifyPDFConfig();
            }

            return null;
        }
    }
}
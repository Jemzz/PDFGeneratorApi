using System;

namespace PDF.PDFGeneration
{
    public static class Extensions
    {
        public static double IncrementSubSection(this double value)
        {
            return Math.Round(value + 0.1, 1);
        }


        public static string ReplaceNullWithHyphen(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }
        //public static int IncrementSection(double value)
        //{
        //    return (int)value + 1;
        //}
    }
}

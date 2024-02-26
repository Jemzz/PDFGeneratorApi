using System;
using PDF.Models.ClientReportModels;
using PDF.Models.Enums;
using PDF.Models.VerifyModel.CustomerInformation;
using PDF.Models.ViewModels;

namespace PDF.PDFGeneration.Helper
{
    public static class Extensions
    {
        public static string FullName(this PersonalDetailModel personalDetails)
        {
            return GetFullName(personalDetails.FirstName, personalDetails.MiddleName, personalDetails.Surname);
        }

        public static string FullName(this RequestedParticipantPersonalDetailsModel personalDetails)
        {
            return GetFullName(personalDetails.FirstName, personalDetails.MiddleName, personalDetails.Surname);
        }

        private static string GetFullName(string firstName, string middleName, string surname)
        {
            return !string.IsNullOrWhiteSpace(middleName) ? $"{firstName} {middleName} {surname}" : $"{firstName} {surname}";
        }
        public static string FirstCharToUpper(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? value[0].ToString().ToUpper() + value.Substring(1) : null;
        }
        private static int Status(string result)
        {
            result = result.Replace(" ", string.Empty);
            return !string.IsNullOrEmpty(result) ? (int)Enum.Parse(typeof(VerifyStatuses), result, true) : -1;
        }

        public static string StatusDescription(this string result)
        {
            return string.IsNullOrEmpty(result) || result.Equals("review", StringComparison.OrdinalIgnoreCase) ? "Review Required" : result.FirstCharToUpper();
        }

        public static string ProofOfAddressStatusDescription(this string result)
        {
            return Status(result) switch
            {
                0 => "Uploaded",
                _ => "Pending",
            };
        }

        public static string StatusFontColor(this string result)
        {
            return Status(result) switch
            {
                0 or 2 => "green-colour",
                1 => "orange-colour",
                _ => "red-colour",
            };
        }

        public static string StatusTickIcon(this string result)
        {
            return Status(result) switch
            {
                0 => "icons/TickIcon.svg",
                2 => "icons/manually_accepted.svg",
                3 => "icons/manually_rejected.svg",
                _ => "icons/OrangeIcon.svg",
            };
        }

        public static string SubHeadingStatus(this string result)
        {
            return string.IsNullOrEmpty(result) ? "Review" : result;
        }

        public static string RoundTo2Decimal(this string score)
        {
            var scoreWithoutPercentage = score.Replace("%", "");
            double.TryParse(scoreWithoutPercentage, out var faceScore);
            return faceScore.ToString("0.00");
        }
    }
}

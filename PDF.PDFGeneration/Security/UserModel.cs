
namespace PDF.PDFGeneration.Security
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public string TenantId { get; set; }
        public string[] Roles { get; set; }
        public string Scope { get; set; }
        public string AccessToken { get; set; }
        public bool IsIndividual { get; set; }
        public long? IndividualId { get; set; }
        public UserDataModel UserData { get; set; }
    }
}

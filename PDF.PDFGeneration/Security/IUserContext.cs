using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PDF.PDFGeneration.Security
{
    public interface IUserContext
    { 
        Task<UserModel> GetUserContextAsync();
        HttpContext HttpCurrentContext { get; }
        string UserId { get; }
        UserModel CurrentContext { get; }
        bool IsAuthenticated { get; }
        void Impersonate(string userId);
    }
}
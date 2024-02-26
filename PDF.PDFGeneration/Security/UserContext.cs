using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using PDF.Onboard.Api.Core.Security;

namespace PDF.PDFGeneration.Security
{
    public class UserContext : IUserContext
    {
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _UserImpersonatedId;
        private bool? _UserImpersonatedIsAuthenticated;
        public UserContext(IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext HttpCurrentContext => _httpContextAccessor.HttpContext;

        public void Impersonate(string userId)
        {
            _UserImpersonatedId = userId;
            _UserImpersonatedIsAuthenticated = true;
        }

        public async Task<UserModel> GetUserContextAsync()
        {
            var userId = (_UserImpersonatedIsAuthenticated ?? false) ? _UserImpersonatedId : _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();

            if (_UserImpersonatedIsAuthenticated ?? false)
                return new UserModel
                {
                    UserId = userId
                };

            var user = await _cache.GetOrCreateAsync($"UserContext_{userId}", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(10);
                var userPrincipal = _httpContextAccessor.HttpContext.User;

                return await Task.Run(() =>
                {
                    var tenantId = userPrincipal.GetLoggedInUserTenantId();
                    var clientId = userPrincipal.GetLoggedInUserClientId();
                    var userData = userPrincipal.GetLoggedInUserData();
                    var email = userPrincipal.GetLoggedInUserEmail();
                    var scope = userPrincipal.GetLoggedInUserScope();
                    var individualId = userPrincipal.GetLoggedInUserIndividualId();
                    var accessToken = userPrincipal.GetLoggedInUserToken();

                    userData.Email = email;

                    var userModel = new UserModel
                    {
                        UserId = userId,
                        TenantId = tenantId,
                        ClientId = clientId,
                        UserData = userData,
                        Scope = scope,
                        IndividualId = Convert.ToInt64(individualId),
                        IsIndividual = IsIndividual(scope),
                        AccessToken = accessToken
                    };

                    return userModel;
                });
            });

            return user;
        }

        private bool IsIndividual(string scope)
        {
            var operationalScopes = new[] { WellKnownScopes.Api};

            return !operationalScopes.Any(x => scope.Equals(x, StringComparison.OrdinalIgnoreCase));
        }

        public string UserId => _UserImpersonatedId ?? _httpContextAccessor?.HttpContext?.User?.GetLoggedInUserId<string>() ?? Guid.Empty.ToString();
        public UserModel CurrentContext => GetUserContextAsync().Result;
        public bool IsAuthenticated => _UserImpersonatedIsAuthenticated ?? _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
using PDF.Core.Utilities;
using PDF.PDFGeneration.Security;
using System;
using System.Linq;
using System.Security.Claims;

namespace PDF.Onboard.Api.Core.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey ?
                principal.FindFirst(ClaimTypes.UserData)?.Value : principal.FindFirst(ClaimTypes.PrimarySid)?.Value;

            if (string.IsNullOrWhiteSpace(loggedInUserId))
                throw new NullReferenceException(nameof(principal));

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(loggedInUserId, typeof(T));
            }

            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return (T)Convert.ChangeType(loggedInUserId, typeof(T));
            }

            throw new Exception("Invalid type provided");
        }

        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.Name).Value;
        }

        public static string GetLoggedInUserTenantId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return string.Empty;

            return principal.FindFirst(WellKnownClaimTypes.TenantId).Value;
        }

        public static string GetLoggedInUserClientId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return string.Empty;

            return principal.FindFirst(WellKnownClaimTypes.ClientId).Value;
        }

        public static string GetLoggedInUserScheme(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(WellKnownClaimTypes.Scheme).Value;
        }

        public static string GetLoggedInUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return principal.FindFirst(ClaimTypes.NameIdentifier).Value;

            return principal.FindFirst(ClaimTypes.Email).Value;
        }

        public static string GetLoggedInUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return string.Empty;

            return principal.FindFirst(WellKnownClaimTypes.UserToken)?.Value ?? "";
        }

        public static string GetLoggedInUserScope(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return WellKnownScopes.System;

            var scopes = principal.FindAll(WellKnownClaimTypes.Scope);
            if (scopes == null) return string.Empty;
            var enumerable = scopes as Claim[] ?? scopes.ToArray();
            if (enumerable.Any(s => s.Value.Equals(WellKnownScopes.System, StringComparison.OrdinalIgnoreCase)))
                return WellKnownScopes.System;
            if (enumerable.Any(s => s.Value.Equals(WellKnownScopes.Api, StringComparison.OrdinalIgnoreCase)))
                return WellKnownScopes.Api;

            return string.Empty;
        }

        public static string GetLoggedInUserIndividualId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return "0";

            var key = principal.FindFirst(WellKnownClaimTypes.UserKey)?.Value;

            return string.IsNullOrWhiteSpace(key) ? "0" : key;
        }

        public static string[] GetLoggedInUserRoles(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var roles = principal.FindAll(ClaimTypes.Role).Select(x => x.Value).ToArray();

            return roles;
        }

        public static UserDataModel GetLoggedInUserData(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var userData = principal.FindFirst(ClaimTypes.UserData)?.Value;

            if (string.IsNullOrWhiteSpace(userData))
                throw new NullReferenceException(nameof(principal));

            if (principal.Identity.AuthenticationType == WellKnownAuthenticationTypes.ApiKey)
                return new UserDataModel
                {
                    Email = principal.FindFirst(ClaimTypes.NameIdentifier).Value,
                    LastName = string.Empty,
                    MiddleName = string.Empty,
                    FirstName = string.Empty
                };

            var model = userData.FromJsonString<UserDataModel>();

            if (model == null)
                throw new NullReferenceException(nameof(UserDataModel));

            return model;
        }
    }
}

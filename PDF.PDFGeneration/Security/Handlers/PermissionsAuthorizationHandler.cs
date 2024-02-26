using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using PDF.PDFGeneration.Security.Requirements;

namespace PDF.PDFGeneration.Security.Handlers
{
#pragma warning disable 1591
    public class PermissionsAuthorizationHandler : AuthorizationHandler<PermissionsRequirement>
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IMemoryCache _cacheManager;

        public PermissionsAuthorizationHandler(IMemoryCache cacheManager)
        {
            _cacheManager = cacheManager;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionsRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            if (context.HasSucceeded)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(WellKnownUserRoles.Admin))
            {
                Utility.Succeed(context, requirement.Identifier);
                return Task.CompletedTask;
            }

            if (context.User == null || requirement == null || string.IsNullOrWhiteSpace(requirement.Permissions))
            {
                return Task.CompletedTask;
            }

            var requirementTokens = requirement.Permissions.Split("|", StringSplitOptions.RemoveEmptyEntries);

            if (requirementTokens?.Any() != true)
            {
                return Task.CompletedTask;
            }

            List<(string, string, string)> expectedRequirements = new List<(string, string, string)>(); 

            foreach (var token in requirementTokens.Where(t => !t.Equals(WellKnownPermissions.Auto, StringComparison.OrdinalIgnoreCase)))
            {
                var separatedTokens = token.Split(":");

                if (separatedTokens?.Any() != true || separatedTokens.Length != 3)
                {
                    return Task.CompletedTask;
                }

                expectedRequirements.Add((separatedTokens[0], separatedTokens[1], separatedTokens[2]));
            }

            if (expectedRequirements.Count == 0)
            {
                return Task.CompletedTask;
            }

            var userPermissionClaims = context.User.Claims?.Where(c =>
                string.Equals(c.Type, "permission", StringComparison.OrdinalIgnoreCase));

            foreach (var claim in userPermissionClaims ?? Enumerable.Empty<Claim>())
            {
                var userPermission = claim.Value?.Split(':');

                if (userPermission == null || userPermission.Length != 3)
                {
                    continue;
                }

                var match = expectedRequirements
                    .Where(r =>
                        r.Item1 == userPermission[0]
                        && (r.Item2 == "*" || userPermission[1] == "*" || r.Item2 == userPermission[1])
                        && (r.Item3 == "*" || userPermission[2] == "*" || r.Item3 == userPermission[2]));

                if (match.Any())
                {
                    Utility.Succeed(context, requirement.Identifier);
                    break;
                }
            }

            return Task.CompletedTask;
        }

        public string[] GetControllers()
        {
            var asm = Assembly.GetAssembly(typeof(PermissionsAuthorizationHandler));

            if (asm == null) return new string[] { };
            var controllers = asm.GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type));

            return controllers.Select(c => c.Name.Replace("Controller", "")).ToArray();
        }
    }
#pragma warning restore 1591
}

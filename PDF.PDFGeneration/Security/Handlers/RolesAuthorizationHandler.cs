using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NLog;
using PDF.PDFGeneration.Security.Requirements;

namespace PDF.PDFGeneration.Security.Handlers
{
#pragma warning disable 1591
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesRequirement>
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            RolesRequirement requirement)
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

            if (context.User == null || requirement == null || string.IsNullOrWhiteSpace(requirement.Roles))
            {
                return Task.CompletedTask;
            }

            var requirementTokens = requirement.Roles.Split("|", StringSplitOptions.RemoveEmptyEntries);

            if (requirementTokens?.Any() != true)
            {
                return Task.CompletedTask;
            }

            var expectedRequirements = requirementTokens.ToList();

            if (expectedRequirements.Count == 0)
            {
                return Task.CompletedTask;
            }

            var userRoleClaims = context.User.Claims?.Where(c =>
                string.Equals(c.Type, "role", StringComparison.OrdinalIgnoreCase)
                || string.Equals(c.Type, System.Security.Claims.ClaimTypes.Role, StringComparison.OrdinalIgnoreCase));

            foreach (var claim in userRoleClaims ?? Enumerable.Empty<Claim>())
            {
                var match = expectedRequirements
                    .Where(r => string.Equals(r, claim.Value, StringComparison.OrdinalIgnoreCase));

                if (match.Any())
                {
                    Utility.Succeed(context, requirement.Identifier);
                    break;
                }
            }

            return Task.CompletedTask;
        }
    }
#pragma warning restore 1591
}

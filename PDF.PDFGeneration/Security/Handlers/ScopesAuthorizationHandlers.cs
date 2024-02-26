﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NLog;
using PDF.PDFGeneration.Security.Requirements;

namespace PDF.PDFGeneration.Security.Handlers
{
#pragma warning disable 1591
    public class ScopesAuthorizationHandler : AuthorizationHandler<ScopesRequirement>
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ScopesRequirement requirement)
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

            if (context.User == null || requirement == null || string.IsNullOrWhiteSpace(requirement.Scopes))
            {
                return Task.CompletedTask;
            }

            var requirementTokens = requirement.Scopes.Split("|", StringSplitOptions.RemoveEmptyEntries);

            if (requirementTokens?.Any() != true)
            {
                return Task.CompletedTask;
            }

            var expectedRequirements = requirementTokens.ToList();

            if (expectedRequirements.Count == 0)
            {
                return Task.CompletedTask;
            }

            var userScopeClaims = context.User.Claims?.Where(c => string.Equals(c.Type, "scope", StringComparison.OrdinalIgnoreCase)).ToList();

            if (userScopeClaims!.Any(c => c.Value.Equals("user", StringComparison.OrdinalIgnoreCase)))
            {
                var decision = context.User.Claims?.FirstOrDefault(c =>
                    c.Type.Equals(System.Security.Claims.ClaimTypes.AuthorizationDecision,
                        StringComparison.OrdinalIgnoreCase));
                
                if(string.Equals(decision?.Value ?? "Deny", "Deny", StringComparison.OrdinalIgnoreCase))
                    return Task.CompletedTask;
            }
            
            foreach (var claim in userScopeClaims ?? Enumerable.Empty<Claim>())
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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PDF.PDFGeneration.Security.Requirements;

namespace PDF.PDFGeneration.Security.Handlers
{
    /// <summary>
    /// Common requirement for security policy.
    /// </summary>
    public class WxlGlobalRequirementHandler : AuthorizationHandler<WxlGlobalRequirement>
    {
        private readonly IUserContext _userContext;

        /// <summary>
        /// WxlGlobalRequirementHandler
        /// </summary>
        /// <param name="userContext"></param>
        public WxlGlobalRequirementHandler(IUserContext userContext)
        {
            _userContext = userContext;
        }

        /// <summary>
        /// Makes a decision if authorization is allowed based on a specific requirement.
        /// </summary>
        /// <param name="context">The authorization context.</param>
        /// <param name="requirement">The requirement to evaluate.</param>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WxlGlobalRequirement requirement)
        {
            if (context == null)
            {
                return Task.FromResult(0);
            }

            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.FromResult(0);
            }

            IEnumerable<string> requiredClaims = new List<string>
            {
                System.Security.Claims.ClaimTypes.Name,
                System.Security.Claims.ClaimTypes.PrimarySid,
                System.Security.Claims.ClaimTypes.Email
            };

            // check all claims are supplied
            if (requiredClaims.Any(claim => !context.User.HasClaim(c => c.Type == claim)))
            {
                context.Fail();
                return Task.FromResult(0);
            }

            // make sure the primary sid is not empty
            if (string.IsNullOrWhiteSpace(context.User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.PrimarySid)?.Value))
            {
                context.Fail();
                return Task.FromResult(0);
            }
            
            context.Succeed(requirement);

            return Task.FromResult(0);
        }
    }
}


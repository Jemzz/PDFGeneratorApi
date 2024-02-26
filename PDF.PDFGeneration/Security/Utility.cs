using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace PDF.PDFGeneration.Security
{
#pragma warning disable 1591
    public static class Utility
    {
        public static void Succeed(AuthorizationHandlerContext context, Guid identifier)
        {
            var groupedRequirements = context.Requirements.Where(r => (r as IIdentifiable)?.Identifier == identifier);

            foreach (var requirement in groupedRequirements)
            {
                context.Succeed(requirement);
            }
        }
    }
#pragma warning restore 1591
}

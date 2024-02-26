using System;
using Microsoft.AspNetCore.Authorization;

namespace PDF.PDFGeneration.Security.Requirements
{
#pragma warning disable 1591
    public class ScopesRequirement : IAuthorizationRequirement, IIdentifiable
    {
        public ScopesRequirement(string scopes, Guid identifier)
        {
            Scopes = scopes;
            Identifier = identifier;
        }

        public string Scopes { get; }

        public Guid Identifier { get; set; }
    }
#pragma warning restore 1591
}

using System;
using Microsoft.AspNetCore.Authorization;

namespace PDF.PDFGeneration.Security.Requirements
{
#pragma warning disable 1591
    public class RolesRequirement : IAuthorizationRequirement, IIdentifiable
    {
        public RolesRequirement(string roles, Guid identifier)
        {
            Roles = roles;
            Identifier = identifier;
        }

        public string Roles { get; }

        public Guid Identifier { get; set; }
    }
#pragma warning restore 1591
}

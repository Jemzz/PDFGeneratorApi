using System;
using Microsoft.AspNetCore.Authorization;

namespace PDF.PDFGeneration.Security.Requirements
{
#pragma warning disable 1591
    public class PermissionsRequirement : IAuthorizationRequirement, IIdentifiable
    {
        public PermissionsRequirement(string permissions, Guid identifier)
        {
            Permissions = permissions;
            Identifier = identifier;
        }

        public string Permissions { get; }

        public Guid Identifier { get; set; }
    }
#pragma warning restore 1591
}

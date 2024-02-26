using System;
using Microsoft.AspNetCore.Authorization;

namespace PDF.PDFGeneration.Security
{
#pragma warning disable 1591
    public sealed class PermissionsAttribute : AuthorizeAttribute
    {
        public const string PermissionsGroup = "Permissions";
        public const string RolesGroup = "Roles";
        public const string ScopesGroup = "Scopes";

        private string[] _permissions;
        private string[] _scopes;
        private string[] _roles;

        private bool _isDefault = true;

        public PermissionsAttribute()
        {
            _permissions = Array.Empty<string>();
            _roles = Array.Empty<string>();
            _scopes = Array.Empty<string>();
        }

        /// <summary>
        /// Permissions based on user
        /// </summary>
        public string[] Permissions
        {
            get => _permissions;
            set => BuildPolicy(ref _permissions, value, PermissionsGroup);
        }

        public string[] Scopes
        {
            get => _scopes;
            set => BuildPolicy(ref _scopes, value, ScopesGroup);
        }

        public new string[] Roles
        {
            get => _roles;
            set => BuildPolicy(ref _roles, value, RolesGroup);
        }

        private void BuildPolicy(string[] value, string group)
        {
            var target = new string[] { };
            BuildPolicy(ref target, value, @group);
        }

        private void BuildPolicy(ref string[] target, string[] value, string group)
        {
            target ??= new string[] { };

            target = value ?? Array.Empty<string>();

            if (_isDefault)
            {
                Policy = string.Empty;
                _isDefault = false;
            }

            Policy += $"{group}${string.Join("|", target)};";
        }
    }
#pragma warning restore 1591
}

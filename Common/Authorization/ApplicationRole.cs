using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Common.Authorization
{
    public static class ApplicationRole
    {
        public const string Admin = nameof(Admin);
        public const string Basic = nameof(Basic);

        public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(
            new[]
            {
                Admin,
                Basic
            });

        public static bool IsDefaultRole(string roleName)
        {
            return DefaultRoles.Any(r => r == roleName);
        }
    }
}

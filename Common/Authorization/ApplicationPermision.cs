
using System.Collections.ObjectModel;

namespace Common.Authorization
{
    public record ApplicationPermission(
        string Feature,
        string Action,
        string Group,
        string Description,
        bool IsBasicPermission = false
    )
    {
        public string Name => NameFor(Feature, Action);

        public static string NameFor(string feature, string action)
            => $"Permissions.{feature}.{action}";
    }

    public static class Permissions
    {
        private static readonly ApplicationPermission[] _all = new ApplicationPermission[]
        {
            new(ApplicationFeature.Users, ApplicationAction.Create, ApplicationRoleGroup.SystemAccess, "Create Users"),
            new(ApplicationFeature.Users, ApplicationAction.Update, ApplicationRoleGroup.SystemAccess, "Update Users"),
            new(ApplicationFeature.Users, ApplicationAction.Read, ApplicationRoleGroup.SystemAccess, "Read Users"),
            new(ApplicationFeature.Users, ApplicationAction.Delete, ApplicationRoleGroup.SystemAccess, "Delete Users"),

            new(ApplicationFeature.UsersRoles, ApplicationAction.Read, ApplicationRoleGroup.SystemAccess, "Read User Roles"),
            new(ApplicationFeature.UsersRoles, ApplicationAction.Update, ApplicationRoleGroup.SystemAccess, "Update User Roles"),

            new(ApplicationFeature.Roles, ApplicationAction.Read, ApplicationRoleGroup.SystemAccess, "Read Roles"),
            new(ApplicationFeature.Roles, ApplicationAction.Create, ApplicationRoleGroup.SystemAccess, "Create Roles"),
            new(ApplicationFeature.Roles, ApplicationAction.Update, ApplicationRoleGroup.SystemAccess, "Update Roles"),
            new(ApplicationFeature.Roles, ApplicationAction.Delete, ApplicationRoleGroup.SystemAccess, "Delete Roles"),

            new(ApplicationFeature.RoleClaims, ApplicationAction.Read, ApplicationRoleGroup.SystemAccess, "Read Role Claims/Permissions"),
            new(ApplicationFeature.RoleClaims, ApplicationAction.Update, ApplicationRoleGroup.SystemAccess, "Update Role Claims/Permissions"),

            new(ApplicationFeature.Employees, ApplicationAction.Read, ApplicationRoleGroup.HierarchyManagement, "Read Employees", IsBasicPermission: true),
            new(ApplicationFeature.Employees, ApplicationAction.Create, ApplicationRoleGroup.HierarchyManagement, "Create Employees"),
            new(ApplicationFeature.Employees, ApplicationAction.Update, ApplicationRoleGroup.HierarchyManagement, "Update Employees"),
            new(ApplicationFeature.Employees, ApplicationAction.Delete, ApplicationRoleGroup.HierarchyManagement, "Delete Employees"),
        };
    }

    public class ApplicationPermissions
    {
        private static readonly ApplicationPermission[] _all = new ApplicationPermission[]
        public static IReadOnlyList<ApplicationPermission> AdminPermissions { get; } =
       new ReadOnlyCollection<ApplicationPermission>(
           _all.Where(p => !p.IsBasicPermission).ToList()
       );

        public static IReadOnlyList<ApplicationPermission> BasicPermissions { get; } =
            new ReadOnlyCollection<ApplicationPermission>(
                _all.Where(p => p.IsBasicPermission).ToList()
            );
    }
}
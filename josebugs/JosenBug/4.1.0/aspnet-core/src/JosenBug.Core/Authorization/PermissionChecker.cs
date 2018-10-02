using Abp.Authorization;
using JosenBug.Authorization.Roles;
using JosenBug.Authorization.Users;

namespace JosenBug.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

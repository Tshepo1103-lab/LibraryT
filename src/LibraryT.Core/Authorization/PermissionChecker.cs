using Abp.Authorization;
using LibraryT.Authorization.Roles;
using LibraryT.Authorization.Users;

namespace LibraryT.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

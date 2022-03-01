using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;


namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetUserRole();
        Response AddUserRole(UserRole userRole);
        Response UpdateUserRole(UserRole userRole);
        Response DeleteUserRole(int userRoleId);
        UserRole GetUserRoleById(int userRoleId);
    }
}

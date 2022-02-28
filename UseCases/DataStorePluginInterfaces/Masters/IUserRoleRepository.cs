using CoreBusiness.Masters;
using System.Collections.Generic;


namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetUserRole();
        void AddUserRole(UserRole userRole);
        void UpdateUserRole(UserRole userRole);
        void DeleteUserRole(int userRoleId);
        UserRole GetUserRoleById(int userRoleId);
    }
}

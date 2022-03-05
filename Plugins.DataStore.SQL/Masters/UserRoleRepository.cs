using CoreBusiness;
using CoreBusiness.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.Masters
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public UserRoleRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddUserRole(UserRole userRole)
        {
            if (userRole != null)
                try
                {
                    _db.UserRoles.Add(userRole);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "User Role is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteUserRole(int UserRoleId)
        {
            var userRole = _db.UserRoles.Find(UserRoleId);
            if (userRole == null) return response;
            try
            {
                _db.UserRoles.Remove(userRole);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "User Role is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<UserRole> GetUserRole()
        {
            return _db.UserRoles.ToList();
        }

        public UserRole GetUserRoleById(int UserRoleId)
        {
            return _db.UserRoles.Find(UserRoleId);
        }

        public Response UpdateUserRole(UserRole userRole)
        {
            var user = _db.UserRoles.Find(userRole.UserRoleId);
            if (userRole == null) return response;
            try
            {
                user.RoleName = userRole.RoleName;
                user.ShortDescription = userRole.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "User Role is Updated Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }
    }
}

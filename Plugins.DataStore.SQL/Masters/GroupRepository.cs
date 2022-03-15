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
    public class GroupRepository: IGroupRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public GroupRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddGroup(Group group)
        {
            if (group != null)
                try
                {
                    _db.Groups.Add(group);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Group is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteGroup(int GroupId)
        {
            var group = _db.Groups.Find(GroupId);
            if (group == null) return response;
            try
            {
                _db.Groups.Remove(group);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Group is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Group> GetGroup()
        {
            return _db.Groups.ToList();
        }

        public Group GetGroupById(int GroupId)
        {
            return _db.Groups.Find(GroupId);
        }

        public Response UpdateGroup(Group group)
        {
            var grp = _db.Groups.Find(group.GroupId);
            if (group == null) return response;
            try
            {
                grp.GroupName = group.GroupName;
                grp.ShortDescription = group.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Group is Updated Successfuly";
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

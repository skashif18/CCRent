using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            throw new NotImplementedException();
        }

        public Response DeleteGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetGroup()
        {
            throw new NotImplementedException();
        }

        public Group GetGroupById(int groupId)
        {
            throw new NotImplementedException();
        }

        public Response UpdateGroup(Group group)
        {
            throw new NotImplementedException();
        }
    }
}

using CoreBusiness;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroup();
        Response AddGroup(Group group);
        Response UpdateGroup(Group group);
        Response DeleteGroup(int groupId);
        Group GetGroupById(int groupId);
    }
}

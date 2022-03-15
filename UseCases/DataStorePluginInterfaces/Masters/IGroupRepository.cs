using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;


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

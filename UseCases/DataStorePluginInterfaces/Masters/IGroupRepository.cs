using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroup();
        void AddGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(int groupId);
        Group GetGroupById(int groupId);
    }
}

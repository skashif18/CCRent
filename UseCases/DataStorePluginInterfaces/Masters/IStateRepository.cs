using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IStateRepository
    {
        IEnumerable<State> GetState();
        void AddState(State state);
        void UpdateState(State state);
        void DeleteState(int stateId);
        State GetStateById(int stateId);
    }
}

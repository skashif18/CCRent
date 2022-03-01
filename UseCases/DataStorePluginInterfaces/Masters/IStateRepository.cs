using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IStateRepository
    {
        IEnumerable<State> GetState();
        Response AddState(State state);
        Response UpdateState(State state);
        Response DeleteState(int stateId);
        State GetStateById(int stateId);
    }
}

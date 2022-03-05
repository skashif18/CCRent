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
    public class StateRepository : IStateRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public StateRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddState(State state)
        {
            if (state != null)
                try
                {
                    _db.States.Add(state);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "State is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteState(int StateId)
        {
            var state = _db.States.Find(StateId);
            if (state == null) return response;
            try
            {
                _db.States.Remove(state);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "State is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<State> GetState()
        {
            return _db.States.ToList();
        }

        public State GetStateById(int StateId)
        {
            return _db.States.Find(StateId);
        }

        public Response UpdateState(State state)
        {
            var ste = _db.States.Find(state.StateId);
            if (state == null) return response;
            try
            {
                ste.Name = state.Name;
                ste.Code = state.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "State is Updated Successfuly";
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

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
    public class PayHeadRepository : IPayHeadRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public PayHeadRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddPayHead(PayHead payHead)
        {
            if (payHead != null)
                try
                {
                    _db.PayHeads.Add(payHead);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Pay Head is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeletePayHead(int PayHeadId)
        {
            var payHead = _db.PayHeads.Find(PayHeadId);
            if (payHead == null) return response;
            try
            {
                _db.PayHeads.Remove(payHead);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Pay Head is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<PayHead> GetPayHead()
        {
            return _db.PayHeads.ToList();
        }

        public PayHead GetPayHeadById(int PayHeadId)
        {
            return _db.PayHeads.Find(PayHeadId);
        }

        public Response UpdatePayHead(PayHead payHead)
        {
            var pay = _db.PayHeads.Find(payHead.PayHeadId);
            if (payHead == null) return response;
            try
            {
                pay.Description = payHead.Description;
                pay.Code = payHead.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Pay Head is Updated Successfuly";
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

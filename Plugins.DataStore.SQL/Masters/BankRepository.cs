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
    public class BankRepository : IBankRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public BankRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddBank(Bank bank)
        {
            if (bank != null)
                try
                {
                    _db.Banks.Add(bank);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Bank is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteBank(int BankId)
        {

            var bank = _db.Banks.Find(BankId);
            if (bank == null) return response;
            try
            {
                _db.Banks.Remove(bank);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Branch is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Bank> GetBank()
        {
            return _db.Banks.ToList();
        }

        public Bank GetBankById(int BankId)
        {
            return _db.Banks.Find(BankId);
        }

        public Response UpdateBank(Bank bank)
        {
            
            var ban = _db.Banks.Find(bank.BankId);
            if (bank == null) return response;
            try
            {
                ban.Description = bank.Description;
                ban.Code = bank.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Bank is Updated Successfuly";
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

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
    public class CompanySelectionRepository : ICompanySelectionRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public CompanySelectionRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }
        public Response AddCompanySelection(CompanySelection companySelection)
        {
            if (companySelection != null)
                try
                {
                    _db.CompanySelections.Add(companySelection);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Company is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteCompanySelection(int CompanyId)
        {
            var companySelection = _db.CompanySelections.Find(CompanyId);
            if (companySelection == null) return response;
            try
            {
                _db.CompanySelections.Remove(companySelection);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Company is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<CompanySelection> GetCompanySelection()
        {
            return _db.CompanySelections.ToList();
        }

        public CompanySelection GetCompanySelectionById(int companyId)
        {
            return _db.CompanySelections.Find(companyId);
        }

        public Response UpdateCompanySelection(CompanySelection companySelection)
        {
            var companySlt = _db.CompanySelections.Find(companySelection.CompanyId);
            if (companySelection == null) return response;
            try
            {
                companySlt.CompanyName = companySelection.CompanyName;
                companySlt.ShortDescription = companySelection.ShortDescription;
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

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
    public class CompanyGroupRepository : ICompanyGroupRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public CompanyGroupRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }
        public Response AddCompanyGroup(CompanyGroup companyGroup)
        {
            if (companyGroup != null)
                try
                {
                    _db.CompanyGroups.Add(companyGroup);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Company Group is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteCompanyGroup(int CompanyGroupId)
        {
            var companyGroup = _db.CompanyGroups.Find(CompanyGroupId);
            if (companyGroup == null) return response;
            try
            {
                _db.CompanyGroups.Remove(companyGroup);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Company Group is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<CompanyGroup> GetCompanyGroup()
        {
            return _db.CompanyGroups.ToList();
        }

        public CompanyGroup GetCompanyGroupById(int CompanyGroupId)
        {
            return _db.CompanyGroups.Find(CompanyGroupId);
        }

        public Response UpdateCompanyGroup(CompanyGroup companyGroup)
        {
            var companyGrp = _db.CompanyGroups.Find(companyGroup.CompanyGroupId);
            if (companyGroup == null) return response;
            try
            {
                companyGrp.Description = companyGroup.Description;
                companyGrp.ShortDescription = companyGrp.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Company Group is Updated Successfuly";
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

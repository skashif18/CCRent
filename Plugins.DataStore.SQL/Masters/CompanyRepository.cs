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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public CompanyRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddCompany(Company company)
        {
            if (company != null)
                try
                {
                    _db.Companies.Add(company);
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

        public Response DeleteCompany(int CompanyId)
        {
            var company = _db.Companies.Find(CompanyId);
            if (company == null) return response;
            try
            {
                _db.Companies.Remove(company);
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

        public IEnumerable<Company> GetCompany()
        {
            return _db.Companies.ToList();
        }

        public Company GetCompanyById(int CompanyId)
        {
            return _db.Companies.Find(CompanyId);
        }

        public Response UpdateCompany(Company company)
        {
            var comp = _db.Companies.Find(company.CompanyId);
            if (company == null) return response;
            try
            {
                comp.Description = company.Description;
                comp.ShortDescription = company.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Company is Updated Successfuly";
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

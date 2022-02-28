using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompany();
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int companyId);
        Company GetCompanyById(int companyId);
    }
}

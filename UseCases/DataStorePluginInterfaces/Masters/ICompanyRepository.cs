using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompany();
        Response AddCompany(Company company);
        Response UpdateCompany(Company company);
        Response DeleteCompany(int companyId);
        Company GetCompanyById(int companyId);
    }
}

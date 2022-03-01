using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICompanySelectionRepository
    {
        IEnumerable<CompanySelection> GetCompanySelection();
        Response AddCompanySelection(CompanySelection companySelection);
        Response UpdateCompanySelection(CompanySelection companySelection);
        Response DeleteCompanySelection(int companySelectionId);
        CompanySelection GetCompanySelectionById(int companySelectionId);
    }
}

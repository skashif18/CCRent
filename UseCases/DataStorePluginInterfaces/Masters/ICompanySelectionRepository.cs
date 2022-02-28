using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICompanySelectionRepository
    {
        IEnumerable<CompanySelection> GetCompanySelection();
        void AddCompanySelection(CompanySelection companySelection);
        void UpdateCompanySelection(CompanySelection companySelection);
        void DeleteCompanySelection(int companySelectionId);
        CompanySelection GetCompanySelectionById(int companySelectionId);
    }
}

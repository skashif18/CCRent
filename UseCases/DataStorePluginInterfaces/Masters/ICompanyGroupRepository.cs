using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICompanyGroupRepository
    {
        IEnumerable<CompanyGroup> GetCompanyGroup();
        void AddCompanyGroup(CompanyGroup companyGroup);
        void UpdateCompanyGroup(CompanyGroup companyGroup);
        void DeleteCompanyGroup(int companyGroupId);
        CompanyGroup GetCompanyGroupById(int companyGroupId);
    }
}


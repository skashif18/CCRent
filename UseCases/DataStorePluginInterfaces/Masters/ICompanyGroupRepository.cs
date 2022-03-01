using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICompanyGroupRepository
    {
        IEnumerable<CompanyGroup> GetCompanyGroup();
        Response AddCompanyGroup(CompanyGroup companyGroup);
        Response UpdateCompanyGroup(CompanyGroup companyGroup);
        Response DeleteCompanyGroup(int companyGroupId);
        CompanyGroup GetCompanyGroupById(int companyGroupId);
    }
}


using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICostCenterRepository
    {
        IEnumerable<CostCenter> GetCostCenter();
        Response AddCostCenter(CostCenter costCenter);
        Response UpdateCostCenter(CostCenter costCenter);
        Response DeleteCostCenter(int costCenterId);
        CostCenter GetCostCenterById(int costCenterId);
    }
}

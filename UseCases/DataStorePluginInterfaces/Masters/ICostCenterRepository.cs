using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICostCenterRepository
    {
        IEnumerable<CostCenter> GetCostCenter();
        void AddCostCenter(CostCenter costCenter);
        void UpdateCostCenter(CostCenter costCenter);
        void DeleteCostCenter(int costCenterId);
        CostCenter GetCostCenterById(int costCenterId);
    }
}

using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetBranch();
        Response AddBranch(Branch branch);
        Response UpdateBranch(Branch branch);
        Response DeleteBranch(int branchId);
        Branch GetBranchById(int branchId);
    }
}

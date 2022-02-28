using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IBranchRepository
    {
        IEnumerable<Branch> GetBranch();
        void AddBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void DeleteBranch(int branchId);
        Branch GetBranchById(int branchId);
    }
}

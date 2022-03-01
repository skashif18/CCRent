using CoreBusiness;
using CoreBusiness.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.Masters
{
    public class BranchRepository : IBranchRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public BranchRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddBranch(Branch branch)
        {
            if(branch != null)
            try
            {
                _db.Branches.Add(branch);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Branch is Added Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public Response DeleteBranch(int BranchId)
        {
            var branch = _db.Branches.Find(BranchId);
            if (branch == null) return response;
            else
                try
                {
                    _db.Branches.Remove(branch);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Branch is Removed Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }
            return response;
        }
        public IEnumerable<Branch> GetBranch()
        {
            return _db.Branches.ToList();
        }

        public Branch GetBranchById(int BranchId)
        {
            return _db.Branches.Find(BranchId);
        }

        public Response UpdateBranch(Branch branch)
        {
            var bar = _db.Branches.Find(branch.BranchId);
            if (branch == null) return response;
            try
            {
                bar.Description = branch.Description;
                bar.ShortDescription = branch.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Branch is Updated Successfuly";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }

            return response;
        }
    }


}


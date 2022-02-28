using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IDesignationRepository
    {
        IEnumerable<Designation> GetDesignation();
        void AddDesignation(Designation designation);
        void UpdateDesignation(Designation designation);
        void DeleteDesignation(int designationId);
        Designation GetDesignationById(int designationId);
    }
}

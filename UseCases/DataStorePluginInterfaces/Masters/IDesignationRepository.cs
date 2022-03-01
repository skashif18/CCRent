using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IDesignationRepository
    {
        IEnumerable<Designation> GetDesignation();
        Response AddDesignation(Designation designation);
        Response UpdateDesignation(Designation designation);
        Response DeleteDesignation(int designationId);
        Designation GetDesignationById(int designationId);
    }
}

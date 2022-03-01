using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;


namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IDivisionRepository
    {
        IEnumerable<Division> GetDivision();
        Response AddDivision(Division division);
        Response UpdateDivision(Division division);
        Response DeleteDivision(int divisionId);
        Division GetDivisionById(int divisionId);
    }
}

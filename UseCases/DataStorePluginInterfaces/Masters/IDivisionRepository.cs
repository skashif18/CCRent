using CoreBusiness.Masters;
using System.Collections.Generic;


namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IDivisionRepository
    {
        IEnumerable<Division> GetDivision();
        void AddDivision(Division division);
        void UpdateDivision(Division division);
        void DeleteDivision(int divisionId);
        Division GetDivisionById(int divisionId);
    }
}

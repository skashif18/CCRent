using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetBank();
        Response AddBank(Bank bank);
        Response UpdateBank(Bank bank);
        Response DeleteBank(int bankId);
        Bank GetBankById(int bankId);
    }
}

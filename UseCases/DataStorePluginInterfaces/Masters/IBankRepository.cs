using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetBank();
        void AddBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(int bankId);
        Bank GetBankById(int bankId);
    }
}

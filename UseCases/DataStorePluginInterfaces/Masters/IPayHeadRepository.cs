using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IPayHeadRepository
    {
        IEnumerable<PayHead> GetPayHead();
        void AddPayHead(PayHead payHead);
        void UpdatePayHead(PayHead payHead);
        void DeletePayHead(int payHeadId);
        PayHead GetPayHeadById(int payHeadId);
    }
}

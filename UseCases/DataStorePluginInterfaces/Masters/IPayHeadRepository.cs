using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IPayHeadRepository
    {
        IEnumerable<PayHead> GetPayHead();
        Response AddPayHead(PayHead payHead);
        Response UpdatePayHead(PayHead payHead);
        Response DeletePayHead(int payHeadId);
        PayHead GetPayHeadById(int payHeadId);
    }
}

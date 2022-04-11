using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();
        string GetId();
    }
}

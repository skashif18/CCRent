namespace Appo.Server.Features.Search
{
    using Appo.Server.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ISearchService
    {

        Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string search);
    }
}

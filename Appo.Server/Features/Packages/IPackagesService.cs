namespace Appo.Server.Features.Packages
{
    using Appo.Server.Features.Packages.Models;
    using Appo.Server.Infrastructure.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPackagesService
    {
        Task<int> Create(string heading, string description, string imageUrl, string userId);

        Task<Result> Update(int id, string heading, string description, string userId);
        Task<Result> Delete(int id, string userId);
        Task<IEnumerable<PackageListServiceModel>> Get(string userId);

        Task<PackageDetailsServiceModel> Details(int id);

      

    }
}

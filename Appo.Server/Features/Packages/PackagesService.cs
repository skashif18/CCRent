namespace Appo.Server.Features.Packages
{
    using Appo.Server.Data;
    using Appo.Server.Data.Models;
    using Appo.Server.Features.Packages.Models;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PackagesService : IPackagesService
    {
        private readonly AppoDbContext db;

        public PackagesService(AppoDbContext db)
        {
            this.db = db;
        }
        public async Task<int> Create(string heading, string description, string imageUrl, string userId)
        {
            var package = new Package
            {
                Heading = heading,
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };
            db.Add(package);
            await db.SaveChangesAsync();
            return package.Id;
        }
        public async Task<PackageDetailsServiceModel> Details(int id)
        => await this.db
            .Packages
            .Where(m => m.Id == id)
            .Select(m => new PackageDetailsServiceModel
            {
                Id = m.Id,
                UserId = m.UserId,
                Heading = m.Heading,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                UserName = m.User.UserName
            }).FirstOrDefaultAsync();

        public async Task<IEnumerable<PackageListServiceModel>> Get(string userId)
        => await this.db
            .Packages
            .Where(m => m.UserId == userId)
            .OrderByDescending(m=>m.CreatedOn)
            .Select(m => new PackageListServiceModel
            {
                Id = m.Id,
                Heading = m.Heading,
                Description = m.Description,
                ImageUrl = m.ImageUrl
            }).ToListAsync();

        public async Task<Result> Update(int id, string heading, string description, string userId)
        {
            var v = await this.GetPackageByIdAndUserId(id, userId);

            if (v == null) return "You can not update this Package ";

            v.Heading = heading;
            v.Description = description;
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<Result> Delete(int id, string userId)
        {
            var v = await this.GetPackageByIdAndUserId(id, userId);

            if (v == null) 
                return "You can not delete this package";

            this.db.Packages.Remove(v);
            await this.db.SaveChangesAsync();

            return true;
        }

        private async Task<Package> GetPackageByIdAndUserId(int id, string userId)
            => await this.db
                .Packages
                .Where(m => m.Id == id && m.UserId == userId)
                .FirstOrDefaultAsync();

    }
}

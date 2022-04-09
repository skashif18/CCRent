using Appo.Server.Data;
using Appo.Server.Features.Search.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appo.Server.Features.Search
{
    public class SearchService : ISearchService
    {

        private readonly AppoDbContext db;

        public SearchService(AppoDbContext db)
       => this.db = db;

        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string search)
            => await this.db
                .Users
                .Where(m => m.UserName.ToLower().Contains(search) || m.Profile.Name.Contains(search))
                .Select(m => new ProfileSearchServiceModel
                {
                    UserId = m.Id,
                    UserName = m.UserName,
                    ProfilePhotoUrl = m.Profile.MainPhotoUrl
                })
                .ToListAsync();

    }
}

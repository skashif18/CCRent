using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appo.Server.Features.Search.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appo.Server.Features.Search
{
    
    public class SearchController : ApiController
    {
        private readonly ISearchService search;

        public SearchController(ISearchService search)
               => this.search = search;

        [Route(nameof(Profiles))]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
                => await this.search.Profiles(query);
    }
}

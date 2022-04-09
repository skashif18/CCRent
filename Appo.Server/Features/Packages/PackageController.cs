namespace Appo.Server.Features.Packages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Appo.Server.Features.Packages.Models;
    using Appo.Server.Infrastructure.Extensions;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Infrastructure.WebConstants;
   
    public class PackageController : ApiController
    {
        private readonly IPackagesService packages;

        private readonly ICurrentUserService currentUser;

        public PackageController(IPackagesService packages,ICurrentUserService currentUser)
        {
            this.packages= packages;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<PackageListServiceModel>> Get()
            => await packages.Get(this.currentUser.GetId());


        [HttpGet]
        [Route(Id)]
        public async Task<PackageDetailsServiceModel> Details(int id)
            => await packages
                    .Details(id);



        [HttpPost]
        public async Task<ActionResult> Create(CreatePackageRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var id = await packages.Create(
                model.Heading,
                model.Description,
                model.ImageUrl,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdatePackageRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var result = await packages.Update(
                model.Id,
                model.Heading,
                model.Description,
                userId);

            if (!result.Succeeded) 
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();
            var result = await packages.Delete(id,userId);

            if (!result.Succeeded) 
                return BadRequest(result.Error);

            return Ok();
        }
    }
}

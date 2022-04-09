namespace Appo.Server.Features.Profiles
{
    using Appo.Server.Features.Follows;
    using Appo.Server.Features.Profiles.Models;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualBasic;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Infrastructure.WebConstants;
    public class ProfilesController : ApiController
    {
        private readonly IProfileService profile;
        private readonly IFollowService follow;
        private readonly ICurrentUserService currentUser;
        public ProfilesController(IProfileService profile,
                                IFollowService follow,
                                ICurrentUserService currentUser
                                )

        {
            this.profile = profile;
            this.currentUser = currentUser;
            this.follow = follow;
        }

        [HttpGet]
        public async Task<ProfileServiceModel> Get()
                => await this.profile.Get(this.currentUser.GetId(), isPublic: true);




        [HttpGet]
        [AllowAnonymous]
        [Route(Id)]
        public async Task<ProfileServiceModel> Get(string Id)
        {
            var allinformation = await this.follow.IsFollower(Id, this.currentUser.GetId());
            if (!allinformation)
                allinformation = !await this.profile.IsPrivate(Id);

            return await this.profile.Get(Id, allinformation);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.profile.Update(model, userId);

            if (!result.Succeeded)
                return BadRequest(result.Error);

            return Ok();
        }



    }
}

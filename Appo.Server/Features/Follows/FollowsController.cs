namespace Appo.Server.Features.Follows
{
    using Appo.Server.Features.Follows.Models;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class FollowsController : ApiController
    {

        private readonly IFollowService follow;
        private readonly ICurrentUserService currentUser;

        public FollowsController(IFollowService follow, ICurrentUserService currentUser)
        {
            this.follow = follow;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async  Task<ActionResult> Create(FollowRequestModel model)
        {
            var result =  await this.follow.Follow(model.UserId, this.currentUser.GetId());
            
            if (!result.Succeeded) return BadRequest(result.Error);

            return Ok();
        }
    }
}

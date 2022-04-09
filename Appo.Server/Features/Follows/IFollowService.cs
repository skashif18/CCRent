

namespace Appo.Server.Features.Follows
{
    using Appo.Server.Infrastructure.Services;
    using System;
    using System.Threading.Tasks;

    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followersId);
        Task<bool> IsFollower(string userId, string followersId);
    }
}

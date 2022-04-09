namespace Appo.Server.Features.Follows
{
    using Appo.Server.Data;
    using Appo.Server.Data.Models;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    public class FollowService : IFollowService
    {
        private readonly AppoDbContext db;

        public FollowService(AppoDbContext db)
        => this.db = db;

        public async Task<Result> Follow(string userId, string followersId)
        {
            var userAlreadyFollowed = await this.db
                .Follows
                .AnyAsync(u => u.UserId == userId && u.FollowerId == followersId);

            if (userAlreadyFollowed)
                return "You are already following";

            var publicProfile = await this.db
                .Profiles
                .Where(p => p.UserId == userId)
                .Select(p => !p.IsPrivate)
                .FirstOrDefaultAsync();

            this.db.Follows.Add(new Follow
            {
                UserId = userId,
                FollowerId = followersId,
                IsApproved = publicProfile

            });

            await this.db.Follows.SingleOrDefaultAsync();

            return true;
        }

        public Task<bool> IsFollower(string userId, string followersId)
            => this.db
                .Follows
                .AnyAsync(m =>
                    m.UserId == userId &&
                    m.FollowerId == followersId &&
                    m.IsApproved
                );
    }
}

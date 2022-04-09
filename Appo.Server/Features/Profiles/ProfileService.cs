namespace Appo.Server.Features.Profiles
{
    using Appo.Server.Data;
    using Appo.Server.Data.Models;
    using Appo.Server.Features.Profiles.Models;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    public class ProfileService : IProfileService
    {
        private readonly AppoDbContext db;

        public ProfileService(AppoDbContext db)
            => this.db = db;

        public async Task<ProfileServiceModel> Get(string userId, bool isPublic = false)
            => await this
                .db
            .Users
            .Where(m => m.Id == userId)

            .Select(m =>
                    !isPublic ?
                        new ProfileServiceModel
                        {
                            Name = m.Profile.Name,
                            MainPhotoUrl = m.Profile.MainPhotoUrl,
                            IsPrivate = m.Profile.IsPrivate

                        } :
                        new PublicProfileServiceModel
                        {
                            Name = m.Profile.Name,
                            MainPhotoUrl = m.Profile.MainPhotoUrl,
                            Website = m.Profile.Website,
                            Biography = m.Profile.Biography,
                            Gender = m.Profile.Gender.ToString(),
                            IsPrivate = m.Profile.IsPrivate

                        }).FirstOrDefaultAsync();

        public async Task<bool> IsPrivate(string userId)
            => await this.db
            .Profiles
            .Where(m => m.UserId == userId)
            .Select(m => m.IsPrivate).FirstOrDefaultAsync();

        public async Task<Result> Update(UpdateProfileRequestModel model, string userId)
        {

            var v = await this.GetUserById(userId);

            if (v == null) return "User Dose not exist.";

            if (v.Profile is null) v.Profile = new Profile();

            if (v.UserName != model.Email)
            {

                var IsExist = await this
                        .db
                        .Users
                        .AnyAsync(u => u.Id != userId && u.Email == model.Email);

                if (IsExist) return "Email already exist";
                v.Email = model.Email;
            }
            if (v.Email != model.Email)
            {

                var IsExist = await this
                        .db
                        .Users
                        .AnyAsync(u => u.Id != userId && u.UserName == model.UserName);

                if (IsExist) return "User Name already exist";
                v.UserName = model.UserName;
            }

            if (v.Profile.Name != model.Name)
                v.Profile.Name = model.Name;

            if (v.Profile.MainPhotoUrl != model.MainPhotoUrl)
                v.Profile.MainPhotoUrl = model.MainPhotoUrl;

            if (v.Profile.Website != model.Website)
                v.Profile.Website = model.Website;

            if (v.Profile.IsPrivate != model.IsPrivate)
                v.Profile.IsPrivate = model.IsPrivate;

            if (v.Profile.Biography != model.Biography)
                v.Profile.Biography = model.Biography;

            if (v.Profile.Gender != model.Gender)
                v.Profile.Gender = model.Gender;

            await this.db.SaveChangesAsync();
            return true;
        }

        private async Task<User> GetUserById(string id)
           => await this.db
               .Users
               .Include(m => m.Profile)
               .FirstOrDefaultAsync(m => m.Id == id);
    }
}

namespace Appo.Server.Features.Profiles
{
    using Appo.Server.Infrastructure.Services;
    using Profiles.Models;
    using System.Threading.Tasks;

    public interface IProfileService
    {
        Task<ProfileServiceModel> Get(string userId,bool isPublic=false);
        Task<Result> Update(UpdateProfileRequestModel model, string userId);
        Task<bool> IsPrivate(string userId);

    }
}

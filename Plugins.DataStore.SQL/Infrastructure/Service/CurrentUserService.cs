using Microsoft.AspNetCore.Http;
using Plugins.DataStore.SQL.Infrastructure.Extensions;
using System.Security.Claims;

namespace Plugins.DataStore.SQL.Infrastructure.Services
{

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
                => this.user = httpContextAccessor.HttpContext?.User;

        public string GetId()
            => user?.GetId();

        public string GetUserName()
        => user?.Identity?.Name;

    }
}

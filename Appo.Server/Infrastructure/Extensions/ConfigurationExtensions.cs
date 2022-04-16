

namespace Appo.Server.Infrastructure.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigurationExtensions
    {

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
        public static string GetAccountConnectionString(this IConfiguration configuration)
           => configuration.GetConnectionString("AccountContextConnection");

    }
}

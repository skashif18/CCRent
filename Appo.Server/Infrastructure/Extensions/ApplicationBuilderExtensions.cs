using Appo.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Appo.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        => app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP.Server API");
                    c.RoutePrefix = string.Empty;
                });
        public static void ApplyMigrations(this IApplicationBuilder app) {
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<AppoDbContext>();
            dbContext.Database.Migrate();
        }
    }
}

namespace Appo.Server.Infrastructure
{
    using Appo.Server.Data;
    using Appo.Server.Features.Identity;
    using Appo.Server.Infrastructure.Extensions;
    using Appo.Server.Infrastructure.Filters;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Plugins.DataStore.SQL;
    using Plugins.DataStore.SQL.Infrastructure.Services;
    using Plugins.DataStore.SQL.Masters;
    using Plugins.DataStore.SQL.ServiceRepository;
    using System;
    using System.Text;
    using UseCases.DataStorePluginInterfaces.Masters;
    using UseCases.DataStorePluginInterfaces.SrvTable.Supplier;

    public static class ServiceCollectionExtensions
    {

        public static AppSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingConfigration = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingConfigration);
            return appSettingConfigration.Get<AppSettings>();
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {

            services.AddIdentity<IdentityUser, IdentityRole>(option
                    =>
            {
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;

            })
                .AddEntityFrameworkStores<AccountContext>();
            return services;
        }

        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, AppSettings appSetting)
        {

            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IGetMasterRepository, GetMasterRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();


            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<CarRentContext>(
                options =>
                     options.UseSqlServer(
                         configuration.GetDefaultConnectionString()))

            .AddDbContext<AccountContext>(
                options =>
                     options.UseSqlServer(
                         configuration.GetAccountConnectionString()));

        public static void AddApiController(this IServiceCollection services)
            => services
            .AddControllers(option => option
                            .Filters
                            .Add<ModelOrNotFoundActionFilter>());
        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Appo.Server API",
                    Description = "Appo.Server ASP.NET Core Web API",
                    TermsOfService = new Uri("https://kashifabbas.dev"),
                    Contact = new OpenApiContact
                    {
                        Name = "Kashif Abbas",
                        Email = "me@kashifabbas.dev",
                        Url = new Uri("https://twitter.com/skashif18"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://kashifabbas.dev"),
                    }
                });
            });

    }
}

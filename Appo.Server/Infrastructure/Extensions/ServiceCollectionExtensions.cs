namespace Appo.Server.Infrastructure
{
    using Appo.Server.Data;
    using Appo.Server.Features.Category.Services;
    using Appo.Server.Features.Identity;
    using Appo.Server.Features.Master.Service;
    using Appo.Server.Features.Service.Service;
    using Appo.Server.Features.ServiceAddOn.Service;
    using Appo.Server.Features.ServiceAttachment.Service;
    using Appo.Server.Features.ServiceAttachmentType.Service;
    using Appo.Server.Features.ServiceBookingRating.Service;
    using Appo.Server.Features.ServiceBookingReview.Service;
    using Appo.Server.Features.ServiceClassValue.Service;
    using Appo.Server.Features.ServiceEvaluationCriteria.Service;
    using Appo.Server.Features.ServiceRequest.Service;
    using Appo.Server.Features.ServiceRequestQuotation.Service;
    using Appo.Server.Features.ServiceSchedule.Service;
    using Appo.Server.Features.ServiceType.Service;
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
    using Plugins.DataStore.SQL.MastersRepositories;
    using Plugins.DataStore.SQL.ServiceRepository;
    using System;
    using System.Text;
    using System.Text.Json.Serialization;
    using UseCases.DataStorePluginInterfaces.Masters;
    using UseCases.DataStorePluginInterfaces.SrvTable;
    using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;
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

        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
            services.AddTransient<IClassRepository, ClassRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();


            services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddTransient<IServiceTypeService, ServiceTypeService>();

            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IServiceService, ServiceService>();

            services.AddTransient<IClassValueRepository, ClassValueRepository>();

            services.AddTransient<IServiceAttachmentRepository, ServiceAttachmentRepository>();
            services.AddTransient<IServiceAttachmentService, ServiceAttachmentService>();

            services.AddTransient<IServiceTypeAttachmentRepository, ServiceTypeAttachmentRepository>();
            services.AddTransient<IServiceAttachmentTypeService, ServiceAttachmentTypeService>();

            services.AddTransient<IMasterService, MasterService>();

            services.AddTransient<IServiceClassValueRepository, ServiceClassValueRepository>();
            services.AddTransient<IServiceClassValueService, ServiceClassValueService>();

            services.AddTransient<IServiceScheduleRepository, ServiceScheduleRepository>();
            services.AddTransient<IServiceScheduleService, ServiceScheduleService>();


            services.AddTransient<IServiceAddOnRepository, ServiceAddOnRepository>();
            services.AddTransient<IServiceAddOnService, ServiceAddOnService>();

            services.AddTransient<IServiceBookingRepository, ServiceBookingRepository>();
            services.AddTransient<IServiceBookingService, ServiceBookingService>();


            services.AddTransient<IServiceBookingRatingRepository, ServiceBookingRatingRepository>();
            services.AddTransient<IServiceBookingRatingService, ServiceBookingRatingService>();

            services.AddTransient<IServiceBookingReviewRepository, ServiceBookingReviewRepository>();
            services.AddTransient<IServiceBookingReviewService, ServiceBookingReviewService>();

            services.AddTransient<IServiceTypeEvaluationCriterionRepository, ServiceTypeEvaluationCriterionRepository>();
            services.AddTransient<IServiceEvaluationCriteriaService, ServiceEvaluationCriteriaService>();

            services.AddTransient<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddTransient<IServiceRequestService, ServiceRequestService>();

            services.AddTransient<IServiceRequestQuotationRepository, ServiceRequestQuotationRepository>();
            services.AddTransient<IServiceRequestQuotationService, ServiceRequestQuotationService>();


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
                            .Add<ModelOrNotFoundActionFilter>())
            .AddControllersAsServices().AddJsonOptions(
               x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                );

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CCRent.Server API",
                    Description = "CCRent.Server ASP.NET Core Web API",
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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

            });

    }
}

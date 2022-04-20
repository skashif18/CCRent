using Blazored.Toast;
using Blazorise;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.SQL;
using Plugins.DataStore.SQL.Infrastructure.Services;
using Plugins.DataStore.SQL.Masters;
using Plugins.DataStore.SQL.ServiceRepository;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.DataStorePluginInterfaces.Masters;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;
using WebApp.Data;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddBlazoredToast();
            
            services.AddDbContext<CarRentContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSyncfusionBlazor();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
                options.AddPolicy("CustomerOnly", p => p.RequireClaim("Position", "Customer"));
                options.AddPolicy("SupplierOnly", p => p.RequireClaim("Position", "Supplier"));
            });

            //Dependency Injection for In-Memory Data Store
            //services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
            //services.AddScoped<IProductRepository, ProductInMemoryRepository>();
            //services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

            //Dependency Injection for ef core Data Store for SQL
            services.AddTransient<INationalityRepository, NationalityRepository>();
            services.AddTransient<IReligionRepository, ReligionRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();

            services.AddTransient<IClassValueRepository, ClassValueRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();


            services.AddScoped<ICurrentUserService, CurrentUserService>();

            //Dependency Injection for Use Cases and Repositories

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

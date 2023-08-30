namespace Appo.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Appo.Server.Infrastructure;
    using Appo.Server.Infrastructure.Extensions;
    using Appo.Server.Infrastructure.Filters;
    using Microsoft.Extensions.FileProviders;
    using System.IO;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                    .AddDatabase(this.Configuration)
                    .AddIdentity()
                    .AddJWTAuthentication(services.GetAppSettings(this.Configuration))
                    .AddApplicationServices()
                    .AddSwagger()
                    .AddAutoMappers()
                    .AddApiController();


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

          
                app.UseDeveloperExceptionPage();
           
            app
                .UseSwaggerUI()
                .UseRouting()
                .UseCors(options =>
                    options.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "upload")),
                RequestPath = "/upload",
                EnableDefaultFiles = true
            });
            //.ApplyMigrations();
        }
    }
}

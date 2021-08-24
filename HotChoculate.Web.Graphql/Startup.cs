using HotChoculate.Infrastructure.Core.Configuration;
using HotChoculate.Infrastructure.Core.Interfaces;
using HotChoculate.Infrastructure.Core.Managers;
using HotChoculate.Infrastructure.Core.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace HotChoculate.Web.Graph
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;
        private readonly string CorsClient = "_corsclient";

        public Startup(IWebHostEnvironment env)
        {
            _env = env;

            // Load settings from json file and deserialise into classes
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true, reloadOnChange: true)
               .Build();

            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            
            // TODO need to add cors for localhost, preprod and others see conf
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsClient,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                    }
                    );
            });
            // Add our Config object so it can be injected
            services.Configure<DatabaseConfig>(Configuration.GetSection("DatabaseConfig"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IDatabaseNameProvider, DatabaseNameProvider>();
            services.AddTransient<IConnectionManager, ConnectionManager>();
            services.AddTransient<IMainDataBaseProvider, DatabaseProvider>();

            services.AddRepositories()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<EmployeeQueries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsClient);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}

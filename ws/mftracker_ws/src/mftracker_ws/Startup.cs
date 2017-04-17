using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using mftracker_ws.DatabaseContext;
using mftracker_ws.Repository;
using Microsoft.Extensions.Configuration.UserSecrets;

[assembly: UserSecretsId("aspnet-mftracker_ws-20170416074606")]
namespace mftracker_ws
{    
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);                          

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
                builder.AddUserSecrets<Startup>();
            }
            else
            {
                builder.AddAzureKeyVault(Configuration["Vault"], 
                    Configuration["ClientId"], Configuration["ClientSecret"]);                
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ConfigManager.Config>(new ConfigManager.Config(Configuration));
            services.AddDbContext<MutualFundContext>();
            services.AddSingleton<IAmcRepository, AmcRepository>();
            services.AddSingleton<INavRepository, NavRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();
            app.UseApplicationInsightsExceptionTelemetry();
            app.UseMvc();
        }
    }
}

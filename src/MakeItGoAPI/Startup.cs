using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MakeItGoAPI.Models;
using MakeItGoAPI.Repository;

namespace MakeItGoAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();          var connection = @"Server=(localdb)\mssqllocaldb;Database=MakeItGo;Trusted_Connection=True;";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            services.AddTransient(typeof(BootstrapMvc.Mvc6.BootstrapHelper<>));

            services.AddSingleton<DoctorRepository, DoctorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory
    .WithFilter(new FilterLoggerSettings
    {
        { "Microsoft", LogLevel.Warning },
        { "System", LogLevel.Warning },
        { "ToDoApi", LogLevel.Debug }
    });
            app.UseMvc();
        }
    }
}

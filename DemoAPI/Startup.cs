using DemoAPI.Factories;
using DemoAPI.Models;
using DemoAPI.Repositories;
using DemoAPI.Repositories;
using DemoAPI.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<ApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PlayerContextConnectionString")));
            
            /* Mock data setup */
            //services.AddSingleton<IPlayerData, MockPlayerData>();
            //services.AddSingleton<IScoreData, MockScoreData>();

            /* Data setup */
            services.AddScoped<IPlayerRepository, SqlPlayerRepository>();
            services.AddScoped<IScoreRepository, SqlScoreRepository>();

            /* Factory setup */
            services.AddScoped<IImpactReportFactory, ImpactReportFactory>();
            services.AddScoped<IWeeklySummaryFactory, WeeklySummaryFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

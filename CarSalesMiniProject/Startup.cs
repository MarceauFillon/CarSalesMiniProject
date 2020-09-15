using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarSalesMiniProject.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CarSalesMiniProject
{
    public class Startup
    {
        private string _contentRootPath = "";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _contentRootPath = env.ContentRootPath;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            if (connectionString.Contains("%CONTENTROOTPATH%"))
            {
                connectionString = connectionString.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }

            services.AddDbContext<VehiclesContext>(options => options.UseSqlServer(
                connectionString,
                providerOptions => providerOptions.EnableRetryOnFailure()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

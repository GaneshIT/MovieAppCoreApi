using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieAppCore.BAL.services;
using MovieAppCore.DAL.Data;
using MovieAppCore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * AddTransient
Transient lifetime services are created each time they are requested. 
This lifetime works best for lightweight, stateless services.

Transient objects are always different; 
a new instance is provided to every controller and every service

AddScoped
Scoped lifetime services are created once per request.

AddSingleton
Singleton lifetime services are created the first time they are requested 
(or when ConfigureServices is run if you specify an instance there) 
and then every subsequent request will use the same instance.
 */
namespace MovieAppCoreApi
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
            string connectionStr = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<MovieService, MovieService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

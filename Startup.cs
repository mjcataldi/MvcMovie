using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie
{
    public class Startup
    {
        private string _testSecret = null;
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc().AddSessionStateTempDataProvider();
            // services.AddSession(options => {
            //     options.IdleTimeout = TimeSpan.FromMinutes(10);
            //     options.Cookie.HttpOnly = true;
            // });

            // services.AddDbContext<MvcMovieContext>(options => options.UseSqlServer("Data Source=MvcMovie.db"));

            services.AddDbContext<MvcMovieContext>(options =>
                options.UseSqlite("Data Source=MvcMovie.db"));

            _testSecret = Configuration["MySecret"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                var builder = new ConfigurationBuilder();
                builder.AddUserSecrets<Startup>();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

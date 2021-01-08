using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestsData;

namespace DevLearn
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(opts =>
            {
                // Determines whether user consent for non-essential cookies is needed for a given request
                opts.CheckConsentNeeded = context => true;
                opts.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddDbContext<TestsDataDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TestsConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // Where is UseHttps();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            // Where is UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
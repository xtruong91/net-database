using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data;
using MySQL.Models;
using Pomelo.AspNetCore.Localization;

namespace MySQL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration Configuration;
            services.AddConfiguration(out Configuration);
            // Add framework services.
            if (Configuration["Database:Type"] == "SQLite")
            {
                services.AddDbContext<BlogContext>(x => x.UseSqlite(Configuration["Database:ConnectionString"]));
            }
            else if (Configuration["Database:Type"] == "MySQL")
            {
                services.AddDbContext<BlogContext>(x => x.UseMySql(Configuration["Database:ConnectionString"]));
            }

            services.AddSmartCookies();
            services.AddMemoryCache();
            services.AddSession(x => x.IdleTimeout = TimeSpan.FromMinutes(20));

            services.AddBlobStorage()
                .AddEntityFrameworkStorage<BlogContext>()
                .AddSessionUploadAuthorization();

            services.AddPomeloLocalization(x =>
            {
                x.AddCulture(new string[] { "zh", "zh-CN", "zh-Hans", "zh-Hans-CN", "zh-cn" }, new JsonLocalizedStringStore(Path.Combine("Localization", "zh-CN.json")));
                x.AddCulture(new string[] { "en", "en-US", "en-GB" }, new JsonLocalizedStringStore(Path.Combine("Localization", "en-US.json")));
            });

            services.AddMvc()
                .AddMultiTemplateEngine()
                .AddCookieTemplateProvider();

            services.AddTimedJob();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Warning, true);

            app.UseStaticFiles();
            app.UseSession();
            app.UseBlobStorage("/assets/shared/scripts/jquery.codecomb.fileupload.js");
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();

            await SampleData.InitializeBlog(app.ApplicationServices);

            app.UseTimedJob();
        }
    }
}

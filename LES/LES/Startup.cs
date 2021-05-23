using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LES.Controllers;
using LES.Controllers.Facade;
using LES.Data.DAO;
using LES.Models;
using LES.Models.Schedulers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LES
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
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "LoginCookie";
                     config.LoginPath = "/Conta/Login";
                 });

            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultSqlServer"))
                );

            services.AddScoped(typeof(IFacadeCrud), typeof(FacadeCrud));
            services.AddScoped(typeof(IDAO<>), typeof(DAO<>));
            services.AddScoped(typeof(IDAOTabelaRel<>), typeof(DAOTabelaRel<>));
            services.AddScoped(typeof(IAgendarJob), typeof(ScheduleCarrinho));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // who are you?  
            app.UseAuthentication();

            // are you allowed?  
            app.UseAuthorization();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_BL.Extentions;
using MVC_BL.Helpers;
using MVC_BLL.InterfaceRepository;
using MVC_BLL.Repositories;
using MVC_DAL.Data;
using MVC_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("DefualtConnection")));
            services.AddApplicationServices();
            services.AddAutoMapper(M=>M.AddProfile(new MappingProfiles()));
			services.AddIdentity<AccountUser, IdentityRole>(Option =>
			{
				Option.Password.RequireNonAlphanumeric = true; // @ # $
				Option.Password.RequireDigit = true; //123
				Option.Password.RequireLowercase = true; //MNB
				Option.Password.RequireUppercase = true; // mnb
														 //P@ssw0rd

			})
				.AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            //services.AddScoped<UserManager<AccountUser>>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Option =>
            {
                Option.LoginPath = "Account/Login";
                Option.AccessDeniedPath = "Home/Error";
            });


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
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}

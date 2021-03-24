using System.Net;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Repositories.Context;
using Repositories.Generic;
using Services;
using Services.Generic;

namespace Web
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
            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();

            services.AddDbContextPool<RealStateDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Standard")));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<RealStateDbContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {

                //add this option to identity configuration
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 1;
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Home/Index";
            });
            // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            // .AddCookie(options =>
            // {
            //     options.Events.OnRedirectToAccessDenied = context =>
            //     {
            //         context.Response.StatusCode = 403;
            //         return Task.CompletedTask;
            //     };
            // });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IHouseService, HouseServiceX>();

            services.AddScoped<IGenericRepository<Province>, GenericRepository<Province>>();
            services.AddScoped<IGenericService<Province>, GenericService<Province>>();

            services.AddScoped<IGenericRepository<Feature>, GenericRepository<Feature>>();
            services.AddScoped<IGenericService<Feature>, GenericService<Feature>>();
            // // services.AddScoped<IGenericRepository<Item>, ItemRepository>();
            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IGenericRepository<Service>, GenericRepository<Service>>();
            services.AddScoped<IGenericService<Service>, GenericService<Service>>();
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
                // The default HSTS value is 30 days. You may want to change this for Itemion scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    // pattern: "{controller=Home}/{action=Index}/{id?}");
                    pattern: "{controller=Rent}/{action=List}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
using System;
using AutoMapper;
using Entities;
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContextPool<FoodTownDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Standard")));

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<FoodTownDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                //add this option to identity configuration
                options.User.RequireUniqueEmail = true;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IGenericRepository<Brand>, GenericRepository<Brand>>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IGenericService<Brand>, GenericService<Brand>>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
            services.AddScoped<IGenericService<Category>, GenericService<Category>>();

            services.AddScoped<IGenericRepository<Item>, ItemRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IItemService, ItemService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    // pattern: "{controller=Item}/{action=List}/{id?}");
                    pattern: "{controller=Item}/{action=List}/{id?}");
            });
        }
    }
}
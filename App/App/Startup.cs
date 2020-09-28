using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models.Entity;
using App.Repository;
using App.Repository.Interface;
using App.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            services.AddIdentity<AccountUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;    // 비밀번호 필수 8자 이상으로 설정
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<DBSeeder>();      // AddTransient: 필요할 때마다 생성되고 데이터가 캐시내에 머물지 않는다.
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IGoodsService, GoodsService>();
            services.AddScoped<IOrderService, OrderService>();


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DBSeeder seeder)
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            seeder.SeedDatabase().Wait();
        }
    }
}

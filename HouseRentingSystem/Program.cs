using HouseRentingSystem.Data;
using HouseRentingSystem.Extensions;
using HouseRentingSystem.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationDbContexts(builder.Configuration);

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddApplicationServices();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<HouseRentingDbContext>();

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
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

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}
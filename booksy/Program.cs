using Booksy.DAL;
using Booksy.Models;
using Booksy.BLL;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Booksy.Services;

namespace Booksy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext here
            builder.Services.AddDbContext<BooksyDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register DAL and BLL services
            builder.Services.AddScoped<AuthorDAL>();
            builder.Services.AddScoped<BookDAL>();
            builder.Services.AddScoped<SerieDAL>();
            builder.Services.AddScoped<SerieService>();
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<CommentService>();
            builder.Services.AddScoped<CommentDAL>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

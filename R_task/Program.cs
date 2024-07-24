using DataAccessLayer;

using DataACesslayer;

using IReprosastory;

using Microsoft.EntityFrameworkCore;

using ReprestoryServess;

using System.Configuration;

using ViewModel.MailSeting;

namespace R_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            IServiceCollection serviceCollection =
                builder.Services.AddDbContext<ApplicationDBcontext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
            builder.Services.AddTransient<DepartmentService>();
            builder.Services.AddTransient<UnitOfWork>();
            builder.Services.AddTransient<MailingService>();
            builder.Services.AddHostedService<ReminderSerivce>();    
            builder.Services.AddTransient<LookupService>();    
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

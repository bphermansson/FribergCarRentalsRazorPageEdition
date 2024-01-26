using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FribergCarRentalsRazorPageEdition.Data;
using FribergsCarRentals.DataAccess.Data;
namespace FribergCarRentalsRazorPageEdition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FribergCarRentalsRazorPageEditionContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FribergCarRentalsRazorPageEditionContext") ?? throw new InvalidOperationException("Connection string 'FribergCarRentalsRazorPageEditionContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<FribergCarRentalsDbContext>(options => options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FribergCarRentals; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False"));

            builder.Services.AddTransient<ICarsRepository, CarsRepository>();
            builder.Services.AddTransient<ICustomersRepository, CustomersRepository>();
            builder.Services.AddTransient<IBookingsRepository, BookingsRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}

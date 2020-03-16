using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMS.BL.Domain.General;
using SMS.DAL;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace SMS.Tests.BDD.Infra
{
    public class SmsWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {

        public IOptionManager OptionManager { get; private set; }
        public DbContextOptionsBuilder<SmsDbContext> DbBuilder { get; private set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<SmsDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<DbContext, SmsDbContext>(
                    options => options.UseSqlite("Filename=./SmsDb/SmsTest.db"), 
                                                                ServiceLifetime.Scoped);
                 var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DbContext>();

                    //open connection
                    db.Database.OpenConnectionAsync();
                    // Ensure the database is created.
                    db.Database.EnsureCreatedAsync();

                    db.Database.CloseConnectionAsync();

                    var optionManager = scopedServices.GetService<IOptionManager>();

                    OptionManager = optionManager;
                }
            });

        }
    }
}

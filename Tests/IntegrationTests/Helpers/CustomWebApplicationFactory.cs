using AutoCallsApi.Data.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Helpers;

public class CustomWebApplicationFactory<TProgram>
 : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<EfApplicationDbContext>));
            services.Remove(dbContextDescriptor!); 

            services.AddDbContext<EfApplicationDbContext>(options => 
            {
                options.UseInMemoryDatabase(new Guid().ToString());
            });
        });
    }
}
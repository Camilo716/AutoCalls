using AutoCallsApi.Data.EntityFramework;
using AutoCallsApi.Services.AudioPlayer;
using IntegrationTests.Helpers.ESL;
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
            ServiceDescriptor? dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<EfApplicationDbContext>));
            services.Remove(dbContextDescriptor!); 

            services.AddDbContext<EfApplicationDbContext>(options => 
            {
                options.UseInMemoryDatabase(new Guid().ToString());
            });


            ServiceDescriptor? IAudioPlayerFactoryDescriptor = services.SingleOrDefault(
                s => s.ServiceType == typeof(IAudioPlayerFactory)
            );
            services.Remove(IAudioPlayerFactoryDescriptor!);

            services.AddSingleton<IAudioPlayerFactory, DumbAudioPlayerFactory>();
        });
    }
}
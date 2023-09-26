using Microsoft.AspNetCore.Mvc.Testing;
using AutoCallsApi.Data.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.IntegrationTests.Helpers;

public static class DbContextUtilities
{
    public static EfApplicationDbContext GetDbContext(WebApplicationFactory<Program> factory)
    {
        var scope = factory.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<EfApplicationDbContext>();
        return db;
    }
}
using AutoCallsApi.Data.EntityFramework;
using IntegrationTests.Helpers;
using IntegrationTests.Helpers.Database;
using Test.Helpers.Database;

namespace IntegrationTests;

public partial class EnpointsTests 
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly EfApplicationDbContext _context;
    private readonly SeedDataIds _seedDataIds;

    public EnpointsTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _context = DbContextUtilities.GetDbContext(factory);
        _seedDataIds = DbUtilities.ReinitializeDbForTests(_context);
    }

    [Theory]
    [InlineData("/api/number")]
    public async Task ClientGetAll_ReturnSuccessTest(string url)
    {
        var client = _factory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", 
            response.Content.Headers.ContentType?.ToString());
    }
}
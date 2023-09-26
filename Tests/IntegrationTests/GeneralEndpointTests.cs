using AutoCallsApi.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc.Testing;
using Test.Helpers;
using Tests.IntegrationTests.Helpers;

namespace Tests.IntegrationTests;

public partial class EnpointsTests 
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly EfApplicationDbContext _context;

    public EnpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _context = DbContextUtilities.GetDbContext(factory);
        DbUtilities.ReinitializeDbForTests(_context);
    }

    [Theory]
    [InlineData("/api/number")]
    public async Task Get_EnpointsReturnSuccessAndCorrectContentType(string url)
    {
        var client = _factory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", 
            response.Content.Headers.ContentType?.ToString());
    }
}